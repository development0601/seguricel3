using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguricel3.Models
{
    public class DispositivoViewModels
    {
        [Display(Name = "labelSerial", ResourceType = typeof(Resources.DispositivoResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public string Serial { get; set; }

        [Display(Name = "labelTipoDispositivo", ResourceType = typeof(Resources.DispositivoResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public string TipoDispositivo { get; set; }

        [Display(Name = "labelFirmware", ResourceType = typeof(Resources.DispositivoResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public string Firmware { get; set; }
    }
}
