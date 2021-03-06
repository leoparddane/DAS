﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace win.ProjectService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProjectService.IProject")]
    public interface IProject {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/getAllList", ReplyAction="http://tempuri.org/IProject/getAllListResponse")]
        Model.project[] getAllList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/getAllList", ReplyAction="http://tempuri.org/IProject/getAllListResponse")]
        System.Threading.Tasks.Task<Model.project[]> getAllListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/getProjectStatu", ReplyAction="http://tempuri.org/IProject/getProjectStatuResponse")]
        int getProjectStatu(string projectID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/getProjectStatu", ReplyAction="http://tempuri.org/IProject/getProjectStatuResponse")]
        System.Threading.Tasks.Task<int> getProjectStatuAsync(string projectID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/updateProjectStatu", ReplyAction="http://tempuri.org/IProject/updateProjectStatuResponse")]
        bool updateProjectStatu(string projectID, int newStatu);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/updateProjectStatu", ReplyAction="http://tempuri.org/IProject/updateProjectStatuResponse")]
        System.Threading.Tasks.Task<bool> updateProjectStatuAsync(string projectID, int newStatu);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/getProjectStatuName", ReplyAction="http://tempuri.org/IProject/getProjectStatuNameResponse")]
        string getProjectStatuName(string projectID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/getProjectStatuName", ReplyAction="http://tempuri.org/IProject/getProjectStatuNameResponse")]
        System.Threading.Tasks.Task<string> getProjectStatuNameAsync(string projectID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/addCheckInfo", ReplyAction="http://tempuri.org/IProject/addCheckInfoResponse")]
        bool addCheckInfo(string projectID, int checkPersonID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/addCheckInfo", ReplyAction="http://tempuri.org/IProject/addCheckInfoResponse")]
        System.Threading.Tasks.Task<bool> addCheckInfoAsync(string projectID, int checkPersonID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/addProject", ReplyAction="http://tempuri.org/IProject/addProjectResponse")]
        bool addProject(Model.project model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/addProject", ReplyAction="http://tempuri.org/IProject/addProjectResponse")]
        System.Threading.Tasks.Task<bool> addProjectAsync(Model.project model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/hasUnreadMessage", ReplyAction="http://tempuri.org/IProject/hasUnreadMessageResponse")]
        bool hasUnreadMessage(int userid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/hasUnreadMessage", ReplyAction="http://tempuri.org/IProject/hasUnreadMessageResponse")]
        System.Threading.Tasks.Task<bool> hasUnreadMessageAsync(int userid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/hasNGMessage", ReplyAction="http://tempuri.org/IProject/hasNGMessageResponse")]
        bool hasNGMessage(int userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/hasNGMessage", ReplyAction="http://tempuri.org/IProject/hasNGMessageResponse")]
        System.Threading.Tasks.Task<bool> hasNGMessageAsync(int userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/getNGMessage", ReplyAction="http://tempuri.org/IProject/getNGMessageResponse")]
        System.Data.DataTable getNGMessage(int userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProject/getNGMessage", ReplyAction="http://tempuri.org/IProject/getNGMessageResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> getNGMessageAsync(int userID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProjectChannel : win.ProjectService.IProject, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProjectClient : System.ServiceModel.ClientBase<win.ProjectService.IProject>, win.ProjectService.IProject {
        
        public ProjectClient() {
        }
        
        public ProjectClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProjectClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProjectClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProjectClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Model.project[] getAllList() {
            return base.Channel.getAllList();
        }
        
        public System.Threading.Tasks.Task<Model.project[]> getAllListAsync() {
            return base.Channel.getAllListAsync();
        }
        
        public int getProjectStatu(string projectID) {
            return base.Channel.getProjectStatu(projectID);
        }
        
        public System.Threading.Tasks.Task<int> getProjectStatuAsync(string projectID) {
            return base.Channel.getProjectStatuAsync(projectID);
        }
        
        public bool updateProjectStatu(string projectID, int newStatu) {
            return base.Channel.updateProjectStatu(projectID, newStatu);
        }
        
        public System.Threading.Tasks.Task<bool> updateProjectStatuAsync(string projectID, int newStatu) {
            return base.Channel.updateProjectStatuAsync(projectID, newStatu);
        }
        
        public string getProjectStatuName(string projectID) {
            return base.Channel.getProjectStatuName(projectID);
        }
        
        public System.Threading.Tasks.Task<string> getProjectStatuNameAsync(string projectID) {
            return base.Channel.getProjectStatuNameAsync(projectID);
        }
        
        public bool addCheckInfo(string projectID, int checkPersonID) {
            return base.Channel.addCheckInfo(projectID, checkPersonID);
        }
        
        public System.Threading.Tasks.Task<bool> addCheckInfoAsync(string projectID, int checkPersonID) {
            return base.Channel.addCheckInfoAsync(projectID, checkPersonID);
        }
        
        public bool addProject(Model.project model) {
            return base.Channel.addProject(model);
        }
        
        public System.Threading.Tasks.Task<bool> addProjectAsync(Model.project model) {
            return base.Channel.addProjectAsync(model);
        }
        
        public bool hasUnreadMessage(int userid) {
            return base.Channel.hasUnreadMessage(userid);
        }
        
        public System.Threading.Tasks.Task<bool> hasUnreadMessageAsync(int userid) {
            return base.Channel.hasUnreadMessageAsync(userid);
        }
        
        public bool hasNGMessage(int userID) {
            return base.Channel.hasNGMessage(userID);
        }
        
        public System.Threading.Tasks.Task<bool> hasNGMessageAsync(int userID) {
            return base.Channel.hasNGMessageAsync(userID);
        }
        
        public System.Data.DataTable getNGMessage(int userID) {
            return base.Channel.getNGMessage(userID);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> getNGMessageAsync(int userID) {
            return base.Channel.getNGMessageAsync(userID);
        }
    }
}
