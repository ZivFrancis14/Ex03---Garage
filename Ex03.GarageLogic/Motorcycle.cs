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

        public eLicenceType LicenceType
        {
            get
            {
                return m_LicenceType;
            }
        }

        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }


        }
        //public Motorcycle (int i_EngineCapacity, string i_ModelName, string i_LicencePlateNumber, float i_EnergyPrecentage, List<Wheel> i_Wheels, Engine i_Engine) 
        //    : base(i_ModelName, i_LicencePlateNumber, i_EnergyPrecentage, i_Wheels, i_Engine)

        //{
        //    m_LicenceType = i_LicenceType;
        //    m_EngineCapacity = i_EngineCapacity;
        //}
    }
}