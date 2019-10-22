using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    public class EvaluableBoard
    {
        #region Properties
        public Board Board { get; set; }
        public int Score { get; set; }
        #endregion

        #region Construct
        public EvaluableBoard(Board board)
        {
            Board = board;
            Score = 0;
        }

        public EvaluableBoard(int score)
        {
            Score = score;
        }
        #endregion
    }
}
