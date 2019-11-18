using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaquinCodeBehind;
using System.Diagnostics;

namespace TaquinUI
{
    public partial class ResultForm : Form
    {
        private List<Board> States { get; set; }
        private Solver Solver { get; }
        private EvaluableBoard _board;
        BackgroundWorker _solverThread;
        Stopwatch _watch = new Stopwatch();

        int _index = 0;
        int _size;

        public ResultForm()
        {
            InitializeComponent();
        }

        /*public ResultForm(List<Board> boards)
        {
            InitializeComponent();
            States = boards;
            nbMovesLabel.Text += " " + (boards.Count - 1) + " coups.";
            SetBoard();
        }*/

        public ResultForm(Solver solver, EvaluableBoard board)
        {
            InitializeComponent();
            // Hiding stuff
            leftButton.Hide();
            rightButton.Hide();
            nbMovesLabel.Hide();

            Solver = solver;
            _board = board;
            _solverThread = new BackgroundWorker();
            // Assigning the DoWork Method
            _solverThread.DoWork += new DoWorkEventHandler(SolverThreadDoWork);
            _solverThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(SolverThreadWorkDone);
            
            _solverThread.WorkerSupportsCancellation = true;

            _solverThread.RunWorkerAsync();
        }

        private void SolverThreadDoWork(object sender, DoWorkEventArgs e)
        {
            _watch = Stopwatch.StartNew();
            if (_solverThread.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            States = Solver.Solve(_board);
        }

        private void SolverThreadWorkDone(object sender, RunWorkerCompletedEventArgs e)
        {
            _watch.Stop();
            // Vérification de l'arrêt du Thread
            if (e.Cancelled)
            {
                timeLabel.Text = "Ce solver à été imterrompu ! L'opération à éxcedé la minute.";
            }
            // Letting stuff show
            leftButton.Show();
            rightButton.Show();
            nbMovesLabel.Show();
            // Reversing solution
            States.Reverse();
            string solverName = "";
            string heuriName = "";
            // Finding Solver Name
            if (typeof(AstarUni) == Solver.GetType()) solverName = "A* Unidirectionel";
            else if (Solver.GetType() == typeof(Segments)) solverName = "la méthode humaine";
            else solverName = "IDA*";
            // Finding Heuristic Used
            if (Solver.Heuristic.GetType() == typeof(PLC)) heuriName = "P&LC";
            else if (Solver.Heuristic.GetType() == typeof(PLCC)) heuriName = "P&Lc&C";
            else heuriName = "de Manhattan";
            // Finding computeTime
            var elapsedMs = _watch.ElapsedMilliseconds;
            nbMovesLabel.Text += " " + (States.Count - 1) + " coups grace à " + solverName +" et à l'heuristique " + heuriName + " en " + elapsedMs + " Ms";
            SetBoard();
        }

        private void SetSize()
        {
            _size = States[_index].Structure.GetLength(0);
        }

        public void SetBoard()
        {
            SetSize();
            int line = -1;
            int column = 0;
            boardPanel.Controls.Clear();
            //Debug.WriteLine(boardPanel.Left + " - " + boardPanel.Top);
            foreach (Cell cell in States[_index])
            {
                if (column % _size == 0) line++;
                int size = boardPanel.Width / _size;
                CellButton currentCellButton = new CellButton(cell, size);

                currentCellButton.Left = ((column % _size) * size);
                //Console.Write(currentCellButton.Left + " - ");
                currentCellButton.Top = (line * size);
                //Console.WriteLine(currentCellButton.Top);
                boardPanel.Controls.Add(currentCellButton);
                column++;
            }
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (_solverThread.IsBusy)
            {
                _solverThread.CancelAsync();
            }
            Close();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
