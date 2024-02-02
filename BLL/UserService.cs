using DAL;
using Entity;
using LoginPage.DAL;

namespace LoginPage.BLL
{
    public class UserService: ConnString
    {
        private readonly UserDAL userDAL;

        public UserService()
        {
            userDAL = new UserDAL();
        }

        public bool ConfirmUser(Kullanici kullanici)
        {
            // Kullanıcı doğrulama işlemini DAL katmanındaki metodu kullanarak gerçekleştir
            return userDAL.ConfirmUser(kullanici);
        }
        public bool CheckName(Kullanici kullanici)
        {
            // Kullanıcı adı doğrulama işlemini DAL katmanındaki metodu kullanarak gerçekleştir
            return userDAL.CheckName(kullanici);
        }

        public void AddUser(Kullanici kullanici)
        {
            // Kullanıcı ekleme işlemini DAL katmanındaki metodu kullanarak gerçekleştir
            userDAL.AddUser(kullanici);
        }
        public void EditUser(int userId, string userName)
        {
            userDAL.EditUser(userId, userName);
        }

        public void RemoveUser(int kullaniciId)
        {
            // Kullanıcı silme işlemini DAL katmanındaki metodu kullanarak gerçekleştir
            userDAL.RemoveUser(kullaniciId);
        }
        public List<Kullanici> GetUsers()
        {
            return userDAL.GetUsers();
        }
    }
}
