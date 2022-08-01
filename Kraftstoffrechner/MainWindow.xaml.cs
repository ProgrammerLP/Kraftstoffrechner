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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kraftstoffrechner
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DataHandler dh = new DataHandler();

        public MainWindow()
        {
            InitializeComponent();
            DataHandler.create();
            DataHandler.load();
            
            if (Vars.darkmode)
            {
                Vars.FGC = Brushes.White;
                Vars.OWBGC = new SolidColorBrush(Color.FromRgb(34, 34, 34));

                this.Background = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                SP_M.Background = new SolidColorBrush(Color.FromRgb(48, 48, 48));
            }
            else
            {
                Vars.FGC = Brushes.Black;
                Vars.OWBGC = Brushes.White;

                this.Background = Brushes.White;
                SP_M.Background = Brushes.Gray;
            }

            Main.Content = new List();
            List_btn.Background = Brushes.SkyBlue;
            stats_btn.Background = Brushes.White;
            settings_btn.Background = Brushes.White;

        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }

        private void test_Click(object sender, RoutedEventArgs e)
        {
            Menu_Click();

        }

        public void Menu_Click()
        {
            if (SP_M.ActualWidth > 100)
            {

                BeginStoryboard sb_t50 = this.FindResource("SB_sp_m_t50") as BeginStoryboard;
                sb_t50.Storyboard.Completed += new EventHandler(delegate (object sender1, EventArgs a)
                {
                    //SP_M.Width = 50;
                    List_btn.Visibility = Visibility.Collapsed;
                    stats_btn.Visibility = Visibility.Collapsed;
                    settings_btn.Visibility = Visibility.Collapsed;
                    Exit.Visibility = Visibility.Collapsed;
                    Main.Opacity = 1;
                });
                sb_t50.Storyboard.Begin();
            }
            else
            {
                BeginStoryboard sb_t200 = this.FindResource("SB_sp_m_t200") as BeginStoryboard;
                sb_t200.Storyboard.Begin();
                //SP_M.Width = 200;
                List_btn.Visibility = Visibility.Visible;
                stats_btn.Visibility = Visibility.Visible;
                settings_btn.Visibility = Visibility.Visible;
                Exit.Visibility = Visibility.Visible;
                Main.Opacity = 0.65;
            }

            if (Vars.darkmode)
            {
                this.Background = new SolidColorBrush(Color.FromRgb(34, 34, 34));
                SP_M.Background = new SolidColorBrush(Color.FromRgb(48, 48, 48));
            }
            else
            {
                this.Background = Brushes.White;
                SP_M.Background = Brushes.Gray;
            }

        }

        private void List_btn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new List();
            List_btn.Background = Brushes.SkyBlue;
            stats_btn.Background = Brushes.White;
            settings_btn.Background = Brushes.White;
            Menu_Click();
        }

        private void stats_btn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new stats();
            List_btn.Background = Brushes.White;
            stats_btn.Background = Brushes.SkyBlue;
            settings_btn.Background = Brushes.White;
            Menu_Click();
        }

        private void settings_btn_Click(object sender, RoutedEventArgs e)
        {
            
                Main.Content = new general_sets();
                List_btn.Background = Brushes.White;
                stats_btn.Background = Brushes.White;
                settings_btn.Background = Brushes.SkyBlue;

            Menu_Click();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Main_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (SP_M.ActualWidth > 100)
            {

                BeginStoryboard sb_t50 = this.FindResource("SB_sp_m_t50") as BeginStoryboard;
                sb_t50.Storyboard.Completed += new EventHandler(delegate (object sender1, EventArgs a)
                {
                    //SP_M.Width = 50;
                    List_btn.Visibility = Visibility.Collapsed;
                    stats_btn.Visibility = Visibility.Collapsed;
                    settings_btn.Visibility = Visibility.Collapsed;
                    Exit.Visibility = Visibility.Collapsed;
                    Main.Opacity = 1;
                });
                sb_t50.Storyboard.Begin();
            }
        }
    }
}
