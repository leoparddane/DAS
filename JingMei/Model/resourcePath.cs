//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class resourcePath
    {
        public int id { get; set; }
        public string projectID { get; set; }
        public int statu { get; set; }
        public string filePath { get; set; }
        public int uploadPerson { get; set; }
        public System.DateTime dntime { get; set; }
        public int type { get; set; }
        public string note { get; set; }
    
        public virtual project project { get; set; }
        public virtual projectStatus projectStatus { get; set; }
        public virtual user user { get; set; }
    }
}
