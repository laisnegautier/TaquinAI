using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    public class Functions
    {
        public static int coord2pos(int i, int j, int size)
        {
            return (i * size + j);
        }

        public static void pos2coord(out int i, out int j, int rank, int size)
        {
            j = rank % size;
            i = rank / size;
        }
    }
}
