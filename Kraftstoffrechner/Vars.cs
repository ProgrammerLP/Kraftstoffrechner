using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Kraftstoffrechner
{
    class Vars
    {

        //general
        public static string version = "1.1.4.0";
        public static bool darkmode;

        public static Brush FGC { get; set; }
        public static Brush OWBGC { get; set; }

        //Liste
        public static List<ListContentInput> listLCI = new List<ListContentInput>();

        public static List<double> d_list = new List<double>();

        //statistic vars
        /*public float tankVolumeAVG;
        public float tankPriceAVG;
        public int dayTankDifferenceAVG;*/
        public static float gesPrice;
        public static float highest_price;
        public static float lowest_price;

        public static float gesTankVolume;
        public static float highest_TankVolume;
        public static float lowestTankVolume;

        public static float gesDistance;
        public static float highest_distance;
        public static float lowest_distance;

        public static double gesdayTankdifference;
        public static int highest_dayTankdifference;
        public static int lowest_dayTankdifference;


        public static float gesPrice_p_l;
        public static float highest_Price_p_l;
        public static float lowest_Price_p_l;

        public static float gesKM_p_l;
        public static float highest_km_p_l;
        public static float lowest_km_p_l;

        public static float gesPrice_p_km;
        public static float highest_price_p_km;
        public static float lowest_price_p_km;

        public static float gesVerbrauch;
        public static float highest_verbrauch;
        public static float lowest_verbrauch;

        //general vars
        public static DateTime previousDate;
        public static DateTime currentDate;

    }
}
