﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaquinCodeBehind;
using System.Diagnostics;

namespace Parametrizer
{
    class ParametrizeSolver
    {
        int Size { get; set; }
        public List<int> Params { get; set; }
        List<EvaluableBoard> _openSet = new List<EvaluableBoard>();
        List<EvaluableBoard> _closedSet = new List<EvaluableBoard>();
        EvaluableBoard _destination;
        EvaluableBoard _currentBoard;
        public TimeSpan performance { get; set; }

        public ParametrizeSolver( int param1, int param2, int param3)//, int param4, int param5)
        {
            param1 = param1 < 0 ? 0 : param1;
            param2 = param2 < 0 ? 0 : param2;
            param3 = param3 < 0 ? 0 : param3;
            //param4 = param4 < 0 ? 0 : param4;
            //param5 = param5 < 0 ? 0 : param5;
            Params = new List<int>();
            Params.Add(param1);
            Params.Add(param2);
            Params.Add(param3);
            //Params.Add(param4);
            //Params.Add(param5);
        }

        Stopwatch UnderStep(int rank, Stopwatch chrono)
        {
            _destination = new EvaluableBoard(CreateStep(Size, rank));
            while (_openSet.Count > 0)
            {
                _currentBoard = _openSet[0];
                if (_currentBoard.Equals(_destination))
                {
                    //Console.WriteLine("=============== Step {0} ==============", rank);
                    //Console.WriteLine(_destination.Board);
                    //Console.WriteLine("======================================", rank);
                    //Console.WriteLine(_currentBoard.Board);
                    if (rank == Size * Size - 3)
                    {
                        chrono.Stop();
                        return chrono;
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
                List<EvaluableBoard> holder = CreateChild(_currentBoard, rank);
                foreach (EvaluableBoard testBoard in holder)
                {
                    if (FindPast(testBoard) || FindBest(testBoard)) { }
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
                if (chrono.Elapsed.Minutes >= 1)
                    break;
            }
            return chrono;
        }

        public Stopwatch Solve(EvaluableBoard board)
        {
            // Innitialisation Step
            _openSet = new List<EvaluableBoard>();
            _closedSet = new List<EvaluableBoard>();
            Size = board.Board.Structure.GetLength(0);
            _openSet.Add(board);
            // Solve loop
            Stopwatch chrono = new Stopwatch();
            chrono.Start();
            for (int rank = 0; rank < (Size * Size) - Size * 2; rank++)
            {
                chrono = UnderStep(rank, chrono);
                if (chrono.Elapsed.Minutes >= 1)
                    return chrono;

            }
            bool lineOne = true;
            int start = Size * Size - Size * 2;
            for (int rank = start; rank < start + Size; rank++)
            {
                // Première ou deuxième place dans la colonne ?
                chrono = UnderStep(rank, chrono);
                if (chrono.Elapsed.Minutes >= 1)
                    return chrono;

                int step = rank + Size;
                if (step < Size * Size - 2)
                {
                    chrono = UnderStep(step, chrono);
                    if (chrono.Elapsed.Minutes >= 1)
                        return chrono;
                }
            }
            chrono.Stop();
            return chrono;
        }

        private int Eval(EvaluableBoard board, int step)
        {
            int score = 0;
            int optI, optJ, currI, currJ;
            for (int i = 0; i < step; i++)
            {
                // Recherche de la position optimale
                Functions.pos2coord(out optI, out optJ, i, Size);
                // Recherche de la position courante
                board.Board.FindCellByValue(out currI, out currJ, Convert.ToString(i));
                // Prise ne compte de la distance case destination
                score += Math.Abs(i - step) * (Math.Abs(optI - currI) + Math.Abs(optJ - currJ));
            }
            Functions.pos2coord(out optI, out optJ, step, Size);
            board.Board.FindCellByValue(out currI, out currJ, Convert.ToString(step));
            score += Params[0] * (Math.Abs(optI - currI) + Math.Abs(optJ - currJ));

            int hole1I, hole1J, hole2I, hole2J;
            board.Board.FindEmptyOne(out hole1I, out hole1J);
            board.Board.FindEmptyTwo(out hole2I, out hole2J);
            // Prise en compte de la distance trou case à placer
            int distH1T = Math.Abs(hole1I - currI) + Math.Abs(hole1J - currJ);
            int distH2T = Math.Abs(hole2I - currI) + Math.Abs(hole2J - currJ);

            score += Params[1] * distH1T;//* Math.Min(distH1T, distH2T);
            score += Params[1] * distH2T;//* Math.Max(distH1T, distH2T);

            // Prise en compte de la distance trou destination
            int distH1 = Math.Abs(optI - hole1I) + Math.Abs(optJ - hole1J);
            int distH2 = Math.Abs(optI - hole2I) + Math.Abs(optJ - hole2J);

            //score += 5 * distH1;
            //score += 5 * distH2;
            score += Params[2] * Math.Min(distH1, distH2);
            //score += Params[4] * Math.Max(distH1, distH2);
            return score;
        }

        private Board CreateStep(int size, int rank)
        {
            Board board;
            List<Cell> structure = new List<Cell>();
            if(rank < size * size - size * 2)
            {
                for (int i = 0; i <= rank; i++)
                {
                    Cell cell = new Cell(i);
                    structure.Add(cell);
                }
                for (int i = rank; i < (size * size - 2) - 1; i++)
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
            }
            else
            {
                List<int> values;
                for (int i = 0; i <= Size * Size - Size * 2; i++)
                {
                    Cell cell = new Cell(i);
                    structure.Add(cell);
                }
                for (int i = Size * Size - Size * 2; i < (size * size - 2) - 1; i++)
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
                int index = 0;
                if(Size == 3)
                {
                    values = new List<int>() { 3, 6, 4, 5 };
                    while(values[index] != rank)
                    {
                        int posI, posJ;
                        Functions.pos2coord(out posI, out posJ, values[index], Size);
                        board.Structure[posI, posJ] = new Cell(values[index]);
                        index++;
                    }
                }
                else
                {
                    values = new List<int>() { 15, 20, 16, 21, 17, 22, 18, 19 };
                    while (values[index] != rank)
                    {
                        int posI, posJ;
                        Functions.pos2coord(out posI, out posJ, values[index], Size);
                        board.Structure[posI, posJ] = new Cell(values[index]);
                        index++;
                    }
                }
                int posValI, posValJ;
                Functions.pos2coord(out posValI, out posValJ, values[index], Size);
                board.Structure[posValI, posValJ] = new Cell(values[index]);
            }
            return board;
        }

        // Might be transform as static
        public static List<EvaluableBoard> CreateChild(EvaluableBoard board)
        {
            List<EvaluableBoard> neighbours = new List<EvaluableBoard>();

            foreach (Cell cell in board)
            {
                int i, j;
                board.Board.FindCellByValue(out i, out j, cell.Value);
                if (cell.IsMovable())
                {
                    foreach (Cell.Moves move in cell.AvailableMoves)
                    {
                        EvaluableBoard neighbour = CopyBoard(board);
                        neighbour.Cost = board.Cost;
                        neighbour.Board.Move(neighbour.Board.Structure[i, j], move);
                        neighbour.Previous = board;
                        neighbours.Add(neighbour);
                    }
                }
            }
            return neighbours;
        }

        public static EvaluableBoard CopyBoard(EvaluableBoard board)
        {
            EvaluableBoard result = new EvaluableBoard(board.Score);
            Cell[,] structure = new Cell[board.Size, board.Size];
            foreach (Cell cell in board)
            {
                Cell newCell = new Cell(cell.Value);
                int posI, posJ;
                board.Board.FindCellByValue(out posI, out posJ, cell.Value);
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
            result.Size = result.Board.Structure.GetLength(0);
            return result;
        }

        public bool FindPast(EvaluableBoard board)
        {
            bool result = false;
            foreach (EvaluableBoard oldBoard in _closedSet)
                if (oldBoard.Equals(board)) result = true;
            return result;
        }

        public bool FindBest(EvaluableBoard board)
        {
            bool result = false;
            foreach (EvaluableBoard currentBoard in _openSet)
            {
                if (board.Equals(currentBoard) && currentBoard.Cost <= board.Cost) result = true;
                else if (board.Equals(currentBoard) && currentBoard.Cost > board.Cost) { currentBoard.Cost = board.Cost; }
            }
            return result;
        }

        public static new List<EvaluableBoard> CreateChild(EvaluableBoard board, int step)
        {
            List<EvaluableBoard> neighbours = new List<EvaluableBoard>();
            int size = board.Board.Structure.GetLength(0);
            List<int> values;
            if (size == 3) values = new List<int>() { 0, 1, 2, 3, 4, 7, 5, 6 };
            else values = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 20, 16, 21, 17, 22, 18, 19 };
            int maxIndex = values.IndexOf(step);
            foreach (Cell cell in board)
            {
                if (cell.Value != "-")
                {
                    int index = values.IndexOf(Convert.ToInt32(cell.Value));
                    if (index >= maxIndex)
                    {
                        int i, j;
                        board.Board.FindCellByValue(out i, out j, cell.Value);
                        if (cell.IsMovable())
                        {
                            foreach (Cell.Moves move in cell.AvailableMoves)
                            {
                                EvaluableBoard neighbour = CopyBoard(board);
                                neighbour.Cost = board.Cost;
                                neighbour.Board.Move(neighbour.Board.Structure[i, j], move);
                                neighbour.Previous = board;
                                neighbours.Add(neighbour);
                            }
                        }
                    }
                }
            }
            return neighbours;
        }
    }
}