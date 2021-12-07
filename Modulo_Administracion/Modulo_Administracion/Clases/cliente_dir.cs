namespace Modulo_Administracion.Clases
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class cliente_dir
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_cliente { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal cod_tipo_dir { get; set; }

        public int cod_clase_dir { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? cod_tipo_calle { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? cod_calle { get; set; }

        [StringLength(5)]
        public string txt_numero { get; set; }

        [StringLength(5)]
        public string txt_apto { get; set; }

        [StringLength(3)]
        public string txt_piso { get; set; }

        [StringLength(250)]
        public string txt_direccion { get; set; }

        [StringLength(8)]
        public string txt_cod_postal { get; set; }

        [Column(TypeName = "numeric")]
        public decimal cod_pais { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? cod_provincia { get; set; }

        [Column(TypeName = "numeric")]
        public decimal cod_municipio { get; set; }

        public int sn_activo { get; set; }

        public DateTime? fec_ult_modif { get; set; }

        [StringLength(100)]
        public string accion { get; set; }

        public virtual cliente cliente { get; set; }

        public virtual ttipo_dir ttipo_dir { get; set; }

        public virtual tpais tpais { get; set; }

        public virtual tprovincia tprovincia { get; set; }

        public virtual tcalle tcalle { get; set; }

        public virtual tmunicipio tmunicipio { get; set; }

        public virtual ttipo_calle ttipo_calle { get; set; }
    }
}
