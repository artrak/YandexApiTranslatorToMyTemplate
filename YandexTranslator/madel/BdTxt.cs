using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YandexTranslator.madel
{
    class BdTxt
    {
        //static string writePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"db_result.txt";
        //static string readPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"db_source.txt";

        static string writePath = @"C:\YandexTranslatorBd\db_result.txt";
        static string readPath = @"C:\YandexTranslatorBd\db_source.txt";
        static string endString = "\r\n";

        // запись в файл
        public static void writeMsg(string msg)
        {
            try
            {
                using (StreamWriter file = new StreamWriter(writePath, true, Encoding.UTF8))
                {
                    file.WriteLine(msg);
                }
            }
            catch (Exception ex)
            {
                Thread.Sleep(1000);
                writeMsg(msg);
            }
        }

        // чтение из файла
        public static List<string> readMsg()
        {
            List<string> listBD = new List<string>();
            try
            {
                using (StreamReader file = new StreamReader(readPath, Encoding.UTF8))
                {
                    for (int i = 0; i < 528; i++)
                    {
                        listBD.Add(file.ReadLine());
                    }
                }               
            }
            catch (Exception)
            {
                Thread.Sleep(1000);
                readMsg();
            }
            return listBD;
        }
    }
}
