using AgricolaData.Entities;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApoloCartera.Clases
{
    public class CombosClass
    {
        private Logger _logger = LogManager.GetLogger("AppDomainLog");
        ApoloData.Context _context = new ApoloData.Context();

        public SelectList ListarComboEmpresa(long? ID = null)
        {
            var data = _context.Empresas.Where(c => c.Activo).ToList();
            data.Add(new Empresa { IdEmpresa = 0, NombreComercial = "Empresa" });

            var datos = data.Select(c => new Empresa
            {
                IdEmpresa = c.IdEmpresa,
                NombreComercial = c.NombreComercial
            }).ToList();

            return new SelectList(datos.OrderBy(c => c.IdEmpresa), "IdEmpresa", "NombreComercial", ID);
        }

        public SelectList ListarComboEstablecimiento(long? ID = null)
        {
            var data = _context.Establecimientos.Where(c => c.Activo).ToList();
            data.Add(new Establecimiento { IdEstablecimiento = 0, Nombre = "Establecimiento" });

            var datos = data.Select(c => new Establecimiento
            {
                IdEstablecimiento = c.IdEstablecimiento,
                Nombre = c.Codigo
            }).ToList();

            return new SelectList(datos.OrderBy(c => c.IdEstablecimiento), "IdEstablecimiento", "Nombre", ID);
        }


        public SelectList ListarComboPuntoVenta(long? ID = null)
        {
            var data = _context.PuntoVentas.Where(c => c.Activo).ToList();
            data.Add(new PuntoVenta { IdPuntoVenta = 0, Nombre = "Punto de Venta" });

            var datos = data.Select(c => new PuntoVenta
            {
                IdPuntoVenta = c.IdPuntoVenta,
                Nombre = c.Codigo
            }).ToList();

            return new SelectList(datos.OrderBy(c => c.IdPuntoVenta), "IdPuntoVenta", "Nombre", ID);
        }

        public SelectList ListarComboTipoDocumento(long? ID = null)
        {
            var data = _context.TipoDocumentos.Where(c => c.Activo).ToList();
            data.Add(new TipoDocumento { IdTipoDocumento = 0, Nombre = "Documento" });

            var datos = data.Select(c => new TipoDocumento
            {
                IdTipoDocumento = c.IdTipoDocumento,
                Nombre = c.Nombre
            }).ToList();

            return new SelectList(datos.OrderBy(c => c.IdTipoDocumento), "IdTipoDocumento", "Nombre", ID);
        }

        public SelectList ListarComboPersonas(long? ID = null)
        {
            var data = _context.Personas.Where(c => c.Activo).ToList();
            data.Add(new Persona { IdPersona = 0, NombreComercial = "Persona" });

            var datos = data.Select(c => new Persona
            {
                IdPersona = c.IdPersona,
                NombreComercial = c.NombreComercial
            }).ToList();

            return new SelectList(datos.OrderBy(c => c.IdPersona), "IdPersona", "NombreComercial", ID);
        }



        public SelectList ListarComboFormaPago(long? ID = null)
        {
            var data = _context.FormaPagos.Where(c => c.Activo).ToList();
            data.Add(new FormaPago { IdFormaPago = 0, Nombre = "Forma de Pago" });

            var datos = data.Select(c => new FormaPago
            {
                IdFormaPago = c.IdFormaPago,
                Nombre = c.Nombre
            }).ToList();

            return new SelectList(datos.OrderBy(c => c.IdFormaPago), "IdFormaPago", "Nombre", ID);
        }

    }
}