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
    
    public partial class TipoDispositivo_Comando_Sincronizador
    {
        public string Culture { get; set; }
        public int IdTipoDispositivo { get; set; }
        public int IdComando { get; set; }
        public string Comando { get; set; }
        public short OrdenEnvio { get; set; }
    
        public virtual TipoDispositivo TipoDispositivo { get; set; }
    }
}
