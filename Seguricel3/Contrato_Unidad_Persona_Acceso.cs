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
    
    public partial class Contrato_Unidad_Persona_Acceso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contrato_Unidad_Persona_Acceso()
        {
            this.Contrato_Unidad_Persona_Acceso_Horario = new HashSet<Contrato_Unidad_Persona_Acceso_Horario>();
            this.Contrato_Unidad_Persona_Biometria_Trasmision = new HashSet<Contrato_Unidad_Persona_Biometria_Trasmision>();
        }
    
        public System.Guid IdContrato { get; set; }
        public System.Guid IdUnidad { get; set; }
        public System.Guid IdPersona { get; set; }
        public System.Guid IdAcceso { get; set; }
        public bool Permitido { get; set; }
        public bool AccesoTelefonico { get; set; }
        public bool AccesoBiometrico { get; set; }
        public string Telefono { get; set; }
    
        public virtual Contrato Contrato { get; set; }
        public virtual Contrato_Acceso Contrato_Acceso { get; set; }
        public virtual Contrato_Unidad Contrato_Unidad { get; set; }
        public virtual Contrato_Unidad_Persona Contrato_Unidad_Persona { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Unidad_Persona_Acceso_Horario> Contrato_Unidad_Persona_Acceso_Horario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Unidad_Persona_Biometria_Trasmision> Contrato_Unidad_Persona_Biometria_Trasmision { get; set; }
    }
}
