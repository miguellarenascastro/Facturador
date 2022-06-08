using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiRest.Migrations
{
    public partial class primera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CasaComercials",
                columns: table => new
                {
                    CasacomercialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CasacomercialNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CasacomercialRuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CasacomercialDireccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CasacomercialTelefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CasacomercialEstado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CasacomercialEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CasacomercialPropietario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasaComercials", x => x.CasacomercialId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteCiruc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteDireccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteTelefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteEstado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "ComprobanteCompras",
                columns: table => new
                {
                    ComprobantecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CasacomercialId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    ComprobantecNumerocompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComprobantecFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ComprobantecDetalle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComprobantecEstado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComprobantecSubtotal0 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ComprobantecSubtotal12 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ComprobantecIvatotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ComprobantecTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ComprobantecDescuento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ComprobantecSubtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ComprobantecTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComprobantecFormapago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComprobantecNumeroserie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComprobantecNumerolocal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComprobantecNumero = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprobanteCompras", x => x.ComprobantecId);
                });

            migrationBuilder.CreateTable(
                name: "ComprobanteVenta",
                columns: table => new
                {
                    ComprobantevId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ComprobantevFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ComprobantevTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComprobantevNumero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComprobantevFormapago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComprobantevRemision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComprobantevEstado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComprobantevSubtotal0 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ComprobantevSubtotal12 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ComprobantevDescuento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ComprobantevSubtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ComprobantevIvatotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    ComprobantevTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Docsri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprobanteVenta", x => x.ComprobantevId);
                });

            migrationBuilder.CreateTable(
                name: "DetalleVenta",
                columns: table => new
                {
                    DetallevId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    ComprobantevId = table.Column<int>(type: "int", nullable: false),
                    DetallevCantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DetallevValor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DetallevEstado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetallevDescuento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DetallevTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DetallevDescuentoporc = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleVenta", x => x.DetallevId);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaRuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpresaPropietario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpresaEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpresaClasecontribuyente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpresaNumerocalificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpresaCalificacionartesanal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpresaActividadeconomica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpresaOlc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpresaEstado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpresaNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpresaDireccion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.EmpresaId);
                });

            migrationBuilder.CreateTable(
                name: "Locals",
                columns: table => new
                {
                    LocalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    LocalNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalTelefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalDireccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalActividad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalFechainicioactividad = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocalEstado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalNumero = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locals", x => x.LocalId);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoCod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductoDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductoEstado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductoValor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductoCantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductoIva = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductoFabricacion = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "Secuencials",
                columns: table => new
                {
                    SecuencialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SecuencialNumero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecuencialTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkEmpresa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secuencials", x => x.SecuencialId);
                });

            migrationBuilder.CreateTable(
                name: "Tbdatosfacturacionelectronicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkEmpresa = table.Column<int>(type: "int", nullable: false),
                    Dfecontribuyente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dfeubicacionarchivop12 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dfecontrasena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dfeimagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dfeubicacionruta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dfepruebaproduccion = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbdatosfacturacionelectronicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbdocumentosfacturacionelectronicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkComprobanteVenta = table.Column<int>(type: "int", nullable: true),
                    Empidfk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FelectEstado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FelectAmbiente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FelectNumeroautorizacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FelectFechaautorizacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FelectIdentificador = table.Column<int>(type: "int", nullable: true),
                    FelectMensaje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FelectInformacionadicional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FelectTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FelectComprobantexml = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbdocumentosfacturacionelectronicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbrutasXmls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RutaGenerado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RutaFirmado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkComprobanteVenta = table.Column<int>(type: "int", nullable: false),
                    RutaAutorizado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RutaPdf = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbrutasXmls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioEstado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioCodereset = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CasaComercials");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "ComprobanteCompras");

            migrationBuilder.DropTable(
                name: "ComprobanteVenta");

            migrationBuilder.DropTable(
                name: "DetalleVenta");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Locals");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Secuencials");

            migrationBuilder.DropTable(
                name: "Tbdatosfacturacionelectronicas");

            migrationBuilder.DropTable(
                name: "Tbdocumentosfacturacionelectronicas");

            migrationBuilder.DropTable(
                name: "TbrutasXmls");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
