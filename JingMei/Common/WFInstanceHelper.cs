using System;
using System.Activities;
using System.Activities.DurableInstancing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WF;

namespace Common
{
    public class WFInstanceHelper
    {
        /// <summary>
        /// 创建工作流
        /// </summary>
        /// <param name="model">项目信息</param>
        /// <returns>创建是否成功</returns>
        public static bool CreateInstance(Model.project model)
        {
             bool result = false;
            
            AutoResetEvent syncEvent = new AutoResetEvent(false);

            //传递参数给活动
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("projectModel", model);
            
            WorkflowApplication app = new WorkflowApplication(new Project(), dic);

            //var instanceid = app.Id;
            model.instanceID = app.Id.ToString();
            SqlWorkflowInstanceStore store =
            new SqlWorkflowInstanceStore(DB.getConnectionString());
            //new SqlWorkflowInstanceStore(@"Server=DESKTOP-FCNHL7F\SQLEXPRESS;database=JingMei;uid=sa;pwd=123");
            //绑定数据库
            app.InstanceStore = store;
            #region 工作流生命周期事件
            app.Unloaded = delegate (WorkflowApplicationEventArgs er)
            {
                Console.WriteLine("工作流 {0} 卸载.", er.InstanceId);
            };
            app.Completed = delegate (WorkflowApplicationCompletedEventArgs er)
            {
                //textBox1.Text = er.Outputs["arg1"].ToString();
                syncEvent.Set();
            };
            app.Aborted = delegate (WorkflowApplicationAbortedEventArgs er)
            {
                Console.WriteLine("工作流 {0} 终止.", er.InstanceId);
            };
            app.Idle = delegate (WorkflowApplicationIdleEventArgs er)
            {

                Console.WriteLine("工作流 {0} 空闲.", er.InstanceId);
                syncEvent.Set(); //这里要唤醒，不让的话，当创建了一个书签之后，界面就卡死了。
            };
            app.PersistableIdle = delegate (WorkflowApplicationIdleEventArgs er)
            {
                var bookmarks = er.Bookmarks;
                //instanceID = er.InstanceId.ToString();
                //textBox1.Text = er.["arg1"].ToString();
                Console.WriteLine("持久化");
                return PersistableIdleAction.Unload;
            };
            app.OnUnhandledException = delegate (WorkflowApplicationUnhandledExceptionEventArgs er)
            {
                Console.WriteLine("OnUnhandledException in Workflow {0}\n{1}",
                    er.InstanceId, er.UnhandledException.Message);
                return UnhandledExceptionAction.Terminate;
            };
            #endregion
            try
            {
                app.Run();
                syncEvent.WaitOne();
                result = true;
            }
            catch (Exception)
            {
            }
            finally
            {
                app.Unload();
            }
            return result;
        }

        /// <summary>
        /// 制定实例id以及书签名称继续执行书签
        /// </summary>
        /// <param name="instanceID"></param>
        /// <param name="bookmarkName"></param>
        /// <returns></returns>
        public static bool resumeBookMark(string instanceID, string bookmarkName, Activity bookMarkType,int userID)
        {
            bool result = false;

            AutoResetEvent syncEvent = new AutoResetEvent(false);
            WorkflowApplication app = new WorkflowApplication(bookMarkType);
            SqlWorkflowInstanceStore store =
                new SqlWorkflowInstanceStore(DB.getConnectionString());
            app.InstanceStore = store;
            #region 工作流生命周期事件
            app.Unloaded = delegate (WorkflowApplicationEventArgs er)
            {
                Console.WriteLine("工作流 {0} 卸载.", er.InstanceId);
            };
            app.Completed = delegate (WorkflowApplicationCompletedEventArgs er)
            {
                //textBox1.Text = er.Outputs["arg1"].ToString();
                syncEvent.Set();
            };
            app.Aborted = delegate (WorkflowApplicationAbortedEventArgs er)
            {
                Console.WriteLine("工作流 {0} 终止.", er.InstanceId);
            };
            app.Idle = delegate (WorkflowApplicationIdleEventArgs er)
            {

                Console.WriteLine("工作流 {0} 空闲.", er.InstanceId);
                syncEvent.Set(); //这里要唤醒，不让的话，当创建了一个书签之后，界面就卡死了。
            };
            app.PersistableIdle = delegate (WorkflowApplicationIdleEventArgs er)
            {
                var bookmarks = er.Bookmarks;
                //var instanceID = er.InstanceId;
                //textBox1.Text = er.["arg1"].ToString();
                Console.WriteLine("持久化");
                return PersistableIdleAction.Unload;
            };
            app.OnUnhandledException = delegate (WorkflowApplicationUnhandledExceptionEventArgs er)
            {
                Console.WriteLine("OnUnhandledException in Workflow {0}\n{1}",
       er.InstanceId, er.UnhandledException.Message);
                return UnhandledExceptionAction.Terminate;
            };
            #endregion
            //继续执行
            try
            {
                app.Load(Guid.Parse(instanceID));
                app.ResumeBookmark(bookmarkName, null);
                result = true;

                //记录状态变更情况
                var changeModel = new Model.projectStatuChangeInfo();
                var projectModel = new BLL.ProjectBLL().GetModels(p => p.id == bookmarkName).First();
                changeModel.projectID = projectModel.id;
                changeModel.statu = projectModel.currentStatuID;
                changeModel.time = DateTime.Now;
                changeModel.userID = userID;
                new BLL.ProjectStatuChangeInfo().Add(changeModel);
            }
            catch (Exception)
            {
            }
            finally
            {
                //app.Unload();
            }
            return result;
        }
    }
}
