using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace Course
{
    [Serializable]
    public class CListImage
    {
        [DataMember]
        public List<CImage> listImage = new List<CImage>();
        [DataMember]
        public List<string> listCategory = new List<string>();



        public void addImage(string name, string path, List<string> category)
        {
            CImage image = new CImage(name, path, category);
            listImage.Add(image);
        }
        public void addCategory(string nameCategory)
        {
            listCategory.Add(nameCategory);
        }
        public bool deleteImage(string name)
        {
            foreach(CImage num in listImage)
            {
                if(num.name == name)
                {
                    listImage.Remove(num);
                    return true;
                }
            }
            return false;
        }
        public bool deleteCategory(string nameCat)
        {
            foreach (string num in listCategory)
            {
                if (num == nameCat)
                {
                    listCategory.Remove(num);
                    return true;
                }
            }
            return false;
        }

        public List<CImage> dowListImage(string path) //загрузить списки
        {
            return listImage;
        }

        public List<CImage> saveListImage(string path) 
        {
            return listImage;
        }

        public Uri getImage(string name)
        {
            foreach(CImage img in listImage)
            {
                if (img.name == name)
                    return img.getImage();
            }

            return null;
        }

        public List<string> findByCategory(string cat) //поиск по категории
        {
            List<string> listcat = new List<string>();

            foreach (CImage img in listImage)
            {
                if (img.getCategory().Contains(cat) == true)
                {
                    listcat.Add(img.name);
                }    
            }
            return listcat;
        }

        public List<string> findAllImg() 
        {
            List<string> listimg = new List<string>();

            foreach (CImage img in listImage)
            {
                listimg.Add(img.name);
            }
            return listimg;
        }
        
       
        public List<string> findAllCat()
        {
            List<string> listcat = new List<string>();

            foreach (CImage cat in listImage)
            {
                List<string> liststr = cat.getCategory();
                foreach(string str in liststr)
                if (listcat.Contains(str) == false)
                    {
                        listcat.Add(str);
                    }
            }
            return listcat;
        } 
    }
}
