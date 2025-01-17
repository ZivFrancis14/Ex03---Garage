using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleRecord
    {
        private readonly Vehicle r_Vehicle;
        private readonly string r_OwnerName;
        private readonly string r_OwnerPhone;
        private eVehicleStatus m_VehicleStatus;

        public VehicleRecord(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhone, eVehicleStatus i_VehicleStatus)
        {
            r_Vehicle = i_Vehicle;
            r_OwnerName = i_OwnerName;
            r_OwnerPhone = i_OwnerPhone;
            m_VehicleStatus = eVehicleStatus.InRepair;
        }
        public Vehicle Vehicle
        {
            get { return r_Vehicle; }
        }
        public string OwnerName
        {
            get { return r_OwnerName; }
        }
        public string OwnerPhone
        {
            get { return r_OwnerPhone; }
        }
        public eVehicleStatus VehicleStatus
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value; }
        }
    }
}
