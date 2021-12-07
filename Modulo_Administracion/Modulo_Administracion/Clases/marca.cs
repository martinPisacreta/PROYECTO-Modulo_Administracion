namespace Modulo_Administracion.Clases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("marca")]
    public partial class marca
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public marca()
        {
            familia = new HashSet<familia>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_tabla_marca { get; set; }

        public int id_marca { get; set; }

        public int id_proveedor { get; set; }

        [Required]
        [StringLength(100)]
        public string txt_desc_marca { get; set; }

        public int sn_activo { get; set; }

        public DateTime fec_ult_modif { get; set; }

        [Required]
        [StringLength(100)]
        public string accion { get; set; }

        [StringLength(400)]
        public string path_img { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<familia> familia { get; set; }

        public virtual proveedor proveedor { get; set; }
    }
}
