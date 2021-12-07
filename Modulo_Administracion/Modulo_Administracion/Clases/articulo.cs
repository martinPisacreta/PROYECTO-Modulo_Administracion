namespace Modulo_Administracion.Clases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("articulo")]
    public partial class articulo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public articulo()
        {
            factura_detalle = new HashSet<factura_detalle>();
        }

        [Key]
        public long id_articulo { get; set; }

        [StringLength(100)]
        public string codigo_articulo_marca { get; set; }

        [StringLength(100)]
        public string codigo_articulo { get; set; }

        [StringLength(400)]
        public string descripcion_articulo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? precio_lista { get; set; }

        public int? id_tabla_familia { get; set; }

        public int? sn_oferta { get; set; }

        [StringLength(400)]
        public string path_img { get; set; }

        public DateTime? fecha_ult_modif { get; set; }

        public DateTime? fec_baja { get; set; }

        [StringLength(50)]
        public string accion { get; set; }

        public int? stock { get; set; }

        public long? id_orden { get; set; }

        public virtual familia familia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<factura_detalle> factura_detalle { get; set; }
    }
}
