using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Seguricel3
{
    public class CustomPrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role)
        {
            return false;
        }
        public CustomPrincipal(string email)
        {
            this.Identity = new GenericIdentity(email);
        }

        public eEstadoUsuario Estado { get; set; }
        public Nullable<DateTime> FechaUltimaConexion { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int IdTipoUsuario { get; set; }
        public int HoursTimeZone { get; set; }
        public int MinutesTimeZone { get; set; }
        public double Latitud { get; set; }
        public double Longitd { get; set; }
        public string Culture { get; set; }
        public string DefaultCulture { get; set; }
        public string Rol
        {
            get
            {
                string _rol = string.Empty;
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    _rol = (from r in db.TipoUsuario
                            where r.IdTipoUsuario == IdTipoUsuario
                            select r.Nombre).FirstOrDefault();
                }

                if (_rol == null)
                    _rol = string.Empty;

                return _rol;
            }
        }
    }

    public class CustomPrincipalSerializeModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public eEstadoUsuario Estado { get; set; }
        public Nullable<DateTime> FechaUltimaConexion{ get; set; }
        public int IdTipoUsuario { get; set; }
        public int HoursTimeZone { get; set; }
        public int MinutesTimeZone { get; set; }
        public string Rol
        {
            get
            {
                string _rol = string.Empty;
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    _rol = (from r in db.TipoUsuario
                            where r.IdTipoUsuario == IdTipoUsuario
                            select r.Nombre).FirstOrDefault();
                }

                if (_rol == null)
                    _rol = string.Empty;

                return _rol;
            }
        }
        public double Latitud { get; set; }
        public string Culture { get; set; }
        public string DefaultCulture { get; set; }
        public double Longitd { get; set; }
    }
}
