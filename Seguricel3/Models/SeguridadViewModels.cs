using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Seguricel3.Models
{

    public class UsuarioMasterDetailModel
    {
        public UsuarioViewModel SelectedUsuario { get; set; }
        public Guid SelectedUsuarioId { get; set; }
        public List<UsuarioViewModel> Usuarios { get; set; }
        public string LoginSubtitle { get { return Resources.LoginResource.LoginSubTitle; } }
        public string HembraLabel { get { return Resources.PerfilResource.LabelHembra; } }
        public string VaronLabel { get { return Resources.PerfilResource.LabelVaron; } }
        public string DatosPersonalesHeader { get { return Resources.PerfilResource.HeaderDatosPersonales; } }
        public string SeguridadHeader { get { return Resources.PerfilResource.HeaderSeguridad; } }
        public string HeaderColumn1 { get { return Resources.UsuarioSeguridadResource.HeaderColumna1; } }
        public string HeaderColumn2 { get { return Resources.UsuarioSeguridadResource.HeaderColumna2; } }
        public string HeaderColumn3 { get { return Resources.UsuarioSeguridadResource.HeaderColumna3; } }
        public string HeaderColumn4 { get { return Resources.UsuarioSeguridadResource.HeaderColumna4; } }
        public string HeaderColumn5 { get { return Resources.UsuarioSeguridadResource.HeaderColumna5; } }
        public string HeaderColumn6 { get { return Resources.UsuarioSeguridadResource.HeaderColumna6; } }
        public string HeaderListSecction { get { return Resources.UsuarioSeguridadResource.HeaderListSecction; } }
        public string LabelNewButton { get { return Resources.EtiquetasResource.labelNewLink; } }
        public string LabelEditButton { get { return Resources.EtiquetasResource.labelEditLink; } }

    }
    public class UsuarioViewModel
    {
        [Display(Name = "LabelEmail", ResourceType = typeof(Resources.PerfilResource))]
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "TypeValueErrorMessage")]
        public string Email { get; set; }
        [Display(Name = "LabelPassword", ResourceType = typeof(Resources.PerfilResource))]
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [StringLength(100, ErrorMessageResourceName = "StringLengthErrorMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), MinimumLength = 6)]
        [DataType(DataType.Password, ErrorMessageResourceName = "TypeValueErrorMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        public string Password { get; set; }
        [Display(Name = "LabelConfirmarContraseña", ResourceType = typeof(Resources.PerfilResource))]
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [StringLength(100, ErrorMessageResourceName = "StringLengthErrorMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), MinimumLength = 6)]
        [DataType(DataType.Password, ErrorMessageResourceName = "TypeValueErrorMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "ConfirmarContraseñaCompareErrorMessage")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "LabelNombre", ResourceType = typeof(Resources.PerfilResource))]
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [StringLength(500, ErrorMessageResourceName = "StringLengthErrorMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), MinimumLength = 10)]
        public string Nombre { get; set; }
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [Display(Name = "LabelNivelUsuario", ResourceType = typeof(Resources.UsuarioSeguridadResource))]
        public int IdTipoUsuario { get; set; }
        public IEnumerable<SelectListItem> NivelesUsuario { get; set; }
        [Display(Name = "LabelNivelUsuario", ResourceType = typeof(Resources.UsuarioSeguridadResource))]
        public string NivelUsuario { get; set; }
        [Display(Name = "LabelFechaRegistro", ResourceType = typeof(Resources.UsuarioSeguridadResource))]
        public DateTime FechaRegistro { get; set; }
        [Display(Name = "LabelFechaUltimaConexion", ResourceType = typeof(Resources.UsuarioSeguridadResource))]
        public DateTime FechaUltimaConexion { get; set; }
        [Display(Name = "LabelFechaCambioEstado", ResourceType = typeof(Resources.UsuarioSeguridadResource))]
        public DateTime FechaCambioEstado { get; set; }
        [Display(Name = "LabelEstadoUsuario", ResourceType = typeof(Resources.UsuarioSeguridadResource))]
        public eEstadoUsuario Estado { get; set; }
        [Display(Name = "LabelEstadoUsuario", ResourceType = typeof(Resources.UsuarioSeguridadResource))]
        public string EstadoUsuario { get; set; }
        public Guid Id { get; set; }
        public string UserTimeZone { get; set; }
        public string ValidationSummaryText { get { return Resources.LoginResource.ValidationSummaryText; } }
        private string _HeaderDetailSection;
        public string HeaderDetailSection
        {
            get { return _HeaderDetailSection; }
            set { _HeaderDetailSection = value; }
        }
        public string SaveButtonText { get { return Resources.UsuarioSeguridadResource.SaveButtonText; } }
        public string LabelDeleteButton { get { return Resources.EtiquetasResource.labelDeleteLink; } }
        public string LabelBackButton { get { return Resources.EtiquetasResource.labelBackLink; } }
    }
    public class EstadoUsuarioViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
