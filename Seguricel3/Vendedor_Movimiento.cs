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
    
    public partial class Vendedor_Movimiento
    {
        public System.Guid IdVendedor { get; set; }
        public System.Guid IdVenta { get; set; }
        public System.Guid IdContrato { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaCierre { get; set; }
        public int IdEstadoVenta { get; set; }
        public System.DateTime FechaEstadoVenta { get; set; }
        public Nullable<int> DiasPospuesta { get; set; }
        public string MotivoRechazo { get; set; }
    
        public virtual Vendedor Vendedor { get; set; }
        public virtual Contrato Contrato { get; set; }
    }
}
