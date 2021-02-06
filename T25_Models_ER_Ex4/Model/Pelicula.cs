using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T25_Models_ER_Ex4.Model
{
    public class Pelicula
    {
        // ATRIBUTOS GETTERS Y SETTERS
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int? CalificacionEdad { get; set; }
        public ICollection<Sala> Salas { get; set; }

        // CONSTRUCTOR
        public Pelicula()
        {
            Salas = new HashSet<Sala>();
        }
    }
}
