using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TA34_01.Models
{
    public partial class Suministra
    {
        public int CodigoPieza { get; set; }
        public string IdProveedor { get; set; }
        public int Precio { get; set; }                     
        public virtual Piezas Piezas { get; set; }
        public virtual Proveedores Proveedores { get; set; }
    }
}
