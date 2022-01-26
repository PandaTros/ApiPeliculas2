using System;
using System.Collections.Generic;

#nullable disable

namespace ApiPeliculas_Final.Modelos
{
    public partial class Peliculas2
    {
        public int Id { get; set; }
        public string NombrePelicula { get; set; }
        public string Director { get; set; }
        public string Genero { get; set; }
        public int Puntuacion { get; set; }
        public decimal Rating { get; set; }
        public string FechaPublicacion { get; set; }
    }
}
