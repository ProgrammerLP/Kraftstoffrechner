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
    /// Interaktionslogik für kstoff_stats_s2.xaml
    /// </summary>
    public partial class kstoff_stats_s2 : Page
    {
        public kstoff_stats_s2()
        {
            InitializeComponent();

            Vars.gesPrice_p_l = 0;
            Vars.highest_Price_p_l = 0;
            Vars.lowest_Price_p_l = 1000000;

            Vars.gesKM_p_l = 0;
            Vars.highest_km_p_l = 0;
            Vars.lowest_km_p_l = 100000000;

            Vars.gesPrice_p_km = 0;
            Vars.highest_price_p_km = 0;
            Vars.lowest_price_p_km = 100000000;

            Vars.gesVerbrauch = 0;
            Vars.highest_verbrauch = 0;
            Vars.lowest_verbrauch = 100000000;

            for (int i = 0; i < Vars.listLCI.Count; i++)
            {

                Vars.gesPrice_p_l += Vars.listLCI[i].price_p_l;
                Vars.highest_Price_p_l = Math.Max(Vars.listLCI[i].price_p_l, Vars.highest_Price_p_l);
                Vars.lowest_Price_p_l = Math.Min(Vars.listLCI[i].price_p_l, Vars.lowest_Price_p_l);

                Vars.gesKM_p_l += Vars.listLCI[i].km_p_l;
                Vars.highest_km_p_l = Math.Max(Vars.listLCI[i].km_p_l, Vars.highest_km_p_l);
                Vars.lowest_km_p_l = Math.Min(Vars.listLCI[i].km_p_l, Vars.lowest_km_p_l);

                Vars.gesPrice_p_km += Vars.listLCI[i].price_p_km;
                Vars.highest_price_p_km = Math.Max(Vars.listLCI[i].price_p_km, Vars.highest_price_p_km);
                Vars.lowest_price_p_km = Math.Min(Vars.listLCI[i].price_p_km, Vars.lowest_price_p_km);

                Vars.gesVerbrauch += Vars.listLCI[i].verbrauch;
                Vars.highest_verbrauch = Math.Max(Vars.listLCI[i].verbrauch, Vars.highest_verbrauch);
                Vars.lowest_verbrauch = Math.Min(Vars.listLCI[i].verbrauch, Vars.lowest_verbrauch);

            }

            try
            {
                float price_p_lAVG = Vars.gesPrice_p_l / Vars.listLCI.Count;
                float km_p_lAVG = Vars.gesKM_p_l / Vars.listLCI.Count;
                float price_p_kmAVG = Vars.gesPrice_p_km / Vars.listLCI.Count;
                float verbrauchAVG = Vars.gesVerbrauch / Vars.listLCI.Count;

                TB_price_p_l_avg.Text = price_p_lAVG.ToString() + "€";
                TB_price_p_l_highest.Text = Vars.highest_Price_p_l.ToString() + "€";

                TB_distance_p_l_avg.Text = km_p_lAVG.ToString() + "km";
                TB_distance_p_l_highest.Text = Vars.highest_km_p_l.ToString() + "km";

                TB_price_p_km_avg.Text = price_p_kmAVG.ToString() + "€";
                TB_price_p_km_highest.Text = Vars.highest_price_p_km.ToString() + "€";

                TB_verbrauch_avg.Text = verbrauchAVG.ToString() + "L";
                TB_verbrauch_highest.Text = Vars.highest_verbrauch.ToString() + "L";
                TB_verbrauch_ges.Text = Vars.gesVerbrauch.ToString() + "L";

                if (Vars.listLCI.Count == 0)
                {
                    TB_verbrauch_lowest.Text = "0L";
                    TB_price_p_km_lowest.Text = "0€";
                    TB_distance_p_l_lowest.Text = "0km";
                    TB_price_p_l_lowest.Text = "0€"; 
                }
                else
                {
                    TB_verbrauch_lowest.Text = Vars.lowest_verbrauch.ToString() + "L";
                    TB_price_p_km_lowest.Text = Vars.lowest_price_p_km.ToString() + "€";
                    TB_distance_p_l_lowest.Text = Vars.lowest_km_p_l.ToString() + "km";
                    TB_price_p_l_lowest.Text = Vars.lowest_Price_p_l.ToString() + "€";
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Fehler bei Statistiken erstellung");
            }
        }
    }
}
