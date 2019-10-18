using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaquinUI
{
    public partial class MainForm : Form
    {
        #region Attributes
        private int _selectedSize;
        // private IHeuristique _selectedHeuristic
        private Thread _solverThread;
        private ResultForm _resultForm;
        #endregion

        #region Construct
        public MainForm()
        {
            InitializeComponent();
            // Initialisation des paramètres internes du Form
            _solverThread = new Thread(new ThreadStart(Solve)); // Le resolution Thread launches 
            _resultForm = new ResultForm();

        }
        #endregion

        #region UIMethods
        //==========================BUTTON===CLOSE=================================
        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (_solverThread.IsAlive) _solverThread.Interrupt();
            if (_resultForm.IsAccessible) _resultForm.Close();
            Close();
        }
        //=============================SIZE===3X3===================================
        private void SizeButton3_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Fonction used to Solve the Taquin board using the selected Heuristic
        /// </summary>
        public void Solve()
        {
        }

        #endregion

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.FromArgb(255,143,143);
            button.ForeColor = Color.FromArgb(252,252,250);
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.FromArgb(231,217,218);
            button.ForeColor = Color.FromArgb(66,94,41);
        }
    }
}
