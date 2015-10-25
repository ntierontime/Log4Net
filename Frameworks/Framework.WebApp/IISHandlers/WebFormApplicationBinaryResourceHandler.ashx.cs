using System;
using System.Web;
using System.IO;

namespace Framework.WebApp.IISHandlers
{
    /// <summary>
	/// The following code from: http://forums.asp.net/t/1210646.aspx
    /// Summary description for ImageHandler
    /// </summary>
    public class WebFormApplicationBinaryResourceHandler : IHttpHandler
    {
        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void ProcessRequest(HttpContext context)
        {
            string sImageFileName = "";

            sImageFileName = context.Request.QueryString["img"];
            System.Drawing.Image objImage = (System.Drawing.Bitmap)Framework.Resources.UIImageResource.ResourceManager.GetObject(sImageFileName);
            
            //log.Info(string.Format("{0}: {1}", Framework.LoggingOptions.BinaryResourceHandler_Request_Process_Started.ToString(), sImageFileName));

            if (objImage != null)
            {
                MemoryStream objMemoryStream = new MemoryStream();
                objImage.Save(objMemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageContent = new byte[objMemoryStream.Length];
                objMemoryStream.Position = 0;
                objMemoryStream.Read(imageContent, 0, (int)objMemoryStream.Length);
                context.Response.ContentType = "image/png";
                context.Response.BinaryWrite(imageContent);
            }

            //log.Info(string.Format("{0}: {1}", Framework.LoggingOptions.BinaryResourceHandler_Request_Process_Ended.ToString(), sImageFileName));
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