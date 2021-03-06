﻿using System;
using System.Drawing;
using System.Windows.Forms;
using TaquinCodeBehind;

namespace TaquinUI
{
    /// <summary>
    /// Fenêtre principale de l'application de résolution de Taquin
    /// </summary>
    public partial class MainForm : Form
    {
        #region Attributes
        Random r = new Random();
        // Taquin
        private int _selectedSize;
        private Taquin taquin;
        // Solver
        private IHeuristic _selectedHeuristic;
        private Solver _solver;
        // Child Forms
        private ResultForm _resultForm;
        private LoadForm _loadForm;
        private string _fileName;
        // Panel movement
        private bool mouseDown;
        private Point lastLocation;
        // locking
        private bool heuriLock = false;
        private bool solverLock = false;
        #endregion

        #region Construct
        public MainForm()
        {
            InitializeComponent();
            // Initialisation des paramètres internes du Form
            _resultForm = new ResultForm();
            _fileName = "";
            _loadForm = new LoadForm();
            _loadForm.FormClosing += (s, e) => LoadForm_Close(s, e);
            // Défini la taille, 3x3 par défault
            _selectedSize = 3;
            ButtonSetFocus(sizeButton3);
            // Define Heuristic
            _selectedHeuristic = new Manhattan();
            ButtonSetFocus(heuristicThreeButton);
            // Define Solver
            _solver = new AstarUni(_selectedHeuristic);
            ButtonSetFocus(AstarUniButton);
            taquin = new Taquin(_selectedSize);
            //Debug.WriteLine(taquin);
            SetBoard();
        }
        #endregion

        #region UIMethods_Misceallanous
        // Bouton permettant de fermer l'application
        private void CloseButton_Click(object sender, EventArgs e)
        {
            // Ferme au préalable les enfants
            if (_loadForm.IsAccessible) _loadForm.Close();
            if (_resultForm.IsAccessible) _resultForm.Close();
            Close();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Fonctions permettant de drag le Form
        private void dragBorder_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void dragBorder_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void dragBorder_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        #endregion

        #region UIMethods_Foncitonnalities
        // Permet de placer tous les cellButton dans l'espace dedier à l'affichage du board
        private void SetBoard()
        {
            int line = -1;
            int column = 0;
            boardPanel.Controls.Clear();
            // Pour chaque cellule on crée un cellButton object et on créer les évenement associés
            foreach (Cell cell in taquin)
            {
                if (column % _selectedSize == 0) line++;
                int size = boardPanel.Width / _selectedSize;
                CellButton currentCellButton = new CellButton(cell, size);

                currentCellButton.MouseEnter += (s, e) => Button_MouseEnter(s, e);
                currentCellButton.MouseLeave += (s, e) => Button_MouseLeave(s, e);
                currentCellButton.Click += (s, e) => CellButton_Click(s, e);
                // Placement des boutons dans l'interface
                currentCellButton.Left = ((column % _selectedSize) * size);
                currentCellButton.Top = (line * size);
                boardPanel.Controls.Add(currentCellButton);
                column++;
            }
        }

        // Permet d'update le Taquin après un mouvement
        private void UpdateBoard()
        {
            // Cette fois ci on assure la concordance entre l'UI et le backend en loopant sur les cell button
            foreach (CellButton cellBtn in boardPanel.Controls)
            {
                int id = cellBtn.TabIndex;
                int i, j;
                Functions.pos2coord(out i, out j, id, _selectedSize);
                cellBtn.Cell = taquin.GetCell(i, j);
                cellBtn.Text = cellBtn.Cell.Value;
            }
        }
        
        // Fonction trigger lorsque un bouton raise un MouseEnter event
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ButtonSetFocus(button);
        }

        // Fonction trigger lorsque un bouton raise un MouseLeave envent
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            // Si le bouton est une taille et que la taille est déjà selectionnée on ne fait rien
            if ((button == sizeButton3 && _selectedSize == 3) || (button == sizeButton5 && _selectedSize == 5)) ;
            // On agi en fonction de l'heuristique courante
            else if ((button == heuristicOneButton && _selectedHeuristic.GetType() == typeof(PLC))
                   || (button == heuristicTwoButton && _selectedHeuristic.GetType() == typeof(PLCC))
                   || (button == heuristicThreeButton && _selectedHeuristic.GetType() == typeof(Manhattan))) ;
            // On agi en fonction du solver courante
            else if ((button == AstarUniButton && _solver.GetType() == typeof(AstarUni))
                  || (button == segmentButton && _solver.GetType() == typeof(Segments))
                  || (button == IDAStarButton && _solver.GetType() == typeof(IDAstar))) ;
            else ButtonUnsetFocus(button);
        }

        // Fonction mettant le focus sur un bouton selectionné
        private void ButtonSetFocus(Button button)
        {
            button.BackColor = Color.FromArgb(255, 143, 143);
            button.ForeColor = Color.FromArgb(252, 252, 250);
        }

