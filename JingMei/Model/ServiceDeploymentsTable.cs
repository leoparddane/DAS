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
    
    public partial class ServiceDeploymentsTable
    {
        public long Id { get; set; }
        public System.Guid ServiceDeploymentHash { get; set; }
        public string SiteName { get; set; }
        public string RelativeServicePath { get; set; }
        public string RelativeApplicationPath { get; set; }
        public string ServiceName { get; set; }
        public string ServiceNamespace { get; set; }
    }
}
