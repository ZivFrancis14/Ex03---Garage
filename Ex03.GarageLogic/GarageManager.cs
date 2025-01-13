using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private Dictionary<string, Vehicle> m_CurrentVehicleInGarage;

        public GarageManager()
        {
            m_CurrentVehicleInGarage = new Dictionary<string, Vehicle>();
        }
        public Dictionary<string, Vehicle> CurrentVehicleInGarage
        {
            get 
            { 
                return m_CurrentVehicleInGarage; 
            }
        }
        public void AddNewVehicle(Vehicle i_NewVehicle)
        {
            m_CurrentVehicleInGarage.Add(i_NewVehicle.LicencePlate, i_NewVehicle);
        }
        public bool isVehicleExisit(string i_LicencePlateNumber)
        {
            return m_CurrentVehicleInGarage.ContainsKey(i_LicencePlateNumber);
        }
    }
}
