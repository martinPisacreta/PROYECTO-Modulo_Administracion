namespace Modulo_Administracion.Clases
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class usuario_pedido_detalle
    {
        [Key]
        public int id_usuario_pedido_detalle { get; set; }

        public int id_usuario_pedido { get; set; }

        [Required]
        [StringLength(100)]
        public string codigo_articulo { get; set; }

        [StringLength(400)]
        public string descripcion_articulo { get; set; }

        [Required]
        [StringLength(100)]
        public string txt_desc_marca { get; set; }

        [Required]
        [StringLength(255)]
        public string txt_desc_familia { get; set; }

        [Column(TypeName = "numeric")]
        public decimal precioLista_por_coeficiente_por_medioIva { get; set; }

        public int utilidad { get; set; }

        public int sn_oferta { get; set; }

        [Column(TypeName = "numeric")]
        public decimal precio_lista { get; set; }

        [Column(TypeName = "numeric")]
        public decimal coeficiente { get; set; }

        public int cantidad { get; set; }

        public virtual usuario_pedido usuario_pedido { get; set; }
    }
}
