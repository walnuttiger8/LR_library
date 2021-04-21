using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LR_library.Controllers
{
    public class UserController
    {
        private User user;

        public string Name { get => user.Name; set => user.Name = value; }
        public string Email { get => user.Email; set => user.Email = value; }
        public string Login { get => user.Login; set => user.Login = value; }
        public string Role { get => user.Role; set => user.Role = value; }

        public UserController(User user)
        {
            this.user = user;
        }

        public static UserController FromDb(int userId)
        {
            using (UserContainer db = new UserContainer())
            {
                var users = from u in db.UserSet
                            where u.Id == userId
                            select u;

                if (users.Any())
                {
                    return new UserController(users.First());
                }
            }
            return null;
        }

        public static UserController FromEmail(string email)
        {
            using (UserContainer db = new UserContainer())
            {
                var users = from u in db.UserSet
                            where u.Email == email
                            select u;

                if (users.Any())
                {
                    return new UserController(users.First());
                }
            }
            return null;
        }

        public static UserController FromLogin(string login)
        {
            using (UserContainer db = new UserContainer())
            {
                var users = from u in db.UserSet
                            where u.Login == login
                            select u;

                if (users.Any())
                {
                    return new UserController(users.First());
                }
            }
            return null;
        }

        public void Delete()
        {
            using(UserContainer db = new UserContainer())
            {
                db.Entry(user).State = System.Data.Entity.EntityState.Deleted;
                db.UserSet.Remove(user);
                db.SaveChanges();
            }
        }

        public UserCode SetUserCode(string code)
        {
            UserCode userCode = new UserCode() { Code = code, Timestamp = DateTime.UtcNow};
            if (user.UserCode == null)
            {
                using (UserContainer db = new UserContainer())
                {
                    user.UserCode = userCode;
                    db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    db.UserCodeSet.Add(userCode);
                    db.SaveChanges();
                }
                return userCode;
            }
            user.UserCode = userCode;

            using(UserContainer db = new UserContainer())
            {
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return userCode;
        }

        public UserCode SetUserCode()
        {
            Random random = new Random();
            string code = random.Next(0, 99999).ToString();
            return SetUserCode(code);
        }

        public bool CheckUserCode(string code)
        {
            UserCode userCode = user.UserCode;

            if (userCode == null)
            {
                return false;
            }

            var delta = DateTime.UtcNow - userCode.Timestamp;

            if (delta.TotalMinutes > 15.0d)
            {
                return false;
            }
            return userCode.Code == code;
        }

        private string GetHashString(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = "";
            foreach (byte b in byteHash)
            {
                hash += string.Format("{0:x2}", b);
            }
            return hash;
        }

        public void SetPassword(string password)
        {
            string passwordHash = GetHashString(password);
            user.Password = passwordHash;
        }

        public bool CheckPassword(string password)
        {
            return user.Password == GetHashString(password);
        }

        public void Modify()
        {
            using (UserContainer db = new UserContainer())
            {
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(object sender, EventArgs e) { Delete(); }
    }
}
