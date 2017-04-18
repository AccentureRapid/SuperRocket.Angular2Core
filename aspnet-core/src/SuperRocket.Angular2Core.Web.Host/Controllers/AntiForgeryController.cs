using SuperRocket.Angular2Core.Controllers;
using Microsoft.AspNetCore.Antiforgery;

namespace SuperRocket.Angular2Core.Web.Host.Controllers
{
    public class AntiForgeryController : Angular2CoreControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}