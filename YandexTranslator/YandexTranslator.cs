using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using YandexTranslator.madel;

namespace YandexTranslator
{
    class YandexTranslator
    {
        public void Work()
        {
            string lineStr = "";            
            
            List<string> listBD = BdTxt.readMsg();

            foreach (var item in listBD)
            {
                lineStr = Translate(item, "en-ru");
                BdTxt.writeMsg(lineStr);
            }
            
            bool zend = true;          
        }


        public string Translate(string s, string lang)
        {          
            if (s.Length > 0)
            {
                WebRequest request = WebRequest.Create("https://dictionary.yandex.net/api/v1/dicservice.json/lookup?"
                    + "key=dict.1.1.20170710T113049Z.e66d5d6de9b802fc.bc0676632d584fa4c3bf7d7f2230ea4cfe244586"
                    + "&text=" + s
                    + "&lang=" + lang);

                //WebProxy myproxy = new WebProxy("89.40.116.171", 8080);
                WebProxy myproxy = new WebProxy("46.101.105.245", 3128);
                myproxy.BypassProxyOnLocal = false;
                request.Proxy = myproxy;
                request.Method = "GET";

                WebResponse response = request.GetResponse();
                
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {

                    string line;

                    if ((line = stream.ReadLine()) != null)
                    {
                        Translation translation = JsonConvert.DeserializeObject<Translation>(line);

                        string eng;
                        string rus;
                        string transklr;
                        try
                        {
                            eng = translation.def[0].text.ToString();
                            rus = translation.def[0].tr[0].text.ToString();
                            transklr = translation.def[0].ts.ToString();
                        }
                        catch (Exception)
                        {
                            return null;
                        }                       

                        return ConvertToLine(eng, rus, transklr);
                    }
                }

                return "";
            }
            else
                return "";
        }

        private string ConvertToLine(string eng, string rus, string transklr)
        {
            string result = "addWordtoArr(\""  + eng + "\", \"[" + transklr + "]\", \"" + rus + "\", \"\", R.raw.emoticon__en_1, \"[" + transklr + "]\")";

            return result;
        }
    }
    
    class Translation
    {
        public object head { get; set; }
        public def[] def { get; set; }
    }

    class def
    {
        public string text { get; set; }
        public string pos { get; set; }
        public string ts { get; set; }
        public tr[] tr { get; set; }
    }

    class tr
    {
        public string text { get; set; }
        public string pos { get; set; }
        public string gen { get; set; }
        public _syn[] syn { get; set; }
    }

    class _syn
    {
        public string text { get; set; }
        public string pos { get; set; }
        public string gen { get; set; }
    }
}
