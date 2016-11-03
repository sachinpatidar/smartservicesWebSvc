using smartservicesapp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smartservicesapp
{
    /// <summary>
    /// Summary description for GetPicHandler
    /// </summary>
    public class GetPicHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;
            //try
            //{             
            //    Service s = new Service();
            //    string FileID = context.Request.Form["FileID"];
            //    var fileInfo=s.GetfileInfo(FileID);

            //    foreach(var f in fileInfo)
            //    {
            //        string base64String = Convert.ToBase64String(f.File);

            //    }



            //    byte[] fileData = null;
            //    using (var binaryReader = new BinaryReader(context.Request.InputStream))
            //    {
            //        fileData = binaryReader.ReadBytes(context.Request.Files[0].ContentLength);
            //    }
            //    ur.FileName = fileData;
            //    s.RegisterUser(ur);


            //    Repository.ResizeImage ri = new Repository.ResizeImage();

            //    string base64 = ri.SaveImage(context.Request.Files[0].InputStream, 250, 250, "Uploads/ProfilePic", context, filename);



            //    context.Response.Write(base64);
            //}
            //catch (Exception ex)
            //{
            //    context.Response.Write("Error: " + ex.Message);
            //}
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}