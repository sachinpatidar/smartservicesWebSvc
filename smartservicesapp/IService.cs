
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
        ReturnValues RegisterUser(UserRegister1 obj);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "LoginUser")]
        ReturnValues LoginUser(Login obj);
        //[OperationContract]
        //[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "UploadImages")]
        //List<AddBlog> UploadImages();
    }


 

}
