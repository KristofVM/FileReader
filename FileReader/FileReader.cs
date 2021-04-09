using Newtonsoft.Json;
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

        #region Version 3
        /// <summary>
        /// Returns and Decripts the content of the file by a given decryption algorithm.
        /// </summary>
        /// <param name="filePath">The full path where the file is located.</param>
        /// <param name="decryptionAlg">The decryption algorithm that is to be used to decrypt the file.</param>
        /// <returns>A decrypted string of the file content.</returns>
        public static string ReadTxt(string filePath, Func<string, string> decryptionAlg)
            => decryptionAlg.Invoke(ReadTxt(filePath));
        #endregion

        #region Version 5
        /// <summary>
        /// Returns and decrypts the content of an xml file as T
        /// </summary>
        /// <typeparam name="T">The type that is to be returned</typeparam>
        /// <param name="filePath">The location of the file</param>
        /// <param name="decryptionAlg">The decryption algorithm that is to be used.</param>
        /// <returns>the content of the XML file as Type T</returns>
        public static T ReadXML<T>(string filePath, Func<string, string> decryptionAlg)
        {
            var xmlDecrypted = ReadTxt(filePath, decryptionAlg);

            byte[] byteArray = Encoding.ASCII.GetBytes(xmlDecrypted);
            MemoryStream stream = new MemoryStream(byteArray);

            return (T)new XmlSerializer(typeof(T)).Deserialize(stream);
        }
        #endregion

        #region Version 7
        /// <summary>
        /// Method wil read and return the content of a JSON file as T.
        /// </summary>
        /// <typeparam name="T">The type that is to be returned.</typeparam>
        /// <param name="filePath">The full path where the file is located.</param>
        /// /// <param name="decryptionAlg">The decryption algorithm that is to be used.</param>
        /// <returns>The content of a JSON file as T.</returns>
        public static T ReadJson<T>(string filePath)
            => JsonConvert.DeserializeObject<T>(ReadTxt(filePath));
        #endregion 
    }
}
