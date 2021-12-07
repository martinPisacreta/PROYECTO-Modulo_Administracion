namespace Modulo_Administracion.Clases
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class tpais
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tpais()
        {
            cliente_dir = new HashSet<cliente_dir>();
            proveedor_dir = new HashSet<proveedor_dir>();
            tmunicipio = new HashSet<tmunicipio>();
            tprovincia = new HashSet<tprovincia>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal cod_pais { get; set; }

        [Required]
        [StringLength(25)]
        public string txt_desc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cliente_dir> cliente_dir { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<proveedor_dir> proveedor_dir { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tmunicipio> tmunicipio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tprovincia> tprovincia { get; set; }
    }
}
