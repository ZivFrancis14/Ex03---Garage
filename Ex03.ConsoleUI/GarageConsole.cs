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
    internal class GarageConsole
    {
        private VehiclesCreator m_VehiclesCreator;
        private GarageManager m_GarageManager;
        private CarConsole m_CarConsole;
        private MotorcycleConsole m_MotorcycleConsole;
        private TruckConsole m_TruckConsole;
        private VehicleRecord m_VehicleRecord;

        public void startGarageSystem()
        {
            m_GarageManager = new GarageManager();
            m_CarConsole = new CarConsole();
            m_MotorcycleConsole = new MotorcycleConsole();
            m_TruckConsole = new TruckConsole();
            m_VehiclesCreator = new VehiclesCreator();
            bool userExit = false;

            string msg = string.Empty;

            msg = "Welcome To The Garage";
            Console.WriteLine(msg);
            while (userExit == false)
            {
                userExit = selectOptionFromMenu();
            }

            msg = "Bye!";
            Console.WriteLine(msg);
        }
        private bool selectOptionFromMenu()
        {
            int userChoice = 0;
            string msg = string.Empty;
            const int k_MinValue = 1;
            const int k_MaxValue = 7;
            bool userExit = false;

            printOptionsMenu();
            userChoice = getUserOption(k_MinValue, k_MaxValue);

            switch (userChoice)
            {
                case 1:
                    vehicleByPlateNumberToGarage();
                    break;
                case 2:
                    displayCurrentVehicleInGarage();
                    break; 
                case 3:
                    changeVehicleStatus();
                    break;
                case 4:
                    fillMaxAirWheels();
                    break;
                case 5:
                    refuelOrChargeVehicle();
                    break;
                case 6:
                    displayVehicleDetails();
                    break;
                case 7:
                    userExit = true;
                    break;
                default:
                    msg = "Invalid choice.";
                    Console.WriteLine(msg);
                    break;
            }

            return userExit;
        }
        private void printOptionsMenu()
        {
            string msg = string.Format(
            "Please choose an option from the menu:\n" +
            "1. Add a new vehicle to the garage\n" +
            "2. Display the licence plate numbers of current vehicles in the garage\n" +
            "3. Change Vehicle status\n" +
            "4. Fill air in wheels\n" +
            "5. Refuel/Charge Vehicle\n" +
            "6. Display full details for vehicle\n" +
            "7. Exit");
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
            string licencePlateNumber = string.Empty;;

            licencePlateNumber = getLicencePlateNumberFromUser();
            if (vehicleIsExist(licencePlateNumber) == true)
            {
                vehicleAllreadyInGarage(licencePlateNumber);
            }
            else
            {
                newVehicle = createNewVehicle(licencePlateNumber);
                setVehicleDetails(newVehicle);
                createVehicleRecord(newVehicle);
            }
        }
        private void vehicleAllreadyInGarage(string i_LicencePlateNumber)
        {
            string msg = "This vehicle licence plate number allready exist. Status change to: Repair";
            Console.WriteLine(msg);
            m_GarageManager.CurrentVehicleInGarage[i_LicencePlateNumber].VehicleStatus = eVehicleStatus.Repaired;
        }
        private void createVehicleRecord(Vehicle i_Vehicle)
        {
            VehicleRecord newVehicleRecord = null;
            string ownerName = string.Empty;
            string ownerNumber = string.Empty;

            ownerName = getOwnerNameFromUser();
            ownerNumber = getOwnerNumberFromUser();
            newVehicleRecord = new VehicleRecord(i_Vehicle, ownerName, ownerNumber, eVehicleStatus.InRepair);
            m_GarageManager.AddNewVehicle(newVehicleRecord);
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
        private void displayCurrentVehicleInGarage()
        {
            string msg = string.Empty;
            int userChoice = 0;
            const int k_MinValue = 1;
            const int k_MaxValue = 2;

            msg = "Select an option to display (press 1 or 2):\n(1) Filter display by vehicle condition\n(2) Unfiltered display";
            Console.WriteLine(msg);
            userChoice = getUserOption(k_MinValue, k_MaxValue);
            switch (userChoice)
            {
                case 1:
                    displayFilteredVehicles();
                    break;
                case 2:
                    printAllVehicleInGarage();
                    break;
                default:
                    msg = "Invalid choice.";
                    Console.WriteLine(msg);
                    break;
            }
        }
        private void displayFilteredVehicles()
        {
            string msg = string.Empty;
            int userChoice = 0;

            msg = "Select a condition to filter by:\n(1) In Repair\n(2) Repaired\n(3) Paid";
            Console.WriteLine(msg);
            userChoice = getUserOption(1, 3);

            eVehicleStatus filterCondition = (eVehicleStatus)userChoice;
            displayVehiclesByStatus(filterCondition);
        }
        private void displayVehiclesByStatus(eVehicleStatus i_VehicleStatus)
        {
            string msg = string.Empty;
            bool isFound = false;

            foreach(var record in m_GarageManager.CurrentVehicleInGarage.Values)
            {
                if(record.VehicleStatus == i_VehicleStatus)
                {
                    msg = string.Format("{0}", record.Vehicle.LicencePlate);
                    Console.WriteLine(msg);
                    isFound = true;
                }
            }

            if(isFound == false)
            {
                msg = string.Format("No vehicles found with status {0}", i_VehicleStatus.ToString());
                Console.WriteLine(msg);
            }
        }
        private void printAllVehicleInGarage()
        {
            string msg = string.Empty;

            if (m_GarageManager.CurrentVehicleInGarage.Count == 0)
            {
                msg = "There are no vehicles in the garage.";
                Console.WriteLine(msg);
            }
            else
            {
                msg = "Current vehicles in the garage:";
                Console.WriteLine(msg);
                foreach (string licencePlate in m_GarageManager.CurrentVehicleInGarage.Keys)
                {
                    msg = string.Format("Licence Plate: {0}", licencePlate);
                    Console.WriteLine(msg);
                }
            }
        }
        private string getOwnerNameFromUser()
        {
            string ownerName = string.Empty;
            string msg = string.Empty;
            bool isValidInput = false;

            while (isValidInput == false)
            {
                try
                {
                    msg = "Please enter the owner's name:";
                    Console.WriteLine(msg);
                    ownerName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(ownerName))
                    {
                        throw new FormatException("The owner's name cannot be empty.");
                    }

                    isValidInput = true;
                }
                catch (FormatException ex)
                {
                    msg = string.Format("Error: {0}", ex.Message);
                    Console.WriteLine(msg);
                }
            }

            return ownerName;
        }
        private string getOwnerNumberFromUser()
        {
            string ownerPhone = string.Empty;
            string msg = string.Empty;
            bool isValidInput = false;

            while (!isValidInput)
            {
                try
                {
                    msg = "Please enter the owner's phone number:";
                    Console.WriteLine(msg);
                    ownerPhone = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(ownerPhone) || !ownerPhone.All(char.IsDigit))
                    {
                        throw new FormatException("The phone number must contain digits only and cannot be empty.");
                    }

                    isValidInput = true;
                }
                catch (FormatException ex)
                {
                    msg = string.Format("Error: {0}", ex.Message);
                    Console.WriteLine(msg);
                }
            }

            return ownerPhone;
        }
        private void changeVehicleStatus()
        {

        }
        private void fillMaxAirWheels()
        {

        }
        private void refuelOrChargeVehicle()
        {

        }
        private void displayVehicleDetails()
        {
            string licencePlateNumber = getLicencePlateNumberFromUser();
            var vehicleRecord = m_GarageManager.CurrentVehicleInGarage[licencePlateNumber];
            string fuelType = getFuelType(vehicleRecord.Vehicle.Engine);            

            string msg = "Vehicle Details:";
            Console.WriteLine(msg);
            msg = string.Format(
            "- Licence Plate: {0}\n" +
            "- Model Name: {1}\n" +
            "- Owner Name: {2}\n" +
            "- Owner Phone: {3}\n" +
            "- Vehicle Status: {4}\n" +
            "- Energy Type: {5}\n" +
            "- Current Energy Percentage: {6}%\n" +
            "- Wheels Manufacturer: {7}\n" +
            "- Wheels Current Air Pressure: {8}",
                licencePlateNumber, vehicleRecord.Vehicle.VehicleModelName, vehicleRecord.OwnerName,
                vehicleRecord.OwnerPhone, vehicleRecord.VehicleStatus,fuelType, vehicleRecord.Vehicle.Engine.EnergyPrecentage(),
                vehicleRecord.Vehicle.Wheels[0].ManufacturerName, vehicleRecord.Vehicle.Wheels[0].CurrentAirPressure);
            Console.WriteLine(msg);
            switch(vehicleRecord.Vehicle)
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
        private string getFuelType(Engine i_Engine)
        {
            string fuelType;

            if (i_Engine is GasEngine gasEngine)
            {
                fuelType = string.Format("{0}", gasEngine.FuelType.ToString());
            }
            else
            {
                fuelType = "Electric";
            }

            return fuelType;
        }

    }
}
