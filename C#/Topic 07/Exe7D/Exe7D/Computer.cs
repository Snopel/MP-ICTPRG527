using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exe7D
{
    //Computer Class created to store all information about the computer being purchased
    //Each part upgrade will use a Boolean variable to detect whether or not they have been selected.
    class Computer
    {
        //VARIABLE DECLARATIONS
        //Performance Upgrades
        private bool ssd; //SSD Upgrade
        private bool gpu; //Graphics Card Upgrade
        private bool screen; //27" LED Monitor Upgrade
        private int ram; //RAM Upgrades (Up to 3)

        //Utilities
        private bool assembly; //Parts Assembly by PolyTech
        private bool osDisk; //Windows Operating System OEM Disk
        private bool osInstall; //Windows OS Installaton (Requires 'osDisk == true')

        //Default constructor
        public Computer()
        {
            //Defaulting all variables
            ssd = false;
            gpu = false;
            screen = false;
            ram = -1;
            assembly = false;
            osDisk = false;
            osInstall = false;
        }

        //Getters
        public bool getSSD()
        {
            return ssd;
        }
        public bool getGPU()
        {
            return gpu;
        }
        public bool getScreen()
        {
            return screen;
        }
        public int getRAM()
        {
            return ram;
        }
        public bool getAssembly()
        {
            return assembly;
        }
        public bool getOSDisk()
        {
            return osDisk;
        }
        public bool getOSInstall()
        {
            return osInstall;
        }

        //Setters
        public void setSSD(bool x)
        {
            ssd = x;
        }
        public void setGPU(bool x)
        {
            gpu = x;
        }
        public void setScreen(bool x)
        {
            screen = x;
        }
        public void setRAM(int x)
        {
           ram = x;
        }
        public void setAssembly(bool x)
        {
            assembly = x;
        }
        public void setOSDisk(bool x)
        {
            osDisk = x;
        }
        public void setOSInstall(bool x)
        {
            osInstall = x;
        }
    }
}
