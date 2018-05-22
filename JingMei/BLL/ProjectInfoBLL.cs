using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
namespace BLL
{
    public class ProjectInfoBLL : BaseBLL<Model.projectInfo>
    {
        /// <summary>
        /// 在这里声明实例化一个UserBLL的对象
        /// </summary>
        public static readonly ProjectInfoBLL bll = new ProjectInfoBLL(); 
        /// <summary>
        /// 要对BaseBLL中的抽象方法进行实现。
        /// </summary>
        public override void SetCurrentRepository()
        {
            CurrentRepository = ProjectInfoDAL.dal;//CurrentRepository属性在BaseBLL中定义
        }
    }
}
