using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private Dictionary<string, VehicleRecord> m_CurrentVehicleInGarage;

        public GarageManager()
        {
            m_CurrentVehicleInGarage = new Dictionary<string, VehicleRecord>();
        }
        public Dictionary<string, VehicleRecord> CurrentVehicleInGarage
        {
            get 
            { 
                return m_CurrentVehicleInGarage; 
            }
        }
        public void AddNewVehicle(VehicleRecord i_NewVehicle)
        {
            m_CurrentVehicleInGarage.Add(i_NewVehicle.Vehicle.LicencePlate, i_NewVehicle);
        }

        public void ChangeVehicleStatus(string i_LicencePlateNumber, eVehicleStatus i_NewStatus)
        {
            m_CurrentVehicleInGarage[i_LicencePlateNumber].VehicleStatus = i_NewStatus;
        }

        public bool isVehicleExisit(string i_LicencePlateNumber)
        {
            return m_CurrentVehicleInGarage.ContainsKey(i_LicencePlateNumber);
        }
    }
}
