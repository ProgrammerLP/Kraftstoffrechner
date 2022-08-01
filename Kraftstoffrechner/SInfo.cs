using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;    //This namespace is used to work with Registry editor.
using System.Management; //This namespace is used to work with WMI classes. For using this namespace add reference of System.Management.dll.

namespace Kraftstoffrechner
{
    class SInfo
    {
        public static void SysInfo()
        {
            SystemInfo si = new SystemInfo();       //Create an object of SystemInfo class.
            si.getOperatingSystemInfo();            //Call get operating system info method which will display operating system information.
            si.getProcessorInfo();                  //Call get  processor info method which will display processor info.
            Console.ReadLine();                     //Wait for user to accept input key.
        }
    }
    public class SystemInfo
    {

        public string OSN;
        public string OSA;
        public string cpuCores;

        public void getOperatingSystemInfo()
        {
            Console.WriteLine("Displaying operating system info....\n");
            //Create an object of ManagementObjectSearcher class and pass query as parameter.
            ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
            foreach (ManagementObject managementObject in mos.Get())
            {
                if (managementObject["Caption"] != null)
                {
                    OSN = "" + managementObject["Caption"].ToString();   //Display operating system caption
                }
                if (managementObject["OSArchitecture"] != null)
                {
                    OSA = "" + managementObject["OSArchitecture"].ToString();   //Display operating system architecture.
                }
            }
        }

        public void getProcessorInfo()
        {
            Console.WriteLine("\n\nDisplaying Processor Name....");
            RegistryKey processor_name = Registry.LocalMachine.OpenSubKey(@"Hardware\Description\System\CentralProcessor\0", RegistryKeyPermissionCheck.ReadSubTree);   //This registry entry contains entry for processor info.

            if (processor_name != null)
            {
                if (processor_name.GetValue("ProcessorNameString") != null)
                {
                    try
                    {

                        int prozessoranzahl = Environment.ProcessorCount;
                        //Console.WriteLine("Prozessor Threads: " + Convert.ToString(prozessoranzahl));

                        ManagementScope oMs = new ManagementScope();
                        ObjectQuery oQuery = new ObjectQuery("SELECT Capacity FROM Win32_PhysicalMemory");
                        ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oMs, oQuery);
                        ManagementObjectCollection oCollection = oSearcher.Get();

                        long MemSize = 0;
                        long mCap = 0;

                        // In case more than one Memory sticks are installed
                        foreach (ManagementObject obj in oCollection)
                        {
                            mCap = Convert.ToInt64(obj["Capacity"]);
                            MemSize += mCap;
                        }
                        MemSize = MemSize / 1073741824;

                        cpuCores = "Prozessor: " + processor_name.GetValue("ProcessorNameString") + "\nThreads: " + Convert.ToString(prozessoranzahl) + "\nRam: " + MemSize + "GB";
                        
                    }

                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }
}
