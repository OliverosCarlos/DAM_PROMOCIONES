using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static AppDAM10DemoRest.Models.FicModInventarios;
using static AppDAM10DemoRest.Models.FicModPromociones;



namespace AppDAM10DemoRest.Data
{
    public class FicDBContext : DbContext
    {
        public FicDBContext(DbContextOptions<FicDBContext> options) : base(options)
        {

        }//constructor

        protected async override void OnConfiguring(DbContextOptionsBuilder FicPaOptionsBuilder)
        {
            try
            {

            }
            catch (Exception e)
            {

            }
        }//config conection

        //inventarios
        public DbSet<zt_cat_estatus> zt_cat_estatus { get; set; }
        public DbSet<zt_inventarios> zt_inventarios { get; set; }
        public DbSet<zt_inventarios_acumulados> zt_inventarios_acumulados { get; set; }
        public DbSet<zt_inventarios_conteos> zt_inventarios_conteos { get; set; }
        //unidades medida
        public DbSet<zt_cat_grupos_sku> zt_cat_grupos_sku { get; set; }
        public DbSet<zt_cat_productos> zt_cat_productos { get; set; }
        public DbSet<zt_cat_unidad_medidas> zt_cat_unidad_medidas { get; set; }
        public DbSet<zt_cat_productos_medidas> zt_cat_productos_medidas { get; set; }
        //products
        public DbSet<ce_cat_prod_serv2> ce_cat_prod_serv2 { get; set; }

        //

        public DbSet<zt_cat_cedis> zt_cat_cedis { get; set; }
        public DbSet<zt_cat_almacenes> zt_cat_almacenes { get; set; }
        public DbSet<zt_cat_ubicaciones> zt_cat_ubicaciones { get; set; }
        public DbSet<zt_almacenes_ubicaciones> zt_almacenes_ubicaciones { get; set; }
        //promociones
        public DbSet<ce_cat_promociones> ce_cat_promociones { get; set; }
        public DbSet<ce_cat_promociones_aplica_a> ce_cat_promociones_aplica_a { get; set; }
        public DbSet<ce_cat_promociones_cantidad_fisica> ce_cat_promociones_cantidad_fisica { get; set; }
        public DbSet<ce_cat_promo_prod_serv> ce_cat_promo_prod_serv { get; set; }
        //public DbSet<cat_tipo_generales> cat_tipo_generales { get; set; }
        //public DbSet<cat_generales> cat_generales { get; set; }

        protected async override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                //      *** LLAVES PRIMARIAS ***     //
                //PRODUCTS
                modelBuilder.Entity<ce_cat_prod_serv2>().HasKey(c => new { c.IdProdServ });
                //INVENTARIOS
                modelBuilder.Entity<zt_cat_cedis>().HasKey(c => new { c.IdCEDI });
                modelBuilder.Entity<zt_cat_almacenes>().HasKey(c => new { c.IdAlmacen });
                modelBuilder.Entity<zt_inventarios_acumulados>().HasKey(a => new { a.IdInventario, a.IdSKU, a.IdUnidadMedida });
                modelBuilder.Entity<zt_almacenes_ubicaciones>().HasKey(c => new { c.IdAlmacen, c.IdUbicacion });
                modelBuilder.Entity<zt_cat_estatus>().HasKey(c => new { c.IdEstatus });
                modelBuilder.Entity<zt_cat_grupos_sku>().HasKey(c => new { c.IdGrupoSKU });
                modelBuilder.Entity<zt_cat_productos>().HasKey(c => new { c.IdSKU });
                modelBuilder.Entity<zt_cat_productos_medidas>().HasKey(c => new { c.IdSKU, c.IdUMedidaBase });
                modelBuilder.Entity<zt_cat_ubicaciones>().HasKey(c => new { c.IdUbicacion });
                modelBuilder.Entity<zt_cat_unidad_medidas>().HasKey(c => new { c.IdUnidadMedida });
                modelBuilder.Entity<zt_inventarios>().HasKey(c => new { c.IdInventario });
                modelBuilder.Entity<zt_inventarios_conteos>().HasKey(c => new { c.IdInventario, c.IdSKU, c.IdUnidadMedida, c.IdAlmacen, c.IdUbicacion, c.NumConteo });

