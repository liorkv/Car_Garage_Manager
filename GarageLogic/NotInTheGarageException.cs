using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class NotInTheGarageException : Exception
    {
        private string m_LicensePlate;

        public NotInTheGarageException(string i_LicensePlate):
            base(String.Format("The license plate {0} is not in our garge.\n if you wish to proceed with handeling this vehicle in our garge please insert this vehicle to our garge, option 1 in the main menu.", i_LicensePlate))
        {
            m_LicensePlate = i_LicensePlate;
        }

        public string GetLicensePlate()
        {
            return m_LicensePlate;
        }
    }
}
