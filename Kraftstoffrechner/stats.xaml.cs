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

namespace Kraftstoffrechner
{
    /// <summary>
    /// Interaktionslogik für stats.xaml
    /// </summary>
    public partial class stats : Page
    {

        int index;

        public stats()
        {
            InitializeComponent();

            stats_F.Content = new Kstoff_stats();
            index = 1;
            rb_p1.IsChecked = true;

        }

        private void nav_btn_Click(object sender, RoutedEventArgs e)
        {
            if (index == 1)
            {
                index = 2;
                stats_F.Content = new kstoff_stats_s2();
                rb_p2.IsChecked = true;
            }
            else if (index == 2)
            {
                index = 1;
                stats_F.Content = new Kstoff_stats();
                rb_p1.IsChecked = true;
            }
        }
    }
}
