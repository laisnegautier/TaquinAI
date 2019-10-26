using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    public class Board : IEnumerable<Cell>
    {
        public enum Neighbours { Up, Down, Left, Right }
        #region Attributes
        private int _size;
        #endregion

        #region Properties
        public Cell[,] Structure;
        #endregion

        #region Construct
        public Board(int size)
        {
            _size = size;
            Structure = new Cell[_size, _size];
        }

        public Board(Cell[,] board)
        {
            Structure = board;
            _size = Structure.GetLength(0);
        }

        public Board(Cell[] cells)
        {
            if (cells.Length % 3 == 0) _size = 3;
            if (cells.Length % 5 == 0) _size = 5;
            Structure = new Cell[_size, _size];
            int line = -1; // Modulo Hack
            for(int i = 0; i < _size*_size; i++)
            {
                if (i % _size == 0)
                    line++;
                Structure[line, i % _size] = cells[i];
            }
        }
        #endregion

        #region Methods
        public void FindEmptyOne(out int i, out int j)
        {
            FindCellByValue(out i, out j, "-");
        }

        public void FindEmptyTwo(out int i, out int j)
        {
            i = 0; j = 0;
            for (int y = _size - 1; y >= 0; y--)
                for (int x = _size - 1; x >= 0; x--)
                {
                    if (Structure[y, x].Value == "-")
                    {
                        i = y; j = x;
                        break;
                    }
                }
        }

        public void FindCellByValue(out int i, out int j, string value)
        {
            i = 0; j = 0;
            for (int y = 0; y < _size; y++)
                for (int x = 0; x < _size; x++)
                {
                    if (Structure[y, x].Value == value)
                    {
                        i = y; j = x;
                        break;
                    }
                }
        }

        public void ClearBoardStatus()
        {
            foreach (Cell cell in Structure) cell.ClearMoves();
        }

        public void CalculatePossibleMoves()
        {
            foreach(Cell cell in Structure)
            {
                if(cell.Value != "-")
                { 
                    List<Neighbours> neighbours = EvaluateNeighbours(cell);
                    foreach (Neighbours n in neighbours)
                        switch (n)
                        {
                            case Neighbours.Up: cell.SetMoves(Cell.Moves.Up);  break;
                            case Neighbours.Down: cell.SetMoves(Cell.Moves.Down); break;
                            case Neighbours.Left: cell.SetMoves(Cell.Moves.Left); break;
                            case Neighbours.Right: cell.SetMoves(Cell.Moves.Right); break;
                        }
                    string moves = "";
                    foreach (Cell.Moves move in cell.AvailableMoves) moves += move + " - ";
                    Console.WriteLine(cell.Value + " moves: " + moves);
                }
            }
        }

        public List<Neighbours> EvaluateNeighbours(Cell cell)
        {
            List<Neighbours> neighbours = new List<Neighbours>();
            int i, j;
            FindCellByValue(out i, out j, cell.Value);
            if (i > 0) if(Structure[i - 1, j].Value == "-") neighbours.Add(Neighbours.Up);
            if (i < _size - 1) if (Structure[i + 1, j].Value == "-") neighbours.Add(Neighbours.Down);
            if (j > 0) if (Structure[i, j - 1].Value == "-") neighbours.Add(Neighbours.Left);
            if (j < _size - 1) if (Structure[i, j + 1].Value == "-") neighbours.Add(Neighbours.Right);
            return neighbours;
        }

        public void Move(Cell cell, Cell.Moves move )
        {
            if (cell.IsMovable())
            {
                Cell holder;
                int i, j;
                FindCellByValue(out i, out j, cell.Value);
                switch (move)
                {
                    case Cell.Moves.Up:
                        holder = Structure[i - 1, j];
                        Structure[i - 1, j] = cell;
                        Structure[i, j] = holder;
                        break;
                    case Cell.Moves.Down:
                        holder = Structure[i + 1, j];
                        Structure[i + 1, j] = cell;
                        Structure[i, j] = holder;
                        break;
                    case Cell.Moves.Left:
                        holder = Structure[i, j - 1];
                        Structure[i, j - 1] = cell;
                        Structure[i, j] = holder;
                        break;
                    case Cell.Moves.Right:
                        holder = Structure[i, j + 1];
                        Structure[i, j + 1] = cell;
                        Structure[i, j] = holder;
                        break;
                }
                ClearBoardStatus();
                CalculatePossibleMoves();
            }
        }

        public override string ToString()
        {
            string result = "";
            for(int i =0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    result += (Structure[i, j].ToString() + " ");
                }
                result += "\n";
            }
            return result;
        }
        #endregion

        #region IEnumerable
        public IEnumerator<Cell> GetEnumerator()
        {
            int line = -1;
            for (int i = 0; i < _size * _size; i++)
            {
                if (i % _size == 0) line++;
                yield return Structure[line, i % _size];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
