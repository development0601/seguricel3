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
    
    public partial class Contrato
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contrato()
        {
            this.Contrato_Acceso = new HashSet<Contrato_Acceso>();
            this.Contrato_Cartelera = new HashSet<Contrato_Cartelera>();
            this.Contrato_Cartelera_Imagen = new HashSet<Contrato_Cartelera_Imagen>();
            this.Contrato_Contacto = new HashSet<Contrato_Contacto>();
            this.Contrato_Correos_Seguricel = new HashSet<Contrato_Correos_Seguricel>();
            this.Contrato_Correos_Seguricel_Destinatarios = new HashSet<Contrato_Correos_Seguricel_Destinatarios>();
            this.Contrato_Dispositivo_Actualizacion = new HashSet<Contrato_Dispositivo_Actualizacion>();
            this.Contrato_Dispositivo_Bitacora = new HashSet<Contrato_Dispositivo_Bitacora>();
            this.Contrato_Dispositivo_Clonacion = new HashSet<Contrato_Dispositivo_Clonacion>();
            this.Contrato_Dispositivo = new HashSet<Contrato_Dispositivo>();
            this.Contrato_Dispositivo_Estadistica = new HashSet<Contrato_Dispositivo_Estadistica>();
            this.Contrato_Estacionamiento = new HashSet<Contrato_Estacionamiento>();
            this.Contrato_TipoArea_Evento = new HashSet<Contrato_TipoArea_Evento>();
            this.Contrato_Facturacion = new HashSet<Contrato_Facturacion>();
            this.Contrato_JuntaCondominio = new HashSet<Contrato_JuntaCondominio>();
            this.Contrato_Mensaje_Anexo = new HashSet<Contrato_Mensaje_Anexo>();
            this.Contrato_Mensaje = new HashSet<Contrato_Mensaje>();
            this.Contrato_Mensaje_Destinatario = new HashSet<Contrato_Mensaje_Destinatario>();
            this.Contrato_Publicacion = new HashSet<Contrato_Publicacion>();
            this.Contrato_Punto_Control = new HashSet<Contrato_Punto_Control>();
            this.Contrato_RFID = new HashSet<Contrato_RFID>();
            this.Contrato_Ronda = new HashSet<Contrato_Ronda>();
            this.Contrato_Ronda_Punto = new HashSet<Contrato_Ronda_Punto>();
            this.Contrato_Unidad_Anuncio = new HashSet<Contrato_Unidad_Anuncio>();
            this.Contrato_Unidad_Bloqueo_Acceso = new HashSet<Contrato_Unidad_Bloqueo_Acceso>();
            this.Contrato_Unidad_Factura = new HashSet<Contrato_Unidad_Factura>();
            this.Contrato_Unidad_Persona_Acceso = new HashSet<Contrato_Unidad_Persona_Acceso>();
            this.Contrato_Unidad_Persona_Acceso_Horario = new HashSet<Contrato_Unidad_Persona_Acceso_Horario>();
            this.Contrato_Unidad_Persona_AlarmaSilente_Bitacora = new HashSet<Contrato_Unidad_Persona_AlarmaSilente_Bitacora>();
            this.Contrato_Unidad_Persona_AlarmaSilente = new HashSet<Contrato_Unidad_Persona_AlarmaSilente>();
            this.Contrato_Unidad_Persona_Biometria_Trasmision = new HashSet<Contrato_Unidad_Persona_Biometria_Trasmision>();
            this.Contrato_Unidad_Persona = new HashSet<Contrato_Unidad_Persona>();
            this.Contrato_Unidad_Vehiculo = new HashSet<Contrato_Unidad_Vehiculo>();
            this.Contrato_Unidad_Visitas = new HashSet<Contrato_Unidad_Visitas>();
            this.Contrato_Usuario_Config_Cartelera = new HashSet<Contrato_Usuario_Config_Cartelera>();
            this.Contrato_Usuario = new HashSet<Contrato_Usuario>();
            this.Cotizacion = new HashSet<Cotizacion>();
            this.Ticket = new HashSet<Ticket>();
            this.Usuario_Bitacora = new HashSet<Usuario_Bitacora>();
            this.Vendedor_Movimiento = new HashSet<Vendedor_Movimiento>();
        }
    
        public System.Guid IdContrato { get; set; }
        public int IdTipoContrato { get; set; }
        public long NroContrato { get; set; }
        public string Contratante { get; set; }
        public string NombreCompleto { get; set; }
        public string Direccion { get; set; }
        public int IdPais { get; set; }
        public int IdEstado { get; set; }
        public int IdCiudad { get; set; }
        public string CodigoPostal { get; set; }
        public System.DateTime FechaContrato { get; set; }
        public string RegistroFiscal { get; set; }
        public System.Guid IdAdministradora { get; set; }
        public bool AccesoTelefonico { get; set; }
        public bool AccesoDactilar { get; set; }
        public bool Vigicel { get; set; }
        public bool AlarmaSilente { get; set; }
        public bool CondominioVirtual { get; set; }
        public bool ControlAscensores { get; set; }
        public bool EmergenciaVecinal { get; set; }
        public int MaximoSecundarios { get; set; }
        public int MaximoInvitados { get; set; }
        public bool ControlEstacionamiento { get; set; }
        public int MaximoPuestosVisitantes { get; set; }
        public int MaximoPuestosFijos { get; set; }
        public string CorreoElectronicoJunta { get; set; }
        public string CorreoElectronicoComunida { get; set; }
        public Nullable<int> PuertoPOPGeneral { get; set; }
        public Nullable<int> PuertoSMTPGeneral { get; set; }
        public string ServidorPOPGeneral { get; set; }
        public string ServidorSMTPGeneral { get; set; }
        public Nullable<int> PuertoPOPJC { get; set; }
        public Nullable<int> PuertoSMTPJC { get; set; }
        public string ServidorPOPJC { get; set; }
        public string ServidorSMTPJC { get; set; }
        public string UsuarioCorreoComunidad { get; set; }
        public string ContraseñaCorreoComunidad { get; set; }
        public string UsuarioCorreoJC { get; set; }
        public string ContraseñaCorreoJC { get; set; }
        public Nullable<int> NroRedesInstalacion { get; set; }
        public bool DetieneSMS_Emergencia { get; set; }
        public bool DetieneSMS_JC { get; set; }
        public int DiaCorte { get; set; }
        public bool AutoGestion_Aptos { get; set; }
        public byte[] ImagenEdificio { get; set; }
        public byte[] IdRedMiwi { get; set; }
        public int IdEstadoContrato { get; set; }
        public System.Data.Entity.Spatial.DbGeography UbicacionGeografica { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Acceso> Contrato_Acceso { get; set; }
        public virtual Contrato_Administradora Contrato_Administradora { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Cartelera> Contrato_Cartelera { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Cartelera_Imagen> Contrato_Cartelera_Imagen { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Contacto> Contrato_Contacto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Correos_Seguricel> Contrato_Correos_Seguricel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Correos_Seguricel_Destinatarios> Contrato_Correos_Seguricel_Destinatarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Dispositivo_Actualizacion> Contrato_Dispositivo_Actualizacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Dispositivo_Bitacora> Contrato_Dispositivo_Bitacora { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Dispositivo_Clonacion> Contrato_Dispositivo_Clonacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Dispositivo> Contrato_Dispositivo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Dispositivo_Estadistica> Contrato_Dispositivo_Estadistica { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Estacionamiento> Contrato_Estacionamiento { get; set; }
        public virtual EstadoContrato EstadoContrato { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_TipoArea_Evento> Contrato_TipoArea_Evento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Facturacion> Contrato_Facturacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_JuntaCondominio> Contrato_JuntaCondominio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Mensaje_Anexo> Contrato_Mensaje_Anexo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Mensaje> Contrato_Mensaje { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Mensaje_Destinatario> Contrato_Mensaje_Destinatario { get; set; }
        public virtual Pais Pais { get; set; }
        public virtual Pais_Estado Pais_Estado { get; set; }
        public virtual Pais_Estado_Ciudad Pais_Estado_Ciudad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Publicacion> Contrato_Publicacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Punto_Control> Contrato_Punto_Control { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_RFID> Contrato_RFID { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Ronda> Contrato_Ronda { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Ronda_Punto> Contrato_Ronda_Punto { get; set; }
        public virtual TipoContrato TipoContrato { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Unidad_Anuncio> Contrato_Unidad_Anuncio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Unidad_Bloqueo_Acceso> Contrato_Unidad_Bloqueo_Acceso { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Unidad_Factura> Contrato_Unidad_Factura { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Unidad_Persona_Acceso> Contrato_Unidad_Persona_Acceso { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Unidad_Persona_Acceso_Horario> Contrato_Unidad_Persona_Acceso_Horario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Unidad_Persona_AlarmaSilente_Bitacora> Contrato_Unidad_Persona_AlarmaSilente_Bitacora { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Unidad_Persona_AlarmaSilente> Contrato_Unidad_Persona_AlarmaSilente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Unidad_Persona_Biometria_Trasmision> Contrato_Unidad_Persona_Biometria_Trasmision { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Unidad_Persona> Contrato_Unidad_Persona { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Unidad_Vehiculo> Contrato_Unidad_Vehiculo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Unidad_Visitas> Contrato_Unidad_Visitas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Usuario_Config_Cartelera> Contrato_Usuario_Config_Cartelera { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Usuario> Contrato_Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cotizacion> Cotizacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Ticket { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario_Bitacora> Usuario_Bitacora { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vendedor_Movimiento> Vendedor_Movimiento { get; set; }
    }
}
