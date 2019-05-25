using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using Galeria_WEB.Models.Clases;

namespace Galeria_WEB.DAO
{
    public class daoCreate : BaseDatos
    {

        public int InsertUser(Usuario user)
        {
            this.OpenConnection();
            int sw = 0;
            daoRead dbRead = new daoRead();

            if (dbRead.ValidarExistencia(user))
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
            this.CloseConnnection();
            return sw;
        }
    }
}