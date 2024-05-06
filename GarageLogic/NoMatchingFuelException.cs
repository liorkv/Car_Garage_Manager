using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class NoMatchingFuelException : Exception
    {
        private string m_VehicleFuelType;
        private string m_DesiredCustomerFuelType;
      public NoMatchingFuelException(string i_VehicleFuelType, string i_DesiredCustomerFuelType) : base(String.Format("The fuel type {0} that you have chose to refuel your tank with it is incorrect. The correct fuel type of the vehicle is {1}", i_DesiredCustomerFuelType, i_VehicleFuelType))
      {
            m_VehicleFuelType = i_VehicleFuelType;
            m_DesiredCustomerFuelType = i_DesiredCustomerFuelType;
      }
    }
}
