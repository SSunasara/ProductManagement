using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManagement.DataAccess.Repository.Interface;
using ProductManagement.DataAccess.Repository;
using ProductManagement.Business.Manager.Interface;
using ProductManagement.Business.Manager;
using ProductManagement.Controllers;
using System.Web.Mvc;
using ProductManagement.Entity.ViewModels;
using System.Web;
using Moq;

namespace ProductManagement.Tests.Controllers
{
    /// <summary>
    /// Summary description for UserControllerTest
    /// </summary>
    [TestClass]
    public class UserControllerTest
    {
        public UserControllerTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        /// <summary>
        /// Test Case To check serving Login Page
        /// </summary>
        [TestMethod]
        public void TestLoginView()
        {
            IUserDataRepository userRepository = new UserDataRepository();
            IUserManager userManager = new UserManager(userRepository);
            UserController controller = new UserController(userManager);
            ViewResult result = controller.Login() as ViewResult;
            Assert.IsTrue(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Login");
        }

        /// <summary>
        /// Check with Correct Email id and password of Activated Account
        /// </summary>
        [TestMethod]
        public void TestLogin1()
        {
            IUserDataRepository userRepository = new UserDataRepository();
            IUserManager userManager = new UserManager(userRepository);
            UserController controller = new UserController(userManager);
            UserViewModel user = new UserViewModel 
            { EmailId = "ss.sunasara786440@gmail.com", Password = "12312312" };
            var context = new Mock<ControllerContext>();
            var session = new Mock<HttpSessionStateBase>();
            context.Setup(m => m.HttpContext.Session).Returns(session.Object);
            controller.ControllerContext = context.Object;
            var result = (RedirectToRouteResult)controller.Login(user);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Product", result.RouteValues["controller"]);
        }

        /// <summary>
        /// Check with invalid Emailid and password of Activated Account
        /// </summary>
        [TestMethod]
        public void TestLogin2()
        {
            IUserDataRepository userRepository = new UserDataRepository();
            IUserManager userManager = new UserManager(userRepository);
            UserController controller = new UserController(userManager);
            UserViewModel user = new UserViewModel
            { EmailId = "ss.sunasara786440@gmail.com", Password = "12385263" };
            var context = new Mock<ControllerContext>();
            var session = new Mock<HttpSessionStateBase>();
            context.Setup(m => m.HttpContext.Session).Returns(session.Object);
            controller.ControllerContext = context.Object;
            var result = controller.Login(user) as ViewResult;
            Assert.IsTrue(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Login");
            Assert.AreEqual("Invalid Email or password", result.ViewBag.error);
        }

        /// <summary>
        /// Check with Correct Email id and password of NotActivated Account
        /// </summary>
        [TestMethod]
        public void TestLogin3()
        {
            IUserDataRepository userRepository = new UserDataRepository();
            IUserManager userManager = new UserManager(userRepository);
            UserController controller = new UserController(userManager);
            UserViewModel user = new UserViewModel
            { EmailId = "sunasara786440@gmail.com", Password = "11111111" };
            var context = new Mock<ControllerContext>();
            var session = new Mock<HttpSessionStateBase>();
            context.Setup(m => m.HttpContext.Session).Returns(session.Object);
            controller.ControllerContext = context.Object;
            var result = controller.Login(user) as ViewResult;
            Assert.IsTrue(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Login");
            Assert.AreEqual("Your Account is not Active go to your email and Activete your Account", result.ViewBag.error);
        }

        /// <summary>
        /// Check duplicate mail id for registration
        /// </summary>
        [TestMethod]
        public void TestDuplicateMail()
        {
            IUserDataRepository userRepository = new UserDataRepository();
            IUserManager userManager = new UserManager(userRepository);
            UserController controller = new UserController(userManager);
            string email = "ss.sunasara786440@gmail.com";
            var result = controller.CheckEmail(email) as JsonResult;
            Assert.IsTrue(Convert.ToBoolean(result.Data));
        }

        /// <summary>
        /// Check New mail id for registration
        /// </summary>
        [TestMethod]
        public void TestNewMail()
        {
            IUserDataRepository userRepository = new UserDataRepository();
            IUserManager userManager = new UserManager(userRepository);
            UserController controller = new UserController(userManager);
            string email = "sunasara@gmail.com";
            var result = controller.CheckEmail(email) as JsonResult;
            Assert.IsFalse(Convert.ToBoolean(result.Data));
        }


    }
}
