namespace Modulo_Administracion.Clases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("usuario")]
    public partial class usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usuario()
        {
            usuario_pedido = new HashSet<usuario_pedido>();
        }

        [Key]
        public int id_usuario { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [StringLength(200)]
        public string password { get; set; }

        [Required]
        [StringLength(50)]
        public string razon_social { get; set; }

        [Required]
        [StringLength(50)]
        public string cuit { get; set; }

        public bool? acepta_terminos { get; set; }

        [Required]
        [StringLength(50)]
        public string rol { get; set; }

        [StringLength(3000)]
        public string token_verificacion { get; set; }

        public bool? usuario_verificado { get; set; }

        [StringLength(3000)]
        public string token_reseteo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? token_reseteo_fecha_expiracion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_creacion_usuario { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_ultima_modificacion_usuario { get; set; }

        [Required]
        [StringLength(50)]
        public string telefono { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string apellido { get; set; }

        [Required]
        [StringLength(200)]
        public string direccion_valor { get; set; }

        [Required]
        [StringLength(200)]
        public string direccion_descripcion { get; set; }

        [Required]
        [StringLength(200)]
        public string lat { get; set; }

        [Required]
        [StringLength(200)]
        public string lng { get; set; }

        public int utilidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuario_pedido> usuario_pedido { get; set; }
    }
}
