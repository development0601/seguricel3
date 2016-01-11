using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguricel3.Models
{
    public class UploadFileViewModel
    {
        [Display(Name = "labelUploadFile", ResourceType = typeof(Resources.EtiquetasResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public string File { get; set; }
    }
}
