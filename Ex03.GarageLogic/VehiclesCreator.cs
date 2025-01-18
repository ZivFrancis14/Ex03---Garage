using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehiclesCreator
    {
        private eVehicleType[] m_CurrentVehicleType = { eVehicleType.GasCar, eVehicleType.ElectricCar, eVehicleType.GasMotorcycle, eVehicleType.ElectricMotorcycle, eVehicleType.Truck };
        public eVehicleType[] CurrentVehicleTypes
        {
            get { return m_CurrentVehicleType; }
        }
        public Car CreateGasCar(string i_LicencePlateNumber, ref GarageManager i_GarageManager)
        {
            const float k_MaxLitersFuelQuantity = 52f;
            const eFuelType k_FuelType = eFuelType.Octan95;

            GasEngine gasEngine = new GasEngine(k_MaxLitersFuelQuantity, k_FuelType);
            Car newCar = new Car(i_LicencePlateNumber, gasEngine);

            return newCar;
        }
        public Car CreateElectricCar(string i_LicencePlateNumber, ref GarageManager i_GarageManager)
        {
            const float k_MaxBatteryCapacityInHours = 5.4f;

            ElectricEngine electricEngine = new ElectricEngine(k_MaxBatteryCapacityInHours);
            Car newCar = new Car(i_LicencePlateNumber, electricEngine);

            return newCar;
        }
        public Motorcycle CreateGasMotorcycle(string i_LicencePlateNumber, ref GarageManager i_GarageManager)
        {
            const float k_MaxLitersFuelQuantity = 6.2f;
            const eFuelType k_FuelType = eFuelType.Octan98;

            GasEngine gasEngine = new GasEngine(k_MaxLitersFuelQuantity, k_FuelType);
            Motorcycle newMotorcycle = new Motorcycle(gasEngine, i_LicencePlateNumber);

            return newMotorcycle;
        }
        public Motorcycle CreateElectricMotorcycle(string i_LicencePlateNumber, ref GarageManager i_GarageManager)
        {
            const float k_MaxBatteryCapacityInHours = 2.9f;

            ElectricEngine electricEngine = new ElectricEngine(k_MaxBatteryCapacityInHours);
            Motorcycle newMotorcycle = new Motorcycle(electricEngine, i_LicencePlateNumber);

            return newMotorcycle;
        }
        public Truck CreateTruck(string i_LicencePlateNumber, ref GarageManager i_GarageManager)
        {
            const float k_MaxLitersFuelQuantity = 125f;
            const eFuelType k_FuelType = eFuelType.Soler;

            GasEngine gasEngine = new GasEngine(k_MaxLitersFuelQuantity, k_FuelType);
            Truck newTruck = new Truck(i_LicencePlateNumber, gasEngine);

            return newTruck;
        }
    }
}
