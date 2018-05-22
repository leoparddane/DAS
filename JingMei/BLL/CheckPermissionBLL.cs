﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
namespace BLL
{
    public class CheckPermissionBLL : BaseBLL<Model.checkPermission>
    {
        /// <summary>
        /// 在这里声明实例化一个UserBLL的对象
        /// </summary>
        public static readonly CheckPermissionBLL bll = new CheckPermissionBLL(); 
        /// <summary>
        /// 要对BaseBLL中的抽象方法进行实现。
        /// </summary>
        public override void SetCurrentRepository()
        {
            CurrentRepository = CheckPermissionDAL.dal;//CurrentRepository属性在BaseBLL中定义
        }
    }
}
