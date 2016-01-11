using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Seguricel3.Models
{

    public class UsuarioViewModel
    {
        [Display(Name = "labelEmail", ResourceType = typeof(Resources.UsuarioSeguridadResource))]
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "TypeValueErrorMessage")]
        public string EmailUsuario { get; set; }
        [Display(Name = "labelPassword", ResourceType = typeof(Resources.UsuarioSeguridadResource))]
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [StringLength(100, ErrorMessageResourceName = "StringLengthErrorMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), MinimumLength = 6)]
        [DataType(DataType.Password, ErrorMessageResourceName = "TypeValueErrorMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        public string PasswordUsuario { get; set; }
        [Display(Name = "labelConfirmarContraseña", ResourceType = typeof(Resources.UsuarioSeguridadResource))]
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [StringLength(100, ErrorMessageResourceName = "StringLengthErrorMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), MinimumLength = 6)]
        [DataType(DataType.Password, ErrorMessageResourceName = "TypeValueErrorMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [System.ComponentModel.DataAnnotations.Compare("PasswordUsuario", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "ConfirmarContraseñaCompareErrorMessage")]
        public string ConfirmPasswordUsuario { get; set; }
        [Display(Name = "labelNombre", ResourceType = typeof(Resources.UsuarioSeguridadResource))]
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [StringLength(500, ErrorMessageResourceName = "StringLengthErrorMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), MinimumLength = 10)]
        public string Nombre { get; set; }
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [Display(Name = "labelTipoUsuario", ResourceType = typeof(Resources.UsuarioSeguridadResource))]
        public int IdTipoUsuario { get; set; }
        [Display(Name = "labelTipoUsuario", ResourceType = typeof(Resources.UsuarioSeguridadResource))]
        public string NivelUsuario { get; set; }
        [Display(Name = "labelFechaUltimaConexion", ResourceType = typeof(Resources.UsuarioSeguridadResource))]
        [DisplayFormat(DataFormatString = "{0:g}", ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, NullDisplayText = "")]
        public DateTime FechaUltimaConexion { get; set; }
        [Display(Name = "labelFechaCambioEstado", ResourceType = typeof(Resources.UsuarioSeguridadResource))]
        [DisplayFormat(DataFormatString = "{0:g}", ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, NullDisplayText = "")]
        public DateTime FechaCambioEstado { get; set; }
        [Display(Name = "labelEstadoUsuario", ResourceType = typeof(Resources.UsuarioSeguridadResource))]
        public int Estado { get; set; }
        [Display(Name = "labelEstadoUsuario", ResourceType = typeof(Resources.UsuarioSeguridadResource))]
        public string EstadoUsuario { get; set; }
        public Guid Id { get; set; }

        public UsuarioViewModel()
        {
            this.EmailUsuario = string.Empty;
            this.ConfirmPasswordUsuario = string.Empty;
            this.Estado = (int)eEstadoUsuario.Activo;
            this.EstadoUsuario = eEstadoUsuario.Activo.ToString();
            this.FechaCambioEstado = DateTime.UtcNow;
            this.IdTipoUsuario = 0;
            this.Nombre = string.Empty;
            this.PasswordUsuario = string.Empty;
        }
    }
    public class UsuarioContratoViewModel
    {
        [Display(Name = "labelUsuario", ResourceType = typeof(Resources.UsuarioSeguridadResource))]
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        public Guid IdUsuario { get; set; }
        [Display(Name = "labelContrato", ResourceType = typeof(Resources.UsuarioSeguridadResource))]
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        public Guid IdContrato { get; set; }
        [Display(Name = "labelUnidad", ResourceType = typeof(Resources.UsuarioSeguridadResource))]
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        public Guid IdUnidad { get; set; }
        [Display(Name = "labelPais", ResourceType = typeof(Resources.TablasResource))]
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        public int IdPais { get; set; }
        [Display(Name = "labelEstado", ResourceType = typeof(Resources.TablasResource))]
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        public int IdEstado { get; set; }
        [Display(Name = "labelCiudad", ResourceType = typeof(Resources.TablasResource))]
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        public int IdCiudad { get; set; }
    }
    public class ModuloViewModel
    {
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [Display(Name = "labelModulo", ResourceType = typeof(Resources.ModuloResource))]
        [RegularExpression("([1-9][0-9]*)", ErrorMessageResourceName = "RegularExpressionMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        public long IdModulo { get; set; }
        [Display(Name = "labelModuloPadre", ResourceType = typeof(Resources.ModuloResource))]
        public Nullable<long> IdModuloPadre { get; set; }
        [Display(Name = "labelModuloPadre", ResourceType = typeof(Resources.ModuloResource))]
        public string ModuloPadre { get; set; }
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [Display(Name = "labelModuloNombre", ResourceType = typeof(Resources.ModuloResource))]
        [StringLength(50, ErrorMessageResourceName = "StringLengthErrorMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        public string Nombre { get; set; }
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [Display(Name = "labelModuloTipoElemento", ResourceType = typeof(Resources.ModuloResource))]
        public int IdTipoElemento { get; set; }
        [Display(Name = "labelModuloTipoElemento", ResourceType = typeof(Resources.ModuloResource))]
        public string TipoElemento { get; set; }
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [Display(Name = "labelModuloController", ResourceType = typeof(Resources.ModuloResource))]
        [StringLength(50, ErrorMessageResourceName = "StringLengthErrorMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        public string Controller { get; set; }
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [Display(Name = "labelModuloAction", ResourceType = typeof(Resources.ModuloResource))]
        [StringLength(50, ErrorMessageResourceName = "StringLengthErrorMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        public string Action { get; set; }
        [Display(Name = "labelModuloActivo", ResourceType = typeof(Resources.ModuloResource))]
        public bool Activo { get; set; }

        public ModuloViewModel()
        {
            this.Action = string.Empty;
            this.Activo = false;
            this.Controller = string.Empty;
            this.IdModulo = 0;
            this.IdModuloPadre = 0;
            this.IdTipoElemento = 0;
            this.ModuloPadre = string.Empty;
            this.Nombre= string.Empty;
            this.TipoElemento = string.Empty;
        }

    }
    public class RolesViewModel
    {
        public int RolID { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
        public bool showModulos { get; set; }
        public List<RolViewModel> Modulos { get; set; }

    }
    public class RolViewModel
    {
        [Display(Name = "labelModulo", ResourceType = typeof(Resources.RolesResource))]
        public long IdModulo { get; set; }
        [Display(Name = "labelModulo", ResourceType = typeof(Resources.RolesResource))]
        public string Modulo { get; set; }
        [Display(Name = "labelModuloPadre", ResourceType = typeof(Resources.ModuloResource))]
        public string ModuloPadre { get; set; }
        [Display(Name = "labelTipoUsuario", ResourceType = typeof(Resources.RolesResource))]
        public int IdTipoUsuario { get; set; }
        [Display(Name = "labelFechaAsignación", ResourceType = typeof(Resources.RolesResource))]
        [DisplayFormat(DataFormatString = "{0:g}", ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, NullDisplayText = "")]
        public Nullable<DateTime> FechaAsignacion { get; set; }
        [Display(Name = "labelAsignado", ResourceType = typeof(Resources.RolesResource))]
        public bool Asignado { get; set; }
    }


}
