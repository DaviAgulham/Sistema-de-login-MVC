using Sistema_de_login.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_login.Model
{
    public class Controle
    {
        public bool have;
        public string mensage ="";

        public bool Acceder(String login, string password)
        {
            LoginComand loginCo = new LoginComand();
            have = loginCo.verificarLogin(login, password);
            if (!loginCo.mensage.Equals(""))
            {
                this.mensage = loginCo.mensage;
            }
            return have;
        }

        public string Registrar(String email, String password, String confPass)
        {
            LoginComand loginCo = new LoginComand();
            this.mensage = loginCo.Registar(email, password, confPass);
            if (loginCo.have)//si have es true imprime mensaje de exito
            {
                this.have = true;
            }
            return mensage;
        }
    }
}
