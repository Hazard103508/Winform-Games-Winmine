namespace WinMine
{
    partial class Config
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
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMines = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.txtMines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(90, 70);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mines";
            // 
            // txtMines
            // 
            this.txtMines.Location = new System.Drawing.Point(47, 38);
            this.txtMines.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtMines.Name = "txtMines";
            this.txtMines.Size = new System.Drawing.Size(67, 20);
            this.txtMines.TabIndex = 2;
            this.txtMines.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Width";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(47, 12);
            this.txtWidth.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txtWidth.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(67, 20);
            this.txtWidth.TabIndex = 2;
            this.txtWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtWidth.ValueChanged += new System.EventHandler(this.txtWidth_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Height";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(172, 12);
            this.txtHeight.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txtHeight.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(67, 20);
            this.txtHeight.TabIndex = 2;
            this.txtHeight.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtHeight.ValueChanged += new System.EventHandler(this.txtHeight_ValueChanged);
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 98);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMines);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOk);
            this.Name = "Config";
            this.Text = "Config";
            ((System.ComponentModel.ISupportInitialize)(this.txtMines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtMines;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown txtWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtHeight;
    }
}