using Entity;
using LoginPage.BLL;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly UserService userService;

    public HomeController()
    {
        userService = new UserService();
    }

    public IActionResult Index()
    {
        List<Kullanici> users = userService.GetUsers();
        return View(users);
    }

    [HttpPost]
    public IActionResult AddUser(Kullanici kullanici)
    {
        // Kullanıcı bilgilerini doğrudan veritabanına kaydedin
        userService.AddUser(kullanici);

        // Kayıt işleminden sonra Index action metodunu çağırarak kullanıcı listesini göster
        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public IActionResult RemoveUser(int userId)
    {
        // Kullanıcıyı veritabanından sil
        userService.RemoveUser(userId);

        // Silme işleminden sonra Index action metodunu çağırarak kullanıcı listesini göster
        return RedirectToAction("Index", "Home");
    }
    public IActionResult LoginConfirmUser(Kullanici kullanici)
    {
        // Kullanıcı veritabaninda var mi kontrol et, varsa giris yapabilir
        if (userService.ConfirmUser(kullanici)) {
            //varsa Index sayfasına gonder
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Geçersiz kullanıcı adı veya şifre.");
            return RedirectToAction("Login", "Home");
        }
    }
    public IActionResult CheckName(Kullanici kullanici)
    {
        // Ayni kullanici adinda biri veritabaninda var mi kontrol et, varsa kaydolamaz
        if (userService.CheckName(kullanici))
        {
            ModelState.AddModelError(string.Empty, "Bu isimde bir kullanici mevcut.");
            //varsa tekrar kayıt sayfasina
            return RedirectToAction("SignUp", "Home");
        }
        else
        {
            //yoksa kayit basarili,kullaniciyi ekle
            return AddUser(kullanici);
        }
    }

    [HttpPost]
    public IActionResult EditUser(int userId, string userName)
    {
        // Kullanıcı adını güncelle
        userService.EditUser(userId, userName);

        // Güncelleme işleminden sonra Index action metodunu çağırarak kullanıcı listesini göster
        return RedirectToAction("Index", "Home");
    }



    public IActionResult SignUp()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }
}
