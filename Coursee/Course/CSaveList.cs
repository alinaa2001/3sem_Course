using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
//using System.Text.Json;
//using System.Text.Json.Serialization;


namespace Course
{
    public static class CSaveList
    {
        //public void Serializ()
        //{
        //    var enviromentConstans = new EnvironmentConstans();
        //    string jsonString  JsonSerializer.Serialize(CImage);
        //    File.WriteAllText("ListImage.json", jsonString);
        //}
        //public void save()
        //{

        //}

        //JsonSerializer serializer = new JsonSerializer(typeof(CListImage)); // передаем в конструктор тип класса

        static DataContractJsonSerializer jsonF = new DataContractJsonSerializer(typeof(CListImage));
        

        //string jsonString = JsonSerializer.Serialize(CImage);
        public static void saveListImage(CListImage listImage)
        {
            //json xml
            //serialization deserialization

            using (FileStream fs = new FileStream("ListImage.json", FileMode.OpenOrCreate)) // получаем поток, куда будем записывать сериализованный объект
            { 
                jsonF.WriteObject(fs, listImage);
            }
        }

        public static CListImage dowListImage(string json)
        {
           // jsonData = "{\"name\":[{\"last\":\"Smith\"},{\"last\":\"Doe\"}]}";

            var deserializedList = new CListImage();

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            var ser = new DataContractJsonSerializer(deserializedList.GetType());
            deserializedList = ser.ReadObject(ms) as CListImage;
            ms.Close();

            return deserializedList;
        }


    }
}
