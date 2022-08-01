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
    /// Interaktionslogik für cl_win.xaml
    /// </summary>
    public partial class cl_win : Window
    {
        public cl_win()
        {
            InitializeComponent();

            TB_cl.Text = "Neuigkeiten:\n" +
                         "-Inhalt des Fensters passt sich nun der Größe des Fensters an\n" +
                         "\nFixes & Änderungen:\n" +
                         "-kleinere Design Verbesserungen\n";

        }
    }
}
