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
        public PrimsMethodForm()
        {
            InitializeComponent();
        }

        private void rb_fast_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_fast.Checked)
            {
                //curMode = DemoMode.Fast;
                timer1.Interval = 250;
                //if (curState != DemoState.End)
                    start_btn.Enabled = true;
                next_btn.Enabled = false;
            }
        }

        private void rb_slow_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_slow.Checked)
            {
                //curMode = DemoMode.Slow;
                timer1.Interval = 750;
                //if (curState != DemoState.End)
                    start_btn.Enabled = true;
                next_btn.Enabled = false;
            }
        }

        private void rb_noanime_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_noanime.Checked)
            {
                //curMode = DemoMode.NoAnime;
                timer1.Interval = 1;
                //if (curState != DemoState.End)
                    start_btn.Enabled = true;
                next_btn.Enabled = false;
            }
        }

        private void rb_manual_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_manual.Checked)
            {
                timer1.Stop();
                //curMode = DemoMode.Manual;
                //if (curState != DemoState.End)
                    next_btn.Enabled = true;
                start_btn.Enabled = false;
            }
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            //TODO start
        }

        private void next_btn_Click(object sender, EventArgs e)
        {
            //TODO next
        }

        private void button4_Click(object sender, EventArgs e) //reset
        {
            if (MessageBox.Show("Вы действительно хотите сбросить текущий прогресс?", "Сброс прогресса метода",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //TODO reset
            }
        }

        private void button1_Click(object sender, EventArgs e) //close
        {
            Close();
        }
    }
}
