using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Galeria_WEB.Models.Clases
{
    public class Ordenxalbum
    {

        private int numeroOrden,
            albumID, imageID;
        private Imagen imagenref;
        private Album albumref;

        public Ordenxalbum(int numeroOrden, int albumID, int imageID)
        {
            this.NumeroOrden = numeroOrden;
            this.AlbumID = albumID;
            this.ImageID = imageID;
        }

        public int NumeroOrden { get => numeroOrden; set => numeroOrden = value; }
        public int AlbumID { get => albumID; set => albumID = value; }
        public int ImageID { get => imageID; set => imageID = value; }
        internal Imagen Imagenref { get => imagenref; set => imagenref = value; }
        internal Album Albumref { get => albumref; set => albumref = value; }

    }
}