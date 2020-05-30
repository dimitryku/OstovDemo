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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void методToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lb_verticle_Leave(object sender, EventArgs e)
        {
            if(lb_verticle.SelectedIndex != -1)
                lb_verticle.SetSelected(lb_verticle.SelectedIndex, false);
        }


        private void VerticleContextMenu_Opening(object sender, CancelEventArgs e)
        {
            if (lb_verticle.SelectedIndex == -1)
                e.Cancel = true;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            if(lb_verticle.SelectedIndex != -1)
                lb_verticle.SetSelected(lb_verticle.SelectedIndex, false);
            if(lb_edges.SelectedIndex != -1)
                lb_edges.SetSelected(lb_edges.SelectedIndex, false);
        }

        private void lb_edges_Leave(object sender, EventArgs e)
        {
            if(lb_edges.SelectedIndex != -1)
                lb_edges.SetSelected(lb_edges.SelectedIndex, false);
        }
    }
}
