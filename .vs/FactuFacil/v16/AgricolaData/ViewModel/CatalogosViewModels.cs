using Agricola.Seguridad.Entidades;
using AgricolaData.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgricolaData.ViewModel
{


    public class ListarUsuariosViewModel
    {
        public ListarUsuariosViewModel()
        {
            Usuarios = new List<Usuarios>();
        }
        public List<Usuarios> Usuarios;
    }

    public class ListarRolesViewModel
    {
        public ListarRolesViewModel()
        {
            Roles = new List<AgricolaRoles>();
        }

        public List<AgricolaRoles> Roles;
    }


    public class LoginViewModel
    {
        public string usuario { set; get; }
        public string clave { set; get; }
        public string mensaje { set; get; }
        public bool RememberMe { get; set; }
        public long? IdEmpresa { get; set; }
    }
    public class RollViewModel
    {
        public long? IdRoll { set; get; }
        [Required]
        public string Nombre { set; get; }
        [Required]
        public string Singular { set; get; }
        [Required]
        public string Plural { set; get; }
        [Required]
        public int Prioridad { set; get; }

        public string Descripcion { set; get; }
    }
    public class UsuarioViewModel
    {
        public long? IdUsuario { set; get; }
        [Required]
        public string Nombres { set; get; }
        [Required]
        public string Apellidos { set; get; }
        [Required]
        public string Identificacio { set; get; }
        [Required]
        [Display(Name = "Usuario")]
        public string UserName { set; get; }

        [Display(Name = "Clave")]
        public string Clave { set; get; }
    }

    public class ListarClientesViewModel
    {
        public ListarClientesViewModel()
        {
            Clientes = new List<ItemClientesViewModel>();
        }

        public List<ItemClientesViewModel> Clientes;
    }

    public class ItemClientesViewModel
    {
        public long? IdCliente { set; get; }
        [Display(Name = "Código Cliente ")]
        public string CodCliente { set; get; }
        [Display(Name = "Tipo Cliente")]
        public long IdTipoCliente { set; get; }
        [Display(Name = "Tipo")]
        public string NombreTipoCliente { set; get; }
        [Display(Name = "Tipo Identificación")]
        public long IdTipoIdentificacion { set; get; }
        [Display(Name = "Tipo Identificación")]
        public string NombreTipoIdentificacion { set; get; }
        public string Identificacion { set; get; }
        public string Nombre { set; get; }
        [Display(Name = "Sector Producción")]
        public long? IdSectorProduccion { set; get; }
        [Display(Name = "Sector Producción")]
        public string NombreSectorProduccion { set; get; }
        [Display(Name = "Actividad Económica")]
        public long? IdActividadEconomica { set; get; }
        [Display(Name = "Actividad Económica")]
        public string NombreActividadEconomica { set; get; }
        [Display(Name = "Grupo Económico")]
        public long? IdGrupoEconomico { set; get; }
        [Display(Name = "Grupo Económico")]
        public string NombreGrupoEconomico { set; get; }
        [Display(Name = "Pais")]
        public long? IdPais { set; get; }
        [Display(Name = "Pais")]
        public string NombrePais { set; get; }
        [Display(Name = "Provincia")]
        public long? IdProvincia { set; get; }
        [Display(Name = "Provincia")]
        public string NombreProvincia { set; get; }
        [Display(Name = "Ciudad")]
        public long? IdCiudad { set; get; }
        [Display(Name = "Ciudad")]
        public string NombreCiudad { set; get; }
        [Display(Name = "Parroqui")]
        public long? IdParroquia { set; get; }
        [Display(Name = "Parroquia")]
        public string NombreParroquia { set; get; }
        [Display(Name = "Barrio")]
        public string Barrio { set; get; }
        [Display(Name = "Dirección 1")]
        public string Direccion1 { set; get; }
        [Display(Name = "Dirección 2")]
        public string Direccion2 { set; get; }
        [Display(Name = "Teléfono 1")]
        public string Telefono1 { set; get; }
        [Display(Name = "Teléfono 2")]
        public string Telefono2 { set; get; }
        [Display(Name = "Celular")]
        public string Celular1 { set; get; }
        [Display(Name = "Correo")]
        public string CorreoFactura { set; get; }
        [Display(Name = "Central de Riesgo")]
        public bool CentralRiesgo { set; get; }
        [Display(Name = "Calificación")]
        public long? IdCalificacionCredito { set; get; }
        [Display(Name = "Calificación")]
        public string NombreCalificacionCredito { set; get; }
        [Display(Name = "Calificación")]
        public decimal? Calificacion { set; get; }
        [Display(Name = "Oficial de Credito")]
        public long? IdOficialCredito { set; get; }
        [Display(Name = "Oficial de Credito")]
        public string NombreOficialCredito { set; get; }
        public string PEP { set; get; }
        [Display(Name = "Banco")]
        public long? IdBanco { set; get; }
        [Display(Name = "Banco")]
        public string NombreBanco { set; get; }
        [Display(Name = "# Cuenta")]
        public string NumCuenta { set; get; }
        [Display(Name = "Canton")]
        public long? IdCanton { set; get; }
        [Display(Name = "Canton")]
        public string NombreCanton { set; get; }

        //PERSONA NATURAL
        public long IdDatosPersonaNatural { set; get; }


        public string Nombres { set; get; }
        public string Apellidos { set; get; }
        [Display(Name = "Genero")]
        public long? IdGenero { set; get; }
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? FechaNacimiento { set; get; }
        [Display(Name = "Nivel Academico")]
        public long? IdNivelAcademico { set; get; }
        [Display(Name = "Profesión")]
        public long? IdProfesion { set; get; }
        [Display(Name = "Pers. Dependen")]
        public int PersDependen { set; get; }
        public decimal Patrimonio { set; get; }
        [Display(Name = "Demanda Judicial")]
        public decimal DemandaJudicial { set; get; }
        [Display(Name = "Estado Civil")]
        public long? IdEstadoCivil { set; get; }

        public long? IdConyuge { set; get; }
        [Display(Name = "Tipo Vivienda")]
        public long? IdTipoVivienda { set; get; }
        [Display(Name = "Año Vivienda")]
        public int? AnioVivienda { set; get; }
        [Display(Name = "Arriendatario")]
        public string NombreArriendatario { set; get; }
        [Display(Name = "Tipo Actividad")]
        public long? IdTipoActividad { set; get; }
        // CONYUGE
        [Display(Name = "Nombres")]
        public string Conyuge_Nombres { set; get; }
        [Display(Name = "Apellidos")]
        public string Conyuge_Apellidos { set; get; }
        [Display(Name = "Teléfono")]
        public string Conyuge_TelfCelular { set; get; }
        [Display(Name = "Separacion de Bienes")]
        public bool Conyuge_SeparacionBienes { set; get; }
        [Display(Name = "Capitulaciones Matrimoniales")]
        public bool Conyuge_CapitulacionesMatrimoniales { set; get; }
        [Display(Name = "Identificación")]
        public string Conyuge_TIdentificacion { set; get; }

    }

    public class ListarAseguradorasViewModel
    {
        public ListarAseguradorasViewModel()
        {
            Aseguradoras = new List<ItemAseguradoraViewModel>();
        }

        public List<ItemAseguradoraViewModel> Aseguradoras;
    }

    public class ItemAseguradoraViewModel
    {
        public long? IdCIAAseguradora { set; get; }
        [Display(Name = "Codigo")]
        public string Codigo { set; get; }
        [Display(Name = "Nombre")]
        public string Nombre { set; get; }
        [Display(Name = "Valor de Cobertura")]
        public decimal ValorCobertura { set; get; }
        [Display(Name = "Valor de Emision")]
        public decimal ValorEmision { set; get; }
        [Display(Name = "% Prima")]
        public decimal Prima { set; get; }
        [Display(Name = "% Ret. Fuente")]
        public decimal RetFuente { set; get; }
        [Display(Name = "% Seguro Campesino")]
        public decimal SeguroCampesino { set; get; }
    }




    public class ListarTasasBCEViewModel
    {
        public ListarTasasBCEViewModel()
        {
            Tasas = new List<ItemTasaBCEViewModel>();
        }

        public List<ItemTasaBCEViewModel> Tasas;
    }

    public class ItemTasaBCEViewModel
    {
        public long? IdTasaMensualBCE { set; get; }
        [Display(Name = "Año")]
        public int Anio { set; get; }
        [Display(Name = "Mes")]
        public int Mes { set; get; }
        [Display(Name = "Tasa Pasiva")]
        public decimal TasaPasiva { set; get; }
        [Display(Name = "Tasa Maxima")]
        public decimal TasaMaxima { set; get; }
    }



    public class ListarVentaCarteraViewModel
    {
        public ListarVentaCarteraViewModel()
        {
            Carteras = new List<ItemVentaCarteraViewModel>();
        }

        public List<ItemVentaCarteraViewModel> Carteras;
    }

    public class ItemVentaCarteraViewModel
    {

        public long? IdVentaCartera { set; get; }
        [Display(Name = "Comprador")]
        public long IdComprador { set; get; }
        [Display(Name = "Comprador")]
        public string NombreComprador { set; get; }
        [Display(Name = "Cód. Venta")]
        public string CodigVenta { set; get; }
        [Display(Name = "Nombre Venta")]
        public string NombreVenta { set; get; }
        [Display(Name = "Capital Vendido	")]
        public decimal CapitalVendido { set; get; }
        [Display(Name = "Fecha de Venta")]
        public DateTime FechaVenta { set; get; }
        [Display(Name = "Distintivo para Reportes")]
        public string DistintivoReportes { set; get; }
        [Display(Name = "Porcentaje Castigo Mora")]
        public decimal PorcentajeCastigoMora { set; get; }
        [Display(Name = "Porción de la Tasa de Interés Castigada")]
        public decimal PorcionasaInteresCastigada { set; get; }
        [Display(Name = "Porcentaje Castigo Capital")]
        public decimal PorcentajeCastigoCapital { set; get; }


        [Display(Name = "Gestión de Cobro")]
        public bool GestionCobro { set; get; }

    }



    public class ListarParticipanteViewModel
    {
        public ListarParticipanteViewModel()
        {
            Participantes = new List<ItemParticipanteViewModel>();
        }

        public List<ItemParticipanteViewModel> Participantes;
    }

    public class ItemParticipanteViewModel
    {

        public long? IdParticipante { set; get; }

        [Display(Name = "Código")]
        public int susCodigo { set; get; }
        [Display(Name = "Código")]
        public int partCodigo { set; get; }
        [Display(Name = "Nombre")]
        public string partNombre { set; get; }
        [Display(Name = "Tipo Cliente")]
        public long IdTipoCliente { set; get; }
        [Display(Name = "Tipo Cliente")]
        public string NombreTipoCliente { set; get; }
        [Display(Name = "Tipo Identificación")]
        public long? IdTipoIdentificacion { set; get; }
        [Display(Name = "Tipo Identificación")]
        public string NombreTipoIdentificacion { set; get; }

        [Display(Name = "Género")]
        public long? IdGenero { set; get; }
        [Display(Name = "Estado Civil")]
        public long? IdEstadoCivil { set; get; }
        [Display(Name = "Fecha Creación")]
        public DateTime? partFechaCreacion { set; get; }
        [Display(Name = "PartUltTelefono")]
        public int? PartUltTelefono { set; get; }
        [Display(Name = "PartUltimoEmail")]
        public int? PartUltimoEmail { set; get; }
        [Display(Name = "PartUltImagen")]
        public int? PartUltImagen { set; get; }
        [Display(Name = "PartUltimaDireccion")]
        public int? PartUltimaDireccion { set; get; }
        [Display(Name = "Apellidos")]
        public string partApellidos { set; get; }
        [Display(Name = "Nombres")]
        public string partNombres { set; get; }
        [Display(Name = "Identificación")]
        public string partIdentificacion { set; get; }
        [Display(Name = "Comentarios")]
        public string partComentarios { set; get; }
        [Display(Name = "Título")]
        public string partTitulo { set; get; }
        [Display(Name = "Fecha Nacimiento")]
        public DateTime? partFechaNacimiento { set; get; }
        [Display(Name = "Razón Social")]
        public string partRazonSocial { set; get; }
        [Display(Name = "Nombre Comercial")]
        public string partNombreComercial { set; get; }
        [Display(Name = "Estado")]
        public string PartEstado { set; get; }

        public string PartLogin { set; get; }
        public string PartPassword { set; get; }

        [Display(Name = "Tipo Organización")]
        public int partTipoOrganizacion { set; get; }
        [Display(Name = "Es Dependiente")]
        public bool PartEsDependiente { set; get; }
        [Display(Name = "")]
        public string PartPasswordConfirmar { set; get; }
        [Display(Name = "Nacionalidad")]
        public string partNacionalidad { set; get; }
        [Display(Name = "")]
        public string partCodigoAlterno { set; get; }
        [Display(Name = "Teléfono")]
        public string partTelefono { set; get; }
        [Display(Name = "Dirección")]
        public string partDireccion { set; get; }
        [Display(Name = "Email para Facturación Electrónica")]
        public string partEmailFactuaElec { set; get; }


    }


    public class ListarFeriadosViewModel
    {
        public ListarFeriadosViewModel()
        {
            Feriados = new List<ItemFeriadosViewModel>();
        }

        public List<ItemFeriadosViewModel> Feriados;
    }

    public class ItemFeriadosViewModel
    {
        public long? IdFeriado { set; get; }
        [Display(Name = "Nombre")]
        public string Nombre { set; get; }
        [Display(Name = "Observación")]
        public string Observacion { set; get; }
        [Display(Name = "Fecha")]
        public DateTime FechaFeriado { set; get; }
    }

    public class ListarTiposNCViewModel
    {
        public ListarTiposNCViewModel()
        {
            Tipos = new List<ItemTipoNcViewModel>();
        }

        public List<ItemTipoNcViewModel> Tipos;
    }

    public class ItemTipoNcViewModel
    {
        public ItemTipoNcViewModel()
        {
            Cuentas = new List<ItemCuentaContableViewModel>();
        }


        [Display(Name = "Tipo Nota Crédito")]
        public long? IdTipoNotaCredito { set; get; }
        [Display(Name = "Código")]
        public string Codigo { set; get; }
        [Display(Name = "Descripción")]
        public string Descripcion { set; get; }
        [Display(Name = "Sub Cuenta Deudora")]
        public string SubCuentaDeudora { set; get; }
        [Display(Name = "Tipo")]
        public long ClasificacionTipo { set; get; }


        [Display(Name = "Tipo")]
        public string NombreClasificacionTipo { set; get; }
        [Display(Name = "Secuencia")]
        public long SecuenciaTipoNotaCredito { set; get; }


        public List<ItemCuentaContableViewModel> Cuentas;
    }


    public class ItemCuentaContableViewModel
    {


        [Display(Name = "Sub. Cuenta")]
        public decimal subCuenta { set; get; }
        [Display(Name = "Nombre")]
        public String subNombre { set; get; }
        [Display(Name = "Código")]
        public string ctaCodigo { set; get; }

    }


    public class ListarInformeRecuadacionViewModel
    {
        public ListarInformeRecuadacionViewModel()
        {
            Elemento = new List<ItemInformRecaudacionViewModel>();
        }

        public List<ItemInformRecaudacionViewModel> Elemento;
    }

    public class ItemInformRecaudacionViewModel
    {
        [Display(Name = "Fecha Depósito")]
        public DateTime FechaDeposito { set; get; }
        [Display(Name = "Proyecto")]
        public string Proyecto { set; get; }
        [Display(Name = "Cliente")]
        public string NombreCliente { set; get; }
        [Display(Name = "Concepto")]
        public string Concepto { set; get; }
        [Display(Name = "Acreedor")]
        public string Acreedor { set; get; }
        [Display(Name = "Número Cta Cte")]
        public string NumeroCtaCte { set; get; }
        [Display(Name = "Valor Recibido")]
        public decimal ValorRecibido { set; get; }
        [Display(Name = "Retenciones")]
        public decimal ValorRetenciones { set; get; }
        [Display(Name = "Notas Credito")]
        public decimal ValorNotasCredito { set; get; }
        [Display(Name = "Total Recaudado")]
        public decimal ValorTotalRecaudado { set; get; }
    }


    public class ListarPeriodosViewModel
    {
        public ListarPeriodosViewModel()
        {
            Periodos = new List<ItemPeriodoViewModel>();
        }

        public List<ItemPeriodoViewModel> Periodos;
    }

    public class ItemPeriodoViewModel
    {
        public long? IdPeriodo { set; get; }
        [Display(Name = "Empresa")]
        public long IdEmpresa { set; get; }
        [Display(Name = "Num. Periodo")]
        public long NumPeriodo { set; get; }
        [Display(Name = "Año")]
        public long AnioPeriodo { set; get; }
        [Display(Name = "Fecha Inicio")]
        public DateTime FechaInicio { set; get; }
        [Display(Name = "Fecha Termino")]
        public DateTime FechaFinal { set; get; }
        [Display(Name = "Estado")]
        public string EstadoModulo { set; get; }
    }



    public class ListarEmpresaViewModel
    {
        public ListarEmpresaViewModel()
        {
            Empresas = new List<ItemEmpresaViewModel>();
        }

        public List<ItemEmpresaViewModel> Empresas;
    }

    public class ItemEmpresaViewModel
    {
        [Display(Name = "Empresa")]
        public long IdEmpresa { set; get; }

        [Display(Name = "RUC.")]
        public string ciaRUC { set; get; }
        [Display(Name = "Razón Social")]
        public string ciaRazonSocial { set; get; }
        [Display(Name = "Nombre Comercial")]
        public string ciaNombreComercial { set; get; }
        [Display(Name = "Dirección")]
        public string ciaDireccion { set; get; }

        [Display(Name = "Grupo Productor")]
        public long IdGrupoProductor { set; get; }
        [Display(Name = "Grupo Productor")]
        public string NombreGrupoProductor { set; get; }

    }

    public class ItemDocumentoViewModel
    {
        public ItemDocumentoViewModel()
        {
            Detalle = new List<ItemDetalleDocumentoViewModel>();
        }

        [Display(Name = "Documento")]
        public long IdDocumentoCabecera { set; get; }
        [Display(Name = "Tipo de Documento")]
        public long IdTipoDocumento { set; get; }
        [Display(Name = "Empresa")]
        public long IdEmpresa { set; get; }
        [Display(Name = "Establecimiento")]
        public long IdEstablecimiento { set; get; }
        [Display(Name = "Punto de Venta")]
        public long IdPuntoVenta { set; get; }
        [Display(Name = "Fecha Emisión")]
        public DateTime FechaEmision { set; get; }
        [Display(Name = "Persona")]
        public long IdPersona { set; get; }
        [Display(Name = "Descripción")]
        public string Descripcion { set; get; }
        [Display(Name = "Fecha Vencimiento")]
        public DateTime FechaVencimiento { set; get; }
        [Display(Name = "Dirección Matriz")]
        public string DireccionMatriz { set; get; }
        [Display(Name = "Dirección Sucursal")]
        public string DireccionSucursal { set; get; }
        [Display(Name = "Número Documento")]
        public int NumDocumento { set; get; }
        [Display(Name = "Dirección")]
        public string Info1Direccion { set; get; }
        [Display(Name = "Email")]
        public string Info2Email { set; get; }
        [Display(Name = "Forma de Pago")]
        public long IdFormaPago { set; get; }


        public long IdTipoDocumentoModificado { set; get; }
        public string ComprobanteModifica { set; get; }
        public string RazonModificacion { set; get; }

       

        public List<ItemDetalleDocumentoViewModel> Detalle;

    }

    public class ItemDetalleDocumentoViewModel
    {

        public long? IdDocumentoDetalle { set; get; }
        public long? IdDocumentoCabecera { set; get; }

        public long IdProducto { set; get; }
        public string NombreProducto { set; get; }

        public decimal? Cantidad { set; get; }
        public long? IdUnidadMedida { set; get; }
        public string NombreUnidadMedida { set; get; }
        public decimal? Precio { set; get; }
        public long? IdRetenFuente { set; get; }
        public long? IdRetenIva { set; get; }
        public decimal? Descuento { set; get; }
        public decimal? SubTotal { set; get; }

    }


    public class ItemFilaArchivoViewModel
    {
        public long? NumFila { set; get; }
        public string Detalle { set; get; }
        public bool ClienteEncontrado { set; get; }
    }




    public class ListarArchivoOrdenViewModel
    {
        public ListarArchivoOrdenViewModel()
        {
            Archivos = new List<ItemArchivoViewModel>();
        }

        public List<ItemArchivoViewModel> Archivos;
    }



    
    public class ItemArchivoViewModel : CrudAuditoria
    {
        public long IdArchivoOrden { set; get; }
        public long IdEmpresa { set; get; }
        public DateTime FechaOrden { set; get; }
        public string UsuarioCarga { set; get; }
        public string Detalle { set; get; }
        public long IdFilaArchivoOrden { set; get; }
        public string NumCedula { set; get; }
        public string NombrePersona { set; get; }
        public decimal Valor { set; get; }
    }


    public class ListarArchivoOrdenPagoViewModel
    {
        public ListarArchivoOrdenPagoViewModel()
        {
            Filas = new List<ItemFilaArchivoViewModel>();
        }
        public List<ItemFilaArchivoViewModel> Filas;



        public long IdClienteTablaAmortizacion { set; get; }
        [Display(Name = "Cliente")]
        public long IdCliente { set; get; }
        [Display(Name = "Cliente")]
        public string NombreCliente { set; get; }

        [Display(Name = "Empresa")]
        public long IdEmpresa { set; get; }
        [Display(Name = "Empresa")]
        public string NombreEmpresa { set; get; }

        [Display(Name = "Días Tabla")]
        public long DiasTabla { set; get; }
        [Display(Name = "Fecha Contrato")]
        public DateTime? FechaContrato { set; get; }


        [Display(Name = "Lote")]
        public long? IdLote { set; get; }

        [Display(Name = "Concepto")]
        public long? IdConcepto { set; get; }

        [Display(Name = "Descar Plantilla")]
        public string Url_Plantilla { set; get; }


        [Display(Name = "Detalle Facturas")]
        public string Detalle { set; get; }
    }





}

