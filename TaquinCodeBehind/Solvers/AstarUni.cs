using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    /// <summary>
    /// Implementation de l'algorithme A* unidirectionelle de parcours de graph
    /// </summary>
    public class AstarUni : Solver
    {
        #region Attributes
        protected EvaluableBoard _currentBoard;
        // represente l'état final objectif pour le taquin
        protected EvaluableBoard _destination;
        #endregion

        #region Construct
        public AstarUni(IHeuristic heuristic)
        { 
            // Injection de dépendance de l'heuristique choisie par l'interface
            Heuristic = heuristic;
        }
        #endregion

        #region Methods
        public override List<Board> Solve(EvaluableBoard board)
        {
            _openSet = new List<EvaluableBoard>();
            int size = board.Size;
            _destination = Functions.CreateTarget(size);
            _openSet.Add(board);
            List<Board> result = new List<Board>();
            while (_openSet.Count > 0)
            {
                _currentBoard = _openSet[0];
                // Si on est arrivé, on arrête
                if (_currentBoard.Equals(_destination))
                {
                    Console.WriteLine("Ouvert:");
                    Console.WriteLine(_openSet.Count);
                    Console.WriteLine("Fermes:");
                    Console.WriteLine(_closedSet.Count);
                    result = Unpile(_currentBoard);
                    return result;
                }
                //Sinon on créer les voisins
                List<EvaluableBoard> holder = CreateChild(_currentBoard);
                foreach(EvaluableBoard testBoard in holder)
                {
                    if (FindPast(testBoard) || FindBest(testBoard)){}
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
            return result;
        }
        #endregion
    }
}
