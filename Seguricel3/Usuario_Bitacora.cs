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
    
    public partial class Usuario_Bitacora
    {
        public System.Guid IdUsuario { get; set; }
        public System.Guid IdBitacora { get; set; }
        public Nullable<System.Guid> IdContrato { get; set; }
        public string Accion { get; set; }
        public string DireccionIP_Publica { get; set; }
        public string DireccionIP_Privada { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public Nullable<long> IdModulo { get; set; }
        public string Observacion { get; set; }
    
        public virtual Contrato Contrato { get; set; }
        public virtual Modulo Modulo { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
