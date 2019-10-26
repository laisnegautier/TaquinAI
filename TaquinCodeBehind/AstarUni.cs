using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    public class AstarUni : Solver
    {
        EvaluableBoard _currentBoard;
        EvaluableBoard _destination;

        public AstarUni(IHeuristic heuristic)
        {
            Heuristic = heuristic;
        }

        public void CreateTarget(int size)
        {
            Cell[] list = new Cell[size * size];
            for (int i = 0; i < size * size - 2; i++)
            {
                Cell cell = new Cell(i);
                list[i] = cell;
            }
            for(int j = 0; j < 2; j++)
            {
                Cell cell = new Cell("-");
                list[list.Length - 1 - j] = cell;
            }
            Board board = new Board(list);
            _destination = new EvaluableBoard(board);
        }

        public List<Board> Unpile(EvaluableBoard board)
        {
            throw new NotImplementedException();
        }

        public override List<Board> Solve(EvaluableBoard board)
        {
            int size = board.Size;
            CreateTarget(size);
            _openSet.Add(board);
            List<Board> result = new List<Board>();
            while (_openSet.Count > 0)
            {
                _currentBoard = _openSet[0];
                Console.WriteLine(_currentBoard.Board + "\n");
                // Si on est arrivé, on arrête
                if (_currentBoard.Equals(_destination))
                {
                    result = Unpile(_currentBoard);
                    return result;
                }
                //Sinon on créer les voisins
                List<EvaluableBoard> holder = CreateChild(_currentBoard, 1);
                foreach(EvaluableBoard testBoard in holder)
                {
                    if (!FindPast(testBoard))
                    {
                        testBoard.Score += Heuristic.EvaluateBoard(testBoard.Board, _destination.Board);
                        if (!FindBest(testBoard))
                        {
                            _openSet.Add(testBoard);
                        }
                    }
                }
                _closedSet.Add(_currentBoard);
                _openSet.Remove(_currentBoard);
                _openSet = _openSet.OrderBy(b => b.Score).ToList();
                //foreach (EvaluableBoard b in _openSet) Console.Write(b.Board + " ");
            }
            return result;
        }

        protected override int TotalScore(EvaluableBoard board)
        {
            throw new NotImplementedException();
        }
    }
}
