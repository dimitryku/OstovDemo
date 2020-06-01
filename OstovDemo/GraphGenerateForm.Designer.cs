namespace OstovDemo
{
    partial class GraphGenerateForm
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
            this.tb_vertCount = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label_vertCount = new System.Windows.Forms.Label();
            this.cb_generateEdges = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tb_vertCount)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_vertCount
            // 
            this.tb_vertCount.LargeChange = 1;
            this.tb_vertCount.Location = new System.Drawing.Point(16, 42);
            this.tb_vertCount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_vertCount.Maximum = 15;
            this.tb_vertCount.Minimum = 4;
            this.tb_vertCount.Name = "tb_vertCount";
            this.tb_vertCount.Size = new System.Drawing.Size(324, 56);
            this.tb_vertCount.TabIndex = 0;
            this.tb_vertCount.Value = 4;
            this.tb_vertCount.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Число вершин:";
            // 
            // label_vertCount
            // 
            this.label_vertCount.AutoSize = true;
            this.label_vertCount.Location = new System.Drawing.Point(135, 18);
            this.label_vertCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_vertCount.Name = "label_vertCount";
            this.label_vertCount.Size = new System.Drawing.Size(16, 17);
            this.label_vertCount.TabIndex = 2;
            this.label_vertCount.Text = "4";
            // 
            // cb_generateEdges
            // 
            this.cb_generateEdges.AutoSize = true;
            this.cb_generateEdges.Checked = true;
            this.cb_generateEdges.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_generateEdges.Location = new System.Drawing.Point(20, 106);
            this.cb_generateEdges.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cb_generateEdges.Name = "cb_generateEdges";
            this.cb_generateEdges.Size = new System.Drawing.Size(173, 21);
            this.cb_generateEdges.TabIndex = 3;
            this.cb_generateEdges.Text = "Сгенерировать рёбра";
            this.cb_generateEdges.UseVisualStyleBackColor = true;
            this.cb_generateEdges.CheckedChanged += new System.EventHandler(this.cb_generateEdges_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(223, 133);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "ОК";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GraphGenerateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(356, 182);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cb_generateEdges);
            this.Controls.Add(this.label_vertCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_vertCount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GraphGenerateForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Сгенерировать  граф";
            ((System.ComponentModel.ISupportInitialize)(this.tb_vertCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar tb_vertCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_vertCount;
        private System.Windows.Forms.CheckBox cb_generateEdges;
        private System.Windows.Forms.Button button1;
    }
}