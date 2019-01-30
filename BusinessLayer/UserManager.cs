using DataAccessLayer.EntityFramework;
using Entities;
using Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserManager
    {
        Repository<User> repo_User = new Repository<User>();

        public User FindUser(int data)
        {
            return repo_User.Find(x => x.ID == data);
        }

        public int FindUserID(LoginVM loginVM)
        {
            User User = repo_User.Find(x => (x.Username == loginVM.Identity || x.Email== loginVM.Identity) && x.Password== loginVM.Password);
            if (User!=null)
            {
                return User.ID;
            }
            else
            {
                return 0;
            }
        }

        public int NewUser (User user)
        {
            return repo_User.Insert(user);
        }

        public User ChechUser (RegisterVM registerVM)
        {
            User user = repo_User.Find(x => x.Email== registerVM.Email || x.Username == registerVM.Username);
            User User = new User();

            if (user == null)
            {
                User.Name = registerVM.Name;
                User.Surname = registerVM.Surname;
                User.Username = registerVM.Username;
                User.Email = registerVM.Email;
                User.Password = registerVM.Password;
                User.IsOnline = true;
                return User;
            }
            else
            {
                return null;
            }
        }
    }
}
