using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.IO;

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
                postedFile.SaveAs(savepath + @"\" + context.Request.Params[0] + filename.Replace(" ", ""));
                context.Response.Write(objguid + filename.Replace(" ", ""));
                context.Response.StatusCode = 200;
             
         string Email = context.Request.Params["data"];

                context.Response.Write("email:" + Email);
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
        public void SaveImage(HttpPostedFile postedFile, int maxWidth, int maxHeight, string savelocation, HttpContext context, string filename)
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


            thumbnailBitmap.Save(context.Server.MapPath(savelocation + "/" + filename), image.RawFormat);

            thumbnailGraph.Dispose();
            thumbnailBitmap.Dispose();
            image.Dispose();
        }

    }
}