namespace AgricolaData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ARTABAN_00000001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "SGR.SeguridadAreas",
                c => new
                    {
                        IdArea = c.Int(nullable: false, identity: true),
                        Guid = c.String(),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        SecurityLevel_IdNivel = c.Int(),
                    })
                .PrimaryKey(t => t.IdArea)
                .ForeignKey("SGR.SeguridadNiveles", t => t.SecurityLevel_IdNivel)
                .Index(t => t.SecurityLevel_IdNivel);
            
            CreateTable(
                "SGR.Permisos",
                c => new
                    {
                        IdPermiso = c.Long(nullable: false, identity: true),
                        Guid = c.String(),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        IdArea = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPermiso)
                .ForeignKey("SGR.SeguridadAreas", t => t.IdArea, cascadeDelete: true)
                .Index(t => t.IdArea);
            
            CreateTable(
                "SEG.Cat_Usuarios",
                c => new
                    {
                        IdUsuario = c.Long(nullable: false, identity: true),
                        Nombres = c.String(),
                        Apellidos = c.String(),
                        Clave = c.String(),
                        Identificacion = c.String(),
                        Username = c.String(),
                        Activo = c.Boolean(nullable: false),
                        UsuarioCreacion = c.String(),
                        FechaCreacion = c.DateTime(),
                        UsuarioModificacion = c.String(),
                        FechaModificacion = c.DateTime(),
                        UsuarioEliminacion = c.String(),
                        FechaEliminacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdUsuario);
            
            CreateTable(
                "CONF.Empresa",
                c => new
                    {
                        IdEmpresa = c.Long(nullable: false, identity: true),
                        Ruc = c.String(),
                        NombreComercial = c.String(),
                        RazonSocial = c.String(),
                        Direccion = c.String(),
                        IdGrupoProductor = c.Long(nullable: false),
                        ObligadoContabilidad = c.Boolean(nullable: false),
                        Telefono = c.String(),
                        Ciudad = c.String(),
                        ActividadEconomica = c.String(),
                        NumDecimales = c.Int(nullable: false),
                        Correo = c.String(),
                        Activo = c.Boolean(nullable: false),
                        UsuarioCreacion = c.String(),
                        FechaCreacion = c.DateTime(),
                        UsuarioModificacion = c.String(),
                        FechaModificacion = c.DateTime(),
                        UsuarioEliminacion = c.String(),
                        FechaEliminacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdEmpresa);
            
            CreateTable(
                "SGR.SeguridadNiveles",
                c => new
                    {
                        IdNivel = c.Int(nullable: false, identity: true),
                        Guid = c.String(),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.IdNivel);
            
            CreateTable(
                "SGR.Roles",
                c => new
                    {
                        IdRol = c.Long(nullable: false, identity: true),
                        Plural = c.String(),
                        Descripcion = c.String(),
                        Sistema = c.Boolean(nullable: false),
                        Defecto = c.Boolean(nullable: false),
                        Activo = c.Boolean(nullable: false),
                        Prioridad = c.Int(nullable: false),
                        Orden = c.Int(nullable: false),
                        FechaRegistro = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(),
                        FechaEliminacion = c.DateTime(),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.IdRol)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "SGR.RolesUsuarios",
                c => new
                    {
                        IdUsuario = c.Long(nullable: false),
                        IdRol = c.Long(nullable: false),
                        Activo = c.Boolean(nullable: false),
                        Primario = c.Boolean(nullable: false),
                        FechaRegistro = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(),
                        FechaEliminacion = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.IdUsuario, t.IdRol })
                .ForeignKey("SGR.Roles", t => t.IdRol, cascadeDelete: true)
                .ForeignKey("SGR.Usuarios", t => t.IdUsuario, cascadeDelete: true)
                .Index(t => t.IdUsuario)
                .Index(t => t.IdRol);
            
            CreateTable(
                "SGR.Usuarios",
                c => new
                    {
                        IdUsuario = c.Long(nullable: false, identity: true),
                        Nombres = c.String(),
                        Apellidos = c.String(),
                        Identificacion = c.String(),
                        Activo = c.Boolean(nullable: false),
                        FechaRegistro = c.DateTime(nullable: false),
                        FechaActivacion = c.DateTime(),
                        FechaDesactivacion = c.DateTime(),
                        FechaExpiracion = c.DateTime(),
                        FechaModificacion = c.DateTime(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.IdUsuario)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "SGR.ClaimsUsuarios",
                c => new
                    {
                        IdClaim = c.Int(nullable: false, identity: true),
                        IdUsuario = c.Long(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.IdClaim)
                .ForeignKey("SGR.Usuarios", t => t.IdUsuario, cascadeDelete: true)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "SGR.LoginsUsuarios",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        IdUsuario = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.IdUsuario })
                .ForeignKey("SGR.Usuarios", t => t.IdUsuario, cascadeDelete: true)
                .Index(t => t.IdUsuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("SGR.RolesUsuarios", "IdUsuario", "SGR.Usuarios");
            DropForeignKey("SGR.LoginsUsuarios", "IdUsuario", "SGR.Usuarios");
            DropForeignKey("SGR.ClaimsUsuarios", "IdUsuario", "SGR.Usuarios");
            DropForeignKey("SGR.RolesUsuarios", "IdRol", "SGR.Roles");
            DropForeignKey("SGR.SeguridadAreas", "SecurityLevel_IdNivel", "SGR.SeguridadNiveles");
            DropForeignKey("SGR.Permisos", "IdArea", "SGR.SeguridadAreas");
            DropIndex("SGR.LoginsUsuarios", new[] { "IdUsuario" });
            DropIndex("SGR.ClaimsUsuarios", new[] { "IdUsuario" });
            DropIndex("SGR.Usuarios", "UserNameIndex");
            DropIndex("SGR.RolesUsuarios", new[] { "IdRol" });
            DropIndex("SGR.RolesUsuarios", new[] { "IdUsuario" });
            DropIndex("SGR.Roles", "RoleNameIndex");
            DropIndex("SGR.Permisos", new[] { "IdArea" });
            DropIndex("SGR.SeguridadAreas", new[] { "SecurityLevel_IdNivel" });
            DropTable("SGR.LoginsUsuarios");
            DropTable("SGR.ClaimsUsuarios");
            DropTable("SGR.Usuarios");
            DropTable("SGR.RolesUsuarios");
            DropTable("SGR.Roles");
            DropTable("SGR.SeguridadNiveles");
            DropTable("CONF.Empresa");
            DropTable("SEG.Cat_Usuarios");
            DropTable("SGR.Permisos");
            DropTable("SGR.SeguridadAreas");
        }
    }
}
