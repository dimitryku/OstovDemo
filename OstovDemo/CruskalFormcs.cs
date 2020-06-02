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
            Paused
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

        private void CruskalFormcs_Load(object sender, EventArgs e)
        {
            // TODO shit
            curMode = DemoMode.Slow;

            var cruscalVertsList = new List<List<Verticle>>();
            for (var i = 0; i < Verticles.Count(); i++)
            {
                var newlist = new List<Verticle> { Verticles[i] };
                cruscalVertsList.Add(newlist);
            }

            var cruscalEdgesList = new List<Edge>();
            cruscalEdgesList.AddRange(Edges);

            // TODO сортировка 
            SortEdgesList(cruscalEdgesList); //Пузырёк, вроде остальные методы явно быстрее только на больших числах


            foreach (var edge in cruscalEdgesList)
            {
                CruscalIterations(cruscalVertsList, edge);

                //Drawing_panel.Refresh();
                if (cruscalVertsList.Count() == 1) break;
            }

        }

        private bool CruscalIterations(List<List<Verticle>> cruscalVertsList, Edge edge) // возвращает false если не подходит, true если подходит
        {
            var a = false;
            var b = false;
            var firstNum = -1;
            var secondNum = 0;

            for (secondNum = 0; secondNum < cruscalVertsList.Count(); secondNum++)
            {
                a = a == true || cruscalVertsList[secondNum].Contains(edge.A);
                b = b == true || cruscalVertsList[secondNum].Contains(edge.B);
                if (a != b && firstNum == -1) firstNum = secondNum;
                if (a == true && b == true) break;
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
                // TODO
            }
        }

        private void rb_slow_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_slow.Checked)
            {
                curMode = DemoMode.Slow;
                // TODO
            }
        }

        private void rb_manual_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_manual.Checked)
            {
                curMode = DemoMode.Manual;
                // TODO
            }
        }
    }
}
