using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    public class IDAstar : Solver
    {
        protected EvaluableBoard _destination;
        int Size { get; set; }

        public IDAstar(IHeuristic heuristic)
        {
            Heuristic = heuristic;
        }

        public override List<Board> Solve(EvaluableBoard board)
        {
            //Setting the Freshold from the StartNOde Cost
            Size = board.Board.Structure.GetLength(0);
            CreateTarget(Size);
            int threshold = Heuristic.EvaluateBoard(board.Board, _destination.Board);

            //Setting the StartNode for this iteration
            EvaluableBoard start = board;
            while (true)
            {
                EvaluableBoard temp = Search(start, 0, threshold);
                int tempScore = temp.Score;
                if (temp.Equals(_destination))
                    return Unpile(temp);
                // Rajouter un if d'arrêt en temps
                threshold = tempScore;
            }
        }

        public EvaluableBoard Search(EvaluableBoard currEval, int cost, int threshold)
        {
            //Console.WriteLine(currEval.Board);
            //Console.WriteLine(threshold);
            int f = cost + Heuristic.EvaluateBoard(currEval.Board, _destination.Board);
            if(f > threshold)
            {
                currEval.Score = f;
                return currEval;
            }
            if (currEval.Equals(_destination)) return currEval;
            int min = int.MaxValue;
            List<EvaluableBoard> holder = CreateChild(currEval);
            foreach(EvaluableBoard child in holder)
            {
                EvaluableBoard temp = Search(child, cost + 1, threshold);
                int tempScore = temp.Score;
                if (temp.Equals(_destination))
                    return temp;
                if (tempScore < min) min = tempScore;
            }
            currEval.Score = min;
            return currEval;
        }

        public void CreateTarget(int size)
        {
            Cell[] list = new Cell[size * size];
            for (int i = 0; i < size * size - 2; i++)
            {
                Cell cell = new Cell(i);
                list[i] = cell;
            }
            for (int j = 0; j < 2; j++)
            {
                Cell cell = new Cell("-");
                list[list.Length - 1 - j] = cell;
            }
            Board board = new Board(list);
            _destination = new EvaluableBoard(board);
        }
    }
}
