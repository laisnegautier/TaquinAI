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
        public Board board { get; set; }
        public int Score { get; set; }
        #endregion

        #region Construct
        public EvaluableBoard(Board board)
        {
            this.board = board;
            Score = 0;
        }
        #endregion
    }
}
