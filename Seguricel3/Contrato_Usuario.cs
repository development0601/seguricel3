//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Seguricel3
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contrato_Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contrato_Usuario()
        {
            this.Contrato_Cartelera = new HashSet<Contrato_Cartelera>();
            this.Contrato_Mensaje_Destinatario = new HashSet<Contrato_Mensaje_Destinatario>();
            this.Contrato_Publicacion = new HashSet<Contrato_Publicacion>();
            this.Contrato_Ronda = new HashSet<Contrato_Ronda>();
            this.Contrato_TipoArea_Evento = new HashSet<Contrato_TipoArea_Evento>();
            this.Contrato_TipoArea_Evento1 = new HashSet<Contrato_TipoArea_Evento>();
            this.Contrato_Unidad_Persona = new HashSet<Contrato_Unidad_Persona>();
            this.Contrato_Usuario_Config_Cartelera = new HashSet<Contrato_Usuario_Config_Cartelera>();
        }
    
        public System.Guid IdContrato { get; set; }
        public System.Guid IdUsuario { get; set; }
        public System.DateTime FechaRegistro { get; set; }
    
        public virtual Contrato Contrato { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Cartelera> Contrato_Cartelera { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Mensaje_Destinatario> Contrato_Mensaje_Destinatario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Publicacion> Contrato_Publicacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Ronda> Contrato_Ronda { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_TipoArea_Evento> Contrato_TipoArea_Evento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_TipoArea_Evento> Contrato_TipoArea_Evento1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Unidad_Persona> Contrato_Unidad_Persona { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Usuario_Config_Cartelera> Contrato_Usuario_Config_Cartelera { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}