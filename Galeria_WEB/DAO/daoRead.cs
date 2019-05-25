using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Galeria_WEB.Models.Clases;
using System.Data;

namespace Galeria_WEB.DAO
{
    public class daoRead : BaseDatos
    {
        public List<Usuario> TraerUsuarios()  //    Muestra los usuarios registrados en la db
        {
            this.OpenConnection();
            string result = "";
            string UsName = "";
            string ID = "";
            string name = "";
            string mail = "";
            List<Usuario> UserList = new List<Usuario>();
            try
            {
                string sql = "SELECT p.`Cedula`, p.`Nombre`, p.`correo`,u.`NombreUsuario` FROM `persona` p JOIN `usuario` u ON p.PersonaID = u.PersonaID";
                MySqlCommand comando = new MySqlCommand(sql);
                comando.Connection = galeriaC;
                MySqlDataReader reader = comando.ExecuteReader();
                var tb = new DataTable();
                tb.Load(reader);

                foreach (DataRow row in tb.Rows)
                {
                    Usuario user = new Usuario(UsName + row["NombreUsuario"], null, null, ID + row["Cedula"], name + row["Nombre"], mail + row["correo"]);
                    UserList.Add(user);
                }
            }
            catch (MySqlException e)
            {
                result = "Ocurrio el siguiente error: " + e;
            }

            this.CloseConnnection();
            return UserList;
        }

        public string ValidarUserPass(Usuario user) // Valida el usuario y la contraseña
        {
            this.OpenConnection();
            string result = "";
            try
            {
                string sql = "SELECT `NombreUsuario` FROM `usuario` WHERE (NombreUsuario ='" + user.NombreUsuario + "')&&(contrasena = '" + user.Contrasena + "')";
                MySqlCommand comando = new MySqlCommand(sql);
                comando.Connection = galeriaC;
                MySqlDataReader reader = comando.ExecuteReader();
                var tb = new DataTable();
                tb.Load(reader);

                foreach (DataRow row in tb.Rows)
                {
                    result += row["NombreUsuario"];
                }
            }
            catch (MySqlException e)
            {
                result = "Ocurrio el siguiente error: " + e;
            }

            this.CloseConnnection();
            return result;
        }

        public bool ValidarExistencia(Usuario user) //Valida que no me ingresen un nombre de usuario que ya exista
        {
            this.OpenConnection();
            string result = "";
            try
            {
                string sql = "SELECT `NombreUsuario` FROM `usuario` WHERE (NombreUsuario ='" + user.NombreUsuario + "')";
                MySqlCommand comando = new MySqlCommand(sql);
                comando.Connection = galeriaC;
                MySqlDataReader reader = comando.ExecuteReader();
                var tb = new DataTable();
                tb.Load(reader);

                foreach (DataRow row in tb.Rows)
                {
                    result += row["NombreUsuario"];
                }
            }
            catch (MySqlException e)
            {
                result = "Ocurrio el siguiente error: " + e;
            }
            this.CloseConnnection();

            if (result == "")
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public string TraerPersonaID(Usuario user)
        {
            this.OpenConnection();
            string result = "";
            try
            {
                string sql = "SELECT `PersonaID` FROM `usuario` WHERE NombreUsuario ='" + user.NombreUsuario + "'";
                MySqlCommand comando = new MySqlCommand(sql);
                comando.Connection = galeriaC;
                MySqlDataReader reader = comando.ExecuteReader();
                var tb = new DataTable();
                tb.Load(reader);

                foreach (DataRow row in tb.Rows)
                {
                    result += row["PersonaID"];
                }
            }
            catch (MySqlException e)
            {
                result = "Ocurrio el siguiente error: " + e;
            }

            this.CloseConnnection();
            return result;
        }


    }
}