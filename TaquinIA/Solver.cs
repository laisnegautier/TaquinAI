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
            OpenSet.Add(_start); // On push le départ dans la liste à évaluer
            if (_start.IsSolvable())
            {
                Console.WriteLine("Ca part sur une résolution Mdr");
                // Tant que l'on à des noeuds à évaluer
                _currentBoard = _start;
                while (OpenSet.Count != 0)
                {
                    // Récupérer le noeud courant
                    Console.WriteLine("Selected Best Board");
                    Console.WriteLine(_currentBoard);
                    // pop la tête
                    ClosedSet.Add(_currentBoard);
                    OpenSet.Remove(_currentBoard);
                    // Ajouter les Board créer par tous les mouvement possible 
                    List<Moves> currentPossibleMoves = FindPossibleMoves();
                    foreach (Moves move in currentPossibleMoves)
                    {
                        Console.Write(move + " ");
                        OpenSet.Add(CreateBoard(move, _currentBoard));
                    }
                    Thread.Sleep(2000);
                    // Evaluer les mouvements faits
                    foreach (Board board in OpenSet) board.Evaluate();
                    // Ordonner la liste

                    OpenSet = OpenSet.OrderBy(b => b.Score).ToList();


                    _currentBoard = OpenSet[0];
                    if (_currentBoard.Score == 0) break;

                    Console.WriteLine(_currentBoard.Score);

                    // Recommencer avec le meilleur noued
                }

            }
            else Console.WriteLine("Ce Taquin n'est pas soluble - On ne peut pas le mélanger dans l'eau");
            Console.WriteLine("Solving Over");
        }

        Board CreateBoard(Moves move, Board previous)
        {
            int i, j;
            _currentBoard.FindEmpty(out i, out j);
            Board newBoard = new Board(_currentBoard.Size);
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
            newBoard.Previous = previous;
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
