using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eColorType m_Color;
        private int m_NumberOfDoors = 0; //can be 2,3,4,5
        private const int k_NumberOfWheels = 4;
        private const int k_WheelsMaxPressure = 34;

        public Car(string i_LicencePlateNumber, Engine i_Engine) : base(i_LicencePlateNumber ,i_Engine, k_NumberOfWheels, k_WheelsMaxPressure)
        {
            this.LicencePlate = i_LicencePlateNumber;
            this.Engine = i_Engine;
        }
        public int NumOfDoors
        {
        get
            {
                return m_NumberOfDoors;
            }
            private set
            {
                if (checkDoorsValue(value) == true)
                {
                    m_NumberOfDoors = value;
                }               
            }
        }
        private bool checkDoorsValue(int inputDoorsNumber)
        {
            const int k_MinNumOfDoors = 2;
            const int k_MaxNumOfDoors = 5;

            if (inputDoorsNumber < k_MinNumOfDoors || inputDoorsNumber > k_MaxNumOfDoors)
            {
                throw new ValueOutOfRangeException(k_MinNumOfDoors, k_MaxNumOfDoors);
            }

            return false;
        }

        public override void CompleteVehicleDetails(List<object> i_VehicleDetails)
        {
            base.CompleteVehicleDetails(i_VehicleDetails);
            setCarColor(i_VehicleDetails[4].ToString());
            setNumOfDoors(i_VehicleDetails[5].ToString());
        }
        private void setNumOfDoors(string i_NumOfDoorsAsStr)
        {
            bool isNumber = int.TryParse(i_NumOfDoorsAsStr, out int numOfDoors);

            if (!isNumber)
            {
                throw new FormatException("Invalid: Syntactically incorrect input");
            }

            else
            {
                NumOfDoors = numOfDoors;
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
        private void setCarColor(string i_ColorCarAsStr)
        {
            bool iseColor = Enum.TryParse(i_ColorCarAsStr, out eColorType color);

            if (!iseColor || !Enum.IsDefined(typeof(eColorType), color))
            {
                throw new ArgumentException("Invalid: Input is not a valid color");
            }

            else
            {
                m_Color = color;
            }
        }
        public override string ToString()
        {
            string details = base.ToString();

            details += string.Format("\nCar color: {0}, numbr of doors: {1}", m_Color, NumOfDoors);

            return details;
        }

    }
}
