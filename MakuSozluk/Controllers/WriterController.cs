using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MakuSozluk.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator writervalidator = new WriterValidator();
        public IActionResult Index()
        {
            var WriterValues = wm.Getlist();
            return View(WriterValues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();

        }

        public ActionResult AddWriter(Writer p)
        {
            ValidationResult result =  writervalidator.Validate(p);
            if(result.IsValid)
            {
                wm.WriterAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        [HttpGet]
       public ActionResult EditWriter(int id)
        {
            var writervalue = wm.GetByID(id);
            return View(writervalue);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer p)
        {
            ValidationResult result = writervalidator.Validate(p);
            if (result.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
    }
}

