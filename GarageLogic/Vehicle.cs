using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageLogic;

namespace GarageLogic
{
    public class Vehicle
    {
        protected string m_VehicleModelName;
        protected string m_LicenseNumber;
        protected List<Wheel> m_Wheels;
        protected VehicleFactory.eVehicleType m_VehicleType;
        protected VehiclePowerSystem m_PowerSystem;
        protected Customer m_Customer;
        protected eVehicleStatus m_VehicleStatus;

        public enum eVehicleStatus
        {
            InRepair,
            Repaired,
            Paid,
            None
        }

        public Vehicle(VehiclePowerSystem i_PowerSystem, VehicleFactory.eVehicleType i_VehicleType, Customer i_Customer, List<Wheel> i_Wheels)
        {
            m_PowerSystem = i_PowerSystem;
            m_VehicleType = i_VehicleType;
            m_LicenseNumber = null;
            m_Customer = i_Customer;
            m_Wheels = i_Wheels;
        }

        public virtual Dictionary<string, object> GetPropertiesDictionary()
        {
            return new Dictionary<string, object>();
        }

        public virtual void AssignAndValidateProperties(Dictionary<string, string> i_PropertiesDict) { }
       
        public override string ToString()
        {
            return $"License number: {m_LicenseNumber}\nModel name: {m_VehicleModelName}\nOwner name: {m_Customer.GetName()}" +
                $"\nVehicle status: {m_VehicleStatus.ToString()}\nVehicle type: {m_VehicleType.ToString()}\nFuel\\Battery Properties: {m_PowerSystem.ToString()}" +
                $"\nWheel Properties: {makeWheelsDataString()}";
        }

        private string makeWheelsDataString()
        {
            string output = "";
            foreach (var wheel in m_Wheels)
            {
                output += $" {wheel.ToString()}";
            }
            return output;
        }

        public eVehicleStatus GetVehicleStatus()
        {
            return m_VehicleStatus;
        }

        public void ValidateAndAsignCommonData(string i_ModelName, float i_EnergyUnits, float i_AirPressure, string i_LicenseNumber)
        {
            
            m_VehicleModelName = i_ModelName;
            m_VehicleStatus = eVehicleStatus.InRepair;
            m_LicenseNumber = i_LicenseNumber;
            

            if(m_PowerSystem is ElectricPowered electric)
            {
                electric.Recharge(i_EnergyUnits);
            }
            else if(m_PowerSystem is InternalCombustionPowered fuel)
            {
                fuel.AddEnergy(i_EnergyUnits);
            }

            foreach(Wheel wheel in m_Wheels)
            {
                wheel.AddAirPressure(i_AirPressure);
            }

        }

        public void SetVehicleStatus(eVehicleStatus i_VehicleStatus)
        {
            m_VehicleStatus = i_VehicleStatus;
        }

        public string GetLicenseNumber()
        {
            return m_LicenseNumber;
        }

        public List<Wheel> GetWheels()
        {
            return m_Wheels;
        }

        public bool IsFuelType()
        {
            return ((m_VehicleType == VehicleFactory.eVehicleType.FuelMotorcycle) || (m_VehicleType == VehicleFactory.eVehicleType.Truck) || (m_VehicleType == VehicleFactory.eVehicleType.FuelCar));
        }

        public bool IsElectricType()
        {
            return ((m_VehicleType == VehicleFactory.eVehicleType.ElectricMotorcycle) || (m_VehicleType == VehicleFactory.eVehicleType.ElectricCar));
        }

        public VehiclePowerSystem GetVehiclePowerSystem()
        {
            return m_PowerSystem;
        }

    }
}
