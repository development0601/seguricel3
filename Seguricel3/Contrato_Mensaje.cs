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
    
    public partial class Contrato_Mensaje
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contrato_Mensaje()
        {
            this.Contrato_Mensaje_Anexo = new HashSet<Contrato_Mensaje_Anexo>();
            this.Contrato_Mensaje_Destinatario = new HashSet<Contrato_Mensaje_Destinatario>();
        }
    
        public System.Guid IdContrato { get; set; }
        public System.Guid IdMensaje { get; set; }
        public System.Guid IdUnidadOrigen { get; set; }
        public string Asunto { get; set; }
        public string Mensaje { get; set; }
        public System.DateTime FechaEnvio { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public int IdBandeja { get; set; }
        public int IdTipoMensaje { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Mensaje_Anexo> Contrato_Mensaje_Anexo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Mensaje_Destinatario> Contrato_Mensaje_Destinatario { get; set; }
        public virtual Contrato Contrato { get; set; }
        public virtual Contrato_Unidad Contrato_Unidad { get; set; }
    }
}
