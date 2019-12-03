using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    /// <summary>
    /// Interface à implémenter pour toute les heuristique
    /// </summary>
    public interface IHeuristic
    {
        // fonction a implémenter pour calculer le cout séparant deux tableaux
        int EvaluateBoard(Board currBoard, Board destBoard); 
    }
}
