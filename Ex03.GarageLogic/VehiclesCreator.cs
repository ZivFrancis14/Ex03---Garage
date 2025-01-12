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
        public Car CreateGasCar(string i_LicencePlateNumber)
        {
            GasEngine gasEngine = new GasEngine();
            Car newCar = new Car(i_LicencePlateNumber, gasEngine);

            return newCar;
        }
        public Car CreateElectricCar(string i_LicencePlateNumber)
        {
            ElectricEngine electricEngine = new ElectricEngine();
            Car newCar = new Car(i_LicencePlateNumber, electricEngine);

            return newCar;
        }
        public Motorcycle CreateGasMotorcycle(string i_LicencePlateNumber)
        {
            GasEngine gasEngine = new GasEngine();
            Motorcycle newMotorcycle = new Motorcycle(gasEngine, i_LicencePlateNumber);

            return newMotorcycle;
        }
        public Motorcycle CreateElectricMotorcycle(string i_LicencePlateNumber)
        {
            ElectricEngine electricEngine = new ElectricEngine();
            Motorcycle newMotorcycle = new Motorcycle(electricEngine, i_LicencePlateNumber);

            return newMotorcycle;
        }
        public Truck CreateTruck(string i_LicencePlateNumber)
        {
            GasEngine gasEngine = new GasEngine();
            Truck newTruck = new Truck(i_LicencePlateNumber, gasEngine);

            return newTruck;
        }
    }
}
