using AgricolaData.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgricolaData.StoreProcedures
{
    public class SpCXC
    {

        ApoloData.Context _context = new ApoloData.Context();
        public SpCXC()
        {

            _context = new ApoloData.Context();
        }

        public PORTAFOLIOINVENTARIOSpModel SP_CARGAR_EDIFICIO(string pryCodigo, string invCodigo)
        {
            try
            {
                return _context.Database.SqlQuery<PORTAFOLIOINVENTARIOSpModel>("EXEC SP_DOMUSPORTAFOLIOINVENTARIO @pryCodigo, @invCodigo",
                           new SqlParameter("pryCodigo", pryCodigo),
                           new SqlParameter("invCodigo", invCodigo)
                           ).FirstOrDefault();
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public List<ListaEdificios> SP_CARGAR_EDIFICIOS(string pryCodigo)
        {
            try
            {
                return _context.Database.SqlQuery<ListaEdificios>("EXEC SP_CARGAR_EDIFICIOS @pryCodigo",
                           new SqlParameter("pryCodigo", pryCodigo)

                           ).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }






        public List<CUENTASCONTABLESSpModel> SP_CARGAR_CUENTASCONTABLES(string ciaCodigo)
        {
            try
            {
                try
                {
                    return _context.Database.SqlQuery<CUENTASCONTABLESSpModel>("EXEC SP_DOMUSCUENTSCONTABLES @ciaCodigo",
                               new SqlParameter("ciaCodigo", ciaCodigo)

                               ).ToList();
                }
                catch (Exception e)
                {
                    return null;
                    throw;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }




        public SUCURSALESNUMERACIONES SP_CARGAR_NUMERACIONES_SUCURSALES(long ciaCodigo, string modCodigo, string NumCodigo)
        {
            try
            {
                return _context.Database.SqlQuery<SUCURSALESNUMERACIONES>("EXEC SUCURSALESNUMERACIONES @ciaCodigo, @modCodigo, @NumCodigo",
                           new SqlParameter("ciaCodigo", ciaCodigo),
                           new SqlParameter("modCodigo", modCodigo),
                           new SqlParameter("NumCodigo", NumCodigo)
                           ).FirstOrDefault();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public SUCURSALESNUMERACIONES SP_AUMENTARNUMERACIONSUCURSALES(long ciaCodigo, string modCodigo, string NumCodigo)
        {
            try
            {
                return _context.Database.SqlQuery<SUCURSALESNUMERACIONES>("EXEC AUMENTARNUMERACIONSUCURSALES @ciaCodigo, @modCodigo, @NumCodigo",
                           new SqlParameter("ciaCodigo", ciaCodigo),
                           new SqlParameter("modCodigo", modCodigo),
                           new SqlParameter("NumCodigo", NumCodigo)
                           ).FirstOrDefault();
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public SUCURSALESNUMERACIONES SP_DOMUS_INSERTMOVIMIENTOSBANCARIOS(MOVIMIENTOSBANCARIOS itemMovimientoBancario)
        {
            try
            {
                string concepto = "Transferencia de Larisa FONDOS COMANDATO / PAGO NOMINA 1ERA QUINC FEB 2021001784TRN";
                decimal ValorMovimiento = 0;
                string MovEstado = "A";
                return _context.Database.SqlQuery<SUCURSALESNUMERACIONES>("EXEC SP_DOMUS_INSERTMOVIMIENTOSBANCARIOS @susCodigo, " +
                                        "@ciaCodigo, " +
                                        "@sucCodigo, " +
                                        "@movTipo, " +
                                        "@movNumero, " +
                                        "@movFecha, " +
                                        "@cteSubCuenta, " +
                                        "@movTipoCambio, " +
                                        "@movConcepto, " +
                                        "@movValorMovimiento, " +
                                        "@movEstado, " +
                                        "@movUltLinea, " +
                                        "@movConciliado, " +
                                        "@movBeneficiario, " +
                                        "@movNroCheque, " +
                                        "@movOrdenGiro, " +
                                        "@movChqEmitido, " +
                                        "@movChqEntregado, " +
                                        "@movChqFecha, " +
                                        "@movContabilizado, " +
                //"@movFechaConciliacion ",
                "@movNroReferencia, " +
                //"@movChqEntregadoFecha, " +
                "@movFechaCreacion ",
                //"@movCreadoPor, " +
                //"@movFechaModificacion, " +
                //"@movModificadoPor, " +
                //"@movChqEntregadoA, " +
                //"@movFechaAnulacion, " +
                //"@movAnuladoPor, " +
                //"@movFechaProgramadaEntrega, " +
                //"@movChqEfectivizadoFecha, " +
                //"@movChqAutorizado, " +
                //"@movChqEfectivizado ",


                //new SqlParameter("susCodigo", 1)
                //           

                new SqlParameter("susCodigo", itemMovimientoBancario.susCodigo),
                new SqlParameter("ciaCodigo", itemMovimientoBancario.ciaCodigo),
                new SqlParameter("sucCodigo", itemMovimientoBancario.sucCodigo),
                new SqlParameter("movTipo", itemMovimientoBancario.movTipo),
                new SqlParameter("movNumero", itemMovimientoBancario.movNumero),
                new SqlParameter("movFecha", DateTime.Now),
                new SqlParameter("cteSubCuenta", 11010201),
                new SqlParameter("movTipoCambio", 1),
                new SqlParameter("movConcepto", concepto),
                new SqlParameter("movValorMovimiento", ValorMovimiento),
                new SqlParameter("movEstado", MovEstado),
                new SqlParameter("movUltLinea", itemMovimientoBancario.movUltLinea),
                new SqlParameter("movConciliado", itemMovimientoBancario.movConciliado),
                new SqlParameter("movBeneficiario", itemMovimientoBancario.movBeneficiario),
                new SqlParameter("movNroCheque", itemMovimientoBancario.movNroCheque),
                new SqlParameter("movOrdenGiro", itemMovimientoBancario.movOrdenGiro),
                new SqlParameter("movChqEmitido", itemMovimientoBancario.movChqEmitido),
                new SqlParameter("movChqEntregado", itemMovimientoBancario.movChqEntregado),
                new SqlParameter("movChqFecha", itemMovimientoBancario.movChqFecha),
                new SqlParameter("movContabilizado", itemMovimientoBancario.movContabilizado),
                //new SqlParameter("movFechaConciliacion", itemMovimientoBancario.movFechaConciliacion)
                new SqlParameter("movNroReferencia", itemMovimientoBancario.movNroReferencia),
                //new SqlParameter("movChqEntregadoFecha", itemMovimientoBancario.movChqEntregadoFecha),
                new SqlParameter("movFechaCreacion", itemMovimientoBancario.movFechaCreacion)
                //new SqlParameter("movCreadoPor", itemMovimientoBancario.movCreadoPor),
                //new SqlParameter("movFechaModificacion", itemMovimientoBancario.movFechaModificacion),
                //new SqlParameter("movModificadoPor", itemMovimientoBancario.movModificadoPor),
                //new SqlParameter("movChqEntregadoA", itemMovimientoBancario.movChqEntregadoA),
                //new SqlParameter("movFechaAnulacion", itemMovimientoBancario.movFechaAnulacion),
                //new SqlParameter("movAnuladoPor", itemMovimientoBancario.movAnuladoPor),
                //new SqlParameter("movFechaProgramadaEntrega", itemMovimientoBancario.movFechaProgramadaEntrega),
                //new SqlParameter("movChqEfectivizadoFecha", itemMovimientoBancario.movChqEfectivizadoFecha),
                //new SqlParameter("movChqAutorizado", itemMovimientoBancario.movChqAutorizado),
                //new SqlParameter("movChqEfectivizado", itemMovimientoBancario.movChqEfectivizado)


                ).FirstOrDefault();




                //new SqlParameter("@ciaCodigo", 1),
                //new SqlParameter("@sucCodigo", "001"),
                //new SqlParameter("@movTipo", "NCR"),
                //new SqlParameter("@movNumero", 1969),
                //new SqlParameter("@movFecha", "01/01/2021"),
                //new SqlParameter("@cteSubCuenta", 11010201),
                //new SqlParameter("@movTipoCambio", 0),
                //new SqlParameter("@movConcepto", "Transferencia de Larisa FONDOS COMANDATO / PAGO NOMINA 1ERA QUINC FEB 2021001784TRN"),
                //new SqlParameter("@movValorMovimiento", 117800.00),
                //new SqlParameter("@movEstado", "P"),
                //new SqlParameter("@movUltLinea", 1),
                //new SqlParameter("@movConciliado", "S"),
                //new SqlParameter("@movBeneficiario", 0),
                //new SqlParameter("@movNroCheque", 0),
                //new SqlParameter("@movOrdenGiro", 0),
                //new SqlParameter("@movChqEmitido", ""),
                //new SqlParameter("@movChqEntregado", ""),
                //new SqlParameter("@movChqFecha", ""),
                //new SqlParameter("@movContabilizado", "S"),
                //new SqlParameter("@movFechaConciliacion", null),
                //new SqlParameter("@movNroReferencia", "                              "),
                //new SqlParameter("@movChqEntregadoFecha", null),
                //new SqlParameter("@movFechaCreacion", null),
                //new SqlParameter("@movCreadoPor", 0),
                //new SqlParameter("@movFechaModificacion", null),
                //new SqlParameter("@movModificadoPor", 0),
                //new SqlParameter("@movChqEntregadoA", "                                                                                                    "),
                //new SqlParameter("@movFechaAnulacion", null),
                //new SqlParameter("@movAnuladoPor", null),
                //new SqlParameter("@movFechaProgramadaEntrega", null),
                //new SqlParameter("@movChqEfectivizadoFecha", null),
                //new SqlParameter("@movChqAutorizado", null),
                //new SqlParameter("@movChqEfectivizado", null)

            }
            catch (Exception e)
            {
                return null;
            }
        }



        public List<CargarLotes>  SP_CARGARLOTES()
        {
            try
            {
                return _context.Database.SqlQuery<CargarLotes>("EXEC SP_CARGARLOTES").ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }



        public List<CargarConcepto> SP_CARGARCONCEPTO()
        {
            try
            {
                return _context.Database.SqlQuery<CargarConcepto>("EXEC SP_CARGARCONCEPTOS").ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }


    }
}
