using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinanceManager.CommonClasses
{
    /// <summary>
    /// Класс для работы с файлами
    /// </summary>
    public static class FileWorker
    {
        /// <summary>
        /// Сохранение картинки на сервере
        /// </summary>
        /// <param name="photo">Картинка</param>
        /// <param name="imgFormat">Формат картинки</param>
        /// <param name="login">Логин пользователя</param>
        /// <returns>Возвращает относительный путь, для возможности отображения картинки в браузере</returns>
        public static string SaveUserPhoto(byte[] photo, string imgFormat, string login)
        {        
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "Resources\\UsersFiles\\" + login + "\\";
            string relationalPath = "/Resources/UsersFiles/" + login + "/";
           
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