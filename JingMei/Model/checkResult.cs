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
    
    public partial class checkResult
    {
        public int id { get; set; }
        public int checkPersonID { get; set; }
        public string projectID { get; set; }
        public System.DateTime time { get; set; }
    
        public virtual project project { get; set; }
        public virtual user user { get; set; }
    }
}
