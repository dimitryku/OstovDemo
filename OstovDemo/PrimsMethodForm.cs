using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


// all methods without comments is additional methods, needen for drawing
namespace OstovDemo
{
    public partial class PrimsMethodForm : Form
    {
        private List<Edge> AvailableEdges;
        private DemoMode curMode;
        private int currentEdge = -1;
        private DemoState curState = DemoState.NotStarted;
        private bool EdgeApproved;
        public List<Edge> Edges;
        private bool firstPart = true;
        private int numOfMinEdge;
        private List<Edge> primEdges;
        private HashSet<Verticle> UsedVerticles;
        public List<Verticle> Verticles;

        public PrimsMethodForm()
        {
            InitializeComponent();
        }

        // Start form
        private void PrimsMethodForm_Load(object sender, EventArgs e)
        {
            UsedVerticles = new HashSet<Verticle>();
            AvailableEdges = new List<Edge>();
            curMode = DemoMode.Slow;
            timer1.Interval = 750;
            numOfMinEdge = SearchForMinEdge(Edges);
            PrepareForMethod();
            RecalculateDrawingCoordinates();
        }

        // preparing to perform Prim method
        private void PrepareForMethod()
        {
            if (AvailableEdges.Any()) AvailableEdges.Clear();
            if (UsedVerticles.Any()) UsedVerticles.Clear();
            AvailableEdges.Add(Edges[numOfMinEdge]);
            UsedVerticles.Add(Edges[numOfMinEdge].A);

            foreach (var ed in Edges) ed.condition = Condition.Waiting;
            next_btn.Enabled = curMode == DemoMode.Manual;
            start_btn.Enabled = curMode != DemoMode.Manual;
            curState = DemoState.NotStarted;
            firstPart = false;
            currentEdge = 0;

            log_tb.Clear();
            log_tb.AppendText("Начало:" + Environment.NewLine + "Ребро " + Edges[numOfMinEdge].ToString() + Environment.NewLine + Environment.NewLine);
            start_btn.Text = "Начать";
            drawing_panel.Refresh();

            primEdges = new List<Edge>();
            primEdges.AddRange(Edges);
            primEdges.RemoveAt(numOfMinEdge);
        }

        // searching for edge with minimal weight
        private static int SearchForMinEdge(List<Edge> edges)
        {
            if (!edges.Any()) return -1;
            var num = 0;
            var minweight = edges[0].weight;
            for (var i = 0; i < edges.Count(); i++)
                if (edges[i].weight < minweight)
                {
                    minweight = edges[i].weight;
                    num = i;
                }

            return num;
        }

        private void RecalculateDrawingCoordinates()
        {
            if (Verticles == null || Edges == null)
                return;
            var drawingCentreX = drawing_panel.Width / 2;
            var drawingCentreY = drawing_panel.Height / 2;
            var radius = Math.Min(drawingCentreX, drawingCentreY) * 0.85;
            var deg = Math.PI * 2 / Verticles.Count;
            for (var i = 0; i < Verticles.Count; ++i)
            {
                var l_deg = i * deg;
                var x = drawingCentreX + radius * Math.Cos(l_deg);
                var y = drawingCentreY + radius * Math.Sin(l_deg);
                Verticles[i].point = new Point((int) x, (int) y);
            }
        }

