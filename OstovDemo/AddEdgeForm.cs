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
    public partial class AddEdgeForm : Form
    {
        public AddEdgeForm()
        {
            InitializeComponent();
        }

        public bool SetDefaultVerticles = false;
        public Verticle Va, Vb;
        public List<Verticle> Verticles;
        public List<Edge> Edges;
        public Edge Return;

        private void AddEdgeForm_Load(object sender, EventArgs e)
        {
            var rnd = new Random();
            if (Verticles.Count < 2)
            {
                MessageBox.Show("В графе менее 2 вершин, создать ребро нельзя.");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

            if (SetDefaultVerticles)
            {

                cb_selectA.Items.Add(Va.name);
                cb_selectB.Items.Add(Vb.name);
                cb_selectA.Text = Va.name;
                cb_selectB.Text = Vb.name;
                cb_selectA.Enabled = false;
                cb_selectB.Enabled = false;

                button1.Enabled = true;
                numericUpDown1.Value = rnd.Next(50);
                return;
            }

            foreach (var verticle in Verticles)
            {
                cb_selectA.Items.Add(verticle.GetName());
            }
            numericUpDown1.Value = rnd.Next(50);
        }

        private void cb_selectB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //кнопка активна только если начало и конец выбраны
            button1.Enabled = !(cb_selectA.Text.Length == 0 || cb_selectB.Text.Length == 0);
        }

        private void cb_selectA_SelectedIndexChanged(object sender, EventArgs e)
        {
            // при выборе вршины А, в выбиралке вершины Б будут только те вершина, до которых из А нет рёбер
            cb_selectB.SelectedIndex = -1;
            cb_selectB.Items.Clear();
            var selectedVerticle = Verticles.First((verticle) => verticle.name == cb_selectA.Text);
            foreach (var verticle in Verticles.Where(verticle => 
                !Edges.Any((edge) => Equals(edge.A, selectedVerticle) && Equals(edge.B, verticle) 
                                     || Equals(edge.B, selectedVerticle) && Equals(edge.A, verticle))))
            {
                cb_selectB.Items.Add(verticle.GetName());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var VerticleA = Verticles.First((v) => v.GetName().Equals(cb_selectA.Text));
            var VerticleB = Verticles.First((v) => v.GetName().Equals(cb_selectB.Text));
            Return = new Edge(VerticleA, VerticleB, (int)numericUpDown1.Value);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
