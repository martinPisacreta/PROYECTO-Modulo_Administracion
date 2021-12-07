namespace Modulo_Administracion.Clases
{
    using System.ComponentModel.DataAnnotations;

    public partial class articulo_tmp_errores
    {
        [StringLength(255)]
        public string codigo_articulo_marca { get; set; }

        [StringLength(255)]
        public string codigo_articulo { get; set; }

        [StringLength(400)]
        public string descripcion_articulo { get; set; }

        public double? precio_lista { get; set; }

        public double? precio_final { get; set; }

        public double? id_tabla_familia { get; set; }

        public double? sn_oferta { get; set; }

        [StringLength(400)]
        public string path_img { get; set; }

        public long? id_articulo { get; set; }

        public int? stock { get; set; }

        public long? id_orden { get; set; }

        [Key]
        [StringLength(255)]
        public string observacion { get; set; }
    }
}
