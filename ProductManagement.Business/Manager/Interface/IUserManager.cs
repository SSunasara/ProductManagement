using ProductManagement.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Business.Manager.Interface
{
    public interface IUserManager
    {
        bool CreateUser(UserViewModel user);
        UserViewModel Login(UserViewModel user);
        bool CheckEmail(string email);
        bool Activate(string email);
        bool Edit(UserViewModel user);
        UserViewModel FindById(int id);
    }
}
