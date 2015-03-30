using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinanceManager.CommonClasses
{
    public static class FileWorker
    {
        public static string SaveUserPhoto(byte[] photo, string imgFormat, string login)
        {        
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "Resources\\UsersFiles\\" + login + "\\"; ;
            string a = AppDomain.CurrentDomain.DynamicDirectory;
            string relationalPath = "/Resources/UsersFiles/" + login + "/";
           
           // string filePath = Request.PhysicalApplicationPath + "Resources\\UsersFiles\\" + login + "\\";
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            string name = "avatar." + imgFormat;
            using (var imageFile = new FileStream(filePath + name, FileMode.Create))
            {
                imageFile.Write(photo, 0, photo.Length);
                imageFile.Flush();
            }

            return relationalPath + name;
        }
    }
}