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
    /// <summary>
    /// Le cell button permet d'encapsuler une cellule en conservant les propriétés d'un bouton
    /// </summary>
    class CellButton : Button
    {
        #region Properties
        public Cell Cell { get; set; }
        #endregion

        #region Construct
        // Construit le bouton en fonction de la taille du taquin
        public CellButton(Cell cell, int size)
        {
            Cell = cell;
            Height = size;
            Width = size;
            Text = Cell.Value;
            SetStyle();
        }
        
        // Assigne toutes les propriété de style au bouton
        public void SetStyle()
        {
            BackColor = Color.FromArgb(231, 217, 218);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Font = new Font("AR BONNIE", 40f, FontStyle.Regular);
            ForeColor = Color.FromArgb(66, 94, 41);
        }
        #endregion
        
    }
}
