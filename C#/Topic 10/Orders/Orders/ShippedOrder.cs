using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders
{
    class ShippedOrder : Order
    {
        //New constant for a shipped order
        private const int HANDLING = 4;

        //Override of computePrice
        public new void computePrice()
        {
            base.setTotalPrice(getUnitPrice() * getQty() * HANDLING);
        }
    }
}
