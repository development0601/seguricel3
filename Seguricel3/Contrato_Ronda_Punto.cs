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
    
    public partial class Contrato_Ronda_Punto
    {
        public System.Guid IdContrato { get; set; }
        public System.Guid IdRonda { get; set; }
        public System.Guid IdPunto { get; set; }
        public byte Orden { get; set; }
        public int DistanciaMts { get; set; }
        public int TiempoMin { get; set; }
    
        public virtual Contrato_Punto_Control Contrato_Punto_Control { get; set; }
        public virtual Contrato Contrato { get; set; }
    }
}
