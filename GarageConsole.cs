using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.ConsoleUI
{
    public class GarageConsole
    {        
        public void startGarageSystem()
        {
            string msg = string.Empty;

            msg = "Welcome To The Garage";
            Console.WriteLine(msg);
            getLicencePlateNumberFromUser();



        }
        private void getLicencePlateNumberFromUser()
        {
            string licencePlateNumber = string.Empty;
            bool isVAlid = false;
            string msg = string.Empty;

            while(isVAlid == false)
            {
                try
                {
                    msg = "Please Enter Licence Plate Number";
                    Console.WriteLine(msg);
                    licencePlateNumber = Console.ReadLine();
                    if(string.IsNullOrWhiteSpace(licencePlateNumber) == true || stringIsNumbersAndLetters(licencePlateNumber) == false)
                    {
                        throw new FormatException("License plate number must include letters and numbers only and not empty");
                    }

                    isVAlid = true;
                }
                catch(FormatException ex)
                {
                    msg = string.Format("Invalid input {0}", ex);
                    Console.WriteLine(msg);
                }
            }
            
        }
        private bool stringIsNumbersAndLetters(string input)
        {
            foreach (char c in input)
            {
                if (char.IsLetterOrDigit(c) == false)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
