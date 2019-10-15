using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinIA
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(3);
            board.InitSafe();
            //board.Init();
            Solver solver = new Solver(board);
            solver.Solve();

            Console.Read();
        }
    }
}
