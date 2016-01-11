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
    
    public partial class Contrato_Dispositivo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contrato_Dispositivo()
        {
            this.Contrato_Dispositivo_Actualizacion = new HashSet<Contrato_Dispositivo_Actualizacion>();
            this.Contrato_Dispositivo_Bitacora = new HashSet<Contrato_Dispositivo_Bitacora>();
            this.Contrato_Dispositivo_Clonacion = new HashSet<Contrato_Dispositivo_Clonacion>();
            this.Contrato_Dispositivo_Clonacion1 = new HashSet<Contrato_Dispositivo_Clonacion>();
            this.Contrato_Dispositivo1 = new HashSet<Contrato_Dispositivo>();
            this.Contrato_Dispositivo11 = new HashSet<Contrato_Dispositivo>();
            this.Contrato_Dispositivo_Estadistica = new HashSet<Contrato_Dispositivo_Estadistica>();
            this.Contrato_Unidad_Bloqueo_Acceso = new HashSet<Contrato_Unidad_Bloqueo_Acceso>();
            this.Contrato_Unidad_Persona_Biometria_Trasmision = new HashSet<Contrato_Unidad_Persona_Biometria_Trasmision>();
        }
    
        public System.Guid IdContrato { get; set; }
        public System.Guid IdDispositivo { get; set; }
        public System.Guid IdAcceso { get; set; }
        public string Serial { get; set; }
        public string NroGSM { get; set; }
        public int TiempoAperturaAutomatico { get; set; }
        public Nullable<int> TiempoAperturaAutomatico2 { get; set; }
        public System.Guid IdGrupo { get; set; }
        public System.Guid IdSubGrupo { get; set; }
        public string DiasSemana { get; set; }
        public System.TimeSpan HoraInicio1 { get; set; }
        public System.TimeSpan HoraInicio2 { get; set; }
        public System.TimeSpan HoraFinal1 { get; set; }
        public System.TimeSpan HoraFinal2 { get; set; }
        public System.Guid IdFirmwareActivo { get; set; }
        public int IdTipoDispositivo { get; set; }
        public bool Privilegio { get; set; }
        public Nullable<System.Guid> IdDispositivoPadre { get; set; }
        public bool Visible { get; set; }
        public Nullable<System.Guid> IdDispositivoSMS { get; set; }
        public string IdTipoApertura { get; set; }
        public string IdTipoApertura2 { get; set; }
        public string IdentificadorBajoNivel { get; set; }
        public string IdentificadorBajoNivel2 { get; set; }
        public string IdentificadorBajoNivel3 { get; set; }
        public Nullable<bool> ActivadorAcceso { get; set; }
        public Nullable<bool> ActivadorAcceso2 { get; set; }
        public Nullable<bool> ActivadorAcceso3 { get; set; }
        public Nullable<bool> EmisorSMS { get; set; }
        public Nullable<bool> DispositivoEncolador { get; set; }
        public Nullable<System.Guid> IdOperadora { get; set; }
        public System.DateTime FechaUltimaActualizacion { get; set; }
    
        public virtual Contrato Contrato { get; set; }
        public virtual Contrato_Acceso Contrato_Acceso { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Dispositivo_Actualizacion> Contrato_Dispositivo_Actualizacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Dispositivo_Bitacora> Contrato_Dispositivo_Bitacora { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Dispositivo_Clonacion> Contrato_Dispositivo_Clonacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Dispositivo_Clonacion> Contrato_Dispositivo_Clonacion1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Dispositivo> Contrato_Dispositivo1 { get; set; }
        public virtual Contrato_Dispositivo Contrato_Dispositivo2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Dispositivo> Contrato_Dispositivo11 { get; set; }
        public virtual Contrato_Dispositivo Contrato_Dispositivo3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Dispositivo_Estadistica> Contrato_Dispositivo_Estadistica { get; set; }
        public virtual Firmware Firmware { get; set; }
        public virtual Grupo Grupo { get; set; }
        public virtual Operadora Operadora { get; set; }
        public virtual SubGrupo SubGrupo { get; set; }
        public virtual TipoDispositivo TipoDispositivo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Unidad_Bloqueo_Acceso> Contrato_Unidad_Bloqueo_Acceso { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato_Unidad_Persona_Biometria_Trasmision> Contrato_Unidad_Persona_Biometria_Trasmision { get; set; }
    }
}