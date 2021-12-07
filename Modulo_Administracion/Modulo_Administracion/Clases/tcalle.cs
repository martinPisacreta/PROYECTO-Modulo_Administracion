namespace Modulo_Administracion.Clases
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("tcalle")]
    public partial class tcalle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tcalle()
        {
            cliente_dir = new HashSet<cliente_dir>();
            proveedor_dir = new HashSet<proveedor_dir>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal cod_calle { get; set; }

        [Required]
        [StringLength(50)]
        public string txt_desc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cliente_dir> cliente_dir { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<proveedor_dir> proveedor_dir { get; set; }
    }
}
