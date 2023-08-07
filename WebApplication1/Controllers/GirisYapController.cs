using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models.Sınıflar;

namespace WebApplication1.Controllers
{
    public class GirisYapController : Controller
    {
        Context c =new Context();
        // GET: GirisYap
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin) {
            var bilgi = c.Admins.FirstOrDefault(x=> x.Kullanici == admin.Kullanici && x.Sifre == admin.Sifre);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.Kullanici,false);
                Session["Kullanici"]=bilgi.Kullanici.ToString();
                return RedirectToAction("Index","Admin");

            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","GirisYap");
        }
    }
}