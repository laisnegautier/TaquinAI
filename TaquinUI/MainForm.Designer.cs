namespace TaquinUI
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.closeButton = new System.Windows.Forms.Button();
            this.headerBar = new System.Windows.Forms.Panel();
            this.nameLabel = new System.Windows.Forms.Label();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.sizeButtonPanel = new System.Windows.Forms.Panel();
            this.sizeButton5 = new System.Windows.Forms.Button();
            this.sizeButton3 = new System.Windows.Forms.Button();
            this.boardPanel = new System.Windows.Forms.Panel();
            this.heuristicLabel = new System.Windows.Forms.Label();
            this.heuristicPanel = new System.Windows.Forms.Panel();
            this.headerBar.SuspendLayout();
            this.sizeButtonPanel.SuspendLayout();
            this.SuspendLayout();
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
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // headerBar
            // 
            this.headerBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(148)))), ((int)(((byte)(79)))));
            this.headerBar.Controls.Add(this.nameLabel);
            this.headerBar.Controls.Add(this.closeButton);
            this.headerBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerBar.Location = new System.Drawing.Point(0, 0);
            this.headerBar.Name = "headerBar";
            this.headerBar.Size = new System.Drawing.Size(736, 29);
            this.headerBar.TabIndex = 1;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("AR BONNIE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.nameLabel.Location = new System.Drawing.Point(12, 4);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(128, 21);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "TAQUIN - Alpha 0.0.1";
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.BackColor = System.Drawing.Color.Transparent;
            this.sizeLabel.Font = new System.Drawing.Font("AR BONNIE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sizeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(94)))), ((int)(((byte)(41)))));
            this.sizeLabel.Location = new System.Drawing.Point(32, 43);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(39, 21);
            this.sizeLabel.TabIndex = 2;
            this.sizeLabel.Text = "S I Z E";
            // 
            // sizeButtonPanel
            // 
            this.sizeButtonPanel.Controls.Add(this.sizeButton5);
            this.sizeButtonPanel.Controls.Add(this.sizeButton3);
            this.sizeButtonPanel.Location = new System.Drawing.Point(12, 67);
            this.sizeButtonPanel.Name = "sizeButtonPanel";
            this.sizeButtonPanel.Size = new System.Drawing.Size(155, 75);
            this.sizeButtonPanel.TabIndex = 3;
            // 
            // sizeButton5
            // 
            this.sizeButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(217)))), ((int)(((byte)(218)))));
            this.sizeButton5.FlatAppearance.BorderSize = 0;
            this.sizeButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sizeButton5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(94)))), ((int)(((byte)(41)))));
            this.sizeButton5.Location = new System.Drawing.Point(80, 3);
            this.sizeButton5.Name = "sizeButton5";
            this.sizeButton5.Size = new System.Drawing.Size(70, 69);
            this.sizeButton5.TabIndex = 1;
            this.sizeButton5.Text = "5 X 5";
            this.sizeButton5.UseVisualStyleBackColor = false;
            this.sizeButton5.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.sizeButton5.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // sizeButton3
            // 
            this.sizeButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(217)))), ((int)(((byte)(218)))));
            this.sizeButton3.FlatAppearance.BorderSize = 0;
            this.sizeButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sizeButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(94)))), ((int)(((byte)(41)))));
            this.sizeButton3.Location = new System.Drawing.Point(4, 3);
            this.sizeButton3.Name = "sizeButton3";
            this.sizeButton3.Size = new System.Drawing.Size(70, 69);
            this.sizeButton3.TabIndex = 0;
            this.sizeButton3.Text = "3 X 3";
            this.sizeButton3.UseVisualStyleBackColor = false;
            this.sizeButton3.Click += new System.EventHandler(this.SizeButton3_Click);
            this.sizeButton3.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.sizeButton3.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // boardPanel
            // 
            this.boardPanel.Location = new System.Drawing.Point(208, 67);
            this.boardPanel.Name = "boardPanel";
            this.boardPanel.Size = new System.Drawing.Size(489, 489);
            this.boardPanel.TabIndex = 4;
            // 
            // heuristicLabel
            // 
            this.heuristicLabel.AutoSize = true;
            this.heuristicLabel.BackColor = System.Drawing.Color.Transparent;
            this.heuristicLabel.Font = new System.Drawing.Font("AR BONNIE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.heuristicLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(94)))), ((int)(((byte)(41)))));
            this.heuristicLabel.Location = new System.Drawing.Point(32, 158);
            this.heuristicLabel.Name = "heuristicLabel";
            this.heuristicLabel.Size = new System.Drawing.Size(87, 21);
            this.heuristicLabel.TabIndex = 5;
            this.heuristicLabel.Text = "H E U R I S T I C";
            // 
            // heuristicPanel
            // 
            this.heuristicPanel.Location = new System.Drawing.Point(16, 194);
            this.heuristicPanel.Name = "heuristicPanel";
            this.heuristicPanel.Size = new System.Drawing.Size(151, 165);
            this.heuristicPanel.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(736, 610);
            this.Controls.Add(this.heuristicPanel);
            this.Controls.Add(this.heuristicLabel);
            this.Controls.Add(this.boardPanel);
            this.Controls.Add(this.sizeButtonPanel);
            this.Controls.Add(this.sizeLabel);
            this.Controls.Add(this.headerBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Taquin Alpha";
            this.headerBar.ResumeLayout(false);
            this.headerBar.PerformLayout();
            this.sizeButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Panel headerBar;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.Panel sizeButtonPanel;
        private System.Windows.Forms.Button sizeButton5;
        private System.Windows.Forms.Button sizeButton3;
        private System.Windows.Forms.Panel boardPanel;
        private System.Windows.Forms.Label heuristicLabel;
        private System.Windows.Forms.Panel heuristicPanel;
    }
}

