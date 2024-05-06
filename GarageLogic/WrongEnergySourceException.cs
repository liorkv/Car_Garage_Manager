using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class WrongEnergySourceException: Exception
    {


        public WrongEnergySourceException(): base("wrong action, your trying to refuel electric vehicle or charge fueled vehicle.")
        {

        }
    }
}