        // Fonction retirant le focus d'un bouton
        private void ButtonUnsetFocus(Button button)
        {
            button.BackColor = Color.FromArgb(231, 217, 218);
            button.ForeColor = Color.FromArgb(66, 94, 41);
        }
        
        // Fonction permettant de locker un bouton
        private void ButtonLockView(Button button)
        {
            button.BackColor = Color.FromArgb(179, 167, 168);
            button.ForeColor = Color.FromArgb(179, 167, 168);
            button.MouseEnter -= Button_MouseEnter;
            button.MouseLeave -= Button_MouseLeave;
            if (button == heuristicOneButton ||
                button == heuristicTwoButton ||
                button == heuristicThreeButton)
            {
                heuriLock = true;
                button.Click -= HeuristicButton_Click;
            }
            if (button == AstarUniButton ||
                     button == IDAStarButton ||
                     button == segmentButton)
            {
                solverLock = true;
                button.Click -= SolverButton_CLick;
            }
        }

        private void UnlockButtonView(Button button)
        {
            button.BackColor = Color.FromArgb(231, 217, 218);
            button.ForeColor = Color.FromArgb(66, 94, 41);
            button.MouseEnter += Button_MouseEnter;
            button.MouseLeave += Button_MouseLeave;
            if (button == heuristicOneButton ||
                button == heuristicTwoButton ||
                button == heuristicThreeButton)
            {
                heuriLock = false;
                button.Click += HeuristicButton_Click;
            }
            if (button == AstarUniButton ||
                 button == IDAStarButton ||
                 button == segmentButton)
            {
                solverLock = false;
                button.Click += SolverButton_CLick;
            }
        }
        #endregion

        #region UIMethod_Interactions
        // Initialise un Taquin 3x3 dans l'interface
        private void SizeButton3_Click(object sender, EventArgs e)
        {
            if(_selectedSize != 3) // On effectue rien si l'on avait déjà un Taquin 3x3 présent
            {
                // Gestion du 3x3
                ButtonSetFocus(sizeButton3);
                _selectedSize = 3;
                taquin = new Taquin(3);
                SetBoard();
                ButtonUnsetFocus(sizeButton5);
                // Conséquences
                if(heuriLock == true && _solver.GetType() != typeof(Segments))
                {
                    UnlockButtonView(heuristicOneButton);
                    UnlockButtonView(heuristicTwoButton);
                    UnlockButtonView(heuristicThreeButton);
                    heuriLock = false;
                }
                if(solverLock == true)
                {
                    UnlockButtonView(AstarUniButton);
                    UnlockButtonView(IDAStarButton);
                    solverLock = false;
                }
            }
        }

        // Initialise un Taquin 5x5 dans l'interface
        private void SizeButton5_Click(object sender, EventArgs e)
        {
            if (_selectedSize != 5) // On effectue rien si l'on avait déjà un Taquin 5x5 présent
            {
                // Gestion du 5x5
                ButtonSetFocus(sizeButton5);
                _selectedSize = 5;
                taquin = new Taquin(5);
                SetBoard();
                ButtonUnsetFocus(sizeButton3);
                // Conséquences
                if(heuriLock == false)
                {
                    ButtonLockView(heuristicOneButton);
                    ButtonLockView(heuristicTwoButton);
                    ButtonLockView(heuristicThreeButton);
                    heuriLock = true;
                }
                if(solverLock == false)
                {
                    ButtonLockView(AstarUniButton);
                    ButtonLockView(IDAStarButton);
                    _solver = new Segments(_selectedHeuristic);
                    ButtonSetFocus(segmentButton);
                    solverLock = true;
                }
            }
        }

        // Permet de selectionner une heuristique pour un solver
        private void HeuristicButton_Click(object sender, EventArgs e)
        {
            // Enlève le focus du bouton précedent
            if (_selectedHeuristic.GetType() == typeof(Manhattan)) ButtonUnsetFocus(heuristicThreeButton);
            else if (_selectedHeuristic.GetType() == typeof(PLC)) ButtonUnsetFocus(heuristicOneButton);
            else ButtonUnsetFocus(heuristicTwoButton);
            // Ajoute l'heuristique choisie comme courante et met le bouton en Focus
            Button button = (Button)sender;
            if (button == heuristicOneButton) _selectedHeuristic = new PLC();
            else if (button == heuristicTwoButton) _selectedHeuristic = new PLCC();
            else _selectedHeuristic = new Manhattan();
            ButtonSetFocus(button);
        }

