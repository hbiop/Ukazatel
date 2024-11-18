using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Ukazatel
{
    /// <summary>
    /// Логика взаимодействия для DobavitUkazatel.xaml
    /// </summary>
    public partial class DobavitUkazatel : Window
    {
        public DobavitUkazatel()
        {
            InitializeComponent();
        }

        private void BtnSohranit(object sender, RoutedEventArgs e)
        {
            string[] stranici = tbStranici.Text.Split(',');
            int[] straniciInt = new int[stranici.Length];
            int index = -1;
            bool tryParseResult = true;
            foreach (var stranica in stranici) 
            {
                tryParseResult = int.TryParse(stranica, out int stranicaInt);
                if (tryParseResult == false) 
                {
                    break;
                }
                straniciInt[++index] = stranicaInt;
            }
            if(tryParseResult == false || stranici.Length == 0)
            {
                MessageBox.Show("Не все страницы были числами");
            }
            else
            {
                if(tbSlovo.Text == "")
                {
                    MessageBox.Show("Введите слово");
                }
                else
                {
                    string soobshenie = PredmetniyUkazatel.DobavitUkazatel(tbSlovo.Text, straniciInt);
                    MessageBox.Show(soobshenie);
                }
            }
        }

        private void BtnBack(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void BtnVvodIzFaila(object sender, RoutedEventArgs e)
        {
            try
            {
                string putFaila = null;
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                {
                    putFaila = openFileDialog.FileName;
                }
                if (putFaila != null)
                {   
                    using (StreamReader reader = new StreamReader(putFaila))
                    {
                        string line = reader.ReadLine();
                        if(line != null)
                        {
                            var parts = line.Split(';');
                            if (parts.Length != 2)
                            {
                                MessageBox.Show("Формат ввода был не верный");
                            }
                            else
                            {
                                tbSlovo.Text = parts[0];
                                tbStranici.Text = parts[1];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при чтении файла: {ex.Message}");
            }
        }
    }
}
