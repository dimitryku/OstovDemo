using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
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
            // TODO Cruskal method
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

        private void bibaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Сгенерировать граф
            var GGForm = new GraphGenerateForm();
            if (GGForm.ShowDialog() == DialogResult.OK)
            {
                // GenerateGraph(GGForm.Count,GGForm.GenerateEdges);
            }
        }

        private void AddVerticle_btn_Click(object sender, EventArgs e)
        {
            // TODO add verticle
        }

        private void btn_add_edge_Click(object sender, EventArgs e)
        {
            // TODO add edge
        }

        private void методПримаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO Preem method
        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO help window
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO about window
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удвлить все элементы графа?", "Вы уверены?", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                // TODO clear graph
            }
        }

        private void Drawing_panel_Paint(object sender, PaintEventArgs e)
        {
            // TODO draw graph

            int x1 = 100, y1 = 100, x2 = 400, y2 = 400;

            const int verticleRadius = 20;
            int verticleRadiusDiagonale = verticleRadius * (int)Math.Sqrt(2);
            const float edgeWidth = 2;
            const float verticleBorderWidth = 3;
            const int vTextOffsetX = 12, vTextOffsetY = 10;
            const int eTextOffsetY = 15;
            


            // SETTINGS
            e.Graphics.SmoothingMode =
                SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint =
                TextRenderingHint.AntiAliasGridFit;
            e.Graphics.InterpolationMode =
                InterpolationMode.High;



            // EDGES
            e.Graphics.DrawLine(new Pen(Color.Black, edgeWidth), 
                x1, y1, 
                x2, y2);

            // VERICLES
            e.Graphics.FillEllipse(
                new SolidBrush(Color.White),
                new Rectangle(x1 - verticleRadiusDiagonale, y1 - verticleRadiusDiagonale,
                    verticleRadius*2, verticleRadius*2));
            e.Graphics.FillEllipse(
                new SolidBrush(Color.White),
                new Rectangle(x2 - verticleRadiusDiagonale, y2 - verticleRadiusDiagonale,
                    verticleRadius*2, verticleRadius*2));

            e.Graphics.DrawEllipse(new Pen(Color.Black, verticleBorderWidth),
                x1 - verticleRadiusDiagonale, y1 - verticleRadiusDiagonale,
                verticleRadius*2, verticleRadius*2);
            e.Graphics.DrawEllipse(new Pen(Color.Black, verticleBorderWidth),
                x2 - verticleRadiusDiagonale, y2 - verticleRadiusDiagonale,
                verticleRadius*2, verticleRadius*2);

            // VERTICLE CAPTIONS
            e.Graphics.DrawString("V1", lb_verticle.Font,
                new SolidBrush(Color.Black), x1 - vTextOffsetX, y1 - vTextOffsetY);
            e.Graphics.DrawString("V2", lb_verticle.Font,
                new SolidBrush(Color.Black), x2 - vTextOffsetX, y2 - vTextOffsetY);

            // EDGE CAPTIONS
            e.Graphics.DrawString("10", btn_add_edge.Font, 
                new SolidBrush(Color.Black),
                (float)(x1 + (x2 - x1)*0.3), (float)(y1 + (y2 - y1)*0.3 - eTextOffsetY));

        }
    }
}
