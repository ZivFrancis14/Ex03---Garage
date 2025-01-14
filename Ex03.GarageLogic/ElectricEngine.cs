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
            r_MaxBatteryCappacityInHours = i_MaxBatteryCapacityInHours;
        }
        public override void InitEngine(float i_BatteryTimeLeftInHours)
        {
            if (i_BatteryTimeLeftInHours < 0 || i_BatteryTimeLeftInHours > r_MaxBatteryCappacityInHours)
            {
                throw new ValueOutOfRangeException(0, r_MaxBatteryCappacityInHours);
            }

            m_BatteryTimeLeftInHours = i_BatteryTimeLeftInHours;         
        }
        public override float EnergyPrecentage()
        {
            return (m_BatteryTimeLeftInHours / r_MaxBatteryCappacityInHours) * 100;
        }
    }

}
