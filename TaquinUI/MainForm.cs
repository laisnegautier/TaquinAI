using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaquinCodeBehind;

namespace TaquinUI
{
    public partial class MainForm : Form
    {
        Random r = new Random();
        #region Attributes
        // Taquin
        private int _selectedSize;
        private Taquin taquin;
        // Solver
        private IHeuristic _selectedHeuristic;
        private Solver _solver;
        private Thread _solverThread;
        // Child Forms
        private ResultForm _resultForm;
        private LoadForm _loadForm;
        private string _fileName;

        private bool mouseDown;
        private Point lastLocation;
        #endregion

        #region Properties

        #endregion

        #region Construct
        public MainForm()
        {
            InitializeComponent();
            // Initialisation des paramètres internes du Form
            // Le resolution Thread launches 
            _resultForm = new ResultForm();
            _fileName = "";
            _loadForm = new LoadForm();
            _loadForm.FormClosing += (s, e) => LoadForm_Close(s, e);
            // Define Size
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

        #region UIMethods
        //==========================SETTING==BOARD=================================
        private void SetBoard()
        {
            int line = -1;
            int column = 0;
            boardPanel.Controls.Clear();
            //Debug.WriteLine(boardPanel.Left + " - " + boardPanel.Top);
            foreach (Cell cell in taquin)
            {
                if (column % _selectedSize == 0) line++;
                int size = boardPanel.Width / _selectedSize;
                CellButton currentCellButton = new CellButton(cell,size);

                currentCellButton.MouseEnter += (s, e) => Button_MouseEnter(s, e);
                currentCellButton.MouseLeave += (s, e) => Button_MouseLeave(s, e);
                currentCellButton.Click += (s, e) => CellButton_Click(s, e);

                currentCellButton.Left = ((column % _selectedSize) * size);
                //Console.Write(currentCellButton.Left + " - ");
                currentCellButton.Top = (line * size);
                //Console.WriteLine(currentCellButton.Top);
                boardPanel.Controls.Add(currentCellButton);
                column++;
            }
        }

        private void UpdateBoard()
        {
            foreach(CellButton cellBtn in boardPanel.Controls)
            {
                // Mettre à jour les val d'une Cell lors d'un mvt !
                int id = cellBtn.TabIndex;
                int i, j;
                Functions.pos2coord(out i, out j, id, _selectedSize);
                cellBtn.Cell = taquin.GetCell(i, j);
                cellBtn.Text = cellBtn.Cell.Value; // Add event on Cell changed
            }
        }
        //==========================BUTTON===CLOSE=================================
        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (_solverThread != null && _solverThread.IsAlive) _solverThread.Interrupt();
            if (_loadForm.IsAccessible) _loadForm.Close();
            if (_resultForm.IsAccessible) _resultForm.Close();
            Close();
        }
        //=============================SIZE===3X3===================================
        private void SizeButton3_Click(object sender, EventArgs e)
        {
            if(_selectedSize != 3)
            {
                ButtonSetFocus(sizeButton3);
                _selectedSize = 3;
                taquin = new Taquin(3);
                SetBoard();
                ButtonUnsetFocus(sizeButton5);
            }
        }
        //=============================SIZE===5X5===================================
        private void SizeButton5_Click(object sender, EventArgs e)
        {
            if (_selectedSize != 5)
            {
                ButtonSetFocus(sizeButton5);
                _selectedSize = 5;
                taquin = new Taquin(5);
                SetBoard();
                ButtonUnsetFocus(sizeButton3);
            }
        }
        //=============================HEURISTICS===================================
        private void HeuristicButton_Click(object sender, EventArgs e)
        {
            // Unset last selected button focus
            if (_selectedHeuristic.GetType() == typeof(Manhattan)) ButtonUnsetFocus(heuristicThreeButton);
            else if (_selectedHeuristic.GetType() == typeof(PLC)) ButtonUnsetFocus(heuristicOneButton);
            else ButtonUnsetFocus(heuristicTwoButton);
            // Action & Focus
            Button button = (Button)sender;
            if (button == heuristicOneButton) _selectedHeuristic = new PLC();
            else if (button == heuristicTwoButton) _selectedHeuristic = new PLCC();
            else _selectedHeuristic = new Manhattan();
            ButtonSetFocus(button);
        }
        
