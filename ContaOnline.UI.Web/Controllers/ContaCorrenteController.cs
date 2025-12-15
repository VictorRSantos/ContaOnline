using Microsoft.AspNetCore.Mvc;

namespace ContaOnline.UI.Web.Controllers
{
    public class ContaCorrenteController : Controller
    {
        public IActionResult Inicio()
        {
            return View();
        }
    }
}
