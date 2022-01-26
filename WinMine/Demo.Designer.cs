namespace WinMine
{
    partial class Demo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Demo));
            this.txtMines = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.pnlValues = new System.Windows.Forms.Panel();
            this.btnLink = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.pnlValues.SuspendLayout();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Canvas.Image = ((System.Drawing.Image)(resources.GetObject("Canvas.Image")));
            this.Canvas.Location = new System.Drawing.Point(0, 31);
            this.Canvas.Size = new System.Drawing.Size(284, 230);
            // 
            // txtMines
            // 
            this.txtMines.Location = new System.Drawing.Point(32, 6);
            this.txtMines.Name = "txtMines";
            this.txtMines.ReadOnly = true;
            this.txtMines.Size = new System.Drawing.Size(80, 20);
            this.txtMines.TabIndex = 2;
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(178, 6);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(78, 20);
            this.txtTime.TabIndex = 2;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(119, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(53, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.BackgroundImage = global::WinMine.Properties.Resources.config;
            this.btnConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfig.Location = new System.Drawing.Point(3, 4);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(23, 23);
            this.btnConfig.TabIndex = 3;
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // pnlValues
            // 
            this.pnlValues.Controls.Add(this.btnStart);
            this.pnlValues.Controls.Add(this.txtMines);
            this.pnlValues.Controls.Add(this.btnLink);
            this.pnlValues.Controls.Add(this.btnConfig);
            this.pnlValues.Controls.Add(this.txtTime);
            this.pnlValues.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlValues.Location = new System.Drawing.Point(0, 0);
            this.pnlValues.Name = "pnlValues";
            this.pnlValues.Size = new System.Drawing.Size(284, 31);
            this.pnlValues.TabIndex = 4;
            // 
            // btnLink
            // 
            this.btnLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLink.BackgroundImage = global::WinMine.Properties.Resources.Linkedin;
            this.btnLink.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLink.Location = new System.Drawing.Point(258, 4);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(23, 23);
            this.btnLink.TabIndex = 3;
            this.btnLink.UseVisualStyleBackColor = true;
            this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // Demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.pnlValues);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Demo";
            this.Text = "WinMine";
            this.Canvas_MouseUp += new System.EventHandler<System.Windows.Forms.MouseEventArgs>(this.Demo_Canvas_MouseUp);
            this.Controls.SetChildIndex(this.pnlValues, 0);
            this.Controls.SetChildIndex(this.Canvas, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.pnlValues.ResumeLayout(false);
            this.pnlValues.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtMines;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Panel pnlValues;
        private System.Windows.Forms.Button btnLink;
    }
}

