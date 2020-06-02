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
            if (GraphIsConnected())
            {
                // TODO Cruskal method
                var cruscalVertsList = new List<List<Verticle>>();
                for (var i = 0; i < listOfVerticles.Count(); i++)
                {
                    var newlist = new List<Verticle>();
                    newlist.Add(new Verticle(listOfVerticles[i]));
                    cruscalVertsList.Add(newlist);
                }

                var cruscalEdgesList = new List<Edge>();
                cruscalEdgesList.AddRange(listOfEdges);

                // TODO сортировка

                foreach (var edge in cruscalEdgesList)
                {
                    var a = false;
                    var b = false;
                    var firstNum = -1;
                    var secondNum = 0;

                    for (secondNum = 0; secondNum < cruscalVertsList.Count(); secondNum++)
                    {
                        a = a == true ? true : cruscalVertsList[secondNum].Contains(edge.A);
                        b = b == true ? true : cruscalVertsList[secondNum].Contains(edge.B);
                        if (a != b && firstNum == -1) firstNum = secondNum;
                        if (a == b == true) break;
                    }

                    if (firstNum == -1) continue;
                    else
                    {
                        cruscalVertsList[firstNum].AddRange(cruscalVertsList[secondNum]);
                        cruscalVertsList[secondNum].Clear();
                        cruscalVertsList.RemoveAt(secondNum);
                        //TODO подтвердили нахождение подходящего ребра, выполняем вывод на экран.
                        Console.WriteLine(edge.weight); //test, looks like passed
                    }

                    if (cruscalVertsList.Count() == 1) break;
                }
            }
            else
            {
                // TODO Обработка неполного массива (предложить дополнить или пусть сам)
                Console.WriteLine("NO WAY!"); // test, passed
            }
        }

        private bool GraphIsConnected()
        {
            var checkList = new List<List<Verticle>>();
            for (var i = 0; i < listOfVerticles.Count(); i++)
            {
                var newlist = new List<Verticle>();
                newlist.Add(new Verticle(listOfVerticles[i]));
                checkList.Add(newlist);
            }

            foreach (var edge in listOfEdges)
            {
                var a = false;
                var b = false;
                var firstNum = -1;
                var secondNum = 0;

                for (secondNum = 0; secondNum < checkList.Count(); secondNum++)
                {
                    a = a == true ? true : checkList[secondNum].Contains(edge.A);
                    b = b == true ? true : checkList[secondNum].Contains(edge.B);
                    if (a != b && firstNum == -1) firstNum = secondNum;
                    if (a == b == true) break;
                }

                if (firstNum == -1) continue;
                else
                {
                    checkList[firstNum].AddRange(checkList[secondNum]);
                    checkList[secondNum].Clear();
                    checkList.RemoveAt(secondNum);
                }

                if (checkList.Count() == 1) return true;
            }

            return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RecalculateDrawingCoordinates();
        }

        private void RecalculateDrawingCoordinates()
        {
            _drawingCentreX = Drawing_panel.Width / 2;
            _drawingCentreY = Drawing_panel.Height / 2;
            var radius = Math.Min(_drawingCentreX, _drawingCentreY) * 0.9;
            var deg = Math.PI * 2 / listOfVerticles.Count;
            for (var i = 0; i < listOfVerticles.Count; ++i)
            {
                var l_deg = i * deg;
                var x = _drawingCentreX + radius * Math.Cos(l_deg);
                var y = _drawingCentreY + radius * Math.Sin(l_deg);
                listOfVerticles[i].point = new Point((int)x, (int)y);
            }
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
            Drawing_panel.Refresh();
            if (GGForm.Count > 10 && this.WindowState != FormWindowState.Maximized)
            {
                if (MessageBox.Show("Развернуть окно для лучшего отображения графа?", "Большой граф",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.WindowState = FormWindowState.Maximized;
                }
            }
        }

        private void GenerateGraph(int count, bool gedges)
        {
            for (int i = 0; i < count; i++)
                listOfVerticles.Add(new Verticle("V" + ++_maxVertNum));

            Random rnd = new Random(DateTime.UtcNow.Millisecond);
            if (gedges)
                for (var i = 0; i < listOfVerticles.Count() - 1; i++)
                    for (var j = i + 1; j < listOfVerticles.Count(); j++)
                        if ((rnd.Next() % 100) < 20)
                        {
                            listOfEdges.Add(new Edge(listOfVerticles[i], listOfVerticles[j], (rnd.Next() % 49) + 1));
                            ++listOfVerticles[i].connections;
                            ++listOfVerticles[j].connections;
                        }

            foreach (var verticle in listOfVerticles)
            {
                if (verticle.connections == 0)
                {
                    var ptr = -1;
                    while (ptr == -1 || listOfVerticles[ptr] == verticle)
                        ptr = rnd.Next() % listOfVerticles.Count();
                    listOfEdges.Add(new Edge(verticle, listOfVerticles[ptr], (rnd.Next() % 49) + 1));
                    ++verticle.connections;
                    ++listOfVerticles[ptr].connections;
                }
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
            Drawing_panel.Refresh();

        }

        private void btn_add_edge_Click(object sender, EventArgs e)
        {
            var aef = new AddEdgeForm {Verticles = listOfVerticles, Edges = listOfEdges};
            if(listOfVerticles.Count < 2)
            {
                MessageBox.Show("В графе менее 2 вершин, создать ребро нельзя.");
                return;
            }
            aef.ShowDialog();
            if (aef.DialogResult != DialogResult.OK) return;
            listOfEdges.Add(aef.Return);
            listOfVerticles.Find(x => x.Equals(aef.Return.A)).connections++;
            listOfVerticles.Find(x => x.Equals(aef.Return.B)).connections++;
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

            var weightFont = new Font("Courier new", 8F, System.Drawing.
                FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            const int verticleRadius = 20;
            int verticleRadiusDiagonale = verticleRadius * (int)Math.Sqrt(2);
            const float edgeWidth = 2;
            const float verticleBorderWidth = 3;
            const float eCaprionOffsetX = 8, eCaptionOffsetY = 7;
            const int edgeCapRadius = 10;
            var edgeCpaDiagonale = edgeCapRadius * (int) Math.Sqrt(2);
            


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
            var rnd = new Random(DateTime.UtcNow.Millisecond);
            foreach (var edge in listOfEdges)
            {
                double x1 = edge.A.point.X, y1 = edge.A.point.Y;
                double x2 = edge.B.point.X, y2 = edge.B.point.Y;
                double ax = x2-x1, ay = y2-y1;
                var len = Math.Sqrt(ax*ax + ay*ay);
                ax /= len;
                ay /= len;
                var dst = rnd.NextDouble();
                do
                {
                    dst = rnd.NextDouble();
                } while (dst < 0.3 || dst > 0.7);
                //var x = x1 + (ax) * (1.3 + dst*3) * verticleRadius;
                //var y = y1 + (ay) * (1.3 + dst*3) * verticleRadius;
                var x = x1 + (ax) * dst * len + 0*ax*1.3 * verticleRadius;
                var y = y1 + (ay) * dst * len + 0*ay*1.3 * verticleRadius;
                


                e.Graphics.FillEllipse(
                    new SolidBrush(Color.White),
                    new Rectangle((int)x - edgeCpaDiagonale, (int)y - edgeCpaDiagonale,
                        edgeCapRadius*2, edgeCapRadius*2));
                e.Graphics.DrawEllipse(new Pen(Color.Black, 1f),
                    (int)x - edgeCpaDiagonale, (int)y - edgeCpaDiagonale,
                    edgeCapRadius*2, edgeCapRadius*2);

                e.Graphics.DrawString(edge.weight > 9 ? edge.weight.ToString() : 
                        "0" + edge.weight, weightFont, 
                    new SolidBrush(Color.Black),
                    (float)(x - eCaprionOffsetX), 
                    (float)(y - eCaptionOffsetY));
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
            Drawing_panel.Refresh();
        }
    }
}
