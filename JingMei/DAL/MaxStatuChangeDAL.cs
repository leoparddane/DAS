using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MaxStatuChangeDAL : BaseDAL<Model.maxStatuChange>
    {
        /// <summary>
        /// 在这里声明实例化一个adminDAL的对象
        /// </summary>
        public static readonly MaxStatuChangeDAL dal = new MaxStatuChangeDAL();
        public MaxStatuChangeDAL() { }
    }
}
