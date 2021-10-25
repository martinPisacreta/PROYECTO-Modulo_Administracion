namespace Modulo_Administracion.Clases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("proveedor")]
    public partial class proveedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public proveedor()
        {
            marca = new HashSet<marca>();
            proveedor_datos = new HashSet<proveedor_datos>();
            proveedor_dir = new HashSet<proveedor_dir>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_proveedor { get; set; }

        [Required]
        [StringLength(100)]
        public string razon_social { get; set; }

        public int sn_activo { get; set; }

        public DateTime fec_ult_modif { get; set; }

        [Required]
        [StringLength(100)]
        public string accion { get; set; }

        [StringLength(500)]
        public string path_img { get; set; }

        public int? id_condicion_ante_iva { get; set; }

        public int? id_condicion_pago { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<marca> marca { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<proveedor_datos> proveedor_datos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<proveedor_dir> proveedor_dir { get; set; }

        public virtual ttipo_condicion_iva ttipo_condicion_iva { get; set; }

        public virtual ttipo_condicion_pago ttipo_condicion_pago { get; set; }
    }
}
