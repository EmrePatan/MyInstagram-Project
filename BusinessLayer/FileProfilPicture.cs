using DataAccessLayer.EntityFramework;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class FileProfilPicture
    {
            Repository<User> repo_User = new Repository<User>();

            public void SaveImage(string path)
            {
                User user = repo_User.Find(x => x.ProfilePicture == "yok");
                user.ProfilePicture = path;
                repo_User.Update(user);
            }
    }
}
