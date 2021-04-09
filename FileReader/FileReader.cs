﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace FileReadingLibrary
{
    public static class FileReader
    {
        #region Version 1
        /// <summary>
        /// Method will read and return the content of a given file.
        /// </summary>
        /// <param name="filePath">The full path where the file is located.</param>
        /// <returns>The content of the requested file.</returns>
        public static string ReadTxt(string filePath)
        {
            File.ReadAllLines(filePath);
            return File.ReadAllText($@"{filePath}");
        }

        #endregion

        #region Version 2
        /// <summary>
        /// Method wil read and return the content of an XML file as T.
        /// </summary>
        /// <typeparam name="T">The type that is to be returned.</typeparam>
        /// <param name="filePath">The full path where the file is located.</param>
        /// <returns>The content of an XML file as T.</returns>
        public static T ReadXML<T>(string filePath)
        {
            using Stream reader = new FileStream($@"{filePath}", FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            var serialzeResult = (T)serializer.Deserialize(reader);

            return serialzeResult;
        }
        #endregion
    }
}
