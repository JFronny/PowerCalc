namespace PowerCalc
{
    partial class MainForm
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
            this.evalBox = new System.Windows.Forms.Panel();
            this.calcBox1 = new System.Windows.Forms.TextBox();
            this.calcBox2 = new System.Windows.Forms.TextBox();
            this.calcBox3 = new System.Windows.Forms.TextBox();
            this.calcBox4 = new System.Windows.Forms.TextBox();
            this.calcLabel1 = new System.Windows.Forms.Label();
            this.calcLabel2 = new System.Windows.Forms.Label();
            this.calcLabel3 = new System.Windows.Forms.Label();
            this.calcLabel4 = new System.Windows.Forms.Label();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.saveButton = new System.Windows.Forms.Button();
            this.coordLabel = new System.Windows.Forms.Label();
            this.evalButton = new System.Windows.Forms.Button();
            this.logExpandButton = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.TextBox();
            this.logCollapseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // evalBox
            // 
            this.evalBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.evalBox.BackColor = System.Drawing.Color.White;
            this.evalBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.evalBox.Location = new System.Drawing.Point(3, 5);
            this.evalBox.Name = "evalBox";
            this.evalBox.Size = new System.Drawing.Size(254, 145);
            this.evalBox.TabIndex = 0;
            this.evalBox.Paint += new System.Windows.Forms.PaintEventHandler(this.evalBox_Paint);
            this.evalBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.evalBox_MouseDown);
            this.evalBox.MouseLeave += new System.EventHandler(this.evalBox_MouseLeave);
            this.evalBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.evalBox_MouseMove);
            // 
            // calcBox1
            // 
            this.calcBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calcBox1.Location = new System.Drawing.Point(27, 173);
            this.calcBox1.Name = "calcBox1";
            this.calcBox1.Size = new System.Drawing.Size(230, 20);
            this.calcBox1.TabIndex = 1;
            this.calcBox1.Text = "x";
            // 
            // calcBox2
            // 
            this.calcBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calcBox2.Location = new System.Drawing.Point(27, 199);
            this.calcBox2.Name = "calcBox2";
            this.calcBox2.Size = new System.Drawing.Size(230, 20);
            this.calcBox2.TabIndex = 2;
            this.calcBox2.Text = "x";
            // 
            // calcBox3
            // 
            this.calcBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calcBox3.Location = new System.Drawing.Point(27, 225);
            this.calcBox3.Name = "calcBox3";
            this.calcBox3.Size = new System.Drawing.Size(230, 20);
            this.calcBox3.TabIndex = 3;
            this.calcBox3.Text = "x";
            // 
            // calcBox4
            // 
            this.calcBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calcBox4.Location = new System.Drawing.Point(27, 251);
            this.calcBox4.Name = "calcBox4";
            this.calcBox4.Size = new System.Drawing.Size(230, 20);
            this.calcBox4.TabIndex = 4;
            this.calcBox4.Text = "x";
            // 
            // calcLabel1
            // 
            this.calcLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.calcLabel1.AutoSize = true;
            this.calcLabel1.ForeColor = System.Drawing.Color.Red;
            this.calcLabel1.Location = new System.Drawing.Point(3, 176);
            this.calcLabel1.Name = "calcLabel1";
            this.calcLabel1.Size = new System.Drawing.Size(27, 13);
            this.calcLabel1.TabIndex = 5;
            this.calcLabel1.Text = "f(x)=";
            // 
            // calcLabel2
            // 
            this.calcLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.calcLabel2.AutoSize = true;
            this.calcLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.calcLabel2.Location = new System.Drawing.Point(3, 202);
            this.calcLabel2.Name = "calcLabel2";
            this.calcLabel2.Size = new System.Drawing.Size(27, 13);
            this.calcLabel2.TabIndex = 6;
            this.calcLabel2.Text = "f(x)=";
            // 
            // calcLabel3
            // 
            this.calcLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.calcLabel3.AutoSize = true;
            this.calcLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.calcLabel3.Location = new System.Drawing.Point(3, 228);
            this.calcLabel3.Name = "calcLabel3";
            this.calcLabel3.Size = new System.Drawing.Size(27, 13);
            this.calcLabel3.TabIndex = 7;
            this.calcLabel3.Text = "f(x)=";
            // 
            // calcLabel4
            // 
            this.calcLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.calcLabel4.AutoSize = true;
            this.calcLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.calcLabel4.Location = new System.Drawing.Point(3, 254);
            this.calcLabel4.Name = "calcLabel4";
            this.calcLabel4.Size = new System.Drawing.Size(27, 13);
            this.calcLabel4.TabIndex = 8;
            this.calcLabel4.Text = "f(x)=";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.MinimumSize = new System.Drawing.Size(200, 200);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.AutoScroll = true;
            this.splitContainer.Panel1.Controls.Add(this.saveButton);
            this.splitContainer.Panel1.Controls.Add(this.coordLabel);
            this.splitContainer.Panel1.Controls.Add(this.evalButton);
            this.splitContainer.Panel1.Controls.Add(this.logExpandButton);
            this.splitContainer.Panel1.Controls.Add(this.evalBox);
            this.splitContainer.Panel1.Controls.Add(this.calcBox1);
            this.splitContainer.Panel1.Controls.Add(this.calcLabel1);
            this.splitContainer.Panel1.Controls.Add(this.calcBox2);
            this.splitContainer.Panel1.Controls.Add(this.calcLabel2);
            this.splitContainer.Panel1.Controls.Add(this.calcBox3);
            this.splitContainer.Panel1.Controls.Add(this.calcLabel3);
            this.splitContainer.Panel1.Controls.Add(this.calcBox4);
            this.splitContainer.Panel1.Controls.Add(this.calcLabel4);
            this.splitContainer.Panel1MinSize = 200;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.logBox);
            this.splitContainer.Panel2.Controls.Add(this.logCollapseButton);
            this.splitContainer.Panel2MinSize = 0;
            this.splitContainer.Size = new System.Drawing.Size(448, 274);
            this.splitContainer.SplitterDistance = 260;
            this.splitContainer.TabIndex = 9;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.Location = new System.Drawing.Point(39, 150);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(23, 23);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "💾";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // coordLabel
            // 
            this.coordLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.coordLabel.AutoSize = true;
            this.coordLabel.Location = new System.Drawing.Point(68, 155);
            this.coordLabel.Name = "coordLabel";
            this.coordLabel.Size = new System.Drawing.Size(44, 13);
            this.coordLabel.TabIndex = 10;
            this.coordLabel.Text = "{X=,Y=}";
            // 
            // evalButton
            // 
            this.evalButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.evalButton.Location = new System.Drawing.Point(3, 150);
            this.evalButton.Name = "evalButton";
            this.evalButton.Size = new System.Drawing.Size(36, 23);
            this.evalButton.TabIndex = 9;
            this.evalButton.Text = "Eval";
            this.evalButton.UseVisualStyleBackColor = true;
            this.evalButton.Click += new System.EventHandler(this.eval);
            // 
            // logExpandButton
            // 
            this.logExpandButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.logExpandButton.Location = new System.Drawing.Point(234, 150);
            this.logExpandButton.Name = "logExpandButton";
            this.logExpandButton.Size = new System.Drawing.Size(23, 23);
            this.logExpandButton.TabIndex = 0;
            this.logExpandButton.Text = ">";
            this.logExpandButton.UseVisualStyleBackColor = true;
            this.logExpandButton.Visible = false;
            this.logExpandButton.Click += new System.EventHandler(this.logExpandButton_Click);
            // 
            // logBox
            // 
            this.logBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logBox.Location = new System.Drawing.Point(0, 0);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(184, 251);
            this.logBox.TabIndex = 0;
            // 
            // logCollapseButton
            // 
            this.logCollapseButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logCollapseButton.Location = new System.Drawing.Point(0, 251);
            this.logCollapseButton.Name = "logCollapseButton";
            this.logCollapseButton.Size = new System.Drawing.Size(184, 23);
            this.logCollapseButton.TabIndex = 1;
            this.logCollapseButton.Text = "<<<";
            this.logCollapseButton.UseVisualStyleBackColor = true;
            this.logCollapseButton.Click += new System.EventHandler(this.logCollapseButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(448, 274);
            this.Controls.Add(this.splitContainer);
            this.MinimumSize = new System.Drawing.Size(266, 243);
            this.Name = "MainForm";
            this.Text = "PowerCalc";
            this.Resize += new System.EventHandler(this.eval);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel evalBox;
        private System.Windows.Forms.TextBox calcBox1;
        private System.Windows.Forms.TextBox calcBox2;
        private System.Windows.Forms.TextBox calcBox3;
        private System.Windows.Forms.TextBox calcBox4;
        private System.Windows.Forms.Label calcLabel1;
        private System.Windows.Forms.Label calcLabel2;
        private System.Windows.Forms.Label calcLabel3;
        private System.Windows.Forms.Label calcLabel4;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.Button logCollapseButton;
        private System.Windows.Forms.Button logExpandButton;
        private System.Windows.Forms.Button evalButton;
        private System.Windows.Forms.Label coordLabel;
        private System.Windows.Forms.Button saveButton;
    }
}

