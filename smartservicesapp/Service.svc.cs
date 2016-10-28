using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using smartservicesapp.Model;
using System.Transactions;

using System.ServiceModel.Web;
using System.Text;
using smartservicesapp.Repository;

namespace smartservicesapp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service : IService
    {
        #region ["GetCategoryList"]
        public List<Category> GetCategoryList(string CategoryID)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    RepsistoryEF<Category> _o = new global::RepsistoryEF<Model.Category>();
                    int catID = 0;
                    List<Category> lst = new List<Category>();
                    if (CategoryID.Trim() != "L")
                    {
                        catID = int.Parse(CategoryID); lst = _o.GetListBySelector(z => z.CategoryID == catID).ToList();
                    }
                    else
                    {
                        lst = _o.GetList().OrderBy(z => z.CatOrderBy).ToList();
                    }
                    trans.Complete();
                    return lst;
                }
                catch (Exception ex)
                {
                    trans.Dispose();
                    throw;
                }
                finally
                {
                    trans.Dispose();
                }
            }

        }
        #endregion

        #region [GetPrivacyTypeList]
        public List<PrivacyType> GetPrivacyTypeList(string PrivacyTypeID)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    RepsistoryEF<PrivacyType> _o = new global::RepsistoryEF<Model.PrivacyType>();
                    int ID = 0;
                    List<PrivacyType> lst = new List<PrivacyType>();
                    if (PrivacyTypeID.Trim() != "L")
                    {
                        ID = int.Parse(PrivacyTypeID);
                        lst = _o.GetListBySelector(z => z.PrivacyID == ID).ToList();
                    }
                    else
                    {
                        lst = _o.GetList().OrderBy(z=>z.PrivacyOrderBy).ToList();
                    }
                    trans.Complete();
                    return lst;
                }
                catch (Exception)
                {
                    trans.Dispose();
                    throw;
                }
                finally
                {
                    trans.Dispose();
                }
            }

        }
        #endregion


        public void RegisterUser(UserRegister obj)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    RepsistoryEF<UserRegister> _o = new global::RepsistoryEF<UserRegister>();
                    obj.CreateDate = DateTime.Now;
                    int fileID = 0;
                    if (obj.FileName != null)
                    {
                        
                    //    byte[] b = Convert.FromBase64String(obj.FileName);
                        RepsistoryEF<FileSetting> _F = new global::RepsistoryEF<FileSetting>();
                        FileSetting objf = new FileSetting { File = obj.FileName, FileType = FileType.UserProfile.ToString() };
                        _F.Save(objf);
                        fileID= objf.Id;
                    }
                    obj.FileId = fileID;
                    var resultValue = _o.Save(obj);
                    ReturnValues result = null;
                    if (resultValue != null)
                    {
                       
                        result = new ReturnValues
                        {
                            Success = "Registeration Successfully Done ",
                         //   Source = resultValue.RegistrationID.ToString(),
                        };
                    }
                    trans.Complete();
                  //  return result;
                }
                catch (Exception ex)
                {
                    trans.Dispose();
                    ReturnValues objex = new ReturnValues
                    {
                        Failure = ex.Message,
                        Source = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.RequestUri.AbsoluteUri,
                    };
                    throw new WebFaultException<ReturnValues>(objex, System.Net.HttpStatusCode.InternalServerError);
                }
                finally
                {
                    trans.Dispose();
                }
            }
        }

        public ReturnValues LoginUser(Login obj)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    RepsistoryEF<Model.UserRegister> _o = new global::RepsistoryEF<Model.UserRegister>();

                   var resultValue = _o.GetListBySelector(z => z.UserName == obj.UserName && z.Password == obj.Password).FirstOrDefault();
                    ReturnValues result = null;
                    if (resultValue != null)
                    {
                        result = new ReturnValues
                        {
                            Success = "Login Successfully",
                    //        Source = resultValue.RegistrationID.ToString(),
                        };
                    }
                    else
                    {
                        result = new ReturnValues
                        {
                            Success = "Login Failed, Please enter correct username and password",
                            Source = "0",
                        };
                    }
                    trans.Complete();
                    return result;
                }
                catch (Exception ex)
                {
                    trans.Dispose();
                    ReturnValues objex = new ReturnValues
                    {
                        Failure = ex.Message,
                        Source = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.RequestUri.AbsoluteUri,
                    };
                    throw new WebFaultException<ReturnValues>(objex, System.Net.HttpStatusCode.InternalServerError);
                }
                finally
                {
                    trans.Dispose();
                }
            }
        }


        //public List<AddBlog> UploadImages() {
        //    AddBlog a = new AddBlog();
        //    RepsistoryEF<AddBlog> _o = new global::RepsistoryEF<AddBlog>();
        //    var g = _o.GetList();
        //    return g;
        //}

    }
}
