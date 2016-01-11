using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Seguricel3.Models;
using System.Text;
using System.Net.Mail;
using System.Net.Mime;

using System.Globalization;

using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

using Newtonsoft.Json;
using System.Web.Security;
using Seguricel3.Helpers;

using System.Data.Entity.Validation;

using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Imaging;

namespace Seguricel3.Controllers
{
    public class CaptchaResult : ActionResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            //context.HttpContext.Response.Write("something");

            context.HttpContext.Session["CaptchaImageText"] = ClasesVarias.Generar_Clave();
            // Create a CAPTCHA image using the text stored in the Session object.
            RandomImage ci = new RandomImage(context.HttpContext.Session
                ["CaptchaImageText"].ToString(), 300, 75);
            // Change the response headers to output a JPEG image.
            context.HttpContext.Response.Clear();
            context.HttpContext.Response.ContentType = "image/jpeg";
            // Write the image to the response stream in JPEG format.
            ci.Image.Save(context.HttpContext.Response.OutputStream, ImageFormat.Jpeg);
            // Dispose of the CAPTCHA image object.
            ci.Dispose();

        }

        private string GenerateRandomCode()
        {
            Random r = new Random();
            string s = "";
            for (int j = 0; j < 5; j++)
            {
                int i = r.Next(3);
                int ch;
                switch (i)
                {
                    case 1:
                        ch = r.Next(0, 9);
                        s = s + ch.ToString();
                        break;
                    case 2:
                        ch = r.Next(65, 90);
                        s = s + Convert.ToChar(ch).ToString();
                        break;
                    case 3:
                        ch = r.Next(97, 122);
                        s = s + Convert.ToChar(ch).ToString();
                        break;
                    default:
                        ch = r.Next(97, 122);
                        s = s + Convert.ToChar(ch).ToString();
                        break;
                }
                r.NextDouble();
                r.Next(100, 1999);
            }
            return s;
        }

    }
}