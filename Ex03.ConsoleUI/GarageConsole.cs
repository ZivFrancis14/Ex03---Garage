using Ex03.GarageLogic;
using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace Ex03.ConsoleUI
{
    public class GarageConsole
    {
        private VehiclesCreator m_VehiclesCreator;
        private CarConsole m_CarConsole;

        public void startGarageSystem()
        {
            string msg = string.Empty;

            msg = "Welcome To The Garage";
            Console.WriteLine(msg);
            //printOptionsMenu();
        }
        private void newCarToGarage()
        {
            Vehicle newVehicle = null;
            string licencePlateNumber = string.Empty;
            m_VehiclesCreator = new VehiclesCreator();

            licencePlateNumber = getLicencePlateNumberFromUser();
            if (vehicleIsExist(licencePlateNumber) == true)
            {

            }
            else
            {
                newVehicle = createNewVehicle(licencePlateNumber);
                insertVehicleStatus(newVehicle);
            }
        }
        private string getLicencePlateNumberFromUser()
        {
            string licencePlateNumber = string.Empty;
            bool isVAlid = false;
            string msg = string.Empty;

            while (isVAlid == false)
            {
                try
                {
                    msg = "Please Enter Licence Plate Number";
                    Console.WriteLine(msg);
                    licencePlateNumber = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(licencePlateNumber) == true || stringIsNumbersAndLetters(licencePlateNumber) == false)
                    {
                        throw new FormatException("License plate number must include letters and numbers only and not empty");
                    }

                    isVAlid = true;
                }
                catch (FormatException ex)
                {
                    msg = string.Format("Invalid input {0}", ex);
                    Console.WriteLine(msg);
                }
            }

            return licencePlateNumber;
        }
        private bool stringIsNumbersAndLetters(string i_Input)
        {
            foreach (char c in i_Input)
            {
                if (char.IsLetterOrDigit(c) == false)
                {
                    return false;
                }
            }
            return true;
        }
        private Vehicle createNewVehicle(string i_LicencePlateNumber)
        {
            Vehicle newVehicle = null;
            eVehicleType userVehicleChoice = getUserVehicleOptions(i_LicencePlateNumber, m_VehiclesCreator.CurrentVehicleTypes);

            switch (userVehicleChoice)
            {
                case eVehicleType.GasCar:
                    newVehicle = m_VehiclesCreator.CreateGasCar(i_LicencePlateNumber);
                    break;
                case eVehicleType.ElectricCar:
                    newVehicle = m_VehiclesCreator.CreateElectricCar(i_LicencePlateNumber);
                    break;
                case eVehicleType.GasMotorcycle:
                    newVehicle = m_VehiclesCreator.CreateGasMotorcycle(i_LicencePlateNumber);
                    break;
                case eVehicleType.ElectricMotorcycle:
                    newVehicle = m_VehiclesCreator.CreateElectricMotorcycle(i_LicencePlateNumber);
                    break;
                case eVehicleType.Truck:
                    newVehicle = m_VehiclesCreator.CreateTruck(i_LicencePlateNumber);
                    break;
                default:
                    break;
            }

            return newVehicle;
        }
        private eVehicleType getUserVehicleOptions(string i_LicencePlateNumber, eVehicleType[] i_VehicleOptions)
        {
            string msg = string.Empty;
            eVehicleType userChoice = 0;
            bool inputIsValid = false;

            while (inputIsValid == false)
            {
                try
                {
                    msg = string.Format("Please choose the number of your vehicle:");
                    Console.WriteLine(msg);
                    for (int i = 0; i < i_VehicleOptions.Length; i++)
                    {
                        msg = string.Format("{0}.  {1}", i + 1, i_VehicleOptions[i].ToString());
                        Console.WriteLine(msg);
                    }

                    string userInput = Console.ReadLine();
                    if (int.TryParse(userInput, out int choice) == false)
                    {
                        throw new FormatException("Invalid input. Please enter a number.");
                    }
                    if (choice < 1 || choice > i_VehicleOptions.Length)
                    {
                        throw new FormatException("Invalid input. Please enter a number.");
                    }
                    userChoice = i_VehicleOptions[choice - 1];
                    inputIsValid = true;
                }
                catch (FormatException ex)
                {
                    msg = string.Format("Error: ", ex.Message);
                    Console.WriteLine(msg);
                }
            }

            return userChoice;
        }
        private void insertVehicleStatus(Vehicle i_Vehicle)
        {
            switch(i_Vehicle)
            {
                case Car car:

                    if (car.Engine is GasEngine)
                    {
                        insertVehicleGasCar(car);
                    }
                    else
                    {
                        insertVehicleElectricCar(car);
                    }
                    break;
                case Motorcycle motorcycle:
                    if (motorcycle.Engine is GasEngine)
                    {
                        insertVehicleGasMotorcycle(motorcycle);
                    }
                    else
                    {
                        insertVehicleElectricMotorcycle(motorcycle);
                    }
                    break;
                case Truck truck:
                    insertVehicleTruck(truck);
                    break;
                default:
                    break;
            }
        }
        private void insertVehicleTruck(Truck i_Truck)
        {
            insertGeneralVehicleStatus(i_Truck);
        }
        private void insertVehicleElectricMotorcycle(Motorcycle i_Motorcycle)
        {
            insertGeneralVehicleStatus(i_Motorcycle);
        }
        private void insertVehicleGasMotorcycle(Motorcycle i_Motorcycle)
        {
            insertGeneralVehicleStatus(i_Motorcycle);
        }
        private void insertVehicleElectricCar(Car i_Car)
        {
            insertGeneralVehicleStatus(i_Car);
            m_CarConsole.InsertElectricCarStatus(ref i_Car);
        }
        private void insertVehicleGasCar(Car i_Car)
        {
            insertGeneralVehicleStatus(i_Car);
            m_CarConsole.InsertGasCarStatus(ref i_Car);
        }
        private void insertGeneralVehicleStatus(Vehicle i_Vehicle)
        {
            string msg = "Please enter Model Name:";
            Console.WriteLine(msg);
            i_Vehicle.ModelName = getModelOrManufacturerNameFromUser();
            currentWheelsCondition(i_Vehicle);
        }
        private string getModelOrManufacturerNameFromUser()
        {
            string modelName = string.Empty;
            bool isValidInput = false;

            while (isValidInput == false)
            {
                modelName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(modelName))
                {
                    string msg = "Input cannot be empty or whitespace. Please try again.";
                    Console.WriteLine(msg);
                }
                else
                {
                    isValidInput = true;
                }
            }

            return modelName;
        }
        private float currentEnergyPercentage(float i_MaxEnergy)
        {
            float currentEnergy = 0;
            bool isValidInput = false;
            string userInput = string.Empty;
            int k_MinEnergy = 0;
            string msg = string.Empty;

            while (isValidInput == false)
            {
                try
                {
                    msg = string.Format("Please Enter The current energy percentage (value between {0} - {1}):", i_MinEnergy, i_MaxEnergy);
                    Console.WriteLine(msg);
                    userInput = Console.ReadLine();
                    if (float.TryParse(userInput, out currentEnergy) == false)
                    {
                        throw new FormatException("Invalid input. Please enter a numeric value.");
                    }

                    if (currentEnergy < k_MinEnergy || currentEnergy > i_MaxEnergy)
                    {
                        throw new ValueOutOfRangeException(k_MinEnergy, i_MaxEnergy);
                    }

                    isValidInput = true;
                }
                catch (FormatException ex)
                {
                    msg = string.Format("Error: {0}", ex.Message);
                }
                catch (ValueOutOfRangeException ex)
                {
                    msg = string.Format("Error: {0}", ex.Message);
                    Console.WriteLine(msg);
                }
                catch (Exception ex)
                {
                    msg = string.Format("Error: {0}", ex.Message);
                    Console.WriteLine(msg);
                }
            }

            float energyPercentage = (currentEnergy / i_MaxEnergy) * 100;
            return energyPercentage;
        }
        private void currentWheelsCondition(Vehicle i_Vehicle)
        {
            string msg = "Please enter Manufacturer Name:";
            Console.WriteLine(msg);
            getModelOrManufacturerNameFromUser();
            i_Vehicle.EnergyPercentage = currentEnergyPercentage(i_Vehicle.Wheels[0].MaxAirPressure);
        }
    }
}
