using System.Collections.Generic;

namespace TA34_04.Models
{
    public partial class Investigadores
    {
        public Investigadores()
        {
            Reserva = new HashSet<Reserva>();
        }
        public string DNI { get; set; }
        public string NomApels { get; set; }
        public int FacCod { get; set; }

        public virtual Facultad Fac { get; set; }

        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
