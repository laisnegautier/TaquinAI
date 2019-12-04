using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    /// <summary>
    /// Class permettant d'encapsuler un tableau pour les algorithmes de résolution
    /// </summary>
    public class EvaluableBoard : IEnumerable<Cell>
    {
        #region Properties
        public int Size { get; set; } // Taille du tableau
        public Board Board { get; set; } // Tableau encapsulé
        public int Score { get; set; } // Distance entre le tableau et le noeud d'origine
        public int Cost { get; set; } // Distance entre le tableau et le noeud d'arrivée
        public EvaluableBoard Previous { get; set; }
        #endregion

        #region Construct
        public EvaluableBoard(Board board)
        {
            Previous = null;
            Board = board;
            Size = board.Structure.GetLength(0);
            Score = 0;
        }

        public EvaluableBoard(int score)
        {
            Previous = null;
            Score = score;
        }
        #endregion

        #region Method
        // Methode permettant de retourner si deux tableau sont égaux
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
                    if(cell.Value != "-")
                        if(Board.Structure[posI,posJ].Value != "-1" && board.Board.Structure[posI,posJ].Value != "-1")
                            if (Board.Structure[posI, posJ].Value != cell.Value)
                                equal = false;
                }
            }
            else equal = false;
            return equal;
        }
        #endregion

        #region IEnumerable
        // Implementation de l'interface IEnumerable permettant de rendre le tableau evaluable 
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
