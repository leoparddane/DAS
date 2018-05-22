using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
namespace Service
{
    [ServiceContract]
    interface IUser
    {
        [OperationContract]
        bool checkPwd(string username,string pwd);

        [OperationContract]
        int getUserID(string username);
        [OperationContract]
        bool checkPerimission(int userid, int projectStatuID, int type);

        [OperationContract]
        bool hsaCheckPermission(int userid, int projectStatuID);
    }
}
