using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    public class Taquin : IEnumerable<Cell>
    {
        #region Attributes
        private Board _board;
        private readonly int _size;
        #endregion

        public int Size { get { return _size; } }
        public Board Board { get { return _board; } }
        #region Construct
        public Taquin(int size)
        {
            _size = size;
            Populate(size);
            Shuffle();
        }

        public Taquin(string fileName)
        {
            
            string[] lines = File.ReadAllLines(fileName);
            _size = lines[0].Length < 6 ? 3 : 5;
            Cell[,] finalBoard = new Cell[_size, _size];
            int currentLineCount = 0;
            foreach(string l in lines)
            {
                int currentColumn = 0;
                string[] values = l.Split(',');
                foreach(string value in values)
                {
                    Cell cell = new Cell(values[currentColumn]);
                    finalBoard[currentLineCount, currentColumn % _size] = cell;
                    currentColumn++;
                }
                currentLineCount++;
            }
            _board = new Board(finalBoard);
            _board.CalculatePossibleMoves();
        }
        #endregion

        #region Methods
        public void Populate(int size)
        {
           // Can be factorized
            Cell[] cells = new Cell[size*size];
            for(int i = 0; i < (size*size)-2; i++)
            {
                Cell cell = new Cell(i);
                cells[i] = cell;
            }
            cells[cells.Length - 2] = new Cell();
            cells[cells.Length - 1] = new Cell();
            _board = new Board(cells);
        }

        public void Shuffle()
        {
            if(_board != null)
            {
                _board.CalculatePossibleMoves();
            }
        }

        public Cell GetCell(int i, int j)
        {
            return _board.Structure[i, j];
        }

        public void Move(Cell cell)
        {
            if(cell.IsMovable())
            _board.Move(cell, cell.AvailableMoves[0]);
        }

        public override string ToString()
        {
            return _board.ToString();
        }
        #endregion

        #region IEnumerable
        public IEnumerator<Cell> GetEnumerator()
        {
            int line = -1;
            for(int i = 0; i < _size*_size; i++)
            {
                if (i % _size == 0) line++;
                yield return _board.Structure[line,i % _size];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
