using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaktionslogik für info_help.xaml
    /// </summary>
    public partial class info_help : Page
    {
        SystemInfo sysinfo = new SystemInfo();

        public string about = "PLP-Fuelinfo ist eine offizielle, lizensierte, modern gestalltete und leicht zu benutztende Anwendung von ProgrammerLP, damit Sie ihre Kraftstoff Ausgaben im Blick behalten und verwalten können.\nMehr Informationen finden Sie auf der Website.";
        public string lizenz = "Dieses Produkt wurde von ProgrammerLP zur Verfügen gestellt \nNutzung nur für private Zwecke, kein Verleih oder weiterverkauf oder ähnliches! \nSiehe Lizenz Informationen. \n© - 2022 by ProgrammerLP, All rights reserved";

        public info_help()
        {
            InitializeComponent();

            sysinfo.getOperatingSystemInfo();
            sysinfo.getProcessorInfo();

            LBL_About_Text.Text = about;
            LBL_Lizenz_Text.Text = lizenz;
            LBL_Version.Content = "Version: " + Vars.version;
            LBL_OS_Name.Content = "Betriebsystem: " + sysinfo.OSN + " (" + sysinfo.OSA + ")";
            LBL_CPU_Name.Content = sysinfo.cpuCores;
        }

        private void H_Ud_BTN_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://programmerlp-net.vercel.app/licens_privacy_info.html");
        }

        private void H_DS_BTN_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://programmerlp-net.vercel.app");
        }

        private void H_LI_BTN_Click(object sender, RoutedEventArgs e)
        {
            cl_win clw = new cl_win();
            clw.Show();
        }

        private void H_HO_RM_BTN_Click(object sender, RoutedEventArgs e)
        {
            H_HO_RM_BTN.Content = "developer.programmerlp@gmx.net";
        }

        private void back_btn_Click(object sender, RoutedEventArgs e)
        {
            var ns = NavigationService.GetNavigationService(this);
            ns.Navigate(new Uri("general_sets.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
