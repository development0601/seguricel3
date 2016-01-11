using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguricel3
{
    public enum eEstadoUsuario
    {
        Activo = 1,
        Conectado = 2,
        Bloqueado = 3,
        Eliminado = 4,
        Inactivo = 5
    }
    public enum eTipoTabla
    {
        TipoAccion,
        TipoAnuncio,
        TipoBandeja,
        TipoCartelera,
        TipoContacto,
        TipoContrato,
        TipoDispositivo,
        TipoMensaje,
        TipoPersona,
        TipoPropuesta,
        TipoTicket,
        TipoUsuario,
        TipoVehiculo
    }

    public enum eTipoUsuario
    {
        Administrador_Sistema = 1,
        Administrador = 2,
        Cliente = 3,
        Vendedor = 4,
        Atención_Cliente = 5,
        Software = 6,
        Firmware = 7,
        Instalador = 8,
        Franquiciado = 9,
        Administradora = 10
    }

    public enum eTipoElementoMenu
    {
        Nivel1 = 1,
        Nivel2 = 2,
        Nivel3 = 3,
        Nivel4 = 4,
        Elemento = 5
    }
}
