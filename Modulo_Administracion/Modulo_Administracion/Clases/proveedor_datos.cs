namespace Modulo_Administracion.Clases
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class proveedor_datos
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_proveedor { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal cod_tipo_dato { get; set; }

        [Required]
        [StringLength(500)]
        public string txt_dato_proveedor { get; set; }

        public int sn_activo { get; set; }

        public DateTime fec_ult_modif { get; set; }

        [Required]
        [StringLength(100)]
        public string accion { get; set; }

        public virtual proveedor proveedor { get; set; }

        public virtual ttipo_dato ttipo_dato { get; set; }
    }
}
