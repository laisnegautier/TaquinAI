using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaquinCodeBehind
{
    public class Taquin : IEnumerable<Cell>
    {
        #region Attributes
        private Board _board;
        private readonly int _size;
        #endregion



        #region Construct
        public Taquin(int size)
        {
            _size = size;
            Populate(size);
            Shuffle();
        }
        #endregion

        #region Methods
        public void Populate(int size)
        {
           // Can be factorized
            Cell[] cells = new Cell[size*size];
            for(int i = 0; i < (size*size)-2; i++)
            {
                Cell cell = new Cell(i);
                cells[i] = cell;
            }
            cells[cells.Length - 2] = new Cell();
            cells[cells.Length - 1] = new Cell();
            _board = new Board(cells);
        }

        public void Shuffle()
        {
            if(_board != null)
            {

            }
        }

        public override string ToString()
        {
            return _board.ToString();
        }
        #endregion

        #region IEnumerable
        public IEnumerator<Cell> GetEnumerator()
        {
            int line = -1;
            for(int i = 0; i < _size*_size; i++)
            {
                if (i % _size == 0) line++;
                yield return _board.Structure[line,i % _size];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
