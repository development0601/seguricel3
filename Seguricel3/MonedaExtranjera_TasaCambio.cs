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
    
    public partial class MonedaExtranjera_TasaCambio
    {
        public int IdPais { get; set; }
        public System.DateTime FechaVigencia { get; set; }
        public float TasaCambioUS_ { get; set; }
    
        public virtual Pais Pais { get; set; }
    }
}
