using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace Seguricel3
{

    #region Enumeradores
    /// <summary>
    /// Tipos de vista para el correo electrónico
    /// </summary>
    public enum TipoVistaEmail
    {
        HTML,
        PLAIN,
        RICH_TEXT,
        XML
    }
    /// <summary>
    /// Prioridades de entrega para el correo electrónico
    /// </summary>
    public enum PrioridadEntrega
    {
        NORMAL,
        BAJA,
        ALTA
    }
    /// <summary>
    /// Indicador de acuse de recibo para el correo electrónico
    /// </summary>
    public enum TieneAcuseRecibo {
        SI,
        NO
    }

    #endregion

    public class SendEmail
    {

        #region Propiedades
        public string _De { get; set; }
        public string _NombreDe { get; set; }
        public List<string> _Para { get; set; }
        public List<string> NombreCC { get; set; }
        public List<string> ConCopia { get; set; }
        public List<string> ConCopiaOculta { get; set; }
        public string _Asunto { get; set; }
        public List<string> RutaArchivosAdjuntos { get; set; }
        public string CuerpoEmail { get; set; }
        public StringBuilder CuerpoEmail_2 { get; set; }
        public AlternateView TipoDeVista { get; set; }
        public LinkedResource IMG { get; set; }
        public bool TipoVistaEscogida { get; set; }
        public string ServidorSMTP { get; set; }
        public string _Prioridad { get; set; }
        public bool AcuseRecibo { get; set; }
        public string _EmailRespuesta { get; set; }
        public string Puerto { get; set; }
        public bool EnableSsl { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        #endregion
        public SendEmail()
        {
            this.AcuseRecibo = false;
            this.ConCopia = new List<string>();
            this.ConCopiaOculta = new List<string>();
            this.CuerpoEmail = string.Empty;
            this.CuerpoEmail_2 = new StringBuilder();
            this.EnableSsl = true;
            this.Login = string.Empty;
            this.NombreCC = new List<string>();
            this.Password = string.Empty;
            this.Puerto = string.Empty;
            this.RutaArchivosAdjuntos = new List<string>();
            this.ServidorSMTP = string.Empty;
            this.TipoVistaEscogida = false;
            this.UseDefaultCredentials = false;
            this._Asunto = string.Empty;
            this._De = string.Empty;
            this._EmailRespuesta = string.Empty;
            this._NombreDe = string.Empty;
            this._Para = new List<string>();
            this._Prioridad = string.Empty;
        }
        /// <summary>
        /// Función para limpiar los valores que se usan con el envio de correos
        /// </summary>
        /// <param name="Errores"></param>
        /// <remarks></remarks>
        public void LimpiaValoresEmail()
        {
            try {
                _De = "";
                _NombreDe = "";
                if (_Para.Count > 0)
                    _Para.Clear();
                if (NombreCC.Count > 0)
                    NombreCC.Clear();
                if (ConCopia.Count > 0)
                    ConCopia.Clear();
                if (ConCopiaOculta.Count > 0)
                    ConCopiaOculta.Clear();
                _Asunto = "";
                if (RutaArchivosAdjuntos.Count > 0)
                    RutaArchivosAdjuntos.Clear();
                CuerpoEmail = "";
                if (CuerpoEmail_2.Length > 0)
                    CuerpoEmail_2.Clear();
                ServidorSMTP = "";
                _Prioridad = "";
                _EmailRespuesta = "";
                Puerto = "";
                Login = "";
                Password = "";
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        /// <summary>
        /// Agrega el remitente al cuerpo del correo
        /// </summary>
        /// <param name="Remitente">Dirección de email de quien remite la el email</param>
        public void DE(string EmailRemitente)
        {
            _De = EmailRemitente;
        }
        public void DE(string EmailRemitente, string NombreRemitente) {
            _De = EmailRemitente;
            _NombreDe = NombreRemitente;
        }
        /// <summary>
        /// función para agregar los destinatarios del email
        /// </summary>
        /// <param name="EmailDestinatario">Dirección de email del destinatario</param>
        public void PARA(string EmailDestinatario) {
            if (EmailDestinatario != "") {
                _Para.Add(EmailDestinatario);
            }
        }
        /// <summary>
        /// Función para agregar los destinatarios que recibiran una copia del email
        /// </summary>
        /// <param name="EmailDestinatarioCopia">Email de los destinatarios</param>
        public void CON_COPIA(string EmailDestinatarioCopia) {
            if (EmailDestinatarioCopia != "") {
                ConCopia.Add(EmailDestinatarioCopia);
            }
        }
        public void CON_COPIA(string EmailDestinatarioCopia, string NombreDestinatarioCopia) {
            if (EmailDestinatarioCopia != "") {
                ConCopia.Add(EmailDestinatarioCopia);
            }
            if (NombreDestinatarioCopia != "") {
                NombreCC.Add(NombreDestinatarioCopia);
            }
        }
        /// <summary>
        /// Función para agregar los destinatarios que recibiran una copia del email
        /// </summary>
        /// <param name="EmailDestinatarioCopiaOculta">Email de los destinatarios</param>
        public void CON_COPIA_OCULTA(string EmailDestinatarioCopiaOculta) {
            if (EmailDestinatarioCopiaOculta != "") {
                ConCopiaOculta.Add(EmailDestinatarioCopiaOculta);
            }
        }
        /// <summary>
        /// Función para agregasr el asunto del email
        /// </summary>
        /// <param name="AsuntoEmail">Asunto del email</param>
        public void ASUNTO(string AsuntoEmail) {
            _Asunto = AsuntoEmail;
        }
        /// <summary>
        /// Función para agregar los archivos adjuntos al email
        /// </summary>
        /// <param name="RutaCompletaArchivoAdjunto">Ruta de los archivos a adjuntar al email</param>
        public void RUTA_ARCHIVOS_ADJUNTOS(string RutaCompletaArchivoAdjunto) {
            if (RutaCompletaArchivoAdjunto != "") {
                RutaArchivosAdjuntos.Add(RutaCompletaArchivoAdjunto);
            }
        }
        /// <summary>
        /// Función para agregar el cuerpo del email
        /// </summary>
        /// <param name="CuerpoDelEmail">Cuerpo del email</param>
        public void CUERPO_EMAIL(string CuerpoDelEmail) {
            CuerpoEmail = CuerpoDelEmail;
        }
        public void CUERPO_EMAIL(StringBuilder CuerpoDelEmail) {
            CuerpoEmail_2 = CuerpoDelEmail;
        }
        public void TIPO_VISTA_EMAIL(Seguricel3.TipoVistaEmail Tipo)
        {
            try
            {
                TipoVistaEscogida = true;
                switch (Tipo)
                {
                    case TipoVistaEmail.HTML:
                        TipoDeVista = AlternateView.CreateAlternateViewFromString(CuerpoEmail, null, System.Net.Mime.MediaTypeNames.Text.Html);
                        break;
                    case TipoVistaEmail.PLAIN:
                        TipoDeVista = AlternateView.CreateAlternateViewFromString(CuerpoEmail, null, System.Net.Mime.MediaTypeNames.Text.Plain);
                        break;
                    case TipoVistaEmail.RICH_TEXT:
                        TipoDeVista = AlternateView.CreateAlternateViewFromString(CuerpoEmail, null, System.Net.Mime.MediaTypeNames.Text.RichText);
                        break;
                    case TipoVistaEmail.XML:
                        TipoDeVista = AlternateView.CreateAlternateViewFromString(CuerpoEmail, null, System.Net.Mime.MediaTypeNames.Text.Xml);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion para agregar una imagen a un email
        /// NOTA: DEBE USARSE DESPUES DE TIPO_VISTA_EMAIL, LA VARIABLE NOMBRE DEBE COINCIDIR CON LA ETIQUETA 
        /// QUE VA EN EL CUEPOR DEL MENSAJE: src="cid:NOMBRE_IMAGEN"
        /// </summary>
        /// <param name="NombreImagen"></param>
        /// <param name="Url_Imagen"></param>
        /// <param name="Errores"></param>
        public void IMAGEN_EMBEBIDA(string NombreImagen, string Url_Imagen) {
            try {
                string Final = Url_Imagen.Substring(Url_Imagen.Length - 3, 3).ToString();
                switch (Final) {
                    case "jpg":
                        IMG = new LinkedResource(Url_Imagen, System.Net.Mime.MediaTypeNames.Image.Jpeg);
                        break;
                    case "gif (":
                        IMG = new LinkedResource(Url_Imagen, System.Net.Mime.MediaTypeNames.Image.Gif);
                        break;
                };
                IMG.ContentId = NombreImagen;
                TipoDeVista.LinkedResources.Add(IMG);
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Función para agregar el nombre del servidor SMTP a usar
        /// </summary>
        /// <param name="Servidor">Servidor SMTP</param>
        public void SERVIDOR_SMTP(string Servidor) {
            ServidorSMTP = Servidor;
        }
        /// <summary>
        /// Función para marcar la prioridadd e entrega del email
        /// </summary>
        /// <param name="Prioridad"></param>
        public void PRIORIDAD_ENTREGA(PrioridadEntrega Prioridad) {
            _Prioridad = Prioridad.ToString();
        }
        /// <summary>
        /// Función para indicar si se necesita o no un acuse de recibido
        /// </summary>
        /// <param name="Acuse"></param>
        public void ACUSE_RECIBO(TieneAcuseRecibo Acuse)
        {
            switch (Acuse)
            {
                case TieneAcuseRecibo.NO:
                    AcuseRecibo = false;
                    break;
                case TieneAcuseRecibo.SI:
                    AcuseRecibo = true;
                    break;
            }
        }
        /// <summary>
        /// Aqui se especif (ica la dirección de email para las respuesta
        /// </summary>
        /// <param name="Email"></param>
        public void EMAIL_RESPUESTA(string Email) {
            _EmailRespuesta = Email;
        }
        /// <summary>
        /// Función que setea el nro del puerto a usar con este cliente SMTP
        /// </summary>
        /// <param name="NroPuerto"></param>
        /// <remarks></remarks>
        public void NRO_PUERTO(string NroPuerto) {
            Puerto = NroPuerto;
        }
        /// <summary>
        /// Función para indicar si este cliente SMTP usa o no Ssl
        /// </summary>
        /// <param name="Valor"></param>
        /// <remarks></remarks>
        public void HABILITO_Ssl(Boolean Valor) {
            EnableSsl = Valor;
        }
        /// <summary>
        /// Función para indicar si este cliente SMTP usa o no las credenciales por defecto
        /// </summary>
        /// <param name="Valor"></param>
        /// <remarks></remarks>
        public void USA_CREDENCIALES_POR_DEFECTO(Boolean Valor) {
            UseDefaultCredentials = Valor;
        }
        /// <summary>
        /// Función para indicar las credenciales de este cliente SMTP
        /// </summary>
        /// <param name="ElLogin"></param>
        /// <param name="ElPassword"></param>
        /// <remarks></remarks>
        public void CREDENCIALES(string ElLogin, string ElPassword) {
            Login = ElLogin;
            Password = ElPassword;
        }
        /// <summary>
        /// Funión que envía los emails
        /// </summary>
        /// <param name="Errores"></param>
        /// <returns></returns>
        public bool Enviar() {
            try
            {
                bool enviado = false;

                MailMessage message = new MailMessage();
                MailAddress from;

                // Se agrega el remitente
                if (_NombreDe == "")
                    from = new MailAddress(_De);
                else
                    from = new MailAddress(_De, _NombreDe);
                message.From = from;

                // Se agregan los destinatarios
                if (_Para.Count > 0)
                {
                    MailAddress too;
                    for (int cuenta = 0; cuenta < _Para.Count; cuenta++)
                    {
                        too = new MailAddress(_Para[cuenta].ToString());
                        message.To.Add(too);
                    };
                }

                // Si posee valores CC
                if (ConCopia.Count > 0)
                {
                    MailAddress cc;
                    for (int cuenta = 0; cuenta < ConCopia.Count; cuenta++)
                    {
                        if (NombreCC.Count == 0)
                            cc = new MailAddress(ConCopia[cuenta].ToString());
                        else
                            cc = new MailAddress(ConCopia[cuenta].ToString(), NombreCC[cuenta].ToString());
                        message.CC.Add(cc);
                    }
                }

                // Si posee valoers Bcc (Copia oculta)
                if (ConCopiaOculta.Count > 0)
                {
                    MailAddress bcc;
                    for (int cuenta = 0; cuenta < ConCopia.Count; cuenta++)
                    {
                        bcc = new MailAddress(ConCopiaOculta[cuenta].ToString());
                        message.Bcc.Add(bcc);
                    }
                }

                // Se le agrega el asunto
                if ((_Asunto != ""))
                {
                    message.Subject = _Asunto;
                }

                // Si posee adjuntos
                if (RutaArchivosAdjuntos.Count > 0)
                {
                    Attachment data;
                    for (int cuenta = 0; cuenta < RutaArchivosAdjuntos.Count; cuenta++)
                    {
                        data = new Attachment(RutaArchivosAdjuntos[cuenta].ToString());
                        message.Attachments.Add(data);
                    }
                }

                // El cuerpo del email
                if (CuerpoEmail != "")
                    message.Body = CuerpoEmail;
                else
                {
                    if (CuerpoEmail_2.ToString() != "")
                    {
                        message.Body = CuerpoEmail_2.ToString();
                    }
                }

                // Se le asigna el tipo de vista escogido (Por defecto es PLAIN/TEXT)
                if (TipoVistaEscogida)
                    message.AlternateViews.Add(TipoDeVista);

                // La prioridad de entrega
                switch (_Prioridad)
                {
                    case "":
                        message.Priority = MailPriority.Normal;
                        break;
                    case "ALTA":
                        message.Priority = MailPriority.High;
                        break;
                    case "BAJA":
                        message.Priority = MailPriority.Low;
                        break;
                    case "NORMAL":
                        message.Priority = MailPriority.Normal;
                        break;
                }

                //Se especif (ica el acuse de recibo
                if (AcuseRecibo)
                    message.Headers.Add("Disposition-Notification-To", _De);

                // El email de respuesta (ai aplica)
                if (_EmailRespuesta != "")
                    message.ReplyToList.Add(new MailAddress(_EmailRespuesta));

                SmtpClient client = new SmtpClient(ServidorSMTP);
                if (Puerto != "")
                    client.Port = int.Parse(Puerto);
                client.EnableSsl = EnableSsl;
                client.UseDefaultCredentials = UseDefaultCredentials;
                if (Login != "" && Password != "")
                    client.Credentials = new NetworkCredential(Login, Password);

                client.Timeout = 30000; // Tiempo en milisegundos para el timeout
                client.Send(message);
                enviado = true;
                return enviado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}