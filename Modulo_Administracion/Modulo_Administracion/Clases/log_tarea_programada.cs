namespace Modulo_Administracion.Clases
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class log_tarea_programada
    {
        [Key]
        [Column(Order = 0)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string tabla { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime fecha { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(200)]
        public string observacion { get; set; }
    }
}
