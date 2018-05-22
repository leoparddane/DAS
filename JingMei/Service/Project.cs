using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Service
{
    public class Project : IProject
    {
        /// <summary>
        /// 加入审查信息记录表-暂不使用
        /// </summary>
        /// <param name="projectID">项目编号</param>
        /// <param name="checkPersonID">审查人用户id</param>
        /// <returns>是否添加成功</returns>
        public bool addCheckInfo(string projectID, int checkPersonID)
        {
            bool result=false;
            //根据状态获取所有需要审核的人
            //判断审核人是否具有权限
            //添加审核记录
            var model = new Model.checkResult();

            return result;
        }

        /// <summary>
        /// 添加项目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool addProject(project model)
        {
            bool result = false;
            try
            {
                var bll=new BLL.ProjectBLL();
                bll.Add(model);
                result = true;
            }
            catch (Exception)
            {
            }
            return result;
        }

        /// <summary>
        /// 获取所有的项目信息
        /// </summary>
        /// <returns></returns>
        public List<project> getAllList()
        {
            return new BLL.ProjectBLL().GetModelList();
        }

        /// <summary>
        /// 根据项目ID获取项目信息
        /// </summary>
        /// <param name="projectID">项目编号</param>
        /// <returns>当前项目状态</returns>
        public int getProjectStatu(string projectID)
        {
            var statu= new BLL.ProjectBLL().GetModel(p => p.id == projectID).currentStatuID;
            return statu;
        }
        /// <summary>
        /// 获取项目当前时间节点的名称
        /// </summary>
        /// <param name="projectID"></param>
        /// <returns></returns>
        public string getProjectStatuName(string projectID)
        {
            var statu = new BLL.ProjectBLL().GetModel(p => p.id == projectID).currentStatuID;
            var statuName = new BLL.ProjectStatusBLL().GetModel(p => p.id == statu).name;
            return statuName;
        }

        /// <summary>
        /// 更新项目状态同时加入状态变更信息
        /// </summary>
        /// <param name="projectID">项目编号</param>
        /// <param name="newStatu">新的状态</param>
        /// <returns>是否更新成功</returns>
        public bool updateProjectStatu(string projectID, int newStatu)
        {
            bool result = false;

            BLL.ProjectBLL bll = new BLL.ProjectBLL();
            var model = bll.GetModel(p => p.id == projectID);
            model.currentStatuID = newStatu;
            bll.Update(model, new string[] { "id", "currentStatuID" });
            //添加到状态变更记录中
            var changeModel = new Model.projectStatuChangeInfo();
            changeModel.projectID = projectID;
            changeModel.statu = newStatu;
            changeModel.time = DateTime.Now;
            return result;
        }

        public DataTable getUnreadMessage(WF.ProjectStatusEnum statu)
        {
            DataTable dt = new DataTable();
            var info = new BLL.NoticeBLL().GetModels(p => p.projectStatu == (int)statu && p.userID == null &&  p.statu == false);
            dt.Columns.Add("id",typeof(int));
            dt.Columns.Add("userID", typeof(int));
            dt.Columns.Add("projectID", typeof(string));
            dt.Columns.Add("projectStatu", typeof(int));
            dt.Columns.Add("statu", typeof(bool));
            dt.Columns.Add("time", typeof(DateTime));
            dt.Columns.Add("readtime", typeof(DateTime));

            foreach (var item in info)
            {
                DataRow dr = dt.NewRow();
                dr["id"] = item.id;
                dr["userID"] = item.userID;
                dr["projectID"] = item.projectID;
                dr["projectStatu"] = item.projectStatu;
                dr["statu"] = item.statu;
                dr["time"] = item.time;
                dr["readtime"] = item.readtime;

                dt.Rows.Add(dr);
            }
            return dt;
        }
        /// <summary>
        /// 判断用户是否有未读的待审核记录
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public bool hasUnreadMessage(int userid)
        {
            bool result = false;
            var notices = new List<Model.notice>();
            //获取当前用户所有的可以审核的项目状态
            var checkItems = new BLL.CheckPermissionBLL().GetModels(p => p.userID == userid);
            foreach (var item in checkItems)
            {
                //获取所有的未读消息
                var info = new BLL.NoticeBLL().GetModels(p => p.projectStatu == item.projectStatuID && p.statu == false && p.userID == null);
                notices.AddRange(info);
            }
            if (notices.Count > 0)
                result = true;
            return result;
        }

        /// <summary>
        /// 判断是否有未读的NG记录
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public bool hasNGMessage(int userID)
        {
            bool result = false;
            //获取所有的未读消息
            var info = new BLL.NoticeBLL().GetModels(p => p.statu == false && p.userID == userID);
                
            if (info.Count() > 0)
                result = true;
            return result;
        }
        /// <summary>
        /// 获取所有未读的NG记录
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataTable getNGMessage(int userID)
        {
            DataTable dt = new DataTable();
            var info = new BLL.NoticeBLL().GetModels(p => p.userID==userID && p.statu == false);
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("userID", typeof(int));
            dt.Columns.Add("projectID", typeof(string));
            dt.Columns.Add("projectStatu", typeof(int));
            dt.Columns.Add("statu", typeof(bool));
            dt.Columns.Add("time", typeof(DateTime));
            dt.Columns.Add("readtime", typeof(DateTime));

            foreach (var item in info)
            {
                DataRow dr = dt.NewRow();
                dr["id"] = item.id;
                dr["userID"] = item.userID;
                dr["projectID"] = item.projectID;
                dr["projectStatu"] = item.projectStatu;
                dr["statu"] = item.statu;
                dr["time"] = item.time;
                dr["readtime"] = item.readtime;

                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
