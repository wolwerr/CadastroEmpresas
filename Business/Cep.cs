using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.IO;
using System.Web.Script.Serialization;


namespace Business
{
    public class Cep
    {
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public static Cep Busca(string cep)
        {
           
           var cepObj = new Cep();
           var url = "https://www.receitaws.com.br/v1/cnpj/" + cep;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            string json = string.Empty;
            using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using(Stream stream = response.GetResponseStream())
            using(StreamReader reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }

            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            JsonCepObject cepJson = json_serializer.Deserialize<JsonCepObject>(json);

            cepObj.CEP = cepJson.code;
            cepObj.Endereco = cepJson.address;
            cepObj.Endereco = cepJson.district;
            cepObj.Endereco = cepJson.city;
            cepObj.Endereco = cepJson.state;
           return cepObj;
         }
    }

    public class JsonCepObject
    {
        public string code { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string address { get; set; }

    }
}