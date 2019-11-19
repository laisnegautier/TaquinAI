using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaquinUI
{
    public partial class LoadForm : Form
    {
        private string _fileName;
        private string _path = @"./../../../Ressources";
        private string _selectedFile;
        private string[] _files;
        private Button _currentSelection;

        public string SelectedFile { get { return _selectedFile; } }

        private bool mouseDown;
        private Point lastLocation;

        public LoadForm()
        {
            InitializeComponent();
            _fileName = "";
            LoadFilesButton();
        }

        private void LoadFilesButton()
        {
            string[] _files = Directory.GetFiles(_path);
            int i = 0;
            foreach (string name in _files)
            {
                // Define File selection button
                Button button = new Button
                {
                    Text = name.Substring(_path.Length + 1),
                    Width = filePanel.Width,
                    Height = 50,
                    // Style
                    BackColor = Color.FromArgb(231, 217, 218),
                    ForeColor = Color.FromArgb(69, 94, 41),
                    FlatStyle = FlatStyle.Flat
                };
                button.FlatAppearance.BorderSize = 0;
                button.Top = i * button.Height + i;
                // Events
                button.Click += (s, e) => SelectFileButton_Click(s, e);
                button.MouseEnter += (s, e) => Button_MouseEnter(s, e);
                button.MouseLeave += (s, e) => Button_MouseLeave(s, e);
                // Adding the control
                filePanel.Controls.Add(button);
                if (i == 0) { _currentSelection = button; _fileName = button.Text; }
                i++;
            }
            ButtonSetFocus(_currentSelection);
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ButtonSetFocus(button);
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            //if ((button == sizeButton3 && _selectedSize == 3) || (button == sizeButton5 && _selectedSize == 5)) ;
            if (button == _currentSelection) ;
            else ButtonUnsetFocus(button);
        }

        private void ButtonSetFocus(Button button)
        {
            button.BackColor = Color.FromArgb(255, 143, 143);
            button.ForeColor = Color.FromArgb(252, 252, 250);
        }

        private void ButtonUnsetFocus(Button button)
        {
            button.BackColor = Color.FromArgb(231, 217, 218);
            button.ForeColor = Color.FromArgb(66, 94, 41);
        }

        private void CloseLoadButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            ButtonUnsetFocus(_currentSelection);
            Button button = (Button)sender;
            _currentSelection = button;
            ButtonSetFocus(button);
            _fileName = button.Text;
            Console.WriteLine(_selectedFile);
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            _selectedFile = _path +"/"+ _fileName;
            Close();   
        }

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

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
