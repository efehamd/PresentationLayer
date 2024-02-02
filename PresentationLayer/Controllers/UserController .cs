using Entity;
using LoginPage.BLL;
using Microsoft.AspNetCore.Mvc;

namespace LoginPage.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService userService;

        public UserController()
        {
            userService = new UserService();
        }

        // Kullanıcı doğrulama işlemi için
        [HttpPost]
        public IActionResult Login([FromForm] Kullanici model)
        {

            bool dogrulandi = userService.ConfirmUser(model);
            if (dogrulandi)
            {
                // Kullanıcı doğrulandıysa, istenen sayfaya yönlendir
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Geçersiz kullanıcı adı veya şifre.");
            }

            return View("Login", model);
        }

        // Yeni kullanıcı ekleme işlemi için
        [HttpPost]
        public IActionResult YeniKullaniciEkle(Kullanici model)
        {
            if (ModelState.IsValid)
            {
                userService.AddUser(model);
                return RedirectToAction("AnaSayfa");
            }
            return View("YeniKullanici");
        }

        // Kullanıcı silme işlemi için
        [HttpPost]
        public IActionResult KullaniciSil(int kullaniciId)
        {
            userService.RemoveUser(kullaniciId);
            return RedirectToAction("AnaSayfa");
        }

        // Ana sayfa için
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
