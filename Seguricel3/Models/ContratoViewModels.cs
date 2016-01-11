using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seguricel3.Models
{

    public class ContratoViewModel : IValidatableObject
    {

        [Display(Name = "LabelContrato", ResourceType = typeof(Resources.ContratosResource))]
        public System.Guid IdContrato { get; set; }
        [Display(Name = "LabelTipoContrato", ResourceType = typeof(Resources.ContratosResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int IdTipoContrato { get; set; }
        public IEnumerable<SelectListItem> TiposContrato { get; set; }
        [Display(Name = "LabelTipoContrato", ResourceType = typeof(Resources.ContratosResource))]
        public string TipoContrato { get; set; }
        [Display(Name = "LabelNroContrato", ResourceType = typeof(Resources.ContratosResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public string NroContrato { get; set; }
        [Display(Name = "LabelContratante", ResourceType = typeof(Resources.ContratosResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public string Contratante { get; set; }
        [Display(Name = "LabelNombreCompleto", ResourceType = typeof(Resources.ContratosResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public string NombreCompleto { get; set; }
        [Display(Name = "LabelDireccion", ResourceType = typeof(Resources.ContratosResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public string Direccion { get; set; }
        [Display(Name = "LabelPais", ResourceType = typeof(Resources.ContratosResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int IdPais { get; set; }
        public IEnumerable<SelectListItem> PaisesDisponibles { get; set; }
        [Display(Name = "LabelEstado", ResourceType = typeof(Resources.ContratosResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int IdEstado { get; set; }
        public IEnumerable<SelectListItem> Estados { get; set; }
        [Display(Name = "LabelCiudad", ResourceType = typeof(Resources.ContratosResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int IdCiudad { get; set; }
        public IEnumerable<SelectListItem> Ciudades { get; set; }
        [Display(Name = "LabelCodigoPostal", ResourceType = typeof(Resources.ContratosResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public string CodigoPostal { get; set; }
        [Display(Name = "LabelFechaContrato", ResourceType = typeof(Resources.ContratosResource))]
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "TypeValueErrorMessage")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = false, DataFormatString = "{0:d}")]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public System.DateTime FechaContrato { get; set; }
        [Display(Name = "LabelRegistroFiscal", ResourceType = typeof(Resources.ContratosResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public string RegistroFiscal { get; set; }
        [Display(Name = "LabelAdministradora", ResourceType = typeof(Resources.ContratosResource))]
        public System.Guid IdAdministradora { get; set; }
        public IEnumerable<SelectListItem> Administradoras { get; set; }
        [Display(Name = "LabelEstadoContrato", ResourceType = typeof(Resources.ContratosResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int IdEstadoContrato { get; set; }
        public IEnumerable<SelectListItem> EstadosContrato { get; set; }
        [Display(Name = "LabelEstadoContrato", ResourceType = typeof(Resources.ContratosResource))]
        public string EstadoContrato { get; set; }
        [Display(Name = "LabelUbicacionGeografica", ResourceType = typeof(Resources.ContratosResource))]
        public System.Data.Entity.Spatial.DbGeography UbicacionGeografica { get; set; }
        public string PaisEstadoCiudad { get; set; }
        [Display(Name = "LabelLongitud", ResourceType = typeof(Resources.ContratosResource))]
        public string Latitud { get; set; }
        [Display(Name = "LabelLatitud", ResourceType = typeof(Resources.ContratosResource))]
        public string Longitud { get; set; }
        [Display(Name = "LabelAutoGestion", ResourceType = typeof(Resources.ContratosResource))]
        public bool AutoGestion { get; set; }
        [Display(Name = "LabelAccesoTelefonico", ResourceType = typeof(Resources.ContratosResource))]
        public bool AccesoTelefonico { get; set; }
        [Display(Name = "LabelAccesoDactilar", ResourceType = typeof(Resources.ContratosResource))]
        public bool AccesoDactilar { get; set; }
        [Display(Name = "LabelVigicel", ResourceType = typeof(Resources.ContratosResource))]
        public bool Vigicel { get; set; }
        [Display(Name = "LabelAlarmaSilente", ResourceType = typeof(Resources.ContratosResource))]
        public bool AlarmaSilente { get; set; }
        [Display(Name = "LabelCondominioVirtual", ResourceType = typeof(Resources.ContratosResource))]
        public bool CondominioVirtual { get; set; }
        [Display(Name = "LabelControlAscensores", ResourceType = typeof(Resources.ContratosResource))]
        public bool ControlAscensores { get; set; }
        [Display(Name = "LabelEmergenciaVecinal", ResourceType = typeof(Resources.ContratosResource))]
        public bool EmergenciaVecinal { get; set; }
        [Display(Name = "LabelMaximoSecundarios", ResourceType = typeof(Resources.ContratosResource))]
        public int MaximoSecundarios { get; set; }
        [Display(Name = "LabelMaximoInvitados", ResourceType = typeof(Resources.ContratosResource))]
        public int MaximoInvitados { get; set; }
        [Display(Name = "LabelControlEstacionamiento", ResourceType = typeof(Resources.ContratosResource))]
        public bool ControlEstacionamiento { get; set; }
        [Display(Name = "LabelMaximoPuestosVisitantes", ResourceType = typeof(Resources.ContratosResource))]
        public int MaximoPuestosVisitantes { get; set; }
        [Display(Name = "LabelMaximoPuestosFijos", ResourceType = typeof(Resources.ContratosResource))]
        public int MaximoPuestosFijos { get; set; }
        [Display(Name = "LabelCorreoElectronicoJunta", ResourceType = typeof(Resources.ContratosResource))]
        public string CorreoElectronicoJunta { get; set; }
        [Display(Name = "LabelCorreoElectronicoComunida", ResourceType = typeof(Resources.ContratosResource))]
        public string CorreoElectronicoComunida { get; set; }
        [Display(Name = "LabelPuertoPOPGeneral", ResourceType = typeof(Resources.ContratosResource))]
        public Nullable<int> PuertoPOPGeneral { get; set; }
        [Display(Name = "LabelPuertoSMTPGeneral", ResourceType = typeof(Resources.ContratosResource))]
        public Nullable<int> PuertoSMTPGeneral { get; set; }
        [Display(Name = "LabelServidorPOPGeneral", ResourceType = typeof(Resources.ContratosResource))]
        public string ServidorPOPGeneral { get; set; }
        [Display(Name = "LabelServidorSMTPGeneral", ResourceType = typeof(Resources.ContratosResource))]
        public string ServidorSMTPGeneral { get; set; }
        [Display(Name = "LabelPuertoPOPJC", ResourceType = typeof(Resources.ContratosResource))]
        public Nullable<int> PuertoPOPJC { get; set; }
        [Display(Name = "LabelPuertoSMTPJC", ResourceType = typeof(Resources.ContratosResource))]
        public Nullable<int> PuertoSMTPJC { get; set; }
        [Display(Name = "LabelServidorPOPJC", ResourceType = typeof(Resources.ContratosResource))]
        public string ServidorPOPJC { get; set; }
        [Display(Name = "LabelServidorSMTPJC", ResourceType = typeof(Resources.ContratosResource))]
        public string ServidorSMTPJC { get; set; }
        [Display(Name = "LabelUsuarioCorreoComunidad", ResourceType = typeof(Resources.ContratosResource))]
        public string UsuarioCorreoComunidad { get; set; }
        [Display(Name = "LabelContraseñaCorreoComunidad", ResourceType = typeof(Resources.ContratosResource))]
        public string ContraseñaCorreoComunidad { get; set; }
        [Display(Name = "LabelUsuarioCorreoJC", ResourceType = typeof(Resources.ContratosResource))]
        public string UsuarioCorreoJC { get; set; }
        [Display(Name = "LabelContraseñaCorreoJC", ResourceType = typeof(Resources.ContratosResource))]
        public string ContraseñaCorreoJC { get; set; }
        [Display(Name = "LabelImagenEdificio", ResourceType = typeof(Resources.ContratosResource))]
        public string ImagenEdificio { get; set; }
        [Display(Name = "LabelIdRedMiwi", ResourceType = typeof(Resources.ContratosResource))]
        public byte[] IdRedMiwi { get; set; }
        public int UserHours { get; set; }
        public int UserMinutes { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            List<ValidationResult> res = new List<ValidationResult>();
            if (FechaContrato > DateTime.UtcNow.AddHours(UserHours).AddMinutes(UserMinutes))
            {
                ValidationResult mss = new ValidationResult(Resources.ErrorMessageResource.DateTimeVsTodayErrorMessage);
                res.Add(mss);
            }
            return res;
        }
    }
    public class ContactosViewModel
    {
        [Display(Name = "labelPais", ResourceType = typeof(Resources.TablasResource))]
        public int IdPais { get; set; }
        public IEnumerable<SelectListItem> Paises { get; set; }
        [Display(Name = "LabelContrato", ResourceType = typeof(Resources.ContratoContactoResource))]
        public Guid IdContrato { get; set; }
        public IEnumerable<SelectListItem> Contratos { get; set; }
        public bool showContactos { get; set; }
        public List<ContactoViewModel> Contactos { get; set; }
    }
    public class ContactoViewModel
    {
        public int IdPais { get; set; }
        public System.Guid IdContrato { get; set; }
        public System.Guid IdContacto { get; set; }
        [Display(Name="LabelNombre", ResourceType=typeof(Resources.ContratoContactoResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public string Nombre { get; set; }
        [Display(Name = "LabelCargoJunta", ResourceType = typeof(Resources.ContratoContactoResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int IdCargoJunta { get; set; }
        public IEnumerable<SelectListItem> CargosJunta { get; set; }
        [Display(Name = "LabelCargoJunta", ResourceType = typeof(Resources.ContratoContactoResource))]
        public string CargoJunta { get; set; }
        [Display(Name = "LabelTelefonoFijo", ResourceType = typeof(Resources.ContratoContactoResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int TelefonoFijo { get; set; }
        [Display(Name = "LabelTelefonoMovil", ResourceType = typeof(Resources.ContratoContactoResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int TelefonoMovil { get; set; }
    }

}