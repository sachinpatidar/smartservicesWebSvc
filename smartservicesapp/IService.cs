
using System.ServiceModel;
using System.ServiceModel.Web;
using smartservicesapp.Model;
using System.Text;
using System.Collections.Generic;
using smartservicesapp.Repository;

namespace smartservicesapp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetCategoryList/{CategoryID}")]
        List<Category> GetCategoryList(string CategoryID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetPrivacyTypeList/{PrivacyTypeID}")]
        List<PrivacyType> GetPrivacyTypeList(string PrivacyTypeID);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "RegisterUser")]
        void RegisterUser(UserRegister obj);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "LoginUser")]
        ReturnValues LoginUser(Login obj);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetUserInfo/{UserID}")]
        List<UserRegister> GetUserInfo(string UserID);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddBlogs")]
        ReturnValues AddBlogs(AddBlog obj);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddUpdateBlogComment")]
        ReturnValues AddUpdateBlogComment(BlogComment obj);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetfileInfo/{fileID}")]
        List<FileSetting> GetfileInfo(string fileID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetDocuments/{SourceID}/{Filtype}")]
        List<FileSetting> GetDocuments(string SourceID, string Filtype);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetBlogList/{BlogID}/{CategoryID}")]
        List<AddBlog> GetBlogList(string BlogID, string CategoryID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "UserComment/{BlogID}")]
        List<BlogComment> UserComment(string BlogID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "DeleteBlogComment/{CommentId}")]
        ReturnValues DeleteBlogComment(string CommentId);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "UserLikes/{BlogID}/{UserID}")]
        ReturnValues UserLikes(string BlogID, string UserID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ForgetPassword/{emailID}")]
        ReturnValues ForgetPassword(string emailID);

    }




}
