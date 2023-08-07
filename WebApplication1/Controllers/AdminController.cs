using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Sınıflar;


namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        Context c = new Context();

        // GET: Admin
        [Authorize]
        public ActionResult Index()
        {
            var deger = c.Blogs.ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult BlogSil(int id)
        {
            var b = c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

      public ActionResult BlogGetir(int id)
        {
            var blog = c.Blogs.Find(id);
            return View("BlogGetir",blog);

        }

        public ActionResult BlogGüncelle(Blog b)
        {
            var bl = c.Blogs.Find(b.ID);
            bl.Aciklama= b.Aciklama;
            bl.Baslik = b.Baslik;   
            bl.BlogImage= b.BlogImage;  
            bl.Tarih= b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");   
        }

        public ActionResult YorumListesi()
        {
            var yorum = c.Yorumlars.ToList();
            return View(yorum);
        }

        public ActionResult YorumSil(int id)
        {
            var y = c.Yorumlars.Find(id);
                c.Yorumlars.Remove(y); 
            c.SaveChanges();    
            return RedirectToAction("YorumListesi");   
        }



        public ActionResult YorumGetir(int id)
        {
            var yor = c.Yorumlars.Find(id);

            return View("YorumGetir",yor);
        }

        public ActionResult YorumGüncelle(Yorumlar y)
        {
            var yor = c.Yorumlars.Find(y.ID);
            yor.KullaniciAdi = y.KullaniciAdi;
            yor.Mail = y.Mail;  
            yor.Yorum= y.Yorum;
            c.SaveChanges();


            return RedirectToAction("YorumListesi");
        }
    }
}