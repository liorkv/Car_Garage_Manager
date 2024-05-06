using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class InternalCombustionPowered: VehiclePowerSystem
    {
        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        private eFuelType m_FuelType;

        public InternalCombustionPowered(eFuelType i_FuelType, float i_CurrentFuelAmount, float i_MaxFuelAmount)
        {
            m_CurrentEnergyAmount = i_CurrentFuelAmount;
            m_MaxEnergyAmount = i_MaxFuelAmount;
            m_FuelType = i_FuelType;
        }

        public void Refuel(float i_FuelAmount, eFuelType i_FuelType)
        {

            if (m_FuelType == i_FuelType)
            {
                base.AddEnergy(i_FuelAmount);
            }
            else
            {
                throw new NoMatchingFuelException(Enum.GetName(typeof(eFuelType), m_FuelType), Enum.GetName(typeof(eFuelType), i_FuelType));
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}, fuel type: {m_FuelType.ToString()}";
        }
    }
}
