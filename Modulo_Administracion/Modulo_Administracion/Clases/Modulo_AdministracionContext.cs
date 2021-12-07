using System.Data.Entity;

namespace Modulo_Administracion.Clases
{
    public partial class Modulo_AdministracionContext : DbContext
    {
        public Modulo_AdministracionContext()
            : base("name=Modulo_AdministracionContext")
        {
        }

        public virtual DbSet<articulo> articulo { get; set; }
        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<cliente_cuenta_corriente> cliente_cuenta_corriente { get; set; }
        public virtual DbSet<cliente_datos> cliente_datos { get; set; }
        public virtual DbSet<cliente_dir> cliente_dir { get; set; }
        public virtual DbSet<empresa> empresa { get; set; }
        public virtual DbSet<factura> factura { get; set; }
        public virtual DbSet<factura_detalle> factura_detalle { get; set; }
        public virtual DbSet<factura_detalle_log> factura_detalle_log { get; set; }
        public virtual DbSet<factura_log> factura_log { get; set; }
        public virtual DbSet<familia> familia { get; set; }
        public virtual DbSet<marca> marca { get; set; }
        public virtual DbSet<proveedor> proveedor { get; set; }
        public virtual DbSet<proveedor_datos> proveedor_datos { get; set; }
        public virtual DbSet<proveedor_dir> proveedor_dir { get; set; }
        public virtual DbSet<tcalle> tcalle { get; set; }
        public virtual DbSet<tmunicipio> tmunicipio { get; set; }
        public virtual DbSet<tpais> tpais { get; set; }
        public virtual DbSet<tprovincia> tprovincia { get; set; }
        public virtual DbSet<ttipo_calle> ttipo_calle { get; set; }
        public virtual DbSet<ttipo_cliente> ttipo_cliente { get; set; }
        public virtual DbSet<ttipo_condicion_factura> ttipo_condicion_factura { get; set; }
        public virtual DbSet<ttipo_condicion_iva> ttipo_condicion_iva { get; set; }
        public virtual DbSet<ttipo_condicion_pago> ttipo_condicion_pago { get; set; }
        public virtual DbSet<ttipo_dato> ttipo_dato { get; set; }
        public virtual DbSet<ttipo_dir> ttipo_dir { get; set; }
        public virtual DbSet<ttipo_factura> ttipo_factura { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
        public virtual DbSet<usuario_pedido> usuario_pedido { get; set; }
        public virtual DbSet<usuario_pedido_detalle> usuario_pedido_detalle { get; set; }
        public virtual DbSet<vendedor> vendedor { get; set; }
        public virtual DbSet<articulo_historico> articulo_historico { get; set; }
        public virtual DbSet<articulo_tmp_errores> articulo_tmp_errores { get; set; }
        public virtual DbSet<log_tarea_programada> log_tarea_programada { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<articulo>()
                .Property(e => e.precio_lista)
                .HasPrecision(18, 4);

            modelBuilder.Entity<cliente>()
                .HasMany(e => e.cliente_datos)
                .WithRequired(e => e.cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cliente>()
                .HasMany(e => e.cliente_dir)
                .WithRequired(e => e.cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cliente>()
                .HasMany(e => e.factura)
                .WithRequired(e => e.cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cliente_cuenta_corriente>()
                .Property(e => e.cod_tipo_factura_vieja)
                .HasPrecision(2, 0);

            modelBuilder.Entity<cliente_datos>()
                .Property(e => e.cod_tipo_dato)
                .HasPrecision(2, 0);

            modelBuilder.Entity<cliente_datos>()
                .Property(e => e.txt_dato_cliente)
                .IsUnicode(false);

            modelBuilder.Entity<cliente_dir>()
                .Property(e => e.cod_tipo_dir)
                .HasPrecision(2, 0);

            modelBuilder.Entity<cliente_dir>()
                .Property(e => e.cod_tipo_calle)
                .HasPrecision(3, 0);

            modelBuilder.Entity<cliente_dir>()
                .Property(e => e.cod_calle)
                .HasPrecision(5, 0);

            modelBuilder.Entity<cliente_dir>()
                .Property(e => e.txt_numero)
                .IsUnicode(false);

            modelBuilder.Entity<cliente_dir>()
                .Property(e => e.txt_apto)
                .IsUnicode(false);

            modelBuilder.Entity<cliente_dir>()
                .Property(e => e.txt_piso)
                .IsUnicode(false);

            modelBuilder.Entity<cliente_dir>()
                .Property(e => e.txt_direccion)
                .IsUnicode(false);

            modelBuilder.Entity<cliente_dir>()
                .Property(e => e.txt_cod_postal)
                .IsUnicode(false);

            modelBuilder.Entity<cliente_dir>()
                .Property(e => e.cod_pais)
                .HasPrecision(2, 0);

            modelBuilder.Entity<cliente_dir>()
                .Property(e => e.cod_provincia)
                .HasPrecision(3, 0);

            modelBuilder.Entity<cliente_dir>()
                .Property(e => e.cod_municipio)
                .HasPrecision(6, 0);

            modelBuilder.Entity<empresa>()
                .HasMany(e => e.usuario_pedido)
                .WithRequired(e => e.empresa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<factura>()
                .Property(e => e.cod_tipo_factura)
                .HasPrecision(2, 0);

            modelBuilder.Entity<factura>()
                .HasMany(e => e.factura_detalle)
                .WithRequired(e => e.factura)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<factura_detalle>()
                .Property(e => e.precio_lista_x_coeficiente)
                .HasPrecision(18, 4);

            modelBuilder.Entity<factura_detalle>()
                .Property(e => e.iva)
                .HasPrecision(18, 4);

            modelBuilder.Entity<factura_detalle_log>()
                .Property(e => e.precio_lista_x_coeficiente)
                .HasPrecision(18, 4);

            modelBuilder.Entity<factura_detalle_log>()
                .Property(e => e.iva)
                .HasPrecision(18, 4);

            modelBuilder.Entity<factura_log>()
                .Property(e => e.cod_tipo_factura)
                .HasPrecision(2, 0);

            modelBuilder.Entity<familia>()
                .Property(e => e.algoritmo_1)
                .HasPrecision(18, 4);

            modelBuilder.Entity<familia>()
                .Property(e => e.algoritmo_2)
                .HasPrecision(18, 4);

            modelBuilder.Entity<familia>()
                .Property(e => e.algoritmo_3)
                .HasPrecision(18, 4);

            modelBuilder.Entity<familia>()
                .Property(e => e.algoritmo_4)
                .HasPrecision(18, 4);

            modelBuilder.Entity<familia>()
                .Property(e => e.algoritmo_5)
                .HasPrecision(18, 4);

            modelBuilder.Entity<familia>()
                .Property(e => e.algoritmo_6)
                .HasPrecision(18, 4);

            modelBuilder.Entity<familia>()
                .Property(e => e.algoritmo_7)
                .HasPrecision(18, 4);

            modelBuilder.Entity<familia>()
                .Property(e => e.algoritmo_8)
                .HasPrecision(18, 4);

            modelBuilder.Entity<familia>()
                .Property(e => e.algoritmo_9)
                .HasPrecision(18, 4);

            modelBuilder.Entity<familia>()
                .Property(e => e.algoritmo_10)
                .HasPrecision(18, 4);

            modelBuilder.Entity<marca>()
                .HasMany(e => e.familia)
                .WithRequired(e => e.marca)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<proveedor>()
                .HasMany(e => e.marca)
                .WithRequired(e => e.proveedor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<proveedor>()
                .HasMany(e => e.proveedor_datos)
                .WithRequired(e => e.proveedor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<proveedor>()
                .HasMany(e => e.proveedor_dir)
                .WithRequired(e => e.proveedor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<proveedor_datos>()
                .Property(e => e.cod_tipo_dato)
                .HasPrecision(2, 0);

            modelBuilder.Entity<proveedor_datos>()
                .Property(e => e.txt_dato_proveedor)
                .IsUnicode(false);

            modelBuilder.Entity<proveedor_dir>()
                .Property(e => e.cod_tipo_dir)
                .HasPrecision(2, 0);

            modelBuilder.Entity<proveedor_dir>()
                .Property(e => e.cod_tipo_calle)
                .HasPrecision(3, 0);

            modelBuilder.Entity<proveedor_dir>()
                .Property(e => e.cod_calle)
                .HasPrecision(5, 0);

            modelBuilder.Entity<proveedor_dir>()
                .Property(e => e.txt_numero)
                .IsUnicode(false);

            modelBuilder.Entity<proveedor_dir>()
                .Property(e => e.txt_apto)
                .IsUnicode(false);

            modelBuilder.Entity<proveedor_dir>()
                .Property(e => e.txt_piso)
                .IsUnicode(false);

            modelBuilder.Entity<proveedor_dir>()
                .Property(e => e.txt_direccion)
                .IsUnicode(false);

            modelBuilder.Entity<proveedor_dir>()
                .Property(e => e.txt_cod_postal)
                .IsUnicode(false);

            modelBuilder.Entity<proveedor_dir>()
                .Property(e => e.cod_pais)
                .HasPrecision(2, 0);

            modelBuilder.Entity<proveedor_dir>()
                .Property(e => e.cod_provincia)
                .HasPrecision(3, 0);

            modelBuilder.Entity<proveedor_dir>()
                .Property(e => e.cod_municipio)
                .HasPrecision(6, 0);

            modelBuilder.Entity<tcalle>()
                .Property(e => e.cod_calle)
                .HasPrecision(5, 0);

            modelBuilder.Entity<tcalle>()
                .Property(e => e.txt_desc)
                .IsUnicode(false);

            modelBuilder.Entity<tmunicipio>()
                .Property(e => e.cod_municipio)
                .HasPrecision(6, 0);

            modelBuilder.Entity<tmunicipio>()
                .Property(e => e.cod_provincia)
                .HasPrecision(3, 0);

            modelBuilder.Entity<tmunicipio>()
                .Property(e => e.cod_pais)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tmunicipio>()
                .Property(e => e.cod_divipola)
                .HasPrecision(6, 0);

            modelBuilder.Entity<tmunicipio>()
                .HasMany(e => e.cliente_dir)
                .WithRequired(e => e.tmunicipio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tmunicipio>()
                .HasMany(e => e.proveedor_dir)
                .WithRequired(e => e.tmunicipio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tpais>()
                .Property(e => e.cod_pais)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tpais>()
                .Property(e => e.txt_desc)
                .IsUnicode(false);

            modelBuilder.Entity<tpais>()
                .HasMany(e => e.cliente_dir)
                .WithRequired(e => e.tpais)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tpais>()
                .HasMany(e => e.proveedor_dir)
                .WithRequired(e => e.tpais)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tpais>()
                .HasMany(e => e.tmunicipio)
                .WithRequired(e => e.tpais)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tpais>()
                .HasMany(e => e.tprovincia)
                .WithRequired(e => e.tpais)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tprovincia>()
                .Property(e => e.cod_provincia)
                .HasPrecision(3, 0);

            modelBuilder.Entity<tprovincia>()
                .Property(e => e.cod_pais)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tprovincia>()
                .Property(e => e.txt_desc)
                .IsUnicode(false);

            modelBuilder.Entity<tprovincia>()
                .HasMany(e => e.tmunicipio)
                .WithRequired(e => e.tprovincia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ttipo_calle>()
                .Property(e => e.cod_tipo_calle)
                .HasPrecision(3, 0);

            modelBuilder.Entity<ttipo_calle>()
                .Property(e => e.txt_desc)
                .IsUnicode(false);

            modelBuilder.Entity<ttipo_cliente>()
                .HasMany(e => e.cliente)
                .WithRequired(e => e.ttipo_cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ttipo_condicion_factura>()
                .HasMany(e => e.cliente)
                .WithRequired(e => e.ttipo_condicion_factura)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ttipo_condicion_factura>()
                .HasMany(e => e.factura)
                .WithRequired(e => e.ttipo_condicion_factura)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ttipo_condicion_iva>()
                .HasMany(e => e.empresa)
                .WithRequired(e => e.ttipo_condicion_iva)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ttipo_dato>()
                .Property(e => e.cod_tipo_dato)
                .HasPrecision(2, 0);

            modelBuilder.Entity<ttipo_dato>()
                .Property(e => e.txt_desc)
                .IsUnicode(false);

            modelBuilder.Entity<ttipo_dato>()
                .HasMany(e => e.cliente_datos)
                .WithRequired(e => e.ttipo_dato)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ttipo_dato>()
                .HasMany(e => e.proveedor_datos)
                .WithRequired(e => e.ttipo_dato)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ttipo_dir>()
                .Property(e => e.cod_tipo_dir)
                .HasPrecision(2, 0);

            modelBuilder.Entity<ttipo_dir>()
                .Property(e => e.txt_desc)
                .IsUnicode(false);

            modelBuilder.Entity<ttipo_dir>()
                .HasMany(e => e.cliente_dir)
                .WithRequired(e => e.ttipo_dir)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ttipo_dir>()
                .HasMany(e => e.proveedor_dir)
                .WithRequired(e => e.ttipo_dir)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ttipo_factura>()
                .Property(e => e.cod_tipo_factura)
                .HasPrecision(2, 0);

            modelBuilder.Entity<ttipo_factura>()
                .Property(e => e.txt_desc)
                .IsUnicode(false);

            modelBuilder.Entity<ttipo_factura>()
                .Property(e => e.letra)
                .IsFixedLength();

            modelBuilder.Entity<ttipo_factura>()
                .HasMany(e => e.factura)
                .WithRequired(e => e.ttipo_factura)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.token_verificacion)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.token_reseteo)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .HasMany(e => e.usuario_pedido)
                .WithRequired(e => e.usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<usuario_pedido>()
                .HasMany(e => e.usuario_pedido_detalle)
                .WithRequired(e => e.usuario_pedido)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<articulo_historico>()
                .Property(e => e.precio_lista)
                .HasPrecision(18, 4);
        }
    }
}
