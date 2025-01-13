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
            //r_MaxBatteryCapacityInHours = i_MaxBatteryCapacityInHours;
        }
        public override void InitEngine(float i_BatteryTimeLeftInHours)
        {
            if (i_BatteryTimeLeftInHours < 0 || i_BatteryTimeLeftInHours > r_MaxBatteryCappacityInHours)
            {
                throw new ArgumentOutOfRangeException(nameof(i_BatteryTimeLeftInHours), "Energy percentage must be between 0 and 100.");
            }
            m_BatteryTimeLeftInHours = i_BatteryTimeLeftInHours;
              
        }
        public override float EnergyPrecentage()
        {
            return (m_BatteryTimeLeftInHours / r_MaxBatteryCappacityInHours) * 100;
        }
    }

}
