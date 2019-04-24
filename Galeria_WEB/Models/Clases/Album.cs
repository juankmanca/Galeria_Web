using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Galeria_WEB.Models.Clases
{
    public class Album
    {


        private string nombreAlbum, descripcion;
        private Usuario usuarioRef;
        private List<Ordenxalbum> listorden;




        public Album(int albumID, int usuarioID, string nombreAlbum, string descripcion)
        {

            this.NombreAlbum = nombreAlbum;
            this.Descripcion = descripcion;
        }

        public string NombreAlbum { get => nombreAlbum; set => nombreAlbum = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        internal Usuario UsuarioRef { get => usuarioRef; set => usuarioRef = value; }
        internal List<Ordenxalbum> Listorden { get => listorden; set => listorden = value; }
    }

}
