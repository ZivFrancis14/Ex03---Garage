using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        public abstract void InitEngine(float i_CurrentEnergy);
        public abstract float EnergyPrecentage();
    }
}
