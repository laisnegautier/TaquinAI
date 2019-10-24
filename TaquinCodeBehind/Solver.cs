using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    public abstract class Solver
    {
        #region Attributes
        protected List<EvaluableBoard> _openSet;
        protected List<EvaluableBoard> _closedSet;
        #endregion

        #region Properties
        public IHeuristic Heuristic { get; set; }
        #endregion

        #region AbstractsToOverride
        protected abstract int TotalScore(EvaluableBoard board);
        public abstract List<Board> Solve(EvaluableBoard board);
        #endregion

        #region Methods
        public EvaluableBoard CopyBoard(EvaluableBoard board)
        {
            EvaluableBoard result = new EvaluableBoard(board.Score);
            foreach(Cell cell in board)
            {

            }
            return result;
        }

        public List<EvaluableBoard> CreateChild(EvaluableBoard board)
        {
            List<EvaluableBoard> neighbours = new List<EvaluableBoard>();
            /* Pour chaque Cell trouver 
             tous les mouvement possible. Créer
             un nouveau Board ou le move est réalisé
             et l'ajouter à la liste des voisins
             */

            return neighbours;
        }

        public bool FindPast(EvaluableBoard board)
        {
            bool result = false;

            return result;
        }

        public bool FindBest(EvaluableBoard board)
        {
            bool result = false;

            return result;
        }
        #endregion
    }
}
