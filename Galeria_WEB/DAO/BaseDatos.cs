using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Galeria_WEB.Models.Clases;
using System.Data;

namespace Galeria_WEB.DAO
{
    public class BaseDatos
    {
        protected MySqlConnection galeriaC = new MySqlConnection();


        public void OpenConnection()
        {
            galeriaC.ConnectionString = "server = 127.0.0.1; "
                                + "uid= root; "
                                + "pwd= root; "
                               + "database= galeria;";
            galeriaC.Open();
        }

        public void CloseConnnection()
        {
            galeriaC.Close();
        }

  /*
    public int InsertUser(Usuario user)
    {
        int sw = 0;

            if (ValidarExistencia(user))
            {
                try
                {
                    //ingresar datos en la tabla persona
                    string sql = "INSERT INTO `persona` (`PersonaID`,"
                    + " `Cedula`, `Nombre`,`correo`)"
                    + " VALUES(NULL,'" + user.Cedula + "','" + user.Nombre + "','" + user.Correo + "');";
                    MySqlCommand command = new MySqlCommand(sql);
                    command.Connection = galeriaC;
                    command.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    sw = 1;
                }
                String Resultado = ""; // Variable aux donde guardaremos la consulta
                                       //Si a este campo le ponemos el valor que deberia ir en PersonaID(persona) y
                                       //el de PersonaID(Usuario), logra hacer la consulta 2
                if (sw == 0)
                {
                    try
                    {
                        //Pasar el ultimo valor de PersonaID a UsuarioID
                        String query = "SELECT MAX(`PersonaID`) AS'RESULT' FROM `persona`;";


                        MySqlCommand command3 = new MySqlCommand(query);
                        command3.Connection = galeriaC;
                        MySqlDataReader reader = command3.ExecuteReader();
                        var dataTable = new DataTable();
                        dataTable.Load(reader);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            Resultado = Resultado + (row["RESULT"]);

                        }
                        
                    }
                    catch (MySqlException e)
                    {
                        sw = 1;
                    }

                    try
                    {
                        //Ingresar Datos a la tabla Usuario
                        string sql2 = "INSERT INTO `usuario`(`UsuarioID`,`NombreUsuario`,`contrasena`, `Avatar`, `PersonaID`)" +
                        " VALUES (NULL,'" + user.NombreUsuario + "','" + user.Contrasena + "','" + user.Avatar + "','" + Resultado + "');";
                        MySqlCommand command2 = new MySqlCommand(sql2);
                        command2.Connection = galeriaC;
                        command2.ExecuteNonQuery();
                    }
                    catch (MySqlException e)
                    {
                        sw = 1;
                    }
                }
            }
            else
            {
                sw = 2;
            }
        return sw;
    } */
    /*
        public string ValidarUserPass(Usuario user) // Valida el usuario y la contraseña
        {
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


            return result;
        }

        public bool ValidarExistencia(Usuario user) //Valida que no me ingresen un nombre de usuario que ya exista
        {
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

            if (result == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
         */
        /*
        public List<Usuario> TraerUsuarios()  //    Muestra los usuarios registrados en la db
        { 
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
                    Usuario user = new Usuario(UsName + row["NombreUsuario"], null, null,ID +  row["Cedula"],name + row["Nombre"],mail + row["correo"]);
                    UserList.Add(user);    
                }
            }
            catch (MySqlException e)
            {
                result = "Ocurrio el siguiente error: " + e;
            }


            return UserList;
        }
        */
    }
}