using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    public class Segments : AstarUni
    {
        int Size { get; set; }

        public Segments(IHeuristic heuristic): base(heuristic){}

        public override List<Board> Solve(EvaluableBoard board)
        {
            // Innitialisation Step
            Size = board.Board.Structure.GetLength(0);
            _openSet.Add(board);
            // Solve loop
            for(int rank = 0; rank <= Size*Size-2; rank++)
            {
                _destination = new EvaluableBoard(CreateStep(Size, rank));
                while(_openSet.Count > 0)
                {
                    _currentBoard = _openSet[0];
                    if (_currentBoard.Equals(_destination))
                    {
                        Console.WriteLine("=============== Step {0} ==============", rank);
                        Console.WriteLine(_destination.Board);
                        Console.WriteLine("======================================", rank);
                        Console.WriteLine(_currentBoard.Board);
                        if (rank == 22)
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
                            // Evaluation d'une heuristique humaine
                            int thisHumanHeuri = Eval(testBoard, rank);
                            testBoard.Score = testBoard.Cost + thisHumanHeuri;//Heuristic.EvaluateBoard(testBoard.Board, _destination.Board);
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

        private int Eval(EvaluableBoard board, int step)
        {
            int score = 0;
            int optI, optJ, currI, currJ;
            // Recherche de la position optimale
            Functions.pos2coord(out optI, out optJ, step, Size);
            // Recherche de la position courante
            board.Board.FindCellByValue(out currI, out currJ, Convert.ToString(step));
            // Prise ne compte de la distance case destination
            score += 3 * (Math.Abs(optI - currI) + Math.Abs(optJ - currJ));
            int hole1I, hole1J, hole2I, hole2J;
            board.Board.FindEmptyOne(out hole1I, out hole1J);
            board.Board.FindEmptyTwo(out hole2I, out hole2J);
            // Prise en compte de la distance trou case à placer
            score += 2 * ( Math.Abs(hole1I - currI) + Math.Abs(hole1J - currJ));
            score += 2 * ( Math.Abs(hole2I - currI) + Math.Abs(hole2J - currJ));
            // Prise en compte de la distance trou destination
            int distH1 = Math.Abs(optI - hole1I) + Math.Abs(optJ - hole1J);
            int distH2 = Math.Abs(optI - hole2I) + Math.Abs(optJ - hole2J);

            score += Math.Min(distH1, distH2);
            return score;
        }

        private Board CreateStep(int size, int rank)
        {
            Board board;
            List<Cell> structure = new List<Cell>();
            for (int i = 0; i <= rank; i++)
            {
                Cell cell = new Cell(i);
                structure.Add(cell);
            }
            for (int i = rank; i < (size * size - 2)-1; i++)
            { 
                Cell empty = new Cell(-1);
                structure.Add(empty);
            }
            for (int i = 0; i < 2; i++)
            {
                Cell hole = new Cell("-");
                structure.Add(hole);
            }
            board = new Board(structure.ToArray());
            return board;
        }
    }
}
