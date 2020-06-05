using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


// ReSharper disable ArrangeTypeMemberModifiers
// all methods without comments is additional methods, needen for drawing
namespace OstovDemo
{
    internal enum DemoState
    {
        NotStarted,
        Going,
        Paused,
        End
    }


    internal enum DemoMode
    {
        Fast,
        Slow,
        Manual,
        NoAnime
    }

    public partial class CruskalFormcs : Form
    {
        private List<Edge> cruscalEdgesList;
        private List<List<Verticle>> cruscalVertsList;
        private DemoMode curMode;
        private int currentEdge = -1;
        private bool currentEdgeApproved;
        private DemoState curState = DemoState.NotStarted;
        public List<Edge> Edges;
        private bool firstPart = true;
        public List<Verticle> Verticles;

        public CruskalFormcs()
        {
            InitializeComponent();
        }

        // Start form
        private void CruskalFormcs_Load(object sender, EventArgs e)
        {
            curMode = DemoMode.Slow;
            timer1.Interval = 750;
            cruscalEdgesList = new List<Edge>();
            cruscalEdgesList.AddRange(Edges);

            SortEdgesList(cruscalEdgesList);
            PrepareForMethod();
            RecalculateDrawingCoordinates();
            Form1.RandomizeWeightsPositions(cruscalEdgesList);
            drawing_panel.Refresh();
        }

        // preparing to perform Kruscal method
        private void PrepareForMethod()
        {
            foreach (var ed in cruscalEdgesList) ed.condition = Condition.Waiting;
            cruscalVertsList = new List<List<Verticle>>();
            for (var i = 0; i < Verticles.Count(); i++)
            {
                var newlist = new List<Verticle> {Verticles[i]};
                cruscalVertsList.Add(newlist);
            }

            currentEdge = 0;
            next_btn.Enabled = curMode == DemoMode.Manual;
            start_btn.Enabled = curMode != DemoMode.Manual;
            curState = DemoState.NotStarted;
            log_tb.Clear();
            firstPart = true;
            start_btn.Text = "Начать";
            RefreshSets();
            drawing_panel.Refresh();
        }

        private void RecalculateDrawingCoordinates()
        {
            if (Verticles == null || cruscalEdgesList == null)
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

        // checking edge
        private bool CruscalIterations(Edge edge)
        {
            var a = false;
            var b = false;
            var firstNum = -1;
            var secondNum = 0;

            for (secondNum = 0; secondNum < cruscalVertsList.Count(); secondNum++)
            {
                a = a || cruscalVertsList[secondNum].Contains(edge.A);
                b = b || cruscalVertsList[secondNum].Contains(edge.B);
                if (a != b && firstNum == -1) firstNum = secondNum;
                if (a && b) break;
            }

            if (firstNum == -1) return false;

            cruscalVertsList[firstNum].AddRange(cruscalVertsList[secondNum]);
            cruscalVertsList[secondNum].Clear();
            cruscalVertsList.RemoveAt(secondNum);
            return true;
        }

        // sort method. Using bubble sort because of its speed on small Lists
        private static void SortEdgesList(IList<Edge> edges)
        {
            var wasChanged = true;
            while (wasChanged)
            {
                wasChanged = false;
                for (var i = 0; i < edges.Count() - 1; i++)
                {
                    if (edges[i].weight <= edges[i + 1].weight) continue;
                    var temp = new Edge(edges[i]);
                    edges[i] = new Edge(edges[i + 1]);
                    edges[i + 1] = new Edge(temp);
                    wasChanged = true;
                }
            }
        }

        //close button
        private void button1_Click(object sender, EventArgs e) 
        {
            GC.Collect();
            Close();
        }

        //reset button
        private void button4_Click(object sender, EventArgs e) 
        {
            timer1.Stop();
            if (MessageBox.Show("Вы действительно хотите сбросить текущий прогресс?", "Сброс прогресса метода",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                PrepareForMethod();
            }
            else
            {
                if (curMode != DemoMode.Manual) timer1.Start();
            }
        }

        //next button
        private void next_btn_Click(object sender, EventArgs e)
        {
            timer1_Tick(null, null);
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

        //Tick. Every tick performing its part of algorithm
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Checking
            if (firstPart)
            {
                cruscalEdgesList[currentEdge].condition = Condition.Checking;
                log_tb.AppendText(cruscalEdgesList[currentEdge] + Environment.NewLine);
                if (curMode != DemoMode.NoAnime)
                    drawing_panel.Refresh();
                currentEdgeApproved = CruscalIterations(cruscalEdgesList[currentEdge]);

                firstPart = !firstPart;
            }
            else
            {
                // Checking result
                if (currentEdgeApproved)
                {
                    cruscalEdgesList[currentEdge].condition = Condition.Accept;
                    log_tb.Text += "Подходит" + Environment.NewLine + Environment.NewLine;
                    log_tb.SelectionStart = log_tb.Text.Length;
                    log_tb.ScrollToCaret();
                }
                else
                {
                    log_tb.Text += "Не подходит" + Environment.NewLine + Environment.NewLine;
                    cruscalEdgesList[currentEdge].condition = Condition.Waiting;
                    log_tb.SelectionStart = log_tb.Text.Length;
                    log_tb.ScrollToCaret();
                }

                if (curMode != DemoMode.NoAnime)
                    drawing_panel.Invalidate();

                RefreshSets();

                if (cruscalVertsList.Count() == 1)
                {
                    timer1.Stop();
                    curState = DemoState.End;
                    next_btn.Enabled = false;
                    start_btn.Text = "Начать";
                    start_btn.Enabled = false;
                    if (currentEdge < Edges.Count() - 1)
                        log_tb.Text += "Остальные ребра не подходят" + Environment.NewLine;
                    else log_tb.Text += "Конец списка рёбер" + Environment.NewLine;
                    log_tb.SelectionStart = log_tb.Text.Length;
                    log_tb.ScrollToCaret();

                    if (curMode != DemoMode.NoAnime)
                        MessageBox.Show("Метод завершил свою работу, все вершины присоединены.", "Готово!",
                            MessageBoxButtons.OK);
                    drawing_panel.Invalidate();
                }

                firstPart = !firstPart;
                ++currentEdge;
            }
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
                if (curState == DemoState.Going) timer1.Start();
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
                if (curState == DemoState.Going) timer1.Start();
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

        //special additional methods
        private void drawing_panel_Paint(object sender, PaintEventArgs e)
        {
            Form1.DrawGraph(e, Verticles, cruscalEdgesList, false);
        }

        private void CruskalFormcs_Resize(object sender, EventArgs e)
        {
            RecalculateDrawingCoordinates();
            drawing_panel.Refresh();
        }

        private void RefreshSets()
        {
            var s = "";
            foreach (var lst in cruscalVertsList)
            {
                s += "{";

                foreach (var verticle in lst)
                {
                    s += verticle.name;
                    if (!Equals(verticle, lst.Last()))
                        s += ", ";
                }

                s += "}";
                if (!Equals(lst, cruscalVertsList.Last()))
                    s += ", ";
            }

            label_sets.Text = s;
        }


        private void CruskalFormcs_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
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
                if (curState == DemoState.Going) timer1.Start();
            }
        }

        private void обновитьПоложениеВесовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.RandomizeWeightsPositions(cruscalEdgesList);
            drawing_panel.Invalidate();
        }
    }
}