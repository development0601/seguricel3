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
        public static IEnumerable<SelectListItem> GetEstadosUsuario()
        {
            var tipos = Enum.GetValues(typeof(eEstadoUsuario)).
                 Cast<eEstadoUsuario>().
                 Select(e => new SelectListItem
                 {
                     Value = ((int)e).ToString(),
                     Text = e.ToString()
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
                IdBitacora = Guid.NewGuid(),
                Observacion = Observacion
            };

            db.Usuario_Bitacora.Add(bitacora);
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
        public static IEnumerable<SelectListItem> GetGrupos(int IdPais)
        {
            List<SelectListItem> Grupos = new List<SelectListItem>();

            if (IdPais > 0)
            {

                using (SeguricelEntities db = new SeguricelEntities())
                {

                    string _Culture = db.Pais.Where(x => x.IdPais == IdPais).FirstOrDefault().Culture;

                    Grupos = (from n in db.Grupo
                              where n.Culture == _Culture
                              select new SelectListItem
                              {
                                  Value = n.IdGrupo.ToString(),
                                  Text = n.Nombre
                              }).ToList();
                }
            }

            Grupos.Insert(0, new SelectListItem
            {
                Value = null,
                Text = Resources.EtiquetasResource.labelSelectValue
            });

            return new SelectList(Grupos, "Value", "Text");
        }
        public static IEnumerable<SelectListItem> GetPaises()
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

            return new SelectList(Paises, "Value", "Text");
        }
        public static IEnumerable<SelectListItem> GetEstados(long IdPais)
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

            Estados.Insert(0, new SelectListItem
            {
                Value = "0",
                Text = Resources.EtiquetasResource.labelSelectValue
            });

            return Estados.ToList();
        }
        public static IEnumerable<SelectListItem> GetCiudades(long IdPais, long IdEstado)
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

            Ciudades.Insert(0, new SelectListItem
            {
                Value = "0",
                Text = Resources.EtiquetasResource.labelSelectValue
            });

            return Ciudades.ToList();
        }
        public static IEnumerable<SelectListItem> GetContratosbyGeografia(long IdPais, long IdEstado, long IdCiudad)
        {
            List<SelectListItem> Contratos;
            using (SeguricelEntities db = new SeguricelEntities())
            {
                Contratos = (from c in db.Contrato
                            where c.IdPais == IdPais && c.IdEstado == IdEstado && c.IdCiudad == IdCiudad
                            select new SelectListItem
                            {
                                Value = c.IdContrato.ToString(),
                                Text = c.NombreCompleto
                            }).ToList();
            }
            return Contratos.ToList();
        }
        public static IEnumerable<SelectListItem> GetUsuariosTipoCliente()
        {
            List<SelectListItem> Usuarios;
            using (SeguricelEntities db = new SeguricelEntities())
            {
                Usuarios = (from n in db.Usuario
                            where (eTipoUsuario)n.IdTipoUsuario == eTipoUsuario.Cliente
                           select new SelectListItem
                           {
                               Value = n.IdUsuario.ToString(),
                               Text = n.Nombre
                           }).ToList();
            }
            return new SelectList(Usuarios, "Value", "Text");
        }
        public static IEnumerable<SelectListItem> GetModulos()
        {
            List<SelectListItem> Modulos;
            using (SeguricelEntities db = new SeguricelEntities())
            {
                Modulos = (from m in db.Modulo
                            orderby m.IdModulo
                            select new SelectListItem
                            {
                                Value = m.IdModulo.ToString(),
                                Text = m.Nombre
                            }).ToList();
            }
            return new SelectList(Modulos, "Value", "Text");
        }
        public static IEnumerable<SelectListItem> GetTipoElemento()
        {
            List<SelectListItem> TiposElemento =
                Enum.GetValues(typeof(eTipoElementoMenu)).Cast<eTipoElementoMenu>().Select(e => new SelectListItem
                {
                    Text = e.ToString(),
                    Value = ((int)e).ToString()
                }).ToList();

            return new SelectList(TiposElemento, "Value", "Text");
        }
        public static IEnumerable<SelectListItem> GetTiposContrato(string Culture)
        {
            List<SelectListItem> Datos = new List<SelectListItem>();
            using (SeguricelEntities db = new SeguricelEntities())
            {
                Datos = (from p in db.TipoContrato
                         where p.Culture == Culture 
                         select new SelectListItem
                         {
                             Value = p.IdTipoContrato.ToString(),
                             Text = p.Nombre
                         }).ToList();
            }

            Datos.Insert(0, new SelectListItem
            {
                Value = "0",
                Text = Resources.EtiquetasResource.labelSelectValue
            });

            return new SelectList(Datos, "Value", "Text");
        }
        public static IEnumerable<SelectListItem> GetAdministradoras(long IdPais)
        {
            List<SelectListItem> Datos;
            using (SeguricelEntities db = new SeguricelEntities())
            {
                Datos = (from p in db.Contrato_Administradora
                         where p.IdPais == IdPais
                         select new SelectListItem
                         {
                             Value = p.IdAdministradora.ToString(),
                             Text = p.Nombre
                         }).ToList();
            }

            Datos.Insert(0, new SelectListItem
            {
                Value = null,
                Text = Resources.EtiquetasResource.labelSelectValue
            });

            return new SelectList(Datos, "Value", "Text");
        }
        public static IEnumerable<SelectListItem> GetEstadosContrato(long IdPais)
        {
            List<SelectListItem> Datos = new List<SelectListItem>();
            using (SeguricelEntities db = new SeguricelEntities())
            {
                string _Culture = db.Pais.Where(x => x.IdPais == IdPais).FirstOrDefault().Culture;

                Datos = (from p in db.EstadoContrato
                         where p.Culture == _Culture
                         select new SelectListItem
                         {
                             Value = p.IdEstadoContrato.ToString(),
                             Text = p.Nombre
                         }).ToList();
            }

            Datos.Insert(0, new SelectListItem
            {
                Value = null,
                Text = Resources.EtiquetasResource.labelSelectValue
            });

            return new SelectList(Datos, "Value", "Text");
        }
        //public static string GetMenuUsuario_Old()
        //{

        //    string MenuData = string.Empty;

        //    try
        //    {
        //        MenuData = "<ul class=\"v-menu subdown\">";
        //        //MenuData = "<ul id=\"top-level\">";
        //        int UltimoNivel = 0;
        //        FormsAuthenticationTicket encTicket = FormsAuthentication.Decrypt(Session["user"].ToString());
        //        CustomPrincipalSerializeModel serializeModel = JsonConvert.DeserializeObject<CustomPrincipalSerializeModel>(encTicket.UserData);

        //        using (SeguricelEntities db = new SeguricelEntities())
        //        {
        //            List<Modulo> Data = (from m in db.Modulo_TipoUsuario
        //                                 where m.IdTipoUsuario == serializeModel.IdTipoUsuario & m.Modulo.Activo
        //                                 orderby m.IdModulo
        //                                 select m.Modulo).ToList();

        //            foreach (Modulo _modulo in Data)
        //            {
        //                switch ((eTipoElementoMenu)_modulo.IdTipoElemento)
        //                {
        //                    case eTipoElementoMenu.Nivel2:
        //                        switch (UltimoNivel)
        //                        {
        //                            case 2:
        //                                MenuData += "</ul>";
        //                                break;
        //                            case 3:
        //                                MenuData += "</ul></ul>";
        //                                break;
        //                            case 4:
        //                                MenuData += "</ul></ul></ul>";
        //                                break;
        //                        }
        //                        MenuData += string.Format("<li><a href=\"#\">{0}</a><ul class=\"sub-level\">", _modulo.Nombre);
        //                        UltimoNivel = 2;
        //                        break;
        //                    case eTipoElementoMenu.Nivel3:
        //                        switch (UltimoNivel)
        //                        {
        //                            case 3:
        //                                MenuData += "</ul>";
        //                                break;
        //                            case 4:
        //                                MenuData += "</ul></ul>";
        //                                break;
        //                        }
        //                        MenuData += string.Format("<li><a href=\"#\">{0}</a><ul class=\"sub-level\">", _modulo.Nombre);
        //                        UltimoNivel = 3;
        //                        break;
        //                    case eTipoElementoMenu.Nivel4:
        //                        switch (UltimoNivel)
        //                        {
        //                            case 4:
        //                                MenuData += "</ul>";
        //                                break;
        //                        }
        //                        MenuData += string.Format("<li><a href=\"#\">{0}</a><ul class=\"sub-level\">", _modulo.Nombre);
        //                        UltimoNivel = 4;
        //                        break;
        //                    case eTipoElementoMenu.Elemento:
        //                        MenuData += string.Format("<li><a href=\"../{1}/{2}\">{0}</a></li>", _modulo.Nombre, _modulo.Controller, _modulo.Action);
        //                        break;
        //                }
        //            }
        //        }
        //    }
        //    catch
        //    {

        //    }

        //    return MenuData;

        //}
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
                                MenuData += string.Format("<li><a href=\"../{1}/{2}\"  onclick=\"showDialog('#dialogoRegistro')\">{0}</a></li>", _modulo.Nombre, _modulo.Controller, _modulo.Action);
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
        public static string GetPaisCulture(int IdPais)
        {
            try
            {
                string _Culture = string.Empty;
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    _Culture = db.Pais.Where(x => x.IdPais == IdPais).FirstOrDefault().Culture;
                    return _Culture;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static IList<SelectListItem> GetContratos()
        {
            List<SelectListItem> Datos = new List<SelectListItem>();
            using (SeguricelEntities db = new SeguricelEntities())
            {
                Datos = (from p in db.Contrato
                         select new SelectListItem
                         {
                             Value = p.IdContrato.ToString(),
                             Text = p.NombreCompleto
                         }).ToList();
            }
            return Datos.ToList();
        }
        public static string GetNroContrato(int IdPais, int IdTipoContrato)
        {
            string nextNroContrato = string.Empty;

            using (SeguricelEntities db = new SeguricelEntities())
            {
                string _Culture = db.Pais.Where(x => x.IdPais == IdPais).FirstOrDefault().Culture;

                TipoContrato tipoContrato = (from t in db.TipoContrato
                                             where t.Culture == _Culture && t.IdTipoContrato == IdTipoContrato
                                             select t).FirstOrDefault();

                tipoContrato.UltimoNroContrato += 1;
                db.SaveChanges();

                nextNroContrato = string.Format("{0}-{1}-{2}-{3}", tipoContrato.LetraTipoContrato, DateTime.UtcNow.Year.ToString("0000"), DateTime.UtcNow.Month.ToString("00"), (tipoContrato.UltimoNroContrato).ToString("000"));
            }

            return nextNroContrato;
        }
        public static IEnumerable<SelectListItem> GetContratosByPais(int IdPais)
        {
            List<SelectListItem> Datos = new List<SelectListItem>();

            if (IdPais > 0)
            {
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    string _Culture = db.Pais.Where(x => x.IdPais == IdPais).FirstOrDefault().Culture;

                    Datos = (from p in db.Contrato
                             where p.IdPais == IdPais
                             select new SelectListItem
                             {
                                 Value = p.IdContrato.ToString(),
                                 Text = p.NombreCompleto
                             }).ToList();
                }
            }
            Datos.Insert(0, new SelectListItem
            {
                Value = null,
                Text = Resources.EtiquetasResource.labelSelectValue
            });

            return new SelectList(Datos, "Value", "Text");
        }
        public static IEnumerable<SelectListItem> GetCargosJunta()
        {
            List<SelectListItem> Datos = new List<SelectListItem>();
            using (SeguricelEntities db = new SeguricelEntities())
            {
                string _Culture = Session["Culture"].ToString();

                Datos = (from p in db.TipoCargoJuntaCondominio
                         where p.Culture == _Culture
                         select new SelectListItem
                         {
                             Value = p.IdCargoJunta.ToString(),
                             Text = p.Nombre
                         }).ToList();
            }

            Datos.Insert(0, new SelectListItem
            {
                Value = null,
                Text = Resources.EtiquetasResource.labelSelectValue
            });

            return new SelectList(Datos, "Value", "Text");
        }
        public static IEnumerable<SelectListItem> getUnidadesMaestrasContrato(Guid IdContrato, Guid? IdUnidad)
        {
            List<SelectListItem> Datos = new List<SelectListItem>();
            using (SeguricelEntities db = new SeguricelEntities())
            {

                Datos = (from p in db.Contrato_Unidad
                         where p.IdContrato == IdContrato && p.IdUnidad != (Guid)(IdUnidad != null ? IdUnidad : new Guid())
                         select new SelectListItem
                         {
                             Value = p.IdUnidad.ToString(),
                             Text = p.Nombre
                         }).ToList();
            }

            Datos.Insert(0, new SelectListItem
            {
                Value = new Guid().ToString(),
                Text = Resources.EtiquetasResource.lblddlUnidadMaestra
            });

            return new SelectList(Datos, "Value", "Text");
        }
        
        public static string Generar_Clave()
        {
            try
            {
                Random random = new Random();
                string s = "";
                int i = 0;
                int iChr = 0;
                while (i < 5) //Clave de 5 caracteres de largo
                {
                    iChr = random.Next(48, 90);
                    while ((iChr > 57) && (iChr < 65))
                        iChr = random.Next(48, 90);
                    s = String.Concat(s, (char)iChr);
                    i++;
                }

                //Llevo todo a maysuculas
                s = s.ToUpper();

                //Elimino las letras que se prestan a enredo
                s = s.Replace("0", "X");
                s = s.Replace("O", "Z");
                s = s.Replace("L", "9");
                s = s.Replace("1", "8");
                s = s.Replace("Ñ", "N");
                s = s.Replace(" ", "A");
                s = s.Replace("-", "B");
                s = s.Replace("_", "B");

                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static IEnumerable<SelectListItem> GetDispositivos()
        {
            List<SelectListItem> Dispositivos;
            using (SeguricelEntities db = new SeguricelEntities())
            {
                Dispositivos = (from p in db.TipoDispositivo
                          select new SelectListItem
                          {
                              Value = p.IdTipoDispositivo.ToString(),
                              Text = p.Nombre
                          }).ToList();
            }

            return new SelectList(Dispositivos, "Value", "Text");
        }

    }
}