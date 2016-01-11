using Newtonsoft;
using Newtonsoft.Json;
using Seguricel3.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;

namespace Seguricel3
{

    public static class ClasesVarias
    {
        private static HttpSessionState Session { get { return HttpContext.Current.Session; } }
        public static DateTime GetUserActualDate(int hours, int minutes)
        {
            return DateTime.UtcNow.AddHours(hours).AddMinutes(minutes);
        }
        public static DateTime ConvertDateToUserTimezone(DateTime date, int hours, int minutes)
        {
            return date.AddHours(hours).AddMinutes(minutes);
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            throw new Exception("Local IP Address Not Found");
        }
        public static string GetPublicIPAddress()
        {
            return HttpContext.Current.Request.UserHostAddress;
        }
        public static List<EstadoUsuarioViewModel> GetEstadosUsuario()
        {
            var tipos = Enum.GetValues(typeof(eEstadoUsuario)).
                 Cast<eEstadoUsuario>().
                 Select(e => new EstadoUsuarioViewModel
                 {
                     Id = (int)e,
                     Nombre = e.ToString()
                 }).ToList();

            return tipos;
        }
        public static void AddBitacoraUsuario(SeguricelEntities db, string Observacion, long ModuloId, string Accion)
        {

            FormsAuthenticationTicket encTicket = FormsAuthentication.Decrypt(Session["user"].ToString());
            CustomPrincipalSerializeModel serializeModel = JsonConvert.DeserializeObject<CustomPrincipalSerializeModel>(encTicket.UserData);

            Usuario_Bitacora bitacora = new Usuario_Bitacora
            {
                Accion = Accion,
                DireccionIP_Privada = GetLocalIPAddress(),
                DireccionIP_Publica = GetPublicIPAddress(),
                FechaRegistro = DateTime.UtcNow,
                IdModulo = ModuloId,
                IdUsuario = serializeModel.Id,
                IdBitacora = new Guid(),
                Observacion = Observacion
            };

            db.SaveChanges();
        }
        public static IEnumerable<SelectListItem> GetNivelesUsuario()
        {
            List<SelectListItem> Niveles;
            using (SeguricelEntities db = new SeguricelEntities())
            {
                Niveles = (from n in db.TipoUsuario
                           select new SelectListItem
                           {
                               Value = n.IdTipoUsuario.ToString(),
                               Text = n.Nombre
                           }).ToList();
            }
            return new SelectList(Niveles, "Value", "Text");
        }
        public static IEnumerable<SelectListItem> GetGrupos()
        {
            List<SelectListItem> Grupos;
            using (SeguricelEntities db = new SeguricelEntities())
            {
                Grupos = (from n in db.Grupo
                           select new SelectListItem
                           {
                               Value = n.IdGrupo.ToString(),
                               Text = n.Nombre
                           }).ToList();
            }
            return new SelectList(Grupos, "Value", "Text");
        }

