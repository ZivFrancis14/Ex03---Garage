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
        private int m_NumberOfDoors = 2; //can be 2,3,4,5
        private readonly Engine r_Engine;

        public Car(string i_LicencePlateNumber, Engine i_Engine) : base(i_LicencePlateNumber ,i_Engine)
        {
        }
        
      
    }
}
