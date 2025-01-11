using Ex03.GarageLogic;
using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.ConsoleUI
{
    public class GarageConsole
    {
        private VehiclesCreator m_VehiclesCreator;

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
                        throw new ArgumentOutOfRangeException("choice", "The number you entered is out of range.");
                    }
                    userChoice = i_VehicleOptions[choice - 1];
                    inputIsValid = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An unexpected error occurred: " + ex.Message);
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
                        insertGasCarStatus(car);
                    }
                    else
                    {
                        insertElectricCarStatus(car);
                    }
                    break;
                case Motorcycle motorcycle:
                    if (motorcycle.Engine is GasEngine)
                    {
                        insertGasMotorcycleStatus(motorcycle);
                    }
                    else(motorcycle.Engine is ElectricEngine)
                    {
                        insertElectricMotorcycleStatus(motorcycle);
                    }
                    break;
                case Truck truck:
                    insertTruckStatus(truck);
                    break;
                default:
                    break;
            }
        }
        private void insertTruckStatus(Truck truck)
        {
            throw new NotImplementedException();
        }

        private void insertElectricMotorcycleStatus(Motorcycle motorcycle)
        {
            throw new NotImplementedException();
        }

        private void insertGasMotorcycleStatus(Motorcycle motorcycle)
        {
            throw new NotImplementedException();
        }

        private void insertElectricCarStatus(Car car)
        {
            throw new NotImplementedException();
        }

        private void insertGasCarStatus(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
