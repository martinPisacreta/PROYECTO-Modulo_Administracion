namespace Modulo_Administracion.Clases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class articulo_historico
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_lista { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id_articulo { get; set; }

        [StringLength(100)]
        public string codigo_articulo_marca { get; set; }

        [StringLength(100)]
        public string codigo_articulo { get; set; }

        public string descripcion_articulo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? precio_lista { get; set; }

        public int? id_tabla_familia { get; set; }

        public int? sn_oferta { get; set; }

        [StringLength(200)]
        public string path_img { get; set; }

        public DateTime? fecha_ult_modif { get; set; }

        public DateTime? fec_baja { get; set; }

        [StringLength(50)]
        public string accion { get; set; }

        public int? stock { get; set; }

        public long? id_orden { get; set; }

        public virtual familia familia { get; set; }
    }
}
