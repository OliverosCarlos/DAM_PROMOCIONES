using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PROMOCIONES.Models
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

    public class grid_promociones
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
        public string IdTipoPromocion { get; set; }//fk de cat_generales
        [StringLength(20)]
        public string IdTipoDescuento { get; set; }//fk de cat_generales
    }
    public class ce_cat_promociones_post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string idpromocion { get; set; }
        [StringLength(20)]
        public string DesPromocion { get; set; }
        public Nullable<DateTime> FechaExpiraIni { get; set; }
        public Nullable<DateTime> FechaExpiraFin { get; set; }
        [StringLength(20)]
        public string Valor { get; set; }
        [StringLength(1)]
        public char Activo { get; set; }
        [StringLength(1)]
        public char Borrado { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        public int IdTipoPromocion { get; set; }//fk de cat_generales
        public int IdTipoDescuento { get; set; }//fk de cat_generales

    }
    public class ce_cat_promociones_aplica_a
        {
            //[DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int IdTipoAplicaA { get; set; }// fk de cat_generales
            [StringLength(20)]
            public char Activo { get; set; }
            [StringLength(1)]
            public char Borrado { get; set; }
            [StringLength(1)]
            public Nullable<DateTime> FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            [StringLength(20)]
            public string IdPromocion { get; set; }// fk de ce_cat_promociones
            [StringLength(50)]
            public string Valor { get; set; }
        }
        public class ce_cat_promociones_cantidad_fisica
        {
            //[DatabaseGenerated(DatabaseGeneratedOption.None)]
            [StringLength(20)]
            public string IdPromocion { get; set; }// fk de ce_cat_promociones
            public ce_cat_promociones ce_cat_promociones { get; set; }
            public int Valor { get; set; }
            public int ValorAcumulado { get; set; }
            public char Activo { get; set; }
            [StringLength(1)]
            public char Borrado { get; set; }
            [StringLength(1)]
            public Nullable<DateTime> FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
            public int idTipoDescuento { get; set; }// fk de cat_generales

        }
        public class ce_cat_promo_prod_serv
        {
            //[DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int IdProdServ { get; set; }//fk de ce_cat_prod_serv_presenta
            [StringLength(20)]
            public string IdPresentacion { get; set; }//fk de ce_cat_prod_serv_presenta
            [StringLength(20)]
            public string IdPromocion { get; set; }
            public ce_cat_promociones ce_cat_promociones { get; set; }// fk de ce_cat_promociones
            [StringLength(20)]
            public char Activo { get; set; }
            [StringLength(1)]
            public char Borrado { get; set; }
            [StringLength(1)]
            public Nullable<DateTime> FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }

        }
    /*public class cat_tipo_generales
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdTipoGeneral { get; set; }
        [StringLength(50)]
        public string DesTipoGeneral { get; set; }
        public char Activo { get; set; }
        [StringLength(1)]
        public char Borrado { get; set; }
        [StringLength(1)]
        public Nullable<DateTime> FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }

    }
    public class cat_generales
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdGeneral { get; set; }
        [StringLength(50)]
        public string DesGeneral { get; set; }
        public char Activo { get; set; }
        [StringLength(1)]
        public char Borrado { get; set; }
        [StringLength(1)]
        public Nullable<DateTime> FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }

    }*/
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

    public class grid_prod_serv
    {
        [StringLength(20)]
        public string IdProdServ { get; set; }
        [StringLength(20)]
        public string Marca { get; set; }
        [StringLength(20)]
        public string Modelo { get; set; }
        [StringLength(20)]
        public string PuntosXVenta { get; set; }
        [StringLength(20)]
        public string Depto { get; set; }
    }

}
