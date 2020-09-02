using ProductManagement.DataAccess.Repository;
using ProductManagement.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Extension;
using Unity;

namespace ProductManagement.Business
{
    public class UnityResolver : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IUserDataRepository, UserDataRepository>();
            Container.RegisterType<IProductDataRepository, ProductDataRepository>();
        }
    }
}
