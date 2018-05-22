using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class InstancesTableDAL : BaseDAL<Model.InstancesTable>
    {
        /// <summary>
        /// 在这里声明实例化一个adminDAL的对象
        /// </summary>
        public static readonly InstancesTableDAL dal = new InstancesTableDAL();
        public InstancesTableDAL() { }
    }
}
