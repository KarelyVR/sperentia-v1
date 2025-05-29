using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sperientia___SGI.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FotografiaUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Beneficio",
                schema: "dbo",
                columns: table => new
                {
                    IdBeneficio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Benefici__14B7CA0C1D118B54", x => x.IdBeneficio)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "CapacitacionTipo",
                schema: "dbo",
                columns: table => new
                {
                    IdCapacitacionTipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Capacita__46690681113D0F7B", x => x.IdCapacitacionTipo)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Departamento",
                schema: "dbo",
                columns: table => new
                {
                    IdDepartamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Departam__787A433D36EBF1C2", x => x.IdDepartamento)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Divisa",
                schema: "dbo",
                columns: table => new
                {
                    IdDivisa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Divisa__DA960DCBE9A209AB", x => x.IdDivisa)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                schema: "dbo",
                columns: table => new
                {
                    IdEmpresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Empresa__5EF4033E05E4F6AB", x => x.IdEmpresa)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "EstadoCivil",
                schema: "dbo",
                columns: table => new
                {
                    IdEstadoCivil = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EstadoCi__889DE1B295F28A79", x => x.IdEstadoCivil)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "InventarioCategoria",
                schema: "dbo",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Inventar__A3C02A10AD3B8676", x => x.IdCategoria)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "NivelEstudio",
                schema: "dbo",
                columns: table => new
                {
                    IdNivelEstudio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NivelEst__FF408A03D08D14CA", x => x.IdNivelEstudio)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                schema: "dbo",
                columns: table => new
                {
                    IdPais = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pais__FC850A7BE374204E", x => x.IdPais)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Pronombre",
                schema: "dbo",
                columns: table => new
                {
                    IdPronombre = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pronombr__36F24BB1DC4D5397", x => x.IdPronombre)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "SolicitudVacacionesEstatus",
                schema: "dbo",
                columns: table => new
                {
                    IdEstatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Solicitu__B32BA1C7F59265F2", x => x.IdEstatus)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "TallaPlayera",
                schema: "dbo",
                columns: table => new
                {
                    IdTallaPlayera = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Talla = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TallaPla__7F77601606E4CDD9", x => x.IdTallaPlayera)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "TipoContrato",
                schema: "dbo",
                columns: table => new
                {
                    IdTipoContrato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TipoCont__F46C49C2E9581F4E", x => x.IdTipoContrato)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ausencia",
                schema: "dbo",
                columns: table => new
                {
                    IdAusencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "date", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "date", nullable: true),
                    MotivoAusencia = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ausencia__0B5BA4140848C245", x => x.IdAusencia)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Ausencia_Usuario",
                        column: x => x.IdUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Direccion",
                schema: "dbo",
                columns: table => new
                {
                    IdDireccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Latitud = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: true),
                    Longitud = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: true),
                    GoogleMapsUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ComprobanteDomicilioUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Direccio__1F8E0C76D3DAB651", x => x.IdDireccion)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Direccion_Usuario",
                        column: x => x.IdUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BeneficioUsuario",
                schema: "dbo",
                columns: table => new
                {
                    IdUsuarioInformacion = table.Column<int>(type: "int", nullable: false),
                    IdBeneficio = table.Column<int>(type: "int", nullable: false),
                    EstaAsignado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Benefici__94AE11924D7993CA", x => new { x.IdUsuarioInformacion, x.IdBeneficio })
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_BeneficioUsuario_Beneficio",
                        column: x => x.IdBeneficio,
                        principalSchema: "dbo",
                        principalTable: "Beneficio",
                        principalColumn: "IdBeneficio");
                    table.ForeignKey(
                        name: "FK_BeneficioUsuario_Usuario",
                        column: x => x.IdUsuarioInformacion,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CapacitacionUsuario",
                schema: "dbo",
                columns: table => new
                {
                    IdCapacitacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdCapacitacionTipo = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Capacita__B3A1D353BA92BC63", x => x.IdCapacitacion)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_CapacitacionUsuario_CapacitacionTipo",
                        column: x => x.IdCapacitacionTipo,
                        principalSchema: "dbo",
                        principalTable: "CapacitacionTipo",
                        principalColumn: "IdCapacitacionTipo");
                    table.ForeignKey(
                        name: "FK_CapacitacionUsuario_Usuario",
                        column: x => x.IdUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Servicio",
                schema: "dbo",
                columns: table => new
                {
                    IdServicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    CostoDivisa = table.Column<int>(type: "int", nullable: false),
                    CostoFrecuencia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MetodoPago = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FechaAdquisicion = table.Column<DateTime>(type: "date", nullable: true),
                    CuentaRegistrada = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Contrasena = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UltimaModificacionContrasena = table.Column<DateTime>(type: "datetime", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Notas = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Servicio__2DCCF9A299E17E3D", x => x.IdServicio)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Servicio_Divisa",
                        column: x => x.CostoDivisa,
                        principalSchema: "dbo",
                        principalTable: "Divisa",
                        principalColumn: "IdDivisa");
                });

            migrationBuilder.CreateTable(
                name: "Inventario",
                schema: "dbo",
                columns: table => new
                {
                    IdInventario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoInterno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    FechaCompra = table.Column<DateTime>(type: "date", nullable: true),
                    Costo = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    Proveedor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Inventar__1927B20C818BEB6A", x => x.IdInventario)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Inventario_Categoria",
                        column: x => x.IdCategoria,
                        principalSchema: "dbo",
                        principalTable: "InventarioCategoria",
                        principalColumn: "IdCategoria");
                });

            migrationBuilder.CreateTable(
                name: "SolicitudVacaciones",
                schema: "dbo",
                columns: table => new
                {
                    IdSolicitud = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpleado = table.Column<int>(type: "int", nullable: false),
                    FechaSolicitud = table.Column<DateTime>(type: "datetime", nullable: false),
                    DerechoDiasEmpleado = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioRH = table.Column<int>(type: "int", nullable: true),
                    IdEstatus = table.Column<int>(type: "int", nullable: false),
                    SustitutoNombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SustitutoTelefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Solicitu__36899CEF4410E6C2", x => x.IdSolicitud)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_SolicitudVacaciones_Empleado",
                        column: x => x.IdEmpleado,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SolicitudVacaciones_Estatus",
                        column: x => x.IdEstatus,
                        principalSchema: "dbo",
                        principalTable: "SolicitudVacacionesEstatus",
                        principalColumn: "IdEstatus");
                    table.ForeignKey(
                        name: "FK_SolicitudVacaciones_UsuarioRH",
                        column: x => x.IdUsuarioRH,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsuarioInformacion",
                schema: "dbo",
                columns: table => new
                {
                    IdUsuarioLogin = table.Column<int>(type: "int", nullable: false),
                    IdPronombre = table.Column<int>(type: "int", nullable: true),
                    IdEstadoCivil = table.Column<int>(type: "int", nullable: false),
                    IdPais = table.Column<int>(type: "int", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IdTallaPlayera = table.Column<int>(type: "int", nullable: true),
                    IdNivelEstudio = table.Column<int>(type: "int", nullable: false),
                    CedulaProfesional = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CurriculumVitaeUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ActaNacimientoUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Banco = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BancoCLABE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NumeroSeguroSocial = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RFC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CURP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IdentificadorNacional = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NumeroColaborador = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdTipoContrato = table.Column<int>(type: "int", nullable: false),
                    Puesto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false),
                    IdDepartamento = table.Column<int>(type: "int", nullable: false),
                    IdSupervisor = table.Column<int>(type: "int", nullable: true),
                    FechaIngreso = table.Column<DateTime>(type: "date", nullable: false),
                    FechaIngresoAsalariado = table.Column<DateTime>(type: "date", nullable: true),
                    FechaFinContrato = table.Column<DateTime>(type: "date", nullable: true),
                    DuracionJornada = table.Column<int>(type: "int", nullable: true),
                    Sueldo = table.Column<int>(type: "int", nullable: false),
                    SueldoDivisa = table.Column<int>(type: "int", nullable: false),
                    Notas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiasDisponiblesVacaciones = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UsuarioI__9E973030AF5A6385", x => x.IdUsuarioLogin)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_UsuarioInformacion_Departamento",
                        column: x => x.IdDepartamento,
                        principalSchema: "dbo",
                        principalTable: "Departamento",
                        principalColumn: "IdDepartamento");
                    table.ForeignKey(
                        name: "FK_UsuarioInformacion_Divisa",
                        column: x => x.SueldoDivisa,
                        principalSchema: "dbo",
                        principalTable: "Divisa",
                        principalColumn: "IdDivisa");
                    table.ForeignKey(
                        name: "FK_UsuarioInformacion_Empresa",
                        column: x => x.IdEmpresa,
                        principalSchema: "dbo",
                        principalTable: "Empresa",
                        principalColumn: "IdEmpresa");
                    table.ForeignKey(
                        name: "FK_UsuarioInformacion_EstadoCivil",
                        column: x => x.IdEstadoCivil,
                        principalSchema: "dbo",
                        principalTable: "EstadoCivil",
                        principalColumn: "IdEstadoCivil");
                    table.ForeignKey(
                        name: "FK_UsuarioInformacion_NivelEstudio",
                        column: x => x.IdNivelEstudio,
                        principalSchema: "dbo",
                        principalTable: "NivelEstudio",
                        principalColumn: "IdNivelEstudio");
                    table.ForeignKey(
                        name: "FK_UsuarioInformacion_Pais",
                        column: x => x.IdPais,
                        principalSchema: "dbo",
                        principalTable: "Pais",
                        principalColumn: "IdPais");
                    table.ForeignKey(
                        name: "FK_UsuarioInformacion_Pronombre",
                        column: x => x.IdPronombre,
                        principalSchema: "dbo",
                        principalTable: "Pronombre",
                        principalColumn: "IdPronombre");
                    table.ForeignKey(
                        name: "FK_UsuarioInformacion_Supervisor",
                        column: x => x.IdSupervisor,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsuarioInformacion_TallaPlayera",
                        column: x => x.IdTallaPlayera,
                        principalSchema: "dbo",
                        principalTable: "TallaPlayera",
                        principalColumn: "IdTallaPlayera");
                    table.ForeignKey(
                        name: "FK_UsuarioInformacion_TipoContrato",
                        column: x => x.IdTipoContrato,
                        principalSchema: "dbo",
                        principalTable: "TipoContrato",
                        principalColumn: "IdTipoContrato");
                    table.ForeignKey(
                        name: "FK_UsuarioInformacion_UsuarioLogin",
                        column: x => x.IdUsuarioLogin,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServicioUsuario",
                schema: "dbo",
                columns: table => new
                {
                    IdServicio = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    FechaAsignacion = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Servicio__487AA25BF6517A1A", x => new { x.IdServicio, x.IdUsuario })
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_ServicioUsuario_Servicio",
                        column: x => x.IdServicio,
                        principalSchema: "dbo",
                        principalTable: "Servicio",
                        principalColumn: "IdServicio");
                    table.ForeignKey(
                        name: "FK_ServicioUsuario_Usuario",
                        column: x => x.IdUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InventarioAsignacion",
                schema: "dbo",
                columns: table => new
                {
                    IdInventario = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "date", nullable: false),
                    FechaDevolucion = table.Column<DateTime>(type: "date", nullable: true),
                    Nota = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Inventar__7C91E9F51745367F", x => new { x.IdInventario, x.IdUsuario })
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_InventarioAsignacion_Inventario",
                        column: x => x.IdInventario,
                        principalSchema: "dbo",
                        principalTable: "Inventario",
                        principalColumn: "IdInventario");
                    table.ForeignKey(
                        name: "FK_InventarioAsignacion_Usuario",
                        column: x => x.IdUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InventarioGeneral",
                schema: "dbo",
                columns: table => new
                {
                    IdInventario = table.Column<int>(type: "int", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NumeroSerie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EstadoCondicion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GarantiaFechaFin = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Inventar__1927B20CB37CD388", x => x.IdInventario)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_InventarioGeneral_Inventario",
                        column: x => x.IdInventario,
                        principalSchema: "dbo",
                        principalTable: "Inventario",
                        principalColumn: "IdInventario");
                });

            migrationBuilder.CreateTable(
                name: "InventarioLibro",
                schema: "dbo",
                columns: table => new
                {
                    IdInventario = table.Column<int>(type: "int", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Reseña = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Editorial = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EsDigital = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Inventar__1927B20C6FD6ACD2", x => x.IdInventario)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_InventarioLibro_Inventario",
                        column: x => x.IdInventario,
                        principalSchema: "dbo",
                        principalTable: "Inventario",
                        principalColumn: "IdInventario");
                });

            migrationBuilder.CreateTable(
                name: "SolicitudVacacionesDias",
                schema: "dbo",
                columns: table => new
                {
                    IdSolicitud = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Solicitu__DDB9544A027BF603", x => new { x.IdSolicitud, x.Fecha })
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_SolicitudVacacionesDias_Solicitud",
                        column: x => x.IdSolicitud,
                        principalSchema: "dbo",
                        principalTable: "SolicitudVacaciones",
                        principalColumn: "IdSolicitud");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Ausencia_IdUsuario",
                schema: "dbo",
                table: "Ausencia",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "UQ__Benefici__75E3EFCF5716E1CD",
                schema: "dbo",
                table: "Beneficio",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BeneficioUsuario_IdBeneficio",
                schema: "dbo",
                table: "BeneficioUsuario",
                column: "IdBeneficio");

            migrationBuilder.CreateIndex(
                name: "UQ__Capacita__92C53B6C023DF2D4",
                schema: "dbo",
                table: "CapacitacionTipo",
                column: "Descripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CapacitacionUsuario_IdCapacitacionTipo",
                schema: "dbo",
                table: "CapacitacionUsuario",
                column: "IdCapacitacionTipo");

            migrationBuilder.CreateIndex(
                name: "IX_CapacitacionUsuario_IdUsuario",
                schema: "dbo",
                table: "CapacitacionUsuario",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "UQ__Departam__75E3EFCF06D554EB",
                schema: "dbo",
                table: "Departamento",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_IdUsuario",
                schema: "dbo",
                table: "Direccion",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "UQ__Divisa__06370DAC55DB37EE",
                schema: "dbo",
                table: "Divisa",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Divisa__75E3EFCF154D5815",
                schema: "dbo",
                table: "Divisa",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Empresa__75E3EFCF5E153627",
                schema: "dbo",
                table: "Empresa",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__EstadoCi__92C53B6CAC8C98BB",
                schema: "dbo",
                table: "EstadoCivil",
                column: "Descripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_IdCategoria",
                schema: "dbo",
                table: "Inventario",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "UQ__Inventar__28C92875BD551D87",
                schema: "dbo",
                table: "Inventario",
                column: "CodigoInterno",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventarioAsignacion_IdUsuario",
                schema: "dbo",
                table: "InventarioAsignacion",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "UQ__Inventar__75E3EFCF85CBA72C",
                schema: "dbo",
                table: "InventarioCategoria",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__NivelEst__92C53B6CF5C34844",
                schema: "dbo",
                table: "NivelEstudio",
                column: "Descripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Pais__75E3EFCFE0C99BBD",
                schema: "dbo",
                table: "Pais",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Pronombr__92C53B6C782C7B05",
                schema: "dbo",
                table: "Pronombre",
                column: "Descripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_CostoDivisa",
                schema: "dbo",
                table: "Servicio",
                column: "CostoDivisa");

            migrationBuilder.CreateIndex(
                name: "IX_ServicioUsuario_IdUsuario",
                schema: "dbo",
                table: "ServicioUsuario",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudVacaciones_IdEmpleado",
                schema: "dbo",
                table: "SolicitudVacaciones",
                column: "IdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudVacaciones_IdEstatus",
                schema: "dbo",
                table: "SolicitudVacaciones",
                column: "IdEstatus");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudVacaciones_IdUsuarioRH",
                schema: "dbo",
                table: "SolicitudVacaciones",
                column: "IdUsuarioRH");

            migrationBuilder.CreateIndex(
                name: "UQ__Solicitu__92C53B6C6C0B418B",
                schema: "dbo",
                table: "SolicitudVacacionesEstatus",
                column: "Descripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__TallaPla__69DA116124DB2005",
                schema: "dbo",
                table: "TallaPlayera",
                column: "Talla",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__TipoCont__92C53B6C0FE1466A",
                schema: "dbo",
                table: "TipoContrato",
                column: "Descripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioInformacion_IdDepartamento",
                schema: "dbo",
                table: "UsuarioInformacion",
                column: "IdDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioInformacion_IdEmpresa",
                schema: "dbo",
                table: "UsuarioInformacion",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioInformacion_IdEstadoCivil",
                schema: "dbo",
                table: "UsuarioInformacion",
                column: "IdEstadoCivil");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioInformacion_IdNivelEstudio",
                schema: "dbo",
                table: "UsuarioInformacion",
                column: "IdNivelEstudio");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioInformacion_IdPais",
                schema: "dbo",
                table: "UsuarioInformacion",
                column: "IdPais");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioInformacion_IdPronombre",
                schema: "dbo",
                table: "UsuarioInformacion",
                column: "IdPronombre");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioInformacion_IdSupervisor",
                schema: "dbo",
                table: "UsuarioInformacion",
                column: "IdSupervisor");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioInformacion_IdTallaPlayera",
                schema: "dbo",
                table: "UsuarioInformacion",
                column: "IdTallaPlayera");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioInformacion_IdTipoContrato",
                schema: "dbo",
                table: "UsuarioInformacion",
                column: "IdTipoContrato");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioInformacion_SueldoDivisa",
                schema: "dbo",
                table: "UsuarioInformacion",
                column: "SueldoDivisa");

            migrationBuilder.CreateIndex(
                name: "UQ__UsuarioI__4B6490811A110918",
                schema: "dbo",
                table: "UsuarioInformacion",
                column: "NumeroSeguroSocial",
                unique: true,
                filter: "[NumeroSeguroSocial] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__UsuarioI__672E3C39969E54E2",
                schema: "dbo",
                table: "UsuarioInformacion",
                column: "NumeroColaborador",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__UsuarioI__76712BA3CE15A48A",
                schema: "dbo",
                table: "UsuarioInformacion",
                column: "IdentificadorNacional",
                unique: true,
                filter: "[IdentificadorNacional] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__UsuarioI__CAFFA85E37A82D25",
                schema: "dbo",
                table: "UsuarioInformacion",
                column: "RFC",
                unique: true,
                filter: "[RFC] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__UsuarioI__F46C4CBF12446C4B",
                schema: "dbo",
                table: "UsuarioInformacion",
                column: "CURP",
                unique: true,
                filter: "[CURP] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Ausencia",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BeneficioUsuario",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CapacitacionUsuario",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Direccion",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "InventarioAsignacion",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "InventarioGeneral",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "InventarioLibro",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ServicioUsuario",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SolicitudVacacionesDias",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UsuarioInformacion",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Beneficio",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CapacitacionTipo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Inventario",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Servicio",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SolicitudVacaciones",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Departamento",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Empresa",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EstadoCivil",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "NivelEstudio",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Pais",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Pronombre",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TallaPlayera",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TipoContrato",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "InventarioCategoria",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Divisa",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SolicitudVacacionesEstatus",
                schema: "dbo");
        }
    }
}
