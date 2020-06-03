using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OstovDemo
{
    public partial class PrimsMethodForm : Form
    {
        public List<Edge> Edges;
        public List<Verticle> Verticles;
        private DemoState curState = DemoState.NotStarted;
        private DemoMode curMode;
        private int numOfMinEdge = 0;
        private int currentEdge = -1;
        private bool EdgeApproved = false;
        private bool firstPart = true;
        private List<Edge> AvailableEdges;
        //private HashSet<Edge> UsedEdges;
        private HashSet<Verticle> UsedVerticles;
        private List<Edge> primEdges;

        private void PrimsMethodForm_Load(object sender, EventArgs e)
        {
            //UsedEdges = new HashSet<Edge>();
            UsedVerticles = new HashSet<Verticle>();
            AvailableEdges = new List<Edge>();
            curMode = DemoMode.Slow;
            timer1.Interval = 750;
            numOfMinEdge = SearchForMinEdge(Edges);
            PrepareForMethod();
            RecalculateDrawingCoordinates();
        }

        public PrimsMethodForm()
        {
            InitializeComponent();
        }

        private void PrepareForMethod()
        {
            if (AvailableEdges.Count() > 0) AvailableEdges.Clear();
            //if (UsedEdges.Count() > 0)  UsedEdges.Clear();
            if (UsedVerticles.Count() > 0)  UsedVerticles.Clear();
            AvailableEdges.Add(Edges[numOfMinEdge]);
            UsedVerticles.Add(Edges[numOfMinEdge].A);

            foreach (var ed in Edges) ed.condition = Condition.Waiting;
            next_btn.Enabled = curMode == DemoMode.Manual;
            start_btn.Enabled = curMode != DemoMode.Manual;
            curState = DemoState.NotStarted;
            firstPart = true;

            log_tb.Clear();
            start_btn.Text = "Начать";
            drawing_panel.Refresh();

            primEdges = new List<Edge>();
            primEdges.AddRange(Edges);
            primEdges.RemoveAt(numOfMinEdge);
        }

        private static int SearchForMinEdge(List<Edge> edges)
        {
            if (edges.Count() < 1) return -1;
            var num = 0;
            int minweight = edges[0].weight;
            for(var i = 0; i < edges.Count(); i++)
            {
                if(edges[i].weight < minweight)
                {
                    minweight = edges[i].weight;
                    num = i;
                }
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

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if(firstPart)
            {
                EdgeApproved = false;
                //выделяем и проверяем, что грань только одним концом в массиве использованных вершин
                while (!EdgeApproved)
                {
                    currentEdge = SearchForMinEdge(AvailableEdges);
                    if (currentEdge == -1) break;
                    EdgeApproved = (UsedVerticles.Contains(AvailableEdges[currentEdge].A) !=
                    UsedVerticles.Contains(AvailableEdges[currentEdge].B));
                    if (!EdgeApproved) AvailableEdges.RemoveAt(currentEdge);
                }

                if (currentEdge != -1)
                {
                    AvailableEdges[currentEdge].condition = Condition.Checking;
                    EdgeApproved = (UsedVerticles.Contains(AvailableEdges[currentEdge].A) !=
                        UsedVerticles.Contains(AvailableEdges[currentEdge].B));
                }
                else
                {
                    TheEnd();
                }
                drawing_panel.Refresh();
                firstPart = !firstPart;
            }
            else
            {
                //перевыделяем грань и меняем листы, проверяем
                AvailableEdges[currentEdge].condition = Condition.Accept;
                //UsedEdges.Add(AvailableEdges[currentEdge]);
                UsedVerticles.Add(AvailableEdges[currentEdge].A);
                UsedVerticles.Add(AvailableEdges[currentEdge].B);
                drawing_panel.Refresh();
                for(int i = 0; i < primEdges.Count(); i++)
                {
                    if(primEdges[i].A == AvailableEdges[currentEdge].A || primEdges[i].A == AvailableEdges[currentEdge].B ||
                    primEdges[i].B == AvailableEdges[currentEdge].B || primEdges[i].B == AvailableEdges[currentEdge].A)
                    {
                        AvailableEdges.Add(primEdges[i]);
                        primEdges.Remove(primEdges[i]);
                    }
                }
                AvailableEdges.RemoveAt(currentEdge);

                if (UsedVerticles.Count() == Verticles.Count())
                    TheEnd();

                firstPart = !firstPart;
            }
        }

        private void TheEnd()
        {
            timer1.Stop();
            if (curMode != DemoMode.NoAnime)
                MessageBox.Show("Метод завершил свою работу, все вершины присоединены.", "Готово!",
                MessageBoxButtons.OK);
            drawing_panel.Invalidate();
            next_btn.Enabled = false;
            start_btn.Enabled = false;
        }

        private void rb_fast_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_fast.Checked)
            {
                curMode = DemoMode.Fast;
                timer1.Interval = 250;
                if (curState != DemoState.End)
                    start_btn.Enabled = true;
                next_btn.Enabled = false;
            }
        }

        private void rb_slow_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_slow.Checked)
            {
                curMode = DemoMode.Slow;
                timer1.Interval = 750;
                if (curState != DemoState.End)
                    start_btn.Enabled = true;
                next_btn.Enabled = false;
            }
        }

        private void rb_noanime_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_noanime.Checked)
            {
                curMode = DemoMode.NoAnime;
                timer1.Interval = 1;
                if (curState != DemoState.End)
                    start_btn.Enabled = true;
                next_btn.Enabled = false;
            }
        }

        private void rb_manual_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_manual.Checked)
            {
                timer1.Stop();
                curMode = DemoMode.Manual;
                if (curState != DemoState.End)
                    next_btn.Enabled = true;
                start_btn.Enabled = false;
            }
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            //TODO start
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

        private void next_btn_Click(object sender, EventArgs e)
        {
            curState = DemoState.Going;
            Timer1_Tick(null, null);
        }

        private void button4_Click(object sender, EventArgs e) //reset
        {
            timer1.Stop();
            if (MessageBox.Show("Вы действительно хотите сбросить текущий прогресс?", "Сброс прогресса метода",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //TODO reset
                PrepareForMethod();
            }
        }

        private void button1_Click(object sender, EventArgs e) //close
        {
            Close();
        }

        private void drawing_panel_Paint(object sender, PaintEventArgs e)
        {
            Form1.DrawGraph(e,Verticles, Edges, false);
        }

        private void PrimsMethodForm_Resize(object sender, EventArgs e)
        {
            RecalculateDrawingCoordinates();
            drawing_panel.Invalidate();
        }
    }
}
