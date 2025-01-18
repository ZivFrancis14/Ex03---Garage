using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using Ex03.ConsoleUI;

namespace Ex03.ConsoleUI
{
    internal class VehicleConsole
    {
        private VehiclesCreator m_VehiclesCreator;
        private CarConsole m_CarConsole;
        private MotorcycleConsole m_MotorcycleConsole;
        private TruckConsole m_TruckConsole;

        public Vehicle CreateNewVehicle(string i_LicencePlateNumber, ref GarageManager i_GarageManager)
        {
            Vehicle newVehicle = null;
            m_VehiclesCreator = new VehiclesCreator();
            eVehicleType userVehicleChoice = getUserVehicleFromCurrentsOptions(m_VehiclesCreator.CurrentVehicleTypes);

            switch (userVehicleChoice)
            {
                case eVehicleType.GasCar:
                    newVehicle = m_VehiclesCreator.CreateGasCar(i_LicencePlateNumber, ref i_GarageManager);
                    break;
                case eVehicleType.ElectricCar:
                    newVehicle = m_VehiclesCreator.CreateElectricCar(i_LicencePlateNumber, ref i_GarageManager);
                    break;
                case eVehicleType.GasMotorcycle:
                    newVehicle = m_VehiclesCreator.CreateGasMotorcycle(i_LicencePlateNumber, ref i_GarageManager);
                    break;
                case eVehicleType.ElectricMotorcycle:
                    newVehicle = m_VehiclesCreator.CreateElectricMotorcycle(i_LicencePlateNumber, ref i_GarageManager);
                    break;
                case eVehicleType.Truck:
                    newVehicle = m_VehiclesCreator.CreateTruck(i_LicencePlateNumber, ref i_GarageManager);
                    break;
                default:
                    break;
            }

            return newVehicle;
        }
        private eVehicleType getUserVehicleFromCurrentsOptions(eVehicleType[] i_VehicleOptions)
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
        public void SetVehicleDetails(Vehicle i_Vehicle)
        {
            bool inputIsValid = false;
            string msg = string.Empty;
            m_CarConsole = new CarConsole();
            m_MotorcycleConsole = new MotorcycleConsole();
            m_TruckConsole = new TruckConsole();

            while (inputIsValid == false)
            {
                try
                {
                    List<object> valuesToVehicle = getGeneralVehicleDetails(i_Vehicle);
                    switch (i_Vehicle)
                    {
                        case Car car:
                            m_CarConsole.InsertCarStatus(valuesToVehicle);
                            break;
                        case Motorcycle motorcycle:
                            m_MotorcycleConsole.InsertMotorcycleStatus(valuesToVehicle);
                            break;
                        case Truck truck:
                            m_TruckConsole.InsertTruckStatus(valuesToVehicle);
                            break;
                        default:
                            break;
                    }

                    i_Vehicle.CompleteVehicleDetails(valuesToVehicle);
                    inputIsValid = true;
                }
                catch (ValueOutOfRangeException ex)
                {
                    msg = string.Format("Error: {0}", ex.Message);
                    Console.WriteLine(msg);
                }
                catch (FormatException ex)
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
        }
        private List<object> getGeneralVehicleDetails(Vehicle i_Vehicle)
        {
            string modelName = string.Empty;
            float currentEnergyPercentage = 0;
            float currentWheelsPressure = 0;
            string manufacturerName = string.Empty;

            string msg = "Please enter Model Name:";
            Console.WriteLine(msg);
            modelName = getModelOrManufacturerNameFromUser();
            currentEnergyPercentage = getEnergyAmountInput();
            msg = "Please enter wheel manufacturer name:";
            Console.WriteLine(msg);
            manufacturerName = getModelOrManufacturerNameFromUser();
            currentWheelsPressure = currentWheelsPressureInput();

            List<object> generalVehicleDetails = new List<object>
            {
                modelName,
                currentEnergyPercentage,
                currentWheelsPressure,
                manufacturerName
            };

            return generalVehicleDetails;
        }
        private string getModelOrManufacturerNameFromUser()
        {
            string modelName = string.Empty;
            bool isValidInput = false;

            while (isValidInput == false)
            {
                try
                {
                    modelName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(modelName))
                    {
                        throw new FormatException("Input cannot be empty or whitespace.");
                    }

                    isValidInput = true;
                }
                catch (FormatException ex)
                {
                    string msg = string.Format("Error: {0}", ex.Message);
                    Console.WriteLine(msg);
                }
                catch (Exception ex)
                {
                    string msg = string.Format("Error: {0}", ex.Message);
                    Console.WriteLine(msg);
                }
            }

            return modelName;
        }
        private float currentWheelsPressureInput()
        {
            float currentPressure = 0;
            bool isValidInput = false;
            string userInput = string.Empty;
            string msg = string.Empty;

            while (isValidInput == false)
            {
                try
                {
                    msg = string.Format("Please Enter The current PressureInput:");
                    Console.WriteLine(msg);
                    userInput = Console.ReadLine();
                    if (float.TryParse(userInput, out currentPressure) == false)
                    {
                        throw new FormatException("Invalid input. Please enter a numeric value.");
                    }

                    isValidInput = true;
                }
                catch (FormatException ex)
                {
                    msg = string.Format("Error: {0}", ex.Message);
                }
            }

            return currentPressure;
        }
        private float getEnergyAmountInput()
        {
            float currentEnergy = 0;
            bool isValidInput = false;
            string userInput = string.Empty;
            string msg = string.Empty;

            while (isValidInput == false)
            {
                try
                {
                    msg = string.Format("Please Enter The energy amount (in liters or hours):");
                    Console.WriteLine(msg);
                    userInput = Console.ReadLine();
                    if (float.TryParse(userInput, out currentEnergy) == false)
                    {
                        throw new FormatException("Invalid input. Please enter a numeric value.");
                    }

                    if (currentEnergy < 0)
                    {
                        throw new FormatException();
                    }

                    isValidInput = true;
                }
                catch (FormatException ex)
                {
                    msg = string.Format("Error: {0}", ex.Message);
                }
            }

            return currentEnergy;
        }
        public void DisplayVehicleDetailsByType(Vehicle i_Vehicle)
        {
            switch (i_Vehicle)
            {
                case Car car:
                    m_CarConsole.DisplayCarDetails(car);
                    break;

                case Motorcycle motorcycle:
                    m_MotorcycleConsole.DisplayMotorcycleDetails(motorcycle);
                    break;

                case Truck truck:
                    m_TruckConsole.DisplayTruckDetails(truck);
                    break;

                default:
                    break;
            }
        }
        public void FillEnergyInVehicle(Vehicle i_Vehicle)
        {
            bool inputIsValid = false;

            while (inputIsValid == false)
            {
                try
                {
                    float energyFillAmount = getEnergyAmountInput();
                    
                    if (i_Vehicle.Engine is GasEngine gasEngine)
                    {
                        eFuelType fuelType = getFuelTypeFromUser();
                        gasEngine.RefuelTheCar(energyFillAmount, fuelType);
                    }
                    else if (i_Vehicle.Engine is ElectricEngine electricEngine)
                    {
                        electricEngine.ChargeTheCar(energyFillAmount);
                    }

                    inputIsValid = true;
                }
                catch (ValueOutOfRangeException ex)
                {
                    string msg = string.Format("Error: {0}", ex.Message);
                    Console.WriteLine(msg);
                }
                catch (Exception ex)
                {
                    string msg = string.Format("Error: {0}", ex.Message);
                    Console.WriteLine(msg);
                }
            }
        }
        private eFuelType getFuelTypeFromUser()
        {
            eFuelType fuelType = eFuelType.Soler;
            bool isValidInput = false;
            string msg = string.Empty;

            while (isValidInput == false)
            {
                try
                {
                    msg = "Please select the type of fuel from the following options:";
                    Console.WriteLine(msg);

                    foreach (eFuelType type in Enum.GetValues(typeof(eFuelType)))
                    {
                        msg = string.Format("- {0} ({1})", type, (int)type + 1);
                        Console.WriteLine(msg);
                    }

                    string userInput = Console.ReadLine();
                    if (!int.TryParse(userInput, out int selectedOption) || selectedOption < 1 || selectedOption > Enum.GetValues(typeof(eFuelType)).Length)
                    {
                        throw new FormatException("Invalid input. Please select a valid number from the options provided.");
                    }

                    fuelType = (eFuelType)(selectedOption - 1);
                    isValidInput = true;
                }
                catch (FormatException ex)
                {
                    msg = string.Format("Error: {0}", ex.Message);
                    Console.WriteLine(msg);
                }
            }

            return fuelType;
        }

    }
}
