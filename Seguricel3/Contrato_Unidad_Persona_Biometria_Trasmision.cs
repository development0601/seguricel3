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
    
    public partial class Contrato_Unidad_Persona_Biometria_Trasmision
    {
        public System.Guid IdContrato { get; set; }
        public System.Guid IdUnidad { get; set; }
        public System.Guid IdPersona { get; set; }
        public System.Guid IdPlantilla { get; set; }
        public System.Guid IdAcceso { get; set; }
        public System.Guid IdDispositivo { get; set; }
        public System.DateTime FechaTrasmision { get; set; }
        public bool Verificada { get; set; }
    
        public virtual Contrato_Dispositivo Contrato_Dispositivo { get; set; }
        public virtual Contrato_Unidad_Persona Contrato_Unidad_Persona { get; set; }
        public virtual Contrato_Unidad_Persona_Acceso Contrato_Unidad_Persona_Acceso { get; set; }
        public virtual Contrato_Unidad_Persona_Biometria Contrato_Unidad_Persona_Biometria { get; set; }
        public virtual Contrato Contrato { get; set; }
        public virtual Contrato_Unidad Contrato_Unidad { get; set; }
        public virtual Contrato_Acceso Contrato_Acceso { get; set; }
    }
}
