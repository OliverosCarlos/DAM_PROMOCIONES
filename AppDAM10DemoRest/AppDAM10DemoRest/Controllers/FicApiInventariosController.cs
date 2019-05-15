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

        //RUTAS INVENTARIOS- ===================================================================================

        [HttpGet]
        [Route("/api/promociones/listar")]
        public async Task<IActionResult> FicApiGetListPromociones([FromQuery]int idpromocion)
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
            [FromForm]int idpromocion, 
            [FromForm]string  descpromocion, 
            [FromForm]DateTime fechaExpiraini, 
            [FromForm]DateTime fechaexpirafin, 
            [FromForm]string valor, 
            [FromForm]char activo, 
            [FromForm]char borrado,
            [FromForm]DateTime fechareg,
            [FromForm]string usuarioreg,
            [FromForm]string idtipopromo,
            [FromForm]string idtipodescuento
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
        public async Task<IActionResult> FicApiDeletePromociones([FromQuery] int idpromocion)
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
            [FromForm]int idpromocion,
            [FromForm]string descpromocion,
            [FromForm]DateTime fechaExpiraini,
            [FromForm]DateTime fechaexpirafin,
            [FromForm]string valor,
            [FromForm]char activo,
            [FromForm]char borrado,
            [FromForm]DateTime fechaultmod,
            [FromForm]string usuariomod,
            [FromForm]string idtipopromo,
            [FromForm]string idtipodescuento
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


    }
}
