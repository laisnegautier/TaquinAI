using System.Collections.Generic;
using System.Linq;

namespace TaquinCodeBehind
{
    /// <summary>
    /// Implementation de l'algorithme A* unidirectionelle de parcours de graph
    /// </summary>
    public class AstarUni : Solver
    {
        #region Attributes
        protected EvaluableBoard _currentBoard;
        // Represente l'état final objectif pour le taquin
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
        /// <summary>
        /// Implémentation de l'algorithme A*
        /// </summary>
        /// <param name="board"> tableau de départ à résoudre </param>
        /// <returns></returns>
        public override List<Board> Solve(EvaluableBoard board)
        {
            // Création de la liste des ouvert vides
            _openSet = new List<EvaluableBoard>();
            int size = board.Size; // taille de l'example à résoudre
            _destination = Functions.CreateTarget(size);
            _openSet.Add(board);
            List<Board> result = new List<Board>(); // Initialisation du chemin
            // Boucle de résolution
            while (_openSet.Count > 0)
            {
                _currentBoard = _openSet[0]; // On récupère le meilleur élément 
                if (_currentBoard.Equals(_destination)) // Si on est arrivé, on arrête
                {
                    openCount = _openSet.Count;
                    closedCount = _closedSet.Count;
                    result = Unpile(_currentBoard);
                    return result;
                }
                // Sinon on créer les voisins
                List<EvaluableBoard> holder = CreateChild(_currentBoard);
                foreach(EvaluableBoard testBoard in holder)
                {
                    if (FindPast(testBoard) || FindBest(testBoard)){} // Si le voisin à déjà été évalué on ne le considère pas
                    else
                    {
                        // On applique les mesure de cout et d'heuristique à l'enfant et on l'ajoute à la liste
                        testBoard.Cost += 1;
                        testBoard.Score = testBoard.Cost + Heuristic.EvaluateBoard(testBoard.Board, _destination.Board);
                        _openSet.Add(testBoard);
                    }
                }
                // On enlève le noeud courrant des ouvert et on la joute à l aliste des fermés
                _closedSet.Add(_currentBoard);
                _openSet.Remove(_currentBoard);
                // On ordonne la liste pour garder les meilleurs en premier
                _openSet = _openSet.OrderBy(b => b.Score).ToList();
            }
            openCount = _openSet.Count;
            closedCount = _closedSet.Count;
            return result;
        }
        #endregion
    }
}