        private void SolverButton_CLick(object sender, EventArgs e)
        {
            // Unset last selected button focus
            if (_solver.GetType() == typeof(Segments)) ButtonUnsetFocus(segmentButton);
            else if (_solver.GetType() == typeof(AstarUni)) ButtonUnsetFocus(AstarUniButton);
            else if (_solver.GetType() == typeof(IDAstar)) ButtonUnsetFocus(IDAStarButton);
            // Action & Focus
            Button button = (Button)sender;
            if (button == segmentButton) _solver = new Segments(_selectedHeuristic);
            else if (button == AstarUniButton) _solver = new AstarUni(_selectedHeuristic);
            else if (button == IDAStarButton) _solver = new IDAstar(_selectedHeuristic);
            ButtonSetFocus(button);
        }

        private void CellButton_Click(object sender, EventArgs e)
        {
            CellButton cellButton = (CellButton)sender;
            Cell cell = cellButton.Cell;
            if (cell.IsMovable()) taquin.Move(cell);
            UpdateBoard();
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ButtonSetFocus(button);
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if ((button == sizeButton3 && _selectedSize == 3) || (button == sizeButton5 && _selectedSize == 5)) ; // Test Size Selected
            else if ((button == heuristicOneButton && _selectedHeuristic.GetType() == typeof(PLC))
                   || (button == heuristicTwoButton && _selectedHeuristic.GetType() == typeof(PLCC))
                   || (button == heuristicThreeButton && _selectedHeuristic.GetType() == typeof(Manhattan))) ; // Test Heuristic Selected
            else if ((button == AstarUniButton && _solver.GetType() == typeof(AstarUni))
                  || (button == segmentButton && _solver.GetType() == typeof(Segments))
                  || (button == IDAStarButton && _solver.GetType() == typeof(IDAstar))) ; // Test Solver Selected
            else ButtonUnsetFocus(button);
        }

        private void ButtonSetFocus(Button button)
        {
            button.BackColor = Color.FromArgb(255, 143, 143);
            button.ForeColor = Color.FromArgb(252, 252, 250);
        }

        private void ButtonUnsetFocus(Button button)
        {
            button.BackColor = Color.FromArgb(231, 217, 218);
            button.ForeColor = Color.FromArgb(66, 94, 41);
        }
        #endregion

        public void SolveButton_Click(object sender, EventArgs e)
        {
            EvaluableBoard board = new EvaluableBoard(taquin.Board);
            _resultForm = new ResultForm(_solver, board);
            _resultForm.Show();
        }
        
        private void LoadButton_Click(object sender, EventArgs e)
        {
            _loadForm.Show();
        }

        private void LoadForm_Close(object sender, EventArgs e)
        {
            _fileName = _loadForm.SelectedFile;
            _loadForm = new LoadForm();
            _loadForm.FormClosing += (s, evt) => LoadForm_Close(s, evt);
            taquin = new Taquin(_fileName);
            _selectedSize = taquin.Size;
            SetBoard();
            if (_selectedSize == 3) { ButtonSetFocus(sizeButton3); ButtonUnsetFocus(sizeButton5); }
            else if (_selectedSize == 5) { ButtonSetFocus(sizeButton5); ButtonUnsetFocus(sizeButton3); }
        }

        private void ShuffleButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                foreach (Cell cell in taquin)
                {
                    if (cell.IsMovable())
                    {
                        if(r.Next(2) == 1) taquin.Move(cell);
                    };
                }
                taquin.Board.ClearBoardStatus();
                taquin.Board.CalculatePossibleMoves();
            }
            UpdateBoard();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

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
    }
}
