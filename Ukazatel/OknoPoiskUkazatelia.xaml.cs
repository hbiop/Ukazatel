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
using System.Windows.Shapes;

namespace Ukazatel
{
    /// <summary>
    /// Логика взаимодействия для OknoPoiskUkazatelia.xaml
    /// </summary>
    public partial class OknoPoiskUkazatelia : Window
    {
        public OknoPoiskUkazatelia()
        {
            InitializeComponent();
            PredmetniyUkazatel.DobavitUkazatel("test", new int[] { 10, 20, 30, 40 });
            PredmetniyUkazatel.DobavitUkazatel("test2", new int[] { 20, 30, 40 });
        }

        private void BtnNazad(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void BtnNayti(object sender, RoutedEventArgs e)
        {
            string soobshenie = PredmetniyUkazatel.PoluchitStraniciDlyaUkazatelia(tbVvodSlova.Text);
            tbVividStranic.Text = soobshenie;
        }
    }
}
