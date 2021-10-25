namespace Modulo_Administracion.Clases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cliente")]
    public partial class cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cliente()
        {
            cliente_datos = new HashSet<cliente_datos>();
            cliente_dir = new HashSet<cliente_dir>();
            factura = new HashSet<factura>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_cliente { get; set; }

        [Required]
        [StringLength(100)]
        public string nombre_fantasia { get; set; }

        [StringLength(100)]
        public string razon_social { get; set; }

        public int sn_activo { get; set; }

        public DateTime fec_ult_modif { get; set; }

        [Required]
        [StringLength(100)]
        public string accion { get; set; }

        public int? id_condicion_ante_iva { get; set; }

        public int? id_condicion_pago { get; set; }

        public int id_condicion_factura { get; set; }

        public int id_tipo_cliente { get; set; }

        public int? id_vendedor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cliente_datos> cliente_datos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cliente_dir> cliente_dir { get; set; }

        public virtual ttipo_cliente ttipo_cliente { get; set; }

        public virtual ttipo_condicion_factura ttipo_condicion_factura { get; set; }

        public virtual ttipo_condicion_iva ttipo_condicion_iva { get; set; }

        public virtual ttipo_condicion_pago ttipo_condicion_pago { get; set; }

        public virtual vendedor vendedor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<factura> factura { get; set; }
    }
}
