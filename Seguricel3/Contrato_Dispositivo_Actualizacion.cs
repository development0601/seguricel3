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
    
    public partial class Contrato_Dispositivo_Actualizacion
    {
        public System.Guid IdContrato { get; set; }
        public System.Guid IdDispositivo { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public System.Guid IdUsuario { get; set; }
        public int IdTipoAccion { get; set; }
        public string Tabla { get; set; }
        public string IdRegistro { get; set; }
        public bool Procesado { get; set; }
        public bool Descargado { get; set; }
        public System.DateTime FechaDescarga { get; set; }
        public System.DateTime FechaProcesado { get; set; }
    
        public virtual Contrato Contrato { get; set; }
        public virtual Contrato_Dispositivo Contrato_Dispositivo { get; set; }
        public virtual TipoAccion TipoAccion { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
