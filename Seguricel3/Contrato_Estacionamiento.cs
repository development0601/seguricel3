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
    
    public partial class Contrato_Estacionamiento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contrato_Estacionamiento()
        {
            this.Contrato_Unidad_Vehiculo = new HashSet<Contrato_Unidad_Vehiculo>();
        }
    
        public System.Guid IdContrato { get; set; }
        public System.Guid IdEstacionamiento { get; set; }
        public string Nombre { get; set; }
        public int NroPuestoFijo { get; set; }
        public int NroPuestoVisitante { get; set; }
    
        public virtual Contrato Contrato { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Unidad_Vehiculo> Contrato_Unidad_Vehiculo { get; set; }
    }
}
