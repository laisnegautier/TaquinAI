using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaquinCodeBehind;

namespace TaquinUI
{
    class CellButton : Button
    {
        #region Attributes
        #endregion

        #region Properties
        public Cell Cell { get; set; }
        #endregion

        #region Construct
        public CellButton(Cell cell, int size)
        {
            Cell = cell;
            Height = size;
            Width = size;
            Text = Cell.Value;
        }
        #endregion
        
    }
}
