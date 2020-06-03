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
            this.label_noedges = new System.Windows.Forms.Label();
            this.lb_edges = new System.Windows.Forms.ListBox();
            this.EdgeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.удалитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_add_edge = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_noverticles = new System.Windows.Forms.Label();
            this.lb_verticle = new System.Windows.Forms.ListBox();
            this.VerticleContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.исправитьНаложениеВесовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddVerticle_btn = new System.Windows.Forms.Button();
            this.Drawing_panel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.EdgeContextMenu.SuspendLayout();
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(756, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // GenerateGraphToolStripMenuItem
            // 
            this.GenerateGraphToolStripMenuItem.Name = "GenerateGraphToolStripMenuItem";
            this.GenerateGraphToolStripMenuItem.Size = new System.Drawing.Size(132, 20);
            this.GenerateGraphToolStripMenuItem.Text = "Сгенерировать граф";
            this.GenerateGraphToolStripMenuItem.Click += new System.EventHandler(this.bibaToolStripMenuItem_Click);
            // 
            // найтиОстовToolStripMenuItem
            // 
            this.найтиОстовToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.методToolStripMenuItem,
            this.методПримаToolStripMenuItem});
            this.найтиОстовToolStripMenuItem.Name = "найтиОстовToolStripMenuItem";
            this.найтиОстовToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.найтиОстовToolStripMenuItem.Text = "Найти остов";
            // 
            // методToolStripMenuItem
            // 
            this.методToolStripMenuItem.Name = "методToolStripMenuItem";
            this.методToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.методToolStripMenuItem.Text = "Метод Краскала";
            this.методToolStripMenuItem.Click += new System.EventHandler(this.методToolStripMenuItem_Click);
            // 
            // методПримаToolStripMenuItem
            // 
            this.методПримаToolStripMenuItem.Name = "методПримаToolStripMenuItem";
            this.методПримаToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.методПримаToolStripMenuItem.Text = "Метод Прима";
            this.методПримаToolStripMenuItem.Click += new System.EventHandler(this.методПримаToolStripMenuItem_Click);
            // 
            // очиститьToolStripMenuItem
            // 
            this.очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            this.очиститьToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.очиститьToolStripMenuItem.Text = "Очистить";
            this.очиститьToolStripMenuItem.Click += new System.EventHandler(this.очиститьToolStripMenuItem_Click);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.помощьToolStripMenuItem.Text = "Помощь";
            this.помощьToolStripMenuItem.Click += new System.EventHandler(this.помощьToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label_noedges);
            this.panel1.Controls.Add(this.lb_edges);
            this.panel1.Controls.Add(this.btn_add_edge);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(108, 568);
            this.panel1.TabIndex = 1;
            // 
            // label_noedges
            // 
            this.label_noedges.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_noedges.BackColor = System.Drawing.Color.Transparent;
            this.label_noedges.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_noedges.Location = new System.Drawing.Point(2, 264);
            this.label_noedges.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_noedges.Name = "label_noedges";
            this.label_noedges.Size = new System.Drawing.Size(99, 31);
            this.label_noedges.TabIndex = 3;
            this.label_noedges.Text = "нет рёбер";
            this.label_noedges.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_edges
            // 
            this.lb_edges.ContextMenuStrip = this.EdgeContextMenu;
            this.lb_edges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_edges.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_edges.FormattingEnabled = true;
            this.lb_edges.ItemHeight = 20;
            this.lb_edges.Location = new System.Drawing.Point(0, 28);
            this.lb_edges.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lb_edges.Name = "lb_edges";
            this.lb_edges.Size = new System.Drawing.Size(106, 538);
            this.lb_edges.TabIndex = 2;
            this.lb_edges.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lb_edges_MouseDown);
            // 
            // EdgeContextMenu
            // 
            this.EdgeContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.EdgeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьToolStripMenuItem1});
            this.EdgeContextMenu.Name = "EdgeContextMenu";
            this.EdgeContextMenu.Size = new System.Drawing.Size(119, 26);
            this.EdgeContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.EdgeContextMenu_Opening);
            // 
            // удалитьToolStripMenuItem1
            // 
            this.удалитьToolStripMenuItem1.Name = "удалитьToolStripMenuItem1";
            this.удалитьToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.удалитьToolStripMenuItem1.Text = "Удалить";
            this.удалитьToolStripMenuItem1.Click += new System.EventHandler(this.удалитьToolStripMenuItem1_Click);
            // 
            // btn_add_edge
            // 
            this.btn_add_edge.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_add_edge.Location = new System.Drawing.Point(0, 0);
            this.btn_add_edge.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_add_edge.Name = "btn_add_edge";
            this.btn_add_edge.Size = new System.Drawing.Size(106, 28);
            this.btn_add_edge.TabIndex = 1;
            this.btn_add_edge.Text = "Добавить ребро";
            this.btn_add_edge.UseVisualStyleBackColor = true;
            this.btn_add_edge.Click += new System.EventHandler(this.btn_add_edge_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label_noverticles);
            this.panel2.Controls.Add(this.lb_verticle);
            this.panel2.Controls.Add(this.AddVerticle_btn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(633, 24);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(123, 568);
            this.panel2.TabIndex = 2;
            // 
            // label_noverticles
            // 
            this.label_noverticles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_noverticles.BackColor = System.Drawing.Color.Transparent;
            this.label_noverticles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_noverticles.Location = new System.Drawing.Point(4, 264);
            this.label_noverticles.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_noverticles.Name = "label_noverticles";
            this.label_noverticles.Size = new System.Drawing.Size(114, 31);
            this.label_noverticles.TabIndex = 2;
            this.label_noverticles.Text = "нет вершин";
            this.label_noverticles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_verticle
            // 
            this.lb_verticle.ContextMenuStrip = this.VerticleContextMenu;
            this.lb_verticle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_verticle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_verticle.FormattingEnabled = true;
            this.lb_verticle.ItemHeight = 20;
            this.lb_verticle.Location = new System.Drawing.Point(0, 28);
            this.lb_verticle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lb_verticle.Name = "lb_verticle";
            this.lb_verticle.Size = new System.Drawing.Size(121, 538);
            this.lb_verticle.TabIndex = 1;
            this.lb_verticle.SelectedIndexChanged += new System.EventHandler(this.lb_verticle_SelectedIndexChanged);
            this.lb_verticle.Leave += new System.EventHandler(this.lb_verticle_Leave);
            this.lb_verticle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lb_verticle_MouseDown);
            // 
            // VerticleContextMenu
            // 
            this.VerticleContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.VerticleContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьToolStripMenuItem,
            this.исправитьНаложениеВесовToolStripMenuItem});
            this.VerticleContextMenu.Name = "VerticleContextMenu";
            this.VerticleContextMenu.Size = new System.Drawing.Size(229, 48);
            this.VerticleContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.VerticleContextMenu_Opening);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // исправитьНаложениеВесовToolStripMenuItem
            // 
            this.исправитьНаложениеВесовToolStripMenuItem.Name = "исправитьНаложениеВесовToolStripMenuItem";
            this.исправитьНаложениеВесовToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.исправитьНаложениеВесовToolStripMenuItem.Text = "Изменить положение весов";
            this.исправитьНаложениеВесовToolStripMenuItem.Click += new System.EventHandler(this.исправитьНаложениеВесовToolStripMenuItem_Click);
            // 
            // AddVerticle_btn
            // 
            this.AddVerticle_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddVerticle_btn.Location = new System.Drawing.Point(0, 0);
            this.AddVerticle_btn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddVerticle_btn.Name = "AddVerticle_btn";
            this.AddVerticle_btn.Size = new System.Drawing.Size(121, 28);
            this.AddVerticle_btn.TabIndex = 0;
            this.AddVerticle_btn.Text = "Добавить вершину";
            this.AddVerticle_btn.UseVisualStyleBackColor = true;
            this.AddVerticle_btn.Click += new System.EventHandler(this.AddVerticle_btn_Click);
            // 
            // Drawing_panel
            // 
            this.Drawing_panel.ContextMenuStrip = this.VerticleContextMenu;
            this.Drawing_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Drawing_panel.Location = new System.Drawing.Point(108, 24);
            this.Drawing_panel.Name = "Drawing_panel";
            this.Drawing_panel.Size = new System.Drawing.Size(525, 568);
            this.Drawing_panel.TabIndex = 3;
            this.Drawing_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Drawing_panel_Paint);
            this.Drawing_panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Drawing_panel_MouseClick);
            this.Drawing_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drawing_panel_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(756, 592);
            this.Controls.Add(this.Drawing_panel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(772, 631);
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
            this.EdgeContextMenu.ResumeLayout(false);
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
        private System.Windows.Forms.Label label_noedges;
        private System.Windows.Forms.Label label_noverticles;
        private System.Windows.Forms.ToolStripMenuItem исправитьНаложениеВесовToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip EdgeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem1;
    }
}

