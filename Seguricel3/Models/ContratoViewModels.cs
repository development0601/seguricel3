using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Seguricel3.Models
{

    public class ContratoViewModel
    {

        [Display(Name = "LabelContrato", ResourceType = typeof(Resources.ContratosResource))]
        public System.Guid IdContrato { get; set; }
        [Display(Name = "LabelTipoContrato", ResourceType = typeof(Resources.ContratosResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int IdTipoContrato { get; set; }
        [Display(Name = "LabelTipoContrato", ResourceType = typeof(Resources.ContratosResource))]
        public string TipoContrato { get; set; }
        [Display(Name = "LabelNroContrato", ResourceType = typeof(Resources.ContratosResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public long NroContrato { get; set; }
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
        [Display(Name = "LabelPais", ResourceType = typeof(Resources.ContratosResource))]
        public string Pais { get; set; }
        [Display(Name = "LabelEstado", ResourceType = typeof(Resources.ContratosResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int IdEstado { get; set; }
        [Display(Name = "LabelEstado", ResourceType = typeof(Resources.ContratosResource))]
        public string Estado { get; set; }
        [Display(Name = "LabelCiudad", ResourceType = typeof(Resources.ContratosResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int IdCiudad { get; set; }
        [Display(Name = "LabelCiudad", ResourceType = typeof(Resources.ContratosResource))]
        public string Ciudad { get; set; }
        [Display(Name = "LabelCodigoPostal", ResourceType = typeof(Resources.ContratosResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public string CodigoPostal { get; set; }
        [Display(Name = "LabelFechaContrato", ResourceType = typeof(Resources.ContratosResource))]
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "TypeValueErrorMessage")]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public System.DateTime FechaContrato { get; set; }
        [Display(Name = "LabelRegistroFiscal", ResourceType = typeof(Resources.ContratosResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public string RegistroFiscal { get; set; }
        [Display(Name = "LabelAdministradora", ResourceType = typeof(Resources.ContratosResource))]
        public System.Guid IdAdministradora { get; set; }
        [Display(Name = "LabelAdministradora", ResourceType = typeof(Resources.ContratosResource))]
        public string Administradora { get; set; }
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
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        [Range(1, 99, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RangeErrorMessage")]
        public int MaximoSecundarios { get; set; }
        [Display(Name = "LabelMaximoInvitados", ResourceType = typeof(Resources.ContratosResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        [Range(1, 99, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RangeErrorMessage")]
        public int MaximoInvitados { get; set; }
        [Display(Name = "LabelControlEstacionamiento", ResourceType = typeof(Resources.ContratosResource))]
        public bool ControlEstacionamiento { get; set; }
        [Display(Name = "LabelMaximoPuestosVisitantes", ResourceType = typeof(Resources.ContratosResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int MaximoPuestosVisitantes { get; set; }
        [Display(Name = "LabelMaximoPuestosFijos", ResourceType = typeof(Resources.ContratosResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int MaximoPuestosFijos { get; set; }
        [Display(Name = "LabelCorreoElectronicoJunta", ResourceType = typeof(Resources.ContratosResource))]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public string CorreoElectronicoJunta { get; set; }
        [Display(Name = "LabelCorreoElectronicoComunida", ResourceType = typeof(Resources.ContratosResource))]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public string CorreoElectronicoComunida { get; set; }
        [Display(Name = "LabelPuertoPOPGeneral", ResourceType = typeof(Resources.ContratosResource))]
        public int PuertoPOPGeneral { get; set; }
        [Display(Name = "LabelPuertoSMTPGeneral", ResourceType = typeof(Resources.ContratosResource))]
        public int PuertoSMTPGeneral { get; set; }
        [Display(Name = "LabelServidorPOPGeneral", ResourceType = typeof(Resources.ContratosResource))]
        public string ServidorPOPGeneral { get; set; }
        [Display(Name = "LabelServidorSMTPGeneral", ResourceType = typeof(Resources.ContratosResource))]
        public string ServidorSMTPGeneral { get; set; }
        [Display(Name = "LabelPuertoPOPJC", ResourceType = typeof(Resources.ContratosResource))]
        public int PuertoPOPJC { get; set; }
        [Display(Name = "LabelPuertoSMTPJC", ResourceType = typeof(Resources.ContratosResource))]
        public int PuertoSMTPJC { get; set; }
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
        [Display(Name = "LabelNroRedesInstalacion", ResourceType = typeof(Resources.ContratosResource))]
        public int NroRedesInstalacion { get; set; }
        [Display(Name = "LabelDetieneSMS_Emergencia", ResourceType = typeof(Resources.ContratosResource))]
        public bool DetieneSMS_Emergencia { get; set; }
        [Display(Name = "LabelDetieneSMS_JC", ResourceType = typeof(Resources.ContratosResource))]
        public bool DetieneSMS_JC { get; set; }
        [Display(Name = "LabelMesCorte", ResourceType = typeof(Resources.ContratosResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        [Range(1, 12, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RangeErrorMessage")]
        public int MesCorte { get; set; }
        [Display(Name = "LabelAutoGestion_Aptos", ResourceType = typeof(Resources.ContratosResource))]
        public bool AutoGestion_Aptos { get; set; }
        [Display(Name = "LabelImagenEdificio", ResourceType = typeof(Resources.ContratosResource))]
        public byte[] ImagenEdificio { get; set; }
        [Display(Name = "LabelIdRedMiwi", ResourceType = typeof(Resources.ContratosResource))]
        public byte[] IdRedMiwi { get; set; }
        [Display(Name = "LabelEstadoContrato", ResourceType = typeof(Resources.ContratosResource))]
        public int IdEstadoContrato { get; set; }
        [Display(Name = "LabelEstadoContrato", ResourceType = typeof(Resources.ContratosResource))]
        public string EstadoContrato { get; set; }
        [Display(Name = "LabelUbicacionGeografica", ResourceType = typeof(Resources.ContratosResource))]
        public System.Data.Entity.Spatial.DbGeography UbicacionGeografica { get; set; }

    }
}