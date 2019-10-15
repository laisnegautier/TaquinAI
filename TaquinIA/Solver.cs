using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;

namespace TaquinIA
{
    class Solver
    {
        Board _start;
        Board _currentBoard;
        List<Board> OpenSet = new List<Board>();
        List<Board> ClosedSet = new List<Board>();
        enum Moves {Up, Down, Left, Right};
        Moves moves = new Moves();

        public Solver(Board board)
        {
            _start = board;
        }

        public void Solve()
        {
            DateTime start = DateTime.Now;
            OpenSet.Add(_start); // On push le départ dans la liste à évaluer
            if (_start.IsSolvable())
            {
                Console.WriteLine(_start);
                Console.WriteLine("Ca part sur une résolution Mdr");
                /*DateTime current = DateTime.Now;
                TimeSpan spend = current - start;
                Console.WriteLine("\r" + spend);*/
                // Tant que l'on à des noeuds à évaluer
                _currentBoard = _start;
                _currentBoard.TotalCost = 0;
                while (OpenSet.Count != 0)
                {
                    _currentBoard = OpenSet[0]; // Select best board
                    OpenSet.Remove(_currentBoard); // Remove it from non evaluated nodes
                    ClosedSet.Add(_currentBoard);
                    List<Board> CurrentBoards = new List<Board>();
                    if (_currentBoard.IsDone())
                    {
                        Console.WriteLine("Solving Over - Optimal solution found");
                        //Console.WriteLine(_currentBoard);
                        // Dépiler les solutions grace au previous
                        Unpile(_currentBoard);
                        break;
                    }
                    // Trouver les voisins et les ajouter à la liste
                    List<Moves> currentPossibleMoves = FindPossibleMoves();
                    foreach (Moves move in currentPossibleMoves)
                    {
                        //Console.Write(move + " ");
                        CurrentBoards.Add(CreateBoard(move));
                    }

                    foreach(Board board in CurrentBoards)
                    {
                        if (!FindOld(board)) // Ou si il est dans open avec un ct inférieur
                        {
                            board.Cost = board.Previous.Cost + 1;
                            board.Evaluate();
                            board.SetTotalCost();
                            if( !FindBest(board) ) OpenSet.Add(board);
                        }
                        else
                        {
                            Console.Write("");
                        }
                    }
                    OpenSet = OpenSet.OrderBy(b => b.TotalCost).ToList();
                }
                if (OpenSet.Count == 0) Console.Write("Taquin non résoluble");
            }
            else Console.WriteLine("Ce Taquin n'est pas soluble - On ne peut pas le mélanger dans l'eau");
            Console.WriteLine("Solving Over");
        }

        bool FindOld(Board board)
        {
            bool find = false;
            foreach (Board b in ClosedSet)
            {
                if (b == board)
                {
                    find = true;
                    break;
                }
            }
            return find;
        }

        bool FindBest(Board board)
        {
            bool find = false;
            foreach(Board b in OpenSet)
            {
                if (b == board && b.TotalCost < board.TotalCost)
                {
                    find = true;
                    break;
                }
            }
            return find;
        }

        public void Unpile(Board board)
        {
            int moveCount = 0;
            while(!(board.Previous is null))
            {
                Console.WriteLine(board);
                Console.WriteLine("=====");
                moveCount++;
                board = board.Previous;

            }
            Console.WriteLine(board);
            Console.WriteLine("This Taquin was solvable in {0} moves", moveCount);
        }

        Board CreateBoard(Moves move)
        {
            int i, j;
            _currentBoard.FindEmpty(out i, out j);
            Board newBoard = new Board(_currentBoard.Size);
            newBoard.Previous = _currentBoard;
            for(int _=0; _< _currentBoard.Structure.Length; _++)
                Array.Copy(_currentBoard.Structure[_], newBoard.Structure[_], _currentBoard.Structure[_].Length);

            switch (move)
            {
                case Moves.Up:
                    newBoard.Structure[i][j] = _currentBoard.Structure[i + 1][j];
                    newBoard.Structure[i + 1][j] = '-';
                    break;
                case Moves.Down:
                    newBoard.Structure[i][j] = _currentBoard.Structure[i - 1][j];
                    newBoard.Structure[i - 1][j] = '-';
                    break;
                case Moves.Left:
                    newBoard.Structure[i][j] = _currentBoard.Structure[i][j+1];
                    newBoard.Structure[i][j+1] = '-';
                    break;
                case Moves.Right:
                    newBoard.Structure[i][j] = _currentBoard.Structure[i][j-1];
                    newBoard.Structure[i][j-1] = '-';
                    break;
            }
            return newBoard;
        }

        List<Moves> FindPossibleMoves()
        {
            List<Moves> possibles = new List<Moves>();
            int i, j;
            _currentBoard.FindEmpty(out i, out j);
            int move = (int)moves;
            if (i < _currentBoard.Size - 1) possibles.Add(Moves.Up);
            if (i > 0) possibles.Add(Moves.Down);
            if (j < _currentBoard.Size - 1) possibles.Add(Moves.Left);
            if (j > 0) possibles.Add(Moves.Right);
            return possibles;
        }

    }

}
