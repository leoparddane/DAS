using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NoticeDAL : BaseDAL<Model.notice>
    {
        /// <summary>
        /// 在这里声明实例化一个adminDAL的对象
        /// </summary>
        public static readonly NoticeDAL dal = new NoticeDAL();
        public NoticeDAL() { }
    }
}
