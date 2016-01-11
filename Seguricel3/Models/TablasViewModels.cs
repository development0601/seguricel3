using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguricel3.Models
{
    public class TablaGeneralViewModel
    {
        [Display(Name = "labelId", ResourceType = typeof(Resources.TablasResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int Id { get; set; }
        [Display(Name = "labelNombre", ResourceType = typeof(Resources.TablasResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        [StringLength(500, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "StringLengthErrorMessage")]
        public string Nombre { get; set; }
        public eTipoTabla TipoTabla { get; set; }
    }
    public class GrupoViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "labelNombreGrupo", ResourceType = typeof(Resources.TablasResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "StringLengthErrorMessage")]
        public string Nombre { get; set; }
        [Display(Name = "labelCodigoGrupo", ResourceType = typeof(Resources.TablasResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        [StringLength(10, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "StringLengthErrorMessage")]
        public string Codigo { get; set; }
    }
    public class SubGrupoViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "labelSubGrupo_IdGrupo", ResourceType = typeof(Resources.TablasResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public Guid Grupo { get; set; }
        [Display(Name = "labelNombreSubGrupo", ResourceType = typeof(Resources.TablasResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "StringLengthErrorMessage")]
        public string Nombre { get; set; }
        [Display(Name = "labelCodigoSubGrupo", ResourceType = typeof(Resources.TablasResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        [StringLength(10, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "StringLengthErrorMessage")]
        public string Codigo { get; set; }
    }

}
