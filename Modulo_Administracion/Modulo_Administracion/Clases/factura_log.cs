namespace Modulo_Administracion.Clases
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class factura_log
    {
        [Key]
        public int id_factura_log { get; set; }

        public int id_factura { get; set; }

        public int id_cliente { get; set; }

        [Column(TypeName = "numeric")]
        public decimal cod_tipo_factura { get; set; }

        public DateTime fecha { get; set; }

        public long nro_factura { get; set; }

        public decimal precio_final { get; set; }

        public int sn_modifica_precio_final { get; set; }

        public decimal precio_final_con_pago_mayor_a_30_dias { get; set; }

        public decimal precio_final_con_pago_menor_a_30_dias { get; set; }

        public decimal precio_final_con_pago_menor_a_7_dias { get; set; }

        public int sn_emitida { get; set; }

        [StringLength(500)]
        public string observacion { get; set; }

        public int sn_mostrar_pago_mayor_30_dias { get; set; }

        public int sn_mostrar_pago_menor_7_dias { get; set; }

        public int sn_mostrar_pago_menor_30_dias { get; set; }

        public int id_condicion_factura { get; set; }

        public DateTime? fecha_sn_emitida { get; set; }

        [StringLength(1500)]
        public string path_factura { get; set; }

        public DateTime fecha_log { get; set; }

        [Required]
        [StringLength(50)]
        public string accion { get; set; }
    }
}
