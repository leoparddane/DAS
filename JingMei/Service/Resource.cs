using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Resource : IResource
    {
        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public Stream Download(int resourceID)
        {
            return File.OpenRead(new BLL.ResourcePathBLL().GetModel(p=>p.id==resourceID).filePath);
        }

        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="stream"></param>
        public /*async*/ void Upload(FileUploadMessage stream)
        {
            
            //存入数据库
            var model = new Model.resourcePath();
            model.projectID = stream.projectID;
            model.statu = new BLL.ProjectBLL().GetModel(p => p.id == stream.projectID).currentStatuID;

            var path = Environment.CurrentDirectory + @"\resource\" + (WF.ProjectStatusEnum)model.statu + @"\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var finalpath = path+ DateTime.Now.ToString("yyyyMMddhhmmss") + stream.resourceName.Substring(stream.resourceName.LastIndexOf('\\') + 1);
           
            model.filePath = finalpath;
            model.uploadPerson = stream.uploadPerson;
            model.dntime = DateTime.Now;
            model.type = 1;
            new BLL.ResourcePathBLL().Add(model);
            using (var file = File.Create(finalpath))
            {
                const int bufferlen = 1024;
                byte[] buf = new byte[bufferlen];
                int count = 0;
                while((count=stream.data.Read(buf,0,bufferlen))>0)
                {
                    file.Write(buf,0,count);
                }
                /*await*/ //stream.data.CopyToAsync(file);
            }
        }
        public string getFileName(int resourceID)
        {
            string fileNmae = "";

            return fileNmae;
        }

        public bool deleteFile(int resourceID)
        {
            bool result = false;
            var bll = new BLL.ResourcePathBLL();
            var model = bll.GetModel(p => p.id == resourceID);
            if (model==null)
            {
                //
            }
            else
            {
                var path=model.filePath;
                bll.Delete(model,false);
                //check the file is exist or not
                if(File.Exists(path))
                {
                    try
                    {
                        File.Delete(path);
                        result = true;
                    }
                    catch (Exception)
                    { 
                    }
                }  
            }
            return result;
        }
    }
}
