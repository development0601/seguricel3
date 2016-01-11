using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Seguricel3.Models
{
    public class FirmwaresViewModel
    {
        public bool showFirmware { get; set; }

        public List<FirmwareViewModel> Firmwares { get; set; }

        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ErrorMessageResource))]
        [Display(Name = "labelTipoDispositivo", ResourceType = typeof(Resources.FirmResource))]
        public IEnumerable<SelectListItem> TipoDispositivo { get; set; }
        
        [Display(Name = "labelId", ResourceType = typeof(Resources.FirmResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int IdTipoDispositivo { get; set; }
    }

    public class FirmwareViewModel
    {
        [Display(Name = "labelFirmware_IdFirmware", ResourceType = typeof(Resources.FirmResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public Guid Id { get; set; }

        [Display(Name = "labelVersionFirmware", ResourceType = typeof(Resources.FirmResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "StringLengthErrorMessage")]
        public string Version { get; set; }
        
        [Display(Name = "labelDescripcionFirmware", ResourceType = typeof(Resources.FirmResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        [StringLength(500, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "StringLengthErrorMessage")]
        public string Descripcion { get; set; }
        
        [Display(Name = "labelFirmware_Firmware", ResourceType = typeof(Resources.FirmResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public byte[] Firmware { get; set; }

        
        [Display(Name = "labelFirmware_FechaPublicacion", ResourceType = typeof(Resources.FirmResource))]
        public DateTime? FechaPubilcacion { get; set; }

        
        [Display(Name = "labelId", ResourceType = typeof(Resources.FirmResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int IdTipoDispositivo { get; set; }
        
    }
}