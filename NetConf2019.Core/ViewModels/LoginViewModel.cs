using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetConf2019.Core.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {

        private string usuario;
        public string Usuario
        {
            get => usuario;
            set { 
                Set(ref usuario, value);
                IniciarSesionCommand.RaiseCanExecuteChanged();
            }
        }

        private string password;
        public string Password
        {
            get => password;
            set { 
                Set(ref password, value);
                IniciarSesionCommand.RaiseCanExecuteChanged();
            }
        }

        private string mensaje;
        public string Mensaje { get => mensaje; set => Set(ref mensaje, value); }

        RelayCommand iniciarSesionCommand = null;
        public RelayCommand IniciarSesionCommand
        {
            get => iniciarSesionCommand ?? (iniciarSesionCommand = new RelayCommand(() =>
            {
                Mensaje = "Autentificando...";
                Mensaje = (Usuario == Password) ? "Válido" : "Inválido";
            }, () => { return !string.IsNullOrEmpty(Usuario) && !string.IsNullOrEmpty(Password); }));
        }
    }
}
