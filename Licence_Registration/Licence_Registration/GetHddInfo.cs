using System;
using System.Collections;
using System.Management;

namespace Licence_Registration
{
        class HardDrive
        {
            private string model = null;
            private string type = null;
            private string serialNo = null;

            public string Model
            {
                get { return model; }
                set { model = value; }
            }

            public string Type
            {
                get { return type; }
                set { type = value; }
            }

            public string SerialNo
            {
                get { return serialNo; }
                set { serialNo = value; }
            }
        }
        class GetHddInfo
        {
            string Rt;

            [STAThread]
            public string HddSerialNo()
            {

                ArrayList hdCollection = new ArrayList();

                ManagementObjectSearcher searcher = new
                    ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");  // add refrence from menu to system.management

                foreach (ManagementObject wmi_HD in searcher.Get())
                {
                    HardDrive hd = new HardDrive();
                    hd.Model = wmi_HD["Model"].ToString();
                    hd.Type = wmi_HD["InterfaceType"].ToString();

                    hdCollection.Add(hd);
                }

                searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");

                int i = 0;
                foreach (ManagementObject wmi_HD in searcher.Get())
                {
                    // get the hard drive from collection
                    // using index
                    HardDrive hd = (HardDrive)hdCollection[i];

                    // get the hardware serial no.
                    if (wmi_HD["SerialNumber"] == null)
                        hd.SerialNo = "None";
                    else
                        hd.SerialNo = wmi_HD["SerialNumber"].ToString();

                    ++i;
                }


                foreach (HardDrive item in hdCollection)
                {
                    if (item.SerialNo != "None")
                    {
                        Rt = item.SerialNo.TrimStart();
                    }
                }

                return Rt;

            }
        }
}
