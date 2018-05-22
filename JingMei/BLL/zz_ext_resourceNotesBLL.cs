using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
namespace BLL
{
    public class zz_ext_resourceNotesBLL : BaseBLL<Model.zz_ext_resoutceNotes>
    {
        /// <summary>
        /// 在这里声明实例化一个UserBLL的对象
        /// </summary>
        public static readonly zz_ext_resourceNotesBLL bll = new zz_ext_resourceNotesBLL(); 
        /// <summary>
        /// 要对BaseBLL中的抽象方法进行实现。
        /// </summary>
        public override void SetCurrentRepository()
        {
            CurrentRepository = zz_ext_resourceNotesDAL.dal;//CurrentRepository属性在BaseBLL中定义
        }
    }
}
