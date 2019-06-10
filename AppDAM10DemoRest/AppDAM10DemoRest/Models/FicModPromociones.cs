using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AppDAM10DemoRest.Models
{
    public class FicModPromociones 
    {

        public class ce_cat_promociones
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            [StringLength(20)]
            public string IdPromocion { get; set; }
            [StringLength(20)]
            public string DesPromocion { get; set; }
            [StringLength(20)]
            public string FechaExpiraIni { get; set; }
            [StringLength(20)]
            public string FechaExpiraFin { get; set; }
            [StringLength(20)]
            public string Valor { get; set; }
            [StringLength(20)]
            public string Activo { get; set; }
            [StringLength(20)]
            public string Borrado { get; set; }
            [StringLength(20)]
            public string FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            [StringLength(20)]
            public string FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(20)]
            public string IdTipoPromocion { get; set; }//fk de cat_generales
            [StringLength(20)]
            public string IdTipoDescuento { get; set; }//fk de cat_generales

        }
        public class ce_cat_promociones_aplica_a
        {
            //[DatabaseGenerated(DatabaseGeneratedOption.None)]
            [StringLength(20)]
            public string IdTipoAplicaA { get; set; }// fk de cat_generales
            [StringLength(20)]
            public string Activo { get; set; }
            [StringLength(20)]
            public string Borrado { get; set; }
            [StringLength(20)]
            public string FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            [StringLength(20)]
            public string FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(20)]
            public string IdPromocion { get; set; }// fk de ce_cat_promociones
            [StringLength(20)]
            public string Valor { get; set; }
        }
        public class ce_cat_promociones_cantidad_fisica
        {
            //[DatabaseGenerated(DatabaseGeneratedOption.None)]
            [StringLength(20)]
            public string IdPromocion { get; set; }// fk de ce_cat_promociones
            public ce_cat_promociones ce_cat_promociones { get; set; }
            [StringLength(20)]
            public string Valor { get; set; }
            [StringLength(20)]
            public string ValorAcumulado { get; set; }
            [StringLength(20)]
            public string Activo { get; set; }
            [StringLength(20)]
            public string Borrado { get; set; }
            [StringLength(20)]
            public string FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            [StringLength(20)]
            public string FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(20)]
            public string idTipoDescuento { get; set; }// fk de cat_generales

        }
        public class ce_cat_promo_prod_serv
        {
            //[DatabaseGenerated(DatabaseGeneratedOption.None)]
            [StringLength(20)]
            public string IdProdServ { get; set; }//fk de ce_cat_prod_serv_presenta
            [StringLength(20)]
            public string IdPresentacion { get; set; }//fk de ce_cat_prod_serv_presenta
            [StringLength(20)]
            public string IdPromocion { get; set; }
            public ce_cat_promociones ce_cat_promociones { get; set; }// fk de ce_cat_promociones
            [StringLength(20)]
            public string Activo { get; set; }
            [StringLength(20)]
            public string Borrado { get; set; }
            [StringLength(20)]
            public string FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            [StringLength(20)]
            public string FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }

        }
        public class cat_tipo_generales2
        {
            //[DatabaseGenerated(DatabaseGeneratedOption.None)]
            [StringLength(20)]
            public string IdTipoGeneral { get; set; }
            [StringLength(20)]
            public string DesTipoGeneral { get; set; }
            [StringLength(20)]
            public string Activo { get; set; }
            [StringLength(20)]
            public string Borrado { get; set; }
            [StringLength(20)]
            public string FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            [StringLength(20)]
            public string FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }

        }
        public class cat_generales
        {
            //[DatabaseGenerated(DatabaseGeneratedOption.None)]
            [StringLength(20)]
            public string IdGeneral { get; set; }
            [StringLength(20)]
            public string DesGeneral { get; set; }
            [StringLength(20)]
            public string Activo { get; set; }
            [StringLength(20)]
            public string Borrado { get; set; }
            [StringLength(20)]
            public string FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            [StringLength(20)]
            public string FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }

        }

        public class ce_cat_prod_serv2
        {
            [StringLength(20)]
            public string IdProdServ { get; set; }
            [StringLength(20)]
            public string Marca { get; set; }
            [StringLength(20)]
            public string Modelo { get; set; }
            [StringLength(20)]
            public string Activo { get; set; }
            [StringLength(20)]
            public string Borrado { get; set; }
            [StringLength(20)]
            public string FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            [StringLength(20)]
            public string FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(20)]
            public string PuntosXVenta { get; set; }
            [StringLength(20)]
            public string Depto { get; set; }
        }

    }
}