        public static IList<SelectListItem> GetPaises()
        {
            List<SelectListItem> Paises;
            using (SeguricelEntities db = new SeguricelEntities())
            {
                Paises = (from p in db.Pais
                          where p.Activo
                          select new SelectListItem
                          {
                              Value = p.IdPais.ToString(),
                              Text = p.Nombre
                          }).ToList();
            }
            return Paises.ToList();
        }
        public static IList<SelectListItem> GetEstados(long IdPais)
        {
            List<SelectListItem> Estados;
            using (SeguricelEntities db = new SeguricelEntities())
            {
                Estados = (from e in db.Pais_Estado
                           where e.IdPais == IdPais
                           select new SelectListItem
                           {
                               Value = e.IdEstado.ToString(),
                               Text = e.Nombre
                           }).ToList();
            }

            return Estados.ToList();
        }
        public static IList<SelectListItem> GetCiudades(long IdPais, long IdEstado)
        {
            List<SelectListItem> Ciudades;
            using (SeguricelEntities db = new SeguricelEntities())
            {
                Ciudades = (from c in db.Pais_Estado_Ciudad
                            where c.IdPais == IdPais && c.IdEstado == IdEstado
                            select new SelectListItem
                            {
                                Value = c.IdCiudad.ToString(),
                                Text = c.Nombre
                            }).ToList();
            }
            return Ciudades.ToList();
        }
        public static IList<SelectListItem> GetTiposContrato(long IdPais, long IdEstado, long IdCiudad)
        {
            List<SelectListItem> Datos;
            using (SeguricelEntities db = new SeguricelEntities())
            {
                Datos = (from p in db.TipoContrato
                         where p.IdPais == IdPais && p.IdEstado == IdEstado && p.IdCiudad == IdCiudad
                         select new SelectListItem
                         {
                             Value = p.IdTipoContrato.ToString(),
                             Text = p.Nombre
                         }).ToList();
            }
            return Datos.ToList();
        }
        public static IList<SelectListItem> GetAdministradoras(long IdPais, long IdEstado, long IdCiudad)
        {
            List<SelectListItem> Datos;
            using (SeguricelEntities db = new SeguricelEntities())
            {
                Datos = (from p in db.Contrato_Administradora
                         where p.IdPais == IdPais && p.IdEstado == IdEstado && p.IdCiudad == IdCiudad
                         select new SelectListItem
                         {
                             Value = p.IdAdministradora.ToString(),
                             Text = p.Nombre
                         }).ToList();
            }
            return Datos.ToList();
        }

