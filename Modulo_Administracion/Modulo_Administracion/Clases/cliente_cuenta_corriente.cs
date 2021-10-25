namespace Modulo_Administracion.Clases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cliente_cuenta_corriente
    {
        [Key]
        public int id_cliente_cuenta_corriente { get; set; }

        public int id_cliente { get; set; }

        public int? id_factura { get; set; }

        public DateTime? fecha_factura_vieja { get; set; }

        public long? nro_factura_vieja { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? cod_tipo_factura_vieja { get; set; }

        public decimal? imp_factura { get; set; }

        public decimal? pago_1 { get; set; }

        public decimal? pago_2 { get; set; }

        public decimal? pago_3 { get; set; }

        public decimal? pago_4 { get; set; }

        public DateTime? pago_1_fecha { get; set; }

        public DateTime? pago_2_fecha { get; set; }

        public DateTime? pago_3_fecha { get; set; }

        public DateTime? pago_4_fecha { get; set; }

        [StringLength(500)]
        public string observacion { get; set; }
    }
}
