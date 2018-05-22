using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
namespace BLL
{
    public class CheckPersonBLL : BaseBLL<Model.checkPerson>
    {
        /// <summary>
        /// 在这里声明实例化一个UserBLL的对象
        /// </summary>
        public static readonly CheckPersonBLL bll = new CheckPersonBLL(); 
        /// <summary>
        /// 要对BaseBLL中的抽象方法进行实现。
        /// </summary>
        public override void SetCurrentRepository()
        {
            CurrentRepository = CheckPersonDAL.dal;//CurrentRepository属性在BaseBLL中定义
        }
    }
}
