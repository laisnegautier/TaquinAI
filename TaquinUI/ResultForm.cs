using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TaquinCodeBehind;
using System.Diagnostics;

namespace TaquinUI
{
    /// <summary>
    /// Fenêtre permettatn d'afficher le résultat d'une résolution
    /// </summary>
    public partial class ResultForm : Form
    {
        #region Attributes
        private EvaluableBoard _board;
        int _index = 0;
        int _size;
        // Gestion du temps et du parallele
        BackgroundWorker _solverThread;
        Stopwatch _watch;
        // Gestion du Drag
        private bool mouseDown;
        private Point lastLocation;
        #endregion

        #region Properties
        private List<Board> States { get; set; }
        private Solver Solver { get; }
        #endregion

        #region Construct
        public ResultForm()
        {
            InitializeComponent();
        }

        public ResultForm(Solver solver, EvaluableBoard board)
        {
            InitializeComponent();
            // Cacher les fonctionnalitée en attendant les résultats
            leftButton.Hide();
            rightButton.Hide();
            nbMovesLabel.Hide();
            openLabel.Hide();
            label2.Hide();
            // Attribution des utilitaires
            Solver = solver;
            _board = board;
            _solverThread = new BackgroundWorker();
            // Assignation des event du thread d'arrière plan
            _solverThread.DoWork += new DoWorkEventHandler(SolverThreadDoWork);
            _solverThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(SolverThreadWorkDone);
            // Launch du backGroundWorker
            _solverThread.RunWorkerAsync();
            _solverThread.WorkerReportsProgress = true;
            _solverThread.WorkerSupportsCancellation = true;
        }
        #endregion

        #region BackGroundWorker
        // Fonction principale du thread d'arrière plan
        private void SolverThreadDoWork(object sender, DoWorkEventArgs e)
        {
            // Départ du compteur et lancement de la résolution du Taquin
            _watch = Stopwatch.StartNew();
            States = Solver.Solve(_board);
        }

        // Fonction trigger lors de l'arrêt du Thread d'arrière plan
        private void SolverThreadWorkDone(object sender, RunWorkerCompletedEventArgs e)
        {
            // On stop le décompte du temps
            _watch.Stop();
            States.Reverse();
            // Showing stuff back
            leftButton.Show();
            rightButton.Show();
            nbMovesLabel.Show();
            statusLabel.Hide();
            label2.Show();
            openLabel.Show();
            string solverName = "";
            string heuriName = "";
            if(Solver.GetType() == typeof(AstarUni) ||Solver.GetType() == typeof(IDAstar))
            {
                // Finding Solver Name
                if (typeof(AstarUni) == Solver.GetType()) solverName = "A* Unidirectionel";
                else solverName = "IDA*";
                // Finding Heuristic Used
                if (Solver.Heuristic.GetType() == typeof(PLC)) heuriName = "P&LC";
                else if (Solver.Heuristic.GetType() == typeof(PLCC)) heuriName = "P&LC&C";
                else heuriName = "de Manhattan";

                nbMovesLabel.Text += " " + (States.Count - 1) + " coups grace à " + solverName + " et à l'heuristique " + heuriName;
            }
            else
            {
                nbMovesLabel.Text += " " + (States.Count - 1) + " coups grace à la  méthode humaine et à une heuristique spécifique";
            }
            // Finding out time
            var elapsedMs = _watch.ElapsedMilliseconds;
            nbMovesLabel.Text += " en " + elapsedMs + " Ms";
            // Affichage du nombre de noeuds
            openLabel.Text += " " + Solver.openCount;
            label2.Text += " " + Solver.closedCount;
            SetBoard();
        }
        #endregion

        #region UIMethod_Misceallanous
        // Fonction permettant de fermer la fenêtre
        private void button1_Click(object sender, EventArgs e)
        {
            if (_solverThread.IsBusy)
            {
                _solverThread.CancelAsync();
            }
            Close();
        }

        // Fonction permettant de minimiser la fenêtre
        private void minimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Fonctions permettant le Drag du Form
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

        #region UIMethod_Fonctionnalies
        // Fonction permettant d'établir la disposition du board dans la fenêtre
        public void SetBoard()
        {
            // Calcul de la taille adaptée
            SetSize();
            int line = -1;
            int column = 0;
            boardPanel.Controls.Clear();
            // Pour chacun des cellule de l'index actuel
            foreach (Cell cell in States[_index])
            {
                if (column % _size == 0) line++;
                int size = boardPanel.Width / _size;
                // On crée des cellButton par practcité cependant on ne leur assigne pas de gestionnaire d'événement
                CellButton currentCellButton = new CellButton(cell, size);
                currentCellButton.Left = ((column % _size) * size);
                currentCellButton.Top = (line * size);
                boardPanel.Controls.Add(currentCellButton);
                column++;
            }
        }

        // Focntion gérant le taille du Taquin affiché
        private void SetSize()
        {
            _size = States[_index].Structure.GetLength(0);
        }
        #endregion

        #region UIMethod_Interactions
        // Fonctions permettant de modifier l'index tu tableau à afficher
        private void RightButton_Click(object sender, EventArgs e)
        {
            _index = (_index + 1) % States.Count;
            SetBoard();
        }

        private void LeftButton_Click(object sender, EventArgs e)
        {
            _index = ((_index - 1) + States.Count) % States.Count;
            SetBoard();
        }
        #endregion
    }
}
