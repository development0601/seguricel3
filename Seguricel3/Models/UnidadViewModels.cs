using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seguricel3.Models
{
    public class UnidadesViewModel
    {
        [Display(Name = "labelPais", ResourceType = typeof(Resources.TablasResource))]
        public int IdPais { get; set; }
        public IEnumerable<SelectListItem> Paises { get; set; }
        [Display(Name = "LabelContrato", ResourceType = typeof(Resources.ContratoUnidadResource))]
        public Guid IdContrato { get; set; }
        public IEnumerable<SelectListItem> Contratos { get; set; }
        public bool showUnidades { get; set; }
        public List<UnidadViewModel> Unidades { get; set; }
    }

    public class UnidadViewModel
    {
        public int IdPais { get; set; }
        public System.Guid IdContrato { get; set; }
        public System.Guid IdUnidad { get; set; }
        [Display(Name = "labelNombre", ResourceType = typeof(Resources.ContratoUnidadResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        [StringLength(50, ErrorMessageResourceName = "StringLengthErrorMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        public string Nombre { get; set; }
        [Display(Name = "labelTorre", ResourceType = typeof(Resources.ContratoUnidadResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        [StringLength(50, ErrorMessageResourceName = "StringLengthErrorMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        public string Torre { get; set; }
        [Display(Name = "labelPiso", ResourceType = typeof(Resources.ContratoUnidadResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        [StringLength(50, ErrorMessageResourceName = "StringLengthErrorMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        public string Piso { get; set; }
        [Display(Name = "labelIdentificaciónVigilancia", ResourceType = typeof(Resources.ContratoUnidadResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public long CodigoIdentificacionVigilancia { get; set; }
        [Display(Name = "labelCodigoAutorizacion", ResourceType = typeof(Resources.ContratoUnidadResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int CodigoAutorizacion { get; set; }
        [Display(Name = "labelVacaciones", ResourceType = typeof(Resources.ContratoUnidadResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public bool Vacaciones { get; set; }
        [Display(Name = "labelActiva", ResourceType = typeof(Resources.ContratoUnidadResource))]
        public bool Activa { get; set; }
        [Display(Name = "labelUnidadMaestra", ResourceType = typeof(Resources.ContratoUnidadResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public Guid IdUnidadMaestra { get; set; }
        [Display(Name = "labelUnidadMaestra", ResourceType = typeof(Resources.ContratoUnidadResource))]
        public string UnidadMaestra { get; set; }
        public IEnumerable<SelectListItem> UnidadesContrato { get; set; }
        [Display(Name = "labelSeguridad", ResourceType = typeof(Resources.ContratoUnidadResource))]
        public bool Seguridad { get; set; }
        [Display(Name = "labelJuntaCondominio", ResourceType = typeof(Resources.ContratoUnidadResource))]
        public bool JuntaCondominio { get; set; }
        [Display(Name = "labelNroSecundarios", ResourceType = typeof(Resources.ContratoUnidadResource))]
        public bool AceptaSecundarios { get; set; }
        [Display(Name = "labelInvitados", ResourceType = typeof(Resources.ContratoUnidadResource))]
        public bool AceptaInvitados { get; set; }
        [Display(Name = "labelImagen", ResourceType = typeof(Resources.ContratoUnidadResource))]
        public byte[] Imagen { get; set; }

    }
}