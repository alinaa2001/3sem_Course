using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Course
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CListImage clistimage = new CListImage();
        List<string> cat = new List<string>();
        //CFile cfile;

        string path = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //загрузить мем
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();

            path = dlg.FileName;
            Img.Source = new Uri(path, UriKind.Relative);
            
            //image.getImage(Img);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //удалить мем
        {
            if (listMeme.SelectedIndex > -1)
            {
                listMeme.Items.Remove(listMeme.SelectedItem);
                //clistimage.deleteImage(listMeme.SelectedItem.ToString());
                Img.Source = null;
            }
            //Lab.Content = null;
        }
 
        private void Button_Click_5(object sender, RoutedEventArgs e) //??
        {
           
        }
             
        private void listMeme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listMeme.SelectedIndex > -1)
            {
                Uri uri = clistimage.getImage(listMeme.SelectedItem.ToString());
                Img.Source = uri;
              //  Lab.Content = "Мем " + listMeme.SelectedItem.ToString() + " состоит в категории: " + cbCategory.SelectedItem.ToString();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e) //добавить мем в список
        {
            List<string> str = new List<string>();

            // str.Add(cbCategory.SelectedItem.ToString());

            //List<string> listimg = clistimage.findAllImg();

            foreach (string st in listCat2.Items)
            {
                str.Add(st);
                // listMeme.Items.Add(st);
            }

            clistimage.addImage(mName.Text, path, str);
            listMeme.Items.Add(mName.Text);

            listCat2.Items.Clear();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) //добавить категорию
        {
            if (listCat.Items.Contains(catName.Text) == false)
            {
                // if (cbCategory.SelectedIndex > -1)  
                cbCategory.Items.Add(catName.Text);
                cat.Add(catName.Text);


                listCat.Items.Add(catName.Text);
                clistimage.addCategory(catName.Text);
            }
        }
        private void Button_Click_8(object sender, RoutedEventArgs e)   //добавить категорию для одного мема
        {
            //cbCategory.Items.Add(catName.Text);
            //cat.Add(catName.Text);

            //listCat.Items.Add(catName.Text);
            if (cbCategory.SelectedIndex > -1)
            {
                listCat2.Items.Add(cbCategory.SelectedItem.ToString());
            }
            //clistimage.addCategory(catName.Text);
        }   

        private void listCat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listCat.SelectedIndex > -1)
            {
                listMeme.Items.Clear();

                List<string> listimg = clistimage.findByCategory(listCat.SelectedItem.ToString());

                foreach (string str in listimg)
                {
                    listMeme.Items.Add(str);
                }
            }
        }

        private void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
        
        private void Button_Click_6(object sender, RoutedEventArgs e) //удалить категорию
        {
            if (cbCategory.SelectedIndex > -1)
            {
                //clistimage.deleteCategory(cbCategory.SelectedItem.ToString());
                //cat.Remove(cbCategory.SelectedItem.ToString());
                cbCategory.Items.Remove(cbCategory.SelectedItem);
                
                //clistimage.deleteCategory(listCat2.SelectedItem.ToString());
            }
        }

        private void tb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //сохранить список
        {
            CSaveList.saveListImage(clistimage);
            MessageBox.Show("Файл сохранён");
        }
        private void Button_Click_7(object sender, RoutedEventArgs e) //загрузить список
        {
            listMeme.Items.Clear();
            listCat.Items.Clear();
            cbCategory.Items.Clear();

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            string filename = dlg.FileName; // получаем выбранный файл
            string fileText = System.IO.File.ReadAllText(filename); // читаем файл в строку

            clistimage = CSaveList.dowListImage(fileText);

            List<string> listimg = clistimage.findAllImg();

            foreach (string str in listimg)
            {
                listMeme.Items.Add(str);
            }

            List<string> listcat = clistimage.findAllCat();

            foreach (string str in listcat)
            {
                listCat.Items.Add(str);
                cbCategory.Items.Add(str);
            }

            //listMeme.Items.Add(filename);
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
                listMeme.UnselectAll();
                listMeme.Items.Clear();
              
                foreach (CImage img in clistimage.listImage)
                {
                    if (img.name == Search.Text)
                    {
                        listMeme.Items.Add(img.name);
                    }
                }
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            List<string> str = new List<string>();

            //List<string> listimg = clistimage.findAllImg();

            foreach (string st in listCat2.Items)
            {
                str.Add(listCat2.Items.ToString());
               // listMeme.Items.Add(st);
            }

            listMeme.Items.Add(mName.Text);
            clistimage.addImage(mName.Text, path, str);

            listCat2.Items.Clear();
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            //clistimage.deleteCategory(listCat.SelectedItem.ToString());
            listCat.Items.Remove(listCat.SelectedItem);
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            listMeme.Items.Clear();

            foreach (CImage img in clistimage.listImage)
            {
                listMeme.Items.Add(img.name);
            }
        }
    }
}
