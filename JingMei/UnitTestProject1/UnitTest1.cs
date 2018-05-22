using System;
using System.Activities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WF;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var bll = new BLL.UserBLL();
            foreach (var item in bll.GetModelList())
            {
                Console.WriteLine(item.id);  
            }
        }
        [TestMethod]
        public void TestMethod2()
        {
            var bll = new BLL.UserBLL();
            foreach (var item in bll.GetModelList())
            {
                Console.WriteLine(item.id);
            }
        }
        [TestMethod]
        public void act()
        {
            //WorkflowInvoker.Invoke(new WF.projectPreparation());
        }
        [TestMethod]
        public void t()
        {
            win.Public.Notice.ReadNotice("araq");
        }

        [TestMethod]
        public void t2()
        {
            win.Public.Notice.updateNotice("araq", WF.ProjectStatusEnum.Finish);
        }

        [TestMethod]
        public void checkCode()
        {
            Service.User user = new Service.User();
            Console.WriteLine(user.check(1111, 1));
            Console.WriteLine(user.check(1111, 2));
            Console.WriteLine(user.check(1111, 3));
            Console.WriteLine(user.check(1111, 4));
            Console.WriteLine(user.check(0000, 1));
            Console.WriteLine(user.check(0000, 2));
            Console.WriteLine(user.check(0000, 3));
            Console.WriteLine(user.check(0000, 4));
        }
    }
}
