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
    
    public partial class Contrato_Cartelera_Imagen
    {
        public System.Guid IdContrato { get; set; }
        public System.Guid IdElemento { get; set; }
        public int IdTipoCartelera { get; set; }
        public System.Guid IdImagen { get; set; }
        public System.DateTime FechaPublicacion { get; set; }
        public byte[] Imagen { get; set; }
    
        public virtual Contrato_Cartelera Contrato_Cartelera { get; set; }
        public virtual Contrato Contrato { get; set; }
    }
}
