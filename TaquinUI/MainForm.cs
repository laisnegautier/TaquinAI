using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaquinUI
{
    public partial class MainForm : Form
    {
        #region Attributes
        private int _selectedSize;
        // private IHeuristique _selectedHeuristic

        #endregion

        #region Construct
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        #region UIMethods
        private void CloseButton_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
