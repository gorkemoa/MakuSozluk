using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;




// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MakuSozluk.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());


        private readonly Context _context;

        public HeadingController(Context context)
        {
            _context = context;
        }

      

        public IActionResult Index()
        {
            var headingvalues = hm.GetList();
            // Veritabanından başlıkları ve ilişkili kategorileri içeren liste oluşturulur
            List<Heading> headings1 = _context.Headings.Include(h => h.Writer).ToList();

            List<Heading> headings = _context.Headings.Include(h => h.Category ).ToList();


            return View(headings);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }
                                                  ).ToList();

            if (valuecategory == null)
            {
                // valuecategory null ise loglama yapabilirsiniz
                Console.WriteLine("ViewBag.vlc is null.");
            }



            List<SelectListItem> valuewriter = (from x in wm.Getlist()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurName,
                                                    Value = x.WriterID.ToString()
                                                }).ToList();


            if (valuewriter == null)
            {
                // valuecategory null ise loglama yapabilirsiniz
                Console.WriteLine("ViewBag.wlc is null.");
            }

            ViewBag.wlc = valuewriter;
            ViewBag.vlc = valuecategory;
            return View();

        }

        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Now.ToUniversalTime();
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }
                                                 ).ToList();

            if (valuecategory == null)
            {
                // valuecategory null ise loglama yapabilirsiniz
                Console.WriteLine("ViewBag.vlc is null.");
            }

            ViewBag.vlc = valuecategory;
            var headingvalue = cm.GetByID(id);
            return View(headingvalue);
        }

    }

}

