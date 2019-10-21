using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    public abstract class Solver
    {
        public IHeuristic Heuristic { get; set; }

        protected abstract int TotalScore(Board board);

        public abstract List<Board> Solve(Board board);
    }
}
