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
    
    public partial class Contrato_Unidad_Bloqueo_Acceso
    {
        public System.Guid IdContrato { get; set; }
        public System.Guid IdUnidad { get; set; }
        public System.Guid IdUsuarioBloqueo { get; set; }
        public System.DateTime FechaBloqueo { get; set; }
        public System.Guid IdAcceso { get; set; }
        public System.Guid IdDispositivo { get; set; }
    
        public virtual Contrato Contrato { get; set; }
        public virtual Contrato_Acceso Contrato_Acceso { get; set; }
        public virtual Contrato_Dispositivo Contrato_Dispositivo { get; set; }
        public virtual Contrato_Unidad Contrato_Unidad { get; set; }
    }
}
