using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T25_Models_ER_Ex4.Model
{
    public class Sala
    {
        // ATRIBUTOS, GETTERS Y SETTERS
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int? Pelicula { get; set; }
        public Pelicula Peliculas { get; set; }
    }
}
