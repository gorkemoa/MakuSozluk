using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Concrete;

namespace MakuSozluk.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly Context _context;

        public StatisticsController(Context context)
        {
            _context = context;
        }


        public ActionResult StatisticsIndex()
        {
            // 1) Toplam Kategori Sayısı
            int toplamKategoriSayisi = _context.Categories.Count();

            // 2) "Yazılım" Kategorisine Ait Başlık Sayısı
            int yazilimKategoriBaslikSayisi = _context.Categories
                .Count(b => b.CategoryName == "Yazılım");

            // 3) Yazar Adında 'a' Harfi Geçen Yazar Sayısı
            int aHarfiGecenYazarSayisi = _context.Writers
                .Count(y => y.WriterName.Contains("a"));

            // 4) En Fazla Başlığa Sahip Kategori Adı
            var enFazlaBasligaSahipKategori = _context.Categories
                .OrderByDescending(k => k.Headings.Count)
                .Select(k => k.CategoryName)
                .FirstOrDefault();

            // 5) Durumu True Olan ve False Olan Kategoriler Arasındaki Sayısal Fark
            int aktifKategoriSayisi = _context.Categories.Count(k => k.CategoryStatus);
            int pasifKategoriSayisi = _context.Categories.Count(k => !k.CategoryStatus);
            int durumFarki = Math.Abs(aktifKategoriSayisi - pasifKategoriSayisi);

            // View'e verileri aktar
            ViewBag.ToplamKategoriSayisi = toplamKategoriSayisi;
            ViewBag.YazilimKategoriBaslikSayisi = yazilimKategoriBaslikSayisi;
            ViewBag.AHarfiGecenYazarSayisi = aHarfiGecenYazarSayisi;
            ViewBag.EnFazlaBasligaSahipKategori = enFazlaBasligaSahipKategori;
            ViewBag.AktifKategoriSayisi = aktifKategoriSayisi;
            ViewBag.PasifKategoriSayisi = pasifKategoriSayisi;
            ViewBag.DurumFarki = durumFarki;

            return View();
        }
    }
}
