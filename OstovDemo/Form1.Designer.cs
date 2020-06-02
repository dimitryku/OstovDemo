namespace OstovDemo
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.GenerateGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.найтиОстовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.методToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.методПримаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_edges = new System.Windows.Forms.ListBox();
            this.btn_add_edge = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lb_verticle = new System.Windows.Forms.ListBox();
            this.VerticleContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddVerticle_btn = new System.Windows.Forms.Button();
            this.Drawing_panel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.VerticleContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GenerateGraphToolStripMenuItem,
            this.найтиОстовToolStripMenuItem,
            this.очиститьToolStripMenuItem,
            this.помощьToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1005, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // GenerateGraphToolStripMenuItem
            // 
            this.GenerateGraphToolStripMenuItem.Name = "GenerateGraphToolStripMenuItem";
            this.GenerateGraphToolStripMenuItem.Size = new System.Drawing.Size(166, 24);
            this.GenerateGraphToolStripMenuItem.Text = "Сгенерировать граф";
            this.GenerateGraphToolStripMenuItem.Click += new System.EventHandler(this.bibaToolStripMenuItem_Click);
            // 
            // найтиОстовToolStripMenuItem
            // 
            this.найтиОстовToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.методToolStripMenuItem,
            this.методПримаToolStripMenuItem});
            this.найтиОстовToolStripMenuItem.Name = "найтиОстовToolStripMenuItem";
            this.найтиОстовToolStripMenuItem.Size = new System.Drawing.Size(109, 24);
            this.найтиОстовToolStripMenuItem.Text = "Найти остов";
            // 
            // методToolStripMenuItem
            // 
            this.методToolStripMenuItem.Name = "методToolStripMenuItem";
            this.методToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.методToolStripMenuItem.Text = "Метод Краскала";
            this.методToolStripMenuItem.Click += new System.EventHandler(this.методToolStripMenuItem_Click);
            // 
            // методПримаToolStripMenuItem
            // 
            this.методПримаToolStripMenuItem.Name = "методПримаToolStripMenuItem";
            this.методПримаToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.методПримаToolStripMenuItem.Text = "Метод Прима";
            this.методПримаToolStripMenuItem.Click += new System.EventHandler(this.методПримаToolStripMenuItem_Click);
            // 
            // очиститьToolStripMenuItem
            // 
            this.очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            this.очиститьToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.очиститьToolStripMenuItem.Text = "Очистить";
            this.очиститьToolStripMenuItem.Click += new System.EventHandler(this.очиститьToolStripMenuItem_Click);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.помощьToolStripMenuItem.Text = "Помощь";
            this.помощьToolStripMenuItem.Click += new System.EventHandler(this.помощьToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lb_edges);
            this.panel1.Controls.Add(this.btn_add_edge);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(143, 693);
            this.panel1.TabIndex = 1;
            // 
            // lb_edges
            // 
            this.lb_edges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_edges.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_edges.FormattingEnabled = true;
            this.lb_edges.ItemHeight = 25;
            this.lb_edges.Items.AddRange(new object[] {
            "нет рёбер"});
            this.lb_edges.Location = new System.Drawing.Point(0, 34);
            this.lb_edges.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lb_edges.Name = "lb_edges";
            this.lb_edges.Size = new System.Drawing.Size(141, 657);
            this.lb_edges.TabIndex = 2;
            // 
            // btn_add_edge
            // 
            this.btn_add_edge.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_add_edge.Location = new System.Drawing.Point(0, 0);
            this.btn_add_edge.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_add_edge.Name = "btn_add_edge";
            this.btn_add_edge.Size = new System.Drawing.Size(141, 34);
            this.btn_add_edge.TabIndex = 1;
            this.btn_add_edge.Text = "Добавить ребро";
            this.btn_add_edge.UseVisualStyleBackColor = true;
            this.btn_add_edge.Click += new System.EventHandler(this.btn_add_edge_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lb_verticle);
            this.panel2.Controls.Add(this.AddVerticle_btn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(842, 28);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(163, 693);
            this.panel2.TabIndex = 2;
            // 
            // lb_verticle
            // 
            this.lb_verticle.ContextMenuStrip = this.VerticleContextMenu;
            this.lb_verticle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_verticle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_verticle.FormattingEnabled = true;
            this.lb_verticle.ItemHeight = 25;
            this.lb_verticle.Items.AddRange(new object[] {
            "нет вершин"});
            this.lb_verticle.Location = new System.Drawing.Point(0, 34);
            this.lb_verticle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lb_verticle.Name = "lb_verticle";
            this.lb_verticle.Size = new System.Drawing.Size(161, 657);
            this.lb_verticle.TabIndex = 1;
            this.lb_verticle.SelectedIndexChanged += new System.EventHandler(this.lb_verticle_SelectedIndexChanged);
            this.lb_verticle.Leave += new System.EventHandler(this.lb_verticle_Leave);
            // 
            // VerticleContextMenu
            // 
            this.VerticleContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.VerticleContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьToolStripMenuItem});
            this.VerticleContextMenu.Name = "VerticleContextMenu";
            this.VerticleContextMenu.Size = new System.Drawing.Size(211, 56);
            this.VerticleContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.VerticleContextMenu_Opening);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(190, 24);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // AddVerticle_btn
            // 
            this.AddVerticle_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddVerticle_btn.Location = new System.Drawing.Point(0, 0);
            this.AddVerticle_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddVerticle_btn.Name = "AddVerticle_btn";
            this.AddVerticle_btn.Size = new System.Drawing.Size(161, 34);
            this.AddVerticle_btn.TabIndex = 0;
            this.AddVerticle_btn.Text = "Добавить вершину";
            this.AddVerticle_btn.UseVisualStyleBackColor = true;
            this.AddVerticle_btn.Click += new System.EventHandler(this.AddVerticle_btn_Click);
            // 
            // Drawing_panel
            // 
            this.Drawing_panel.ContextMenuStrip = this.VerticleContextMenu;
            this.Drawing_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Drawing_panel.Location = new System.Drawing.Point(143, 28);
            this.Drawing_panel.Margin = new System.Windows.Forms.Padding(4);
            this.Drawing_panel.Name = "Drawing_panel";
            this.Drawing_panel.Size = new System.Drawing.Size(699, 693);
            this.Drawing_panel.TabIndex = 3;
            this.Drawing_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Drawing_panel_Paint);
            this.Drawing_panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Drawing_panel_MouseClick);
            this.Drawing_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drawing_panel_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1005, 721);
            this.Controls.Add(this.Drawing_panel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ostov Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.VerticleContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem GenerateGraphToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_add_edge;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lb_verticle;
        private System.Windows.Forms.Button AddVerticle_btn;
        private System.Windows.Forms.ToolStripMenuItem найтиОстовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem методToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem методПримаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip VerticleContextMenu;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьToolStripMenuItem;
        private System.Windows.Forms.Panel Drawing_panel;
        private System.Windows.Forms.ListBox lb_edges;
    }
}

