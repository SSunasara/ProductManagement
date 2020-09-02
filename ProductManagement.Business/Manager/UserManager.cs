using ProductManagement.Business.Manager.Interface;
using ProductManagement.DataAccess.Repository.Interface;
using ProductManagement.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Business.Manager
{
    public class UserManager : IUserManager
    {
        IUserDataRepository repository;

        public UserManager(IUserDataRepository _repository)
        {
            repository = _repository;
        }

        public bool Activate(string email)
        {
            return repository.Activate(email);
        }

        public bool CheckEmail(string email)
        {
            return repository.CheckEmail(email);
        }

        public bool CreateUser(UserViewModel user)
        {
            return repository.CreateUser(user);
        }

        public bool Edit(UserViewModel user)
        {
            return repository.Edit(user);
        }

        public UserViewModel FindById(int id)
        {
            return repository.FindById(id);
        }

        public UserViewModel Login(UserViewModel user)
        {
            return repository.Login(user);
        }
    }
}
