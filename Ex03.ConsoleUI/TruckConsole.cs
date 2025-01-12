using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03_Ziv_315154351_Rony_318916871
{
    public class TruckConsole
    {
        public bool isTransportingRefrigerate()
        {
            bool isValidInput = false;
            bool isTransportingRefrigerated = false;
            string msg = string.Empty;

            while (!isValidInput)
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
                catch (Exception ex)
                {
                    msg = string.Format("Unexpected error: {0}", ex.Message);
                    Console.WriteLine(msg);
                }
            }

            return isTransportingRefrigerated;
        }
    }
}
