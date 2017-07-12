using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace YandexTranslator
{
    class TestJson
    {
        [JsonObject(MemberSerialization.OptIn)]
        struct MyJsonObject
        {
            [JsonProperty("zayavki")]
            public string Uuid { get; set; }

            [JsonProperty("date")]
            public DateTime Date { get; set; }

            [JsonProperty("comment")]
            public string Comment { get; set; }

            [JsonProperty("firm_id")]
            public string FirmID { get; set; }
        }

        public TestJson()
        {
            string s = "";
            string line = "{\"head\":{},\"def\":[{\"text\":\"dog\",\"pos\":\"noun\",\"ts\":\"dɔg\",\"tr\":[{\"text\":\"собака\",\"pos\":\"noun\",\"gen\":\"ж\",\"syn\":[{\"text\":\"пес\",\"pos\":\"noun\",\"gen\":\"м\"},{\"text\":\"собачка\",\"pos\":\"noun\",\"gen\":\"ж\"},{\"text\":\"псина\",\"pos\":\"noun\",\"gen\":\"ж\"}],\"mean\":[{\"text\":\"hound\"},{\"text\":\"doggy\"}],\"ex\":[{\"text\":\"dog show\",\"tr\":[{\"text\":\"выставка собак\"}]},{\"text\":\"large breed dogs\",\"tr\":[{\"text\":\"собаки крупных пород\"}]},{\"text\":\"pack of stray dogs\",\"tr\":[{\"text\":\"стая бродячих собак\"}]},{\"text\":\"dog of medium size\",\"tr\":[{\"text\":\"собака среднего размера\"}]},{\"text\":\"wild dog\",\"tr\":[{\"text\":\"дикая собака\"}]},{\"text\":\"big black dog\",\"tr\":[{\"text\":\"большой черный пес\"}]},{\"text\":\"prairie dog\",\"tr\":[{\"text\":\"луговая собачка\"}]},{\"text\":\"wet dog\",\"tr\":[{\"text\":\"мокрая псина\"}]}]},{\"text\":\"кобель\",\"pos\":\"noun\",\"gen\":\"м\",\"mean\":[{\"text\":\"male\"}],\"ex\":[{\"text\":\"stud dog\",\"tr\":[{\"text\":\"племенной кобель\"}]}]}]},{\"text\":\"dog\",\"pos\":\"verb\",\"ts\":\"dɔg\",\"tr\":[{\"text\":\"выслеживать\",\"pos\":\"verb\",\"asp\":\"несов\",\"syn\":[{\"text\":\"преследовать\",\"pos\":\"verb\",\"asp\":\"несов\"}],\"mean\":[{\"text\":\"track\"},{\"text\":\"pursue\"}]}]},{\"text\":\"dog\",\"pos\":\"adjective\",\"ts\":\"dɔg\",\"tr\":[{\"text\":\"собачий\",\"pos\":\"adjective\",\"mean\":[{\"text\":\"canine\"}],\"ex\":[{\"text\":\"sled dog race\",\"tr\":[{\"text\":\"гонка на собачьих упряжках\"}]}]}]}]}";
                        
            if (line != null)
            {
                Translation translation = JsonConvert.DeserializeObject<Translation>(line);

                string eng = translation.def[0].text.ToString();
                string rus = translation.def[0].tr[0].text.ToString();
                string transklr = translation.def[0].ts.ToString();
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
}

