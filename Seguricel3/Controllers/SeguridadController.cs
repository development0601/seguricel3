using Seguricel3.Helpers;
using Seguricel3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Seguricel3.Controllers
{
    [CustomAuthorize]
    public class SeguridadController : BaseController
    {
        // GET: Seguridad
        [HandleError]
        [SessionExpireFilter]
        public ActionResult Usuarios()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.Title = Resources.UsuarioSeguridadResource.UsuariosPageTitle;
            ViewBag.PageHeader = Resources.UsuarioSeguridadResource.UsuariosHeaderPage;

            List<UsuarioViewModel> data = new List<UsuarioViewModel>();
            string _Culture = Thread.CurrentThread.CurrentCulture.ToString();


            using (SeguricelEntities db = new SeguricelEntities())
            {
                data = (from d in db.Usuario
                        let fce = SqlFunctions.DateAdd("hh", User.HoursTimeZone, SqlFunctions.DateAdd("mi", User.MinutesTimeZone, d.FechaCambioEstatus))
                        let fuc = SqlFunctions.DateAdd("hh", User.HoursTimeZone, SqlFunctions.DateAdd("mi", User.MinutesTimeZone, d.FechaUltimaConexion))
                        where d.IdTipoUsuario > (User.IdTipoUsuario == 1 ? 0 : 1)
                        select new UsuarioViewModel
                        {
                            ConfirmPasswordUsuario = d.ClaveUsuario,
                            EmailUsuario = d.Email,
                            Estado = d.IdEstadoUsuario,
                            EstadoUsuario = db.EstadoUsuario.Where(x => x.Culture == _Culture && x.IdEstadoUsuario == d.IdEstadoUsuario).FirstOrDefault().Nombre,
                            FechaCambioEstado = (DateTime)fce,
                            FechaUltimaConexion = (DateTime)fuc,
                            Id = d.IdUsuario,
                            IdTipoUsuario = d.IdTipoUsuario,
                            NivelUsuario = db.TipoUsuario.Where(x => x.Culture == _Culture && x.IdTipoUsuario == d.IdTipoUsuario).FirstOrDefault().Nombre,
                            Nombre = d.Nombre,
                            PasswordUsuario = d.ClaveUsuario
                        }).ToList();
            }

            return View(data);
        }
        [HttpPost]
        [SessionExpireFilter]
        [HandleError]
        public JsonResult GetEstadosByPais(string Id)
        {
            int IdPais = int.Parse(Id);
            IEnumerable<SelectListItem> Estados = ClasesVarias.GetEstados(IdPais);

            return Json(new SelectList(Estados, "Value", "Text"));
        }
        [HttpPost]
        [SessionExpireFilter]
        [HandleError]
        public JsonResult GetCiudadesByPais(string IdP, string IdE)
        {
            int IdPais = int.Parse(IdP);
            int IdEstado = int.Parse(IdE);

            IEnumerable<SelectListItem> Ciudades = ClasesVarias.GetCiudades(IdPais, IdEstado);

            return Json(new SelectList(Ciudades, "Value", "Text"));
        }
        [HttpPost]
        [SessionExpireFilter]
        [HandleError]
        public JsonResult GetContratosbyGeografia(string IdP, string IdE, string IdC)
        {
            int IdPais = int.Parse(IdP);
            int IdEstado = int.Parse(IdE);
            int IdCiudad = int.Parse(IdC);

            IEnumerable<SelectListItem> Contratos = ClasesVarias.GetContratosbyGeografia(IdPais, IdEstado, IdCiudad);

            return Json(new SelectList(Contratos, "Value", "Text"));
        }
        [HandleError]
        [SessionExpireFilter]
        public ActionResult CreateUsuario()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.UsuarioSeguridadResource.CreateUsuarioPageTitle;
            ViewBag.PageHeader = Resources.UsuarioSeguridadResource.CreateUsuarioHeaderPage;
            UsuarioViewModel model = new UsuarioViewModel();
            return View(model);
        }
        [HandleError]
        [SessionExpireFilter]
        [HttpPost]
        public ActionResult CreateUsuario(UsuarioViewModel model)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid)
            {
                ViewBag.Title = Resources.UsuarioSeguridadResource.CreateUsuarioPageTitle;
                ViewBag.PageHeader = Resources.UsuarioSeguridadResource.CreateUsuarioHeaderPage;
                return View(model);
            }

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Encriptador Encrypt = new Encriptador();
                Encrypt.InicioClaves("53gur1cel!n37", "4LC_C0MUN1C4C10N35@S3GUR1C3L!N37", "53gur1c3l!4lcC0mun1c4c10n35@s3gur1c3lgm41l!c0m", 5);
                string encryptedPassword = Encrypt.Encriptar(model.PasswordUsuario, Encriptador.HasAlgorimt.SHA1, Encriptador.Keysize.KS256);

                Usuario usuario = new Usuario
                {
                    ClaveUsuario = encryptedPassword,
                    Email = model.EmailUsuario,
                    CodigoUsuario = string.Empty,
                    FechaCambioEstatus = DateTime.UtcNow,
                    FechaUltimaConexion = DateTime.UtcNow,
                    IdEstadoUsuario = (int)eEstadoUsuario.Activo,
                    IdTipoUsuario = model.IdTipoUsuario,
                    IdUsuario = Guid.NewGuid(),
                    Nombre = model.Nombre,
                    Pregunta1 = string.Empty,
                    Pregunta2 = string.Empty,
                    Pregunta3 = string.Empty,
                    PrimeraVez = true,
                    Respuesta1 = string.Empty,
                    Respuesta2 = string.Empty,
                    Respuesta3 = string.Empty
                };

                db.Usuario.Add(usuario);
                db.SaveChanges();

                ClasesVarias.AddBitacoraUsuario(db,
                   "Usuario para " + model.Nombre,
                   105000001,
                   "Agregar");

            }
            return RedirectToAction("Usuarios");
        }
        [HandleError]
        [SessionExpireFilter]
        public ActionResult EditUsuario(Guid id)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.UsuarioSeguridadResource.CreateUsuarioPageTitle;
            ViewBag.PageHeader = Resources.UsuarioSeguridadResource.CreateUsuarioHeaderPage;
            UsuarioViewModel model = new UsuarioViewModel();

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Encriptador Encrypt = new Encriptador();
                Encrypt.InicioClaves("53gur1cel!n37", "4LC_C0MUN1C4C10N35@S3GUR1C3L!N37", "53gur1c3l!4lcC0mun1c4c10n35@s3gur1c3lgm41l!c0m", 5);

                Usuario usuario = (from d in db.Usuario
                                   where d.IdUsuario == id
                                   select d).FirstOrDefault();

                string decryptedPassword = Encrypt.Encriptar(usuario.ClaveUsuario, Encriptador.HasAlgorimt.SHA1, Encriptador.Keysize.KS256);
                if (usuario != null)
                {
                    model.ConfirmPasswordUsuario = decryptedPassword;
                    model.EmailUsuario = usuario.Email;
                    model.Estado = usuario.IdEstadoUsuario;
                    model.Id = usuario.IdUsuario;
                    model.IdTipoUsuario = usuario.IdTipoUsuario;
                    model.Nombre = usuario.Nombre;
                    model.PasswordUsuario = decryptedPassword;
                }
            }

            return View(model);
        }
        [HandleError]
        [SessionExpireFilter]
        [HttpPost]
        public ActionResult EditUsuario(UsuarioViewModel model)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid)
            {
                ViewBag.Title = Resources.UsuarioSeguridadResource.CreateUsuarioPageTitle;
                ViewBag.PageHeader = Resources.UsuarioSeguridadResource.CreateUsuarioHeaderPage;
                return View(model);
            }

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Encriptador Encrypt = new Encriptador();
                Encrypt.InicioClaves("53gur1cel!n37", "4LC_C0MUN1C4C10N35@S3GUR1C3L!N37", "53gur1c3l!4lcC0mun1c4c10n35@s3gur1c3lgm41l!c0m", 5);
                string encryptedPassword = Encrypt.Encriptar(model.PasswordUsuario, Encriptador.HasAlgorimt.SHA1, Encriptador.Keysize.KS256);

                Usuario usuario = (from d in db.Usuario
                                   where d.IdUsuario == model.Id
                                   select d).FirstOrDefault();

                usuario.ClaveUsuario = encryptedPassword;
                usuario.CodigoUsuario = model.EmailUsuario;
                usuario.Email = model.EmailUsuario;
                usuario.IdTipoUsuario = model.IdTipoUsuario;
                usuario.PrimeraVez = true;
                usuario.Nombre = model.Nombre;

                db.SaveChanges();

                ClasesVarias.AddBitacoraUsuario(db,
                   "Usuario para " + model.Nombre,
                   105000001,
                   "Actualizar");

            }

            return RedirectToAction("Usuarios");
        }
        [HandleError]
        [SessionExpireFilter]
        public ActionResult DeleteUsuario(Guid id)
        {

            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            string Nombre = string.Empty;

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Usuario usuario = db.Usuario.Where(x => x.IdUsuario == id).FirstOrDefault();
                Nombre = usuario.Nombre;
                db.Usuario.Remove(usuario);
                db.SaveChanges();

            ClasesVarias.AddBitacoraUsuario(db,
               "Usuario " + Nombre,
               105000003,
               "Eliminar");

            }

            return RedirectToAction("Usuarios");
        }
        [HandleError]
        [SessionExpireFilter]
        public ActionResult UsuarioContrato()
        {

            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.Title = Resources.UsuarioSeguridadResource.UsuarioContratoPageTitle;
            ViewBag.PageHeader = Resources.UsuarioSeguridadResource.UsuarioContratoHeaderPage;

            return View();
        }
        [HandleError]
        [SessionExpireFilter]
        [HttpPost]
        public ActionResult UsuarioContrato(UsuarioContratoViewModel model)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.UsuarioSeguridadResource.UsuarioContratoPageTitle;
            ViewBag.PageHeader = Resources.UsuarioSeguridadResource.UsuarioContratoHeaderPage;

            if (ModelState.IsValid)
            {
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    Contrato_Usuario usuario = (from d in db.Contrato_Usuario
                                                where d.IdContrato == model.IdContrato && d.IdUsuario == model.IdUsuario
                                                select d).FirstOrDefault();

                    if (usuario == null)
                    {
                        usuario = new Contrato_Usuario
                        {
                            IdContrato = model.IdContrato,
                            IdUsuario = model.IdUsuario,
                            FechaRegistro = DateTime.UtcNow
                        };

                        db.SaveChanges();
                    }
                }
            }

            return View();
        }
        [HandleError]
        [SessionExpireFilter]
        public ActionResult Modulos()
        {

            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.Title = Resources.ModuloResource.ModulosPageTitle;
            ViewBag.PageHeader = Resources.ModuloResource.ModulosHeaderPage;

            List<ModuloViewModel> data = new List<ModuloViewModel>();

            using (SeguricelEntities db = new SeguricelEntities())
            {
                data = (from d in db.Modulo
                        select new ModuloViewModel
                        {
                            Action = d.Action,
                            Activo = d.Activo,
                            Controller = d.Controller,
                            IdModulo = d.IdModulo,
                            IdModuloPadre = (long)(d.IdModuloPadre == null ? d.IdModulo : d.IdModuloPadre),
                            IdTipoElemento = d.IdTipoElemento,
                            ModuloPadre = (d.Modulo2 == null ? d.Nombre : d.Modulo2.Nombre),
                            TipoElemento = ((eTipoElementoMenu)d.IdTipoElemento).ToString(),
                            Nombre = d.Nombre
                        }).ToList();
            }

            return View(data);
        }
        [HandleError]
        [SessionExpireFilter]
        public ActionResult CreateModulo()
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.ModuloResource.CreateModuloPageTitle;
            ViewBag.PageHeader = Resources.ModuloResource.CreateModuloHeaderPage;
            ModuloViewModel model = new ModuloViewModel();

            return View(model);
        }
        [HandleError]
        [SessionExpireFilter]
        [HttpPost]
        public ActionResult CreateModulo(ModuloViewModel model)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid)
            {
                ViewBag.Title = Resources.ModuloResource.CreateModuloPageTitle;
                ViewBag.PageHeader = Resources.ModuloResource.CreateModuloHeaderPage;
                return View(model);
            }

            using (SeguricelEntities db = new SeguricelEntities())
            {

                Modulo modulo = new Modulo
                {
                    Action = model.Action,
                    Activo = model.Activo,
                    Controller = model.Controller,
                    IdModulo = model.IdModulo,
                    IdModuloPadre = (((eTipoElementoMenu)model.IdTipoElemento) != eTipoElementoMenu.Nivel1 ? model.IdModuloPadre : (int?)null),
                    IdTipoElemento = model.IdTipoElemento,
                    Nombre = model.Nombre
                };

                db.Modulo.Add(modulo);
                db.SaveChanges();

                ClasesVarias.AddBitacoraUsuario(db,
                   "Módulo " + model.Nombre,
                   105000003,
                   "Agregar");

            }
            return RedirectToAction("Modulos");
        }
        [HandleError]
        [SessionExpireFilter]
        public ActionResult EditModulo(long id)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Title = Resources.ModuloResource.EditModuloPageTitle;
            ViewBag.PageHeader = Resources.ModuloResource.EditModuloHeaderPage;
            ModuloViewModel model = new ModuloViewModel();

            using (SeguricelEntities db = new SeguricelEntities())
            {

                model = (from d in db.Modulo
                         where d.IdModulo == id
                         select new ModuloViewModel
                         {
                             Action = d.Action,
                             Activo = d.Activo,
                             Controller = d.Controller,
                             IdModulo = d.IdModulo,
                             IdModuloPadre = (int)(d.IdModuloPadre == null ? 0 : d.IdModuloPadre),
                             IdTipoElemento = d.IdTipoElemento,
                             ModuloPadre = (d.Modulo2 == null ? string.Empty : d.Modulo2.Nombre),
                             Nombre = d.Nombre,
                             TipoElemento = ((eTipoElementoMenu)d.IdTipoElemento).ToString()
                         }).FirstOrDefault();

            }

            return View(model);
        }
        [HandleError]
        [SessionExpireFilter]
        [HttpPost]
        public ActionResult EditModulo(ModuloViewModel model)
        {
            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid)
            {
                ViewBag.Title = Resources.ModuloResource.EditModuloPageTitle;
                ViewBag.PageHeader = Resources.ModuloResource.EditModuloHeaderPage;
                return View(model);
            }

            using (SeguricelEntities db = new SeguricelEntities())
            {

                Modulo modulo = (from m in db.Modulo
                                 where m.IdModulo == model.IdModulo
                                 select m).FirstOrDefault();

                modulo.Action = model.Action;
                modulo.Activo = model.Activo;
                modulo.Controller = model.Controller;
                modulo.IdModuloPadre = (((eTipoElementoMenu)model.IdTipoElemento) != eTipoElementoMenu.Nivel1 ? model.IdModuloPadre : (int?)null);
                modulo.IdTipoElemento = model.IdTipoElemento;
                modulo.Nombre = model.Nombre;

                db.SaveChanges();

                ClasesVarias.AddBitacoraUsuario(db,
                   "Módulo " + model.Nombre,
                   105000003,
                   "Actualizar");

            }

            return RedirectToAction("Modulos");
        }
        [HandleError]
        [SessionExpireFilter]
        public ActionResult DeleteModulo(long id)
        {

            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            string Nombre = string.Empty;

            using (SeguricelEntities db = new SeguricelEntities())
            {
                Modulo modulo = db.Modulo.Where(x => x.IdModulo == id).FirstOrDefault();
                Nombre = modulo.Nombre;
                db.Modulo_TipoUsuario.RemoveRange(modulo.Modulo_TipoUsuario);
                db.Modulo.Remove(modulo);
                db.SaveChanges();

            ClasesVarias.AddBitacoraUsuario(db,
               "Módulo " + Nombre,
               105000003,
               "Eliminar");

            }

            return RedirectToAction("Modulos");
        }
        /// <summary>
        /// Obtener los roles creados en el sistema (Tipos de Usuario).
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [SessionExpireFilter]
        [HandleError]
        public ActionResult Roles(int? Id)
        {

            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ModelState.Clear();
            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.Title = Resources.RolesResource.RolesPageTitle;
            ViewBag.PageHeader = Resources.RolesResource.RolesHeaderPage;
            RolesViewModel model = new RolesViewModel();
            model.Roles = ClasesVarias.GetNivelesUsuario();
            model.showModulos = false;
            if (Id != null)
            {
                model.RolID = (int)Id;
                model.showModulos = true;
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    model.Modulos = (from d in db.Modulo
                                       select new RolViewModel
                                       {
                                           Asignado = (d.Modulo_TipoUsuario.Where(x => x.IdTipoUsuario == model.RolID).Count() > 0),
                                           FechaAsignacion = (DateTime)d.Modulo_TipoUsuario.Where(x => x.IdTipoUsuario == (int)Id).FirstOrDefault().FechaAsignacion,
                                           IdModulo = d.IdModulo,
                                           IdTipoUsuario = (int)Id,
                                           Modulo = d.Nombre,
                                           ModuloPadre = (d.Modulo2 != null ? d.Modulo2.Nombre : string.Empty)
                                       }).ToList();
                }
            }
            else
            {
                model.showModulos = false;
                model.Modulos = new List<RolViewModel>();
            }

            return View(model);
        }
        /// <summary>
        /// Obtener los módulos identificando los asignados a un rol específico.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public ActionResult Roles(RolesViewModel model)
        {

            if (User == null || User.GetType().ToString() == "System.Security.Principal.GenericPrincipal")
                return RedirectToAction("Index", "Home");

            ViewBag.Menu = ClasesVarias.GetMenuUsuario();
            ViewBag.Title = Resources.RolesResource.RolesPageTitle;
            ViewBag.PageHeader = Resources.RolesResource.RolesHeaderPage;
            model.Roles = ClasesVarias.GetNivelesUsuario();
            model.showModulos = false;
            if (model.RolID > 0)
            {
                model.showModulos = true;
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    model.Modulos = (from d in db.Modulo
                                     select new RolViewModel
                                     {
                                         Asignado = (d.Modulo_TipoUsuario.Where(x => x.IdTipoUsuario == model.RolID).Count() > 0),
                                         FechaAsignacion = (DateTime)d.Modulo_TipoUsuario.Where(x => x.IdTipoUsuario == model.RolID).FirstOrDefault().FechaAsignacion,
                                         IdModulo = d.IdModulo,
                                         IdTipoUsuario = model.RolID,
                                         Modulo = d.Nombre,
                                         ModuloPadre = (d.Modulo2 != null ? d.Modulo2.Nombre : string.Empty)
                                     }).ToList();

                }
            }
            else
            {
                model.showModulos = false;
                model.Modulos = new List<RolViewModel>();
            }

            return View(model);
        }
        /// <summary> 
        /// Permite agregar / eliminar el módulo del sistema al tipo de usuario dependiendo de Active.
        /// Active = true ==> Agregar el´módulo.
        /// Active = false ==> Eliminar el módulo.
        /// </summary>
        /// <param name="IdRol"></param>
        /// <param name="IdModulo"></param>
        /// <param name="Active"></param>
        /// <returns></returns>
        [SessionExpireFilter]
        [HandleError]
        public ActionResult UpdateRol(int IdRol, long IdModulo, bool Active)
        {
            try
            {
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    Modulo modulo = db.Modulo.Where(x => x.IdModulo == IdModulo).FirstOrDefault();

                    if (Active)
                    {
                        Modulo_TipoUsuario moduloUsuario = new Modulo_TipoUsuario
                        {
                            FechaAsignacion = DateTime.UtcNow,
                            IdModulo = IdModulo,
                            IdTipoUsuario = IdRol
                        };

                        db.Modulo_TipoUsuario.Add(moduloUsuario);

                        var chdQry1 = db.Modulo.Where(x => x.IdModuloPadre == IdModulo).Select(x => x.IdModulo);
                        var chdQry2 = from m in db.Modulo where chdQry1.Contains((long)m.IdModuloPadre) select m.IdModulo;
                        var chdQry3 = from m in db.Modulo where chdQry2.Contains((long)m.IdModuloPadre) select m.IdModulo;
                        var chdQry4 = from m in db.Modulo where chdQry3.Contains((long)m.IdModuloPadre) select m.IdModulo;

                        List<Modulo_TipoUsuario> Modulos = new List<Modulo_TipoUsuario>();
                        foreach (int IdNewModulo in chdQry1)
                        {
                            if (db.Modulo_TipoUsuario.Where(x => x.IdModulo == IdNewModulo && x.IdTipoUsuario == IdRol).Count() == 0)
                                Modulos.Add(new Modulo_TipoUsuario
                                {
                                    FechaAsignacion = DateTime.UtcNow,
                                    IdModulo = IdNewModulo,
                                    IdTipoUsuario = IdRol
                                });
                        }
                        if (chdQry2 != null && chdQry2.Count() > 0)
                        {
                            foreach (int IdNewModulo in chdQry2)
                            {
                                if (db.Modulo_TipoUsuario.Where(x => x.IdModulo == IdNewModulo && x.IdTipoUsuario == IdRol).Count() == 0)
                                    Modulos.Add(new Modulo_TipoUsuario
                                    {
                                        FechaAsignacion = DateTime.UtcNow,
                                        IdModulo = IdNewModulo,
                                        IdTipoUsuario = IdRol
                                    });
                            }
                        }
                        if (chdQry3 != null && chdQry3.Count() > 0)
                        {
                            foreach (int IdNewModulo in chdQry3)
                            {
                                if (db.Modulo_TipoUsuario.Where(x => x.IdModulo == IdNewModulo && x.IdTipoUsuario == IdRol).Count() == 0)
                                    Modulos.Add(new Modulo_TipoUsuario
                                    {
                                        FechaAsignacion = DateTime.UtcNow,
                                        IdModulo = IdNewModulo,
                                        IdTipoUsuario = IdRol
                                    });
                            }
                        }
                        if (chdQry4 != null && chdQry4.Count() > 0)
                        {
                            foreach (int IdNewModulo in chdQry4)
                            {
                                if (db.Modulo_TipoUsuario.Where(x => x.IdModulo == IdNewModulo && x.IdTipoUsuario == IdRol).Count() == 0)
                                    Modulos.Add(new Modulo_TipoUsuario
                                    {
                                        FechaAsignacion = DateTime.UtcNow,
                                        IdModulo = IdNewModulo,
                                        IdTipoUsuario = IdRol
                                    });
                            }
                        }

                        db.Modulo_TipoUsuario.AddRange(Modulos);

                        while (modulo.IdModuloPadre != null)
                        {
                            long idModuloPadre = (long)modulo.IdModuloPadre;

                            if (db.Modulo_TipoUsuario.Where(x => x.IdModulo == idModuloPadre && x.IdTipoUsuario == IdRol).Count() == 0)
                                db.Modulo_TipoUsuario.Add(new Modulo_TipoUsuario
                                {
                                    FechaAsignacion = DateTime.UtcNow,
                                    IdModulo = idModuloPadre,
                                    IdTipoUsuario = IdRol
                                });

                            modulo = db.Modulo.Where(x => x.IdModulo == idModuloPadre).FirstOrDefault();
                        }
                    }
                    else
                    {
                        Modulo_TipoUsuario moduloUsuario = db.Modulo_TipoUsuario.Where(x => x.IdModulo == IdModulo && x.IdTipoUsuario == IdRol).FirstOrDefault();
                        db.Modulo_TipoUsuario.Remove(moduloUsuario);

                        var inQry1 = db.Modulo.Where(x => x.IdModuloPadre == IdModulo).Select(x => x.IdModulo);
                        var inQry2 = from m in db.Modulo where inQry1.Contains((long)m.IdModuloPadre) select m.IdModulo;
                        var inQry3 = from m in db.Modulo where inQry2.Contains((long)m.IdModuloPadre) select m.IdModulo;
                        var inQry4 = from m in db.Modulo where inQry3.Contains((long)m.IdModuloPadre) select m.IdModulo;
                        var data = from m in db.Modulo_TipoUsuario
                                   where (inQry1.Contains(m.IdModulo)
                                        || inQry2.Contains(m.IdModulo)
                                        || inQry3.Contains(m.IdModulo)
                                        || inQry4.Contains(m.IdModulo)) && m.IdTipoUsuario == IdRol
                                   select m;
                        db.Modulo_TipoUsuario.RemoveRange(data);
                        List<Modulo_TipoUsuario> forDelete = new List<Modulo_TipoUsuario>();
                        long IdModuloSelected = modulo.IdModulo;

                        while (modulo.IdModuloPadre != null)
                        {

                            long IdModuloPadreDelete = (long)modulo.IdModuloPadre;
                            long Childs = db.Modulo_TipoUsuario.Where(x => x.Modulo.IdModuloPadre == IdModuloPadreDelete && x.IdTipoUsuario == IdRol && x.IdModulo != IdModuloSelected).Count();

                            if (Childs == 0)
                            {
                                Modulo_TipoUsuario DeleteModulo = db.Modulo_TipoUsuario.Where(x => x.IdModulo == modulo.IdModuloPadre && x.IdTipoUsuario == IdRol).FirstOrDefault();
                                if (DeleteModulo != null)
                                    forDelete.Add(DeleteModulo);
                            }
                            else if (Childs == 1)
                            {
                                Modulo_TipoUsuario ChildModulo = db.Modulo_TipoUsuario.Where(x => x.Modulo.IdModuloPadre == IdModuloPadreDelete && x.IdTipoUsuario == IdRol && x.IdModulo != IdModuloSelected).FirstOrDefault();
                                if (forDelete.Contains(ChildModulo))
                                {
                                    Modulo_TipoUsuario DeleteModulo = db.Modulo_TipoUsuario.Where(x => x.IdModulo == modulo.IdModuloPadre && x.IdTipoUsuario == IdRol).FirstOrDefault();
                                    forDelete.Add(DeleteModulo);
                                }
                            }

                            modulo = db.Modulo.Where(x => x.IdModulo == IdModuloPadreDelete).FirstOrDefault();
                        }

                        db.Modulo_TipoUsuario.RemoveRange(forDelete);
                        
                    }

                    db.SaveChanges();
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            string returnURL = Url.Action("Roles", "Seguridad", new { Id = IdRol }).ToString();
            return Json(returnURL);
        }

    }
}