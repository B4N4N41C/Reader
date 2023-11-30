using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace laba52
{
    /// <summary>
    /// Логика взаимодействия для Title.xaml
    /// </summary>
    public partial class Title : Page
    {
        public Title()
        {
            InitializeComponent();
        }
        public Title(object data, string book) : this()
        {
            if (book == "Три товарища")
            {
                string pdfFilePath = "\\\\Mac\\Home\\Documents\\Programming\\Interface\\laba52\\data\\three.txt";
                string title = (data as ListBoxItem).Content.ToString();
                string[] selectTitle = title.Split(' ');

                int numberSelectTitle;
                if (int.TryParse(selectTitle[1], out numberSelectTitle))
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(pdfFilePath))
                        {

                            var myTextBlock = this.tbText;
                            string pdfContent = sr.ReadToEnd();
                            string[] separator = { "\r\n", " " };
                            string[] str = pdfContent.Split(separator, StringSplitOptions.None);

                            //Console.WriteLine($"Количество глав: {numberOfChapters}");
                            //Console.WriteLine(pdfContent);
                            int numberOfTitle;
                            for (int i = 0; i < str.Count() - 1; i++)
                            {
                                if (str[i] == "Глава" && int.TryParse(str[i + 1], out numberOfTitle))
                                {
                                    if (numberOfTitle == numberSelectTitle)
                                    {
                                        for (int j = i + 2; j < str.Count() - 1; j++)
                                        {
                                            if (str[j] != "Глава" || !int.TryParse(str[j + 1], out int gg))
                                            {
                                                myTextBlock.Text += str[j] + ' ';
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }
                }
            }



            if (book == "Автостопом по галактике") { 
            string pdfFilePath = "\\\\Mac\\Home\\Documents\\Programming\\Interface\\laba52\\data\\avtostop.txt";
            string title = (data as ListBoxItem).Content.ToString();
            string[] selectTitle = title.Split(' ');

            int numberSelectTitle;
                if (int.TryParse(selectTitle[1], out numberSelectTitle))
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(pdfFilePath))
                        {

                            var myTextBlock = this.tbText;
                            string pdfContent = sr.ReadToEnd();
                            string[] separator = { "\r\n", " " };
                            string[] str = pdfContent.Split(separator, StringSplitOptions.None);

                            //Console.WriteLine($"Количество глав: {numberOfChapters}");
                            //Console.WriteLine(pdfContent);
                            int numberOfTitle;
                            for (int i = 0; i < str.Count() - 1; i++)
                            {
                                if (str[i] == "Глава" && int.TryParse(str[i + 1], out numberOfTitle))
                                {
                                    if (numberOfTitle == numberSelectTitle)
                                    {
                                        for (int j = i + 2; j < str.Count() - 1; j++)
                                        {
                                            if (str[j] != "Глава" || !int.TryParse(str[j + 1], out int gg))
                                            {
                                                myTextBlock.Text += str[j] + ' ';
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }
                }
            }
        }
    }
}