        // Permet de selectionner le solver de l'application
        private void SolverButton_CLick(object sender, EventArgs e)
        {
            // Enlève le focus du bouton précedent
            if (_solver.GetType() == typeof(Segments)) ButtonUnsetFocus(segmentButton);
            else if (_solver.GetType() == typeof(AstarUni)) ButtonUnsetFocus(AstarUniButton);
            else if (_solver.GetType() == typeof(IDAstar)) ButtonUnsetFocus(IDAStarButton);
            // Ajoute le solver choisi comme courant et met le bouton en Focus
            Button button = (Button)sender;
            if (button == segmentButton)
            {
                ButtonLockView(heuristicOneButton);
                ButtonLockView(heuristicTwoButton);
                ButtonLockView(heuristicThreeButton);
                _solver = new Segments(_selectedHeuristic);
                heuriLock = true;
            }
            else if (button == AstarUniButton)
            {
                if (heuriLock == true)
                {
                    UnlockButtonView(heuristicOneButton);
                    UnlockButtonView(heuristicTwoButton);
                    UnlockButtonView(heuristicThreeButton);
                    heuriLock = false;
                }
                _solver = new AstarUni(_selectedHeuristic);
            }
            else if (button == IDAStarButton)
            {
                if (heuriLock == true)
                {
                    UnlockButtonView(heuristicOneButton);
                    UnlockButtonView(heuristicTwoButton);
                    UnlockButtonView(heuristicThreeButton);
                    heuriLock = false;
                }
                _solver = new IDAstar(_selectedHeuristic);
            }
            ButtonSetFocus(button);
        }
        
        // Fonciton raise par l'event On_Click des cellButton
        private void CellButton_Click(object sender, EventArgs e)
        {
            // Permet de lier l'UI et le backend pour maintenir le Taquin cohérent
            CellButton cellButton = (CellButton)sender;
            Cell cell = cellButton.Cell;
            if (cell.IsMovable()) taquin.Move(cell);
            UpdateBoard();
        }

        // Fonction qui lance la résolution du Taquin courant
        public void SolveButton_Click(object sender, EventArgs e)
        {
            // On crée un EvaluableBoard a partir de l'état courant du Taquin
            EvaluableBoard board = new EvaluableBoard(taquin.Board);
            // On envoie le board et le solver courant a un resultForm que l'on affiche
            if (_solver.GetType() == typeof(AstarUni)) _solver = new AstarUni(_selectedHeuristic);
            else if (_solver.GetType() == typeof(IDAstar)) _solver = new IDAstar(_selectedHeuristic);
            else _solver = new Segments(_selectedHeuristic);
            _resultForm = new ResultForm(_solver, board);
            _resultForm.Show();
        }

        // Affiche le form de chargement d'exemple
        private void LoadButton_Click(object sender, EventArgs e)
        {
            _loadForm.Show();
        }

        // Fonction trigger lorsque l'envent Close du formulaire de chargement est raise
        private void LoadForm_Close(object sender, EventArgs e)
        {
            // On créer le path pour charger un example
            _fileName = _loadForm.SelectedFile;
            _loadForm = new LoadForm();
            _loadForm.FormClosing += (s, evt) => LoadForm_Close(s, evt);
            // On init le Taquin grace au fichier
            taquin = new Taquin(_fileName);
            _selectedSize = taquin.Size;
            // On paramètre l'interface en conséquence
            SetBoard(); 
            if (_selectedSize == 3)
            {
                ButtonSetFocus(sizeButton3);
                ButtonUnsetFocus(sizeButton5);
                if (solverLock == true)
                {
                    UnlockButtonView(AstarUniButton);
                    UnlockButtonView(IDAStarButton);
                    solverLock = false;
                }
                if (heuriLock == true && _solver.GetType() != typeof(Segments))
                {
                    UnlockButtonView(heuristicOneButton);
                    UnlockButtonView(heuristicTwoButton);
                    UnlockButtonView(heuristicThreeButton);
                    heuriLock = false;
                }
            }
            else if (_selectedSize == 5)
            {
                ButtonSetFocus(sizeButton5);
                ButtonUnsetFocus(sizeButton3);
                if(solverLock == false)
                {
                    ButtonLockView(AstarUniButton);
                    ButtonLockView(IDAStarButton);
                    solverLock = true;
                    _solver = new Segments(_selectedHeuristic);
                    ButtonSetFocus(segmentButton);
                }
                if(heuriLock == false)
                {
                    ButtonLockView(heuristicOneButton);
                    ButtonLockView(heuristicTwoButton);
                    ButtonLockView(heuristicThreeButton);
                    heuriLock = true;
                }

            }
        }

        // Fonction permettant de mélanger le Taquin
        private void ShuffleButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                foreach (Cell cell in taquin)
                {
                    if (cell.IsMovable())
                    {
                        if (r.Next(2) == 1) taquin.Move(cell);
                    };
                }
                // On répercute les effet du mélange sur le board
                taquin.Board.ClearBoardStatus();
                taquin.Board.CalculatePossibleMoves();
            }
            // On affiche le résultat à l'écran
            UpdateBoard();
        }
        #endregion
    }
}
