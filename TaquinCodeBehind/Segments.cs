using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    public class Segments : AstarUni
    {
        int Step { get; set; }
        int Size { get; set; }
        List<Board> Targets { get; set; }

        public Segments(IHeuristic heuristic): base(heuristic){}

        public override List<Board> Solve(EvaluableBoard board)
        {
            // Innitialisation Step
            Size = board.Board.Structure.GetLength(0);
            Targets = CreateTargets(Size);
            CreateTarget(Size);
            Targets.Add(_destination.Board);
            Step = Targets.Count();
            _openSet.Add(board);
            int iteration = 0;
            // Solve loop
            foreach (Board target in Targets)
            {
                iteration++;
                _destination = new EvaluableBoard(target);
                while(_openSet.Count > 0)
                {
                    _currentBoard = _openSet[0];
                    if (_currentBoard.Equals(_destination))
                    {
                        Console.WriteLine("===============Step {0}==============", iteration);
                        Console.WriteLine(_currentBoard.Board);
                        if (iteration == Step)
                        {
                            return Unpile(_currentBoard);
                        }
                        else
                        {
                            _openSet = new List<EvaluableBoard>();
                            _closedSet = new List<EvaluableBoard>();
                            _currentBoard.Cost = 0;
                            _currentBoard.Score = 0;
                            _openSet.Add(_currentBoard);
                            break;
                        }
                    }
                    List<EvaluableBoard> holder = CreateChild(_currentBoard);
                    foreach(EvaluableBoard testBoard in holder)
                    {
                        if(FindPast(testBoard) || FindBest(testBoard)) { }
                        else
                        {
                            testBoard.Cost += 1;
                            testBoard.Score = testBoard.Cost + Heuristic.EvaluateBoard(testBoard.Board, _destination.Board);
                            _openSet.Add(testBoard);
                        }
                    }
                    _closedSet.Add(_currentBoard);
                    _openSet.Remove(_currentBoard);
                    _openSet = _openSet.OrderBy(b => b.Score).ToList();
                }
                
            }
            return Unpile(board);
        }

        private List<Board> CreateTargets(int size)
        {
            List<Board> targets = new List<Board>();
            List<Cell> structure = new List<Cell>();
            for (int i = 0; i < size * size - 2; i++)
            {
                Cell cell = new Cell(i);
                structure.Add(cell);
            }
            for (int step = 0; step < size - 2; step++)
            {
                List<Cell> cells = structure.GetRange(0, (size * (step + 1)));
                for (int i = 0; i < (size * size - 2) - (size * (step + 1)); i++)
                {
                    Cell empty = new Cell(-1);
                    cells.Add(empty);
                }
                for (int i = 0; i < 2; i++)
                {
                    Cell hole = new Cell("-");
                    cells.Add(hole);
                }
                Board board = new Board(cells.ToArray());
                targets.Add(board);
            }
            return targets;
        }
    }
}
