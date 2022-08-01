using Microsoft.VisualBasic.Devices;
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
    /// Interaktionslogik für List.xaml
    /// </summary>
    public partial class List : Page
    {

        DataHandler dh = new DataHandler();
        Vars vars = new Vars();
        ListContentInput lci = new ListContentInput();

        public int insertIndex;
        public bool editing = false;

        public List()
        {
            InitializeComponent();
            List1.ItemsSource = null;
            List1.ItemsSource = Vars.listLCI;
        }

        private void delete_element_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Vars.listLCI.Remove(Vars.listLCI[List1.SelectedIndex]);
                List1.ItemsSource = null;
                List1.ItemsSource = Vars.listLCI;
            }
            catch (Exception)
            {
                Console.WriteLine("löschen von Element fehlgeschlagen");
            }

            DataHandler.save();

        }

        private void edit_element_btn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                insertIndex = List1.SelectedIndex;
                editing = true;

                add_new_element_win ane_win = new add_new_element_win(Vars.listLCI[insertIndex].datum, Vars.listLCI[List1.SelectedIndex].volume_l, Vars.listLCI[List1.SelectedIndex].price, Vars.listLCI[List1.SelectedIndex].km, insertIndex, editing, "Bearbeiten");
                ane_win.Closed += add_win_Closed;
                ane_win.Show();

            }
            catch (Exception)
            {
                Console.WriteLine("editieren von Element fehlgeschlagen");
            }

        }
        private void copy_element_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Clipboard.SetText(Vars.listLCI[List1.SelectedIndex].datum + " | " +
                    Vars.listLCI[List1.SelectedIndex].volume_l + " | " + Vars.listLCI[List1.SelectedIndex].price + " | " + 
                    Vars.listLCI[List1.SelectedIndex].km + " | " + Vars.listLCI[List1.SelectedIndex].price_p_l + " | " + 
                    Vars.listLCI[List1.SelectedIndex].km_p_l + " | " + Vars.listLCI[List1.SelectedIndex].price_p_km + " | " + 
                    Vars.listLCI[List1.SelectedIndex].verbrauch);
            }
            catch (Exception)
            {
                Console.WriteLine("Fehler beim kopieren");
            }
        }

        

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            add_new_element_win ane_win = new add_new_element_win("zu Liste hinzufügen");
            ane_win.Closed += add_win_Closed;
            ane_win.Show();
        }

        private void add_win_Closed(object sender, EventArgs e)
        {
            List1.ItemsSource = null;
            List1.ItemsSource = Vars.listLCI;
        }

        private void List1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ListView listView = sender as ListView;
            GridView gView = listView.View as GridView;

            var workingWidth = listView.ActualWidth - SystemParameters.VerticalScrollBarWidth; // take into account vertical scrollbar
            var col1 = 0.125;
            var col2 = 0.125;
            var col3 = 0.125;
            var col4 = 0.125;
            var col5 = 0.125;
            var col6 = 0.125;
            var col7 = 0.125;
            var col8 = 0.125;

            gView.Columns[0].Width = workingWidth * col1;
            gView.Columns[1].Width = workingWidth * col2;
            gView.Columns[2].Width = workingWidth * col3;
            gView.Columns[3].Width = workingWidth * col4;
            gView.Columns[4].Width = workingWidth * col5;
            gView.Columns[5].Width = workingWidth * col6;
            gView.Columns[6].Width = workingWidth * col7;
            gView.Columns[7].Width = workingWidth * col8;
        }
    }
}