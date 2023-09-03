using System.Collections.Generic;

namespace TA34_04.Models
{
    public partial class Facultad
    {
        public Facultad()
        {
            Investigadores = new HashSet<Investigadores>();
            Equipos = new HashSet<Equipos>();
        }

        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Investigadores> Investigadores { get; set; }
        public virtual ICollection<Equipos> Equipos { get; set; }

    }
}
