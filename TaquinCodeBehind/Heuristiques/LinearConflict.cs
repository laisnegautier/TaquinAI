using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    public class LinearConflict : IHeuristic
    {
        /// <summary>
        /// Fonction principale qui evalue le cout de l'heuristique LC 
        /// entre deux tableau quelconques
        /// </summary>
        /// <param name="currBoard"> Le tableau à évaluer </param>
        /// <param name="destBoard"> Le tableau avec lequel on compare </param>
        /// <returns></returns>
        public int EvaluateBoard(Board currBoard, Board destBoard)
        {
            int size = currBoard.Structure.GetLength(0);
            int cost = 0;
            // Evaluation de LC pour les lignes
            for(int value = 0; value < size*size-2-1; value ++) // --1 Car on évalue les cases deux à deux
            {
                int succ = value + 1;
                // Pour la valeur on regarde les conflits en lignes
                cost += EvalLineConflict(value, succ, currBoard, size);
                int I, J;
                Functions.pos2coord(out I, out J, value, size);
                succ = (I < size - 2) ? value + size : value - size;
                if (I < size - 2) succ = value + size; else succ = value - size;
                // Pour la valeur on regarde les conflits en colonnes
                cost += EvalRowConflict(value, succ, currBoard, size);
            }
            return cost;
        }

        // Evaluation des conflits sur les lignes
        public int EvalRowConflict(int value, int succ, Board board, int size)
        {
            // Calcul des coordonées optimales des cases
            int optValI, optValJ, optSuccI, optSuccJ;
            Functions.pos2coord(out optValI, out optValJ, value, size);
            Functions.pos2coord(out optSuccI, out optSuccJ, succ, size);
            // Calcul des position courrante des cases
            int currValI, currValJ, curSuccI, curSuccJ;
            board.FindCellByValue(out currValI, out currValJ, value.ToString());
            board.FindCellByValue(out curSuccI, out curSuccJ, succ.ToString());
            // Test des condition et vérification
            if (optValJ == optSuccJ)
                if (currValJ == curSuccJ)
                    if ((optValI < optSuccI && currValI > curSuccI) || (optValI > optSuccI && currValI < curSuccI))
                        return 2;
            return 0;
        }

        //Evaluation des conflits en colonnes
        public int EvalLineConflict(int value, int succ, Board board, int size)
        {
            // Calcul des coordonées optimales des cases
            int optValI, optValJ, optSuccI, optSuccJ;
            Functions.pos2coord(out optValI, out optValJ, value, size);
            Functions.pos2coord(out optSuccI, out optSuccJ, succ, size);
            // Calcul des position courrante des cases
            int currValI, currValJ, curSuccI, curSuccJ;
            board.FindCellByValue(out currValI, out currValJ, value.ToString());
            board.FindCellByValue(out curSuccI, out curSuccJ, succ.ToString());
            // Test des condition et vérification
            if (optValI == optSuccI)
                if (currValI == curSuccI)
                    if ((optValJ < optSuccJ && currValJ > curSuccJ) || (optValJ > optSuccJ && currValJ < curSuccJ))
                        return 2;
            return 0;
        }
    }
}
