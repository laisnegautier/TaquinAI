﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    public class EvaluableBoard : IEnumerable<Cell>
    {
        #region Properties
        public int Size { get; set; }
        public Board Board { get; set; }
        public int Score { get; set; }
        // Ajouter le parent
        #endregion

        #region Construct
        public EvaluableBoard(Board board)
        {
            Board = board;
            Size = board.Structure.GetLength(0);
            Score = 0;
        }

        public EvaluableBoard(int score)
        {
            Score = score;
        }

        public override bool Equals(object obj)
        {
            bool equal = true;
            if (obj != null)
            {
                EvaluableBoard board = (EvaluableBoard)obj;
                foreach (Cell cell in board)
                {
                    int posI, posJ;
                    board.Board.FindCellByValue(out posI, out posJ, cell.Value);
                    if (Board.Structure[posI, posJ].Value != cell.Value)  equal = false;
                }
            }
            else equal = false;
            return equal;
        }
        #endregion

        #region IEnumerable
        public IEnumerator<Cell> GetEnumerator()
        {
            int line = -1;
            for (int i = 0; i < Size * Size; i++)
            {
                if (i % Size == 0) line++;
                yield return Board.Structure[line, i % Size];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
