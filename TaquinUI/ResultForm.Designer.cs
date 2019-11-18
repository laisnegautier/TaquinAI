namespace TaquinUI
{
    partial class ResultForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultForm));
            this.HeaderBar = new System.Windows.Forms.Panel();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.boardPanel = new System.Windows.Forms.Panel();
            this.leftButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            this.nbMovesLabel = new System.Windows.Forms.Label();
            this.HeaderBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeaderBar
            // 
            this.HeaderBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(148)))), ((int)(((byte)(79)))));
            this.HeaderBar.Controls.Add(this.minimizeButton);
            this.HeaderBar.Controls.Add(this.nameLabel);
            this.HeaderBar.Controls.Add(this.button1);
            this.HeaderBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderBar.Location = new System.Drawing.Point(0, 0);
            this.HeaderBar.Name = "HeaderBar";
            this.HeaderBar.Size = new System.Drawing.Size(586, 29);
            this.HeaderBar.TabIndex = 0;
            // 
            // minimizeButton
            // 
            this.minimizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.minimizeButton.Location = new System.Drawing.Point(527, 2);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(25, 24);
            this.minimizeButton.TabIndex = 3;
            this.minimizeButton.Text = "_";
            this.minimizeButton.UseVisualStyleBackColor = false;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("AR BONNIE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.nameLabel.Location = new System.Drawing.Point(12, 4);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(180, 21);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "TAQUIN - Homo Sapiens 0.3.2";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.button1.Location = new System.Drawing.Point(558, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // boardPanel
            // 
            this.boardPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.boardPanel.Location = new System.Drawing.Point(49, 35);
            this.boardPanel.Name = "boardPanel";
            this.boardPanel.Size = new System.Drawing.Size(489, 489);
            this.boardPanel.TabIndex = 5;
            // 
            // leftButton
            // 
            this.leftButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.leftButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("leftButton.BackgroundImage")));
            this.leftButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.leftButton.FlatAppearance.BorderSize = 0;
            this.leftButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leftButton.Location = new System.Drawing.Point(16, 562);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(82, 81);
            this.leftButton.TabIndex = 6;
            this.leftButton.UseVisualStyleBackColor = false;
            this.leftButton.Click += new System.EventHandler(this.LeftButton_Click);
            // 
            // rightButton
            // 
            this.rightButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rightButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rightButton.BackgroundImage")));
            this.rightButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rightButton.FlatAppearance.BorderSize = 0;
            this.rightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rightButton.Location = new System.Drawing.Point(492, 562);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(82, 81);
            this.rightButton.TabIndex = 7;
            this.rightButton.UseVisualStyleBackColor = false;
            this.rightButton.Click += new System.EventHandler(this.RightButton_Click);
            // 
            // nbMovesLabel
            // 
            this.nbMovesLabel.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbMovesLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(94)))), ((int)(((byte)(41)))));
            this.nbMovesLabel.Location = new System.Drawing.Point(104, 527);
            this.nbMovesLabel.Name = "nbMovesLabel";
            this.nbMovesLabel.Size = new System.Drawing.Size(382, 163);
            this.nbMovesLabel.TabIndex = 8;
            this.nbMovesLabel.Text = "Ce Taquin à été résolu en ";
            this.nbMovesLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(586, 699);
            this.Controls.Add(this.nbMovesLabel);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.boardPanel);
            this.Controls.Add(this.HeaderBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ResultForm";
            this.Text = "ResultForm";
            this.HeaderBar.ResumeLayout(false);
            this.HeaderBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel HeaderBar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel boardPanel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.Label nbMovesLabel;
        private System.Windows.Forms.Button minimizeButton;
    }
}