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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lb_edges = new System.Windows.Forms.ListBox();
            this.btn_add_edge = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.verticle = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bibaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1006, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bibaToolStripMenuItem
            // 
            this.bibaToolStripMenuItem.Name = "bibaToolStripMenuItem";
            this.bibaToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.bibaToolStripMenuItem.Text = "biba";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_add_edge);
            this.panel1.Controls.Add(this.lb_edges);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 693);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.verticle);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(858, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(148, 693);
            this.panel2.TabIndex = 2;
            // 
            // lb_edges
            // 
            this.lb_edges.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lb_edges.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_edges.FormattingEnabled = true;
            this.lb_edges.ItemHeight = 25;
            this.lb_edges.Items.AddRange(new object[] {
            "нет рёбер"});
            this.lb_edges.Location = new System.Drawing.Point(0, 37);
            this.lb_edges.Name = "lb_edges";
            this.lb_edges.Size = new System.Drawing.Size(142, 654);
            this.lb_edges.TabIndex = 0;
            // 
            // btn_add_edge
            // 
            this.btn_add_edge.Location = new System.Drawing.Point(4, 3);
            this.btn_add_edge.Name = "btn_add_edge";
            this.btn_add_edge.Size = new System.Drawing.Size(135, 28);
            this.btn_add_edge.TabIndex = 1;
            this.btn_add_edge.Text = "Добавить ребро";
            this.btn_add_edge.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Добавить вершину";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // verticle
            // 
            this.verticle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.verticle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.verticle.FormattingEnabled = true;
            this.verticle.ItemHeight = 25;
            this.verticle.Location = new System.Drawing.Point(0, 37);
            this.verticle.Name = "verticle";
            this.verticle.Size = new System.Drawing.Size(146, 654);
            this.verticle.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
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
        private System.Windows.Forms.ListBox verticle;
        private System.Windows.Forms.Button button1;
    }
}

