using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceLib
{
    interface IGivesA_Order
    {
        // siehe whatsapp
       void OnGivesA_OrderEvent();
       event EventHandler GivesA_OrderEvent;
    }
}
