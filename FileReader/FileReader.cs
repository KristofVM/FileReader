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
    }
}
