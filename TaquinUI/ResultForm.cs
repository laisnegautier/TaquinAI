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

namespace TaquinUI
{
    public partial class ResultForm : Form
    {
        public List<Board> States { get; set; }
        int _index = 0;
        int _size;

        public ResultForm()
        {
            InitializeComponent();
        }

        public ResultForm(List<Board> boards)
        {
            InitializeComponent();
            States = boards;
            nbMovesLabel.Text += " " + (boards.Count - 1) + " coups.";
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
            Hide();
        }
    }
}
