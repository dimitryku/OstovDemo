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
    public partial class CruskalFormcs : Form
    {
        public CruskalFormcs()
        {
            InitializeComponent();
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

        private DemoState curState = DemoState.NotStarted;
        private DemoMode curMode;
        public List<Verticle> Verticles;
        public List<Edge> Edges;
        private List<List<Verticle>> cruscalVertsList;
        private List<Edge> cruscalEdgesList;
        private bool currentEdgeApproved;
        private int currentEdge = -1;
        private bool firstPart = true;


        private void CruskalFormcs_Load(object sender, EventArgs e)
        {
            // TODO shit
            curMode = DemoMode.Slow;
            timer1.Interval = 750;
            cruscalEdgesList = new List<Edge>();
            cruscalEdgesList.AddRange(Edges);

            SortEdgesList(cruscalEdgesList);
            PrepareForMethod();

        }

        private void PrepareForMethod()
        {
            foreach (var ed in Edges) ed.condition = Condition.Waiting;
            cruscalVertsList = new List<List<Verticle>>();
            for (var i = 0; i < Verticles.Count(); i++)
            {
                var newlist = new List<Verticle> { Verticles[i] };
                cruscalVertsList.Add(newlist);
            }
            currentEdge = 0;
            next_btn.Enabled = (curMode == DemoMode.Manual);
            curState = DemoState.NotStarted;
            log_tb.Clear();
            firstPart = true;
            start_btn.Text = "Начать";

            drawing_panel.Refresh();
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
            else
            {
                cruscalVertsList[firstNum].AddRange(cruscalVertsList[secondNum]);
                cruscalVertsList[secondNum].Clear();
                cruscalVertsList.RemoveAt(secondNum);
                return true;
            }
        }

        private void SortEdgesList(List<Edge> edges)
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

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (MessageBox.Show("Вы действительно хотите сбросить текущий прогресс?", "Сброс прогресса метода",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                PrepareForMethod();
                drawing_panel.Refresh();
            }
            else
            {
                if (curMode != DemoMode.Manual) timer1.Start();
            }
            
        }

        private void next_btn_Click(object sender, EventArgs e)
        {
            if (curMode != DemoMode.Manual)
            {
                timer1.Stop();
                timer1_Tick(null, null);
                timer1.Start();
            }
            else
            {
                timer1_Tick(null, null);
                curState = DemoState.Going;
            }
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            switch (curState)
            {
                case DemoState.NotStarted: //start
                    PrepareForMethod();
                    next_btn.Enabled = true;
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
            // TODO
            if (firstPart)
            {
                // TODO выделение текущей грани и проверка
                if (currentEdge < cruscalEdgesList.Count())
                {
                    cruscalEdgesList[currentEdge].condition = Condition.Checking;
                    drawing_panel.Refresh();
                    currentEdgeApproved = CruscalIterations(cruscalEdgesList[currentEdge]);
                    
                }
                else
                {
                    timer1.Stop();
                    curState = DemoState.End;
                }

                firstPart = !firstPart;
            }
            else
            {
                // TODO Результат проверки
                log_tb.Text += cruscalEdgesList[currentEdge].A.name + " - " + cruscalEdgesList[currentEdge].B.name + Environment.NewLine;
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
                    if(currentEdge < Edges.Count() - 1)
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
                start_btn.Enabled = true;
                if (curState == DemoState.End || curState == DemoState.NotStarted)
                    next_btn.Enabled = false;
                // TODO
            }
        }

        private void rb_slow_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_slow.Checked)
            {
                curMode = DemoMode.Slow;
                timer1.Interval = 750;
                start_btn.Enabled = true;
                if (curState == DemoState.End || curState == DemoState.NotStarted)
                    next_btn.Enabled = false;

                // TODO
            }
        }

        private void rb_manual_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_manual.Checked)
            {
                timer1.Stop();
                curMode = DemoMode.Manual;
                next_btn.Enabled = true;
                start_btn.Enabled = false;
            }
        }

        private void drawing_panel_Paint(object sender, PaintEventArgs e)
        {
            Form1.DrawGraph(e, Verticles, cruscalEdgesList, false);
        }
    }
}
