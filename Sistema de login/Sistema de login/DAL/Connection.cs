using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_login.DAL
{
    public class Connection
    {
        SqlConnection con = new SqlConnection();
        
        /// <summary>
        /// Constructor
        /// </summary>
        public Connection()
        {
            con.ConnectionString = @"Data Source=DESKTOP-G3IRT6L\MSSQLSERVER03;Initial Catalog=""Sistema de login"";Integrated Security=True";
        }

        /// <summary>
        /// Metodo para conectar
        /// </summary>
        /// <returns></returns>
        public SqlConnection Conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        /// <summary>
        /// Metodo para desconectar
        /// </summary>
        public void desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }

    }
}
