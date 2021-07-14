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
using System.Windows.Threading;

namespace WpfApp2
{
    /// <summary>
    /// Window1.xaml etkileşim mantığı
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
           
        }
        MainWindow a = new MainWindow();
        Random konum = new Random();
        private int sure = 5;
        public int toplamtik = 0;
        public int isabetlitik = 0;
        public int puan = 0;

        DispatcherTimer zaman = new DispatcherTimer();
        DispatcherTimer zamankonum = new DispatcherTimer();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            zaman.Interval = TimeSpan.FromSeconds(1);
            zaman.Tick += Zaman_Tick;
            zamankonum.Tick += Zamankonum_Tick1;
            zaman.Start();
            zamankonum.Start();
            if (a.kbuton.IsChecked == true)
            {
                zamankonum.Interval = TimeSpan.FromSeconds(1);
            }

            if (a.obuton.IsChecked == true)
            {
                zamankonum.Interval = TimeSpan.FromSeconds(2);
            }

            if (a.zbuton.IsChecked==true)
            {
                zamankonum.Interval = TimeSpan.FromSeconds(3);
            }
            else
                zamankonum.Interval = TimeSpan.FromSeconds(1);


        }

        private void Zamankonum_Tick1(object sender, EventArgs e)
        {
            
            Thickness b = new Thickness();
            int konumy = konum.Next(0,300);
            int konumx = konum.Next(0,600); 
            b.Left = konumx;          
            b.Right = 600-konumx;          
            b.Top = konumy;
            b.Bottom = 300-konumy;
            ordek.Margin = b;
           
        }

       
        private void Zaman_Tick(object sender, EventArgs e)
        {
            sure--;
            label.Content =sure;
           
            if(sure<1)
            {
                zaman.Stop();
                zamankonum.Stop();
                toplamtik += isabetlitik;
                labelt.Content ="TOPLAM DENEME : " + toplamtik;
                labeli.Content = "TOPLAM İSABET : " + isabetlitik;
                labelp.Content ="PUAN : " +  puan;
            }
           
        }
        private void ordek_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isabetlitik++;
            puan += 5;
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            toplamtik++;
        }

  

    }
}
