using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_Ziv_315154351_Rony_318916871
{
    public class MotorcycleConsole
    {
        public void InsertGasCarStatus(ref Motorcycle i_Motorcycle)
        {
            i_Motorcycle.LicenceType = getLicenceType();
        }
        public void InsertElectricCarStatus(ref Motorcycle i_Motorcycle)
        {
            i_Motorcycle.LicenceType = getLicenceType();
        }
        private eLicenceType getLicenceType()
        {
            eLicenceType licenceType = eLicenceType.A1; // ברירת מחדל
            bool isValidInput = false;
            string msg = string.Empty;

            while (isValidInput == false)
            {
                try
                {
                    msg = "Please select a licence type by entering the corresponding number:";
                    Console.WriteLine(msg);

                    eLicenceType[] licenceTypes = (eLicenceType[])Enum.GetValues(typeof(eLicenceType));
                    for (int i = 0; i < licenceTypes.Length; i++)
                    {
                        msg = string.Format("({0}) - {1}", i + 1, licenceTypes[i]);
                        Console.WriteLine(msg);
                    }

                    msg = "Enter the number of your choice:";
                    Console.WriteLine(msg);
                    string userInput = Console.ReadLine();
                    if (int.TryParse(userInput, out int choice) == false || choice < 1 || choice > licenceTypes.Length)
                    {
                        throw new FormatException("Invalid input. Please enter a number corresponding to a valid licence type.");
                    }

                    licenceType = licenceTypes[choice - 1];
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

            return licenceType;
        }

    }
}
