using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace win.Public
{
    public class ProjectUtility
    {
        public static void updateProjectStatu(string projectID, WF.ProjectStatusEnum statu)
        {
            //更新状态
            ProjectService.ProjectClient service = new ProjectService.ProjectClient("ProjectService");
            service.Open();
            service.updateProjectStatu(projectID, (int)statu);
            service.Close();
        }
    }
}
