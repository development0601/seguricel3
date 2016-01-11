using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Seguricel3.Helpers
{
    public class SessionExpireFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try {
                HttpContext ctx = HttpContext.Current;

                // check if session is supported
                if (ctx.Session != null)
                {

                    // check if a new session id was generated
                    if (ctx.Session.IsNewSession)
                    {

                        // If it says it is a new session, but an existing cookie exists, then it must
                        // have timed out
                        string sessionCookie = ctx.Request.Headers["Cookie"];
                        if ((sessionCookie == null) || (sessionCookie.IndexOf("ASP.NET_SessionId") >= 0))
                        {
                            ctx.Response.Redirect("~/Home/Index");
                        }
                    }
                }
                base.OnActionExecuting(filterContext);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

    }
}
