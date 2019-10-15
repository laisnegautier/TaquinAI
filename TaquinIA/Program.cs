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
            

            /*Board b1 = new Board(3);
            Board b2 = new Board(3);

            b1.InitSafe(); b2.InitSafe();
            Console.WriteLine(b1 == b2);*/

            Console.Read();
        }
    }
}