                //    ***  LLAVES FORANEAS  ***    //
                //INVENTARIOS
                modelBuilder.Entity<zt_cat_almacenes>().HasOne(b => b.zt_cat_cedis).WithMany().HasForeignKey(
                    b => new { b.IdCEDI });
                modelBuilder.Entity<zt_almacenes_ubicaciones>().HasOne(
                    b => b.zt_cat_almacenes).WithMany().HasForeignKey(
                    b => new { b.IdAlmacen });
                modelBuilder.Entity<zt_almacenes_ubicaciones>().HasOne(
                    b => b.zt_cat_ubicaciones).WithMany().HasForeignKey(
                    b => new { b.IdUbicacion });
                modelBuilder.Entity<zt_cat_productos_medidas>().HasOne(
                    b => b.zt_cat_productos).WithMany().HasForeignKey(
                    d => new { d.IdSKU });
                modelBuilder.Entity<zt_cat_productos_medidas>().HasOne(
                    b => b.zt_cat_unidad_medidas).WithMany().HasForeignKey(
                    d => new { d.IdUMedidaBase });
                modelBuilder.Entity<zt_cat_productos>().HasOne(
                    b => b.zt_cat_grupos_sku).WithMany().HasForeignKey(
                    d => new { d.IdGrupoSKU });
                modelBuilder.Entity<zt_cat_productos>().HasOne(
                    b => b.zt_cat_unidad_medidas).WithMany().HasForeignKey(
                    d => new { d.IdUMedidaBase });
                modelBuilder.Entity<zt_inventarios_conteos>().HasOne(
                    b => b.zt_cat_almacenes).WithMany().HasForeignKey(
                    d => new { d.IdAlmacen });
                modelBuilder.Entity<zt_inventarios_conteos>().HasOne(
                    b => b.zt_cat_productos).WithMany().HasForeignKey(
                    d => new { d.IdSKU });
                modelBuilder.Entity<zt_inventarios_conteos>().HasOne(
                    b => b.zt_cat_ubicaciones).WithMany().HasForeignKey(
                    d => new { d.IdUbicacion });
                modelBuilder.Entity<zt_inventarios_conteos>().HasOne(
                    b => b.zt_cat_unidad_medidas).WithMany().HasForeignKey(
                    d => new { d.IdUnidadMedida });
                modelBuilder.Entity<zt_inventarios_conteos>().HasOne(
                    b => b.zt_inventarios).WithMany().HasForeignKey(
                    d => new { d.IdInventario });
                modelBuilder.Entity<zt_inventarios_acumulados>().HasOne(
                    b => b.zt_inventarios).WithMany().HasForeignKey(
                    d => new { d.IdInventario });
                modelBuilder.Entity<zt_inventarios_acumulados>().HasOne(
                   b => b.zt_cat_productos).WithMany().HasForeignKey(
                   d => new { d.IdSKU });
                modelBuilder.Entity<zt_inventarios_acumulados>().HasOne(
                   b => b.zt_cat_unidad_medidas).WithMany().HasForeignKey(
                   d => new { d.IdUnidadMedida });
                modelBuilder.Entity<zt_inventarios>().HasOne(
                    b => b.zt_cat_almacenes).WithMany().HasForeignKey(
                    d => new { d.IdAlmacen });
                modelBuilder.Entity<zt_inventarios>().HasOne(
                    b => b.zt_cat_cedis).WithMany().HasForeignKey(
                    d => new { d.IdCEDI });
                modelBuilder.Entity<zt_inventarios>().HasOne(
                    b => b.zt_cat_estatus).WithMany().HasForeignKey(
                    d => new { d.IdEstatus });

