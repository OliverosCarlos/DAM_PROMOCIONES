﻿using System;
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
            public string IdPromocion { get; set; }
            [StringLength(20)]
            public string DesPromocion { get; set; }
            public DateTime FechaExpiraIni { get; set; }
            public DateTime FechaExpiraFin { get; set; }
            [StringLength(20)]
            public string Valor { get; set; }
            [StringLength(1)]
            public char Activo { get; set; }
            [StringLength(1)]
            public char Borrado { get; set; }
            public Nullable<DateTime> FechaReg { get; set; }
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
            public Int16 IdTipoAplicaA { get; set; }// fk de cat_generales
            public cat_generales cat_generales { get; set; }
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
            public string IdPromocion { get; set; }
            public ce_cat_promociones ce_cat_promociones { get; set; }
            [StringLength(50)]
            public string Valor { get; set; }
        }
        public class ce_cat_promociones_cantidad_fisica
        {
            [StringLength(20)]
            public string IdPromocion { get; set; }// fk de ce_cat_promociones
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
            public Int16 idTipoDescuento { get; set; }// fk de cat_generales
            public cat_tipo_generales cat_tipo_generales { get; set; }

        }
        public class ce_cat_promo_prod_serv
        {

            public int IdProdServ { get; set; }//fk de ce_cat_prod_serv_presenta
            [StringLength(20)]
            public string IdPromocion { get; set; }
            public ce_cat_promociones ce_cat_promociones { get; set; }// fk de ce_cat_promociones
            [StringLength(20)]
            public string IdPresentacion { get; set; }//fk de ce_cat_prod_serv_presenta
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
        public class cat_tipo_generales
        {
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

        }
        
        }
    }