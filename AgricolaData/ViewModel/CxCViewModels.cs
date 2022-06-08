using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgricolaData.ViewModel
{
    public class ListarCobrosViewModel
    {
        public ListarCobrosViewModel()
        {
            Cobros = new List<ItemCobrosViewModel>();
        }

        [Display(Name = "Cliente")]
        public long IdCliente { set; get; }

        [Display(Name = "Periodo")]
        public long IdPeriodo { set; get; }
        
        public List<ItemCobrosViewModel> Cobros;
    }

    public class ItemCobrosViewModel
    {
        public ItemCobrosViewModel()
        {
            Operaciones = new List<OperacionesViewModel>();
            NotasCredito = new List<NotaCreditoCobrosViewModel>();
        }


        public long IdMovimiento { set; get; }

        //[Required]
        [Display(Name = "Nro. Cobro")]
        public string NumCobro { set; get; }
        [Display(Name = "Fecha Transaccion")]
        public DateTime FechaCobro { set; get; }
        //[Display(Name = "Fecha Tranf. Dep")]
        //public DateTime FechaTranfDeposito { set; get; }
        [Display(Name = "Tipo Movimiento")]
        public string NombreTipoMovimiento { set; get; }
        [Display(Name = "Tipo Movimiento")]
        public long IdTipoMovimiento { set; get; }
        [Display(Name = "Cliente")]
        public long IdCliente { set; get; }
        [Display(Name = "Forma Pago")]
        public long IdFormaPago { set; get; }
        [Display(Name = "Forma Pago")]
        public string NombreFormaPago { set; get; }

        [Display(Name = "Tipo Forma Pago")]
        public long IdTipoFormaPago { set; get; }
        [Display(Name = "Tipo Forma Pago")]
        public string NombreTipoFormaPago { set; get; }

        [Display(Name = "Valor Recibido")]
        public decimal ValorRecibido { set; get; }
        [Display(Name = "Cliente")]
        public string NombreCliente { set; get; }
        [Display(Name = "Fecha Comprobante Banco")]
        public DateTime? FechaComprobante { set; get; }
        [Display(Name = "Cta. Bancaria Empresa")]
        public long? IdCuentaBancariaEmpresa { set; get; }
        [Display(Name = "Cta. Bancaria Empresa")]
        public string NombreCuentaBancariaEmpresa { set; get; }

        [Display(Name = "Num Comprobante")]
        public string NumComprobante { set; get; }

        [Display(Name = "Banco")]
        public long? IdBancoCliente { set; get; }

        [Display(Name = "Tipo Nota Crédito")]
        public long? IdTipoNotaCredito { set; get; }
        
        [Display(Name = "Banco")]
        public string NombreBanco { set; get; }
        [Display(Name = "Cta Bco. Cliente")]
        public string CtaBcoCliente { set; get; }
        [Display(Name = "Cant Cheq/Dep")]
        public long CantCheqDep { set; get; }

        public long Periodo { set; get; }

        public List<OperacionesViewModel> Operaciones;
        public List<NotaCreditoCobrosViewModel> NotasCredito;

        public String Deuda_Facturas { set; get; }

        public String Deuda_NotasDebito { set; get; }

        public String Deuda_NotasCredito { set; get; }

        public String Deuda_Total { set; get; }

        public decimal Facturas_Aplicado { set; get; }

        public decimal Total_Aplicado { set; get; }


        // Popup
        [Display(Name = "Num. Comprobante :")]
        public String PopUpNumComprobante { set; get; }
        [Display(Name = "Forma Pago :")]
        public string PopUpTipoDocumento { set; get; }
        [Display(Name = "Operación :")]
        public long PopUpIdOperacion { set; get; }
        [Display(Name = "Valor Aplicado :")]
        public decimal PopUpValorAplicado { set; get; }
        [Display(Name = "Valor Ret. Fuente :")]
        public decimal PopUpValorRetFuente { set; get; }
        [Display(Name = "Valor Ret. Iva :")]
        public decimal PopUpValorRetIva { set; get; }

        [Display(Name = "Saldo :")]
        public string PopUpSaldo { set; get; }

        [Display(Name = "Fecha Registro")]
        public DateTime? FechaRegistro { set; get; }


        [Display(Name = "Num. Secuencia")]
        public string NumSecuencia { set; get; }
    }

    public class OperacionesViewModel
    {
        public long IdOperacion { set; get; }
        [Display(Name = "Cant Cheq/Dep")]
        public long? IdPeriodo { set; get; }
        [Display(Name = "Secuencia")]
        public int? SecuenciaTrans { set; get; }
        [Display(Name = "Empresa")]
        public int CodigoEmpresa { set; get; }
        [Display(Name = "Tipo")]
        public string TipoComprobante { set; get; }
        [Display(Name = "Numero Comprobante")]
        public string NumeroComprobante { set; get; }
        [Display(Name = "Lote")]
        public string NumeroLote { set; get; }
        [Display(Name = "Empresa")]
        public string NombreEmpresa { set; get; }
        [Display(Name = "Urbanización")]
        public string CódigoUrbanización { set; get; }
        [Display(Name = "Identificación")]
        public string IdentificacionCliente { set; get; }
        [Display(Name = "Cliente")]
        public string NombreCliente { set; get; }
        [Display(Name = "Lote")]
        public string DescripcionLote { set; get; }
        [Display(Name = "Concepto")]
        public string Concepto { set; get; }
        [Display(Name = "Fecha Emisión")]
        public int FechaEmision { set; get; }
        [Display(Name = "Fecha Vencimiento")]
        public int FechaVencimiento { set; get; }
        [Display(Name = "Saldo")]
        public decimal Saldo { set; get; }
        [Display(Name = "Valor a Aplicar")]
        public decimal ValorAplicar { set; get; }


        [Display(Name = "Ret. Fuente")]
        public decimal ValorRetFuente { set; get; }

        [Display(Name = "Ret. Iva")]
        public decimal ValorRetIva { set; get; }

        [Display(Name = "Edificio")]
        public string Edificio { set; get; }

        [Display(Name = "Responsable")]
        public string ResponsableCobranza { set; get; }

        public long IdFormaPago { set; get; }

        public DateTime FechaCreacion { set; get; }
    }

    public class NotaCreditoCobrosViewModel
    {
        public long IdMovimiento { set; get; }

        //[Required]
        [Display(Name = "Nro. NC")]
        public string NumCobro { set; get; }
        [Display(Name = "Fecha Transaccion")]
        public string FechaCobro { set; get; }
        //[Display(Name = "Fecha Tranf. Dep")]
        //public DateTime FechaTranfDeposito { set; get; }
        [Display(Name = "Tipo Movimiento")]
        public string NombreTipoMovimiento { set; get; }

        [Display(Name = "Tipo")]
        public long? IdTipoNotaCredito { set; get; }
        
        [Display(Name = "Tipo")]
        public string NombreTipoNotaCredito { set; get; }

        [Display(Name = "Tipo Movimiento")]
        public long IdTipoMovimiento { set; get; }
        [Display(Name = "Cliente")]
        public long IdCliente { set; get; }
        [Display(Name = "Forma Pago")]
        public long IdFormaPago { set; get; }
        [Display(Name = "Forma Pago")]
        public string NombreFormaPago { set; get; }

        [Display(Name = "Tipo Forma Pago")]
        public long IdTipoFormaPago { set; get; }
        [Display(Name = "Valor Recibido")]
        public decimal ValorRecibido { set; get; }
        [Display(Name = "Cliente")]
        public string NombreCliente { set; get; }
        [Display(Name = "Fecha Comprobante")]
        public DateTime FechaComprobante { set; get; }
        [Display(Name = "Cta. Bancaria Empresa")]
        public long? IdCuentaBancariaEmpresa { set; get; }
        [Display(Name = "Num Comprobante")]
        public string NumComprobante { set; get; }

        [Display(Name = "Banco")]
        public long IdBanco { set; get; }


        [Display(Name = "Banco")]
        public string NombreBanco { set; get; }
        [Display(Name = "Cta Bco. Cliente")]
        public string CtaBcoCliente { set; get; }
        [Display(Name = "Cant Cheq/Dep")]
        public long CantCheqDep { set; get; }

        public long Periodo { set; get; }


        public bool Seleccionada { set; get; }

        [Display(Name = "Estado")]
        public string EstadoModulo { set; get; }
        //dos


        [Display(Name = "Fecha")]
        public string FechaRegistro { set; get; }



    }

    public class OperacionesAjaxViewModel
    {
        public long IdOperacion { set; get; }
        public string TipoComprobante { set; get; }
        public string NumeroComprobante { set; get; }
        public string Saldo { set; get; }
        public string ValorAplicar { set; get; }
        public string ValorRetFuente { set; get; }
        public string ValorRetIva { set; get; }
    }

    public class MovimientosAjaxViewModel
    {
        public long IdMovimiento { set; get; }
        public string NumeroComprobante { set; get; }

    }




    public class ExisteAjaxViewModel
    {
        public string EXISTE { set; get; }

    }

    public class NCAjaxViewModel
    {
        public string NumeroComprobante { set; get; }
        public string EstadoModulo { set; get; }
        public string TipoMovimiento { set; get; }
        public string FormaPago { set; get; }
        public string NombreTipoNc { set; get; }

    }
    public class NotadeCreditoAjax 
    {
        public long IdMovimiento { set; get; }

        public long? IdSaldoCliente { set; get; }
        public long IdTipoMovimiento { set; get; }
        public long? IdFormaPago { set; get; }
        public long? IdTipoFormaPago { set; get; }

        public string CodigoRegistro { set; get; }
        public DateTime FechTransaccion { set; get; }
        public decimal ValorRecibido { set; get; }
        public long? IdMovimientoInformativo { set; get; }
        public long? IdMovimientoPadre { set; get; }
        public long NumCuotasTotales { set; get; }


        public string EstadoModulo { set; get; }
        public long? IdMovimientoNcCobro { set; get; }
        public DateTime? FechaAplicacionNcCobro { set; get; }
        public long? IdTipoNotaCredito { set; get; }
        public string NombreTipoNc { set; get; }
       

        public DateTime? FechaCobro { set; get; }
        public string NumSecuencia { set; get; }
        public long? IdCliente { set; get; }
        public long Idperiodo { set; get; }
        public bool? NCAplicada { set; get; }
        public long? IdEmpresa { set; get; }

        public long? IdEdificio { set; get; }


        public string CompNumSecuencia { set; get; }
        public string CompNumComprobante { set; get; }
        public long? CompIdBancoCliente { set; get; }
        public DateTime? CompFechaComprobante { set; get; }
        public string CompStringFechaComprobante { set; get; }
        public string CompCtaBcoCliente { set; get; }
    }


    public class DetalleSaldosViewModel
    {
        public long IdDocumentosSimplexDomus { set; get; }

        public decimal Deuda_Deudas { set; get; }
        public decimal Deuda_NotasDebito { set; get; }
        public decimal Deuda_NotasCredito { set; get; }
        public decimal Deuda_Total { set; get; }


        public decimal Facturas_Aplicado { set; get; }
        public decimal Total_Aplicado { set; get; }
    }

    public class ListarAplicacionesViewModel
    {
        public ListarAplicacionesViewModel()
        {
            Aplicaciones = new List<ItemAplicacionesViewModel>();
        }

        public List<ItemAplicacionesViewModel> Aplicaciones;

    }

    public class ItemAplicacionesViewModel
    {
        public long IdAplicacion { set; get; }
        public long IdMovimiento { set; get; }
        public long? IdOperacion { set; get; }

        [Display(Name = "Num. Cuota")]
        public long NumCuota { set; get; }
        [Display(Name = "Valor Aplicado")]
        public decimal ValorAplicado { set; get; }

        [Display(Name = "Valor Doc.")]
        public decimal ValorDocumento { set; get; }

        [Display(Name = "Tipo")]
        public string TipoComprobante { set; get; }
        [Display(Name = "Numero Comprobante")]
        public string NumeroComprobante { set; get; }
    }

    public class ListarNotasCreditoViewModel
    {
        public ListarNotasCreditoViewModel()
        {
            NotasCredito = new List<ItemNotaCreditoViewModel>();
        }

        [Display(Name = "Cliente")]
        public long IdCliente { set; get; }

        [Display(Name = "Periodo")]
        public long IdPeriodo { set; get; }

        public List<ItemNotaCreditoViewModel> NotasCredito;
    }

    public class ItemNotaCreditoViewModel
    {
        public long IdMovimiento { set; get; }

        //[Required]
        [Display(Name = "Nro. NC.")]
        public string NumCobro { set; get; }
        [Display(Name = "Fecha Cobro")]
        public DateTime? FechaCobro { set; get; }
        [Display(Name = "Fecha Registro")]
        public DateTime? FechaRegistro { set; get; }
        [Display(Name = "Tipo Movimiento")]
        public string NombreTipoMovimiento { set; get; }
        [Display(Name = "Tipo Movimiento")]
        public long IdTipoMovimiento { set; get; }

        [Display(Name = "Tipo Nota Crédito")]
        public long IdTipoNotaCredito { set; get; }
        [Display(Name = "Tipo Nota Crédito")]
        public string NombreTipoNotaCredito { set; get; }


        [Display(Name = "Tipo")]
        public string NombreClasificacionTipo { set; get; }

        [Display(Name = "Cliente")]
        public long IdCliente { set; get; }
        [Display(Name = "Forma Pago")]
        public long IdFormaPago { set; get; }
        [Display(Name = "Forma Pago")]
        public string NombreFormaPago { set; get; }

        [Display(Name = "Tipo Forma Pago")]
        public long IdTipoFormaPago { set; get; }
        [Display(Name = "Tipo Forma Pago")]
        public string NombreTipoFormaPago { set; get; }

        [Display(Name = "Edificio")]
        public long IdEdificio { set; get; }


        [Display(Name = "Edificio")]
        public string NombreEdificio { set; get; }


        [Display(Name = "Valor Recibido")]
        public decimal ValorRecibido { set; get; }
        [Display(Name = "Cliente")]
        public string NombreCliente { set; get; }
        [Display(Name = "Fecha Comprobante")]
        public DateTime? FechaComprobante { set; get; }
        [Display(Name = "Cta. Bancaria Empresa")]
        public long? IdCuentaBancariaEmpresa { set; get; }
        [Display(Name = "Cta. Bancaria Empresa")]
        public string NombreCuentaBancariaEmpresa { set; get; }



        [Display(Name = "Num Comprobante")]
        public string NumComprobante { set; get; }

        [Display(Name = "Banco")]
        public long? IdBancoCliente { set; get; }

        [Display(Name = "Num. Secuencia")]
        public string NumSecuencia { set; get; }

    [Display(Name = "Banco")]
        public string NombreBancoCliente { set; get; }
        [Display(Name = "Cta Bco. Cliente")]
        public string CtaBcoCliente { set; get; }
        [Display(Name = "Cant Cheq/Dep")]
        public long CantCheqDep { set; get; }

        public long Periodo { set; get; }



        public String Deuda_Facturas { set; get; }

        public String Deuda_NotasDebito { set; get; }

        public String Deuda_NotasCredito { set; get; }

        public String Deuda_Total { set; get; }

        public decimal Facturas_Aplicado { set; get; }

        public decimal Total_Aplicado { set; get; }


        // Popup
        [Display(Name = "Num. Comprobante :")]
        public String PopUpNumComprobante { set; get; }
        [Display(Name = "Forma Pago :")]
        public string PopUpTipoDocumento { set; get; }
        [Display(Name = "Operación :")]
        public long PopUpIdOperacion { set; get; }
        [Display(Name = "Valor Aplicado :")]
        public decimal PopUpValorAplicado { set; get; }
        [Display(Name = "Valor Ret. Fuente :")]
        public decimal PopUpValorRetFuente { set; get; }
        [Display(Name = "Valor Ret. Iva :")]
        public decimal PopUpValorRetIva { set; get; }

        [Display(Name = "Saldo :")]
        public string PopUpSaldo { set; get; }
    }


    public class ListarCierreViewModel
    {
        public ListarCierreViewModel()
        {
            Movimientos = new List<ItemCierreViewModel>();
        }

        [Display(Name = "Cliente")]
        public long IdCliente { set; get; }

        [Display(Name = "Periodo")]
        public long IdPeriodo { set; get; }

        [Display(Name = "Periodo")]
        public string PeriodoActivo { set; get; }


        public string TotalSaldo { set; get; }
        public string SubTotalAplicado { set; get; }

        public string FechaInicio { set; get; }
        public string FechaFinal { set; get; }


        public List<ItemCierreViewModel> Movimientos;
    }

    public class ItemCierreViewModel
    {

        public long IdSaldoCliente { set; get; }
        [Display(Name = "Perido")]
        public long Periodo { set; get; }
        [Display(Name = "Perido")]
        public long IdPeriodo { set; get; }
        [Display(Name = "Cliente")]
        public long IdCliente { set; get; }
        [Display(Name = "Cliente")]
        public string NombreCliente { set; get; }
        [Display(Name = "Saldo Cliente")]
        public string SaldoCliente { set; get; }


    }

    public class ListarDetalleCierreViewModel
    {
        public ListarDetalleCierreViewModel()
        {
            Aplicaciones = new List<ItemDetalleCierreViewModel>();
        }
        [Display(Name = "Cliente")]
        public string NombreCliente { set; get; }
        [Display(Name = "Perido")]
        public long Periodo { set; get; }

        [Display(Name = "Saldo Anterior")]
        public string SaldoInicial { set; get; }
        [Display(Name = "Nuevas Operaciones")]
        public string SaldoDocumentos { set; get; }
        [Display(Name = "Total Recaudación")]
        public string SaldoCobros { set; get; }
        [Display(Name = "Total NC Aplicadas")]
        public string SaldoAplicacionNc { set; get; }

        [Display(Name = "Saldo Actual")]
        public string SaldoCliente { set; get; }

        [Display(Name = "Valores por Aplicar")]
        public string valoresxAplicar { set; get; }


        [Display(Name = "Nc No Aplicadas")]
        public string valoresNcInternasNoAplicadas { set; get; }

        [Display(Name = "Total Notas Débito")]
        public string SaldoNotasDebito { set; get; }

        [Display(Name = "Saldo Total")]
        public string SaldoTotal { set; get; }

        //[Display(Name = "Cliente")]
        //public long IdCliente { set; get; }

        //[Display(Name = "Periodo")]
        //public long IdPeriodo { set; get; }

        //[Display(Name = "Periodo")]
        //public string PeriodoActivo { set; get; }

        public List<ItemDetalleCierreViewModel> Aplicaciones;
    }

    public class ItemDetalleCierreViewModel
    {
        //public ItemCierreViewModel()
        //{
        //    Operaciones = new List<OperacionesViewModel>();
        //    NotasCredito = new List<NotaCreditoCobrosViewModel>();
        //}
        public long IdSaldoCliente { set; get; }
        [Display(Name = "Perido")]
        public long Periodo { set; get; }
        [Display(Name = "Perido")]
        public long IdPeriodo { set; get; }
        [Display(Name = "Cliente")]
        public long IdCliente { set; get; }
        [Display(Name = "Cliente")]
        public string NombreCliente { set; get; }
        [Display(Name = "Saldo Cliente")]
        public decimal SaldoCliente { set; get; }

        [Display(Name = "Tipo Movimiento")]
        public decimal IdTipoMovimiento { set; get; }
        [Display(Name = "Tipo Movimiento")]
        public string NombreTipoMovimiento { set; get; }

        //[Display(Name = "Valor Recibido")]
        //public decimal ValorRecibido { set; get; }

        [Display(Name = "Debe")]
        public decimal ValorDebe { set; get; }


        [Display(Name = "Haber")]
        public decimal ValorHaber { set; get; }


        [Display(Name = "Num. Cuota")]
        public long NumCuota { set; get; }


        [Display(Name = "Valor Doc.")]
        public decimal ValorDocumento { set; get; }

        [Display(Name = "Tipo")]
        public string TipoComprobante { set; get; }
        [Display(Name = "Numero Comprobante")]
        public string NumeroComprobante { set; get; }

        //public List<OperacionesViewModel> Operaciones;
        //public List<NotaCreditoCobrosViewModel> NotasCredito;
    }

    public class ListarNotasDebitoViewModel
    {
        public ListarNotasDebitoViewModel()
        {
            NotasDebito = new List<ItemNotaDebitoViewModel>();
        }

        [Display(Name = "Cliente")]
        public long IdCliente { set; get; }

        [Display(Name = "Periodo")]
        public long IdPeriodo { set; get; }

        public List<ItemNotaDebitoViewModel> NotasDebito;
    }

    public class ItemNotaDebitoViewModel
    {
        public long IdMovimiento { set; get; }

        //[Required]
        [Display(Name = "Nro. Cobro")]
        public string NumCobro { set; get; }
        [Display(Name = "Fecha Transaccion")]
        public string FechaCobro { set; get; }
        [Display(Name = "Fecha Registro")]
        public DateTime? FechaRegistro { set; get; }
        [Display(Name = "Tipo Movimiento")]
        public string NombreTipoMovimiento { set; get; }
        [Display(Name = "Tipo Movimiento")]
        public long IdTipoMovimiento { set; get; }

        //[Display(Name = "Tipo Nota Crédito")]
        //public long IdTipoNotaCredito { set; get; }
        //[Display(Name = "Tipo Nota Crédito")]
        //public string NombreTipoNotaCredito { set; get; }


        [Display(Name = "Tipo")]
        public string NombreClasificacionTipo { set; get; }

        [Display(Name = "Cliente")]
        public long IdCliente { set; get; }
        [Display(Name = "Forma Pago")]
        public long IdFormaPago { set; get; }
        [Display(Name = "Forma Pago")]
        public string NombreFormaPago { set; get; }

        [Display(Name = "Tipo Forma Pago")]
        public long IdTipoFormaPago { set; get; }
        [Display(Name = "Tipo Forma Pago")]
        public string NombreTipoFormaPago { set; get; }


        [Display(Name = "Valor Recibido")]
        public decimal ValorRecibido { set; get; }
        [Display(Name = "Cliente")]
        public string NombreCliente { set; get; }
        [Display(Name = "Fecha Comprobante")]
        public DateTime? FechaComprobante { set; get; }
        [Display(Name = "Cta. Bancaria Empresa")]
        public long? IdCuentaBancariaEmpresa { set; get; }
        [Display(Name = "Cta. Bancaria Empresa")]
        public string NombreCuentaBancariaEmpresa { set; get; }

        [Display(Name = "Num Comprobante")]
        public string NumComprobante { set; get; }
        [Display(Name = "Banco")]
        public long? IdBancoCliente { set; get; }
        [Display(Name = "Num. Secuencia")]
        public string NumSecuencia { set; get; }
        [Display(Name = "Banco")]
        public string NombreBanco { set; get; }
        [Display(Name = "Cta Bco. Cliente")]
        public string CtaBcoCliente { set; get; }
        [Display(Name = "Cant Cheq/Dep")]
        public long CantCheqDep { set; get; }
        public long Periodo { set; get; }



        public String Deuda_Facturas { set; get; }
        public String Deuda_NotasDebito { set; get; }
        public String Deuda_NotasCredito { set; get; }
        public String Deuda_Total { set; get; }
        public decimal Facturas_Aplicado { set; get; }
        public decimal Total_Aplicado { set; get; }

        [Display(Name = "Saldo :")]
        public string PopUpSaldo { set; get; }
    }



    public class DetalleSaldosxDocumento
    {
        public long IdDocumentosSimplexDomus { set; get; }

        public decimal Deuda_Deudas { set; get; }
        public decimal Deuda_NotasDebito { set; get; }
        public decimal Deuda_NotasCredito { set; get; }
        public decimal Deuda_Total { set; get; }


        public decimal Facturas_Aplicado { set; get; }
        public decimal Total_Aplicado { set; get; }
    }


    public class SumarDosCantidades
    {
        public decimal Cantidad1 { set; get; }
        public decimal Cantidad2 { set; get; }
        public decimal Total { set; get; }
    }

}
