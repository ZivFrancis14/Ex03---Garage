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

        public Truck(string i_LicencePlateNumber, Engine i_Engine) : base(i_LicencePlateNumber, i_Engine)
        {
            this.Wheels = new List<Wheel>();
            this.Wheels.Add(new Wheel());
        }

    }
}
