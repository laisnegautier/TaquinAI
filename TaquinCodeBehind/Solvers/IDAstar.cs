using System.Collections.Generic;
using System.Linq;

namespace TaquinCodeBehind
{
    /// <summary>
    /// Implementation de l'algorithme IDA* de parcours de graph
    /// </summary>
    public class IDAstar : Solver
    {
        #region Attributes
        protected EvaluableBoard _destination;
        #endregion

        #region Properties
        int Size { get; set; }
        #endregion

        #region Construct
        public IDAstar(IHeuristic heuristic)
        {
            // Injection de dépendance de l'heuristique choisie par l'interface
            Heuristic = heuristic;
        }
        #endregion
        
        #region Functions
        public override List<Board> Solve(EvaluableBoard board)
        {
            // Mise en place du seuil à partir du noeud de départ
            Size = board.Board.Structure.GetLength(0);
            _destination = Functions.CreateTarget(Size);
            int threshold = Heuristic.EvaluateBoard(board.Board, _destination.Board);

            //Setting the StartNode for this iteration
            EvaluableBoard start = board;
            while (true)
            {
                // Départ de la fonction récursive sur le premier noeud
                EvaluableBoard temp = Search(start, 0, threshold);
                int tempScore = temp.Score;
                if (temp.Equals(_destination))
                    return Unpile(temp);
                // Rajouter un if d'arrêt en temps
                threshold = tempScore;
            }
        }

        /// <summary>
        /// Fonction récursive au coeur de l'algorithme IDA* 
        /// permet d'évaluer les parcours potentiels vers la solution
        /// </summary>
        /// <param name="currEval"></param>
        /// <param name="cost"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public EvaluableBoard Search(EvaluableBoard currEval, int cost, int threshold)
        {
            // Evaluation du cout récursif
            int f = cost + Heuristic.EvaluateBoard(currEval.Board, _destination.Board);
            // Si le score dépasse le seuil on coupe la branche
            if(f > threshold)
            {
                currEval.Score = f;
                return currEval;
            }
            if (currEval.Equals(_destination)) return currEval;
            int min = int.MaxValue;
            // Recherche et evaluaiton des voisins
            List<EvaluableBoard> holder = CreateChild(currEval);
            foreach(EvaluableBoard child in holder)
            {
                child.Score = cost + Heuristic.EvaluateBoard(child.Board, _destination.Board);
            }
            holder = holder.OrderBy(b => b.Score).ToList();
            foreach(EvaluableBoard child in holder)
            {
                // Appel récrsif on évalue chaque enfant dans la fonction de recherche
                EvaluableBoard temp = Search(child, cost + 1, threshold);
                int tempScore = temp.Score;
                if (temp.Equals(_destination))
                    return temp;
                if (tempScore < min) min = tempScore;
            }
            currEval.Score = min;
            return currEval;
        }
        #endregion
    }
}
