using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Seguricel3.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessageResourceName ="EmailRequiredErrorMessage", ErrorMessageResourceType = typeof(Resources.LoginResource))]
        [Display(Name = "EmailLabel", ResourceType = typeof(Resources.LoginResource))]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.LoginResource), ErrorMessageResourceName = "ProviderRequiredErrorMessage")]
        public string Provider { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.LoginResource), ErrorMessageResourceName = "CodeRequiredErrorMessage")]
        [Display(Name = "CodeLabel", ResourceType = typeof(Resources.LoginResource))]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "RememberBrowserLabel", ResourceType = typeof(Resources.LoginResource))]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required(ErrorMessageResourceName = "EmailRequiredErrorMessage", ErrorMessageResourceType = typeof(Resources.LoginResource))]
        [Display(Name = "EmailLabel", ResourceType = typeof(Resources.LoginResource))]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessageResourceName = "EmailRequiredErrorMessage", ErrorMessageResourceType = typeof(Resources.LoginResource))]
        [Display(Name = "EmailLabel", ResourceType = typeof(Resources.LoginResource))]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.LoginResource), ErrorMessageResourceName = "EmailAddressErrorMessge")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "PasswordRequiredErrorMessage", ErrorMessageResourceType = typeof(Resources.LoginResource))]
        [Display(Name = "PasswordLabel", ResourceType = typeof(Resources.LoginResource))]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "RecordarCuentaLabel", ResourceType = typeof(Resources.LoginResource))]
        public bool RememberMe { get; set; }
        public string UserTimeZone { get; set; }

        public string LoginSubtitle { get { return Resources.LoginResource.LoginSubTitle; } }
        public string ValidationSummaryText { get { return Resources.LoginResource.ValidationSummaryText; } }
        public string submitButtonText { get { return Resources.LoginResource.submitButtonText; } }
        public string RegistrarNuevoUsuarioLabel { get { return Resources.LoginResource.RegistrarNuevoUsuarioLabel; } }
        public string ForgotPasswordText { get { return Resources.LoginResource.ForgotPasswordText; } }
        public string CookieWarningMessage { get { return Resources.LoginResource.LoginCookieClientMessage; } }

        public LoginViewModel()
        {
            this.Email = string.Empty;
            this.Password = string.Empty;
            this.RememberMe = false;
            this.UserTimeZone = string.Empty;
        }

    }

    public class RegisterViewModel
    {
        [Required(ErrorMessageResourceName = "EmailRequiredErrorMessage", ErrorMessageResourceType = typeof(Resources.LoginResource))]
        [Display(Name = "EmailLabel", ResourceType = typeof(Resources.LoginResource))]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.LoginResource), ErrorMessageResourceName = "EmailAddressErrorMessge")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "PasswordRequiredErrorMessage", ErrorMessageResourceType = typeof(Resources.LoginResource))]
        [Display(Name = "PasswordLabel", ResourceType = typeof(Resources.LoginResource))]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessageResourceName = "StringLengthErrorMessage", ErrorMessageResourceType = typeof(Resources.LoginResource), MinimumLength = 6)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmarContraseñaLabel", ResourceType = typeof(Resources.LoginResource))]
        [Compare("Password", ErrorMessageResourceType = typeof(Resources.LoginResource), ErrorMessageResourceName = "ConfirmarContraseñaCompareErrorMessage")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessageResourceName = "EmailRequiredErrorMessage", ErrorMessageResourceType = typeof(Resources.LoginResource))]
        [Display(Name = "EmailLabel", ResourceType = typeof(Resources.LoginResource))]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.LoginResource), ErrorMessageResourceName = "EmailAddressErrorMessge")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "PasswordRequiredErrorMessage", ErrorMessageResourceType = typeof(Resources.LoginResource))]
        [Display(Name = "PasswordLabel", ResourceType = typeof(Resources.LoginResource))]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessageResourceName = "StringLengthErrorMessage", ErrorMessageResourceType = typeof(Resources.LoginResource), MinimumLength = 6)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmarContraseñaLabel", ResourceType = typeof(Resources.LoginResource))]
        [Compare("Password", ErrorMessageResourceType = typeof(Resources.LoginResource), ErrorMessageResourceName = "ConfirmarContraseñaCompareErrorMessage")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessageResourceName = "EmailRequiredErrorMessage", ErrorMessageResourceType = typeof(Resources.LoginResource))]
        [Display(Name = "EmailLabel", ResourceType = typeof(Resources.LoginResource))]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.LoginResource), ErrorMessageResourceName = "EmailAddressErrorMessge")]
        public string Email { get; set; }
    }

    public class PerfilViewModel
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
        [Compare("Password", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "ConfirmarContraseñaCompareErrorMessage")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "LabelNombre", ResourceType = typeof(Resources.PerfilResource))]
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [StringLength(500, ErrorMessageResourceName = "StringLengthErrorMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), MinimumLength = 10)]
        public string Nombre { get; set; }
        [Display(Name = "LabelApodo", ResourceType = typeof(Resources.PerfilResource))]
        [StringLength(50, ErrorMessageResourceName = "StringLengthErrorMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), MinimumLength = 2)]
        public string Apodo { get; set; }
        [Display(Name = "LabelFechaNacimiento", ResourceType = typeof(Resources.PerfilResource))]
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [DataType(DataType.DateTime, ErrorMessageResourceName = "TypeValueErrorMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        //[Range(minimum: DateTime.UtcNow.AddYears(18), maximum: DateTime.UtcNow, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "Ra")]
        public DateTime FechaNacimiento { get; set; }
        [Display(Name = "LabelVaron", ResourceType = typeof(Resources.PerfilResource))]
        public bool Varon { get; set; }
        [Display(Name = "LabelTelefono", ResourceType = typeof(Resources.PerfilResource))]
        [StringLength(50, ErrorMessageResourceName = "StringLengthErrorMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), MinimumLength = 2)]
        [Phone(ErrorMessageResourceName = "TypeValueErrorMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        public string Telefono { get; set; }
        [Display(Name = "LabelPeguntaSeguridad1", ResourceType = typeof(Resources.PerfilResource))]
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [StringLength(500, ErrorMessageResourceName = "StringLengthErrorMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), MinimumLength = 10)]
        public string Pregunta1 { get; set; }
        [Display(Name = "LabelRespuestaSeguridad1", ResourceType = typeof(Resources.PerfilResource))]
        [StringLength(500, ErrorMessageResourceName = "StringLengthErrorMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), MinimumLength = 10)]
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        public string Respuesta1 { get; set; }
        [Display(Name = "LabelPeguntaSeguridad2", ResourceType = typeof(Resources.PerfilResource))]
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [StringLength(500, ErrorMessageResourceName = "StringLengthErrorMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), MinimumLength = 10)]
        public string Pregunta2 { get; set; }
        [Display(Name = "LabelRespuestaSeguridad2", ResourceType = typeof(Resources.PerfilResource))]
        [StringLength(500, ErrorMessageResourceName = "StringLengthErrorMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), MinimumLength = 10)]
        public string Respuesta2 { get; set; }
        [Display(Name = "LabelPeguntaSeguridad3", ResourceType = typeof(Resources.PerfilResource))]
        [StringLength(500, ErrorMessageResourceName = "StringLengthErrorMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), MinimumLength = 10)]
        public string Pregunta3 { get; set; }
        [Display(Name = "LabelRespuestaSeguridad3", ResourceType = typeof(Resources.PerfilResource))]
        [StringLength(500, ErrorMessageResourceName = "StringLengthErrorMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), MinimumLength = 10)]
        public string Respuesta3 { get; set; }

        public string UserTimeZone { get; set; }
        public string LoginSubtitle { get { return Resources.LoginResource.LoginSubTitle; } }
        public string HembraLabel { get { return Resources.PerfilResource.LabelHembra; } }
        public string VaronLabel { get { return Resources.PerfilResource.LabelVaron; } }
        public string ValidationSummaryText { get { return Resources.LoginResource.ValidationSummaryText; } }
        public string submitButtonText { get { return Resources.LoginResource.submitButtonText; } }
        public string DatosPersonalesHeader { get { return Resources.PerfilResource.HeaderDatosPersonales; } }
        public string SeguridadHeader { get { return Resources.PerfilResource.HeaderSeguridad; } }

    }
}
