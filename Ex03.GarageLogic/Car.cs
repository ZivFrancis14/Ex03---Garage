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

        public Car(Engine i_Engine, string i_LicencePlateNumber) : base(i_LicencePlateNumber)
        {
            r_Engine = i_Engine;
        }
        public Engine Engine
        {
            get { return r_Engine; }
        }
    }
}
