using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Galeria_WEB.Models.Clases;
using System.Data;

namespace Galeria_WEB.DAO
{
    public class daoUpdate: BaseDatos
    {
        
        public bool ActualizarContrasena(Usuario user)
        {
            this.OpenConnection();
            bool sw = true;
            try
            {
                string sql = "UPDATE `usuario` SET `contrasena`= "+user.Contrasena+" WHERE `NombreUsuario`='"+user.NombreUsuario+"'";
                MySqlCommand command = new MySqlCommand(sql);
                command.Connection = galeriaC;
                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                sw = false;
            }
            this.CloseConnnection();
            return sw;
        }
    }
}