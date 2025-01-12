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
        private void currentFuelQuantityInLiters()
        {

        }
        private void currentBatteryStatus()
        {

        }



    }
}
