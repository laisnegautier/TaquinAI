using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinIA
{
    class Board
    {
        #region Attributes
        int _size;
        char[][] structure;
        Random r = new Random();
        #endregion

        #region Properties
        public int Size { get { return _size; } }
        public int Cost { get; set; }
        public int HeuristicCost { get; set; }
        public int TotalCost { get; set; }
        public Board Previous { get; set; }
        public char[][] Structure
        {
            get { return structure; }
            set { structure = value; }
        }
        #endregion

        #region Construct
        public Board(int size)
        {
            _size = size;
            //Création de la première dimension du board
            structure = new char[_size][];
            //Création de la deuxièmre dimension du board
            for (int i = 0; i < _size; i++) structure[i] = new char[_size];
            //Init();
        }
        #endregion

        #region Methods
        public void Init()
        {
            List<int> disp = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7 }); // rendre le remplissage dynamique en fct de la size
            int limit = (_size*_size)-1;
            for(int rank = 0; rank < limit; rank++)
            {
                int index = r.Next(disp.Count);
                int i, j;
                pos2coord(out i,out j, rank);
                structure[i][j] = Convert.ToChar((disp[index]).ToString());
                disp.Remove(disp[index]);
            }
            structure[_size-1][_size-1] = '-';
            Console.WriteLine(IsSolvable());
        }

        public void InitSafe()
        {
            /*char[] l1 = { '0', '1', '2' };
            char[] l2 = { '3', '-', '4' };
            char[] l3 = { '6', '7', '5' };*/
            char[] l1 = { '4', '5', '7' };
            char[] l2 = { '0', '3', '2' };
            char[] l3 = { '1', '6', '-' };
            structure[0] = l1;
            structure[1] = l2;
            structure[2] = l3;
        }

        public int FindRank(int value)
        {
            int rank = 0;
            for (int i = 0; i < _size; i++)
                for (int j = 0; j < _size; j++)
                {
                    if (structure[i][j] == value)
                        rank = coord2pos(i, j);
                }
            return rank;
        }

        public void FindValue(out int i, out int j, int value)
        {
            i = 0; j = 0;
            for (int e = 0; e < _size; e++)
                for (int k = 0; k < _size; k++)
                    if(structure[e][k] != '-')
                        if(Convert.ToInt32((structure[e][k]).ToString()) == value)
                        {
                            i = e;
                            j = k;
                        }
        }

        public bool IsSolvable()
        {
            bool isSovable = false;
            int sumOfPairs = 0;
            for(int i = 0; i < (_size*_size)-1; i++)
                for(int j = 0; j < (_size*_size)-1; j++)
                {
                    if(i != j)
                    {
                        int ligne1, ligne2, column1, column2;
                        int ranki, rankj;
                        FindValue(out ligne1, out column1, i);
                        ranki = coord2pos(ligne1, column1);
                        FindValue(out ligne2, out column2, j);
                        rankj = coord2pos(ligne2, column2);
                        if (i < j && ranki > rankj) sumOfPairs++;
                        if (i > j && ranki < rankj) sumOfPairs++;
                    }
                }
            if (sumOfPairs % 2 == 0) isSovable = true;
            return isSovable;
        }

        public int coord2pos(int i, int j)
        {
            return ( j*_size + i);
        }

        public void pos2coord(out int i, out int j, int rank)
        {
            j = rank % _size;
            i = rank / _size;
        }

        public void Draw()
        {
            for(int i =0; i < _size; i++)
                for(int j = 0; j < _size; j++)
                {
                    Console.Write(structure[i][j]);
                    if ((j+1) % _size == 0) Console.Write('\n');
                }
        }

        public void FindEmpty(out int i, out int j)
        {
            i = j = 0;
            for(int iter = 0; iter < (_size*_size); iter++)
            {
                int e, k;
                pos2coord(out e, out k, iter);
                if(structure[e][k] == '-')
                {
                    i = e; j = k;
                }
            }
        }

        public override string ToString()
        {
            this.Draw();
            return "";
        }

        public int Manhattan(int x1, int y1, int x2, int y2)
        {
            return (Math.Abs(x1-x2) + Math.Abs(y1-y2));            
        }
        
        public bool IsDone()
        {
            if (Heuristic() == 0) return true;
            else return false;
        }

        // Méthode de calcul du cout total sur le board ( Heuristique en |L1| )
        public int Heuristic()
        {
            int opti, optj;
            int currenti, currentj;
            int totalValue = 0;
            for(int _ = 0; _ < (_size*_size)-2; _++)
            {
                pos2coord(out opti, out optj, _);
                FindValue(out currenti, out currentj, _);
                totalValue += Manhattan(opti, optj, currenti, currentj);
            }
            return totalValue;
        }

        public void Evaluate()
        {
            HeuristicCost = Heuristic();
        }

        public void SetTotalCost()
        {
            TotalCost = Cost + HeuristicCost;
        }

        public override bool Equals(object obj)
        {
            bool equal = true;
            Board target = (Board)obj;
            for (int i = 0; i < _size; i++)
                for (int j = 0; j < _size; j++)
                    if (Structure[i][j] != target.Structure[i][j]) equal = false;
            
            return equal;
        }

        public static bool operator == (Board obj1, Board obj2)
        {
            if (obj2 is null || obj1 is null) return false;
            return (obj1.Equals(obj2));
        }

        public static bool operator != (Board obj1, Board obj2)
        {
            if (obj1 is null || obj2 is null) return true;
            return (obj1.Equals(obj2));
        }
        #endregion
    }
}
