using FileJump.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace FileJump
{
    public static class FileHandler
    {
        public static bool FileExists(string filePath)
        {
            if (File.Exists(filePath))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Saves the file to the local storage
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="fStruct"></param>
        public static void SaveFileToLocalStorage(byte[] buffer, LocalFileStructure fStruct)
        {
            string fullName = fStruct.FileName + fStruct.FileExtension;
            string filePath = Path.Combine(ProgramSettings.StorageFolderPath, fullName);

            filePath = GetValidFileName(filePath);

            using (Stream file = File.OpenWrite(filePath))
            {
                file.Write(buffer, 0, buffer.Length);
            }
        }

        /// <summary>
        /// Adds a new message to the database
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="date"></param>
        public static void AddNewMessageToXML(string msg, string date)
        {
            XDocument doc = XDocument.Load(Path.Combine(Directory.GetCurrentDirectory(), "XmlDatabase.xml"));

            XElement Messages = doc.Element("Messages");
            int count = doc.Descendants("Message").Count();

            
            Messages.Add(new XElement("Message",
                         new XElement("Date", date),
                         new XElement("Text", msg),
                         new XElement("id", count)));

            doc.Save(Path.Combine(Directory.GetCurrentDirectory(), "XmlDatabase.xml"));
            
        }

        public static void RemoveXmlDatabaseElement(int id)
        {
            List<TextMessage> list = ReadXmlDatabase();

            ClearXmlDatabase();

            foreach(TextMessage t in list)
            {
                if(t.ID != id)
                {
                    AddNewMessageToXML(t.Message, t.DateSent);
                }
            }
        }

        private static void ClearXmlDatabase()
        {
            XDocument xml = XDocument.Load(Path.Combine(Directory.GetCurrentDirectory(), "XmlDatabase.xml"));
            XElement Messages = xml.Element("Messages");
            xml.Descendants("Message").Remove();
            xml.Save(Path.Combine(Directory.GetCurrentDirectory(), "XmlDatabase.xml"));
            //Messages.RemoveAll();
            //xml.Element("Messages").RemoveAll();
        }

        /// <summary>
        /// Returns a TextMessage list with the contents of the database
        /// </summary>
        /// <returns></returns>
        public static List<TextMessage> ReadXmlDatabase()
        {
            XDocument xml = XDocument.Load(Path.Combine(Directory.GetCurrentDirectory(), "XmlDatabase.xml"));

            List<TextMessage> list = new List<TextMessage>();
            List<XElement> s =  xml.Descendants("Message").ToList();
           
            
            var elementsList = from b in xml.Descendants("Message")
                    select new
                    {
                        Date = (string)b.Element("Date") ?? "Unaviable date",
                        Text = (string)b.Element("Text") ?? "-NO TEXT-",
                        ID = (int)b.Element("id")
                    };

            //var node = xml.Elements().Where(x => x.Element("Text"))

            foreach(var el in elementsList)
            {
                list.Add(new TextMessage(
                    el.Date, el.Text, el.ID));
            }

            return list;
        }

      

        public static string GetValidFileName(string filePath)
        {
            if (File.Exists(filePath))
            {
                string folderPath = Path.GetDirectoryName(filePath);
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                string fileExtension = Path.GetExtension(filePath);
                int number = 1;

                Match regex = Regex.Match(fileName, @"^(.+) \((\d+)\)$");

                if (regex.Success)
                {
                    fileName = regex.Groups[1].Value;
                    number = int.Parse(regex.Groups[2].Value);
                }

                do
                {
                    number++;
                    string newFileName = $"{fileName} ({number}){fileExtension}";
                    filePath = Path.Combine(folderPath, newFileName);
                }
                while (File.Exists(filePath));
            }

            return filePath;
        }

        private static bool HasWriteAccessToFolder(string folderPath)
        {
            try
            {
                // Attempt to get a list of security permissions from the folder. 
                // This will raise an exception if the path is read only or do not have access to view the permissions. 
                System.Security.AccessControl.DirectorySecurity ds = Directory.GetAccessControl(folderPath);
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
        }
    }
}
