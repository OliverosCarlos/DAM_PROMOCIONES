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
            public int IdPromocion { get; set; }
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
            public string IdTipoPromocion { get; set; }
            public string IdTipoDescuento { get; set; }
        }
        public class ce_cat_promociones_aplica_a
        {
        }
        public class ce_cat_promociones_cantidad_fisica
        {
        }
        public class ce_cat_promo_prod_serv
        {
        }
    }
}