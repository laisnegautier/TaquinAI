using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    public class Manhattan : IHeuristic
    {
        public int EvaluateBoard(Board currBoard, Board destBoard)
        {
            int value = 0;
            foreach(Cell cell in currBoard)
            {
                int currentI, currentJ;
                int destI, destJ;
                currBoard.FindCellByValue(out currentI, out currentJ, cell.Value);
                destBoard.FindCellByValue(out destI, out destJ, cell.Value);
                value += Dist(currentI, currentJ, destI, destJ);
            }
            return value;
        }

        public int Dist(int i1, int j1, int i2, int j2)
        {
            return Math.Abs(i1 - i2) + Math.Abs(j1 - j2);
        }
    }
}
