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

        private const int k_NumberOfWheels = 4;
        private const int k_WheelsMaxPressure = 34;

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
            setIsTransportingRefrigerate(i_VehicleDetails[4].ToString());
            setCargoVolume(i_VehicleDetails[5].ToString());
        }
        private void setIsTransportingRefrigerate(string i_IsTransportingRefrigerateAsStr)
        {
            bool isNum = int.TryParse(i_IsTransportingRefrigerateAsStr, out int TransportingRefrigerate);

            if (!isNum)
            {
                throw new FormatException("Invalid: Syntactically incorrect input for Is Carries Hazardous Materials");
            }

            if (TransportingRefrigerate != 1 && TransportingRefrigerate != 2)
            {
                throw new ArgumentException(string.Format("Invalid: {0} is not in the options for Is Carries Hazardous Materials", i_IsTransportingRefrigerateAsStr));
            }

            else
            {
                this.TransportingRefrigerate = (TransportingRefrigerate == 1);
            }
        }
        private void setCargoVolume(string i_CargoVolumeAsStr)
        {
            bool isFloat = float.TryParse(i_CargoVolumeAsStr, out float cargoVolume);

            if (!isFloat)
            {
                throw new FormatException("Invalid: Syntactically incorrect input for Cargo Volume");
            }

            else
            {
                CargoVolume = cargoVolume;
            }
        }
    

        public override string ToString()
        {
            string details = base.ToString();

            details += string.Format("\nCarry hazardous materials: {0}, cargo volume: {1}", TransportingRefrigerate, CargoVolume);
            return details;
        }
    }
}
