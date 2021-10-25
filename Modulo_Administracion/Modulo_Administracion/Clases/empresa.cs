namespace Modulo_Administracion.Clases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("empresa")]
    public partial class empresa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public empresa()
        {
            usuario_pedido = new HashSet<usuario_pedido>();
        }

        [Key]
        public int id_empresa { get; set; }

        [Required]
        [StringLength(100)]
        public string razon_social { get; set; }

        [Required]
        [StringLength(100)]
        public string nombre_fantasia { get; set; }

        [Required]
        [StringLength(15)]
        public string cuit { get; set; }

        [Required]
        [StringLength(50)]
        public string telefono { get; set; }

        [Required]
        [StringLength(50)]
        public string celular { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [StringLength(200)]
        public string direccion { get; set; }

        public int id_condicion_ante_iva { get; set; }

        public DateTime? fecha_inicio_actividad { get; set; }

        public virtual ttipo_condicion_iva ttipo_condicion_iva { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuario_pedido> usuario_pedido { get; set; }
    }
}
