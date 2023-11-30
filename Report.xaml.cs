using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using Path = System.IO.Path;

namespace laba52
{
    /// <summary>
    /// Логика взаимодействия для Report.xaml
    /// </summary>
    public partial class Report : Page
    {
        public Report()
        {
            InitializeComponent();
        }


        static string dataForTitle;
        public Report(object data) : this()
        {
            if ((data as ListBoxItem).Content.ToString() == "Три товарища")
            {

                string pdfFilePath = "\\\\Mac\\Home\\Documents\\Programming\\Interface\\laba52\\data\\three.txt";
                dataForTitle = (data as ListBoxItem).Content.ToString();
                try
                {
                    using (StreamReader sr = new StreamReader(pdfFilePath))
                    {
                        string pdfContent = sr.ReadToEnd();
                        int numberOfChapters = CountChapters(pdfContent);
                        Console.WriteLine($"Количество глав: {numberOfChapters}");
                        //Console.WriteLine(pdfContent);

                        //Получите ваш ListBox
                        ListBox listBox = lbTitle;

                        //Очистите ListBox перед добавлением новых элементов
                        listBox.Items.Clear();

                        for (int i = 1; i <= numberOfChapters; i++)
                        {
                            ListBoxItem newItem = new ListBoxItem();
                            newItem.Content = $"Глава {i}";
                            listBox.Items.Add(newItem);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
           
            if ((data as ListBoxItem).Content.ToString() == "Автостопом по галактике")
            {
                
                string pdfFilePath = "\\\\Mac\\Home\\Documents\\Programming\\Interface\\laba52\\data\\avtostop.txt";
                dataForTitle = (data as ListBoxItem).Content.ToString();
                try
                {
                    using (StreamReader sr = new StreamReader(pdfFilePath))
                    {
                        string pdfContent = sr.ReadToEnd();
                        int numberOfChapters = CountChapters(pdfContent);
                        //Console.WriteLine($"Количество глав: {numberOfChapters}");
                        //Console.WriteLine(pdfContent);

                        //Получите ваш ListBox
                        ListBox listBox = lbTitle;

                        //Очистите ListBox перед добавлением новых элементов
                        listBox.Items.Clear();

                        for (int i = 1; i <= numberOfChapters; i++)
                        {
                            ListBoxItem newItem = new ListBoxItem();
                            newItem.Content = $"Глава {i}";
                            listBox.Items.Add(newItem);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
            //lbTitle. = data is ListBoxItem ? (data as ListBoxItem).Content.ToString() : "Ничего";
        }
        // Получите ваш ListBox
       
        static int CountChapters(string content)
        {
            Regex regex = new Regex(@"Глава \d+", RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(content);

            // Возвращаем количество найденных глав
            return matches.Count;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Title titlePage = new Title(this.lbTitle.SelectedItem, dataForTitle);
            this.NavigationService.Navigate(titlePage);
        }
    }
}
