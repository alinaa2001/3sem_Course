using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Course
{
    [DataContract]
    public class CImage
    {
        [DataMember]
        public string path { get; set; }
        [DataMember]
        public string name { get; set; } //отображаемое имя
        [DataMember]
        public int number { get; set; }
        [DataMember]
        List<string> category = new List<string>();

        //string name = GetFileName(path);

        public CImage(string name, string path, List<string> category)
        {
            this.name = name;
            this.path = path;
            this.category = category;
            number = GUID.getGUID();
        }

        public Uri getImage()
        {
            return new Uri(path, UriKind.Relative);
        }
        public List<string> getCategory()
        {
            return category;
        }

    }
}
