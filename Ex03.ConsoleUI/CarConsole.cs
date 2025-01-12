using Ex03.GarageLogic;
using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class CarConsole
    {
        public void InsertGasCarStatus(ref Car i_Car)
        {            
            currentFuelQuantityInLiters();
            getColorOfCar();
        }
        public void InsertElectricCarStatus(ref Car i_Car)
        {
            currentBatteryStatus();
            getColorOfCar();
        }
        private eColorType getColorOfCar()
        {
            eColorType carColor = eColorType.White;
            bool isValidInput = false;
            string msg = string.Empty;

            while (isValidInput == false)
            {
                try
                {
                    msg = "Please enter the color of the car from the following options:";
                    Console.WriteLine(msg);

                    foreach (eColorType color in Enum.GetValues(typeof(eColorType)))
                    {
                        msg = string.Format("- {0}", color);
                        Console.WriteLine(msg);
                    }

                    msg = "Enter the color:";
                    Console.WriteLine(msg);
                    string userInput = Console.ReadLine();

                    if (Enum.TryParse(userInput, true, out carColor) == false || Enum.IsDefined(typeof(eColorType), carColor) == false)
                    {
                        throw new FormatException("Invalid color. Please select a color from the options provided.");
                    }

                    isValidInput = true;
                }
                catch (FormatException ex)
                {
                    msg = string.Format("Error: {0}", ex.Message);
                    Console.WriteLine(msg);
                }
                catch (Exception ex)
                {
                    msg = string.Format("Unexpected error: {0}", ex.Message);
                    Console.WriteLine(msg);
                }
            }

            return carColor;
        }
        private float currentFuelQuantityInLiters()
        {
            float currentFuelQuantity = 0;
            bool isValidInput = false;
            string msg = string.Empty;

            while (isValidInput == false)
            {
                try
                {
                    msg = string.Format("Please enter the current fuel quantity in liters (0 to {0}):", i_MaxFuelQuantity);
                    Console.WriteLine(msg);
                    string userInput = Console.ReadLine();
                    if (float.TryParse(userInput, out currentFuelQuantity) == false)
                    {
                        throw new FormatException("Invalid input. Please enter a numeric value.");
                    }

                    //if (currentFuelQuantity < 0 || currentFuelQuantity > i_MaxFuelQuantity)
                    //{
                    //    throw new ValueOutOfRangeException(0, i_MaxFuelQuantity, "Fuel quantity is out of range.");
                    //}

                    isValidInput = true;
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

            return currentFuelQuantity;
        }
        private float currentBatteryStatus()
        {
            float currentBatteryLevel = 0;
            bool isValidInput = false;
            string msg = string.Empty;

            while (isValidInput == false)
            {
                try
                {
                    msg = string.Format("Please enter the current battery level in hours (0 to {0}):", i_MaxBatteryCapacity);
                    Console.WriteLine(msg);
                    string userInput = Console.ReadLine();
                    if (float.TryParse(userInput, out currentBatteryLevel) == false)
                    {
                        throw new FormatException("Invalid input. Please enter a numeric value.");
                    }

                    //if (currentBatteryLevel < 0 || currentBatteryLevel > i_MaxBatteryCapacity)
                    //{
                    //    throw new ValueOutOfRangeException(0, i_MaxBatteryCapacity, "Battery level is out of range.");
                    //}

                    isValidInput = true;
                }
                catch (FormatException ex)
                {
                    msg = string.Format("Error: {0}", ex.Message);
                    Console.WriteLine(msg);
                }
                //catch (ValueOutOfRangeException ex)
                //{
                //    msg = string.Format("Error: {0}", ex.Message);
                //    Console.WriteLine(msg);
                //    Console.WriteLine($"Allowed range: {ex.MinValue} - {ex.MaxValue} hours.");
                //}
                catch (Exception ex)
                {
                    msg = string.Format("Unexpected error: {0}", ex.Message);
                    Console.WriteLine(msg);
                }
            }

            return currentBatteryLevel;
        }
    }
}
