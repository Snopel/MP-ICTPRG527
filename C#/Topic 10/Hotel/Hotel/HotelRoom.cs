using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class HotelRoom
    {
        //Declaring variables
        private int roomNum;
        private double nightlyRate;

        //Constructor requiring input for Room Number as it is a required field.
        public HotelRoom(int x)
        {
            roomNum = x;

            //Conditional rate adjustment for rooms below or above 299
            if(roomNum <= 299)
            {
                nightlyRate = 69.95;
            }
            else if (roomNum > 299)
            {
                nightlyRate = 89.95;
            }
        }

        //Getters
        public int getRoomNum()
        {
            return roomNum;
        }
        public double getNightlyRate()
        {
            return nightlyRate;
        }

        //Setters
        public void setRoomNum(int x)
        {
            roomNum = x;
        }
        public void setNightlyRate(double x)
        {
            nightlyRate = x;
        }

    }
}
