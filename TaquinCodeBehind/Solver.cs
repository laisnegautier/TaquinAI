using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    public abstract class Solver
    {
        #region Attributes
        protected List<EvaluableBoard> _openSet = new List<EvaluableBoard>();
        protected List<EvaluableBoard> _closedSet = new List<EvaluableBoard>();
        #endregion

        #region Properties
        public IHeuristic Heuristic { get; set; }
        #endregion

        #region AbstractsToOverride
        protected abstract int TotalScore(EvaluableBoard board);
        public abstract List<Board> Solve(EvaluableBoard board);
        #endregion

        #region Methods
        public static EvaluableBoard CopyBoard(EvaluableBoard board)
        {
            EvaluableBoard result = new EvaluableBoard(board.Score);
            Cell[,] structure = new Cell[board.Size,board.Size];
            foreach(Cell cell in board)
            {
                Cell newCell = new Cell(cell.Value);
                int posI, posJ;
                board.Board.FindCellByValue(out posI,out posJ, cell.Value);
                structure[posI, posJ] = newCell;
            }
            // Might me proper
            Cell emptyOne = new Cell("-");
            Cell emptyTwo = new Cell("-");
            int e1i, e1j, e2i, e2j;
            board.Board.FindEmptyOne(out e1i, out e1j);
            board.Board.FindEmptyTwo(out e2i, out e2j);
            structure[e1i, e1j] = emptyOne;
            structure[e2i, e2j] = emptyTwo;
            // Till there is not really needed
            result.Board = new Board(structure);
            return result;
        }

        // Might be transform as static
        public static List<EvaluableBoard> CreateChild(EvaluableBoard board, int cost)
        {
            List<EvaluableBoard> neighbours = new List<EvaluableBoard>();
            
            foreach(Cell cell in board)
            {
                if (cell.IsMovable())
                {
                    foreach(Cell.Moves move in cell.AvailableMoves)
                    {
                        EvaluableBoard neighbour = CopyBoard(board);
                        neighbour.Score += cost;
                        neighbour.Board.Move(cell, move);
                        neighbour.Previous = board;
                        neighbours.Add(neighbour);
                    }
                }
            }
            return neighbours;
        }

        public bool FindPast(EvaluableBoard board)
        {
            bool result = false;
            foreach(EvaluableBoard oldBoard in _closedSet)
                if (oldBoard.Equals(board)) result = true;
            return result;
        }

        public bool FindBest(EvaluableBoard board)
        {
            bool result = false;
            foreach (EvaluableBoard currentBoard in _openSet)
                if (board.Equals(currentBoard) && currentBoard.Score < board.Score) result = true;
            return result;
        }
        #endregion
    }
}