                //      *** LLAVES PRIMARIAS ***     //
                //PROMOCIONES
                modelBuilder.Entity<zt_cat_almacenes>().HasKey(c => new { c.IdAlmacen });
                modelBuilder.Entity<zt_inventarios_acumulados>().HasKey(a => new { a.IdInventario, a.IdSKU, a.IdUnidadMedida });
                modelBuilder.Entity<zt_almacenes_ubicaciones>().HasKey(c => new { c.IdAlmacen, c.IdUbicacion });
                modelBuilder.Entity<zt_cat_estatus>().HasKey(c => new { c.IdEstatus });
                modelBuilder.Entity<zt_cat_grupos_sku>().HasKey(c => new { c.IdGrupoSKU });
                modelBuilder.Entity<zt_cat_productos>().HasKey(c => new { c.IdSKU });
                modelBuilder.Entity<zt_cat_productos_medidas>().HasKey(c => new { c.IdSKU, c.IdUMedidaBase });
                modelBuilder.Entity<zt_cat_ubicaciones>().HasKey(c => new { c.IdUbicacion });
                modelBuilder.Entity<zt_cat_unidad_medidas>().HasKey(c => new { c.IdUnidadMedida });
                modelBuilder.Entity<zt_inventarios>().HasKey(c => new { c.IdInventario });
                modelBuilder.Entity<zt_inventarios_conteos>().HasKey(c => new { c.IdInventario, c.IdSKU, c.IdUnidadMedida, c.IdAlmacen, c.IdUbicacion, c.NumConteo });


                //  Llaves Primarias//
                //Promociones
                modelBuilder.Entity<ce_cat_promociones>().HasKey(c => new { c.IdPromocion });
                modelBuilder.Entity<ce_cat_promociones_aplica_a>().HasKey(c => new { c.IdTipoAplicaA });
                modelBuilder.Entity<ce_cat_promociones_cantidad_fisica>().HasKey(c => new { c.IdPromocion });
                modelBuilder.Entity<ce_cat_promo_prod_serv>().HasKey(c => new { c.IdProdServ, c.IdPromocion, c.IdPresentacion });
                //modelBuilder.Entity<cat_tipo_generales>().HasKey(c => new { c.IdTipoGeneral });
                //modelBuilder.Entity<cat_generales>().HasKey( c => new { c.IdGeneral});
                //Llaves Foreanas
                //Promociones

                /*modelBuilder.Entity<ce_cat_promociones>().HasOne(
                    b => b.cat_tipo_generales).WithMany().HasForeignKey(
                    d => new { d.IdTipoPromocion });
                modelBuilder.Entity<ce_cat_promociones>().HasOne(
                    b => b.cat_generales).WithMany().HasForeignKey(
                    d => new { d.IdTipoDescuento });//idTipoDescuento*/

                /*modelBuilder.Entity<ce_cat_promociones_aplica_a>().HasOne(
                    b => b.ce_cat_promociones).WithMany().HasForeignKey(
                    d => new { d.IdPromocion });
                modelBuilder.Entity<ce_cat_promociones_aplica_a>().HasOne(
                    b => b.cat_tipo_generales).WithMany().HasForeignKey(
                    d => new { d.IdTipoAplicaA });*/

                modelBuilder.Entity<ce_cat_promociones_cantidad_fisica>().HasOne(
                    b => b.ce_cat_promociones).WithMany().HasForeignKey(
                    d => new { d.IdPromocion });
                /*modelBuilder.Entity<ce_cat_promociones_cantidad_fisica>().HasOne(
                    b => b.cat_tipo_generales).WithMany().HasForeignKey(
                    d => new { d.idTipoDescuento });*/

                modelBuilder.Entity<ce_cat_promo_prod_serv>().HasOne(
                    b => b.ce_cat_promociones).WithMany().HasForeignKey(
                    d => new { d.IdPromocion });

                /*modelBuilder.Entity<ce_cat_promo_prod_serv>().HasOne(
                    b => b.cat_generales).WithMany().HasForeignKey(
                    d => new { d.IdProdServ });

                modelBuilder.Entity<ce_cat_promo_prod_serv>().HasOne(
                    b => b.cat_tipo_generales).WithMany().HasForeignKey(
                    d => new { d.IdPresentacion });*/
               
            }

            catch (Exception e)
            {

            }

        }
    }
}




