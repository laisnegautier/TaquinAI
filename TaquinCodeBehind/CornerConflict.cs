﻿using System;
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
            // Evaluating Corners Conflicts
            

            return cost;
        }
    }
}