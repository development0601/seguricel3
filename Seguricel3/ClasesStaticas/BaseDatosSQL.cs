using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seguricel3.Models;

namespace Seguricel3
{
    /// <summary>
    /// Agrupa los métodos para obtener información de la base de datos
    /// </summary>
    public static class BaseDatosSQL
    {
        /// <summary>
        /// Obtener una lista de paises registrados en la base de datos
        /// </summary>
        public static IList<PaisDataModel> GetPaises()
        {
            List<PaisDataModel> Paises = new List<PaisDataModel>();
            using (SeguricelEntities db = new SeguricelEntities())
            {
                Paises = (from p in db.Pais
                          where p.Activo
                          select new PaisDataModel()
                          {
                              Id = p.IdPais,
                              Nombre = p.Nombre
                          }).ToList();
            }

            Paises.Insert(0, new PaisDataModel()
            {
                Id = 0,
                Nombre = "Seleccione un país..."
            });

            return Paises;

        }
        /// <summary>
        /// Obtener una lista de estados relacionados a un país
        /// </summary>
        public static IList<EstadoDataModel> GetEstados(long IdPais)
        {
            List<EstadoDataModel> Estados = new List<EstadoDataModel>();
            using (SeguricelEntities db = new SeguricelEntities())
            {
                Estados = (from e in db.Pais_Estado
                           where e.IdPais == IdPais
                           select new EstadoDataModel()
                           {
                               Value = e.IdEstado,
                               Text = e.Nombre
                           }).ToList();
            }
            Estados.Insert(0, new EstadoDataModel()
            {
                Value = 0,
                Text = "Seleccione un estado..."
            });

            return Estados;
        }
        /// <summary>
        /// Obtener una lista de ciudades relacionados a un país y estado
        /// </summary>
        public static IList<CiudadDataModel> GetCiudades(long IdPais, long IdEstado)
        {
            List<CiudadDataModel> Ciudades = new List<CiudadDataModel>();
            using (SeguricelEntities db = new SeguricelEntities())
            {
                Ciudades = (from e in db.Pais_Estado_Ciudad
                            where e.IdPais == IdPais && e.IdEstado == IdEstado
                            select new CiudadDataModel()
                            {
                                Value = e.IdCiudad,
                                Text = e.Nombre
                            }).ToList();
            }
            Ciudades.Insert(0, new CiudadDataModel()
            {
                Value = 0,
                Text = "Seleccione una Piso_Estado_Ciudad..."
            });

            return Ciudades;
        }
        /// <summary>
        /// Guardar los datos de contacto en la base de datos
        /// </summary>
        public static void GuardarContacto(ContactoCondominioModel Contacto)
        {
            using (SeguricelEntities db = new SeguricelEntities())
            {
                Contacto dataContacto = new Contacto()
                {
                    IdContacto = Guid.NewGuid(),
                    CantidadVivienda = Contacto.CantidadViviendas,
                    IdCiudad = Contacto.Piso_Estado_Ciudad,
                    Comentario = Contacto.Comentario,
                    Email = Contacto.EmailContacto,
                    IdEstado = Contacto.Estado,
                    Nombre = Contacto.NombreContacto,
                    IdPais = Contacto.Pais,
                    Residencia = Contacto.NombreResidencia,
                    TelefonoLocal = Contacto.TelefonoLocalContacto,
                    TelefonoMovil = Contacto.TelefonoMovilContacto,
                    Urbanizacion = Contacto.NombreUrbanizacion
                };

                db.Contacto.Add(dataContacto);
                db.SaveChanges();
            }
        }

    }
}
