using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.IO;

namespace Service
{
    [ServiceContract]
    public interface IResource
    {
        [OperationContract]
        void Upload(FileUploadMessage stream);

        [OperationContract]
        Stream Download(int resourceID);

        /// <summary>
        /// 获取指定资源的文件名
        /// </summary>
        /// <param name="resourceID"></param>
        /// <returns></returns>
        [OperationContract]
        string getFileName(int resourceID);

        /// <summary>
        /// 删除文件和记录
        /// </summary>
        /// <param name="resourceID"></param>
        /// <returns></returns>
        [OperationContract]
        bool deleteFile(int resourceID);
    }
    [MessageContract]
    public class FileUploadMessage
    {
        //资源名称
        [MessageHeader]
        public string resourceName;
        //项目编号
        [MessageHeader]
        public string projectID;
        //上传人
        [MessageHeader]
        public int uploadPerson;

        [MessageBodyMember]
        public Stream data;
    }

    
}
