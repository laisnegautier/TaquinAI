using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    /// <summary>
    /// Class implémentant l'heuristique PLCC combinant Manhattan, Linear Conflict et CornerConflicts
    /// </summary>
    public class PLCC : IHeuristic
    {
        IHeuristic _h1;
        IHeuristic _h2;
        IHeuristic _h3;

        public PLCC()
        {
            // On utilise nos heuristiques P, LC et C prédéfini
            _h1 = new Manhattan();
            _h2 = new LinearConflict();
            _h3 = new CornerConflict();
        }

        public int EvaluateBoard(Board currBoard, Board destBoard)
        {
            int cost = 0;
            cost += _h1.EvaluateBoard(currBoard, destBoard);
            cost += _h2.EvaluateBoard(currBoard, destBoard);
            cost += _h3.EvaluateBoard(currBoard, destBoard);
            return cost;
        }
    }
}
