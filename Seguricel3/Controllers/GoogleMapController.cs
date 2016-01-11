using Seguricel3.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Spatial;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Seguricel3.Controllers
{
    public class GoogleMapController : BaseController
    {
        // GET: General
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public JsonResult GetCoordenadas(string name)
        {
            string result = string.Empty;

            if (name != "")
            {
                string url = "http://maps.google.com/maps/api/geocode/xml?address=" + name + "&sensor=false";
                WebRequest request = WebRequest.Create(url);
                using (WebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        DataSet dsResult = new DataSet();
                        dsResult.ReadXml(reader);
                        if (dsResult.Tables["result"] != null && dsResult.Tables["result"].Rows.Count > 0)
                        {
                            foreach (DataRow row in dsResult.Tables["result"].Rows)
                            {
                                string geometry_id = dsResult.Tables["geometry"].Select("result_id = " + row["result_id"].ToString())[0]["geometry_id"].ToString();
                                DataRow location = dsResult.Tables["location"].Select("geometry_id = " + geometry_id)[0];
                                result = string.Format("{0} {1}", location["lat"], location["lng"]);
                            }
                        }
                    }
                }
            }

            return Json(result);
        }
        [SessionExpireFilter]
        [HandleError]
        [HttpPost]
        public JsonResult GetNearPoints(string lat, string lng)
        {
            string result = string.Empty;

            var text = string.Format(CultureInfo.InvariantCulture.NumberFormat,
                                       "POINT({0} {1})", lng, lat);
            DbGeography sourcePoint = DbGeography.PointFromText(text, 4326);

            using (SeguricelEntities db = new SeguricelEntities())
            {
                var matches = db.Contrato
                    .Where(x => x.UbicacionGeografica.Distance(sourcePoint) < 15000)
                    .OrderBy(x => x.UbicacionGeografica.Distance(sourcePoint))
                    .Select(x => new
                    {
                        Edificio = x.NombreCompleto,
                        Latitud = x.UbicacionGeografica.Latitude,
                        Longitud = x.UbicacionGeografica.Longitude,
                        Distancia = x.UbicacionGeografica.Distance(sourcePoint)
                    });

                foreach (var location in matches)
                {
                    string mtoK = MetersToKms(location.Distancia).ToString();
                    result += string.Format("{0};{1};{2};{3:n1}/", location.Edificio, location.Latitud.ToString().Replace(",","."), location.Longitud.ToString().Replace(",", "."), mtoK);
                }
            }

            return Json(result);
        }
        public static double MetersToMiles(double? meters)
        {
            if (meters == null)
                return 0F;

            return meters.Value * 0.000621371192;
        }
        public static double MilesToMeters(double? miles)
        {
            if (miles == null)
                return 0;

            return miles.Value * 1609.344;
        }
        public static double MetersToKms(double? meters)
        {
            if (meters == null)
                return 0F;

            return meters.Value * 0.0001;
        }
        public static double KmsToMeters(double? kms)
        {
            if (kms == null)
                return 0;

            return kms.Value * 1000;
        }
    }
}