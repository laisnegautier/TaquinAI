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
            this.minimizeButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.sizeButtonPanel = new System.Windows.Forms.Panel();
            this.sizeButton5 = new System.Windows.Forms.Button();
            this.sizeButton3 = new System.Windows.Forms.Button();
            this.boardPanel = new System.Windows.Forms.Panel();
            this.heuristicLabel = new System.Windows.Forms.Label();
            this.heuristicPanel = new System.Windows.Forms.Panel();
            this.heuristicThreeButton = new System.Windows.Forms.Button();
            this.heuristicTwoButton = new System.Windows.Forms.Button();
            this.heuristicOneButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.actionButtonsPanel = new System.Windows.Forms.Panel();
            this.shuffleButton = new System.Windows.Forms.Button();
            this.solveButton = new System.Windows.Forms.Button();
            this.solverLabel = new System.Windows.Forms.Label();
            this.solverPanel = new System.Windows.Forms.Panel();
            this.IDAStarButton = new System.Windows.Forms.Button();
            this.AstarUniButton = new System.Windows.Forms.Button();
            this.segmentButton = new System.Windows.Forms.Button();
            this.headerBar.SuspendLayout();
            this.sizeButtonPanel.SuspendLayout();
            this.heuristicPanel.SuspendLayout();
            this.actionButtonsPanel.SuspendLayout();
            this.solverPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.closeButton.Location = new System.Drawing.Point(759, 2);
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
            this.headerBar.Controls.Add(this.minimizeButton);
            this.headerBar.Controls.Add(this.nameLabel);
            this.headerBar.Controls.Add(this.closeButton);
            this.headerBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerBar.Location = new System.Drawing.Point(0, 0);
            this.headerBar.Name = "headerBar";
            this.headerBar.Size = new System.Drawing.Size(787, 29);
            this.headerBar.TabIndex = 1;
            this.headerBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dragBorder_MouseDown);
            this.headerBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dragBorder_MouseMove);
            this.headerBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dragBorder_MouseUp);
            // 
            // minimizeButton
            // 
            this.minimizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.minimizeButton.Location = new System.Drawing.Point(727, 2);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(25, 24);
            this.minimizeButton.TabIndex = 4;
            this.minimizeButton.Text = "_";
            this.minimizeButton.UseVisualStyleBackColor = false;
            this.minimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
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
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.BackColor = System.Drawing.Color.Transparent;
            this.sizeLabel.Font = new System.Drawing.Font("AR BONNIE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sizeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(94)))), ((int)(((byte)(41)))));
            this.sizeLabel.Location = new System.Drawing.Point(21, 70);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(39, 21);
            this.sizeLabel.TabIndex = 2;
            this.sizeLabel.Text = "S I Z E";
            // 
            // sizeButtonPanel
            // 
            this.sizeButtonPanel.Controls.Add(this.sizeButton5);
            this.sizeButtonPanel.Controls.Add(this.sizeButton3);
            this.sizeButtonPanel.Location = new System.Drawing.Point(17, 94);
            this.sizeButtonPanel.Name = "sizeButtonPanel";
            this.sizeButtonPanel.Size = new System.Drawing.Size(155, 75);
            this.sizeButtonPanel.TabIndex = 3;
            // 
            // sizeButton5
            // 
            this.sizeButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(217)))), ((int)(((byte)(218)))));
            this.sizeButton5.FlatAppearance.BorderSize = 0;
            this.sizeButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sizeButton5.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sizeButton5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(94)))), ((int)(((byte)(41)))));
            this.sizeButton5.Location = new System.Drawing.Point(80, 3);
            this.sizeButton5.Name = "sizeButton5";
            this.sizeButton5.Size = new System.Drawing.Size(70, 69);
            this.sizeButton5.TabIndex = 1;
            this.sizeButton5.Text = "5 X 5";
            this.sizeButton5.UseVisualStyleBackColor = false;
            this.sizeButton5.Click += new System.EventHandler(this.SizeButton5_Click);
            this.sizeButton5.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.sizeButton5.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // sizeButton3
            // 
            this.sizeButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(217)))), ((int)(((byte)(218)))));
            this.sizeButton3.FlatAppearance.BorderSize = 0;
            this.sizeButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sizeButton3.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.boardPanel.Location = new System.Drawing.Point(209, 67);
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
            this.heuristicLabel.Location = new System.Drawing.Point(21, 184);
            this.heuristicLabel.Name = "heuristicLabel";
            this.heuristicLabel.Size = new System.Drawing.Size(87, 21);
            this.heuristicLabel.TabIndex = 5;
            this.heuristicLabel.Text = "H E U R I S T I C";
            // 
            // heuristicPanel
            // 
            this.heuristicPanel.Controls.Add(this.heuristicThreeButton);
            this.heuristicPanel.Controls.Add(this.heuristicTwoButton);
            this.heuristicPanel.Controls.Add(this.heuristicOneButton);
            this.heuristicPanel.Location = new System.Drawing.Point(18, 208);
            this.heuristicPanel.Name = "heuristicPanel";
            this.heuristicPanel.Size = new System.Drawing.Size(154, 165);
            this.heuristicPanel.TabIndex = 6;
            // 
            // heuristicThreeButton
            // 
            this.heuristicThreeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(217)))), ((int)(((byte)(218)))));
            this.heuristicThreeButton.FlatAppearance.BorderSize = 0;
            this.heuristicThreeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.heuristicThreeButton.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.heuristicThreeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(94)))), ((int)(((byte)(41)))));
            this.heuristicThreeButton.Location = new System.Drawing.Point(3, 112);
            this.heuristicThreeButton.Name = "heuristicThreeButton";
            this.heuristicThreeButton.Size = new System.Drawing.Size(148, 50);
            this.heuristicThreeButton.TabIndex = 4;
            this.heuristicThreeButton.Text = "Distance De Manhattan";
            this.heuristicThreeButton.UseVisualStyleBackColor = false;
            this.heuristicThreeButton.Click += new System.EventHandler(this.HeuristicButton_Click);
            this.heuristicThreeButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.heuristicThreeButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // heuristicTwoButton
            // 
            this.heuristicTwoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(217)))), ((int)(((byte)(218)))));
            this.heuristicTwoButton.FlatAppearance.BorderSize = 0;
            this.heuristicTwoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.heuristicTwoButton.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.heuristicTwoButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(94)))), ((int)(((byte)(41)))));
            this.heuristicTwoButton.Location = new System.Drawing.Point(3, 57);
            this.heuristicTwoButton.Name = "heuristicTwoButton";
            this.heuristicTwoButton.Size = new System.Drawing.Size(148, 50);
            this.heuristicTwoButton.TabIndex = 3;
            this.heuristicTwoButton.Text = "P + LC + C";
            this.heuristicTwoButton.UseVisualStyleBackColor = false;
            this.heuristicTwoButton.Click += new System.EventHandler(this.HeuristicButton_Click);
            this.heuristicTwoButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.heuristicTwoButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // heuristicOneButton
            // 
            this.heuristicOneButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(217)))), ((int)(((byte)(218)))));
            this.heuristicOneButton.FlatAppearance.BorderSize = 0;
            this.heuristicOneButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.heuristicOneButton.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.heuristicOneButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(94)))), ((int)(((byte)(41)))));
            this.heuristicOneButton.Location = new System.Drawing.Point(3, 3);
            this.heuristicOneButton.Name = "heuristicOneButton";
            this.heuristicOneButton.Size = new System.Drawing.Size(148, 50);
            this.heuristicOneButton.TabIndex = 2;
            this.heuristicOneButton.Text = "P + LC";
            this.heuristicOneButton.UseVisualStyleBackColor = false;
            this.heuristicOneButton.Click += new System.EventHandler(this.HeuristicButton_Click);
            this.heuristicOneButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.heuristicOneButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // loadButton
            // 
            this.loadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(217)))), ((int)(((byte)(218)))));
            this.loadButton.FlatAppearance.BorderSize = 0;
            this.loadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadButton.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(94)))), ((int)(((byte)(41)))));
            this.loadButton.Location = new System.Drawing.Point(341, 3);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(145, 50);
            this.loadButton.TabIndex = 5;
            this.loadButton.Text = "L O A D";
            this.loadButton.UseVisualStyleBackColor = false;
            this.loadButton.Click += new System.EventHandler(this.LoadButton_Click);
            this.loadButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.loadButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // actionButtonsPanel
            // 
            this.actionButtonsPanel.Controls.Add(this.shuffleButton);
            this.actionButtonsPanel.Controls.Add(this.solveButton);
            this.actionButtonsPanel.Controls.Add(this.loadButton);
            this.actionButtonsPanel.Location = new System.Drawing.Point(208, 562);
            this.actionButtonsPanel.Name = "actionButtonsPanel";
            this.actionButtonsPanel.Size = new System.Drawing.Size(489, 59);
            this.actionButtonsPanel.TabIndex = 7;
            // 
            // shuffleButton
            // 
            this.shuffleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(217)))), ((int)(((byte)(218)))));
            this.shuffleButton.FlatAppearance.BorderSize = 0;
            this.shuffleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shuffleButton.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shuffleButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(94)))), ((int)(((byte)(41)))));
            this.shuffleButton.Location = new System.Drawing.Point(3, 3);
            this.shuffleButton.Name = "shuffleButton";
            this.shuffleButton.Size = new System.Drawing.Size(145, 50);
            this.shuffleButton.TabIndex = 7;
            this.shuffleButton.Text = "S H U F F L E";
            this.shuffleButton.UseVisualStyleBackColor = false;
            this.shuffleButton.Click += new System.EventHandler(this.ShuffleButton_Click);
            this.shuffleButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.shuffleButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // solveButton
            // 
            this.solveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(217)))), ((int)(((byte)(218)))));
            this.solveButton.FlatAppearance.BorderSize = 0;
            this.solveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.solveButton.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solveButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(94)))), ((int)(((byte)(41)))));
            this.solveButton.Location = new System.Drawing.Point(172, 3);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(145, 50);
            this.solveButton.TabIndex = 6;
            this.solveButton.Text = "S O L V E";
            this.solveButton.UseVisualStyleBackColor = false;
            this.solveButton.Click += new System.EventHandler(this.SolveButton_Click);
            this.solveButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.solveButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // solverLabel
            // 
            this.solverLabel.AutoSize = true;
            this.solverLabel.BackColor = System.Drawing.Color.Transparent;
            this.solverLabel.Font = new System.Drawing.Font("AR BONNIE", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solverLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(94)))), ((int)(((byte)(41)))));
            this.solverLabel.Location = new System.Drawing.Point(21, 397);
            this.solverLabel.Name = "solverLabel";
            this.solverLabel.Size = new System.Drawing.Size(70, 21);
            this.solverLabel.TabIndex = 8;
            this.solverLabel.Text = "S O L V E R";
            // 
            // solverPanel
            // 
            this.solverPanel.Controls.Add(this.IDAStarButton);
            this.solverPanel.Controls.Add(this.AstarUniButton);
            this.solverPanel.Controls.Add(this.segmentButton);
            this.solverPanel.Location = new System.Drawing.Point(18, 418);
            this.solverPanel.Name = "solverPanel";
            this.solverPanel.Size = new System.Drawing.Size(154, 165);
            this.solverPanel.TabIndex = 7;
            // 
            // IDAStarButton
            // 
            this.IDAStarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(217)))), ((int)(((byte)(218)))));
            this.IDAStarButton.FlatAppearance.BorderSize = 0;
            this.IDAStarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IDAStarButton.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDAStarButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(94)))), ((int)(((byte)(41)))));
            this.IDAStarButton.Location = new System.Drawing.Point(3, 112);
            this.IDAStarButton.Name = "IDAStarButton";
            this.IDAStarButton.Size = new System.Drawing.Size(148, 50);
            this.IDAStarButton.TabIndex = 5;
            this.IDAStarButton.Text = "IDA*";
            this.IDAStarButton.UseVisualStyleBackColor = false;
            this.IDAStarButton.Click += new System.EventHandler(this.SolverButton_CLick);
            // 
            // AstarUniButton
            // 
            this.AstarUniButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(217)))), ((int)(((byte)(218)))));
            this.AstarUniButton.FlatAppearance.BorderSize = 0;
            this.AstarUniButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AstarUniButton.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AstarUniButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(94)))), ((int)(((byte)(41)))));
            this.AstarUniButton.Location = new System.Drawing.Point(3, 3);
            this.AstarUniButton.Name = "AstarUniButton";
            this.AstarUniButton.Size = new System.Drawing.Size(148, 50);
            this.AstarUniButton.TabIndex = 3;
            this.AstarUniButton.Text = "A * - Uni";
            this.AstarUniButton.UseVisualStyleBackColor = false;
            this.AstarUniButton.Click += new System.EventHandler(this.SolverButton_CLick);
            this.AstarUniButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.AstarUniButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // segmentButton
            // 
            this.segmentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(217)))), ((int)(((byte)(218)))));
            this.segmentButton.FlatAppearance.BorderSize = 0;
            this.segmentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.segmentButton.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.segmentButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(94)))), ((int)(((byte)(41)))));
            this.segmentButton.Location = new System.Drawing.Point(3, 57);
            this.segmentButton.Name = "segmentButton";
            this.segmentButton.Size = new System.Drawing.Size(148, 50);
            this.segmentButton.TabIndex = 2;
            this.segmentButton.Text = "Methode par Segments";
            this.segmentButton.UseVisualStyleBackColor = false;
            this.segmentButton.Click += new System.EventHandler(this.SolverButton_CLick);
            this.segmentButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.segmentButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(787, 633);
            this.Controls.Add(this.solverPanel);
            this.Controls.Add(this.solverLabel);
            this.Controls.Add(this.actionButtonsPanel);
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
            this.heuristicPanel.ResumeLayout(false);
            this.actionButtonsPanel.ResumeLayout(false);
            this.solverPanel.ResumeLayout(false);
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
        private System.Windows.Forms.Button heuristicThreeButton;
        private System.Windows.Forms.Button heuristicTwoButton;
        private System.Windows.Forms.Button heuristicOneButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Panel actionButtonsPanel;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.Button shuffleButton;
        private System.Windows.Forms.Label solverLabel;
        private System.Windows.Forms.Panel solverPanel;
        private System.Windows.Forms.Button AstarUniButton;
        private System.Windows.Forms.Button segmentButton;
        private System.Windows.Forms.Button IDAStarButton;
        private System.Windows.Forms.Button minimizeButton;
    }
}

