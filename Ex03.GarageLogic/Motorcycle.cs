using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private eLicenceType m_LicenceType;
        private int m_EngineVolume;

        private const int k_NumberOfWheels = 4;
        private const int k_WheelsMaxPressure = 34;

        public Motorcycle(Engine i_Engine, string i_LicencePlateNumber) : base(i_LicencePlateNumber, i_Engine, k_NumberOfWheels, k_WheelsMaxPressure)
        {
        }
        public eLicenceType LicenceType
        {
            get
            {
                return m_LicenceType;
            }
            set
            {
                m_LicenceType = value;
            }
        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }
            set
            {
                m_EngineVolume = value;
            }
        }
        public override void CompleteVehicleDetails(List<object> i_VehicleDetails)
        {
            base.CompleteVehicleDetails(i_VehicleDetails);
            LicenceType = (eLicenceType)i_VehicleDetails[4];
            EngineVolume = (int)i_VehicleDetails[5];
        }

    }
}