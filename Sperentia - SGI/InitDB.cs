using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sperientia___SGI.Models.dbModels;
using Sperientia___SGI.Models.dbModels.DbContext;
using Sperientia___SGI.Models.Utils;
using System.Security.Claims;

namespace Sperientia___SGI
{
    public class InitDB
    {
        public static bool TryToMigrate(SperientiaContext dbcontext)
        {
            try
            {
                dbcontext.Database.Migrate();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public static async Task<bool> TryCreateDefaultUsersAndRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            string strAdminRole = "Administrador";

            ApplicationUser usuarioAdmin1 = new ApplicationUser
            {
                UserName = "admin",
                Email = "admin@admin.com",
                EmailConfirmed = true,
                NombreCompleto = "Admin Admin Administrador Administrador",
                FotografiaUrl = null,
                EstaActivo = true,
            };
            string strContrasenaUsuarioAdmin1 = "Pa55w.rd";


            ApplicationUser usuarioComun1 = new ApplicationUser
            {
                UserName = "usuario",
                Email = "usuario@usuario.com",
                EmailConfirmed = true,
                NombreCompleto = "User User Usuario Usuario",
                FotografiaUrl = null,
                EstaActivo = true,
            };
            string strContrasenaUsuarioComun1 = "Pa55w.rd";

            if (!await TryCreateRoleIfNotExistAsync(roleManager, strAdminRole))
                return false;

            if (!await TryCreateUserIfNotExistsAndAddRoleAsync(userManager, usuarioAdmin1, strContrasenaUsuarioAdmin1, strAdminRole))
                return false;
            if (!await TryCreateUserIfNotExistsAndAddRoleAsync(userManager, usuarioComun1, strContrasenaUsuarioComun1))
                return false;
            return true;
        }

        private static async Task<bool> TryCreateRoleIfNotExistAsync(RoleManager<IdentityRole<int>> roleManager, string strRole, string[]? strRoleClaims = null)
        {
            try
            {
                IdentityRole<int>? oRole = await roleManager.FindByNameAsync(strRole);

                if (oRole == null)
                {
                    oRole = new IdentityRole<int>();
                    oRole.Name = strRole;

                    var result = await roleManager.CreateAsync(oRole);
                    if (result != null && result.Succeeded)
                    {
                        if (strRoleClaims != null)
                            await TryCreateRoleClaimIfNotExistAsync(roleManager, oRole, strRoleClaims);
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static async Task<bool> TryCreateRoleClaimIfNotExistAsync(RoleManager<IdentityRole<int>> roleManager, IdentityRole<int> role, string[]? strRoleClaims = null)
        {
            try
            {
                if (strRoleClaims != null)
                {
                    IList<Claim> existingClaims = await roleManager.GetClaimsAsync(role);

                    foreach (string claim in strRoleClaims)
                    {
                        var result = await roleManager.AddClaimAsync(role, new Claim(claim, claim));
                        if (result == null || !result.Succeeded)
                        {
                            continue;
                        }
                    }
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static async Task<bool> TryCreateUserIfNotExistsAndAddRoleAsync(UserManager<ApplicationUser> userManager, ApplicationUser newUser, string strContrasena, string strRol = null)
        {
            try
            {
                ApplicationUser? oUser = await userManager.FindByEmailAsync(newUser.Email ?? "");
                if (oUser == null)
                {
                    oUser = new ApplicationUser()
                    {
                        UserName = newUser.UserName,
                        Email = newUser.Email,
                        EmailConfirmed = true,
                        NombreCompleto = newUser.NombreCompleto,
                        FotografiaUrl = newUser.FotografiaUrl,
                        EstaActivo = newUser.EstaActivo,
                    };

                    await userManager.CreateAsync(oUser, strContrasena);
                }

                if (oUser != null && strRol != null)
                    await userManager.AddToRoleAsync(oUser, strRol);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public static async Task<bool> TrySeedDefaultDataAsync(SperientiaContext dbcontext)
        {
            try
            {
                Beneficio? beneficio1 = CreateBeneficioIfNotExists(dbcontext, 1, "Internet", "Servicio de internet pagado por la empresa.");
                Beneficio? beneficio2 = CreateBeneficioIfNotExists(dbcontext, 2, "Gasolina", "Vales de gasolina proporcionados por la empresa.");
                Beneficio? beneficio3 = CreateBeneficioIfNotExists(dbcontext, 3, "Vales de comida", "Vales de comida proporcionados por la empresa.");
                dbcontext.SaveChangesWithIdentityInsert<Beneficio>();

                Divisa? divisa1 = CreateDivisaIfNotExists(dbcontext, 1, "Peso mexicano", "MXN");
                Divisa? divisa2 = CreateDivisaIfNotExists(dbcontext, 2, "Peso colombiano", "COP");
                Divisa? divisa3 = CreateDivisaIfNotExists(dbcontext, 3, "Peso argentino", "ARS");
                Divisa? divisa4 = CreateDivisaIfNotExists(dbcontext, 4, "Peso chileno", "CLP");
                Divisa? divisa5 = CreateDivisaIfNotExists(dbcontext, 5, "Bolívar soberano", "VES");
                Divisa? divisa6 = CreateDivisaIfNotExists(dbcontext, 6, "Real brasileño", "BRL");
                Divisa? divisa7 = CreateDivisaIfNotExists(dbcontext, 7, "Dólar estadounidense", "USD");
                Divisa? divisa8 = CreateDivisaIfNotExists(dbcontext, 8, "Dólar canadiense", "CAD");
                Divisa? divisa9 = CreateDivisaIfNotExists(dbcontext, 9, "Dólar australiano", "AUD");
                Divisa? divisa10 = CreateDivisaIfNotExists(dbcontext, 10, "Euro", "EUR");
                Divisa? divisa11 = CreateDivisaIfNotExists(dbcontext, 11, "Franco suizo", "CHF");
                Divisa? divisa12 = CreateDivisaIfNotExists(dbcontext, 12, "Libra esterlina", "GBP");
                Divisa? divisa13 = CreateDivisaIfNotExists(dbcontext, 13, "Yen japonés", "JPY");
                Divisa? divisa14 = CreateDivisaIfNotExists(dbcontext, 14, "Yuan chino", "CNY");
                dbcontext.SaveChangesWithIdentityInsert<Divisa>();

                NivelEstudio? nivel1 = CreateNivelEstudioIfNotExists(dbcontext, 1, "Secundaria");
                NivelEstudio? nivel2 = CreateNivelEstudioIfNotExists(dbcontext, 2, "Preparatoria");
                NivelEstudio? nivel3 = CreateNivelEstudioIfNotExists(dbcontext, 3, "Licenciatura");
                NivelEstudio? nivel4 = CreateNivelEstudioIfNotExists(dbcontext, 4, "Maestría");
                NivelEstudio? nivel5 = CreateNivelEstudioIfNotExists(dbcontext, 5, "Doctorado");
                dbcontext.SaveChangesWithIdentityInsert<NivelEstudio>();

                EstadoCivil? estado1 = CreateEstadoCivilIfNotExists(dbcontext, 1, "Soltero");
                EstadoCivil? estado2 = CreateEstadoCivilIfNotExists(dbcontext, 2, "Casado");
                EstadoCivil? estado3 = CreateEstadoCivilIfNotExists(dbcontext, 3, "Divorciado");
                EstadoCivil? estado4 = CreateEstadoCivilIfNotExists(dbcontext, 4, "Separado");
                EstadoCivil? estado5 = CreateEstadoCivilIfNotExists(dbcontext, 5, "Viudo");
                EstadoCivil? estado6 = CreateEstadoCivilIfNotExists(dbcontext, 6, "Concubinato");
                dbcontext.SaveChangesWithIdentityInsert<EstadoCivil>();

                Pais? pais1 = CreatePaisIfNotExists(dbcontext, 1, "México");
                Pais? pais2 = CreatePaisIfNotExists(dbcontext, 2, "Colombia");
                Pais? pais3 = CreatePaisIfNotExists(dbcontext, 3, "Argentina");
                Pais? pais4 = CreatePaisIfNotExists(dbcontext, 4, "Chile");
                Pais? pais5 = CreatePaisIfNotExists(dbcontext, 5, "Venezuela");
                Pais? pais6 = CreatePaisIfNotExists(dbcontext, 6, "Brasil");
                Pais? pais7 = CreatePaisIfNotExists(dbcontext, 7, "Estados Unidos");
                Pais? pais8 = CreatePaisIfNotExists(dbcontext, 8, "Canadá");
                Pais? pais9 = CreatePaisIfNotExists(dbcontext, 9, "Australia");
                Pais? pais10 = CreatePaisIfNotExists(dbcontext, 10, "Unión Europea");
                Pais? pais11 = CreatePaisIfNotExists(dbcontext, 11, "Suiza");
                Pais? pais12 = CreatePaisIfNotExists(dbcontext, 12, "Reino Unido");
                Pais? pais13 = CreatePaisIfNotExists(dbcontext, 13, "Japón");
                Pais? pais14 = CreatePaisIfNotExists(dbcontext, 14, "China");
                dbcontext.SaveChangesWithIdentityInsert<Pais>();

                Pronombre? pronombre1 = CreatePronombreIfNotExists(dbcontext, 1, "Él");
                Pronombre? pronombre2 = CreatePronombreIfNotExists(dbcontext, 2, "Ella");
                Pronombre? pronombre3 = CreatePronombreIfNotExists(dbcontext, 3, "Elle");
                Pronombre? pronombre4 = CreatePronombreIfNotExists(dbcontext, 4, "Le");
                Pronombre? pronombre5 = CreatePronombreIfNotExists(dbcontext, 5, "Les");
                Pronombre? pronombre6 = CreatePronombreIfNotExists(dbcontext, 6, "Quien");
                Pronombre? pronombre7 = CreatePronombreIfNotExists(dbcontext, 7, "Quienes");
                dbcontext.SaveChangesWithIdentityInsert<Pronombre>();

                TipoContrato? contrato1 = CreateTipoContratoIfNotExists(dbcontext, 1, "Permanente");
                TipoContrato? contrato2 = CreateTipoContratoIfNotExists(dbcontext, 2, "Temporal");
                TipoContrato? contrato3 = CreateTipoContratoIfNotExists(dbcontext, 3, "Flexible");
                TipoContrato? contrato4 = CreateTipoContratoIfNotExists(dbcontext, 4, "Freelance");
                TipoContrato? contrato5 = CreateTipoContratoIfNotExists(dbcontext, 5, "Interno");
                TipoContrato? contrato6 = CreateTipoContratoIfNotExists(dbcontext, 6, "Aprendiz");
                TipoContrato? contrato7 = CreateTipoContratoIfNotExists(dbcontext, 7, "Honorarios");
                TipoContrato? contrato8 = CreateTipoContratoIfNotExists(dbcontext, 8, "Prestador de servicios profesionales");
                TipoContrato? contrato9 = CreateTipoContratoIfNotExists(dbcontext, 9, "Asalariado");
                dbcontext.SaveChangesWithIdentityInsert<TipoContrato>();

                TallaPlayera? talla1 = CreateTallaPlayeraIfNotExists(dbcontext, 1, "XS");
                TallaPlayera? talla2 = CreateTallaPlayeraIfNotExists(dbcontext, 2, "S");
                TallaPlayera? talla3 = CreateTallaPlayeraIfNotExists(dbcontext, 3, "M");
                TallaPlayera? talla4 = CreateTallaPlayeraIfNotExists(dbcontext, 4, "LG");
                TallaPlayera? talla5 = CreateTallaPlayeraIfNotExists(dbcontext, 5, "XL");
                TallaPlayera? talla6 = CreateTallaPlayeraIfNotExists(dbcontext, 6, "XXL");
                TallaPlayera? talla7 = CreateTallaPlayeraIfNotExists(dbcontext, 7, "XXXL");
                dbcontext.SaveChangesWithIdentityInsert<TallaPlayera>();

                Empresa? empresa1 = CreateEmpresaIfNotExists(dbcontext, 1, "Sperientia");
                Empresa? empresa2 = CreateEmpresaIfNotExists(dbcontext, 2, "Sperientia Academy");
                Empresa? empresa3 = CreateEmpresaIfNotExists(dbcontext, 3, "Tasters");
                dbcontext.SaveChangesWithIdentityInsert<Empresa>();

                Departamento? depto1 = CreateDepartamentoIfNotExists(dbcontext, 1, "Recursos Humanos");
                Departamento? depto2 = CreateDepartamentoIfNotExists(dbcontext, 2, "Tecnología");
                dbcontext.SaveChangesWithIdentityInsert<Departamento>();

                InventarioCategoria? categoria1 = CreateInventarioCategoriaIfNotExists(dbcontext, 1, "Libro");
                InventarioCategoria? categoria2 = CreateInventarioCategoriaIfNotExists(dbcontext, 2, "Mobiliario");
                InventarioCategoria? categoria3 = CreateInventarioCategoriaIfNotExists(dbcontext, 3, "Electrónica");
                InventarioCategoria? categoria4 = CreateInventarioCategoriaIfNotExists(dbcontext, 4, "Licencia");
                InventarioCategoria? categoria5 = CreateInventarioCategoriaIfNotExists(dbcontext, 5, "Equipo de cómputo");
                dbcontext.SaveChangesWithIdentityInsert<InventarioCategoria>();

                SolicitudVacacionesEstatus? estatus1 = CreateSolicitudVacacionesEstatusIfNotExists(dbcontext, 1, "Pendiente");
                SolicitudVacacionesEstatus? estatus2 = CreateSolicitudVacacionesEstatusIfNotExists(dbcontext, 2, "Aprobado");
                SolicitudVacacionesEstatus? estatus3 = CreateSolicitudVacacionesEstatusIfNotExists(dbcontext, 3, "No aprobado");
                dbcontext.SaveChangesWithIdentityInsert<SolicitudVacacionesEstatus>();

                CapacitacionTipo? capacitacionTipo1 = CreateCapacitacionTipoIfNotExists(dbcontext, 1, "Certificación");
                CapacitacionTipo? capacitacionTipo2 = CreateCapacitacionTipoIfNotExists(dbcontext, 2, "Idiomas");
                CapacitacionTipo? capacitacionTipo3 = CreateCapacitacionTipoIfNotExists(dbcontext, 3, "Diplomado");
                CapacitacionTipo? capacitacionTipo4 = CreateCapacitacionTipoIfNotExists(dbcontext, 4, "Curso");
                CapacitacionTipo? capacitacionTipo5 = CreateCapacitacionTipoIfNotExists(dbcontext, 5, "Taller");
                CapacitacionTipo? capacitacionTipo6 = CreateCapacitacionTipoIfNotExists(dbcontext, 6, "Seminario");
                CapacitacionTipo? capacitacionTipo7 = CreateCapacitacionTipoIfNotExists(dbcontext, 7, "Conferencia");
                CapacitacionTipo? capacitacionTipo8 = CreateCapacitacionTipoIfNotExists(dbcontext, 8, "Bootcamp");
                CapacitacionTipo? capacitacionTipo9 = CreateCapacitacionTipoIfNotExists(dbcontext, 9, "Maestría");
                dbcontext.SaveChangesWithIdentityInsert<CapacitacionTipo>();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static Beneficio? CreateBeneficioIfNotExists(SperientiaContext dbcontext, int Id, string nombre, string descripcion)
        {
            var obj = dbcontext.Beneficios.Where(x => x.IdBeneficio == Id);

            if (!obj.Any())
            {
                Beneficio o = new()
                {
                    IdBeneficio = Id,
                    Nombre = nombre,
                    Descripcion = descripcion,
                };

                dbcontext.Beneficios.Add(o);

                // Los cambios se guardan con dbcontext.SaveChangesWithIdentityInsert<Beneficio>();
                return o;
            }

            return null;
        }

        private static Divisa? CreateDivisaIfNotExists(SperientiaContext dbcontext, int Id, string nombre, string codigo)
        {
            var obj = dbcontext.Divisas.Where(x => x.IdDivisa == Id);

            if (!obj.Any())
            {
                Divisa o = new()
                {
                    IdDivisa = Id,
                    Nombre = nombre,
                    Codigo = codigo,
                };

                dbcontext.Divisas.Add(o);

                // Los cambios se guardan con dbcontext.SaveChangesWithIdentityInsert<Beneficio>();
                return o;
            }

            return null;
        }

        private static NivelEstudio? CreateNivelEstudioIfNotExists(SperientiaContext dbcontext, int Id, string descripcion)
        {
            if (!dbcontext.NivelEstudios.Any(x => x.IdNivelEstudio == Id))
            {
                NivelEstudio o = new() { IdNivelEstudio = Id, Descripcion = descripcion };
                dbcontext.NivelEstudios.Add(o);
                return o;
            }
            return null;
        }

        private static Departamento? CreateDepartamentoIfNotExists(SperientiaContext dbcontext, int Id, string nombre)
        {
            if (!dbcontext.Departamentoes.Any(x => x.IdDepartamento == Id))
            {
                Departamento o = new() { IdDepartamento = Id, Nombre = nombre };
                dbcontext.Departamentoes.Add(o);
                return o;
            }
            return null;
        }

        private static EstadoCivil? CreateEstadoCivilIfNotExists(SperientiaContext dbcontext, int Id, string descripcion)
        {
            if (!dbcontext.EstadoCivils.Any(x => x.IdEstadoCivil == Id))
            {
                EstadoCivil o = new() { IdEstadoCivil = Id, Descripcion = descripcion };
                dbcontext.EstadoCivils.Add(o);
                return o;
            }
            return null;
        }

        private static Pais? CreatePaisIfNotExists(SperientiaContext dbcontext, int Id, string nombre)
        {
            if (!dbcontext.Pais.Any(x => x.IdPais == Id))
            {
                Pais o = new() { IdPais = Id, Nombre = nombre };
                dbcontext.Pais.Add(o);
                return o;
            }
            return null;
        }

        private static Pronombre? CreatePronombreIfNotExists(SperientiaContext dbcontext, int Id, string descripcion)
        {
            if (!dbcontext.Pronombres.Any(x => x.IdPronombre == Id))
            {
                Pronombre o = new() { IdPronombre = Id, Descripcion = descripcion };
                dbcontext.Pronombres.Add(o);
                return o;
            }
            return null;
        }

        private static TipoContrato? CreateTipoContratoIfNotExists(SperientiaContext dbcontext, int Id, string descripcion)
        {
            if (!dbcontext.TipoContratoes.Any(x => x.IdTipoContrato == Id))
            {
                TipoContrato o = new() { IdTipoContrato = Id, Descripcion = descripcion };
                dbcontext.TipoContratoes.Add(o);
                return o;
            }
            return null;
        }

        private static TallaPlayera? CreateTallaPlayeraIfNotExists(SperientiaContext dbcontext, int Id, string descripcion)
        {
            if (!dbcontext.Pronombres.Any(x => x.IdPronombre == Id))
            {
                TallaPlayera o = new() { IdTallaPlayera = Id, Talla = descripcion };
                dbcontext.TallaPlayeras.Add(o);
                return o;
            }
            return null;
        }

        private static Empresa? CreateEmpresaIfNotExists(SperientiaContext dbcontext, int Id, string descripcion)
        {
            if (!dbcontext.Empresas.Any(x => x.IdEmpresa == Id))
            {
                Empresa o = new() { IdEmpresa = Id, Nombre = descripcion };
                dbcontext.Empresas.Add(o);
                return o;
            }
            return null;
        }

        private static InventarioCategoria? CreateInventarioCategoriaIfNotExists(SperientiaContext dbcontext, int Id, string descripcion)
        {
            if (!dbcontext.InventarioCategorias.Any(x => x.IdCategoria == Id))
            {
                InventarioCategoria o = new() { IdCategoria = Id, Nombre = descripcion };
                dbcontext.InventarioCategorias.Add(o);
                return o;
            }
            return null;
        }

        private static SolicitudVacacionesEstatus? CreateSolicitudVacacionesEstatusIfNotExists(SperientiaContext dbcontext, int Id, string descripcion)
        {
            if (!dbcontext.SolicitudVacacionesEstatus.Any(x => x.IdEstatus == Id))
            {
                SolicitudVacacionesEstatus o = new() { IdEstatus = Id, Descripcion = descripcion };
                dbcontext.SolicitudVacacionesEstatus.Add(o);
                return o;
            }
            return null;
        }

        private static CapacitacionTipo? CreateCapacitacionTipoIfNotExists(SperientiaContext dbcontext, int Id, string descripcion)
        {
            if (!dbcontext.CapacitacionTipoes.Any(x => x.IdCapacitacionTipo == Id))
            {
                CapacitacionTipo o = new() { IdCapacitacionTipo = Id, Descripcion = descripcion };
                dbcontext.CapacitacionTipoes.Add(o);
                return o;
            }
            return null;
        }
    }
}
