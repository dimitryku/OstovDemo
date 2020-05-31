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
    public partial class GraphGenerateForm : Form
    {
        public GraphGenerateForm()
        {
            InitializeComponent();
        }

        public int Count = 4;
        public bool GenerateEdges = true;

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label_vertCount.Text = tb_vertCount.Value.ToString();
            Count = tb_vertCount.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cb_generateEdges_CheckedChanged(object sender, EventArgs e)
        {
            GenerateEdges = cb_generateEdges.Checked;
        }
    }
}
