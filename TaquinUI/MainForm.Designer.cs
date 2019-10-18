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
            this.CloseButton = new System.Windows.Forms.Button();
            this.HeaderBar = new System.Windows.Forms.Panel();
            this.NameLabel = new System.Windows.Forms.Label();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.SizeButtonPanel = new System.Windows.Forms.Panel();
            this.SizeButton3 = new System.Windows.Forms.Button();
            this.SizeButton5 = new System.Windows.Forms.Button();
            this.HeaderBar.SuspendLayout();
            this.SizeButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.CloseButton.Location = new System.Drawing.Point(707, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(25, 24);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.Text = "X";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // HeaderBar
            // 
            this.HeaderBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(148)))), ((int)(((byte)(79)))));
            this.HeaderBar.Controls.Add(this.NameLabel);
            this.HeaderBar.Controls.Add(this.CloseButton);
            this.HeaderBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderBar.Location = new System.Drawing.Point(0, 0);
            this.HeaderBar.Name = "HeaderBar";
            this.HeaderBar.Size = new System.Drawing.Size(736, 29);
            this.HeaderBar.TabIndex = 1;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("AR BONNIE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.NameLabel.Location = new System.Drawing.Point(12, 4);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(128, 21);
            this.NameLabel.TabIndex = 1;
            this.NameLabel.Text = "TAQUIN - Alpha 0.0.1";
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.BackColor = System.Drawing.Color.Transparent;
            this.SizeLabel.Font = new System.Drawing.Font("AR BONNIE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SizeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(94)))), ((int)(((byte)(41)))));
            this.SizeLabel.Location = new System.Drawing.Point(32, 43);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(39, 21);
            this.SizeLabel.TabIndex = 2;
            this.SizeLabel.Text = "S I Z E";
            // 
            // SizeButtonPanel
            // 
            this.SizeButtonPanel.Controls.Add(this.SizeButton5);
            this.SizeButtonPanel.Controls.Add(this.SizeButton3);
            this.SizeButtonPanel.Location = new System.Drawing.Point(12, 67);
            this.SizeButtonPanel.Name = "SizeButtonPanel";
            this.SizeButtonPanel.Size = new System.Drawing.Size(155, 75);
            this.SizeButtonPanel.TabIndex = 3;
            // 
            // SizeButton3
            // 
            this.SizeButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(217)))), ((int)(((byte)(218)))));
            this.SizeButton3.FlatAppearance.BorderSize = 0;
            this.SizeButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SizeButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(94)))), ((int)(((byte)(41)))));
            this.SizeButton3.Location = new System.Drawing.Point(4, 3);
            this.SizeButton3.Name = "SizeButton3";
            this.SizeButton3.Size = new System.Drawing.Size(70, 69);
            this.SizeButton3.TabIndex = 0;
            this.SizeButton3.Text = "3 X 3";
            this.SizeButton3.UseVisualStyleBackColor = false;
            // 
            // SizeButton5
            // 
            this.SizeButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(217)))), ((int)(((byte)(218)))));
            this.SizeButton5.FlatAppearance.BorderSize = 0;
            this.SizeButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SizeButton5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(94)))), ((int)(((byte)(41)))));
            this.SizeButton5.Location = new System.Drawing.Point(80, 3);
            this.SizeButton5.Name = "SizeButton5";
            this.SizeButton5.Size = new System.Drawing.Size(70, 69);
            this.SizeButton5.TabIndex = 1;
            this.SizeButton5.Text = "5 X 5";
            this.SizeButton5.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(736, 610);
            this.Controls.Add(this.SizeButtonPanel);
            this.Controls.Add(this.SizeLabel);
            this.Controls.Add(this.HeaderBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "Taquin Alpha";
            this.HeaderBar.ResumeLayout(false);
            this.HeaderBar.PerformLayout();
            this.SizeButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Panel HeaderBar;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.Panel SizeButtonPanel;
        private System.Windows.Forms.Button SizeButton5;
        private System.Windows.Forms.Button SizeButton3;
    }
}