        public static string GetMenuUsuario_Old()
        {

            string MenuData = string.Empty;

            try
            {
                MenuData = "<ul class=\"v-menu subdown\">";
                //MenuData = "<ul id=\"top-level\">";
                int UltimoNivel = 0;
                FormsAuthenticationTicket encTicket = FormsAuthentication.Decrypt(Session["user"].ToString());
                CustomPrincipalSerializeModel serializeModel = JsonConvert.DeserializeObject<CustomPrincipalSerializeModel>(encTicket.UserData);

                using (SeguricelEntities db = new SeguricelEntities())
                {
                    List<Modulo> Data = (from m in db.Modulo_TipoUsuario
                                         where m.IdTipoUsuario == serializeModel.IdTipoUsuario & m.Modulo.Activo
                                         orderby m.IdModulo
                                         select m.Modulo).ToList();

                    foreach (Modulo _modulo in Data)
                    {
                        switch ((eTipoElementoMenu)_modulo.IdTipoElemento)
                        {
                            case eTipoElementoMenu.Nivel2:
                                switch (UltimoNivel)
                                {
                                    case 2:
                                        MenuData += "</ul>";
                                        break;
                                    case 3:
                                        MenuData += "</ul></ul>";
                                        break;
                                    case 4:
                                        MenuData += "</ul></ul></ul>";
                                        break;
                                }
                                MenuData += string.Format("<li><a href=\"#\">{0}</a><ul class=\"sub-level\">", _modulo.Nombre);
                                UltimoNivel = 2;
                                break;
                            case eTipoElementoMenu.Nivel3:
                                switch (UltimoNivel)
                                {
                                    case 3:
                                        MenuData += "</ul>";
                                        break;
                                    case 4:
                                        MenuData += "</ul></ul>";
                                        break;
                                }
                                MenuData += string.Format("<li><a href=\"#\">{0}</a><ul class=\"sub-level\">", _modulo.Nombre);
                                UltimoNivel = 3;
                                break;
                            case eTipoElementoMenu.Nivel4:
                                switch (UltimoNivel)
                                {
                                    case 4:
                                        MenuData += "</ul>";
                                        break;
                                }
                                MenuData += string.Format("<li><a href=\"#\">{0}</a><ul class=\"sub-level\">", _modulo.Nombre);
                                UltimoNivel = 4;
                                break;
                            case eTipoElementoMenu.Elemento:
                                MenuData += string.Format("<li><a href=\"../{1}/{2}\">{0}</a></li>", _modulo.Nombre, _modulo.Controller, _modulo.Action);
                                break;
                        }
                    }
                }
            }
            catch
            {

            }

            return MenuData;

        }
        public static string GetMenuUsuario()
        {

            string MenuData = string.Empty;

            try
            {
                MenuData = "<ul class=\"v-menu\">";
                int UltimoNivel = 0;
                FormsAuthenticationTicket encTicket = FormsAuthentication.Decrypt(Session["user"].ToString());
                CustomPrincipalSerializeModel serializeModel = JsonConvert.DeserializeObject<CustomPrincipalSerializeModel>(encTicket.UserData);

                using (SeguricelEntities db = new SeguricelEntities())
                {
                    List<Modulo> Data = (from m in db.Modulo_TipoUsuario
                                         where m.IdTipoUsuario == serializeModel.IdTipoUsuario & m.Modulo.Activo
                                         orderby m.IdModulo
                                         select m.Modulo).ToList();

                    foreach (Modulo _modulo in Data)
                    {
                        switch ((eTipoElementoMenu)_modulo.IdTipoElemento)
                        {
                            case eTipoElementoMenu.Nivel2:
                                switch (UltimoNivel)
                                {
                                    case 3:
                                        MenuData += "</ul></li>";
                                        break;
                                    case 4:
                                        MenuData += "</ul></li></ul></li>";
                                        break;
                                }
                                MenuData += string.Format("<li class=\"menu-title\">{0}</li>", _modulo.Nombre);
                                UltimoNivel = 2;
                                break;
                            case eTipoElementoMenu.Nivel3:
                                switch (UltimoNivel)
                                {
                                    case 3:
                                        MenuData += "</ul></li>";
                                        break;
                                    case 4:
                                        MenuData += "</ul></li></ul></li>";
                                        break;
                                }
                                MenuData += string.Format("<li><a href=\"#\" class=\"dropdown-toggle\">{0}</a><ul class=\"d-menu\" data-role=\"dropdown\"><li class=\"menu-title\">{0}</li>", _modulo.Nombre);
                                //MenuData += string.Format("<li><a href=\"#\" class=\"dropdown-toggle\">{0}</a><ul class=\"d-menu\" data-role=\"dropdown\"><li class=\"menu-title\">{0}</li>", _modulo.Nombre);
                                UltimoNivel = 3;
                                break;
                            case eTipoElementoMenu.Nivel4:
                                switch (UltimoNivel)
                                {
                                    case 4:
                                        MenuData += "</ul></li>";
                                        break;
                                }
                                MenuData += string.Format("<li><a href=\"#\" class=\"dropdown-toggle\">{0}</a><ul class=\"d-menu\" data-role=\"dropdown\"><li class=\"menu-title\">{0}</li>", _modulo.Nombre);
                                //MenuData += string.Format("<li><a href=\"#\">{0}</a><ul class=\"d-menu\" data-role=\"dropdown\">", _modulo.Nombre);
                                UltimoNivel = 4;
                                break;
                            case eTipoElementoMenu.Elemento:
                                MenuData += string.Format("<li><a href=\"../{1}/{2}\">{0}</a></li>", _modulo.Nombre, _modulo.Controller, _modulo.Action);
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            MenuData += "</ul>";
            return MenuData;

        }

        public static IList<SelectListItem> GetVendedores()
        {
            List<SelectListItem> Datos = new List<SelectListItem>();

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Datos = (from d in db.Vendedor
                        select new SelectListItem
                        {
                            Value = d.IdVendedor.ToString(),
                            Text = d.Nombre
                        }).ToList();

            }

            return Datos.ToList();
        }
        public static IList<SelectListItem> GetEstadosPropuesta()
        {
            try
            {
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    var Datos = db.EstadoPropuesta.Select(x => new SelectListItem { Value = x.IdEstadoPropuesta.ToString(), Text = x.Nombre });
                    return Datos.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static IList<SelectListItem> GetTiposPropuesta()
        {
            try
            {
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    var Datos = db.TipoPropuesta.Select(x => new SelectListItem { Value = x.IdTipoPropuesta.ToString(), Text = x.Nombre });
                    return Datos.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}