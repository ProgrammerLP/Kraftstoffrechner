using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kraftstoffrechner
{
    class DataHandler
    {

        static ListContentInput lci = new ListContentInput();

        const string path = @"LSS_Verbrauchsrechner";

        public static void create()
        {

            try
            {
                //create Folder
                string sub_Folder = System.IO.Path.Combine(path, "AppData");

                if (!System.IO.Directory.Exists(sub_Folder))
                {
                    System.IO.Directory.CreateDirectory(sub_Folder);

                    Console.WriteLine("Ordner " + sub_Folder + " erstellt");
                }

                else
                {
                    Console.WriteLine("Ordner " + sub_Folder + " existiert bereits");
                }

                string SubFolder = System.IO.Path.Combine(path, "Licenses");

                if (!System.IO.Directory.Exists(SubFolder))
                {
                    System.IO.Directory.CreateDirectory(SubFolder);

                    Console.WriteLine("Ordner (Licenses) erstellt");
                }
                else
                {
                    Console.WriteLine("Ordner (Licenses) existiert bereits");
                }

                //create Files

                string FileName = "tanklist.lss";
                string DataFile = System.IO.Path.Combine(@"LSS_Verbrauchsrechner\AppData", FileName);

                if (!System.IO.File.Exists(DataFile))
                {
                    System.IO.File.Create(DataFile);

                    Console.WriteLine("tanklist.lss erstellt");
                }

                else
                {
                    Console.WriteLine("tanklist.lss existiert bereits");
                }

                string dataName = "AppData.lss";
                string Filepath = System.IO.Path.Combine(@"LSS_Verbrauchsrechner\AppData", dataName);

                if (!System.IO.File.Exists(Filepath))
                {
                    System.IO.File.Create(Filepath);

                    Console.WriteLine("vars_value.lss erstellt");
                }

                else
                {
                    Console.WriteLine("AppData.lss existiert bereits");
                }

            }

            catch (Exception e)
            {
                Console.WriteLine("Fehler: " + e.Message);
            }

        }

        public static void save()
        {
            //Tank Liste speichern
            StreamWriter sw_tl = new StreamWriter(@"LSS_Verbrauchsrechner\AppData\tanklist.lss");
            Console.WriteLine("Test?");

            try
            {
                for (int i = 0; i < Vars.listLCI.Count; i++)
                {
                    sw_tl.WriteLine(Vars.listLCI[i].datum);
                    sw_tl.WriteLine(Vars.listLCI[i].volume_l);
                    sw_tl.WriteLine(Vars.listLCI[i].price);
                    sw_tl.WriteLine(Vars.listLCI[i].km);
                    sw_tl.WriteLine(Vars.listLCI[i].price_p_l);
                    sw_tl.WriteLine(Vars.listLCI[i].km_p_l);
                    sw_tl.WriteLine(Vars.listLCI[i].price_p_km);
                    sw_tl.WriteLine(Vars.listLCI[i].verbrauch);
                    Console.WriteLine("Index " + i + " wurde gespeichert");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Fehler beim speichern der Liste!");
            }

            sw_tl.Close();

            //Vars speichern
            StreamWriter sw_v = new StreamWriter(@"LSS_Verbrauchsrechner\AppData\AppData.lss");

            try
            {
                sw_v.WriteLine(Vars.darkmode);
                Console.WriteLine("Vars gespeichert");
            }
            catch (Exception)
            {
                Console.WriteLine("Fehler beim speichern der Vars");
            }

            sw_v.Close();

        }

        public static void load()
        {
            try
            {

                //Tank Liste laden
                StreamReader sr_tl = new StreamReader(@"LSS_Verbrauchsrechner\AppData\tanklist.lss");

                for (int i = 0; !sr_tl.EndOfStream; i++)
                {

                    Vars.listLCI.Add(new ListContentInput { datum = sr_tl.ReadLine(), 
                        volume_l = float.Parse(sr_tl.ReadLine()), price = float.Parse(sr_tl.ReadLine()), 
                        km = float.Parse(sr_tl.ReadLine()), price_p_l = float.Parse(sr_tl.ReadLine()), 
                        km_p_l = float.Parse(sr_tl.ReadLine()), price_p_km = float.Parse(sr_tl.ReadLine()), 
                        verbrauch = float.Parse(sr_tl.ReadLine()) });
                    Console.WriteLine(sr_tl.EndOfStream);

                }

                sr_tl.Close();

                //Vars geladen
                StreamReader sr_v = new StreamReader(@"LSS_Verbrauchsrechner\AppData\AppData.lss");

                Vars.darkmode = bool.Parse(sr_v.ReadLine());
                Console.WriteLine("Vars geladen");

            }

            catch (Exception e)
            {
                Console.WriteLine("Fehler: " + e.Message);
            }
        }
    }
}
