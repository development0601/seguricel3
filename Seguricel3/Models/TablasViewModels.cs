using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Seguricel3.Models
{
    public class TablasViewModel
    {
        [Display(Name = "labelPais", ResourceType = typeof(Resources.TablasResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int IdPais { get; set; }
        public IEnumerable<SelectListItem> Paises { get; set; }
        public bool showDatos { get; set; }
        public List<TablaGeneralViewModel> DatosTabla { get; set; }
        public eTipoTabla TipoTabla { get; set; }
    }
    public class TablaGeneralViewModel
    {
        public int IdPais { get; set; }
        [Display(Name = "labelId", ResourceType = typeof(Resources.TablasResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int Id { get; set; }
        [Display(Name = "labelNombre", ResourceType = typeof(Resources.TablasResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        [StringLength(500, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "StringLengthErrorMessage")]
        public string Nombre { get; set; }
        public eTipoTabla TipoTabla { get; set; }
    }
    public class GruposViewModel
    {
        [Display(Name = "labelPais", ResourceType = typeof(Resources.TablasResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int IdPais { get; set; }
        public IEnumerable<SelectListItem> Paises { get; set; }
        public bool showDatos { get; set; }
        public List<GrupoViewModel> DatosTabla { get; set; }
    }
    public class GrupoViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "labelNombreGrupo", ResourceType = typeof(Resources.TablasResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        [StringLength(500, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "StringLengthErrorMessage")]
        public string Nombre { get; set; }
        [Display(Name = "labelCodigoGrupo", ResourceType = typeof(Resources.TablasResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        [StringLength(10, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "StringLengthErrorMessage")]
        public string Codigo { get; set; }
        public string Culture { get; set; }
        public int IdPais { get; set; }
    }
    public class SubgruposViewModel
    {
        [Display(Name = "labelPais", ResourceType = typeof(Resources.TablasResource))]
        public int IdPais { get; set; }
        public IEnumerable<SelectListItem> Paises { get; set; }
        [Display(Name = "labelSubGrupo_IdGrupo", ResourceType = typeof(Resources.TablasResource))]
        public Guid GrupoID { get; set; }
        public IEnumerable<SelectListItem> Grupos { get; set; }
        public bool showSubGrupo { get; set; }
        public List<SubGrupoViewModel> SubGrupos { get; set; }

    }
    public class SubGrupoViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "labelSubGrupo_IdGrupo", ResourceType = typeof(Resources.TablasResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public Guid Grupo { get; set; }
        [Display(Name = "labelNombreSubGrupo", ResourceType = typeof(Resources.TablasResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        [StringLength(500, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "StringLengthErrorMessage")]
        public string Nombre { get; set; }
        [Display(Name = "labelCodigoSubGrupo", ResourceType = typeof(Resources.TablasResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        [StringLength(10, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "StringLengthErrorMessage")]
        public string Codigo { get; set; }
        public int IdPais { get; set; }
    }
    public class PaisViewModel
    {
        public int Id { get; set; }
        [Display(Name = "labelNombrePais", ResourceType = typeof(Resources.TablasResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        [StringLength(500, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "StringLengthErrorMessage")]
        public string Nombre { get; set; }
        [Display(Name = "labelActivoPais", ResourceType = typeof(Resources.TablasResource))]
        public bool Activo { get; set; }
        [Display(Name = "labelLongitud", ResourceType = typeof(Resources.TablasResource))]
        public string Longitud { get; set; }
        [Display(Name = "labelLatitud", ResourceType = typeof(Resources.TablasResource))]
        public string Latitud { get; set; }
        [Display(Name = "labelNombreCulture", ResourceType = typeof(Resources.TablasResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        [StringLength(5, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "StringLengthErrorMessage")]
        public string Culture { get; set; }

    }
    public class PaisesViewModel
    {
        [Display(Name = "labelPais", ResourceType = typeof(Resources.TablasResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int IdPais { get; set; }
        public IEnumerable<SelectListItem> Paises { get; set; }
        public bool showEstados { get; set; }
        public List<EstadoViewModel> Estados { get; set; }

    }
    public class EstadoViewModel
    {
        public int Id { get; set; }
        [Display(Name = "labelPais", ResourceType = typeof(Resources.TablasResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int IdPais { get; set; }
        [Display(Name = "labelNombreEstado", ResourceType = typeof(Resources.TablasResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        [StringLength(500, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "StringLengthErrorMessage")]
        public string Nombre { get; set; }
        [Display(Name = "labelActivoEstado", ResourceType = typeof(Resources.TablasResource))]
        public bool Activo { get; set; }
        [Display(Name = "labelLongitud", ResourceType = typeof(Resources.TablasResource))]
        public string Longitud { get; set; }
        [Display(Name = "labelLatitud", ResourceType = typeof(Resources.TablasResource))]
        public string Latitud { get; set; }
        public string PaisEstado { get; set; }
    }
    public class EstadosViewModel
    {
        [Display(Name = "labelPais", ResourceType = typeof(Resources.TablasResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int IdPais { get; set; }

        [Display(Name = "labelEstado", ResourceType = typeof(Resources.TablasResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int IdEstado { get; set; }

        public IEnumerable<SelectListItem> Paises { get; set; }

        public IEnumerable<SelectListItem> Estados { get; set; }

        public bool showCiudades { get; set; }

        public List<CiudadViewModel> Ciudades { get; set; }

    }
    public class CiudadViewModel
    {
        public int Id { get; set; }
        [Display(Name = "labelPais", ResourceType = typeof(Resources.TablasResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int IdPais { get; set; }
        [Display(Name = "labelEstado", ResourceType = typeof(Resources.TablasResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int IdEstado { get; set; }
        [Display(Name = "labelNombreCiudad", ResourceType = typeof(Resources.TablasResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        [StringLength(500, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "StringLengthErrorMessage")]
        public string Nombre { get; set; }
        [Display(Name = "labelActivoCiudad", ResourceType = typeof(Resources.TablasResource))]
        public bool Activo { get; set; }
        [Display(Name = "labelLongitud", ResourceType = typeof(Resources.TablasResource))]
        public string Longitud { get; set; }
        [Display(Name = "labelLatitud", ResourceType = typeof(Resources.TablasResource))]
        public string Latitud { get; set; }
        public string PaisEstadoCiudad { get; set; }
    }
    public class TiposContratoViewModel
    {
        public int IdPais { get; set; }
        public IEnumerable<SelectListItem> Paises { get; set; }
        public bool showTiposContrato { get; set; }
        public List<TipoContratoViewModel> TiposContrato { get; set; }

    }
    public class TipoContratoViewModel
    {
        public int Id { get; set; }
        [Display(Name = "labelPais", ResourceType = typeof(Resources.TipoContratoResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public int IdPais { get; set; }
        [Display(Name = "labelNombre", ResourceType = typeof(Resources.TipoContratoResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "StringLengthErrorMessage")]
        public string Nombre { get; set; }
        [Display(Name = "labelLetraTipoContrato", ResourceType = typeof(Resources.TipoContratoResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        [StringLength(1, ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "StringLengthErrorMessage")]
        public string Letra { get; set; }
        [Display(Name = "labelUltimoNroContrato", ResourceType = typeof(Resources.TipoContratoResource))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResource), ErrorMessageResourceName = "RequiredMessage")]
        public long UltimoNro { get; set; }
    }

}
