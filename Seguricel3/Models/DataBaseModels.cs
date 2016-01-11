using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguricel3.Models
{
    /// <summary>
    /// Información de país
    /// </summary>
    public class PaisDataModel
    {
        /// <summary>
        /// Codigo de identificación del país
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Nombre del país
        /// </summary>
        public string Nombre { get; set; }
    }
    /// <summary>
    /// Información de Estado
    /// </summary>
    public class EstadoDataModel
    {
        /// <summary>
        /// Identificación del estado
        /// </summary>
        public long Value { get; set; }
        /// <summary>
        /// Nombre del estado
        /// </summary>
        public string Text { get; set; }
    }
    /// <summary>
    /// Información de Ciudad
    /// </summary>
    public class CiudadDataModel
    {
        /// <summary>
        /// Identificación de la ciudad
        /// </summary>
        public long Value { get; set; }
        /// <summary>
        /// Nombre de la ciudad
        /// </summary>
        public string Text { get; set; }
    }

    /// <summary>
    /// Clase para la creación de Lista de Vendedor
    /// </summary>
    public class VendedorDataModel
    {
        public Guid IdVendedor { get; set; }
        public string Nombre { get; set; }
    }

}
