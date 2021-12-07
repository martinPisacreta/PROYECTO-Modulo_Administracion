namespace Modulo_Administracion.Clases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class usuario_pedido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usuario_pedido()
        {
            usuario_pedido_detalle = new HashSet<usuario_pedido_detalle>();
        }

        [Key]
        public int id_usuario_pedido { get; set; }

        public DateTime fecha_pedido { get; set; }

        public int id_usuario { get; set; }

        public int id_empresa { get; set; }

        [Column(TypeName = "numeric")]
        public decimal total { get; set; }

        public virtual empresa empresa { get; set; }

        public virtual usuario usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuario_pedido_detalle> usuario_pedido_detalle { get; set; }
    }
}
