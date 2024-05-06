using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class ElectricPowered : VehiclePowerSystem
    {
        public ElectricPowered(float i_CurrentBatteryTime, float i_MaxBatteryTime)
        {
            m_CurrentEnergyAmount = i_CurrentBatteryTime;
            m_MaxEnergyAmount = i_MaxBatteryTime;
        }

        public void Recharge(float i_BatteryTimeAmount)
        {
            AddEnergy(i_BatteryTimeAmount);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
