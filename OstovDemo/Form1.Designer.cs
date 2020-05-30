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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bibaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.найтиОстовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.методToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.методПримаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_add_edge = new System.Windows.Forms.Button();
            this.lb_edges = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lb_verticle = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bibaToolStripMenuItem,
            this.найтиОстовToolStripMenuItem,
            this.помощьToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(754, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bibaToolStripMenuItem
            // 
            this.bibaToolStripMenuItem.Name = "bibaToolStripMenuItem";
            this.bibaToolStripMenuItem.Size = new System.Drawing.Size(141, 20);
            this.bibaToolStripMenuItem.Text = "Сгенерировать граф...";
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
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_add_edge);
            this.panel1.Controls.Add(this.lb_edges);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(108, 562);
            this.panel1.TabIndex = 1;
            // 
            // btn_add_edge
            // 
            this.btn_add_edge.Location = new System.Drawing.Point(2, 4);
            this.btn_add_edge.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_add_edge.Name = "btn_add_edge";
            this.btn_add_edge.Size = new System.Drawing.Size(101, 28);
            this.btn_add_edge.TabIndex = 1;
            this.btn_add_edge.Text = "Добавить ребро";
            this.btn_add_edge.UseVisualStyleBackColor = true;
            // 
            // lb_edges
            // 
            this.lb_edges.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lb_edges.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_edges.FormattingEnabled = true;
            this.lb_edges.ItemHeight = 20;
            this.lb_edges.Items.AddRange(new object[] {
            "нет рёбер"});
            this.lb_edges.Location = new System.Drawing.Point(0, 36);
            this.lb_edges.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lb_edges.Name = "lb_edges";
            this.lb_edges.Size = new System.Drawing.Size(106, 524);
            this.lb_edges.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lb_verticle);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(631, 24);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(123, 562);
            this.panel2.TabIndex = 2;
            // 
            // lb_verticle
            // 
            this.lb_verticle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lb_verticle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_verticle.FormattingEnabled = true;
            this.lb_verticle.ItemHeight = 20;
            this.lb_verticle.Items.AddRange(new object[] {
            "нет вершин"});
            this.lb_verticle.Location = new System.Drawing.Point(0, 36);
            this.lb_verticle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lb_verticle.Name = "lb_verticle";
            this.lb_verticle.Size = new System.Drawing.Size(121, 524);
            this.lb_verticle.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2, 4);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Добавить вершину";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(754, 586);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Ostov Demo";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bibaToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_add_edge;
        private System.Windows.Forms.ListBox lb_edges;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lb_verticle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem найтиОстовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem методToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem методПримаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
    }
}

