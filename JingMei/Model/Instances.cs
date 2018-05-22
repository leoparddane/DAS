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
    
    public partial class Instances
    {
        public System.Guid InstanceId { get; set; }
        public Nullable<System.DateTime> PendingTimer { get; set; }
        public System.DateTime CreationTime { get; set; }
        public Nullable<System.DateTime> LastUpdatedTime { get; set; }
        public Nullable<long> ServiceDeploymentId { get; set; }
        public string SuspensionExceptionName { get; set; }
        public string SuspensionReason { get; set; }
        public string ActiveBookmarks { get; set; }
        public string CurrentMachine { get; set; }
        public string LastMachine { get; set; }
        public string ExecutionStatus { get; set; }
        public Nullable<bool> IsInitialized { get; set; }
        public Nullable<bool> IsSuspended { get; set; }
        public Nullable<bool> IsCompleted { get; set; }
        public Nullable<byte> EncodingOption { get; set; }
        public byte[] ReadWritePrimitiveDataProperties { get; set; }
        public byte[] WriteOnlyPrimitiveDataProperties { get; set; }
        public byte[] ReadWriteComplexDataProperties { get; set; }
        public byte[] WriteOnlyComplexDataProperties { get; set; }
        public string IdentityName { get; set; }
        public string IdentityPackage { get; set; }
        public Nullable<long> Build { get; set; }
        public Nullable<long> Major { get; set; }
        public Nullable<long> Minor { get; set; }
        public Nullable<long> Revision { get; set; }
    }
}
