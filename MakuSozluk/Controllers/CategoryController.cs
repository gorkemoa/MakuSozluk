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
    public class CategoryController : Controller
    {
        // Kategori işlemleri için CategoryManager sınıfını kullanıyoruz
        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        // Kategori listesini göstermek için Index sayfasını döndüren metot
        public IActionResult Index()
        {
            return View();
        }

        // Kategori listesini alıp GetCategoryList view'ına aktaran metot
        public IActionResult GetCategoryList()
        {
            var categoryValues = cm.GetList();  // Tüm kategorileri veritabanından al
            return View(categoryValues);  // Kategori listesini GetCategoryList.cshtml view'ına gönder
        }

        // Yeni kategori ekleme formunu göstermek için HTTP GET metodu
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();  // Yeni kategori ekleme formunu döndür
        }

        // Yeni kategori eklemek için HTTP POST metodu
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();  // Kategori doğrulama kurallarını tanımlayan validator
            ValidationResult result = categoryValidator.Validate(p);  // Kategori modelini doğrula

            if (result.IsValid)
            {
                cm.CategoryAdd(p);  // Kategori ekleme işlemi
                return RedirectToAction("GetCategoryList");  // Kategori ekleme işlemi başarılıysa, kategori listesini gösteren sayfaya yönlendir
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);  // Hata mesajlarını ModelState'e ekle
                }
            }

            return View();  // Hata durumunda tekrar kategori ekleme sayfasını göster
        }
    }
}
