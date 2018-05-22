using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Data;

namespace Service
{
    [ServiceContract]
    interface IProject
    {
        /// <summary>
        /// 获取所有的项目信息
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [ServiceKnownType(typeof(List<Model.project>))]
        List<Model.project> getAllList();

        /// <summary>
        /// 根据项目ID获取项目信息
        /// </summary>
        /// <param name="projectID">项目编号</param>
        /// <returns>当前项目状态</returns>
        [OperationContract]
        int getProjectStatu(string projectID);

        /// <summary>
        /// 更新项目状态同时加入状态变更信息
        /// </summary>
        /// <param name="projectID">项目编号</param>
        /// <param name="newStatu">新的状态</param>
        /// <returns>是否更新成功</returns>
        [OperationContract]
        bool updateProjectStatu(string projectID,int newStatu);


        /// <summary>
        /// 获取项目当前时间节点的名称
        /// </summary>
        /// <param name="projectID"></param>
        /// <returns></returns>
        [OperationContract]
        string getProjectStatuName(string projectID);


        /// <summary>
        /// 加入审查信息记录表
        /// </summary>
        /// <param name="projectID">项目编号</param>
        /// <param name="checkPersonID">审查人用户id</param>
        /// <returns>是否添加成功</returns>
        [OperationContract]
        bool addCheckInfo(string projectID,int checkPersonID);

        /// <summary>
        /// 添加项目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [OperationContract]
        bool addProject(Model.project model);

        [OperationContract]
        bool hasUnreadMessage(int userid);

        [OperationContract]
        bool hasNGMessage(int userID);

        [OperationContract]
        DataTable getNGMessage(int userID);
    }
}
