using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    public class Segments : AstarUni
    {
        int Step { get; }
        int Size { get; set; }

        public Segments(IHeuristic heuristic, List<Board> targets): base(heuristic)
        {
            Step = targets.Count();
            Size = targets[0].Structure.GetLength(0);
        }

        public override List<Board> Solve(EvaluableBoard board)
        {

            return Unpile(_currentBoard);
        }
    }
}
