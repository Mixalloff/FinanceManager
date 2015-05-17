using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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
        /// <param name="imgName">Название картинки</param>
        /// <param name="innerPath">Название папки внутри пользовательских файлов</param>
        /// <returns>Возвращает относительный путь, для возможности отображения картинки в браузере</returns>
        private static string SaveUserPhoto(byte[] photo, string imgFormat, string login, string imgName, string innerPath = "")
        {
            innerPath = innerPath == "" ? "" : innerPath + "\\";
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "Resources\\UsersFiles\\" + login + "\\" + innerPath;
           // innerPath = innerPath.Substring(0, innerPath.IndexOf("\\"));
            string relationalPath = "\\Resources\\UsersFiles\\" + login + "\\"+ innerPath;
           
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            string name = imgName + "." + imgFormat;
            using (var imageFile = new FileStream(filePath + name, FileMode.Create))
            {
                imageFile.Write(photo, 0, photo.Length);
                imageFile.Flush();
            }

            return relationalPath + name;
        }

        /// <summary>
        /// Получение имени сохраненного изображения по строке base64
        /// </summary>
        /// <param name="photo">base64 закодированнаое изображение</param>
        /// <param name="login">Логин пользователя</param>
        /// <param name="imgName">Имя сохраняемого изображения</param>
        /// <param name="innerPath">Название папки внутри пользовательских файлов</param>
        /// <returns>Имя сохраненного изображения</returns>
        public static string GetSavePhoto(string photo, string login, string imgName, string innerPath="")
        {
            MatchCollection matches = new Regex("data:image/(?<format>.*);base64,").Matches(photo);
            if (matches[0].Groups["format"].Success)
            {
                var imgFormat = matches[0].Groups["format"].Value;
                photo = photo.Substring(matches[0].Groups[0].Length);
                var base64str = System.Convert.FromBase64String(photo);

                return SaveUserPhoto(base64str, imgFormat, login, imgName, innerPath);
            }
            return null;
        }
    }
}