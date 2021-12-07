namespace Modulo_Administracion.Clases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("factura")]
    public partial class factura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public factura()
        {
            factura_detalle = new HashSet<factura_detalle>();
        }

        [Key]
        public int id_factura { get; set; }

        public int id_cliente { get; set; }

        [Column(TypeName = "numeric")]
        public decimal cod_tipo_factura { get; set; }

        public DateTime fecha { get; set; }

        public long nro_factura { get; set; }

        public decimal precio_final { get; set; }

        public int sn_modifica_precio_final { get; set; }

        public decimal precio_final_con_pago_mayor_a_30_dias { get; set; }

        public decimal precio_final_con_pago_menor_a_30_dias { get; set; }

        public decimal precio_final_con_pago_menor_a_7_dias { get; set; }

        public int sn_emitida { get; set; }

        [StringLength(500)]
        public string observacion { get; set; }

        public int sn_mostrar_pago_mayor_30_dias { get; set; }

        public int sn_mostrar_pago_menor_7_dias { get; set; }

        public int sn_mostrar_pago_menor_30_dias { get; set; }

        public int id_condicion_factura { get; set; }

        public DateTime? fecha_sn_emitida { get; set; }

        [StringLength(1500)]
        public string path_factura { get; set; }

        public virtual cliente cliente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<factura_detalle> factura_detalle { get; set; }

        public virtual ttipo_condicion_factura ttipo_condicion_factura { get; set; }

        public virtual ttipo_factura ttipo_factura { get; set; }
    }
}
