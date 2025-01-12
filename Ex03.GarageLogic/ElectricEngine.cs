using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        private float m_BatteryTimeLeftInHours;
        private readonly float r_MaxBatteryCappacityInHours;

        public ElectricEngine(float i_MaxBatteryCapacityInHours)
        {
            r_MaxBatteryCapacityInHours = i_MaxBatteryCapacityInHours;
        }

        

    }

}