        //Tick. Every tick performing its part of algorithm
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (firstPart)
            {
                EdgeApproved = false;
                // checking
                while (!EdgeApproved)
                {
                    currentEdge = SearchForMinEdge(AvailableEdges);
                    if (currentEdge == -1) break;
                    EdgeApproved = UsedVerticles.Contains(AvailableEdges[currentEdge].A) !=
                                   UsedVerticles.Contains(AvailableEdges[currentEdge].B);
                    if (!EdgeApproved) AvailableEdges.RemoveAt(currentEdge);
                }

                if (currentEdge != -1)
                    AvailableEdges[currentEdge].condition = Condition.Checking;
                else
                    TheEnd();
                if (curMode != DemoMode.NoAnime)
                    drawing_panel.Refresh();
                log_tb.AppendText("Доступное ребро с наименьшим весом:" + Environment.NewLine +
                    AvailableEdges[currentEdge].ToString() + Environment.NewLine + Environment.NewLine);

                firstPart = !firstPart;
                if(curMode == DemoMode.Manual)
                {
                    System.Threading.Thread.Sleep(150);
                    Timer1_Tick(null, null);
                }
            }
            else
            {
                // if check was successfull
                AvailableEdges[currentEdge].condition = Condition.Accept;
                UsedVerticles.Add(AvailableEdges[currentEdge].A);
                UsedVerticles.Add(AvailableEdges[currentEdge].B);
                if (curMode != DemoMode.NoAnime)
                    drawing_panel.Refresh();
                for (var i = 0; i < primEdges.Count; i++)
                    if (primEdges[i].A.Equals(AvailableEdges[currentEdge].A) ||
                        primEdges[i].A.Equals(AvailableEdges[currentEdge].B) ||
                        primEdges[i].B.Equals(AvailableEdges[currentEdge].B) ||
                        primEdges[i].B.Equals(AvailableEdges[currentEdge].A))
                    {
                        AvailableEdges.Add(primEdges[i]);
                        primEdges.Remove(primEdges[i]);
                        --i;
                    }

                AvailableEdges.RemoveAt(currentEdge);

                if (UsedVerticles.Count() == Verticles.Count())
                    TheEnd();

                firstPart = !firstPart;
            }
        }

        // finishing method
        private void TheEnd()
        {
            timer1.Stop();
            drawing_panel.Invalidate();
            curState = DemoState.End;
            next_btn.Enabled = false;
            start_btn.Enabled = false;
            log_tb.AppendText("Метод закончил работу");
            if (curMode != DemoMode.NoAnime)
                MessageBox.Show("Метод завершил свою работу, все вершины присоединены.", "Готово!",
                    MessageBoxButtons.OK);
        }

        //fast mode
        private void rb_fast_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_fast.Checked)
            {
                curMode = DemoMode.Fast;
                timer1.Interval = 250;
                start_btn.Enabled = curState != DemoState.End;
                next_btn.Enabled = false;
            }
        }

        //slow mode
        private void rb_slow_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_slow.Checked)
            {
                curMode = DemoMode.Slow;
                timer1.Interval = 750;
                start_btn.Enabled = curState != DemoState.End;
                next_btn.Enabled = false;
            }
        }

        //skip animation mode
        private void rb_noanime_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_noanime.Checked)
            {
                curMode = DemoMode.NoAnime;
                timer1.Interval = 1;
                start_btn.Enabled = curState != DemoState.End;
                next_btn.Enabled = false;
            }
        }

        //manual mode
        private void rb_manual_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_manual.Checked)
            {
                timer1.Stop();
                curMode = DemoMode.Manual;
                next_btn.Enabled = curState != DemoState.End;
                start_btn.Enabled = false;
            }
        }

        //start + pause + continue button
        private void start_btn_Click(object sender, EventArgs e)
        {
            switch (curState)
            {
                case DemoState.NotStarted: //start
                    curState = DemoState.Going;
                    start_btn.Text = "Пауза";
                    if (curMode != DemoMode.Manual) timer1.Start();
                    break;

                case DemoState.Going: //pause
                    timer1.Stop();
                    curState = DemoState.Paused;
                    start_btn.Text = "Продолжить";
                    break;

                case DemoState.Paused: //continue
                    start_btn.Text = "Пауза";
                    curState = DemoState.Going;
                    if (curMode != DemoMode.Manual) timer1.Start();
                    break;

                case DemoState.End: //ended already
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        // next button
        private void next_btn_Click(object sender, EventArgs e)
        {
            Timer1_Tick(null, null);
        }

        // reset button
        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MessageBox.Show("Вы действительно хотите сбросить текущий прогресс?", "Сброс прогресса метода",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                PrepareForMethod();
        }

        // close button
        private void button1_Click(object sender, EventArgs e)
        {
            GC.Collect();
            Close();
        }

        private void drawing_panel_Paint(object sender, PaintEventArgs e)
        {
            Form1.DrawGraph(e, Verticles, Edges, false);
        }

        private void PrimsMethodForm_Resize(object sender, EventArgs e)
        {
            RecalculateDrawingCoordinates();
            drawing_panel.Invalidate();
        }

        private void обновитьПоложениеВесовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.RandomizeWeightsPositions(Edges);
            drawing_panel.Invalidate();
        }
    }
}