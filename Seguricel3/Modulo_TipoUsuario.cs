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
    
    public partial class Modulo_TipoUsuario
    {
        public string Culture { get; set; }
        public long IdModulo { get; set; }
        public int IdTipoUsuario { get; set; }
        public Nullable<System.DateTime> FechaAsignacion { get; set; }
    
        public virtual Modulo Modulo { get; set; }
        public virtual TipoUsuario TipoUsuario { get; set; }
    }
}
