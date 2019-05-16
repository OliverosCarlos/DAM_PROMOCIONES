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
            [FromForm]DateTime fechaExpiraini, 
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
            promocion.FechaExpiraIni = fechaExpiraini;
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
            [FromForm]DateTime fechaExpiraini,
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
                promocion.FechaExpiraIni = fechaExpiraini;
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
        [Route("/api/promociones/aplica-a")]
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
        [Route("/api/promociones/aplica-a/list")]
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
        [Route("/api/promociones")]
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
        [Route("/api/promociones")]
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
        [Route("/api/promociones")]
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
        [Route("/api/promociones/aplica-a")]
        public async Task<IActionResult> FicApiGetListPromocionesCantidadFisica([FromQuery]string idpromocion)
        {

            var ce_promociones_aplica_a = (from data_promoaplicaa in FicLoDBContext.ce_cat_promociones_aplica_a where data_promoaplicaa.IdTipoAplicaA == idtipoaplicaa && data_promoaplicaa.IdPromocion == idpromocion select data_promoaplicaa).ToList();
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
        [Route("/api/promociones/aplica-a/list")]
        public async Task<IActionResult> FicApiGetListPromocionesCantidadFisica()
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
        [Route("/api/promociones")]
        public async Task<IActionResult> FicApiNewPromocionesCantidadFisica
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
        [Route("/api/promociones")]
        public async Task<IActionResult> FicApiDeletePromocionesCantidadFisica([FromQuery] string idpromocion, [FromQuery]int idtipoaplicaa)
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
        [Route("/api/promociones")]
        public async Task<IActionResult> FicApiUpdatePromocionesCantidadFisica
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
                var promocion_aplica_a = FicLoDBContext.ce_cat_promociones_aplica_a.First(a => a.IdPromocion == idpromocion && a.IdTipoAplicaA == idtipoaplicaa);
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
        //RUTAS PROMO PROD SERV ===================================================================================

        [HttpGet]
        [Route("/api/promociones/aplica-a")]
        public async Task<IActionResult> FicApiGetListPromocionesProdServ([FromQuery]string idpromocion, [FromQuery]int idtipoaplicaa)
        {

            var ce_promociones_aplica_a = (from data_promoaplicaa in FicLoDBContext.ce_cat_promociones_aplica_a where data_promoaplicaa.IdTipoAplicaA == idtipoaplicaa && data_promoaplicaa.IdPromocion == idpromocion select data_promoaplicaa).ToList();
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
        [Route("/api/promociones/aplica-a/list")]
        public async Task<IActionResult> FicApiGetListPromocionesProdServ()
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
        [Route("/api/promociones")]
        public async Task<IActionResult> FicApiNewPromocionesProdServ
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
        [Route("/api/promociones")]
        public async Task<IActionResult> FicApiDeletePromocionesProdServ([FromQuery] string idpromocion, [FromQuery]int idtipoaplicaa)
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
        [Route("/api/promociones")]
        public async Task<IActionResult> FicApiUpdatePromocionesProdServ
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
                var promocion_aplica_a = FicLoDBContext.ce_cat_promociones_aplica_a.First(a => a.IdPromocion == idpromocion && a.IdTipoAplicaA == idtipoaplicaa);
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
        //RUTAS TIPO GENERALES ===================================================================================

        [HttpGet]
        [Route("/api/promociones/aplica-a")]
        public async Task<IActionResult> FicApiGetListTipoGenerales([FromQuery]string idpromocion, [FromQuery]int idtipoaplicaa)
        {

            var ce_promociones_aplica_a = (from data_promoaplicaa in FicLoDBContext.ce_cat_promociones_aplica_a where data_promoaplicaa.IdTipoAplicaA == idtipoaplicaa && data_promoaplicaa.IdPromocion == idpromocion select data_promoaplicaa).ToList();
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
        [Route("/api/promociones/aplica-a/list")]
        public async Task<IActionResult> FicApiGetListTipoGenerales()
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
        [Route("/api/promociones")]
        public async Task<IActionResult> FicApiNewTipoGenerales
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
        [Route("/api/promociones")]
        public async Task<IActionResult> FicApiDeleteTipoGenerales([FromQuery] string idpromocion, [FromQuery]int idtipoaplicaa)
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
        [Route("/api/promociones")]
        public async Task<IActionResult> FicApiUpdateTipoGenerales
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
                var promocion_aplica_a = FicLoDBContext.ce_cat_promociones_aplica_a.First(a => a.IdPromocion == idpromocion && a.IdTipoAplicaA == idtipoaplicaa);
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
        //RUTAS GENERALES ===================================================================================

        [HttpGet]
        [Route("/api/promociones/aplica-a")]
        public async Task<IActionResult> FicApiGetListGenerales([FromQuery]string idpromocion, [FromQuery]int idtipoaplicaa)
        {

            var ce_promociones_aplica_a = (from data_promoaplicaa in FicLoDBContext.ce_cat_promociones_aplica_a where data_promoaplicaa.IdTipoAplicaA == idtipoaplicaa && data_promoaplicaa.IdPromocion == idpromocion select data_promoaplicaa).ToList();
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
        [Route("/api/promociones/aplica-a/list")]
        public async Task<IActionResult> FicApiGetListGenerales()
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
        [Route("/api/promociones")]
        public async Task<IActionResult> FicApiNewGenerales
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
        [Route("/api/promociones")]
        public async Task<IActionResult> FicApiDeleteGenerales([FromQuery] string idpromocion, [FromQuery]int idtipoaplicaa)
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
        [Route("/api/promociones")]
        public async Task<IActionResult> FicApiUpdateGenerales
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
                var promocion_aplica_a = FicLoDBContext.ce_cat_promociones_aplica_a.First(a => a.IdPromocion == idpromocion && a.IdTipoAplicaA == idtipoaplicaa);
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
    }
}
