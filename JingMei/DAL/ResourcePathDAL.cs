using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ResourcePathDAL : BaseDAL<Model.resourcePath>
    {
        /// <summary>
        /// 在这里声明实例化一个adminDAL的对象
        /// </summary>
        public static readonly ResourcePathDAL dal = new ResourcePathDAL();
        public ResourcePathDAL() { }
    }
}
