using Ex03.GarageLogic;
using Ex03.GarageLogic.Enums;
using Ex03_Ziv_315154351_Rony_318916871;
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
        private GarageManager m_GarageManager;
        private CarConsole m_CarConsole;
        private MotorcycleConsole m_MotorcycleConsole;
        private TruckConsole m_TruckConsole;

        public void startGarageSystem()
        {
            m_GarageManager = new GarageManager();
            m_CarConsole = new CarConsole();
            m_MotorcycleConsole = new MotorcycleConsole();
            m_TruckConsole = new TruckConsole();

            string msg = string.Empty;

            msg = "Welcome To The Garage";
            Console.WriteLine(msg);
            selectOptionFromMenu();
        }
        private void selectOptionFromMenu()
        {
            int userChoice = 0;
            string msg = string.Empty;

            printOptionsMenu();
            userChoice = getUserOption(1, 2);

            switch (userChoice)
            {
                case 1:
                    msg = "You selected to add a new car to the garage.";
                    Console.WriteLine(msg);
                    vehicleByPlateNumberToGarage();
                    break;
                case 2:
                    msg = "You selected to display licence plate numbers of vehicles in the garage.";
                    Console.WriteLine(msg);
                    break;
                default:
                    msg = "Invalid choice.";
                    Console.WriteLine(msg);
                    break;
            }
        }
        private void printOptionsMenu()
        {
            string msg = "Please choose an option from the menu:";
            Console.WriteLine(msg);

            msg = "1.Add a new vehicle to the garage";
            Console.WriteLine(msg);

            msg = "2. Display the licence plate numbers of current vehicles in the garage";
            Console.WriteLine(msg);

        }
        private int getUserOption(int minOption, int maxOption)
        {
            int userChoice = 0;
            bool isValidInput = false;
            string msg = string.Empty;

            while (isValidInput == false)
            {
                try
                {
                    msg = "Please enter your choice:";
                    Console.WriteLine(msg);
                    string userInput = Console.ReadLine();
                    if (int.TryParse(userInput, out userChoice) == false)
                    {
                        msg = "Invalid input. Please enter a numeric value.";
                        throw new FormatException(msg);
                    }
                    if (userChoice < minOption || userChoice > maxOption)
                    {
                        msg = string.Format("Invalid option. Please select a number between {0} and {1}.", minOption, maxOption);
                        throw new FormatException(msg);
                    }

                    isValidInput = true;
                }
                catch (FormatException ex)
                {
                    msg = string.Format("Error: {0}", ex.Message);
                    Console.WriteLine(msg);
                }
            }

            return userChoice;
        }
        private void vehicleByPlateNumberToGarage()
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
                setVehicleDetails(newVehicle);
            }
        }
        private bool vehicleIsExist(string i_LicencePlateNumber)
        {
            return m_GarageManager.isVehicleExisit(i_LicencePlateNumber);
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
            eVehicleType userVehicleChoice = getUserVehicleOptions(m_VehiclesCreator.CurrentVehicleTypes);

            switch (userVehicleChoice)
            {
                case eVehicleType.GasCar:
                    newVehicle = m_VehiclesCreator.CreateGasCar(i_LicencePlateNumber, ref m_GarageManager);
                    break;
                case eVehicleType.ElectricCar:
                    newVehicle = m_VehiclesCreator.CreateElectricCar(i_LicencePlateNumber, ref m_GarageManager);
                    break;
                case eVehicleType.GasMotorcycle:
                    newVehicle = m_VehiclesCreator.CreateGasMotorcycle(i_LicencePlateNumber, ref m_GarageManager);
                    break;
                case eVehicleType.ElectricMotorcycle:
                    newVehicle = m_VehiclesCreator.CreateElectricMotorcycle(i_LicencePlateNumber, ref m_GarageManager);
                    break;
                case eVehicleType.Truck:
                    newVehicle = m_VehiclesCreator.CreateTruck(i_LicencePlateNumber, ref m_GarageManager);
                    break;
                default:
                    break;
            }

            return newVehicle;
        }
        private eVehicleType getUserVehicleOptions(eVehicleType[] i_VehicleOptions)
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
        private void setVehicleDetails(Vehicle i_Vehicle)
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
            currentEnergyPercentage = currentEnergyAmountInput();
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
                    msg = string.Format("Please Enter The current PressureInput:"); // (value between {0} - {1}):", i_MinEnergy, i_MaxEnergy);
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
        private float currentEnergyAmountInput()
        {
            float currentEnergy = 0;
            bool isValidInput = false;
            string userInput = string.Empty;
            string msg = string.Empty;

            while (isValidInput == false)
            {
                try
                {
                    msg = string.Format("Please Enter The current energy amount (in liters or hours):"); // (value between {0} - {1}):", i_MinEnergy, i_MaxEnergy);
                    Console.WriteLine(msg);
                    userInput = Console.ReadLine();
                    if (float.TryParse(userInput, out currentEnergy) == false)
                    {
                        throw new FormatException("Invalid input. Please enter a numeric value.");
                    }

                    if (currentEnergy < 0 || currentEnergy > 100)
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
    }
}
