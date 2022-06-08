using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgricolaData.Models
{
    public class UsuarioDomusSpModel
    {

        public int susCodigo { set; get; }
        public int empCodigo { set; get; }
        public string empApeNombre { set; get; }
        public string empApellidos { set; get; }
        public string empNombres { set; get; }
        public string empPassword { set; get; }
        public string empPasswordConfirmar { set; get; }
        public string empCedula { set; get; }
        public string gruCodigo { set; get; }
        public string empEstado { set; get; }
        public string empCodAlterno { set; get; }
        public string empCargo { set; get; }
        public string empLogin { set; get; }
        public string empHabilitado { set; get; }
        public Int16 empEstadoCivil { set; get; }
        public DateTime empFechaNacimiento { set; get; }
        public Int16 empGenero { set; get; }
        public string empImpresionRetencionFormato { set; get; }
        public Int16 empNivelAprobacionCxC { set; get; }
        public string dptCodigo { set; get; }
    }


    public class PORTAFOLIOINVENTARIOSpModel
    {

        public int susCodigo { set; get; }
        public string invCodigo { set; get; }
        public string pprCodigo { set; get; }
        public string pryCodigo { set; get; }
    }


    public class ListaEdificios
    {

        public string NombreEdificio { set; get; }
        public string pryCodigo { set; get; }

    }


    public class CUENTASCONTABLESSpModel
    {
        public Int32 susCodigo { set; get; }
        public Int32 ciaCodigo { set; get; }
        public decimal subCuenta { set; get; }
        public string subNombre { set; get; }
        public string SubEstado { set; get; }
        public string ctaCodigo { set; get; }
        public string SubIncFlujoCaja { set; get; }
        public string SubIncPresupuesto { set; get; }
        public string SubAcreedores { set; get; }
        public string SubEsUnBanco { set; get; }
        public string subDeudores { set; get; }
        public string SubRequiereCentroCosto { set; get; }
        public string SubEsActivos { set; get; }
        public DateTime subFechaCreacion { set; get; }
        public Int32 subCreadoPor { set; get; }
        public DateTime subFechaModificacion { set; get; }
        public Int32 subModificadoPor { set; get; }
    }

    public class SUCURSALESNUMERACIONES
    {
        public int susCodigo { set; get; }
        public int ciaCodigo { set; get; }
        public string sucCodigo { set; get; }
        public string modCodigo { set; get; }
        public string NumCodigo { set; get; }
        public string NumDescripcion { set; get; }
        public Decimal NumUltNumero { set; get; }
        public string NumAutomatica { set; get; }
    }

    public class MOVIMIENTOSBANCARIOS
    {
        public int susCodigo { set; get; }
        public int ciaCodigo { set; get; }
        public string sucCodigo { set; get; }
        public string movTipo { set; get; }
        public int movNumero { set; get; }
        public DateTime? movFecha { set; get; }
        public decimal? cteSubCuenta { set; get; }
        public int? movTipoCambio { set; get; }
        public string movConcepto { set; get; }
        public decimal? movValorMovimiento { set; get; }
        public string movEstado { set; get; }
        public int movUltLinea { set; get; }
        public string movConciliado { set; get; }
        public string movBeneficiario { set; get; }
        public int movNroCheque { set; get; }
        public int movOrdenGiro { set; get; }
        public string movChqEmitido { set; get; }
        public string movChqEntregado { set; get; }
        public string movChqFecha { set; get; }
        public string movContabilizado { set; get; }
        public DateTime? movFechaConciliacion { set; get; }
        public string movNroReferencia { set; get; }
        public DateTime? movChqEntregadoFecha { set; get; }
        public DateTime? movFechaCreacion { set; get; }
        public int? movCreadoPor { set; get; }
        public DateTime? movFechaModificacion { set; get; }
         public int? movModificadoPor { set; get; }
        public string movChqEntregadoA { set; get; }
        public DateTime? movFechaAnulacion { set; get; }
        public int? movAnuladoPor { set; get; }
        public DateTime? movFechaProgramadaEntrega { set; get; }
        public DateTime? movChqEfectivizadoFecha { set; get; }
        public string movChqAutorizado { set; get; }
        public string movChqEfectivizado { set; get; }
    }


    public class CargarLotes
    {

        public string NumeroLote { set; get; }

    }



    public class CargarConcepto
    {

        public string Concepto { set; get; }

    }


    
}
