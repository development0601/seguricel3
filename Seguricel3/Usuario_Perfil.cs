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
    
    public partial class Usuario_Perfil
    {
        public System.Guid IdUsuarioPerfil { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int IdTipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public string TelefonoHabitacion { get; set; }
        public string TelefonoOficina { get; set; }
        public string TelefonoCelular1 { get; set; }
        public string TelefonoCelular2 { get; set; }
        public bool Vacaciones { get; set; }
    
        public virtual Usuario Usuario { get; set; }
    }
}
