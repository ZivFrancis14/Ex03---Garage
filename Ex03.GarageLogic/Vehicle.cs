using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_VehicleModelName;
        private readonly string r_LicencePlateNumber;
        private float m_EnergyPercentage;
        private List<Wheel> m_Wheels;
        private Engine m_Engine;

        public Vehicle(string i_LicencePlateNumber)
        {
            r_LicencePlateNumber = i_LicencePlateNumber;
        }

        //public Vehicle(string modelName, string licencePlateNumber, float energyPercentage, List<Wheel> Wheels, Engine engine)
        //{
        //    r_VehicleModelName = modelName;
        //    r_LicencePlateNumber = licencePlateNumber;
        //    m_EnergyPercentage = energyPercentage;
        //    m_Wheels = Wheels;
        //    m_Engine = engine;
        //}
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
        //public List<Wheel> Wheels
        //{
        //    get
        //    {
        //        return m_Wheels;
        //    }
        //    set
        //    {
        //        if (value == null || value.Count == 0)
        //        {
        //            throw new ArgumentException("Wheels list cannot be null or empty.");
        //        }
        //        m_Wheels = value;
        //    }
        //}
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
}
