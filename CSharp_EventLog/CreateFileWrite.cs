using System.IO;

namespace CSharp_EventLog
{
    class CreateFileWrite
    {
        public static void CreateFile(string fileName)
        {
            using (FileStream fs = File.Create(fileName))
            {
                
            }
        }

        public static void WriteFile(string fileName, string content)
        {
            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
                sw.WriteLine(content);
            }
        }
    }
}
