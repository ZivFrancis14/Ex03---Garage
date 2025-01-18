using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_TransportingRefrigerate;
        private float r_CargoVolume;
        private const int k_NumberOfWheels = 14;
        private const int k_WheelsMaxPressure = 29;

        public Truck(string i_LicencePlateNumber, Engine i_Engine) : base(i_LicencePlateNumber, i_Engine, k_NumberOfWheels, k_WheelsMaxPressure)
        {

        }
        public bool TransportingRefrigerate
        {
            get
            {
                return m_TransportingRefrigerate;
            }
            set
            {
                m_TransportingRefrigerate = value;
            }
        }
        public float CargoVolume
        {
            get
            {
                return r_CargoVolume;
            }
            set
            {
                r_CargoVolume = value;
            }

        }
        public override void CompleteVehicleDetails(List<object> i_VehicleDetails)
        {
            base.CompleteVehicleDetails(i_VehicleDetails);
            TransportingRefrigerate = (bool)i_VehicleDetails[4];
            CargoVolume = (float)i_VehicleDetails[5];
        }
    }
}
