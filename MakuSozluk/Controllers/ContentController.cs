using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;



// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MakuSozluk.Controllers
{
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());

        private readonly Context _context;

        public ContentController(Context context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public ActionResult ContentByHeading(int id)
        {
            List<Content> contentList = _context.Contents
               .Include(c => c.Writer) // Yazarı yükle
               .Where(c => c.HeadingID == id) // Belirli başlık ID'sine sahip içerikleri filtrele
               .ToList();

            return View(contentList);
        }
    }
}

