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
        #region Attributes
        private int _selectedSize;
        private IHeuristic _selectedHeuristic;
        private Thread _solverThread;
        private ResultForm _resultForm;
        private Taquin taquin;
        #endregion

        #region Properties
        
        #endregion

        #region Construct
        public MainForm()
        {
            InitializeComponent();
            // Initialisation des paramètres internes du Form
            _solverThread = new Thread(new ThreadStart(Solve)); // Le resolution Thread launches 
            _resultForm = new ResultForm();
            _selectedSize = 3;
            ButtonSetFocus(sizeButton3);
            taquin = new Taquin(_selectedSize);
            Debug.WriteLine(taquin);
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
                pos2coord(out i, out j, id);
                cellBtn.Cell = taquin.GetCell(i, j);
                cellBtn.Text = cellBtn.Cell.Value; // Add event on Cell changed
            }
        }

        public int coord2pos(int i, int j)
        {
            return (j * _selectedSize + i);
        }

        public void pos2coord(out int i, out int j, int rank)
        {
            j = rank % _selectedSize;
            i = rank / _selectedSize;
        }
        //==========================BUTTON===CLOSE=================================
        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (_solverThread.IsAlive) _solverThread.Interrupt();
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
            if ((button == sizeButton3 && _selectedSize == 3) || (button == sizeButton5 && _selectedSize == 5)) ;
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

        
        /// <summary>
        /// Fonction used to Solve the Taquin board using the selected Heuristic
        /// </summary>
        public void Solve()
        {
        }
        
    }
}
