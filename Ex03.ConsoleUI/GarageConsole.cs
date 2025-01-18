using Ex03.GarageLogic;
using Ex03.GarageLogic.Enums;
using Ex03_Ziv_315154351_Rony_318916871;
using System;
using System.Linq;

namespace Ex03.ConsoleUI
{
    internal class GarageConsole
    {
        private GarageManager m_GarageManager;
        private VehicleConsole m_VehicleConsole;
        private VehicleRecord m_VehicleRecord;

        public void StartGarageSystem()
        {
            m_GarageManager = new GarageManager();
            m_VehicleConsole = new VehicleConsole();
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
        private int getUserOption(int i_MinOption, int i_MaxOption)
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
                    if (userChoice < i_MinOption || userChoice > i_MaxOption)
                    {
                        msg = string.Format("Invalid option. Please select a number between {0} and {1}.", i_MinOption, i_MaxOption);
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
            string licencePlateNumber = string.Empty; ;

            licencePlateNumber = getLicencePlateNumberFromUser();
            if (vehicleIsExist(licencePlateNumber) == true)
            {
                vehicleAllreadyInGarage(licencePlateNumber);
            }
            else
            {
                newVehicle = m_VehicleConsole.CreateNewVehicle(licencePlateNumber, ref m_GarageManager);
                m_VehicleConsole.SetVehicleDetails(newVehicle);
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
            const int k_MinValue = 1;
            const int k_MaxValue = 2;

            msg = "Select a condition to filter by:\n(1) In Repair\n(2) Repaired\n(3) Paid";
            Console.WriteLine(msg);
            userChoice = getUserOption(k_MinValue, k_MaxValue);
            eVehicleStatus filterCondition = (eVehicleStatus)userChoice;
            displayVehiclesByStatus(filterCondition);
        }
        private void displayVehiclesByStatus(eVehicleStatus i_VehicleStatus)
        {
            string msg = string.Empty;
            bool isFound = false;

            foreach (var record in m_GarageManager.CurrentVehicleInGarage.Values)
            {
                if (record.VehicleStatus == i_VehicleStatus)
                {
                    msg = string.Format("{0}", record.Vehicle.LicencePlate);
                    Console.WriteLine(msg);
                    isFound = true;
                }
            }

            if (isFound == false)
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

            while (isValidInput == false)
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
            string licencePlateNumber = getExistingLicencePlateNumber();
            eVehicleStatus newStatus = getNewVehicleStatusFromUser();
            m_GarageManager.ChangeVehicleStatus(licencePlateNumber, newStatus);
            string msg = string.Format("The status of the vehicle with licence plate '{0}' has been successfully updated to '{1}'.", licencePlateNumber, newStatus);
            Console.WriteLine(msg);
        }
        private string getExistingLicencePlateNumber()
        {
            string licencePlateNumber = string.Empty;
            bool inputIsValid = false;
            string msg = string.Empty;

            while (inputIsValid == false)
            {
                licencePlateNumber = getLicencePlateNumberFromUser();
                if (vehicleIsExist(licencePlateNumber) == false)
                {
                    msg = string.Format("{0} Not Exiest", licencePlateNumber);
                    Console.WriteLine(msg);
                }
                else
                {
                    inputIsValid = true;
                }
            }

            return licencePlateNumber;
        }
        private eVehicleStatus getNewVehicleStatusFromUser()
        {
            const int k_MinValue = 1;
            const int k_MaxValue = 3;

            string msg = "Please select the new status for the vehicle:\n(1) In Repair\n(2) Repaired\n(3) Paid";
            Console.WriteLine(msg);
            int userChoice = getUserOption(k_MinValue, k_MaxValue);
            return (eVehicleStatus)userChoice;
        }
        private void fillMaxAirWheels()
        {
            string licencePlateNumber = getExistingLicencePlateNumber();
            m_GarageManager.CurrentVehicleInGarage[licencePlateNumber].Vehicle.FillMaxAirToWeels();
        }
        private void refuelOrChargeVehicle()
        {
            string licencePlateNumber = getExistingLicencePlateNumber();
            Vehicle vehicle = m_GarageManager.CurrentVehicleInGarage[licencePlateNumber].Vehicle;
            m_VehicleConsole.FillEnergyInVehicle(vehicle);
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
                vehicleRecord.OwnerPhone, vehicleRecord.VehicleStatus, fuelType, vehicleRecord.Vehicle.Engine.EnergyPrecentage(),
                vehicleRecord.Vehicle.Wheels[0].ManufacturerName, vehicleRecord.Vehicle.Wheels[0].CurrentAirPressure);
            Console.WriteLine(msg);
            m_VehicleConsole.DisplayVehicleDetailsByType(vehicleRecord.Vehicle);
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
