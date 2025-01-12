using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class CarConsole
    {
        public void InsertGasCarStatus(ref Car car)
        {            
            currentFuelQuantityInLiters();
            getColorOfCar();
        }
        public void InsertElectricCarStatus(ref Car car)
        {
            currentBatteryStatus();
            getColorOfCar();
        }
        private void getColorOfCar()
        {
            
        }
        public void InsertElectricCarStatus(Car car)
        {
           
        }
        private float currentFuelQuantityInLiters(float i_MaxFuelQuantity)
        {
            float currentFuelQuantity = 0;
            bool isValidInput = false;

            while (isValidInput == false)
            {
                try
                {
                    string msg = string.Format("Please enter the current fuel quantity in liters (0 to {0}):", i_MaxFuelQuantity);
                    Console.WriteLine(msg);
                    string userInput = Console.ReadLine();
                    if (float.TryParse(userInput, out currentFuelQuantity))
                    {
                        msg = "Error: Invalid input. Please enter a numeric value.";
                        Console.WriteLine(msg);
                        continue;
                    }

                    // בדיקת טווח הערכים
                    if (currentFuelQuantity < 0 || currentFuelQuantity > i_MaxFuelQuantity)
                    {
                        msg = string.Format("Error: Fuel quantity is out of range. Allowed range: 0 - {0} liters.", i_MaxFuelQuantity);
                        Console.WriteLine(msg);
                        continue;
                    }

                    // אם הכל תקין, היציאה מהלולאה
                    isValidInput = true;
                }
                catch (Exception ex)
                {
                    string msg = string.Format("Unexpected error: {0}", ex.Message);
                    Console.WriteLine(msg);
                }
            }

            return currentFuelQuantity;
        }

        private void currentBatteryStatus()
        {

        }
    }
}
