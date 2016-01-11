using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Seguricel3.Models
{

    public class AdministradorasViewModel
    {
        public int IdPais { get; set; }
        public IEnumerable<SelectListItem> Paises { get; set; }
        public bool showAdministradoras { get; set; }
        public List<AdministradoraViewModel> Administradoras { get; set; }
    }
    public class AdministradoraViewModel
    {
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [Display(Name = "labelPais", ResourceType = typeof(Resources.AdministradorasResources))]
        public int IdPais { get; set; }
        public Guid Id { get; set; }
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [Display(Name = "labelNombre", ResourceType = typeof(Resources.AdministradorasResources))]
        [StringLength(500, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "StringLengthErrorMessage")]
        public string Nombre { get; set; }
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [Display(Name = "labelRIF", ResourceType = typeof(Resources.AdministradorasResources))]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "StringLengthErrorMessage")]
        public string Rif { get; set; }
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [Display(Name = "labelDireccion", ResourceType = typeof(Resources.AdministradorasResources))]
        public string Direccion { get; set; }
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [Display(Name = "labelEstado", ResourceType = typeof(Resources.AdministradorasResources))]
        public int IdEstado { get; set; }
        public IEnumerable<SelectListItem> EstadosDisponibles { get; set; }
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [Display(Name = "labelCiudad", ResourceType = typeof(Resources.AdministradorasResources))]
        public int IdCiudad { get; set; }
        public IEnumerable<SelectListItem> Ciudades { get; set; }
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [Display(Name = "labelCodigoPostal", ResourceType = typeof(Resources.AdministradorasResources))]
        [Range(1, 9999, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RangeErrorMessage")]
        public string CodigoPostal { get; set; }
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [Display(Name = "labelNombreContacto", ResourceType = typeof(Resources.AdministradorasResources))]
        [StringLength(500, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "StringLengthErrorMessage")]
        public string NombreContacto { get; set; }
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [Display(Name = "labelTelefonoOficina", ResourceType = typeof(Resources.AdministradorasResources))]
        [DataType(DataType.PhoneNumber, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "PhoneNumberMessage")]
        public string TelefonoOficina { get; set; }
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [Display(Name = "labelTelefonoCelular", ResourceType = typeof(Resources.AdministradorasResources))]
        [DataType(DataType.PhoneNumber, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "PhoneNumberMessage")]
        public string TelefonoCelular1 { get; set; }
        [Display(Name = "labelTelefonoCelular2", ResourceType = typeof(Resources.AdministradorasResources))]
        [DataType(DataType.PhoneNumber, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "PhoneNumberMessage")]
        public string TelefonoCelular2 { get; set; }
        [Display(Name = "labelTelefonoFax", ResourceType = typeof(Resources.AdministradorasResources))]
        [DataType(DataType.PhoneNumber, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "PhoneNumberMessage")]
        public string TelefonoFax { get; set; }
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [Display(Name = "labelEmailAdministradora", ResourceType = typeof(Resources.AdministradorasResources))]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "EmailAddressErrorMessage")]
        public string CorreoAdministradora { get; set; }
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [Display(Name = "labelEmailContacto", ResourceType = typeof(Resources.AdministradorasResources))]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "EmailAddressErrorMessage")]
        public string CorreoContacto { get; set; }
    }
}
