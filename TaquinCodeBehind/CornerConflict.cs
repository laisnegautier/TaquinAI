using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    public class CornerConflict : IHeuristic
    {
        public int EvaluateBoard(Board currBoard, Board destBoard)
        {
            int size = currBoard.Structure.GetLength(0);
            int cost = 0;
            List<int> cornerValues;
            // Evaluating Corners Conflicts
            if (size == 3)
            {
                cornerValues = new List<int> { 0, 2, 6 };
                List<int> usedPile = new List<int>();
                foreach (int value in cornerValues)
                {
                    int optI, optJ, currI, currJ;
                    Functions.pos2coord(out optI, out optJ, value, size);
                    currBoard.FindCellByValue(out currI, out currJ, value.ToString());
                    if (optI != currI || optJ != currJ)
                    {
                        if (value == 0)
                        {
                            if (currBoard.Structure[optI, optJ + 1].Value == "1")
                            {
                                cost += 2;
                                usedPile.Add(1);
                            }
                            else if (currBoard.Structure[optI + 1, optJ].Value == "3")
                            {
                                cost += 2;
                                usedPile.Add(3);
                            }
                        }
                        else if (value == 2)
                        {
                            if (!(usedPile.Contains(1)))
                            {
                                if (currBoard.Structure[optI, optJ - 1].Value == "1")
                                    cost += 2;
                            }
                            else if (currBoard.Structure[optI + 1, optJ].Value == "5") cost += 2;
                        }
                        else
                        {
                            if (!(usedPile.Contains(3)))
                            {
                                if (currBoard.Structure[optI - 1, optJ].Value == "3")
                                    cost += 2;
                            }
                        }
                    }
                }
            }
            if (size == 5)
            {
                cornerValues = new List<int> { 0, 4, 20 };
                foreach (int value in cornerValues)
                {
                    int optI, optJ, currI, currJ;
                    Functions.pos2coord(out optI, out optJ, value, size);
                    currBoard.FindCellByValue(out currI, out currJ, value.ToString());
                    if (optI != currI || optJ != currJ)
                    {
                        if (value == 0)
                        {
                            if (currBoard.Structure[optI, optJ + 1].Value == "1") cost += 2;
                            else if (currBoard.Structure[optI + 1, optJ].Value == "5") cost += 2;
                        }
                        else if (value == 4)
                        {
                            if (currBoard.Structure[optI, optJ - 1].Value == "3") cost += 2;
                            else if (currBoard.Structure[optI + 1, optJ].Value == "9") cost += 2;
                        }
                        else
                        {
                            if (currBoard.Structure[optI - 1, optJ].Value == "15") cost += 2;
                            else if (currBoard.Structure[optI, optJ + 1].Value == "21") cost += 2;
                        }
                    }
                }
            }
            return cost;
        }
    }
}

