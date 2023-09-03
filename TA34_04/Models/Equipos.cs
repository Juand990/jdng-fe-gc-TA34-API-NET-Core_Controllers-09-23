using System.Collections.Generic;

namespace TA34_04.Models
{
    public partial class Equipos
    {
        public Equipos()
        {
            Reserva = new HashSet<Reserva>();
        }
        public string Numserie { get; set; }
        public string Nombre { get; set; }
        public int FacCod { get; set; }
        public virtual Facultad Fac { get; set; }

        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
