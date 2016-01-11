using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Resources;
using Seguricel3;
using System.Web.Mvc;
using System;

namespace Seguricel3.Models
{
    public class ContactoCondominioModel
    {

        /// <summary>
        /// Nombre de la persona contacto
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources.ContactoResource),  ErrorMessageResourceName = "NombreContactoRequiredErrorMessage")]
        [Display(Name = "NombreContactoLabel", ResourceType = typeof(Resources.ContactoResource))]
        [StringLength(maximumLength: 500, ErrorMessageResourceType = typeof(Resources.ContactoResource), ErrorMessageResourceName = "NombreStringLengthErrorMessage")]
        public string NombreContacto { get; set; }
        /// <summary>
        /// Número de teléfono local de la persona contacto
        /// </summary>
        [Display(Name = "TelefonoLocalContactoLabel", ResourceType = typeof(Resources.ContactoResource))]
        [StringLength(maximumLength: 50, ErrorMessageResourceType = typeof(Resources.ContactoResource), ErrorMessageResourceName = "TelefonoLocalStringLengthErrorMessage")]
        [Phone(ErrorMessageResourceType = typeof(Resources.ContactoResource), ErrorMessageResourceName = "TelefonoLocalPhoneErrorMessage")]
        public string TelefonoLocalContacto { get; set; }
        /// <summary>
        /// Número de teléfono movil o celular de la persona contacto
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources.ContactoResource), ErrorMessageResourceName = "TelefonoMovilRequieredErrorMessage")]
        [Display(Name = "TelefonoMovilContactoLabel", ResourceType = typeof(Resources.ContactoResource))]
        [StringLength(maximumLength: 50, ErrorMessageResourceType = typeof(Resources.ContactoResource), ErrorMessageResourceName = "TelefonoMovilStringLengthErrorMessage", MinimumLength = 10)]
        [Phone(ErrorMessageResourceType = typeof(Resources.ContactoResource), ErrorMessageResourceName = "TelefonoMovilPhoneErrorMessage")]
        public string TelefonoMovilContacto { get; set; }
        /// <summary>
        /// Correo electrónico de la persona contacto
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources.ContactoResource), ErrorMessageResourceName = "EmailContactoRequieredErrorMessage")]
        [Display(Name = "EmailContactoLabel", ResourceType = typeof(Resources.ContactoResource))]
        [StringLength(maximumLength: 500, ErrorMessageResourceType = typeof(Resources.ContactoResource), ErrorMessageResourceName = "EmailContactoStringLengthErrorMessage")]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.ContactoResource), ErrorMessageResourceName = "EmailContactoEmailErrorMessage")]

        public string EmailContacto { get; set; }
        /// <summary>
        /// Nombre de la residencia para la que se solicita información
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources.ContactoResource), ErrorMessageResourceName = "NombreResidenciaRequiredErrorMessage")]
        [Display(Name = "NombreResidenciaLabel", ResourceType = typeof(Resources.ContactoResource))]
        [StringLength(maximumLength: 500, ErrorMessageResourceType = typeof(Resources.ContactoResource), ErrorMessageResourceName = "NombreResidenciaStringLengthErrorMessage")]
        public string NombreResidencia { get; set; }
        /// <summary>
        /// Cantidad de viviendas en la residencia
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources.ContactoResource), ErrorMessageResourceName = "NroViviendasRequiredErrorMessage")]
        [Display(Name = "NroViviendasLabel", ResourceType = typeof(Resources.ContactoResource))]
        [Range(minimum: 1, maximum: 9999, ErrorMessageResourceType = typeof(Resources.ContactoResource), ErrorMessageResourceName = "NroViviendasRangeErrorMessage")]
        public int CantidadViviendas { get; set; }
        /// <summary>
        /// Nombre de la urbanización donde se encuentra la residencia
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources.ContactoResource), ErrorMessageResourceName = "NombreUrbanizacionRequiredErrorMessage")]
        [Display(Name = "NombreUrbanizacionLabel", ResourceType = typeof(Resources.ContactoResource))]
        [StringLength(maximumLength: 500, ErrorMessageResourceType = typeof(Resources.ContactoResource), ErrorMessageResourceName = "NombreUrbanizacionStringLengthErrorMessage")]
        public string NombreUrbanizacion { get; set; }
        /// <summary>
        /// Identificación del país donde se encuentra la residencia
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources.ContactoResource), ErrorMessageResourceName = "PaisRequiredErrorMessage")]
        [Display(Name = "PaisLabel", ResourceType = typeof(Resources.ContactoResource))]
        [Range(minimum: 1, maximum: long.MaxValue, ErrorMessageResourceType = typeof(Resources.ContactoResource), ErrorMessageResourceName ="PaisRangeErrorMessage" )]
        public int Pais { get; set; }
        /// <summary>
        /// Relación de países para rellenar el combo
        /// </summary>
        public IList<SelectListItem> Paises;
        /// <summary>
        /// Identificación del estado donde se encuentra la residencia
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources.ContactoResource), ErrorMessageResourceName = "EstadoRequiredErrorMessage")]
        [Display(Name = "EstadoLabel", ResourceType = typeof(Resources.ContactoResource))]
        [Range(minimum: 1, maximum: long.MaxValue, ErrorMessageResourceType = typeof(Resources.ContactoResource), ErrorMessageResourceName = "EstadoRangeErrorMessage")]
        public int Estado { get; set; }
        /// <summary>
        /// Relación de estados para rellenar el combo
        /// </summary>
        public IList<SelectListItem> Estados;
        /// <summary>
        /// Identificación de la Piso_Estado_Ciudad donde se encuentra la residencia
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources.ContactoResource), ErrorMessageResourceName = "CiudadRequiredErrorMessage")]
        [Display(Name = "CiudadLabel", ResourceType = typeof(Resources.ContactoResource))]
        [Range(minimum: 1, maximum: long.MaxValue, ErrorMessageResourceType = typeof(Resources.ContactoResource), ErrorMessageResourceName = "CiudadRangeErrorMessage")]
        public int Piso_Estado_Ciudad { get; set; }
        /// <summary>
        /// Relación de ciudades para rellenar el combo
        /// </summary>
        public IList<SelectListItem> Ciudades;
        /// <summary>
        /// Comentarios ofrecidos por la persona que solicita el contacto
        /// </summary>
        [Display(Name = "ComentarioLabel", ResourceType = typeof(Resources.ContactoResource))]
        public string Comentario { get; set; }
        /// <summary>
        /// Titulo que aparece en la página
        /// </summary>
        public string TituloPagina { get { return Resources.ContactoResource.TituloPagina; } }
        /// <summary>
        /// Subtitulo que aparece en la página
        /// </summary>
        public string SubtituloPagina { get { return Resources.ContactoResource.SubtituloPagina; } }
        /// <summary>
        /// Titulo para la dirección en Venezuela
        /// </summary>
        public string TituloDireccionVenezuela { get { return Resources.ContactoResource.DireccionVenezuelaTitulo; } }
        /// <summary>
        /// Titulo para la dirección en España
        /// </summary>
        public string TituloDireccionEspaña { get { return Resources.ContactoResource.DireccionEspañaTitulo; } }
        /// <summary>
        /// Titulo para la dirección en Miami
        /// </summary>
        public string TituloDireccionMiami { get { return Resources.ContactoResource.DireccionMiamiTitulo; } }
        /// <summary>
        /// Botón enviar etiquetas
        /// </summary>
        public string BotonEnviarLabel { get { return Resources.ContactoResource.BotonEnviarLabel; } }
        /// <summary>
        /// Botón enviar etiquetas
        /// </summary>
        public string ValidationSummaryMessage { get { return Resources.ContactoResource.ValidationSummaryMessage; } }
        /// <summary>
        /// Encabezado del panel para datos del contacto
        /// </summary>
        public string ContactoHeader { get { return Resources.ContactoResource.ContactoHeader; } }
        /// <summary>
        /// Encabezado del panel para datos de la residencia
        /// </summary>
        public string ResidenciaHeader { get { return Resources.ContactoResource.ResidenciaHeader; } }

        /// <summary>
        /// Instanciar el modelo
        /// </summary>
        public ContactoCondominioModel()
        {
            this.CantidadViviendas = 0;
            this.Piso_Estado_Ciudad = 0;
            this.EmailContacto = string.Empty;
            this.Estado = 0;
            this.NombreContacto = string.Empty;
            this.NombreResidencia = string.Empty;
            this.NombreUrbanizacion = string.Empty;
            this.Pais = 0;
            this.TelefonoLocalContacto = string.Empty;
            this.TelefonoMovilContacto = string.Empty;
            this.Paises = GetPaises();
            this.Estados = new List<SelectListItem>();
            this.Ciudades = new List<SelectListItem>();
            this.Comentario = string.Empty;
        }
        /// <summary>
        /// Obtener el nombre del país
        /// </summary>
        public string GetNombrePais
        {
            get
            {
                string Nombre = string.Empty;
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    Nombre = (from p in db.Pais
                              where p.IdPais == this.Pais
                              select p.Nombre).FirstOrDefault();
                }
                return Nombre;
            }
        }
        /// <summary>
        /// Obtener el nombre del estado
        /// </summary>
        public string GetNombreEstado
        {
            get
            {
                string Nombre = string.Empty;
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    Nombre = (from p in db.Pais_Estado
                              where p.IdPais == this.Pais && p.IdEstado == this.Estado
                              select p.Nombre).FirstOrDefault();
                }
                return Nombre;
            }
        }
        /// <summary>
        /// Obtener el nombre de la Piso_Estado_Ciudad
        /// </summary>
        public string GetNombreCiudad
        {
            get
            {
                string Nombre = string.Empty;
                using (SeguricelEntities db = new SeguricelEntities())
                {
                    Nombre = (from p in db.Pais_Estado_Ciudad
                              where p.IdPais == this.Pais && p.IdEstado == this.Estado && p.IdCiudad == this.Piso_Estado_Ciudad
                              select p.Nombre).FirstOrDefault();
                }
                return Nombre;
            }
        }
        /// <summary>
        /// Conocer como se enteró de Seguricel
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources.ContactoResource), ErrorMessageResourceName = "OpcionEnterarRequiredErrorMessage")]
        [Display(Name = "OpcionEnterarLabel", ResourceType = typeof(Resources.ContactoResource))]
        [Range(minimum: 1, maximum: 7, ErrorMessageResourceType = typeof(Resources.ContactoResource), ErrorMessageResourceName = "OpcionEnterarRangeErrorMessage")]
        public int OpcionesEnterar { get; set; }
        public string OpcionesEnterarString
        {
            get
            {
                switch (OpcionesEnterar)
                {
                    case 1:
                        return ContactoResource.OpcionEnterarOpcion1;
                    case 2:
                        return ContactoResource.OpcionEnterarOpcion2;
                    case 3:
                        return ContactoResource.OpcionEnterarOpcion3;
                    case 4:
                        return ContactoResource.OpcionEnterarOpcion4;
                    case 5:
                        return ContactoResource.OpcionEnterarOpcion5;
                    case 6:
                        return ContactoResource.OpcionEnterarOpcion6;
                    case 7:
                        return ContactoResource.OpcionEnterarOpcion7;
                    default:
                        return "Opción seleccionada no contemplada";
                }
            }
        }

        public IList<SelectListItem> ListOpcionesEnterar
        {
            get
            {
                List<SelectListItem> Opciones = new List<SelectListItem>();
                Opciones.Add(new SelectListItem() { Value = "0", Text = ContactoResource.OpcionEnterarSelectValue });
                Opciones.Add(new SelectListItem() { Value = "1", Text = ContactoResource.OpcionEnterarOpcion1 });
                Opciones.Add(new SelectListItem() { Value = "2", Text = ContactoResource.OpcionEnterarOpcion2 });
                Opciones.Add(new SelectListItem() { Value = "3", Text = ContactoResource.OpcionEnterarOpcion3 });
                Opciones.Add(new SelectListItem() { Value = "4", Text = ContactoResource.OpcionEnterarOpcion4 });
                Opciones.Add(new SelectListItem() { Value = "5", Text = ContactoResource.OpcionEnterarOpcion5 });
                Opciones.Add(new SelectListItem() { Value = "6", Text = ContactoResource.OpcionEnterarOpcion6 });
                Opciones.Add(new SelectListItem() { Value = "7", Text = ContactoResource.OpcionEnterarOpcion7 });
                return Opciones;
            }
        }
        /// <summary>
        /// Obtener los países
        /// </summary>
        private IList<SelectListItem> GetPaises()
        {
            var data = BaseDatosSQL.GetPaises().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nombre
            }).ToList();

            return data;
        }

    }
}