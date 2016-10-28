using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.IO;
using smartservicesapp.Model;
using System.Web.Script.Serialization;

namespace smartservicesapp
{
    /// <summary>
    /// Summary description for PicUpload
    /// </summary>
    public class PicUpload : IHttpHandler
    {


        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;
            try
            {
                HttpPostedFile postedFile = context.Request.Files[0];

                string savepath = "";
                string tempPath = "";
                tempPath = "Uploads/ProfilePic";
                savepath = context.Server.MapPath(tempPath);
                string filename = postedFile.FileName;
                if (!Directory.Exists(savepath))
                    Directory.CreateDirectory(savepath);
                Guid objguid = Guid.NewGuid();
                postedFile.SaveAs(savepath + @"\" + filename.Replace(" ", ""));
               
                context.Response.StatusCode = 200;
                string[] keys = context.Request.Form.AllKeys;
                Service s = new Service();

                UserRegister ur = new UserRegister();
                ur.FirstName = context.Request.Form["FirstName"];
                ur.LastName= context.Request.Form["LastName"];
                ur.Email= context.Request.Form["Email"];
                ur.UserName= context.Request.Form["UserName"];
                ur.Password= context.Request.Form["Password"];
                ur.Mobile= context.Request.Form["Mobile"];
                byte[] fileData = null;
                using (var binaryReader = new BinaryReader( context.Request.InputStream))
                {
                    fileData = binaryReader.ReadBytes(context.Request.Files[0].ContentLength);
                }
                ur.FileName = fileData;
          //     s.RegisterUser(ur);
              ur.FirstName = Convert.ToBase64String(fileData);
           
               
                //foreach (string fileName in context.Request.Files)
                //{
                //    HttpPostedFile file = context.Request.Files[fileName];


                //}
               // System.Drawing.Bitmap originalImage = new System.Drawing.Bitmap(context.Request.Files[0].InputStream);
             string base64= SaveImage(context.Request.Files[0], 250, 250, "Uploads/ProfilePic", context, filename);
                context.Response.Write(base64);
            }
            catch (Exception ex)
            {
                context.Response.Write("Error: " + ex.Message);
            }
        }




        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public string SaveImage(HttpPostedFile postedFile, int maxWidth, int maxHeight, string savelocation, HttpContext context, string filename)
        {

            System.Drawing.Bitmap originalImage = new System.Drawing.Bitmap(postedFile.InputStream);
            int newWidth = originalImage.Width;
            int newHeight = originalImage.Height;
            double aspectRatio = (double)originalImage.Width / (double)originalImage.Height;

            if (newWidth < maxWidth && newHeight < maxHeight)
            {

            }
            else if (newWidth < maxWidth && newHeight > maxHeight)
            {
                newWidth = maxWidth;
                newHeight = (int)Math.Round(newWidth / aspectRatio);
                if (newHeight > maxHeight)
                {
                    newHeight = maxHeight;
                    newWidth = (int)Math.Round(newHeight * aspectRatio);

                }
            }
            else if (newWidth > maxWidth && newHeight < maxHeight)
            {
                newHeight = maxHeight;
                newWidth = (int)Math.Round(newHeight * aspectRatio);
                if (newWidth > maxWidth)
                {
                    newWidth = maxWidth;
                    newHeight = (int)Math.Round(newWidth / aspectRatio);
                }
            }
            else if (newWidth > maxWidth && newHeight > maxHeight)
            {
                newWidth = maxWidth;
                newHeight = (int)Math.Round(newWidth / aspectRatio);
                if (newHeight > maxHeight)
                {
                    newHeight = maxHeight;
                    newWidth = (int)Math.Round(newHeight * aspectRatio);

                }

                newHeight = maxHeight;
                newWidth = (int)Math.Round(newHeight * aspectRatio);
                if (newWidth > maxWidth)
                {
                    newWidth = maxWidth;
                    newHeight = (int)Math.Round(newWidth / aspectRatio);
                }
            }


            var image = System.Drawing.Image.FromStream(postedFile.InputStream);
            var thumbnailBitmap = new System.Drawing.Bitmap(newWidth, newHeight);
            var thumbnailGraph = System.Drawing.Graphics.FromImage(thumbnailBitmap);
            thumbnailGraph.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            thumbnailGraph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            thumbnailGraph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            var imageRectangle = new System.Drawing.Rectangle(0, 0, newWidth, newHeight);
            
            thumbnailGraph.DrawImage(image, imageRectangle);
            string base64String;
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                     base64String = Convert.ToBase64String(imageBytes);
                 
                }
            

            thumbnailBitmap.Save(context.Server.MapPath(savelocation + "/" + filename), image.RawFormat);

            thumbnailGraph.Dispose();
            thumbnailBitmap.Dispose();
            image.Dispose();
            return base64String;
        }

    }
}