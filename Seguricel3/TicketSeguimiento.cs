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
    
    public partial class TicketSeguimiento
    {
        public System.Guid IdTicket { get; set; }
        public System.DateTime FechaEstadoTicket { get; set; }
        public int IdEstadoTicket { get; set; }
        public System.Guid IdUsuario { get; set; }
        public string Observacion { get; set; }
    
        public virtual Ticket Ticket { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
