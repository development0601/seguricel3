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
    
    public partial class Franquicia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Franquicia()
        {
            this.Franquicia_Contacto = new HashSet<Franquicia_Contacto>();
        }
    
        public System.Guid IdFranquicia { get; set; }
        public string Nombre { get; set; }
        public int IdPais { get; set; }
        public int IdEstado { get; set; }
        public int IdCiudad { get; set; }
        public System.DateTime FechaFranquicia { get; set; }
        public float MontoMinimoMes { get; set; }
        public float MontoMinimoAno { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Franquicia_Contacto> Franquicia_Contacto { get; set; }
        public virtual Pais Pais { get; set; }
        public virtual Pais_Estado Pais_Estado { get; set; }
        public virtual Pais_Estado_Ciudad Pais_Estado_Ciudad { get; set; }
    }
}