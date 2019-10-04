using NetConf2019.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetConf2019WinForms
{
    public partial class Form1 : Form
    {
        public LoginViewModel ViewModel { get; set; } = new LoginViewModel();
        public Form1()
        {
            InitializeComponent();
            ViewModel.IniciarSesionCommand.CanExecuteChanged += (s, e) =>
                entrarButton.Enabled = ViewModel.IniciarSesionCommand.CanExecute(null);
            ViewModel.PropertyChanged += (s, e) =>
            {
                switch (e.PropertyName)
                {
                    case "Mensaje":
                        if (!string.IsNullOrEmpty(ViewModel.Mensaje))
                            MessageBox.Show(ViewModel.Mensaje, "Windows Forms - Net Core 3", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            };
        }

        private void usuarioTextBox_TextChanged(object sender, EventArgs e) =>
            ViewModel.Usuario = usuarioTextBox.Text;

        private void passwordTextBox_TextChanged(object sender, EventArgs e) =>
            ViewModel.Password = passwordTextBox.Text;

        private void entrarButton_Click(object sender, EventArgs e) =>
            ViewModel.IniciarSesionCommand.Execute(null);
    }
}
