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
    
    public partial class Cotizacion_Acceso
    {
        public System.Guid IdCotizacion { get; set; }
        public System.Guid IdAcceso { get; set; }
        public string Nombre { get; set; }
        public bool AccesoTelefonico { get; set; }
        public bool AccesoBiometrico { get; set; }
        public bool ControlVigilancia { get; set; }
        public bool ControlaEntrada { get; set; }
        public bool ControlaSalida { get; set; }
    
        public virtual Cotizacion Cotizacion { get; set; }
    }
}