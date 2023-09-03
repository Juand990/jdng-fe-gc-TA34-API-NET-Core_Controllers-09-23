namespace TA34_04.Models
{
    public partial class Reserva
    {
        public string DniInv { get; set; }
        public string NumSerieEqu { get; set; }
        public DateTime Comienzo { get; set; }
        public DateTime Fin { get; set; }

        public virtual Investigadores Inv { get; set; }
        public virtual Equipos Eq { get; set; }
    }
}
