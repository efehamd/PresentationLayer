using DAL;
using Entity;
using Microsoft.Data.SqlClient;

namespace LoginPage.DAL
{
    public class UserDAL : ConnString
    {

        public UserDAL()
        {
        }

        public bool ConfirmUser(Kullanici kullanici)
        {
            bool dogrulandi = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "SELECT COUNT(*) FROM Personeller WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@KullaniciAdi", kullanici.KullaniciAdi);
                command.Parameters.AddWithValue("@Sifre", kullanici.Sifre);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                if (count > 0)
                {
                    dogrulandi = true;
                }
            }
            return dogrulandi;
        }
        public bool CheckName(Kullanici kullanici)
        {
            bool dogrulandi = false;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "SELECT COUNT(*) FROM Personeller WHERE KullaniciAdi = @KullaniciAdi";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@KullaniciAdi", kullanici.KullaniciAdi);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                if (count > 0)
                {
                    dogrulandi = true;
                }
            }
            return dogrulandi;
        }

        public void AddUser(Kullanici kullanici)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "INSERT INTO Personeller (KullaniciAdi, Sifre) VALUES (@KullaniciAdi, @Sifre)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@KullaniciAdi", kullanici.KullaniciAdi);
                command.Parameters.AddWithValue("@Sifre", kullanici.Sifre);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void RemoveUser(int kullaniciId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "DELETE FROM Personeller WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", kullaniciId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void EditUser(int userId, string newUserName)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "UPDATE Personeller SET KullaniciAdi = @KullaniciAdi WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@KullaniciAdi", newUserName);
                command.Parameters.AddWithValue("@Id", userId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Kullanici> GetUsers()
        {
            List<Kullanici> users = new List<Kullanici>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "SELECT Id, KullaniciAdi FROM Personeller";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Kullanici user = new Kullanici();
                        user.Id = reader.GetInt64(0);
                        user.KullaniciAdi = reader.GetString(1);
                        users.Add(user);
                    }
                    reader.Close();  
                }
            }
            return users;
        }
    }
}
