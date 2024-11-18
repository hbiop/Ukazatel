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

namespace Ukazatel
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PredmetniyUkazatel.DobavitUkazatel("test", new int[] {10,20,30,40});
            var ukazateli = PredmetniyUkazatel.PoluchitVseUkazateli().Select(x => new { slovo = x.Key, stranici = String.Join(", ", x.Value) }).ToList();
            Ukazateli.ItemsSource = ukazateli;
        }
        private void BtnUdalitUkazatel(object sender, RoutedEventArgs e)
        {
            var ukazateli = PredmetniyUkazatel.PoluchitVseUkazateli().Select(x => new { slovo = x.Key, stranici = String.Join(", ", x.Value) }).ToList();
            if (Ukazateli.SelectedIndex != -1)
            {
                string soobshenie = PredmetniyUkazatel.UdalitUkazatel(ukazateli[Ukazateli.SelectedIndex].slovo);
                MessageBox.Show(soobshenie);
            }
            else
            {
                MessageBox.Show("Выберите указатель для удаления");
            }
            ukazateli = PredmetniyUkazatel.PoluchitVseUkazateli().Select(x => new { slovo = x.Key, stranici = String.Join(", ", x.Value) }).ToList();
            Ukazateli.ItemsSource = null;
            Ukazateli.ItemsSource = ukazateli;
        }

        private void BtnNaytiUkazatel(object sender, RoutedEventArgs e)
        {
            OknoPoiskUkazatelia oknoPoiskUkazatelia = new OknoPoiskUkazatelia();
            oknoPoiskUkazatelia.Show();
            this.Close();
        }

        private void BtnDobavitUkazatel(object sender, RoutedEventArgs e)
        {
            DobavitUkazatel dobavitUkazatel = new DobavitUkazatel();
            dobavitUkazatel.Show();
            this.Close();
        }
    }
}
