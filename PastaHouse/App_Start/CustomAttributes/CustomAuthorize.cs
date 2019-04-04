using System.Diagnostics.Contracts;
using System.Linq;
using System.Web.Mvc;

namespace PastaHouse.App_Start.CustomAttributes
{
    // Using CustomAuthorize attribute beacause of the redirection to a different view (Login) than default AuthorizeAttribute
    public class CustomAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (SkipAuthorization(filterContext)) return;

            if (AuthorizeCore(filterContext.HttpContext))
            {
                base.OnAuthorization(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectResult("~/Login");
            }
        }

        private static bool SkipAuthorization(AuthorizationContext filterContext)
        {
            Contract.Assert(filterContext != null);

            return filterContext.ActionDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), true).Any()
                   || filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), true).Any();
        }
    }
}