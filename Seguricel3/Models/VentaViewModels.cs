using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seguricel3.Models
{

    public class CotizacionViewModel
    {

        public System.Guid IdCotizacion { get; set; }
        [Display(Name = "labelNombre", ResourceType = typeof(Resources.CotizacionResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        [StringLength(500, ErrorMessageResourceType =typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "StringLengthErrorMessage")]
        public string Nombre { get; set; }
        [Display(Name = "labelDireccion", ResourceType = typeof(Resources.CotizacionResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public string Direccion { get; set; }
        [Display(Name = "labelVendedor", ResourceType = typeof(Resources.CotizacionResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public SelectListItem IdVendedor { get; set; }
        public IEnumerable<SelectListItem> Vendedores { get; set; }

        [Display(Name = "labelPais", ResourceType = typeof(Resources.CotizacionResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int IdPais { get; set; }
        public IEnumerable<SelectListItem> PaisesDisponibles { get; set; }

        [Display(Name = "labelEstado", ResourceType = typeof(Resources.CotizacionResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int IdEstado { get; set; }
        public IEnumerable<SelectListItem> Estados { get; set; }

        [Display(Name = "labelCiudad", ResourceType = typeof(Resources.CotizacionResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int IdCiudad { get; set; }
        public IEnumerable<SelectListItem> Ciudades { get; set; }

        [Display(Name = "labelTipoPropuesta", ResourceType = typeof(Resources.CotizacionResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int IdTipoPropuesta { get; set; }
        public IEnumerable<SelectListItem> TiposPropuesta { get; set; }

        [Display(Name = "labelTipoPropuesta", ResourceType = typeof(Resources.CotizacionResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int IdEstadoPropuesta { get; set; }
        public IEnumerable<SelectListItem> EstadosPropuesta { get; set; }

        [Display(Name = "labelFechaEstadoPropuesta", ResourceType = typeof(Resources.CotizacionResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public System.DateTime FechaEstadoPropuesta { get; set; }
        [Display(Name = "labelTorres", ResourceType = typeof(Resources.CotizacionResource))]
        [Range(1, 99, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RangeErrorMessage")]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int TotalTorres { get; set; }
        [Display(Name = "labelResidencias", ResourceType = typeof(Resources.CotizacionResource))]
        [Range(1, 999, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RangeErrorMessage")]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int NroResidenciasXTorre { get; set; }
        [Display(Name = "labelTotalResidencia", ResourceType = typeof(Resources.CotizacionResource))]
        public int TotalResidencias { get; set; }
        [Display(Name = "labelLocales", ResourceType = typeof(Resources.CotizacionResource))]
        [Range(0, 999, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RangeErrorMessage")]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int NroLocalesComerciales { get; set; }
        [Display(Name = "labelDescripcionAccesoActual", ResourceType = typeof(Resources.CotizacionResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public string DescripcionAccesoActual { get; set; }
        [Display(Name = "labelAccesoTelefono", ResourceType = typeof(Resources.CotizacionResource))]
        public bool AccesoTelefonico { get; set; }
        [Display(Name = "labelAccesoBiometrico", ResourceType = typeof(Resources.CotizacionResource))]
        public bool AccesoBiometrico { get; set; }
        [Display(Name = "labelAlarmaSilente", ResourceType = typeof(Resources.CotizacionResource))]
        public bool AlarmaSilente { get; set; }
        [Display(Name = "labelAccesoRFID", ResourceType = typeof(Resources.CotizacionResource))]
        public bool AccesoRFID { get; set; }
        [Display(Name = "labelControlVigilancia", ResourceType = typeof(Resources.CotizacionResource))]
        public bool ControlVigilancia { get; set; }
        [Display(Name = "labelVigilanciaContratada", ResourceType = typeof(Resources.CotizacionResource))]
        public Nullable<bool> VigilanciaContratada { get; set; }
        [Display(Name = "labelEmpresaVigilancia", ResourceType = typeof(Resources.CotizacionResource))]
        [StringLength(500, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "StringLengthErrorMessage")]
        public string NombreEmpresaVigilancia { get; set; }

    }
    public class CotizacionAcceso
    {
        public System.Guid IdCotizacion { get; set; }
        [Display(Name = "labelAccesoTitle", ResourceType = typeof(Resources.CotizacionResource))]
        public System.Guid IdAcceso { get; set; }
        [Display(Name = "labelAccesoNombre", ResourceType = typeof(Resources.CotizacionResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "StringLengthErrorMessage")]
        public string Nombre { get; set; }
        [Display(Name = "labelAccesoTelefono", ResourceType = typeof(Resources.CotizacionResource))]
        public bool AccesoTelefonico { get; set; }
        [Display(Name = "labelAccesoBiometrico", ResourceType = typeof(Resources.CotizacionResource))]
        public bool AccesoBiometrico { get; set; }
        [Display(Name = "labelControlVigilancia", ResourceType = typeof(Resources.CotizacionResource))]
        public bool ControlVigilancia { get; set; }
        [Display(Name = "labelControlEntrada", ResourceType = typeof(Resources.CotizacionResource))]
        public bool ControlaEntrada { get; set; }
        [Display(Name = "labelControlSalida", ResourceType = typeof(Resources.CotizacionResource))]
        public bool ControlaSalida { get; set; }
    }
    public class CotizacionContacto
    {
        public System.Guid IdCotizacion { get; set; }
        [Display(Name = "labelContactoTitle", ResourceType = typeof(Resources.CotizacionResource))]
        public System.Guid IdContacto { get; set; }
        [Display(Name = "labelNombreContacto", ResourceType = typeof(Resources.CotizacionResource))]
        public string Nombre { get; set; }
        [Display(Name = "labelTelefonoContacto1", ResourceType = typeof(Resources.CotizacionResource))]
        public string TelefonoContacto1 { get; set; }
        [Display(Name = "labelTelefonoContacto2", ResourceType = typeof(Resources.CotizacionResource))]
        public string TelefonoContacto2 { get; set; }

    }
    public class CotizacionDispositivo
    {
        public System.Guid IdCotizacion { get; set; }
        [Display(Name = "labelTipoDispositivo", ResourceType = typeof(Resources.CotizacionResource))]
        public int IdTipoDispositivo { get; set; }
        [Display(Name = "labelCantidadDispositivo", ResourceType = typeof(Resources.CotizacionResource))]
        public int Cantidad { get; set; }
        [Display(Name = "labelFechaRegistro", ResourceType = typeof(Resources.CotizacionResource))]
        public System.DateTime FechaRegistro { get; set; }
    }
}