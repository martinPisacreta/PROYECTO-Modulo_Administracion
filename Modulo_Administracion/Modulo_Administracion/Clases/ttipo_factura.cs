namespace Modulo_Administracion.Clases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ttipo_factura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ttipo_factura()
        {
            factura = new HashSet<factura>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal cod_tipo_factura { get; set; }

        [Required]
        [StringLength(50)]
        public string txt_desc { get; set; }

        [Required]
        [StringLength(10)]
        public string letra { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<factura> factura { get; set; }
    }
}
