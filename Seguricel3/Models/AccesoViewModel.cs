using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seguricel3.Models
{
    public class AccesosViewModel
    {
        [Display(Name = "labelPais", ResourceType = typeof(Resources.TablasResource))]
        public int IdPais { get; set; }
        public IEnumerable<SelectListItem> Paises { get; set; }
        [Display(Name = "LabelContrato", ResourceType = typeof(Resources.ContratoAccesoResource))]
        public Guid IdContrato { get; set; }
        public IEnumerable<SelectListItem> Contratos { get; set; }
        public bool showAccesos { get; set; }
        public List<AccesoViewModel> Accesos { get; set; }
    }

    public class AccesoViewModel
    {
        public int IdPais { get; set; }
        public System.Guid IdContrato { get; set; }
        public System.Guid IdAcceso { get; set; }   
        [Display(Name = "labelNombre", ResourceType = typeof(Resources.ContratoAccesoResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        [StringLength(50, ErrorMessageResourceName = "StringLengthErrorMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        public string Nombre { get; set; }
        [Display(Name = "labelNroPersonas", ResourceType = typeof(Resources.ContratoAccesoResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int NroPersonas { get; set; }
        [Display(Name = "labelCantidadSecundarios", ResourceType = typeof(Resources.ContratoAccesoResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int CantidadSecundarios { get; set; }
        [Display(Name = "labelPlantillasPersona", ResourceType = typeof(Resources.ContratoAccesoResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int PlantillasPersona { get; set; }
        [Display(Name = "labelPlantillasEmergencia", ResourceType = typeof(Resources.ContratoAccesoResource))]
        public int PlantillasEmergencia { get; set; }
        [Display(Name = "labelEntrada", ResourceType = typeof(Resources.ContratoAccesoResource))]
        public bool Entrada { get; set; }
        [Display(Name = "labelSalida", ResourceType = typeof(Resources.ContratoAccesoResource))]
        public bool Salida { get; set; }
        [Display(Name = "labelPrincipal", ResourceType = typeof(Resources.ContratoAccesoResource))]
        public bool Principales { get; set; }
        [Display(Name = "labelSecundario", ResourceType = typeof(Resources.ContratoAccesoResource))]
        public bool Secundarios { get; set; }
        [Display(Name = "labelJuntaCondominio", ResourceType = typeof(Resources.ContratoAccesoResource))]
        public bool JuntaCondominio { get; set; }
        [Display(Name = "labelVisitante", ResourceType = typeof(Resources.ContratoAccesoResource))]
        public bool Visitante { get; set; }
        [Display(Name = "labelPersonal", ResourceType = typeof(Resources.ContratoAccesoResource))]
        public bool Personal { get; set; }
        [Display(Name = "labelPeatonal", ResourceType = typeof(Resources.ContratoAccesoResource))]
        public bool Peatonal { get; set; }
        [Display(Name = "labelVehicular", ResourceType = typeof(Resources.ContratoAccesoResource))]
        public bool Vehicular { get; set; }
        [Display(Name = "labelServicio", ResourceType = typeof(Resources.ContratoAccesoResource))]
        public bool Servicio { get; set; }
        [Display(Name = "labelRFID", ResourceType = typeof(Resources.ContratoAccesoResource))]
        public bool RFID { get; set; }
    }
}