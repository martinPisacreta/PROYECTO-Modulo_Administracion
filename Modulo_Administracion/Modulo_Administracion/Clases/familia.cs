namespace Modulo_Administracion.Clases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("familia")]
    public partial class familia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public familia()
        {
            articulo = new HashSet<articulo>();
            articulo_historico = new HashSet<articulo_historico>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_tabla_familia { get; set; }

        public int id_familia { get; set; }

        public int id_tabla_marca { get; set; }

        [Required]
        [StringLength(255)]
        public string txt_desc_familia { get; set; }

        public int sn_activo { get; set; }

        public DateTime fec_ult_modif { get; set; }

        [Required]
        [StringLength(100)]
        public string accion { get; set; }

        [StringLength(400)]
        public string path_img { get; set; }

        public decimal algoritmo_1 { get; set; }

        public decimal algoritmo_2 { get; set; }

        public decimal algoritmo_3 { get; set; }

        public decimal algoritmo_4 { get; set; }

        public decimal algoritmo_5 { get; set; }

        public decimal algoritmo_6 { get; set; }

        public decimal algoritmo_7 { get; set; }

        public decimal algoritmo_8 { get; set; }

        public decimal algoritmo_9 { get; set; }

        public decimal algoritmo_10 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<articulo> articulo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<articulo_historico> articulo_historico { get; set; }

        public virtual marca marca { get; set; }
    }
}
