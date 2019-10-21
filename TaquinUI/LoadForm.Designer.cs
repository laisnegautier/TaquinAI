namespace TaquinUI
{
    partial class LoadForm
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
            this.headerBar = new System.Windows.Forms.Panel();
            this.nameLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.closeLoadButton = new System.Windows.Forms.Button();
            this.loadLabel = new System.Windows.Forms.Label();
            this.filePanel = new System.Windows.Forms.Panel();
            this.loadButton = new System.Windows.Forms.Button();
            this.headerBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerBar
            // 
            this.headerBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(148)))), ((int)(((byte)(79)))));
            this.headerBar.Controls.Add(this.closeLoadButton);
            this.headerBar.Controls.Add(this.nameLabel);
            this.headerBar.Controls.Add(this.closeButton);
            this.headerBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerBar.Location = new System.Drawing.Point(0, 0);
            this.headerBar.Name = "headerBar";
            this.headerBar.Size = new System.Drawing.Size(287, 29);
            this.headerBar.TabIndex = 2;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("AR BONNIE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.nameLabel.Location = new System.Drawing.Point(12, 4);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(180, 21);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "TAQUIN - Homo Sapiens 0.3.2";
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.closeButton.Location = new System.Drawing.Point(707, 3);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(25, 24);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = false;
            // 
            // closeLoadButton
            // 
            this.closeLoadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.closeLoadButton.FlatAppearance.BorderSize = 0;
            this.closeLoadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeLoadButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.closeLoadButton.Location = new System.Drawing.Point(259, 2);
            this.closeLoadButton.Name = "closeLoadButton";
            this.closeLoadButton.Size = new System.Drawing.Size(25, 24);
            this.closeLoadButton.TabIndex = 2;
            this.closeLoadButton.Text = "X";
            this.closeLoadButton.UseVisualStyleBackColor = false;
            this.closeLoadButton.Click += new System.EventHandler(this.CloseLoadButton_Click);
            // 
            // loadLabel
            // 
            this.loadLabel.AutoSize = true;
            this.loadLabel.BackColor = System.Drawing.Color.Transparent;
            this.loadLabel.Font = new System.Drawing.Font("AR BONNIE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(94)))), ((int)(((byte)(41)))));
            this.loadLabel.Location = new System.Drawing.Point(12, 32);
            this.loadLabel.Name = "loadLabel";
            this.loadLabel.Size = new System.Drawing.Size(55, 21);
            this.loadLabel.TabIndex = 3;
            this.loadLabel.Text = "L O A D";
            // 
            // filePanel
            // 
            this.filePanel.Location = new System.Drawing.Point(12, 57);
            this.filePanel.Name = "filePanel";
            this.filePanel.Size = new System.Drawing.Size(263, 325);
            this.filePanel.TabIndex = 4;
            // 
            // loadButton
            // 
            this.loadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(217)))), ((int)(((byte)(218)))));
            this.loadButton.FlatAppearance.BorderSize = 0;
            this.loadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadButton.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(94)))), ((int)(((byte)(41)))));
            this.loadButton.Location = new System.Drawing.Point(69, 388);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(145, 50);
            this.loadButton.TabIndex = 6;
            this.loadButton.Text = "L O A D";
            this.loadButton.UseVisualStyleBackColor = false;
            this.loadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // LoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 450);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.filePanel);
            this.Controls.Add(this.loadLabel);
            this.Controls.Add(this.headerBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoadForm";
            this.Text = "LoadForm";
            this.headerBar.ResumeLayout(false);
            this.headerBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel headerBar;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button closeLoadButton;
        private System.Windows.Forms.Label loadLabel;
        private System.Windows.Forms.Panel filePanel;
        private System.Windows.Forms.Button loadButton;
    }
}