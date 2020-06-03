using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;

namespace OstovDemo
{
    public partial class Form1 : Form
    {
        private const int verticleRadius = 20;

        private int _drawingCentreX, _drawingCentreY;

        private int _maxVertNum;
        private Verticle _selectedVerticle; // SELECTED
        public List<Edge> listOfEdges = new List<Edge>();
        public List<Verticle> listOfVerticles = new List<Verticle>();

        // needed for context menu
        private enum WhereWasClick
        {
            DrawingPanel,
            VertsList,
            EdgesList, 
            No
        }

        private WhereWasClick wwClick = WhereWasClick.No;

        public Form1()
        {
            InitializeComponent();
        }

        private void методToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!GraphIsConnected(true)) return;
            Drawing_panel.Refresh();
            var cmForm = new CruskalFormcs {Verticles = listOfVerticles, Edges = listOfEdges};
            cmForm.Size = Size;
            cmForm.WindowState = WindowState;
            cmForm.ShowDialog();
            foreach (var edge in listOfEdges) edge.condition = Condition.Waiting;
            RecalculateDrawingCoordinates();
        }


        private bool GraphIsConnected(bool askForAccept = false) // по умолчанию граф дополняется автоматически
        {
            if (!listOfVerticles.Any()) return false;
            var checkVertsList = new List<List<Verticle>>();
            for (var i = 0; i < listOfVerticles.Count(); i++)
            {
                var newlist = new List<Verticle> {listOfVerticles[i]};
                checkVertsList.Add(newlist);
            }

            foreach (var edge in listOfEdges)
            {
                var a = false;
                var b = false;
                var firstNum = -1;
                var secondNum = 0;

                for (secondNum = 0; secondNum < checkVertsList.Count(); secondNum++)
                {
                    a = a || checkVertsList[secondNum].Contains(edge.A);
                    b = b || checkVertsList[secondNum].Contains(edge.B);
                    if (a != b && firstNum == -1) firstNum = secondNum;
                    if (a && b) break;
                }

                if (firstNum == -1) continue;

                checkVertsList[firstNum].AddRange(checkVertsList[secondNum]);
                checkVertsList[secondNum].Clear();
                checkVertsList.RemoveAt(secondNum);

                if (checkVertsList.Count() == 1) return true;
            }

            var acceptAuto = !askForAccept; // если есть идеи как будет лучше, ду ит)
            if (askForAccept)
                if (MessageBox.Show("Вы хотите, чтобы он был дополнен автоматически?", "Граф не является связным",
                        MessageBoxButtons.YesNo) ==
                    DialogResult.Yes)
                    acceptAuto = true;

            if (!acceptAuto) return false;
            {
                var rnd = new Random(DateTime.UtcNow.Millisecond);
                while (checkVertsList.Count() != 1)
                {
                    //Console.WriteLine("connecting " + i.ToString());
                    var iter1 = -1;
                    var iter2 = -1;
                    while (iter1 == iter2)
                    {
                        iter1 = rnd.Next() % checkVertsList.Count();
                        iter2 = rnd.Next() % checkVertsList.Count();
                    }

                    var a = rnd.Next() % checkVertsList[iter1].Count();
                    var b = rnd.Next() % checkVertsList[iter2].Count();
                    listOfEdges.Add(new Edge(checkVertsList[iter1][a], checkVertsList[iter2][b], rnd.Next() % 49 + 1));
                    ++checkVertsList[iter1][a].connections;
                    ++checkVertsList[iter2][b].connections;
                    checkVertsList[iter1].AddRange(checkVertsList[iter2]);
                    checkVertsList.RemoveAt(iter2);
                }

                RecalculateDrawingCoordinates();
                RandomizeWeightsPositions(listOfEdges);
                RenewLists();
                return true;
            }
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
                listOfVerticles[i].point = new Point((int) x, (int) y);
            }

        }

        public static void RandomizeWeightsPositions(IList<Edge> edges)
        {
            var rnd = new Random(DateTime.UtcNow.Millisecond);
            foreach (var edge in edges) edge.weightPosition = 0.3f + 0.4f * (float) rnd.NextDouble();
        }

        private void RenewLists()
        {
            var ver = listOfVerticles.Select(verticle => verticle.name).ToList();
            var edh = listOfEdges.Select(edge => edge.A.name + "-" + edge.B.name + " (" + edge.weight + ")").ToList();
            lb_verticle.Items.Clear();
            lb_edges.Items.Clear();
            foreach (var j in ver) lb_verticle.Items.Add(j);
            foreach (var j in edh) lb_edges.Items.Add(j);
            label_noverticles.Visible = listOfVerticles.Count == 0;
            label_noedges.Visible = listOfEdges.Count == 0;
        }

        private void lb_verticle_Leave(object sender, EventArgs e)
        {
            if (lb_verticle.SelectedIndex != -1)
                lb_verticle.SetSelected(lb_verticle.SelectedIndex, false);
        }


        private void VerticleContextMenu_Opening(object sender, CancelEventArgs e)
        {
            switch (wwClick)
            {
                case WhereWasClick.DrawingPanel:
                    исправитьНаложениеВесовToolStripMenuItem.Visible = true;
                    удалитьToolStripMenuItem.Visible = _selectedVerticle != null;
                    break;
                case WhereWasClick.VertsList:
                    исправитьНаложениеВесовToolStripMenuItem.Visible = false;
                    удалитьToolStripMenuItem.Visible = _selectedVerticle != null;
                    if (_selectedVerticle == null)
                        e.Cancel = true;
                    break;
                case WhereWasClick.EdgesList:
                    e.Cancel = true;
                    break;
                case WhereWasClick.No:
                    e.Cancel = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            wwClick = WhereWasClick.No;
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
            var ggForm = new GraphGenerateForm();
            if (ggForm.ShowDialog() == DialogResult.OK)
            {
                ClearGraph();
                GenerateGraph(ggForm.Count, ggForm.GenerateEdges);
            }

            Drawing_panel.Refresh();
            if (ggForm.Count <= 10 || WindowState == FormWindowState.Maximized) return;
            if (MessageBox.Show("Развернуть окно для лучшего отображения графа?", "Большой граф",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                WindowState = FormWindowState.Maximized;
        }

        private void GenerateGraph(int count, bool gedges)
        {
            for (var i = 0; i < count; i++)
                listOfVerticles.Add(new Verticle("V" + ++_maxVertNum));

            var rnd = new Random(DateTime.UtcNow.Millisecond);
            if (gedges)
                for (var i = 0; i < listOfVerticles.Count() - 1; i++)
                for (var j = i + 1; j < listOfVerticles.Count(); j++)
                    if (rnd.Next() % 100 < 20)
                    {
                        listOfEdges.Add(new Edge(listOfVerticles[i], listOfVerticles[j], rnd.Next() % 49 + 1));
                        ++listOfVerticles[i].connections;
                        ++listOfVerticles[j].connections;
                    }

            //foreach (var verticle in listOfVerticles) // по сути эта часть получилась не нужна
            //{
            //    if (verticle.connections == 0)
            //    {
            //        var ptr = -1;
            //        while (ptr == -1 || listOfVerticles[ptr] == verticle)
            //            ptr = rnd.Next() % listOfVerticles.Count();
            //        listOfEdges.Add(new Edge(verticle, listOfVerticles[ptr], (rnd.Next() % 49) + 1));
            //        ++verticle.connections;
            //        ++listOfVerticles[ptr].connections;
            //    }
            //}

            RecalculateDrawingCoordinates();
            RandomizeWeightsPositions(listOfEdges);
            RenewLists();

            GraphIsConnected(); // тут генерятся недостающие до полного графа грани. Без подтверждения.
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
            if (listOfVerticles.Count >= 15)
            {
                AddVerticle_btn.Enabled = false;
                return;
            }

            var newvwrt = new Verticle("V" + ++_maxVertNum);
            listOfVerticles.Add(newvwrt);
            RecalculateDrawingCoordinates();
            RandomizeWeightsPositions(listOfEdges);
            RenewLists();
            Drawing_panel.Refresh();
        }

        private void btn_add_edge_Click(object sender, EventArgs e)
        {
            var aef = new AddEdgeForm {Verticles = listOfVerticles, Edges = listOfEdges};
            if (listOfVerticles.Count < 2)
            {
                MessageBox.Show("В графе менее 2 вершин, создать ребро нельзя.", "Ошибка!");
                return;
            }

            aef.ShowDialog();
            if (aef.DialogResult != DialogResult.OK) return;
            listOfEdges.Add(aef.Return);
            listOfVerticles.Find(x => x.Equals(aef.Return.A)).connections++;
            listOfVerticles.Find(x => x.Equals(aef.Return.B)).connections++;
            RenewLists();
            RandomizeWeightsPositions(listOfEdges);
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
            if (MessageBox.Show("Удалить все элементы графа?", "Вы уверены?", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                listOfEdges.Clear();
                listOfVerticles.Clear();
                RenewLists();
                Drawing_panel.Refresh();

                // TODO добавить надписи на нижний уровень, что ничего нет.
            }
        }

        public void Drawing_panel_Paint(object sender, PaintEventArgs e)
        {
            DrawGraph(e, listOfVerticles, listOfEdges);
        }

        public static void DrawGraph(PaintEventArgs e, List<Verticle> verticles_list, List<Edge> edges_list,
            bool noColors = true)
        {
            var weightFont = new Font("Courier new", 8F, FontStyle.Regular,
                GraphicsUnit.Point,
                204);
            var vCapFont = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular,
                GraphicsUnit.Point);

            var verticleRadiusDiagonale = verticleRadius * (int) Math.Sqrt(2);
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
            if (noColors)
                foreach (var edge in edges_list)
                    e.Graphics.DrawLine(new Pen(Color.Black, edgeWidth),
                        edge.A.point,
                        edge.B.point);
            else
                foreach (var edge in edges_list)
                {
                    Color eColor;
                    switch (edge.condition)
                    {
                        case Condition.Waiting:
                            eColor = Color.LightGray;
                            break;
                        case Condition.Checking:
                            eColor = Color.Red;
                            break;
                        case Condition.Accept:
                            eColor = Color.Black;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    e.Graphics.DrawLine(new Pen(eColor, edgeWidth),
                        edge.A.point,
                        edge.B.point);
                }

            // VERICLES
            foreach (var verticle in verticles_list)
            {
                e.Graphics.FillEllipse(
                    new SolidBrush(Color.White),
                    new Rectangle(verticle.point.X - verticleRadiusDiagonale,
                        verticle.point.Y - verticleRadiusDiagonale,
                        verticleRadius * 2, verticleRadius * 2));
                e.Graphics.DrawEllipse(new Pen(Color.Black, verticleBorderWidth),
                    verticle.point.X - verticleRadiusDiagonale, verticle.point.Y - verticleRadiusDiagonale,
                    verticleRadius * 2, verticleRadius * 2);
            }


            // VERTICLE CAPTIONS
            foreach (var verticle in verticles_list)
            {
                int vTextOffsetX = 12 + 5 * (verticle.name.Length - 2), vTextOffsetY = 10;
                e.Graphics.DrawString(verticle.name, vCapFont,
                    new SolidBrush(Color.Black), verticle.point.X - vTextOffsetX, verticle.point.Y - vTextOffsetY);
            }

            // EDGE CAPTIONS
            foreach (var edge in edges_list)
            {
                double x1 = edge.A.point.X, y1 = edge.A.point.Y;
                double x2 = edge.B.point.X, y2 = edge.B.point.Y;
                double ax = x2 - x1, ay = y2 - y1;
                var len = Math.Sqrt(ax * ax + ay * ay);
                ax /= len;
                ay /= len;
                var dst = edge.weightPosition;

                var x = x1 + ax * dst * len + 0 * ax * 1.3 * verticleRadius;
                var y = y1 + ay * dst * len + 0 * ay * 1.3 * verticleRadius;


                e.Graphics.FillEllipse(
                    new SolidBrush(Color.White),
                    new Rectangle((int) x - edgeCpaDiagonale, (int) y - edgeCpaDiagonale,
                        edgeCapRadius * 2, edgeCapRadius * 2));
                e.Graphics.DrawEllipse(new Pen(Color.Black, 1f),
                    (int) x - edgeCpaDiagonale, (int) y - edgeCpaDiagonale,
                    edgeCapRadius * 2, edgeCapRadius * 2);

                e.Graphics.DrawString(edge.weight > 9 ? edge.weight.ToString() : "0" + edge.weight, weightFont,
                    new SolidBrush(Color.Black),
                    (float) (x - eCaprionOffsetX),
                    (float) (y - eCaptionOffsetY));
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удaлить вершину?", "Вы уверены?",
                    MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            listOfVerticles.Remove(_selectedVerticle);
            while (_selectedVerticle.connections > 0)
            {
                var del = listOfEdges.First(x => Equals(x.A, _selectedVerticle)
                                                 || Equals(x.B, _selectedVerticle));
                del.A.connections--;
                del.B.connections--;
                listOfEdges.Remove(del);
            }

            _selectedVerticle = null;
            RenewLists();
            RecalculateDrawingCoordinates();
            Drawing_panel.Refresh();
        }

        private void lb_verticle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lb_verticle.SelectedIndex == -1) return;
            _selectedVerticle = listOfVerticles[lb_verticle.SelectedIndex];
        }

        private void Drawing_panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (lb_verticle.SelectedIndex != -1)
                lb_verticle.SetSelected(lb_verticle.SelectedIndex, false);
            if (lb_edges.SelectedIndex != -1)
                lb_edges.SetSelected(lb_edges.SelectedIndex, false);
            if (e.Button != MouseButtons.Left)
            {
                wwClick = WhereWasClick.DrawingPanel;
                return;
            }
            Verticle select = null;
            foreach (var verticle in listOfVerticles)
            {
                int dx = e.X - verticle.point.X, dy = e.Y - verticle.point.Y;
                if (!(Math.Sqrt(dx * dx + dy * dy) <= verticleRadius)) continue;
                select = verticle;
                break;
            }

            if (Equals(_selectedVerticle, select) || select == null) return;
            if (_selectedVerticle == null)
            {
                _selectedVerticle = select;
            }
            else
            {
                if (listOfEdges.Any(ed => Equals(ed.A, select) && Equals(ed.B, _selectedVerticle)
                                          || Equals(ed.A, _selectedVerticle) && Equals(ed.B, select))) return;

                var aef = new AddEdgeForm
                {
                    Verticles = listOfVerticles,
                    Edges = listOfEdges,
                    SetDefaultVerticles = true,
                    Va = _selectedVerticle,
                    Vb = select
                };
                aef.ShowDialog();
                if (aef.DialogResult != DialogResult.OK)
                {
                    _selectedVerticle = null;
                    return;
                }

                listOfEdges.Add(aef.Return);
                listOfVerticles.Find(x => x.Equals(aef.Return.A)).connections++;
                listOfVerticles.Find(x => x.Equals(aef.Return.B)).connections++;
                RandomizeWeightsPositions(listOfEdges);
                RenewLists();
                Drawing_panel.Refresh();
                _selectedVerticle = null;
            }
        }

        private void Drawing_panel_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void lb_verticle_MouseDown(object sender, MouseEventArgs e)
        {
            wwClick = WhereWasClick.VertsList;
        }

        private void lb_edges_MouseDown(object sender, MouseEventArgs e)
        {
            wwClick = WhereWasClick.EdgesList;
        }

        private void EdgeContextMenu_Opening(object sender, CancelEventArgs e)
        {
            if (lb_edges.SelectedIndex != -1) return;
            e.Cancel = true;

        }

        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удaлить ребро?", "Вы уверены?",
                    MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            var del = listOfEdges[lb_edges.SelectedIndex];
            listOfEdges.Remove(del);
            del.A.connections--;
            del.B.connections--;

            _selectedVerticle = null;
            RenewLists();
            RecalculateDrawingCoordinates();
            Drawing_panel.Refresh();
        }

        private void исправитьНаложениеВесовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RandomizeWeightsPositions(listOfEdges);
            Drawing_panel.Refresh();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            RecalculateDrawingCoordinates();
            Drawing_panel.Refresh();
        }
    }
}