using System;
using FileReadingLibrary;
using Newtonsoft.Json.Linq;

namespace FileReader.test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello welcome to the fileReader Application.");
            bool stop = false;
            while (!stop)
            {
                Console.WriteLine("What file would you like to read?");
                string fileName = Console.ReadLine();

                Console.WriteLine("Do you want to read a Txt, Json or an XML?");
                string fileType = Console.ReadLine().ToUpper();
                if (fileType != "XML" || fileType != "JSON" || fileType != "TXT")
                {
                    Console.WriteLine("Filetype incorrect.");
                    Console.WriteLine("What file would you like to read?");
                }

                Console.WriteLine("Do you want to read an encrypted file? Y/N");
                string encryptedres = Console.ReadLine().ToUpper();

                if (encryptedres != "Y" && encryptedres != "N")
                {
                    Console.WriteLine("Sorry I did not understand");
                    Console.WriteLine("What file would you like to read?");
                    encryptedres = Console.ReadLine().ToUpper();
                }

                bool encrypted = encryptedres == "Y";
                string content = "";
                switch (fileType)
                {
                    case "XML":
                        {
                            if (encrypted)
                                content = FileReadingLibrary.FileReader.ReadXML<dynamic>(fileName, str => str.ToUpper()).ToString();
                            else
                                content = FileReadingLibrary.FileReader.ReadXML<dynamic>(fileName).ToString();
                        }
                        break;
                    case "JSON":
                        {
                            if (encrypted)
                                content = FileReadingLibrary.FileReader.ReadJson<dynamic>(fileName, str => str.ToUpper()).ToString();
                            else
                                content = FileReadingLibrary.FileReader.ReadJson<dynamic>(fileName).ToString();
                        }
                        break;
                    case "TXT":
                        {
                            if (encrypted)
                                content = FileReadingLibrary.FileReader.ReadTxt(fileName, str => str.ToUpper());
                            else
                                content = FileReadingLibrary.FileReader.ReadTxt(fileName);
                        }
                        break;
                }

                Console.WriteLine(content);
                Console.WriteLine("Do you want to continue? Y/N");
                string result = Console.ReadLine().ToUpper();
                if (result == "N")
                    stop = true;
            }
        }
    }
}

