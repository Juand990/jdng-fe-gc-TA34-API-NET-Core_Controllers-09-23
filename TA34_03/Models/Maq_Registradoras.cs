using System.Collections.Generic;

namespace TA34_03.Models
{
    public partial class Maq_Registradoras
    {
        public Maq_Registradoras()
        {
            Venta = new HashSet<Venta>();
        }
        public int Codigo { get; set; }
        public int Piso { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }

}
