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
    
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            this.Contrato_Dispositivo_Actualizacion = new HashSet<Contrato_Dispositivo_Actualizacion>();
            this.Contrato_Ronda = new HashSet<Contrato_Ronda>();
            this.Contrato_Unidad_Persona = new HashSet<Contrato_Unidad_Persona>();
            this.Contrato_Usuario = new HashSet<Contrato_Usuario>();
            this.Ticket = new HashSet<Ticket>();
            this.TicketSeguimiento = new HashSet<TicketSeguimiento>();
            this.Usuario_Bitacora = new HashSet<Usuario_Bitacora>();
            this.Vendedor = new HashSet<Vendedor>();
        }
    
        public System.Guid IdUsuario { get; set; }
        public string Email { get; set; }
        public string ClaveUsuario { get; set; }
        public int IdEstadoUsuario { get; set; }
        public System.DateTime FechaCambioEstatus { get; set; }
        public System.DateTime FechaUltimaConexion { get; set; }
        public string Nombre { get; set; }
        public int IdTipoUsuario { get; set; }
        public string CodigoUsuario { get; set; }
        public bool PrimeraVez { get; set; }
        public string Pregunta1 { get; set; }
        public string Respuesta1 { get; set; }
        public string Pregunta2 { get; set; }
        public string Respuesta2 { get; set; }
        public string Pregunta3 { get; set; }
        public string Respuesta3 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Dispositivo_Actualizacion> Contrato_Dispositivo_Actualizacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Ronda> Contrato_Ronda { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Unidad_Persona> Contrato_Unidad_Persona { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Usuario> Contrato_Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Ticket { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TicketSeguimiento> TicketSeguimiento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario_Bitacora> Usuario_Bitacora { get; set; }
        public virtual Usuario_Perfil Usuario_Perfil { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vendedor> Vendedor { get; set; }
    }
}
