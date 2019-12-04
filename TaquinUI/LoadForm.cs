using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TaquinUI
{
    /// <summary>
    /// Fenêtre de gestion du chargement des exemple et des données enregistrées
    /// </summary>
    public partial class LoadForm : Form
    {
        #region Attributes
        private string _fileName;
        private string _path = @"./../../../Ressources";
        private Button _currentSelection;
        private bool mouseDown;
        private Point lastLocation;
        #endregion

        #region Properties
        public string SelectedFile { get; private set; }
        #endregion

        #region Construct
        public LoadForm()
        {
            InitializeComponent();
            _fileName = "";
            LoadFilesButton();
        }
        #endregion

        #region Methods
        private void LoadFilesButton()
        {
            string[] _files = Directory.GetFiles(_path);
            int i = 0;
            foreach (string name in _files)
            {
                // Création des boutons des fichiers
                Button button = new Button
                {
                    // Contenu
                    Text = name.Substring(_path.Length + 1),
                    Width = filePanel.Width,
                    Height = 50,
                    // Définition du style
                    BackColor = Color.FromArgb(231, 217, 218),
                    ForeColor = Color.FromArgb(69, 94, 41),
                    FlatStyle = FlatStyle.Flat
                };
                button.FlatAppearance.BorderSize = 0;
                button.Top = i * button.Height + i;
                // Ajouts de la gestion des evenements
                button.Click += (s, e) => SelectFileButton_Click(s, e);
                button.MouseEnter += (s, e) => Button_MouseEnter(s, e);
                button.MouseLeave += (s, e) => Button_MouseLeave(s, e);
                // Ajout du control au panel des fichiers
                filePanel.Controls.Add(button);
                if (i == 0) { _currentSelection = button; _fileName = button.Text; }
                i++;
            }
            ButtonSetFocus(_currentSelection);
        }
        #endregion

        #region UIMethods_Misceallanous
        // Fonction pour fermer la fenêtre
        private void CloseLoadButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        // Foncion permettants de drag le form
        private void dragBorder_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void dragBorder_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void dragBorder_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        // Fonction pour minimiser la fenêtre
        private void minimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region UIMethods_Fonctionnalities
        // Fonction trigger lorsqu'un bouton raise un MouseEnter event
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ButtonSetFocus(button);
        }

        // Fonction trigger lorsqu'un bouton raise un MouseLeave event
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            //if ((button == sizeButton3 && _selectedSize == 3) || (button == sizeButton5 && _selectedSize == 5)) ;
            if (button == _currentSelection) ;
            else ButtonUnsetFocus(button);
        }

        // Fonction permettant de mettre en focus un boutton
        private void ButtonSetFocus(Button button)
        {
            button.BackColor = Color.FromArgb(255, 143, 143);
            button.ForeColor = Color.FromArgb(252, 252, 250);
        }

        // Fonction permettant d'enlever le focus d'un boutton
        private void ButtonUnsetFocus(Button button)
        {
            button.BackColor = Color.FromArgb(231, 217, 218);
            button.ForeColor = Color.FromArgb(66, 94, 41);
        }
        #endregion

        #region UIMethods_Interactions
        // Fonction déclenchée au click sur un bouton fichier
        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            // Gestion de l'affichage
            ButtonUnsetFocus(_currentSelection);
            Button button = (Button)sender;
            _currentSelection = button;
            ButtonSetFocus(button);
            // Selection du fichier associer
            _fileName = button.Text;
            Console.WriteLine(SelectedFile);
        }

        // Fonction permettant de charger le fichier choisis
        private void LoadButton_Click(object sender, EventArgs e)
        {
            SelectedFile = _path + "/" + _fileName;
            // On ferme la fenêtre une fois le chemin créé
            Close();
        }
        #endregion
    }
}
