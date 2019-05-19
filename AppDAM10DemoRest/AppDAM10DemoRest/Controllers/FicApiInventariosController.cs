using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDAM10DemoRest.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static AppDAM10DemoRest.Models.FicModInventarios;
using static AppDAM10DemoRest.Models.FicModPromociones;

namespace AppDAM10DemoRest.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class FicApiInventariosController : ControllerBase
    {
        private readonly FicDBContext FicLoDBContext;

        public FicApiInventariosController(FicDBContext context)
        {
            this.FicLoDBContext = context;
        }
        
        //RUTAS INVENTARIOS- ===================================================================================

        [HttpGet]
        [Route("/api/inventarios/listar")]
        public async Task<IActionResult> FicApiGetListInventarios([FromQuery]int idinventario)
        {

            var zt_inventarios = (from data_inv in FicLoDBContext.zt_inventarios where data_inv.IdInventario == idinventario select data_inv).ToList();
            if (zt_inventarios.Count() > 0)
            {
                zt_inventarios = zt_inventarios.ToList();
                return Ok(zt_inventarios);
            }
            else
            {
                zt_inventarios = zt_inventarios.ToList();
                return Ok(zt_inventarios);
            }
        }
        [HttpGet]
        [Route("/api/inventarios")]
        public async Task<IActionResult> FicApiGetListInventarios()
        {
            var zt_inventarios = (from data_inv in FicLoDBContext.zt_inventarios select data_inv).ToList();
            if (zt_inventarios.Count() > 0)
            {
                zt_inventarios = zt_inventarios.ToList();
                return Ok(zt_inventarios);
            }
            else
            {
                zt_inventarios = zt_inventarios.ToList();
                return Ok(zt_inventarios);
            }
        }
        [HttpPost]
        [Route("/api/inventarios")]
        public async Task<IActionResult> FicApiNewInventario([FromForm] int id, [FromForm]short cedi, [FromForm]string sap, [FromForm] DateTime fecha, [FromForm] string user)
        {
            zt_inventarios inventario = new zt_inventarios();
            inventario.IdInventario = id;
            inventario.IdCEDI = cedi;
            inventario.IdInventarioSAP = sap;
            inventario.FechaReg = fecha;
            inventario.UsuarioReg = user;
            inventario.Activo = "S";
            inventario.Borrado = "N";
            FicLoDBContext.zt_inventarios.Add(inventario);
            FicLoDBContext.SaveChanges();
            return Ok(inventario);

        }
        [HttpDelete]
        [Route("/api/inventarios")]
        public async Task<IActionResult> FicApiDeleteInventario([FromQuery] int id)
        {
            zt_inventarios inventario = new zt_inventarios();
            inventario.IdInventario = id;
            try
            {
                FicLoDBContext.zt_inventarios.Remove(inventario);
                FicLoDBContext.SaveChanges();
                return Ok(inventario);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "No se encontraron registros");
                return Ok(err);
            }
        }
        [HttpPut]
        [Route("/api/inventarios")]
        public async Task<IActionResult> FicApiUpdateInventario([FromForm] int id, [FromForm]string sap, [FromForm] DateTime fecha, [FromForm] string user)
        {
            try
            {
                var inventario = FicLoDBContext.zt_inventarios.First(a => a.IdInventario == id);
                inventario.IdInventario = id;
                inventario.IdInventarioSAP = sap;
                inventario.FechaUltMod = fecha;
                inventario.UsuarioMod = user;
                inventario.Activo = "N";
                inventario.Borrado = "S";
                FicLoDBContext.SaveChanges();
                return Ok(inventario);
            }
            catch (Exception e)
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "No se encontraron registros");
                return Ok(err);
            }
        }

        //RUTAS PROMOCIONES ===================================================================================

        [HttpGet]
        [Route("/api/promociones/listar")]
        public async Task<IActionResult> FicApiGetListPromociones([FromQuery]string idpromocion)
        {

            var ce_promociones = (from data_promo in FicLoDBContext.ce_cat_promociones where data_promo.IdPromocion == idpromocion select data_promo).ToList();
            if (ce_promociones.Count() > 0)
            {
                ce_promociones = ce_promociones.ToList();
                return Ok(ce_promociones);
            }
            else
            {
                ce_promociones = ce_promociones.ToList();
                return Ok(ce_promociones);
            }
        }
        [HttpGet]
        [Route("/api/promociones")]
        public async Task<IActionResult> FicApiGetListPromociones()
        {
            var ce_promociones = (from data_inv in FicLoDBContext.ce_cat_promociones select data_inv).ToList();
            if (ce_promociones.Count() > 0)
            {
                ce_promociones = ce_promociones.ToList();
                return Ok(ce_promociones);
            }
            else
            {
                ce_promociones = ce_promociones.ToList();
                return Ok(ce_promociones);
            }
        }
        [HttpPost]
        [Route("/api/promociones")]
        public async Task<IActionResult> FicApiNewPromociones
        (
            [FromForm]string idpromocion, 
            [FromForm]string  descpromocion, 
            [FromForm]DateTime fechaexpiraini, 
            [FromForm]DateTime fechaexpirafin, 
            [FromForm]string valor, 
            [FromForm]char activo, 
            [FromForm]char borrado,
            [FromForm]DateTime fechareg,
            [FromForm]string usuarioreg,
            [FromForm]int idtipopromo,
            [FromForm]int idtipodescuento
        )
        {
            ce_cat_promociones promocion = new ce_cat_promociones();
            promocion.IdPromocion = idpromocion;
            promocion.DesPromocion = descpromocion;
            promocion.FechaExpiraIni = fechaexpiraini;
            promocion.FechaExpiraFin = fechaexpirafin;
            promocion.Valor = valor;
            promocion.Activo = activo;
            promocion.Borrado = borrado;
            promocion.FechaReg = fechareg;
            promocion.UsuarioReg = usuarioreg;
            promocion.IdTipoPromocion = idtipopromo;
            promocion.IdTipoDescuento = idtipodescuento;
            FicLoDBContext.ce_cat_promociones.Add(promocion);
            FicLoDBContext.SaveChanges();
            return Ok(promocion);
        }
        [HttpDelete]
        [Route("/api/promociones")]
        public async Task<IActionResult> FicApiDeletePromociones([FromQuery] string idpromocion)
        {
            ce_cat_promociones promocion = new ce_cat_promociones();
            promocion.IdPromocion = idpromocion;
            try
            {
                FicLoDBContext.ce_cat_promociones.Remove(promocion);
                FicLoDBContext.SaveChanges();
                return Ok(promocion);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "No se encontraron registros");
                return Ok(err);
            }
        }
        [HttpPut]
        [Route("/api/promociones")]
        public async Task<IActionResult> FicApiUpdatePromociones
        (
            [FromForm]string idpromocion,
            [FromForm]string descpromocion,
            [FromForm]DateTime fechaexpiraini,
            [FromForm]DateTime fechaexpirafin,
            [FromForm]string valor,
            [FromForm]char activo,
            [FromForm]char borrado,
            [FromForm]DateTime fechaultmod,
            [FromForm]string usuariomod,
            [FromForm]int idtipopromo,
            [FromForm]int idtipodescuento
        )
        {
            try
            {
                var promocion = FicLoDBContext.ce_cat_promociones.First(a => a.IdPromocion == idpromocion);
                promocion.IdPromocion = idpromocion;
                promocion.DesPromocion = descpromocion;
                promocion.FechaExpiraIni = fechaexpiraini;
                promocion.FechaExpiraFin = fechaexpirafin;
                promocion.Valor = valor;
                promocion.Activo = activo;
                promocion.Borrado = borrado;
                promocion.FechaUltMod = fechaultmod;
                promocion.UsuarioMod = usuariomod;
                promocion.IdTipoPromocion = idtipopromo;
                promocion.IdTipoDescuento = idtipodescuento;
                FicLoDBContext.SaveChanges();
                return Ok(promocion);
            }
            catch (Exception e)
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "No se encontraron registros");
                return Ok(err);
            }
        }

        //RUTAS PROMOCIONES APLICA A ===================================================================================
        
        [HttpGet]
        [Route("/api/promociones-aplica-a/one")]
        public async Task<IActionResult> FicApiGetListPromocionesAplicaA([FromQuery]string idpromocion, [FromQuery]int idtipoaplicaa)
        {

            var ce_promociones_aplica_a = (from data_promoaplicaa in FicLoDBContext.ce_cat_promociones_aplica_a where data_promoaplicaa.IdTipoAplicaA  == idtipoaplicaa && data_promoaplicaa.IdPromocion == idpromocion  select data_promoaplicaa).ToList();
            if (ce_promociones_aplica_a.Count() > 0)
            {
                ce_promociones_aplica_a = ce_promociones_aplica_a.ToList();
                return Ok(ce_promociones_aplica_a);
            }
            else
            {
                ce_promociones_aplica_a = ce_promociones_aplica_a.ToList();
                return Ok(ce_promociones_aplica_a);
            }
        }
        [HttpGet]
        [Route("/api/promociones-aplica-a")]
        public async Task<IActionResult> FicApiGetListPromocionesAplicaA()
        {
            var ce_promociones_aplica_a = (from data_promoaplicaa in FicLoDBContext.ce_cat_promociones_aplica_a select data_promoaplicaa).ToList();
            if (ce_promociones_aplica_a.Count() > 0)
            {
                ce_promociones_aplica_a = ce_promociones_aplica_a.ToList();
                return Ok(ce_promociones_aplica_a);
            }
            else
            {
                ce_promociones_aplica_a = ce_promociones_aplica_a.ToList();
                return Ok(ce_promociones_aplica_a);
            }
        }
        [HttpPost]
        [Route("/api/promociones-aplica-a")]
        public async Task<IActionResult> FicApiNewPromocionesAplicaA
        (
            [FromForm]int idtipoaplicaa,
            [FromForm]char activo,
            [FromForm]char borrado,
            [FromForm]DateTime fechareg,
            [FromForm]string usuarioreg,
            [FromForm]string idpromocion,
            [FromForm]string valor
        )
        {
            ce_cat_promociones_aplica_a promocion_aplica_a = new ce_cat_promociones_aplica_a();
            promocion_aplica_a.IdTipoAplicaA = idtipoaplicaa;
            promocion_aplica_a.Activo = activo;
            promocion_aplica_a.Borrado = borrado;
            promocion_aplica_a.FechaReg = fechareg;
            promocion_aplica_a.UsuarioReg = usuarioreg;
            promocion_aplica_a.IdPromocion = idpromocion;
            promocion_aplica_a.Valor = valor;
            FicLoDBContext.ce_cat_promociones_aplica_a.Add(promocion_aplica_a);
            FicLoDBContext.SaveChanges();
            return Ok(promocion_aplica_a);
        }
        [HttpDelete]
        [Route("/api/promociones-aplica-a")]
        public async Task<IActionResult> FicApiDeletePromocionesAplicaA([FromQuery] string idpromocion, [FromQuery]int idtipoaplicaa)
        {
            ce_cat_promociones_aplica_a promocion_aplica_a = new ce_cat_promociones_aplica_a();
            promocion_aplica_a.IdPromocion = idpromocion;
            promocion_aplica_a.IdTipoAplicaA = idtipoaplicaa;
            try
            {
                FicLoDBContext.ce_cat_promociones_aplica_a.Remove(promocion_aplica_a);
                FicLoDBContext.SaveChanges();
                return Ok(promocion_aplica_a);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "No se encontraron registros");
                return Ok(err);
            }
        }
        [HttpPut]
        [Route("/api/promociones-aplica-a")]
        public async Task<IActionResult> FicApiUpdatePromociones
        (
            [FromForm]int idtipoaplicaa,
            [FromForm]char activo,
            [FromForm]char borrado,
            [FromForm]DateTime fechaultmod,
            [FromForm]string usuariomod,
            [FromForm]string idpromocion,
            [FromForm]string valor
        )
        {
            try
            {
                var promocion_aplica_a = FicLoDBContext.ce_cat_promociones_aplica_a.First(a => a.IdPromocion == idpromocion && a.IdTipoAplicaA==idtipoaplicaa);
                promocion_aplica_a.IdTipoAplicaA = idtipoaplicaa;
                promocion_aplica_a.Activo = activo;
                promocion_aplica_a.Borrado = borrado;
                promocion_aplica_a.FechaUltMod = fechaultmod;
                promocion_aplica_a.UsuarioMod = usuariomod;
                promocion_aplica_a.IdPromocion = idpromocion;
                promocion_aplica_a.Valor = valor;
                FicLoDBContext.ce_cat_promociones_aplica_a.Add(promocion_aplica_a);
                FicLoDBContext.SaveChanges();
                return Ok(promocion_aplica_a);
            }
            catch (Exception e)
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "No se encontraron registros");
                return Ok(err);
            }
        }
        //RUTAS PROMOCIONES CANTIDAD FISICA ===================================================================================

        [HttpGet]
        [Route("/api/promociones-cantidad-fisica/one")]
        public async Task<IActionResult> FicApiGetListPromocionesCantidadFisica([FromQuery]string idpromocion)
        {

            var ce_promociones_cantidad_fisica = (from data_promocantidadfisica in FicLoDBContext.ce_cat_promociones_cantidad_fisica where data_promocantidadfisica.IdPromocion == idpromocion select data_promocantidadfisica).ToList();
            if (ce_promociones_cantidad_fisica.Count() > 0)
            {
                ce_promociones_cantidad_fisica = ce_promociones_cantidad_fisica.ToList();
                return Ok(ce_promociones_cantidad_fisica);
            }
            else
            {
                ce_promociones_cantidad_fisica = ce_promociones_cantidad_fisica.ToList();
                return Ok(ce_promociones_cantidad_fisica);
            }
        }
        [HttpGet]
        [Route("/api/promociones-cantidad-fisica")]
        public async Task<IActionResult> FicApiGetListPromocionesCantidadFisica()
        {
            var ce_promociones_cantidad_fisica = (from data_promocantidadfisica in FicLoDBContext.ce_cat_promociones_cantidad_fisica select data_promocantidadfisica).ToList();
            if (ce_promociones_cantidad_fisica.Count() > 0)
            {
                ce_promociones_cantidad_fisica = ce_promociones_cantidad_fisica.ToList();
                return Ok(ce_promociones_cantidad_fisica);
            }
            else
            {
                ce_promociones_cantidad_fisica = ce_promociones_cantidad_fisica.ToList();
                return Ok(ce_promociones_cantidad_fisica);
            }
        }
        [HttpPost]
        [Route("/api/promociones-cantidad-fisica")]
        public async Task<IActionResult> FicApiNewPromocionesCantidadFisica
        (
            [FromForm]string idpromocion,
            [FromForm]int valor,
            [FromForm]int valoracumulado,
            [FromForm]char activo,
            [FromForm]char borrado,
            [FromForm]DateTime fechareg,
            [FromForm]string usuarioreg,
            [FromForm]int idtipodescuento
        )
        {
            ce_cat_promociones_cantidad_fisica promocion_cantidad_fisica= new ce_cat_promociones_cantidad_fisica();
            promocion_cantidad_fisica.IdPromocion = idpromocion;
            promocion_cantidad_fisica.Valor = valor;
            promocion_cantidad_fisica.ValorAcumulado = valoracumulado;
            promocion_cantidad_fisica.Activo = activo;
            promocion_cantidad_fisica.Borrado = borrado;
            promocion_cantidad_fisica.FechaReg = fechareg;
            promocion_cantidad_fisica.UsuarioReg = usuarioreg;
            promocion_cantidad_fisica.idTipoDescuento = idtipodescuento;
            FicLoDBContext.ce_cat_promociones_cantidad_fisica.Add(promocion_cantidad_fisica);
            FicLoDBContext.SaveChanges();
            return Ok(promocion_cantidad_fisica);
        }
        [HttpDelete]
        [Route("/api/promociones-cantidad-fisica")]
        public async Task<IActionResult> FicApiDeletePromocionesCantidadFisica([FromQuery] string idpromocion)
        {
            ce_cat_promociones_cantidad_fisica promocion_cantidad_fisica = new ce_cat_promociones_cantidad_fisica();
            promocion_cantidad_fisica.IdPromocion = idpromocion;
            try
            {
                FicLoDBContext.ce_cat_promociones_cantidad_fisica.Remove(promocion_cantidad_fisica);
                FicLoDBContext.SaveChanges();
                return Ok(promocion_cantidad_fisica);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "No se encontraron registros");
                return Ok(err);
            }
        }
        [HttpPut]
        [Route("/api/promociones-cantidad-fisica")]
        public async Task<IActionResult> FicApiUpdatePromocionesCantidadFisica
        (
            [FromForm]string idpromocion,
            [FromForm]int valor,
            [FromForm]int valoracumulado,
            [FromForm]char activo,
            [FromForm]char borrado,
            [FromForm]DateTime fechaultmod,
            [FromForm]string usuariomod,
            [FromForm]short idtipodescuento
        )
        {
            try
            {
                var promocion_cantidad_fisica = FicLoDBContext.ce_cat_promociones_cantidad_fisica.First(a => a.IdPromocion == idpromocion);
                promocion_cantidad_fisica.IdPromocion = idpromocion;
                promocion_cantidad_fisica.Valor = valor;
                promocion_cantidad_fisica.ValorAcumulado = valoracumulado;
                promocion_cantidad_fisica.Activo = activo;
                promocion_cantidad_fisica.Borrado = borrado;
                promocion_cantidad_fisica.FechaUltMod = fechaultmod;
                promocion_cantidad_fisica.UsuarioMod = usuariomod;
                promocion_cantidad_fisica.idTipoDescuento = idtipodescuento;
                FicLoDBContext.ce_cat_promociones_cantidad_fisica.Add(promocion_cantidad_fisica);
                FicLoDBContext.SaveChanges();
                return Ok(promocion_cantidad_fisica);
            }
            catch (Exception e)
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "No se encontraron registros");
                return Ok(err);
            }
        }
        //RUTAS PROMO PROD SERV ===================================================================================
        
        [HttpGet]
        [Route("/api/promo-prod-serv/one")]
        public async Task<IActionResult> FicApiGetListPromocionesProdServ([FromQuery]int idprodserv, [FromQuery]string idpresentacion, [FromQuery]string idpromocion )
        {
            var ce_promo_prod_serv = (from data_promoprodserv in FicLoDBContext.ce_cat_promo_prod_serv where data_promoprodserv.IdPromocion == idpromocion && data_promoprodserv.IdProdServ == idprodserv && data_promoprodserv.IdPresentacion == idpresentacion select data_promoprodserv).ToList();
            if (ce_promo_prod_serv.Count() > 0)
            {
                ce_promo_prod_serv = ce_promo_prod_serv.ToList();
                return Ok(ce_promo_prod_serv);
            }
            else
            {
                ce_promo_prod_serv = ce_promo_prod_serv.ToList();
                return Ok(ce_promo_prod_serv);
            }
        }
        [HttpGet]
        [Route("/api/promo-prod-serv")]
        public async Task<IActionResult> FicApiGetListPromocionesProdServ()
        {
            var ce_promo_prod_serv = (from data_promoprodserv in FicLoDBContext.ce_cat_promo_prod_serv select data_promoprodserv).ToList();
            if (ce_promo_prod_serv.Count() > 0)
            {
                ce_promo_prod_serv = ce_promo_prod_serv.ToList();
                return Ok(ce_promo_prod_serv);
            }
            else
            {
                ce_promo_prod_serv = ce_promo_prod_serv.ToList();
                return Ok(ce_promo_prod_serv);
            }
        }
        [HttpPost]
        [Route("/api/promo-prod-serv")]
        public async Task<IActionResult> FicApiNewPromocionesProdServ
        (
            [FromForm]int idprodserv,
            [FromForm]string idpresentacion,
            [FromForm]string idpromocion,
            [FromForm]char activo,
            [FromForm]char borrado,
            [FromForm]DateTime fechareg,
            [FromForm]string usuarioreg
        )
        {
            ce_cat_promo_prod_serv promo_prod_serv = new ce_cat_promo_prod_serv();
            promo_prod_serv.IdProdServ = idprodserv;
            promo_prod_serv.IdPromocion = idpromocion;
            promo_prod_serv.IdPresentacion = idpresentacion;
            promo_prod_serv.Activo = activo;
            promo_prod_serv.Borrado = borrado;
            promo_prod_serv.FechaReg = fechareg;
            promo_prod_serv.UsuarioReg = usuarioreg;
            FicLoDBContext.ce_cat_promo_prod_serv.Add(promo_prod_serv);
            FicLoDBContext.SaveChanges();
            return Ok(promo_prod_serv);
        }
        [HttpDelete]
        [Route("/api/promo-prod-serv")]
        public async Task<IActionResult> FicApiDeletePromocionesProdServ([FromQuery]int idprodserv, [FromQuery]string idpresentacion, [FromQuery]string idpromocion)
        {
            ce_cat_promo_prod_serv promo_prod_serv = new ce_cat_promo_prod_serv();
            promo_prod_serv.IdProdServ = idprodserv;
            promo_prod_serv.IdPromocion = idpromocion;
            promo_prod_serv.IdPresentacion = idpresentacion;
            try
            {
                FicLoDBContext.ce_cat_promo_prod_serv.Remove(promo_prod_serv);
                FicLoDBContext.SaveChanges();
                return Ok(promo_prod_serv);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "No se encontraron registros");
                return Ok(err);
            }
        }
        [HttpPut]
        [Route("/api/promo-prod-serv")]
        public async Task<IActionResult> FicApiUpdatePromocionesProdServ
        (
            [FromForm]int idprodserv,
            [FromForm]string idpromocion,
            [FromForm]string idpresentacion,
            [FromForm]char activo,
            [FromForm]char borrado,
            [FromForm]DateTime fechaultmod,
            [FromForm]string usuariomod
        )
        {
            try
            {
                var promo_prod_serv = FicLoDBContext.ce_cat_promo_prod_serv.First(a => a.IdProdServ == idprodserv && a.IdPromocion == idpromocion && a.IdPresentacion == idpresentacion);
                promo_prod_serv.IdProdServ = idprodserv;
                promo_prod_serv.IdPromocion = idpromocion;
                promo_prod_serv.IdPresentacion = idpresentacion;
                promo_prod_serv.Activo = activo;
                promo_prod_serv.Borrado = borrado;
                promo_prod_serv.FechaUltMod = fechaultmod;
                promo_prod_serv.UsuarioMod = usuariomod;
                FicLoDBContext.ce_cat_promo_prod_serv.Add(promo_prod_serv);
                FicLoDBContext.SaveChanges();
                return Ok(promo_prod_serv);
            }
            catch (Exception e)
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "No se encontraron registros");
                return Ok(err);
            }
        }
       /* //RUTAS TIPO GENERALES ===================================================================================

        [HttpGet]
        [Route("/api/tipo-generales")]
        public async Task<IActionResult> FicApiGetListTipoGenerales([FromQuery]short idtipogeneral)
        {

            var tipo_generales = (from data_tipogenerales in FicLoDBContext.cat_tipo_generales where data_tipogenerales.IdTipoGeneral == idtipogeneral  select data_tipogenerales).ToList();
            if (tipo_generales.Count() > 0)
            {
                tipo_generales = tipo_generales.ToList();
                return Ok(tipo_generales);
            }
            else
            {
                tipo_generales = tipo_generales.ToList();
                return Ok(tipo_generales);
            }
        }
        [HttpGet]
        [Route("/api/tipo-generales")]
        public async Task<IActionResult> FicApiGetListTipoGenerales()
        {
            var tipo_generales = (from data_tipogenerales in FicLoDBContext.cat_tipo_generales select data_tipogenerales).ToList();
            if (tipo_generales.Count() > 0)
            {
                tipo_generales = tipo_generales.ToList();
                return Ok(tipo_generales);
            }
            else
            {
                tipo_generales = tipo_generales.ToList();
                return Ok(tipo_generales);
            }
        }
        [HttpPost]
        [Route("/api/tipo-generales")]
        public async Task<IActionResult> FicApiNewTipoGenerales
        (
            [FromForm]short idtipogeneral,
            [FromForm]string destipogeneral,
            [FromForm]char activo,
            [FromForm]char borrado,
            [FromForm]DateTime fechareg,
            [FromForm]string usuarioreg
        )
        {
            cat_tipo_generales tipo_generales = new cat_tipo_generales();
            tipo_generales.IdTipoGeneral = idtipogeneral;
            tipo_generales.DesTipoGeneral = destipogeneral;
            tipo_generales.Activo = activo;
            tipo_generales.Borrado = borrado;
            tipo_generales.FechaReg = fechareg;
            tipo_generales.UsuarioReg = usuarioreg;
            FicLoDBContext.cat_tipo_generales.Add(tipo_generales);
            FicLoDBContext.SaveChanges();
            return Ok(tipo_generales);
        }
        [HttpDelete]
        [Route("/api/tipo-generales")]
        public async Task<IActionResult> FicApiDeleteTipoGenerales([FromQuery] short idtipogeneral)
        {
            cat_tipo_generales tipo_generales = new cat_tipo_generales();
            tipo_generales.IdTipoGeneral = idtipogeneral;
            try
            {
                FicLoDBContext.cat_tipo_generales.Remove(tipo_generales);
                FicLoDBContext.SaveChanges();
                return Ok(tipo_generales);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "No se encontraron registros");
                return Ok(err);
            }
        }
        [HttpPut]
        [Route("/api/tipo-generales")]
        public async Task<IActionResult> FicApiUpdateTipoGenerales
        (
            [FromForm]short idtipogeneral,
            [FromForm]string destipogeneral,
            [FromForm]char activo,
            [FromForm]char borrado,
            [FromForm]DateTime fechaultmod,
            [FromForm]string usuariomod
        )
        {
            try
            {
                var tipo_generales = FicLoDBContext.cat_tipo_generales.First(a => a.IdTipoGeneral == idtipogeneral);
                tipo_generales.IdTipoGeneral = idtipogeneral;
                tipo_generales.DesTipoGeneral = destipogeneral;
                tipo_generales.Activo = activo;
                tipo_generales.Borrado = borrado;
                tipo_generales.FechaUltMod = fechaultmod;
                tipo_generales.UsuarioMod = usuariomod;
                FicLoDBContext.cat_tipo_generales.Add(tipo_generales);
                FicLoDBContext.SaveChanges();
                return Ok(tipo_generales);
            }
            catch (Exception e)
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "No se encontraron registros");
                return Ok(err);
            }
        }

        //RUTAS GENERALES ===================================================================================

        [HttpGet]
        [Route("/api/generales")]
        public async Task<IActionResult> FicApiGetListGenerales([FromQuery]short idgeneral)
        {

            var general = (from data_general in FicLoDBContext.cat_generales where data_general.IdGeneral == idgeneral select data_general).ToList();
            if (general.Count() > 0)
            {
                general = general.ToList();
                return Ok(general);
            }
            else
            {
                general = general.ToList();
                return Ok(general);
            }
        }
        [HttpGet]
        [Route("/api/generales")]
        public async Task<IActionResult> FicApiGetListGenerales()
        {
            var generales = (from data_generales in FicLoDBContext.cat_generales select data_generales).ToList();
            if (generales.Count() > 0)
            {
                generales = generales.ToList();
                return Ok(generales);
            }
            else
            {
                generales = generales.ToList();
                return Ok(generales);
            }
        }
        [HttpPost]
        [Route("/api/generales")]
        public async Task<IActionResult> FicApiNewGenerales
        (
            [FromForm]short idgeneral,
            [FromForm]string desgeneral,
            [FromForm]char activo,
            [FromForm]char borrado,
            [FromForm]DateTime fechareg,
            [FromForm]string usuarioreg
        )
        {
            cat_generales generales = new cat_generales();
            generales.IdGeneral = idgeneral;
            generales.DesGeneral = desgeneral;
            generales.Activo = activo;
            generales.Borrado = borrado;
            generales.FechaReg = fechareg;
            generales.UsuarioReg = usuarioreg;
            FicLoDBContext.cat_generales.Add(generales);
            FicLoDBContext.SaveChanges();
            return Ok(generales);
        }
        [HttpDelete]
        [Route("/api/generales")]
        public async Task<IActionResult> FicApiDeleteGenerales([FromQuery] short idgeneral)
        {
            cat_generales generales = new cat_generales();
            generales.IdGeneral = idgeneral;
            try
            {
                FicLoDBContext.cat_generales.Remove(generales);
                FicLoDBContext.SaveChanges();
                return Ok(generales);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "No se encontraron registros");
                return Ok(err);
            }
        }
        [HttpPut]
        [Route("/api/generales")]
        public async Task<IActionResult> FicApiUpdateGenerales
        (
            [FromForm]short idgeneral,
            [FromForm]string desgeneral,
            [FromForm]char activo,
            [FromForm]char borrado,
            [FromForm]DateTime fechaultmod,
            [FromForm]string usuariomod
        )
        {
            try
            {
                var generales = FicLoDBContext.cat_generales.First(a => a.IdGeneral == idgeneral);
                generales.IdGeneral = idgeneral;
                generales.DesGeneral = desgeneral;
                generales.Activo = activo;
                generales.Borrado = borrado;
                generales.FechaUltMod = fechaultmod;
                generales.UsuarioMod = usuariomod;
                FicLoDBContext.cat_generales.Add(generales);
                FicLoDBContext.SaveChanges();
                return Ok(generales);
            }
            catch (Exception e)
            {
                Dictionary<String, String> err = new Dictionary<string, string>();
                err.Add("err", "No se encontraron registros");
                return Ok(err);
            }
        }*/
    }
}
