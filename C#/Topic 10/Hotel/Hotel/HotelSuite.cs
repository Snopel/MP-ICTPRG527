using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    //Child class extending the HotelRoom class
    class HotelSuite : HotelRoom
    {
        //New constant for a surcharge on Suite rooms
        private const double SUITE_CHARGE = 40;

        //Child Constructor utilising the base roomNumber value as an input
        public HotelSuite(int x) : base(x)
        {
            //Add $40 surcharge to the Suite selection using base methods
            base.setNightlyRate(base.getNightlyRate() + SUITE_CHARGE);
        }
    }
}
