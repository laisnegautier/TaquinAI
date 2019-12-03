using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    public class PLC : IHeuristic
    {
        IHeuristic _h1;
        IHeuristic _h2;

        public PLC()
        {
            _h1 = new Manhattan();
            _h2 = new LinearConflict();
        }

        public int EvaluateBoard(Board currBoard, Board destBoard)
        {
            int cost = 0;
            cost += _h1.EvaluateBoard(currBoard, destBoard);
            cost += _h2.EvaluateBoard(currBoard, destBoard);
            return cost;
        }
    }
}
