﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Chatly.ServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IDataService")]
    public interface IDataService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/GetMessage", ReplyAction="http://tempuri.org/IDataService/GetMessageResponse")]
        ChatlyServices.Messages GetMessage(int bookmarkId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/GetMessage", ReplyAction="http://tempuri.org/IDataService/GetMessageResponse")]
        System.Threading.Tasks.Task<ChatlyServices.Messages> GetMessageAsync(int bookmarkId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/GetMessagesList", ReplyAction="http://tempuri.org/IDataService/GetMessagesListResponse")]
        ChatlyServices.Messages[] GetMessagesList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/GetMessagesList", ReplyAction="http://tempuri.org/IDataService/GetMessagesListResponse")]
        System.Threading.Tasks.Task<ChatlyServices.Messages[]> GetMessagesListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/AddMessage", ReplyAction="http://tempuri.org/IDataService/AddMessageResponse")]
        void AddMessage(ChatlyServices.Messages message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/AddMessage", ReplyAction="http://tempuri.org/IDataService/AddMessageResponse")]
        System.Threading.Tasks.Task AddMessageAsync(ChatlyServices.Messages message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/UpdateMessage", ReplyAction="http://tempuri.org/IDataService/UpdateMessageResponse")]
        void UpdateMessage(ChatlyServices.Messages message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/UpdateMessage", ReplyAction="http://tempuri.org/IDataService/UpdateMessageResponse")]
        System.Threading.Tasks.Task UpdateMessageAsync(ChatlyServices.Messages message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/DeleteMessage", ReplyAction="http://tempuri.org/IDataService/DeleteMessageResponse")]
        void DeleteMessage(ChatlyServices.Messages message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/DeleteMessage", ReplyAction="http://tempuri.org/IDataService/DeleteMessageResponse")]
        System.Threading.Tasks.Task DeleteMessageAsync(ChatlyServices.Messages message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/GetCode", ReplyAction="http://tempuri.org/IDataService/GetCodeResponse")]
        ChatlyServices.Codes GetCode(int codeId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/GetCode", ReplyAction="http://tempuri.org/IDataService/GetCodeResponse")]
        System.Threading.Tasks.Task<ChatlyServices.Codes> GetCodeAsync(int codeId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/GetCodesList", ReplyAction="http://tempuri.org/IDataService/GetCodesListResponse")]
        ChatlyServices.Codes[] GetCodesList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/GetCodesList", ReplyAction="http://tempuri.org/IDataService/GetCodesListResponse")]
        System.Threading.Tasks.Task<ChatlyServices.Codes[]> GetCodesListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/AddCode", ReplyAction="http://tempuri.org/IDataService/AddCodeResponse")]
        void AddCode(ChatlyServices.Codes code);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/AddCode", ReplyAction="http://tempuri.org/IDataService/AddCodeResponse")]
        System.Threading.Tasks.Task AddCodeAsync(ChatlyServices.Codes code);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/UpdateCode", ReplyAction="http://tempuri.org/IDataService/UpdateCodeResponse")]
        void UpdateCode(ChatlyServices.Codes code);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/UpdateCode", ReplyAction="http://tempuri.org/IDataService/UpdateCodeResponse")]
        System.Threading.Tasks.Task UpdateCodeAsync(ChatlyServices.Codes code);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/DeleteCode", ReplyAction="http://tempuri.org/IDataService/DeleteCodeResponse")]
        void DeleteCode(ChatlyServices.Codes code);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/DeleteCode", ReplyAction="http://tempuri.org/IDataService/DeleteCodeResponse")]
        System.Threading.Tasks.Task DeleteCodeAsync(ChatlyServices.Codes code);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/GetUserList", ReplyAction="http://tempuri.org/IDataService/GetUserListResponse")]
        ChatlyServices.AspNetUsers[] GetUserList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataService/GetUserList", ReplyAction="http://tempuri.org/IDataService/GetUserListResponse")]
        System.Threading.Tasks.Task<ChatlyServices.AspNetUsers[]> GetUserListAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDataServiceChannel : Chatly.ServiceReference.IDataService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DataServiceClient : System.ServiceModel.ClientBase<Chatly.ServiceReference.IDataService>, Chatly.ServiceReference.IDataService {
        
        public DataServiceClient() {
        }
        
        public DataServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DataServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DataServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DataServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ChatlyServices.Messages GetMessage(int bookmarkId) {
            return base.Channel.GetMessage(bookmarkId);
        }
        
        public System.Threading.Tasks.Task<ChatlyServices.Messages> GetMessageAsync(int bookmarkId) {
            return base.Channel.GetMessageAsync(bookmarkId);
        }
        
        public ChatlyServices.Messages[] GetMessagesList() {
            return base.Channel.GetMessagesList();
        }
        
        public System.Threading.Tasks.Task<ChatlyServices.Messages[]> GetMessagesListAsync() {
            return base.Channel.GetMessagesListAsync();
        }
        
        public void AddMessage(ChatlyServices.Messages message) {
            base.Channel.AddMessage(message);
        }
        
        public System.Threading.Tasks.Task AddMessageAsync(ChatlyServices.Messages message) {
            return base.Channel.AddMessageAsync(message);
        }
        
        public void UpdateMessage(ChatlyServices.Messages message) {
            base.Channel.UpdateMessage(message);
        }
        
        public System.Threading.Tasks.Task UpdateMessageAsync(ChatlyServices.Messages message) {
            return base.Channel.UpdateMessageAsync(message);
        }
        
        public void DeleteMessage(ChatlyServices.Messages message) {
            base.Channel.DeleteMessage(message);
        }
        
        public System.Threading.Tasks.Task DeleteMessageAsync(ChatlyServices.Messages message) {
            return base.Channel.DeleteMessageAsync(message);
        }
        
        public ChatlyServices.Codes GetCode(int codeId) {
            return base.Channel.GetCode(codeId);
        }
        
        public System.Threading.Tasks.Task<ChatlyServices.Codes> GetCodeAsync(int codeId) {
            return base.Channel.GetCodeAsync(codeId);
        }
        
        public ChatlyServices.Codes[] GetCodesList() {
            return base.Channel.GetCodesList();
        }
        
        public System.Threading.Tasks.Task<ChatlyServices.Codes[]> GetCodesListAsync() {
            return base.Channel.GetCodesListAsync();
        }
        
        public void AddCode(ChatlyServices.Codes code) {
            base.Channel.AddCode(code);
        }
        
        public System.Threading.Tasks.Task AddCodeAsync(ChatlyServices.Codes code) {
            return base.Channel.AddCodeAsync(code);
        }
        
        public void UpdateCode(ChatlyServices.Codes code) {
            base.Channel.UpdateCode(code);
        }
        
        public System.Threading.Tasks.Task UpdateCodeAsync(ChatlyServices.Codes code) {
            return base.Channel.UpdateCodeAsync(code);
        }
        
        public void DeleteCode(ChatlyServices.Codes code) {
            base.Channel.DeleteCode(code);
        }
        
        public System.Threading.Tasks.Task DeleteCodeAsync(ChatlyServices.Codes code) {
            return base.Channel.DeleteCodeAsync(code);
        }
        
        public ChatlyServices.AspNetUsers[] GetUserList() {
            return base.Channel.GetUserList();
        }
        
        public System.Threading.Tasks.Task<ChatlyServices.AspNetUsers[]> GetUserListAsync() {
            return base.Channel.GetUserListAsync();
        }
    }
}
