using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

// ReSharper disable ArrangeTypeMemberModifiers

namespace OstovDemo
{
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


        private void CruskalFormcs_Load(object sender, EventArgs e)
        {
            curMode = DemoMode.Slow;
            timer1.Interval = 750;
            cruscalEdgesList = new List<Edge>();
            cruscalEdgesList.AddRange(Edges);

            SortEdgesList(cruscalEdgesList);
            PrepareForMethod();
            RecalculateDrawingCoordinates();
            drawing_panel.Refresh();
        }

        private void PrepareForMethod()
        {
            foreach (var ed in Edges) ed.condition = Condition.Waiting;
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

            var rnd = new Random(DateTime.UtcNow.Millisecond);
            foreach (var edge in cruscalEdgesList) edge.weightPosition = 0.3f + 0.4f * (float) rnd.NextDouble();
        }

        private bool CruscalIterations(Edge edge) // возвращает false если не подходит, true если подходит
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

        private void button1_Click(object sender, EventArgs e) //close
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e) //reset
        {
            timer1.Stop();
            if (MessageBox.Show("Вы действительно хотите сбросить текущий прогресс?", "Сброс прогресса метода",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                PrepareForMethod();
                foreach (var edge in cruscalEdgesList) edge.condition = Condition.Waiting;
                drawing_panel.Refresh();
            }
            else
            {
                if (curMode != DemoMode.Manual) timer1.Start();
            }
        }

        private void next_btn_Click(object sender, EventArgs e)
        {
            curState = DemoState.Going;
            timer1_Tick(null, null);
        }

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Проверка
            if (firstPart)
            {
                cruscalEdgesList[currentEdge].condition = Condition.Checking;
                drawing_panel.Refresh();
                currentEdgeApproved = CruscalIterations(cruscalEdgesList[currentEdge]);

                firstPart = !firstPart;
            }
            else
            {
                // Результат проверки
                log_tb.Text += cruscalEdgesList[currentEdge].A.name + " - " + cruscalEdgesList[currentEdge].B.name +
                              " (" + cruscalEdgesList[currentEdge].weight.ToString() + ") " + Environment.NewLine;
                if (currentEdgeApproved)
                {
                    cruscalEdgesList[currentEdge].condition = Condition.Accept;
                    log_tb.Text += "Подходит" + Environment.NewLine + Environment.NewLine;
                    drawing_panel.Refresh();
                }
                else
                {
                    log_tb.Text += "Не подходит" + Environment.NewLine + Environment.NewLine;
                    cruscalEdgesList[currentEdge].condition = Condition.Waiting;
                    drawing_panel.Refresh();
                }

                if (cruscalVertsList.Count() == 1)
                {
                    timer1.Stop();
                    curState = DemoState.End;
                    next_btn.Enabled = false;
                    start_btn.Text = "Начать";
                    start_btn.Enabled = false;
                    if (currentEdge < Edges.Count() - 1)
                        log_tb.Text += "Остальные ребра не подходят" + Environment.NewLine;

                    MessageBox.Show("Метод завершил свою работу, все вершины присоединены.", "Готово!",
                        MessageBoxButtons.OK);
                }

                firstPart = !firstPart;
                ++currentEdge;
            }
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

        private void drawing_panel_Paint(object sender, PaintEventArgs e)
        {
            Form1.DrawGraph(e, Verticles, cruscalEdgesList, false);
        }

        private void CruskalFormcs_Resize(object sender, EventArgs e)
        {
            RecalculateDrawingCoordinates();
            drawing_panel.Refresh();
        }

        enum DemoState
        {
            NotStarted,
            Going,
            Paused,
            End
        }


        enum DemoMode
        {
            Fast,
            Slow,
            Manual
        }
    }
}