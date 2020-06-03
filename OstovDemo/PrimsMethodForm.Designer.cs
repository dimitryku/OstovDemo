namespace OstovDemo
{
    partial class PrimsMethodForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.drawing_panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.log_tb = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rb_noanime = new System.Windows.Forms.RadioButton();
            this.button4 = new System.Windows.Forms.Button();
            this.next_btn = new System.Windows.Forms.Button();
            this.start_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.rb_manual = new System.Windows.Forms.RadioButton();
            this.rb_slow = new System.Windows.Forms.RadioButton();
            this.rb_fast = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // drawing_panel
            // 
            this.drawing_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawing_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawing_panel.Location = new System.Drawing.Point(149, 0);
            this.drawing_panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.drawing_panel.Name = "drawing_panel";
            this.drawing_panel.Size = new System.Drawing.Size(637, 702);
            this.drawing_panel.TabIndex = 7;
            this.drawing_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.drawing_panel_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.log_tb);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(786, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(171, 702);
            this.panel1.TabIndex = 6;
            // 
            // log_tb
            // 
            this.log_tb.BackColor = System.Drawing.Color.White;
            this.log_tb.Cursor = System.Windows.Forms.Cursors.Default;
            this.log_tb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.log_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.log_tb.Location = new System.Drawing.Point(0, 0);
            this.log_tb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.log_tb.Multiline = true;
            this.log_tb.Name = "log_tb";
            this.log_tb.ReadOnly = true;
            this.log_tb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.log_tb.Size = new System.Drawing.Size(171, 702);
            this.log_tb.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rb_noanime);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.next_btn);
            this.panel2.Controls.Add(this.start_btn);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.rb_manual);
            this.panel2.Controls.Add(this.rb_slow);
            this.panel2.Controls.Add(this.rb_fast);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(149, 702);
            this.panel2.TabIndex = 5;
            // 
            // rb_noanime
            // 
            this.rb_noanime.AutoSize = true;
            this.rb_noanime.Location = new System.Drawing.Point(11, 85);
            this.rb_noanime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rb_noanime.Name = "rb_noanime";
            this.rb_noanime.Size = new System.Drawing.Size(122, 21);
            this.rb_noanime.TabIndex = 8;
            this.rb_noanime.Text = "Без анимации";
            this.rb_noanime.UseVisualStyleBackColor = true;
            this.rb_noanime.CheckedChanged += new System.EventHandler(this.rb_noanime_CheckedChanged);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.Location = new System.Drawing.Point(11, 609);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(117, 46);
            this.button4.TabIndex = 7;
            this.button4.Text = "Сброс в начало";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // next_btn
            // 
            this.next_btn.Location = new System.Drawing.Point(11, 230);
            this.next_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.next_btn.Name = "next_btn";
            this.next_btn.Size = new System.Drawing.Size(117, 57);
            this.next_btn.TabIndex = 6;
            this.next_btn.Text = "Далее";
            this.next_btn.UseVisualStyleBackColor = true;
            this.next_btn.Click += new System.EventHandler(this.next_btn_Click);
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(11, 170);
            this.start_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(117, 54);
            this.start_btn.TabIndex = 5;
            this.start_btn.Text = "Начать";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(11, 659);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 30);
            this.button1.TabIndex = 4;
            this.button1.Text = "Закрыть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rb_manual
            // 
            this.rb_manual.AutoSize = true;
            this.rb_manual.Location = new System.Drawing.Point(11, 110);
            this.rb_manual.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rb_manual.Name = "rb_manual";
            this.rb_manual.Size = new System.Drawing.Size(86, 21);
            this.rb_manual.TabIndex = 3;
            this.rb_manual.Text = "Вручную";
            this.rb_manual.UseVisualStyleBackColor = true;
            this.rb_manual.CheckedChanged += new System.EventHandler(this.rb_manual_CheckedChanged);
            // 
            // rb_slow
            // 
            this.rb_slow.AutoSize = true;
            this.rb_slow.Checked = true;
            this.rb_slow.Location = new System.Drawing.Point(11, 60);
            this.rb_slow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rb_slow.Name = "rb_slow";
            this.rb_slow.Size = new System.Drawing.Size(96, 21);
            this.rb_slow.TabIndex = 2;
            this.rb_slow.TabStop = true;
            this.rb_slow.Text = "Медленно";
            this.rb_slow.UseVisualStyleBackColor = true;
            this.rb_slow.CheckedChanged += new System.EventHandler(this.rb_slow_CheckedChanged);
            // 
            // rb_fast
            // 
            this.rb_fast.AutoSize = true;
            this.rb_fast.Location = new System.Drawing.Point(11, 34);
            this.rb_fast.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rb_fast.Name = "rb_fast";
            this.rb_fast.Size = new System.Drawing.Size(78, 21);
            this.rb_fast.TabIndex = 1;
            this.rb_fast.Text = "Быстро";
            this.rb_fast.UseVisualStyleBackColor = true;
            this.rb_fast.CheckedChanged += new System.EventHandler(this.rb_fast_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Демонстрация:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // PrimsMethodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(957, 702);
            this.Controls.Add(this.drawing_panel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimizeBox = false;
            this.Name = "PrimsMethodForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Метод Прима";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel drawing_panel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox log_tb;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rb_noanime;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button next_btn;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rb_manual;
        private System.Windows.Forms.RadioButton rb_slow;
        private System.Windows.Forms.RadioButton rb_fast;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}