using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_Ziv_315154351_Rony_318916871
{
    internal class TruckConsole
    {
        public void InsertTruckStatus(List<object> valuesToVehicle)
        {
            valuesToVehicle.Add(isTransportingRefrigerate());
            valuesToVehicle.Add(getCargoVolume());
        }
        public bool isTransportingRefrigerate()
        {
            bool isValidInput = false;
            bool isTransportingRefrigerated = false;
            string msg = string.Empty;

            while (isValidInput == false)
            {
                try
                {
                    msg = "Does the truck transport refrigerated cargo? (1 for Yes, 2 for No):";
                    Console.WriteLine(msg);
                    string userInput = Console.ReadLine();
                    if (!int.TryParse(userInput, out int choice) || (choice != 1 && choice != 2))
                    {
                        throw new FormatException("Invalid input. Please enter 1 for Yes or 2 for No.");
                    }

                    isTransportingRefrigerated = (choice == 1);
                    isValidInput = true;
                }
                catch (FormatException ex)
                {
                    msg = string.Format("Error: {0}", ex.Message);
                    Console.WriteLine(msg);
                }
            }

            return isTransportingRefrigerated;
        }

        internal void DisplayTruckDetails(Truck i_Truck)
        {
            string msg = string.Empty;

            msg = string.Format("- Is Transporting Refrigerate: {0}\n- Engine Volume: {1}", i_Truck.TransportingRefrigerate.ToString(), i_Truck.CargoVolume);
            Console.WriteLine(msg);
        }

        private float getCargoVolume()
        {
            float cargoVolume = 0.0f;
            bool isValidInput = false;
            string msg = string.Empty;

            while (isValidInput == false)
            {
                try
                {
                    msg = "Please enter the cargo volume:";
                    Console.WriteLine(msg);
                    string userInput = Console.ReadLine();
                    if (!float.TryParse(userInput, out cargoVolume) || cargoVolume <= 0)
                    {
                        throw new FormatException("Invalid input. Please try again.");
                    }

                    isValidInput = true;
                }
                catch (FormatException ex)
                {
                    msg = string.Format("Error: {0}", ex.Message);
                    Console.WriteLine(msg);
                }
            }

            return cargoVolume;
        }
    }
}
