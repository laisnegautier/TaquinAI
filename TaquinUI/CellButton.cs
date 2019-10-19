using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
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
            BackColor = Color.FromArgb(231,217,218);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Font = new Font("AR BONNIE", 50f, FontStyle.Regular);
            ForeColor = Color.FromArgb(66,94,41);
        }
        
        #endregion
        
    }
}
