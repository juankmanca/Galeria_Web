using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Galeria_WEB.Models.Clases
{
    public class Imagen
    {

        private string foto, titulo, descriocion, comentario;
        private List<Ordenxalbum> listorden;
        private Usuario usuarioref;

        public Imagen(int imagenID, int usuarioID, string foto, string titulo, string descriocion, string comentario)
        {

            this.Foto = foto;
            this.Titulo = titulo;
            this.Descriocion = descriocion;
            this.Comentario = comentario;
        }


        public string Foto { get => foto; set => foto = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Descriocion { get => descriocion; set => descriocion = value; }
        public string Comentario { get => comentario; set => comentario = value; }
        internal List<Ordenxalbum> Listorden { get => listorden; set => listorden = value; }
        internal Usuario Usuarioref { get => usuarioref; set => usuarioref = value; }
    }

}
