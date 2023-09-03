namespace TA34_02.Models
{
    public partial class AsignadoA
    {        
        public int id { get; set; }
        public string CientificoDni { get; set; }
        public string ProyectoId { get; set; }

        public virtual Cientificos Cient{ get; set; }
        public virtual Proyectos Proy { get; set; }
    }
}
