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
    
    public partial class Contrato_Mensaje_Anexo
    {
        public System.Guid IdContrato { get; set; }
        public System.Guid IdMensaje { get; set; }
        public System.Guid IdAnexo { get; set; }
        public string IdTipoArchivo { get; set; }
        public string RutaArchivo { get; set; }
    
        public virtual Contrato Contrato { get; set; }
        public virtual Contrato_Mensaje Contrato_Mensaje { get; set; }
    }
}
