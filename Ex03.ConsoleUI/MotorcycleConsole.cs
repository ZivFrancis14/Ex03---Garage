using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_Ziv_315154351_Rony_318916871
{
    internal class MotorcycleConsole
    {
        public void InsertMotorcycleStatus(List<object> valuesToVehicle)
        {
            valuesToVehicle.Add(getLicenceType());
            valuesToVehicle.Add(getEngineCapacity());
        }
        private eLicenceType getLicenceType()
        {
            eLicenceType licenceType = eLicenceType.A1;
            bool isValidInput = false;
            string msg = string.Empty;

            while (isValidInput == false)
            {
                try
                {
                    msg = "Please select a licence type from the following options:";
                    Console.WriteLine(msg);
                    foreach (eLicenceType type in Enum.GetValues(typeof(eLicenceType)))
                    {
                        Console.WriteLine(string.Format("- {0}", type));
                    }

                    msg = "Enter your licence type:";
                    Console.WriteLine(msg);
                    string userInput = Console.ReadLine();
                    if (!Enum.TryParse(userInput, true, out licenceType) || !Enum.IsDefined(typeof(eLicenceType), licenceType))
                    {
                        throw new FormatException("Invalid licence type. Please select a valid option.");
                    }

                    isValidInput = true; 
                }
                catch (FormatException ex)
                {
                    msg = string.Format("Error: {0}", ex.Message);
                    Console.WriteLine(msg);
                }
            }

            return licenceType;
        }
        private int getEngineCapacity()
        {
            int engineCapacity = 0;
            bool isValidInput = false;
            string msg = string.Empty;

            while (isValidInput == false)
            {
                try
                {
                    msg = "Please enter the engine capacity (in cc, must be a positive integer):";
                    Console.WriteLine(msg);
                    string userInput = Console.ReadLine();
                    if (!int.TryParse(userInput, out engineCapacity) || engineCapacity <= 0)
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

            return engineCapacity;
        }

        internal void DisplayMotorcycleDetails(Motorcycle i_Motorcycle)
        {
            string msg = string.Empty;

            msg = string.Format("- Licence Type: {0}\n- Engine Volume: {1}", i_Motorcycle.LicenceType.ToString(), i_Motorcycle.EngineVolume);
            Console.WriteLine(msg);
        }
    }
}
