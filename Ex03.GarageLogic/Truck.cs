using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_TransportingRefrigerate;
        private float m_CargoVolume;
        private readonly Engine r_Engine;

        public Truck() //can be only gas
        {
            r_Engine = new GasEngine();
        }
    }
}
