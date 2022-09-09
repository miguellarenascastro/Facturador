using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgricolaData.Entities
{
    public class CrudAuditoria
    {
        public bool Activo { set; get; }
        public string UsuarioCreacion { set; get; }
        public DateTime? FechaCreacion { set; get; }
        public string UsuarioModificacion { set; get; }
        public DateTime? FechaModificacion { set; get; }
        public string UsuarioEliminacion { set; get; }
        public DateTime? FechaEliminacion { set; get; }
    }

    public class Usuarios : CrudAuditoria
    {
        public long IdUsuario { set; get; }
        public string Nombres { set; get; }
        public string Apellidos { set; get; }
        public string Clave { set; get; }
        public string Identificacion { set; get; }
        public string Username { set; get; }
    }

    public class Cat_Usuarios : CrudAuditoria
    {
        public long IdUsuario { set; get; }
        public string Nombres { set; get; }
        public string Apellidos { set; get; }
        public string Clave { set; get; }
        public string Identificacion { set; get; }
        public string Username { set; get; }
    }


    public class Empresa : CrudAuditoria
    {
        public long IdEmpresa { set; get; }
        public string Ruc { set; get; }
        public string NombreComercial { set; get; }
        public string RazonSocial { set; get; }
        public string Direccion { set; get; }
        public long IdGrupoProductor { set; get; }
        public bool ObligadoContabilidad { set; get; }
        public string Telefono { set; get; }
        public string Ciudad { set; get; }
        public string ActividadEconomica { set; get; }
        public int NumDecimales { set; get; }
        public string Correo { set; get; }

        public string NumContribuyenteEspecial { set; get; }
    }

    public class Establecimiento : CrudAuditoria
    {
        public long IdEstablecimiento { set; get; }
        public long IdEmpresa { set; get; }
        public string Nombre { set; get; }
        public string Codigo { set; get; }
        public string Direccion { set; get; }

        public virtual Empresa Empresa { set; get; }
    }

    public class PuntoVenta : CrudAuditoria
    {
        public long IdPuntoVenta { set; get; }
        public long IdEstablecimiento { set; get; }

        public string Nombre { set; get; }
        public string Codigo { set; get; }


        public virtual Establecimiento Establecimiento { set; get; }
    }

    public class DocumentoPuntoVenta : CrudAuditoria
    {
        public long IdDocumentoporPuntoVenta { set; get; }
        public long IdEmpresa { set; get; }
        public long IdTipoDocumento { set; get; }
        public long IdPuntoVenta { set; get; }

        public int Secuencia { set; get; }

        
        public virtual TipoDocumento TipoDocumento { set; get; }
        public virtual Empresa Empresa { set; get; }
        public virtual PuntoVenta PuntoVenta { set; get; }
    }


    public class TipoDocumento : CrudAuditoria
    {
        public long IdTipoDocumento { set; get; }
        public string Codigo { set; get; }
        public string Nombre { set; get; }
    }

    public class TipoPersona : CrudAuditoria
    {
        public long IdTipoPersona { set; get; }
        public string Codigo { set; get; }
        public string Nombre { set; get; }
    }



    public class Persona : CrudAuditoria
    {
        public long IdPersona { set; get; }
        public long IdTipoTipoPersona { set; get; }
        public bool EsContribuyenteEspecial { set; get; }
        public string Ruc { set; get; }
        public string RazonSocial { set; get; }
        public string NombreComercial { set; get; }
        public string Direccion { set; get; }
        public string Telefono { set; get; }
        public bool Extranjero { set; get; }
        public string Correo { set; get; }

        public virtual TipoPersona TipoPersona { set; get; }
    }


    public class FormaPago : CrudAuditoria
    {
        public long IdFormaPago { set; get; }
        public string Codigo { set; get; }
        public string Nombre { set; get; }
    }

    public class DocumentoCabecera : CrudAuditoria
    {
        public long IdDocumentoCabecera { set; get; }
        public long IdTipoDocumento { set; get; }
        public long IdEmpresa { set; get; }
        public long IdEstablecimiento { set; get; }
        public long IdPuntoVenta { set; get; }

        public DateTime FechaEmision { set; get; }

        public long IdPersona { set; get; }
        public string Descripcion { set; get; }
        public DateTime FechaVencimiento { set; get; }
        public string DireccionMatriz { set; get; }
        public string DireccionSucursal { set; get; }
        public int NumDocumento { set; get; }
        public string Info1Direccion { set; get; }
        public string Info2Email { set; get; }
        public long IdFormaPago { set; get; }
        

        public long? IdTipoDocumentoModificado { set; get; }
        public string ComprobanteModifica { set; get; }
        public string RazonModificacion { set; get; }
        public string ClaveAccesoSri { set; get; }


        public virtual Persona Persona { set; get; }
        public virtual TipoDocumento TipoDocumento { set; get; }
        public virtual Empresa Empresa { set; get; }
        public virtual Establecimiento Establecimiento { set; get; }
        public virtual PuntoVenta PuntoVenta { set; get; }
        public virtual FormaPago FormaPago { set; get; }

    }


    public class Categoria : CrudAuditoria
    {
        public long IdCategoria { set; get; }
        public string Codigo { set; get; }
        public string Nombre { set; get; }
    }


    public class TipoItem : CrudAuditoria
    {
        public long IdTipoItem { set; get; }
        public string Codigo { set; get; }
        public string Nombre { set; get; }
    }

    public class UnidadMedida : CrudAuditoria
    {
        public long IdUnidadMedida { set; get; }
        public string Codigo { set; get; }
        public string Nombre { set; get; }
    }

    public class Impuesto : CrudAuditoria
    {
        public long IdImpuesto { set; get; }
        public string Codigo { set; get; }
        public string Nombre { set; get; }
    }

    public class Producto : CrudAuditoria
    {
        public long IdProducto { set; get; }
        public long IdTipoItem { set; get; }
        public long IdCategoria { set; get; }
        public long IdUnidadMedida { set; get; }
        public long IdImpuesto { set; get; }

        public string Codigo { set; get; }
        public string Nombre { set; get; }

        public decimal Precio { set; get; }

        public virtual TipoItem TipoItem { set; get; }
        public virtual Categoria Categoria { set; get; }
        public virtual UnidadMedida UnidadMedida { set; get; }
        public virtual Impuesto Impuesto { set; get; }

    }



    public class DocumentoDetalle : CrudAuditoria
    {
        public long IdDocumentoDetalle { set; get; }
        public long IdDocumentoCabecera { set; get; }

        public long? IdProducto { set; get; }

        public decimal Cantidad { set; get; }
        public long IdUnidadMedida { set; get; }
        public decimal Precio { set; get; }
        public long? IdRetenFuente { set; get; }
        public long? IdRetenIva { set; get; }
        public decimal Descuento { set; get; }
        public decimal SubTotal { set; get; }
        public string DetalleDocumento { set; get; }

        public virtual DocumentoCabecera DocumentoCabecera { set; get; }
        public virtual Producto Producto { set; get; }
        public virtual UnidadMedida UnidadMedida { set; get; }
    }

    public class ArchivoOrden : CrudAuditoria
    {
        public long IdArchivoOrden { set; get; }
        public long IdEmpresa { set; get; }
        public string DetalleFacturas { set; get; }

        public DateTime FechaOrden { set; get; }
        public string UsuarioCarga { set; get; }
        public string Detalle { set; get; }
    }

    public class FilaArchivoOrden : CrudAuditoria
    {
        public long IdFilaArchivoOrden { set; get; }
        public long IdArchivoOrden { set; get; }
        public string NumCedula { set; get; }
        public string NombrePersona { set; get; }
        public decimal Valor { set; get; }

        public virtual ArchivoOrden ArchivoOrden { set; get; }
    }

}



