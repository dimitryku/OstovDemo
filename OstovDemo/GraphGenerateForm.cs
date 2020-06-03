using System;
using System.Windows.Forms;

namespace OstovDemo
{
    public partial class GraphGenerateForm : Form
    {
        public int Count = 4;
        public bool GenerateEdges = true;

        public GraphGenerateForm()
        {
            InitializeComponent();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label_vertCount.Text = tb_vertCount.Value.ToString();
            Count = tb_vertCount.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cb_generateEdges_CheckedChanged(object sender, EventArgs e)
        {
            GenerateEdges = cb_generateEdges.Checked;
        }
    }
}