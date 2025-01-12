using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private readonly eLicenceType r_LicenceType;
        private  readonly int r_EngineCapacity;

        public eLicenceType LicenceType
        {
            get
            {
                return r_LicenceType;
            }
        }

        public int EngineCapacity
        {
            get
            {
                return r_EngineCapacity;
            }

        }
        public Motorcycle(Engine i_Engine, string i_LicencePlateNumber) : base(i_LicencePlateNumber, i_Engine)
        {
        }




    }
}