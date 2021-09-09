using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_login.DAL
{
    class LoginComand
    {
        public bool have = false;
        public string mensage = "";
        SqlCommand cmd = new SqlCommand();
        Connection con = new Connection();
        SqlDataReader dr;

        public bool verificarLogin(string login, string password)
        {
            //BUSCAR SI HAY EN EL BANCO DE DATOS
            cmd.CommandText = "select * from Logins Where email = @login and senha = @senha";
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", password);

            try
            {
                cmd.Connection = con.Conectar();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)//si fue encontrada informacion
                {
                    have = true;              
                }
                con.desconectar();
                dr.Close();
            }
            catch (SqlException)
            {
                this.mensage = "Error en el banco de datos";
            }
            return have;
        }

        public string Registar(string email, string password, string confPass)
        {
            have = false;
            //COMANDO PARA INSERTAR EN BANCO DE DATOS
            if (password.Equals(confPass))
            {
                cmd.CommandText = "insert into Logins values (@e, @s);";
                cmd.Parameters.AddWithValue("@e", email);
                cmd.Parameters.AddWithValue("@s", password);

                try
                {
                    cmd.Connection = con.Conectar();
                    cmd.ExecuteNonQuery();
                    con.desconectar();
                    this.mensage = "Registrado con exito";
                    have = true;
                }
                catch (SqlException)
                {

                    this.mensage = "Error en el banco de datos";
                }
            }
            else
            {
                this.mensage = "Los passwords no son iguales";
            }      
            
            return mensage;
        }
    }
}
