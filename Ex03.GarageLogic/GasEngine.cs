using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GasEngine : Engine
    {
        private const float k_MinFuelAmount = 0;

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
        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
        }
        public float CurrentFuelQuantity
        {
            get
            {
                return m_CurrentFuelQuantity;
            }
            set
            {
                if (value < k_MinFuelAmount || value > MaxLitersFuelQuantity)
                {
                    throw new ValueOutOfRangeException(k_MinFuelAmount, MaxLitersFuelQuantity); //fuel amount
                }

                m_CurrentFuelQuantity = value;
            }
        }
        public override void InitEngine(float i_CurrentFeulQuantity)
        {
            if (i_CurrentFeulQuantity < 0|| i_CurrentFeulQuantity > r_MaxLitersFuelQuantity)
            {
                throw new ValueOutOfRangeException(0, r_MaxLitersFuelQuantity);
            }

            m_CurrentFuelQuantity = i_CurrentFeulQuantity;
        }
        public override float EnergyPrecentage()
        {
            return (m_CurrentFuelQuantity / r_MaxLitersFuelQuantity) * 100;
        }
        public void RefuelTheCar(float i_AmountOfFuelToAdd, eFuelType i_FuelTypeToAdd)
        {
            
            if (!Enum.IsDefined(typeof(eFuelType), i_FuelTypeToAdd))
            {
                throw new ArgumentException("Invalid: there is no Feul type");
            }

            if (i_FuelTypeToAdd != FuelType)
            {
                throw new ArgumentException("Invalid: Wrong Feul type");
            }

            if (i_AmountOfFuelToAdd < k_MinFuelAmount || CurrentFuelQuantity + i_AmountOfFuelToAdd > r_MaxLitersFuelQuantity)
            {
                throw new ValueOutOfRangeException(0, MaxLitersFuelQuantity); //fuel amount
            }

            CurrentFuelQuantity += i_AmountOfFuelToAdd;


        }
    }
     
}
