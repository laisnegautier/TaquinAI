using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    public class SizeBlock : IHeuristic
    {
        public int Size { get; }

        public SizeBlock(){}

        public int EvaluateBoard(Board currBoard, Board destBoard)
        {
            int value = 0;
            foreach(Cell cell in destBoard)
            {
                if(cell.Value != "-1")
                {
                    int destI, destJ;
                    destBoard.FindCellByValue(out destI, out destJ, cell.Value);
                    int currI, currJ;
                    currBoard.FindCellByValue(out currI, out currJ, cell.Value);
                    value += Math.Abs(currI - destI) + Math.Abs(currJ - destJ);
                }
            }
            return value;
        }
    }
}
