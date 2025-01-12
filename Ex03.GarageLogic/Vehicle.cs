using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_LicencePlateNumber;
        private  string m_VehicleModelName;
        private float m_EnergyPercentage;
        private List<Wheel> m_Wheels;
        private  Engine m_Engine;

        public Vehicle(string i_LicencePlateNumber, Engine i_Engine)
        {
            m_Engine = i_Engine;
            r_LicencePlateNumber = i_LicencePlateNumber;
        }
        public void InitializeVehicleWheels(int i_NumberOfWheels, float i_WheelsMaxPressure)
        {
            m_Wheels = new List<Wheel>();
            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(i_WheelsMaxPressure));
            }
        }
        public virtual void CompleteVehicleDetails(object[] i_VehicleDetails)
        {
            ModelName = (i_VehicleDetails[0]).ToString();
        }

        public string ModelName
        {
            get 
            { 
                return m_VehicleModelName; 
            }
            set
            {
                m_VehicleModelName = value;
            }
        }
        public float EnergyPercentage
        {
            get
            {
                return m_EnergyPercentage;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Energy percentage must be between 0 and 100.");
                }
                m_EnergyPercentage = value;
            }
        }
        public List<Wheel> Wheels
        {
            get { return m_Wheels; }
            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentException("Wheels list cannot be null or empty.");
                }
                m_Wheels = value;
            }
        }
        public Engine Engine
        {
            get
            {
                return m_Engine;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Engine cannot be null.", nameof(value));
                }
                m_Engine = value;
            }
        }
        public string LicencePlate
        {
            get
            {
                return m_VehicleModelName;
            }
        }
    }
}
