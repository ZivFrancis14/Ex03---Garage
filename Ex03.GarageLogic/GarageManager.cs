using Ex03.GarageLogic.Enums;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private readonly Dictionary<string, VehicleRecord> r_CurrentVehicleInGarage;

        public GarageManager()
        {
            r_CurrentVehicleInGarage = new Dictionary<string, VehicleRecord>();
        }
        public Dictionary<string, VehicleRecord> CurrentVehicleInGarage
        {
            get 
            { 
                return r_CurrentVehicleInGarage; 
            }
        }
        public void AddNewVehicle(VehicleRecord i_NewVehicle)
        {
            r_CurrentVehicleInGarage.Add(i_NewVehicle.Vehicle.LicencePlate, i_NewVehicle);
        }
        public void ChangeVehicleStatus(string i_LicencePlateNumber, eVehicleStatus i_NewStatus)
        {
            r_CurrentVehicleInGarage[i_LicencePlateNumber].VehicleStatus = i_NewStatus;
        }
        public bool IsVehicleExisit(string i_LicencePlateNumber)
        {
            return r_CurrentVehicleInGarage.ContainsKey(i_LicencePlateNumber);
        }
    }
}
