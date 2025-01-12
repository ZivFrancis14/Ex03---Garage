using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GasEngine : Engine
    {
        private eFuelType m_FuelType;
        private float m_CurrentFuelQuantity;
        private readonly float r_MaxLitersFuelQuantity;

        public GasEngine(float i_MaxLitersFuelQuantity, eFuelType i_FuelType)
        {
            r_MaxLitersFuelQuantity = i_MaxLitersFuelQuantity;
            m_FuelType = i_FuelType;
        }

        public float MaxLitersFuelQuantity
        {
            get { return r_MaxLitersFuelQuantity; }
        }
    }
     
}
