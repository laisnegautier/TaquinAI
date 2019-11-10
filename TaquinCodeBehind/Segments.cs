using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    public class Segments : Solver
    {
        EvaluableBoard _currentBoard;
        EvaluableBoard _destination;
        public int Step { get; }
        public int Size { get; set; }

        public Segments(int step = 5)
        {
            Step = step;
        }

        public void CreateTarget(int size)
        {
            Cell[] list = new Cell[size * size];
            for (int i = 0; i < size * size - 2; i++)
            {
                Cell cell = new Cell(i);
                list[i] = cell;
            }
            for (int j = 0; j < 2; j++)
            {
                Cell cell = new Cell("-");
                list[list.Length - 1 - j] = cell;
            }
            Board board = new Board(list);
            _destination = new EvaluableBoard(board);
        }

        public int DistanceToStep(Board board, int rank)
        {
            int cost = 0;
            for (int i = 0; i < rank; i++)
                for (int j = 0; j < rank; j++)
                {
                    int optValue = Functions.coord2pos(j, i, Size);
                    int currI, currJ;
                    board.FindCellByValue(out currI, out currJ, optValue.ToString());
                    cost += Math.Abs(i - currI) + Math.Abs(j - currJ);
                }
            return cost;
        }

        public int EvaluateBoard(Board board, int rank)
        {
            IHeuristic heuri = new Manhattan();
            return heuri.EvaluateBoard(board, _destination.Board);
            int cost = 0;
            for(int test = 0; test < Size*Size-2; test++)
            {
                int i, j, opti, optj;
                Functions.pos2coord(out opti,out optj, test, Size);
                board.FindCellByValue(out i, out j, test.ToString());
                cost += Math.Abs(i - opti) + Math.Abs(j - optj);
            }
            return cost;
            return (int)Math.Round(cost*1.5);
        }

        public override List<Board> Solve(EvaluableBoard board)
        {
            Size = board.Size;
            CreateTarget(Size);
            _openSet.Add(board);
            int rank = 0;
            while(rank < Step)
            {
                // On applique A* entre deux état proches 
                while(_openSet.Count > 0)
                {
                    _currentBoard = _openSet[0];
                    //Vérification de fin d'une étape ou de la résolution
                    if(DistanceToStep(_currentBoard.Board, rank + 1) == 0)
                    {
                        Console.WriteLine(new String('=',20));
                        Console.WriteLine("RANK = " + rank);
                        Console.WriteLine("Solver Board for step{0} is:", rank);
                        Console.WriteLine(_currentBoard.Board);
                        if (_currentBoard.Equals(_destination))
                        {
                            List<Board> result;
                            result = Unpile(_currentBoard);
                            return result;
                        }
                        else
                        {
                            // Track count of sum of open and closed knots
                            rank++;
                            //_currentDestination = _targets[rank];
                            _openSet = new List<EvaluableBoard>();
                            _closedSet = new List<EvaluableBoard>();
                            _openSet.Add(_currentBoard);
                            break;
                        }
                    }
                    //================================================================

                    List<EvaluableBoard> holder = CreateChild(_currentBoard);
                    foreach(EvaluableBoard testBoard in holder)
                    {
                        if(FindPast(testBoard) || FindBest(testBoard)) { }
                        else
                        {
                            testBoard.Cost += 1;
                            //testBoard.Score = testBoard.Cost += EvaluateBoard(testBoard.Board, rank + 1);
                            testBoard.Score = testBoard.Cost += DistanceToStep(testBoard.Board, rank + 1);
                            _openSet.Add(testBoard);
                        }
                    }
                    _closedSet.Add(_currentBoard);
                    _openSet.Remove(_currentBoard);
                    _openSet = _openSet.OrderBy(b => b.Score).ToList();
                }   
            }
            return null;
        }
    }
}
