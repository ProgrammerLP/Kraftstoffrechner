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

namespace Kraftstoffrechner
{
    /// <summary>
    /// Interaktionslogik für add_new_element_win.xaml
    /// </summary>
    public partial class add_new_element_win : Window
    {

        DataHandler dh = new DataHandler();
        Vars vars = new Vars();
        ListContentInput lci = new ListContentInput();

        public int insertIndex;
        public bool editing = false;

        public add_new_element_win(string title)
        {
            InitializeComponent();
            this.Title = title;
        }

        public add_new_element_win(string date, float liter, float price, float km, int index, bool allowedit, string title)
        {
            InitializeComponent();
            this.Title = title;
            this.editing = allowedit;
            this.insertIndex = index;

            dp_1.Text = date;
            TB_input_tank_volume.Text = liter.ToString();
            TB_input_tank_volume_price.Text = price.ToString();
            TB_input_km.Text = km.ToString();

        }

        private void add_to_list_btn_Click(object sender, RoutedEventArgs e)
        {
            if (editing && dp_1.Text != "" && TB_input_tank_volume.Text != "" && TB_input_tank_volume_price.Text != "" && !TB_input_tank_volume.Text.Contains(".") && !TB_input_tank_volume_price.Text.Contains("."))
            {
                Vars.listLCI.Remove(Vars.listLCI[insertIndex]);

                lci.datum = dp_1.Text;
                lci.volume_l = float.Parse(TB_input_tank_volume.Text);
                lci.price = float.Parse(TB_input_tank_volume_price.Text);
                lci.km = float.Parse(TB_input_km.Text);
                lci.price_p_l = lci.price / lci.volume_l;
                lci.km_p_l = lci.km / lci.volume_l;
                lci.price_p_km = lci.price / lci.km * 100;
                lci.verbrauch = lci.volume_l / lci.km * 100;

                Vars.listLCI.Insert(insertIndex, new ListContentInput { datum = lci.datum, volume_l = lci.volume_l, price = lci.price, km = lci.km, price_p_l = lci.price_p_l, km_p_l = lci.km_p_l, price_p_km = lci.price_p_km, verbrauch = lci.verbrauch });
                LBL_error.Content = "";
                add_to_list_btn.Content = "hinzufügen";
            }
            else
            {
                LBL_error.Content = "Bitte füllen Sie ALLE Felder aus! OHNE Punkte";
            }

            if (!editing && dp_1.Text != "" && TB_input_tank_volume.Text != "" && TB_input_tank_volume_price.Text != "" && !TB_input_tank_volume.Text.Contains(".") && !TB_input_tank_volume_price.Text.Contains("."))
            {

                try
                {
                    lci.datum = dp_1.Text;
                    lci.volume_l = float.Parse(TB_input_tank_volume.Text);
                    lci.price = float.Parse(TB_input_tank_volume_price.Text);
                    lci.km = float.Parse(TB_input_km.Text);
                    lci.price_p_l = lci.price / lci.volume_l;
                    lci.km_p_l = lci.km / lci.volume_l;
                    lci.price_p_km = lci.price / lci.km * 100;
                    lci.verbrauch = lci.volume_l / lci.km * 100;

                    Vars.listLCI.Insert(0, new ListContentInput { datum = lci.datum, volume_l = lci.volume_l, price = lci.price, km = lci.km, price_p_l = lci.price_p_l, km_p_l = lci.km_p_l, price_p_km = lci.price_p_km, verbrauch = lci.verbrauch });
                    LBL_error.Content = "";
                }
                catch (Exception)
                {
                    LBL_error.Content = "KEINE Buchstaben, keine Sonderzeichen sowie keine Leerzeichen und Punkte";
                }
            }
            else
            {
                LBL_error.Content = "Bitte füllen Sie ALLE Felder aus! OHNE Punkte";
            }

            DataHandler.save();
            this.Close();
        }

    }
}
