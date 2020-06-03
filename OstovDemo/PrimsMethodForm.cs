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

        private List<Edge> AvailableEdges;
        private List<Edge> UsedEdges;
        private List<Verticle> UsedVerticles;

        public PrimsMethodForm()
        {
            InitializeComponent();
        }

        private void PrepareForMethod()
        {
            foreach (var ed in Edges) ed.condition = Condition.Waiting;
            next_btn.Enabled = curMode == DemoMode.Manual;
            start_btn.Enabled = curMode != DemoMode.Manual;
            curState = DemoState.NotStarted;
            log_tb.Clear();
            start_btn.Text = "Начать";
            drawing_panel.Refresh();
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
    }
}
