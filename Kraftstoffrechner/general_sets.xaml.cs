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
    /// Interaktionslogik für general_sets.xaml
    /// </summary>
    public partial class general_sets : Page
    {
        public general_sets()
        {
            InitializeComponent();

            if (Vars.darkmode)
            {
                CHB_dm.IsChecked = true;
            }
            else
            {
                CHB_dm.IsChecked = false;
            }

        }

        private void delete_all_btn_Click(object sender, RoutedEventArgs e)
        {
            applydelete ad_win = new applydelete();
            ad_win.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("info_help.xaml", UriKind.RelativeOrAbsolute));
        }

        private void CHB_dm_Click(object sender, RoutedEventArgs e)
        {
            if (CHB_dm.IsChecked == true)
            {
                Vars.darkmode = true;
                Vars.FGC = Brushes.White;
                Vars.OWBGC = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                DataHandler.save();

                this.Background = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                LBL_HL.Foreground = Brushes.White;
                LBL_GS.Foreground = Brushes.White;
                LBL_Ds.Foreground = Brushes.White;
                CHB_dm.Foreground = Brushes.White;
                LBL_D.Foreground = Brushes.White;
            }
            else
            {
                Vars.darkmode = false;
                Vars.FGC = Brushes.Black;
                Vars.OWBGC = Brushes.White;
                DataHandler.save();

                this.Background = Brushes.White;
                LBL_HL.Foreground = Brushes.Black;
                LBL_GS.Foreground = Brushes.Black;
                LBL_Ds.Foreground = Brushes.Black;
                CHB_dm.Foreground = Brushes.Black;
                LBL_D.Foreground = Brushes.Black;
            }
        }
    }
}
