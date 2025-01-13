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
        private int m_EngineCapacity;

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

        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }
            set
            {
                m_EngineCapacity = value;
            }
        }
        public override void CompleteVehicleDetails(List<object> i_VehicleDetails)
        {
            base.CompleteVehicleDetails(i_VehicleDetails);
            setLicenceType(i_VehicleDetails[4].ToString());
            setEngineVolume(i_VehicleDetails[5].ToString());
        }
        private void setEngineVolume(string i_EngineVolumeAsStr)
        {
            bool isNumber = int.TryParse(i_EngineVolumeAsStr, out int engineVolume);

            if (!isNumber)
            {
                throw new FormatException("Invalid: Syntactically incorrect input for Engine Volume");
            }

            else
            {
                EngineCapacity = engineVolume;
            }
        }
        private void setLicenceType(string i_LicenceTypeAsStr)
        {
            bool iseLicenceType = Enum.TryParse(i_LicenceTypeAsStr, out eLicenceType licenceType);

            if (!iseLicenceType || !Enum.IsDefined(typeof(eLicenceType), licenceType))
            {
                throw new ArgumentException("Invalid: Input is not a valid licence type for Licence Type");
            }

            else
            {
                m_LicenceType = licenceType;
            }
        }
        public override string ToString()
        {
            string details = base.ToString();

            details += string.Format("\nlicence type: {0}, Engine volume: {1}", LicenceType, EngineCapacity);

            return details;
        }



    }
}