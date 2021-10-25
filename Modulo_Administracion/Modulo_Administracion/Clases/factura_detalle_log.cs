namespace Modulo_Administracion.Clases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class factura_detalle_log
    {
        [Key]
        public int id_factura_detalle_log { get; set; }

        public int id_factura_detalle { get; set; }

        public long? id_articulo { get; set; }

        public int id_factura { get; set; }

        public int cantidad { get; set; }

        [Required]
        [StringLength(100)]
        public string codigo_articulo_marca { get; set; }

        [Required]
        [StringLength(100)]
        public string codigo_articulo { get; set; }

        [Required]
        public string descripcion_articulo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal precio_lista_x_coeficiente { get; set; }

        [Column(TypeName = "numeric")]
        public decimal iva { get; set; }

        public DateTime? fec_baja { get; set; }

        public DateTime fecha_log { get; set; }

        [Required]
        [StringLength(50)]
        public string accion { get; set; }
    }
}
