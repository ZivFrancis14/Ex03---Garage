using Ex03.GarageLogic;
using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    internal class CarConsole
    {
        public void InsertCarStatus(List<object> valuesToVehicle)
        {            
            valuesToVehicle.Add(getColorOfCar());
            valuesToVehicle.Add(getNumberOfDoors());
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
        private int getNumberOfDoors()
        {
            int numberOfDoors = 0;
            bool isValidInput = false;
            string msg = string.Empty;

            while (isValidInput == false)
            {
                try
                {
                    msg = "Please enter the number of doors for the car:";
                    Console.WriteLine(msg);
                    string userInput = Console.ReadLine();
                    if (int.TryParse(userInput, out numberOfDoors) == false || numberOfDoors <= 0)
                    {
                        throw new FormatException("Invalid input. Please enter a numeric value.");
                    }

                    isValidInput = true; 

                }
                catch (FormatException ex)
                {
                    msg = string.Format("Error: {0}", ex.Message);
                    Console.WriteLine(msg);
                }
            }

            return numberOfDoors;
        }
        public void DisplayCarDetails(Car i_Car)
        {
            string msg = string.Empty;

            msg = string.Format("- Car Color: {0}\n- Doors Number: {1}", i_Car.CarColor, i_Car.NumOfDoors);
            Console.WriteLine(msg);

        }
    }
}
