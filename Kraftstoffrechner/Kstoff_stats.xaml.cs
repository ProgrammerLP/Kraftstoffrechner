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
    /// Interaktionslogik für Kstoff_stats.xaml
    /// </summary>
    public partial class Kstoff_stats : Page
    {
        public Kstoff_stats()
        {
            InitializeComponent();
                
            Vars.gesPrice = 0;
            Vars.gesDistance = 0;
            Vars.gesTankVolume = 0;
            Vars.gesdayTankdifference = 0;

            Vars.highest_price = 0;
            Vars.highest_distance = 0;
            Vars.highest_TankVolume = 0;
            Vars.highest_dayTankdifference = 0;

            Vars.lowest_price = 1000000;
            Vars.lowest_distance = 100000000;
            Vars.lowestTankVolume = 10000000;
            Vars.lowest_dayTankdifference = 999999999;

            Vars.d_list.Clear();

            for (int i = 0; i < Vars.listLCI.Count; i++)
            {

                Vars.gesPrice += Vars.listLCI[i].price;
                Vars.gesDistance += Vars.listLCI[i].km;
                Vars.gesTankVolume += Vars.listLCI[i].volume_l;

                Vars.highest_price = Math.Max(Vars.listLCI[i].price, Vars.highest_price);
                Vars.lowest_price = Math.Min(Vars.listLCI[i].price, Vars.lowest_price);

                Vars.highest_distance = Math.Max(Vars.listLCI[i].km, Vars.highest_distance);
                Vars.lowest_distance = Math.Min(Vars.listLCI[i].km, Vars.lowest_distance);

                Vars.highest_TankVolume = Math.Max(Vars.listLCI[i].volume_l, Vars.highest_TankVolume);
                Vars.lowestTankVolume = Math.Min(Vars.listLCI[i].volume_l, Vars.lowestTankVolume);

            }

            for (int i = Vars.listLCI.Count; i >= 0; i--)
            {
                try
                {
                    Vars.currentDate = DateTime.Parse(Vars.listLCI[i].datum);
                    Vars.previousDate = DateTime.Parse(Vars.listLCI[i + 1].datum);

                    Console.WriteLine(Vars.currentDate.Subtract(Vars.previousDate).TotalDays);

                    Vars.gesdayTankdifference += Vars.currentDate.Subtract(Vars.previousDate).TotalDays;
                    Vars.highest_dayTankdifference = Math.Max(Vars.highest_dayTankdifference, Convert.ToInt32(Vars.currentDate.Subtract(Vars.previousDate).TotalDays));
                    Vars.lowest_dayTankdifference = Math.Min(Vars.lowest_dayTankdifference, Convert.ToInt32(Vars.currentDate.Subtract(Vars.previousDate).TotalDays));

                    Console.WriteLine(Vars.gesdayTankdifference + " gesday");
        }
                catch (Exception)
                {
                    Console.WriteLine("test1");
                }

            }

            try
            {
                double dayAVG = Vars.gesdayTankdifference / (Vars.listLCI.Count - 1);
                float volumeAVG = Vars.gesTankVolume / Vars.listLCI.Count;
                float priceAVG = Vars.gesPrice / Vars.listLCI.Count;
                float distanceAVG = Vars.gesDistance / Vars.listLCI.Count;

                TB_days_avg.Text = dayAVG.ToString() + "t";
                TB_days_highest.Text = Vars.highest_dayTankdifference.ToString() + "t";

                TB_volume_avg.Text = volumeAVG.ToString() + "L";
                TB_volume_highest.Text = Vars.highest_TankVolume.ToString() + "L";
                TB_volume_ges.Text = Vars.gesTankVolume.ToString() + "L";

                TB_price_avg.Text = priceAVG.ToString() + "€";
                TB_price_highest.Text = Vars.highest_price.ToString() + "€";
                TB_price_ges.Text = Vars.gesPrice.ToString() + "€";

                TB_distance_avg.Text = distanceAVG.ToString() + "km";
                TB_distance_highest.Text = Vars.highest_distance.ToString() + "km";
                TB_distance_ges.Text = Vars.gesDistance.ToString() + "km";


                if (Vars.listLCI.Count == 0)
                {
                    TB_distance_lowest.Text =  "0km";
                    TB_volume_lowest.Text = "0L";
                    TB_days_lowest.Text = "0t";
                    TB_price_lowest.Text = "0€"; 
                }
                else
                {
                    TB_distance_lowest.Text = Vars.lowest_distance.ToString() + "km";
                    TB_volume_lowest.Text = Vars.lowestTankVolume.ToString() + "L";
                    TB_days_lowest.Text = Vars.lowest_dayTankdifference.ToString() + "t";
                    TB_price_lowest.Text = Vars.lowest_price.ToString() + "€";
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Fehler bei Statistiken erstellung");
            }
        }
    }
}