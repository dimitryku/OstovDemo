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
        private bool 

        private void CruskalFormcs_Load(object sender, EventArgs e)
        {
            // TODO shit
            curMode = DemoMode.Slow;
            PrepareForMethod();

            foreach (var edge in cruscalEdgesList)
            {
                bool result = CruscalIterations(cruscalVertsList, edge);
                if (cruscalVertsList.Count() == 1) break;
            }

        }

        private void PrepareForMethod()
        {
            cruscalVertsList = new List<List<Verticle>>();
            for (var i = 0; i < Verticles.Count(); i++)
            {
                var newlist = new List<Verticle> { Verticles[i] };
                cruscalVertsList.Add(newlist);
            }

            cruscalEdgesList = new List<Edge>();
            cruscalEdgesList.AddRange(Edges);

            SortEdgesList(cruscalEdgesList);
        }

        private bool CruscalIterations(List<List<Verticle>> cruscalVertsList, Edge edge) // возвращает false если не подходит, true если подходит
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
                //TODO подтвердили нахождение подходящего ребра, пока выводим результат на консоль.
                //Console.WriteLine(edge.weight + " " + edge.A.name + " " + edge.B.name);
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
            // TODO close
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // TODO reset
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
            }
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            switch (curState)
            {
                case DemoState.NotStarted:
                    // TODO start
                    break;
                case DemoState.Going:
                    // TODO pause

                    break;
                case DemoState.Paused:
                    // TODO start
                    break;
                case DemoState.End:
                    // TODO nothing
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // TODO
        }

        private void rb_fast_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_fast.Checked)
            {
                curMode = DemoMode.Fast;
                timer1.Interval = 250;
                // TODO
            }
        }

        private void rb_slow_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_slow.Checked)
            {
                curMode = DemoMode.Slow;
                timer1.Interval = 750;
                // TODO
            }
        }

        private void rb_manual_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_manual.Checked)
            {
                curMode = DemoMode.Manual;
                timer1.Stop();
                
            }
        }
    }
}
