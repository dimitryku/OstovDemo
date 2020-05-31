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

        private int _drawingCentreX, _drawingCentreY;
        private Verticle _selectedVerticle = null; // SELECTED

        private int _maxVertNum = 0;
        private List<Verticle> listOfVerticles = new List<Verticle>();
        private List<Edge> listOfEdges = new List<Edge>();

        public Form1()
        {
            InitializeComponent();
        }

        private void методToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO Cruskal method
            var cruscalVertsList = new List<List<Verticle>>();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RecalculateDrawingCoordinates();
        }

        private void RecalculateDrawingCoordinates()
        {
            _drawingCentreX = Drawing_panel.Width / 2;
            _drawingCentreY = Drawing_panel.Height / 2;
        }

        private void RenewLists()
        {
            var ver = listOfVerticles.Select(verticle => verticle.name).ToList();
            var edh = listOfEdges.Select(edge => edge.A.name + "-" + edge.B.name + " (" + edge.weight + ")").ToList();
            lb_verticle.Items.Clear();
            lb_edges.Items.Clear();
            foreach (var j in ver)
            {
                lb_verticle.Items.Add(j);
            }
            foreach (var j in edh)
            {
                lb_edges.Items.Add(j);
            }
        }

        private void lb_verticle_Leave(object sender, EventArgs e)
        {
            if (lb_verticle.SelectedIndex != -1)
                lb_verticle.SetSelected(lb_verticle.SelectedIndex, false);
        }


        private void VerticleContextMenu_Opening(object sender, CancelEventArgs e)
        {
            if (_selectedVerticle != null)
                e.Cancel = true;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            if (lb_verticle.SelectedIndex != -1)
                lb_verticle.SetSelected(lb_verticle.SelectedIndex, false);
            if (lb_edges.SelectedIndex != -1)
                lb_edges.SetSelected(lb_edges.SelectedIndex, false);
        }

        private void lb_edges_Leave(object sender, EventArgs e)
        {
            if (lb_edges.SelectedIndex != -1)
                lb_edges.SetSelected(lb_edges.SelectedIndex, false);
        }

        private void bibaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Сгенерировать граф
            var GGForm = new GraphGenerateForm();
            if (GGForm.ShowDialog() == DialogResult.OK)
            {
                ClearGraph();
                GenerateGraph(GGForm.Count, GGForm.GenerateEdges);
            }
        }

        private void GenerateGraph(int count, bool gedges)
        {
            for (int i = 0; i < count; i++)
                listOfVerticles.Add(new Verticle("V" + ++_maxVertNum));

            if (gedges)
            {
                Random rnd = new Random();
                for (var i = 0; i < listOfVerticles.Count() - 1; i++)
                    for (var j = i + 1; j < listOfVerticles.Count(); j++)
                        if ((rnd.Next() % 100) < 20)
                            listOfEdges.Add(new Edge(listOfVerticles[i], listOfVerticles[j]));
            }

            RecalculateDrawingCoordinates();
            RenewLists();

        }

        private void ClearGraph()
        {
            listOfEdges.Clear();
            listOfVerticles.Clear();
            _maxVertNum = 0;
            RenewLists();

        }

        private void AddVerticle_btn_Click(object sender, EventArgs e)
        {
            // TODO add verticle
            if(listOfVerticles.Count >= 15)
            {
                AddVerticle_btn.Enabled = false;
                return;
            }
            var newvwrt = new Verticle("V" + ++_maxVertNum);
            listOfVerticles.Add(newvwrt);
            RecalculateDrawingCoordinates();
            RenewLists();

        }

        private void btn_add_edge_Click(object sender, EventArgs e)
        {
            // TODO add edge
            var aef = new AddEdgeForm();
            aef.Verticles = listOfVerticles;
            aef.Edges = listOfEdges;
            aef.ShowDialog();
            if (aef.DialogResult != DialogResult.OK) return;
            listOfEdges.Add(aef.Return);
            RecalculateDrawingCoordinates();
            RenewLists();
            Drawing_panel.Refresh();
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


            const int verticleRadius = 20;
            int verticleRadiusDiagonale = verticleRadius * (int)Math.Sqrt(2);
            const float edgeWidth = 2;
            const float verticleBorderWidth = 3;
            


            // SETTINGS
            e.Graphics.SmoothingMode =
                SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint =
                TextRenderingHint.AntiAliasGridFit;
            e.Graphics.InterpolationMode =
                InterpolationMode.High;



            // EDGES
            foreach (var edge in listOfEdges)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, edgeWidth), 
                    edge.A.point, 
                    edge.B.point);
            }

            // VERICLES
            foreach (var verticle in listOfVerticles)
            {
                e.Graphics.FillEllipse(
                    new SolidBrush(Color.White),
                    new Rectangle(verticle.point.X - verticleRadiusDiagonale, verticle.point.Y - verticleRadiusDiagonale,
                        verticleRadius*2, verticleRadius*2));
                e.Graphics.DrawEllipse(new Pen(Color.Black, verticleBorderWidth),
                    verticle.point.X - verticleRadiusDiagonale, verticle.point.Y - verticleRadiusDiagonale,
                    verticleRadius*2, verticleRadius*2);
            }

            //e.Graphics.FillEllipse(
            //    new SolidBrush(Color.White),
            //    new Rectangle(x1 - verticleRadiusDiagonale, y1 - verticleRadiusDiagonale,
            //        verticleRadius*2, verticleRadius*2));
            //e.Graphics.FillEllipse(
            //    new SolidBrush(Color.White),
            //    new Rectangle(x2 - verticleRadiusDiagonale, y2 - verticleRadiusDiagonale,
            //        verticleRadius*2, verticleRadius*2));

            //e.Graphics.DrawEllipse(new Pen(Color.Black, verticleBorderWidth),
            //    x1 - verticleRadiusDiagonale, y1 - verticleRadiusDiagonale,
            //    verticleRadius*2, verticleRadius*2);
            //e.Graphics.DrawEllipse(new Pen(Color.Black, verticleBorderWidth),
            //    x2 - verticleRadiusDiagonale, y2 - verticleRadiusDiagonale,
            //    verticleRadius*2, verticleRadius*2);

            // VERTICLE CAPTIONS

            foreach (var verticle in listOfVerticles)
            {
                int vTextOffsetX = 12 + 5*(verticle.name.Length - 2), vTextOffsetY = 10;
                e.Graphics.DrawString(verticle.name, lb_verticle.Font,
                    new SolidBrush(Color.Black), verticle.point.X - vTextOffsetX, verticle.point.Y - vTextOffsetY);
            }
            
            //int vTextOffsetX = 12 + 5*(name1.Length - 2), vTextOffsetY = 10;
            //e.Graphics.DrawString(name1, lb_verticle.Font,
            //    new SolidBrush(Color.Black), x1 - vTextOffsetX, y1 - vTextOffsetY);

            //vTextOffsetX = 12 + 5 * (name2.Length - 2);
            //e.Graphics.DrawString(name2, lb_verticle.Font,
            //    new SolidBrush(Color.Black), x2 - vTextOffsetX, y2 - vTextOffsetY);

            // EDGE CAPTIONS

            foreach (var edge in listOfEdges)
            {
                int x1 = edge.A.point.X, y1 = edge.A.point.Y;
                int x2 = edge.B.point.X, y2 = edge.B.point.Y;
                int ax = x2-x1, ay = y2-y1;
                int dx = -ay/ax*8, dy = 8;
                e.Graphics.DrawString("10", btn_add_edge.Font, 
                    new SolidBrush(Color.Black),
                    (float)(x1 + (x2 - x1)*0.3) - dx, (float)(y1 + (y2 - y1)*0.3 - dy));
            }
            //int ax = x2-x1, ay = y2-y1;
            //int dx = -ay/ax*8, dy = 8;
            //e.Graphics.DrawString("10", btn_add_edge.Font, 
            //    new SolidBrush(Color.Black),
            //    (float)(x1 + (x2 - x1)*0.3) - dx, (float)(y1 + (y2 - y1)*0.3 - dy));

        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удвлить вершину?", "Вы уверены?", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                // TODO delete verticle
            }
        }

        private void lb_verticle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lb_verticle.SelectedIndex == -1) return;
            // TODO _selectedVerticle = ...
        }

        private void Drawing_panel_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Right && e.Button != MouseButtons.Left) return;
            // TODO check if it was click on verticle
            
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            RecalculateDrawingCoordinates();
        }
    }
}
