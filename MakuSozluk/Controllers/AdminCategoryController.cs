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

namespace MakuSozluk.Controllers
{
    public class AdminCategoryController : Controller
    {
        // Kategori işlemleri için CategoryManager sınıfını kullanıyoruz
        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        // Kategori listesini döndüren Index metodu
        public IActionResult Index()
        {
            var categoryValues = cm.GetList();
            return View(categoryValues);
        }

        // Yeni kategori ekleme sayfasını döndüren ve HTTP GET isteğine yanıt veren AddCategory metodu
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        // Yeni kategori ekleme işlemini gerçekleştiren ve HTTP POST isteğine yanıt veren AddCategory metodu
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(p);

            if (result.IsValid)
            {
                cm.CategoryAdd(p);  // Kategori ekleme işlemi
                return RedirectToAction("Index"); // Index sayfasına yönlendirme
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage); // Hata mesajlarını ModelState'e ekleme
                }
            }

            return View();
        }

        // Belirli bir kategoriyi silen DeleteCategory metodu
        public ActionResult DeleteCategory(int id)
        {
            var categoryValue = cm.GetByID(id);
            cm.CategoryDelete(categoryValue); // Kategori silme işlemi
            return RedirectToAction("Index"); // Index sayfasına yönlendirme
        }

        // Kategori düzenleme sayfasını döndüren ve HTTP GET isteğine yanıt veren EditCategory metodu
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryValue = cm.GetByID(id);
            return View(categoryValue);
        }

        // Kategori düzenleme işlemini gerçekleştiren ve HTTP POST isteğine yanıt veren EditCategory metodu
        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            cm.CategoryUpdate(p); // Kategori güncelleme işlemi
            return RedirectToAction("Index"); // Index sayfasına yönlendirme
        }
    }
}
