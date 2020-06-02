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

        private void CruskalFormcs_Load(object sender, EventArgs e)
        {
            // TODO shit
            curMode = DemoMode.Slow;
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
