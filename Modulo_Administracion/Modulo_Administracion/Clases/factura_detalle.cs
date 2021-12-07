namespace Modulo_Administracion.Clases
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class factura_detalle
    {
        [Key]
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

        [StringLength(400)]
        public string descripcion_articulo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal precio_lista_x_coeficiente { get; set; }

        [Column(TypeName = "numeric")]
        public decimal iva { get; set; }

        public DateTime? fec_baja { get; set; }

        public virtual articulo articulo { get; set; }

        public virtual factura factura { get; set; }
    }
}
