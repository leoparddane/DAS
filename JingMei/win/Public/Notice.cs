using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace win.Public
{
    public class Notice
    {
        public static bool ReadNotice(string projectID)
        {
            bool result = false;
            var model = new BLL.NoticeBLL().GetModel(p => p.projectID == projectID);
            if (model != null)
            {
                try
                {
                    model.statu = true;
                    model.readtime = DateTime.Now;
                    new BLL.NoticeBLL().Update(model, new string[] { "id", "statu","readtime" });
                }
                catch (Exception)
                {

                }
            }
            return result;
        }
        /// <summary>
        /// 更新提示信息为已读
        /// </summary>
        /// <param name="projectID"></param>
        /// <param name="newStatu"></param>
        /// <returns></returns>
        public static bool updateNotice(string projectID,WF.ProjectStatusEnum newStatu)
        {
            bool result = false;
            var model = new BLL.NoticeBLL().GetModel(p => p.projectID == projectID);
            if(model!=null)
            {
                try
                {
                    model.statu = false;
                    model.projectStatu = (int)newStatu;
                    model.readtime = null;
                    new BLL.NoticeBLL().Update(model, new string[] { "id", "statu", "projectStatu","readtime" });
                }
                catch (Exception)
                {
                    
                }
            }

            return result;
        }
    }
}
