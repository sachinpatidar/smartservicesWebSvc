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
    // [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service : IService
    {
        #region ["Add_Update_Comment_Likes"]
        public List<BlogComment> UserComment(string BlogID)
        {
            RepsistoryEF<BlogComment> _BlogComm = new global::RepsistoryEF<BlogComment>();
            int blgid = int.Parse(BlogID);
            return _BlogComm.GetListBySelector(z => z.BlogId == blgid).ToList();
        }
        public ReturnValues DeleteBlogComment(string CommentId)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    RepsistoryEF<BlogComment> _BlogComm = new global::RepsistoryEF<BlogComment>();
                    BlogComment _updateblog = new BlogComment();
                    int blgid = int.Parse(CommentId);
                    _updateblog = _BlogComm.GetListBySelector(z => z.CommentId == blgid).FirstOrDefault();
                    _BlogComm.Delete(_updateblog);

                    ReturnValues objReturn = new ReturnValues
                    {
                        Success = "Delete Successfully",
                        Status = true
                    };
                    trans.Complete();
                    return objReturn;
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

        public ReturnValues AddUpdateBlogComment(BlogComment obj)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    RepsistoryEF<BlogComment> _BlogdocF = new global::RepsistoryEF<BlogComment>();
                    BlogComment _updateblog = new BlogComment();
                    _updateblog = _BlogdocF.GetListBySelector(z => z.CommentId == obj.CommentId && z.UserID == obj.UserID).FirstOrDefault();
                    if (_updateblog != null)
                    {
                        _updateblog.Comment = obj.Comment;
                        obj.CreatedDate = DateTime.Now;
                        _BlogdocF.Update(_updateblog);
                    }
                    else
                    {
                        obj.CreatedDate = DateTime.Now;
                        _BlogdocF.Save(obj);
                    }
                    trans.Complete();
                    ReturnValues objReturn = new ReturnValues
                    {
                        Success = "Success",
                        Status = true
                    };
                    return objReturn;
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

        public ReturnValues UserLikes(string BlogID, string UserID)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    RepsistoryEF<AddBlog> _BlogdocF = new global::RepsistoryEF<AddBlog>();
                    AddBlog _updateblog = new AddBlog();
                    int BlgID = int.Parse(BlogID);
                    _updateblog = _BlogdocF.GetListBySelector(z => z.BlogId == BlgID).FirstOrDefault();
                    if (_updateblog != null)
                    {
                        _updateblog.UserLikes += UserID + ",";
                        _BlogdocF.Update(_updateblog);
                    }
                    trans.Complete();
                    ReturnValues objReturn = new ReturnValues
                    {
                        Success = "Success",
                        Status = true

                    };
                    return objReturn;
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

        #endregion

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
                        lst = _o.GetList().OrderBy(z => z.PrivacyOrderBy).ToList();
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

        #region [Registration/Login]
        public void RegisterUser(UserRegister obj)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    RepsistoryEF<UserRegister> _o = new global::RepsistoryEF<UserRegister>();
                    obj.CreateDate = DateTime.Now;
                    var resultValue = _o.Save(obj);
                    if (obj.FileName != null)
                    {
                        RepsistoryEF<FileSetting> _F = new global::RepsistoryEF<FileSetting>();
                        FileSetting objf = new FileSetting { FileType = FileType.UserProfile.ToString(), SourceID = resultValue.RegistrationID, FilePath = obj.FilePathName };
                        _F.Save(objf);
                    }
                    ReturnValues result = null;
                    if (resultValue != null)
                    {
                        result = new ReturnValues
                        {
                            Success = "Registeration Successfully Done ",
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
                            Source = resultValue.RegistrationID.ToString(),
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

        public List<UserRegister> GetUserInfo(string UserID)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    GmContext _db = new GmContext();
                    // RepsistoryEF<UserRegister> _o = new global::RepsistoryEF<Model.UserRegister>();
                    int UID = 0;
                    List<UserRegister> lst = new List<UserRegister>();
                    if (UserID.Trim() != "L")
                    {
                        UID = int.Parse(UserID);

                        var lsts = _db.UserRegister.Where(z => z.RegistrationID == UID).Join(
         _db.FileSetting.Where(z => z.FileType == FileType.UserProfile.ToString()),
         U => U.RegistrationID,
         F => F.SourceID,
         (U, F) => new { u = U, f = F }
     ).Select(us => new
     {
         Email = us.u.Email,
         FilePathName = us.f.FilePath,
         FirstName = us.u.FirstName,
         LastName = us.u.LastName,
         Mobile = us.u.Mobile,
         RegistrationID = us.u.RegistrationID,
         UserName = us.u.UserName
     }).AsQueryable();

                        lst = lsts.ToList().Select(us => new UserRegister
                        {
                            Email = us.Email,
                            FilePathName = us.FilePathName,
                            FirstName = us.FirstName,
                            LastName = us.LastName,
                            Mobile = us.Mobile,
                            RegistrationID = us.RegistrationID,
                            UserName = us.UserName
                        }).ToList();

                    }
                    else
                    {
                        var lsts = _db.UserRegister.Join(_db.FileSetting.Where(z => z.FileType == FileType.UserProfile.ToString()), U => U.RegistrationID, F => F.SourceID, (U, F) => new { u = U, f = F }
   ).Select(us => new UserRegister
   {
       Email = us.u.Email,
       FilePathName = us.f.FilePath,
       FirstName = us.u.FirstName,
       LastName = us.u.LastName,
       Mobile = us.u.Mobile,
       RegistrationID = us.u.RegistrationID,
       UserName = us.u.UserName
   }).AsQueryable().ToList();

                        lst = lsts.ToList().Select(us => new UserRegister
                        {
                            Email = us.Email,
                            FilePathName = us.FilePathName,
                            FirstName = us.FirstName,
                            LastName = us.LastName,
                            Mobile = us.Mobile,
                            RegistrationID = us.RegistrationID,
                            UserName = us.UserName
                        }).ToList();

                    }
                    trans.Complete();
                    return lst;
                }
                catch (Exception ex)
                {
                    trans.Dispose();
                    throw ex;
                }
                finally
                {
                    trans.Dispose();
                }
            }

        }
        #endregion

        #region ["Documents"]
        public List<FileSetting> GetfileInfo(string fileID)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    RepsistoryEF<FileSetting> _o = new global::RepsistoryEF<Model.FileSetting>();
                    int UID = 0;
                    List<FileSetting> lst = new List<FileSetting>();
                    if (fileID.Trim() != "L")
                    {
                        UID = int.Parse(fileID); lst = _o.GetListBySelector(z => z.Id == UID).ToList();
                    }
                    else
                    {
                        lst = _o.GetList().OrderByDescending(z => z.Id).ToList();
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
        public List<FileSetting> GetDocuments(string SourceID, string Filtype)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    RepsistoryEF<FileSetting> _o = new global::RepsistoryEF<Model.FileSetting>();
                    int sID = 0;
                    sID = int.Parse(SourceID);
                    List<FileSetting> lst = new List<FileSetting>();
                    lst = _o.GetListBySelector(z => z.SourceID == sID && z.FileType == Filtype).ToList();

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

        #region ["Add Blogs"]
        public ReturnValues AddBlogs(AddBlog obj)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    RepsistoryEF<AddBlog> _o = new global::RepsistoryEF<AddBlog>();
                    AddBlog resultValue = new AddBlog();
                    if (obj.BlogId > 0)
                    {
                        // Update blogs
                        var getSpecificData = _o.GetListBySelector(z => z.BlogId == obj.BlogId).FirstOrDefault();
                        getSpecificData.UpdatedDate = DateTime.Now;
                        getSpecificData.CategoryID = obj.CategoryID;
                        getSpecificData.PrivacyID = obj.PrivacyID;
                        getSpecificData.textContent = obj.textContent;
                        getSpecificData.UserID = obj.UserID;
                        resultValue = _o.Update(getSpecificData);
                    }
                    else
                    {
                        //Add New Blogs
                        obj.CreatedDate = DateTime.Now;
                        obj.UpdatedDate = DateTime.Now;
                        resultValue = _o.Save(obj);
                    }

                    ReturnValues result = null;
                    if (resultValue != null)
                    {
                        result = new ReturnValues
                        {
                            Success = "Blog Successfully Added ",
                            Status = true,
                            Source = resultValue.BlogId.ToString()
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

        public void AddBlogdocs(string FileName, int BlogID)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    RepsistoryEF<AddBlog> _o = new global::RepsistoryEF<AddBlog>();
                    if (FileName != null)
                    {

                        // file Setting
                        RepsistoryEF<FileSetting> _F = new global::RepsistoryEF<FileSetting>();
                        FileSetting objf = new FileSetting { FilePath = FileName, FileType = FileType.BlogImage.ToString(), SourceID = BlogID };
                        _F.Save(objf);

                        RepsistoryEF<BlogDocument> _BlogdocF = new global::RepsistoryEF<BlogDocument>();


                        // Blog Documents
                        BlogDocument objBlogDocf = new BlogDocument
                        {
                            BlogId = BlogID,
                            FileID = objf.Id,
                            CreatedDate = DateTime.Now
                        };
                        _BlogdocF.Save(objBlogDocf);
                        trans.Complete();
                    }
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


        public List<AddBlog> GetBlogList(string BlogID, string CategoryID)
        {
            try
            {
                GmContext _db = new GmContext();

                int UID = 0;
                List<AddBlog> lst = new List<AddBlog>();

                if (BlogID != "null" && BlogID.Trim() != "L")
                {
                    UID = int.Parse(BlogID);

                    //List of All the Blog Documents
                    var lsts = _db.BlogDocument.Where(z => z.BlogId == UID).Join(_db.FileSetting.Where(z => z.FileType == FileType.BlogImage.ToString()), U => U.FileID, F => F.Id, (U, F) => new { u = U, f = F }).Select(us => new
                    {
                        FilePathName = us.f.FilePath,
                        BlogID = us.u.BlogId

                    }).AsQueryable();

                    // Master Data for Blogs
                    lst = _db.AddBlog.Where(z => z.BlogId == UID).OrderByDescending(z => z.BlogId).ToList();
                    // Add User Information in against of Blog
                    lst.ForEach(a =>
                    {
                        string uid = a.UserID.ToString();
                        var us = GetUserInfo(uid).FirstOrDefault();
                        List<UserRegister> lstUserinfo = new List<UserRegister>();
                        lstUserinfo.Add(new UserRegister
                        {
                            Email = us.Email,
                            FilePathName = us.FilePathName,
                            FirstName = us.FirstName,
                            LastName = us.LastName,
                            Mobile = us.Mobile,
                            RegistrationID = us.RegistrationID,
                            UserName = us.UserName
                        });
                        a.Userinfo = lstUserinfo;
                    });

                    // Add image Information in against of Blog
                    lst.ForEach(a =>
                    {
                        var imginfo = lsts.ToList().Where(d => d.BlogID == a.BlogId).ToList();
                        List<string> lstFilepath = new List<string>();
                        foreach (var f in imginfo)
                        {
                            lstFilepath.Add(f.FilePathName);
                        }
                        a.Fileinfo = lstFilepath;
                        //.ForEach(z => a.Fileinfo.Add(z != null ? z.FilePathName : null));
                    });
                }
                else if (CategoryID != "null" && BlogID.Trim() != "L")
                {
                    UID = int.Parse(CategoryID);


                    // Master Data for Blogs
                    lst = _db.AddBlog.Where(z => z.CategoryID == UID).OrderByDescending(z => z.BlogId).ToList();
                    // Add User Information in against of Blog
                    lst.ForEach(a =>
                    {
                        string uid = a.UserID.ToString();
                        var us = GetUserInfo(uid).FirstOrDefault();
                        List<UserRegister> lstUserinfo = new List<UserRegister>();
                        lstUserinfo.Add(new UserRegister
                        {
                            Email = us.Email,
                            FilePathName = us.FilePathName,
                            FirstName = us.FirstName,
                            LastName = us.LastName,
                            Mobile = us.Mobile,
                            RegistrationID = us.RegistrationID,
                            UserName = us.UserName
                        });
                        a.Userinfo = lstUserinfo;
                    });
                    //List of All the Blog Documents
                    var lsts = _db.BlogDocument.Join(_db.FileSetting.Where(z => z.FileType == FileType.BlogImage.ToString()), U => U.FileID, F => F.Id, (U, F) => new { u = U, f = F }).Select(us => new
                    {
                        FilePathName = us.f.FilePath,
                        BlogID = us.u.BlogId
                    }).AsQueryable();

                    // Add image Information in against of Blog
                    lst.ForEach(a =>
                    {
                        var imginfo = lsts.ToList().Where(d => d.BlogID == a.BlogId).ToList();
                        List<string> lstFilepath = new List<string>();
                        foreach (var f in imginfo)
                        {
                            lstFilepath.Add(f.FilePathName);
                        }
                        a.Fileinfo = lstFilepath;
                        //.ForEach(z => a.Fileinfo.Add(z != null ? z.FilePathName : null));
                    });
                }
                else
                {
                    //List of All the Blog Documents
                    var lsts = _db.BlogDocument.Join(_db.FileSetting.Where(z => z.FileType == FileType.BlogImage.ToString()), U => U.FileID, F => F.Id, (U, F) => new { u = U, f = F }).Select(us => new
                    {
                        FilePathName = us.f.FilePath,
                        BlogID = us.u.BlogId
                    }).AsQueryable();

                    // Master Data for Blogs
                    lst = _db.AddBlog.OrderByDescending(z => z.BlogId).ToList();
                    // Add User Information in against of Blog
                    lst.ForEach(a =>
                    {
                        string uid = a.UserID.ToString();
                        var us = GetUserInfo(uid).FirstOrDefault();
                        List<UserRegister> lstUserinfo = new List<UserRegister>();
                        lstUserinfo.Add(new UserRegister
                        {
                            Email = us.Email,
                            FilePathName = us.FilePathName,
                            FirstName = us.FirstName,
                            LastName = us.LastName,
                            Mobile = us.Mobile,
                            RegistrationID = us.RegistrationID,
                            UserName = us.UserName
                        });
                        a.Userinfo = lstUserinfo;
                    });

                    // Add image Information in against of Blog
                    lst.ForEach(a =>
                    {
                        var imginfo = lsts.ToList().Where(d => d.BlogID == a.BlogId).ToList();
                        List<string> lstFilepath = new List<string>();
                        foreach (var f in imginfo)
                        {
                            lstFilepath.Add(f.FilePathName);
                        }
                        a.Fileinfo = lstFilepath;
                        //.ForEach(z => a.Fileinfo.Add(z != null ? z.FilePathName : null));
                    });

                }
                //trans.Complete();
                return lst;
            }
            catch (Exception ex)
            {
                //  trans.Dispose();
                throw ex;
            }
            finally
            {
                // trans.Dispose();
            }
        }

        #region["ForgetPassword"]
        public ReturnValues Consultant(string emailID)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    RepsistoryEF<UserRegister> _o = new global::RepsistoryEF<UserRegister>();
                    ReturnValues ReturnObj;
                    var RegisteredUser = _o.GetListBySelector(z => z.Email == emailID).FirstOrDefault();

                    if (_o.GetListBySelector(z => z.Email == emailID).Any())
                    {
                        reposSendMail o = new reposSendMail();
                        var dd = o.contentBody(RegisteredUser);
                        ReturnObj = new ReturnValues
                      {
                          Success = "Success",
                      };
                        trans.Complete();

                    }
                    else
                    {
                        ReturnObj = new ReturnValues
                        {
                            Success = "Failure",
                        };
                    }
                   return ReturnObj;
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

        #endregion
    }



        #endregion





}

