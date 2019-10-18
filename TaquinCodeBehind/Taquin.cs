using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    class Taquin
    {
        #region Attributes
        private Board _board;
        #endregion

        #region Construct
        public Taquin(int size)
        {
            Populate(size);
            Shuffle();
        }
        #endregion

        #region Methods
        public void Populate(int size)
        {
            Cell[] cells = new Cell[size*size];
            for(int i = 0; i < (size*size)-2; i++)
            {
                Cell cell = new Cell(i);
                cells[i] = (cell);
            }
            cells[cells.Length - 2] = new Cell();
            cells[cells.Length - 1] = new Cell();
        }

        public void Shuffle()
        {
            if(_board != null)
            {

            }
        }
        #endregion
    }
}
