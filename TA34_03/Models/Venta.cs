namespace TA34_03.Models
{
    public partial class Venta
    {
        public int ProductoCod { get; set; }
        public int CajeroCod { get; set; }
        public int MaquinaCod { get; set; }

        public virtual Productos Pro { get; set; }
        public virtual Cajeros Caj { get; set; }
        public virtual Maq_Registradoras Maq { get; set; }

    }
}
