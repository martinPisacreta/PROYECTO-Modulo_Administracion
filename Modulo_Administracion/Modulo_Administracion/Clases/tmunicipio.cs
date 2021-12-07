namespace Modulo_Administracion.Clases
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("tmunicipio")]
    public partial class tmunicipio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tmunicipio()
        {
            cliente_dir = new HashSet<cliente_dir>();
            proveedor_dir = new HashSet<proveedor_dir>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal cod_municipio { get; set; }

        [Column(TypeName = "numeric")]
        public decimal cod_provincia { get; set; }

        [Column(TypeName = "numeric")]
        public decimal cod_pais { get; set; }

        [StringLength(255)]
        public string txt_desc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? cod_divipola { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cliente_dir> cliente_dir { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<proveedor_dir> proveedor_dir { get; set; }

        public virtual tpais tpais { get; set; }

        public virtual tprovincia tprovincia { get; set; }
    }
}
