using AutoMapper;
using ProductManagement.Data.Database;
using ProductManagement.DataAccess.Repository.Interface;
using ProductManagement.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.DataAccess.Repository
{
    public class UserDataRepository : IUserDataRepository
    {
        private IMapper mapper;
        public UserDataRepository()
        {
            AutomapperHelper automapperHelper = new AutomapperHelper();
            mapper = automapperHelper.mapper;
        }

        public bool Activate(string email)
        {
            using (PMDBEntities db = new PMDBEntities())
            {
                UserDetail user = db.UserDetails.FirstOrDefault(u => u.EmailId == email);
                if (user.Status)
                    return false;
                user.Status = true;
                db.Entry(user).State = EntityState.Modified;
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
        }

        public bool CheckEmail(string email)
        {
            using (PMDBEntities db = new PMDBEntities())
            {
                return db.UserDetails.Any(u => u.EmailId == email);
            }
        }

        public bool CreateUser(UserViewModel user)
        {
            UserDetail userDetail = mapper.Map<UserDetail>(user);
            using (PMDBEntities db = new PMDBEntities())
            {
                db.UserDetails.Add(userDetail);
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
        }

        public bool Edit(UserViewModel user)
        {
            using(PMDBEntities db= new PMDBEntities())
            {
                UserDetail userDetail = mapper.Map<UserDetail>(user);
                db.Entry(userDetail).State = EntityState.Modified;
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
        }

        public UserViewModel FindById(int id)
        {
            using (PMDBEntities db = new PMDBEntities())
            {
                return mapper.Map<UserViewModel>(db.UserDetails.FirstOrDefault(u=>u.id == id));
            }
        }

        public UserViewModel Login(UserViewModel user)
        {
            UserViewModel result = new UserViewModel();
            using (PMDBEntities db = new PMDBEntities())
            {
                var us = db.UserDetails.FirstOrDefault(u => u.EmailId == user.EmailId && u.Password == user.Password);
                result = mapper.Map<UserViewModel>(us);
            }
            return result;
        }        
    }
}
