using Ex03.GarageLogic.Enums;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eColorType m_Color;
        private int m_NumberOfDoors = 0;
        private const int k_NumberOfWheels = 4;
        private const int k_WheelsMaxPressure = 34;

        public Car(string i_LicencePlateNumber, Engine i_Engine) : base(i_LicencePlateNumber, i_Engine, k_NumberOfWheels, k_WheelsMaxPressure) { }
        public int NumOfDoors
        {
            get
            {
                return m_NumberOfDoors;
            }
            set
            {
                m_NumberOfDoors = value;
            }
        }
        public eColorType CarColor
        {
            get
            {
                return m_Color;
            }
            set
            {
                m_Color = value;
            }
        }
        private int initDoorsValue(int i_InputDoorsNumber)
        {
            const int k_MinNumOfDoors = 2;
            const int k_MaxNumOfDoors = 5;

            if (i_InputDoorsNumber < k_MinNumOfDoors || i_InputDoorsNumber > k_MaxNumOfDoors)
            {
                throw new ValueOutOfRangeException(k_MinNumOfDoors, k_MaxNumOfDoors);
            }
            else
            {
                return i_InputDoorsNumber;
            }
        }
        public override void CompleteVehicleDetails(List<object> i_VehicleDetails)
        {
            base.CompleteVehicleDetails(i_VehicleDetails);
            CarColor = (eColorType)i_VehicleDetails[4];
            NumOfDoors = initDoorsValue((int)i_VehicleDetails[5]);
        }  
    }
}
