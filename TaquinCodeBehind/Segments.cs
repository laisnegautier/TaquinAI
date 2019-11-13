using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    public class Segments : AstarUni
    {
        int Step { get; }
        int Size { get; set; }
        List<Board> Targets { get; set; }

        public Segments(IHeuristic heuristic, List<Board> targets): base(heuristic)
        {
            Size = targets[0].Structure.GetLength(0);
            Targets = targets;
            CreateTarget(Size);
            Targets.Add(_destination.Board);
            Step = targets.Count();
        }

        public override List<Board> Solve(EvaluableBoard board)
        {
            // Innitialisation Step
            _openSet.Add(board);
            int iteration = 0;
            foreach(Board target in Targets)
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
    }
}
