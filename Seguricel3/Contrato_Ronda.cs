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
    
    public partial class Contrato_Ronda
    {
        public System.Guid IdContrato { get; set; }
        public System.Guid IdRonda { get; set; }
        public byte Dia { get; set; }
        public System.TimeSpan HoraInicio { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public System.Guid IdUsuario { get; set; }
    
        public virtual Usuario Usuario { get; set; }
        public virtual Contrato Contrato { get; set; }
    }
}
