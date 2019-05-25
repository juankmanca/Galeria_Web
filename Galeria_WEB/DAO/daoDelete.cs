using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Galeria_WEB.Models.Clases;
using System.Data;

namespace Galeria_WEB.DAO
{
    public class daoDelete : BaseDatos
    {

        public bool EliminarRegistro(Usuario user)
        {
            this.OpenConnection();
            daoRead dbRead = new daoRead();
            string PersonaID = dbRead.TraerPersonaID(user);
            bool sw = true;
            
            try
            {
                string sql1 = "DELETE FROM `usuario` WHERE `usuario`.`UsuarioID` = " + PersonaID ;
                MySqlCommand command = new MySqlCommand(sql1);
                command.Connection = galeriaC;
                command.ExecuteNonQuery();
            }catch(MySqlException e)
            {
                sw = false;
            }

            if (sw)
            {
                try
                {
                    string sql = "DELETE FROM `persona` WHERE `persona`.`PersonaID` = " + PersonaID;
                    MySqlCommand command1 = new MySqlCommand(sql);
                    command1.Connection = galeriaC;
                    command1.ExecuteNonQuery();
                }catch(MySqlException e)
                {
                    sw = false;
                }
            }
            this.CloseConnnection();
            return sw;

        }
    }
}