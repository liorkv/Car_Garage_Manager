using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageLogic;

namespace GarageLogic
{
    public class VehicleFactory
    {
        private const float k_ElectricCarMaxBatteryAmount = 5.2f; 
        private const float k_FuelCarMaxTankSize = 46;
        private const float k_FuelTruckMaxTankSize = 135;
        private const float k_ElectricMotorcycleMaxBatteryAmount = 2.6f;
        private const float k_FuelMotorcycleMaxTankSize = 6.4f;
        private const float k_ElectricMotorcycleMaxWheelAirPressure = 31;
        private const float k_FuelMotorcycleMaxWheelAirPressure = 31;
        private const float k_FuelCarMaxWheelAirPressure = 33;
        private const float k_ElectricCarMaxWheelAirPressure = 33;
        private const float k_TruckMaxWheelAirPressure = 26;


        public enum eVehicleType
        {
            FuelMotorcycle = 0,
            ElectricMotorcycle,
            FuelCar,
            ElectricCar,
            Truck
        }

        public bool TryCreateVehicle(eVehicleType i_VehicleType, out Vehicle o_Vehicle, Customer i_Costumer, string i_WheelManufacturerName)
        {
            o_Vehicle = null;
            bool result = false;
            Wheel wheel;

            switch (i_VehicleType)
            {
                case eVehicleType.ElectricCar:
                    wheel = new Wheel(i_WheelManufacturerName, 0, k_ElectricCarMaxWheelAirPressure);
                    o_Vehicle = new Car(new ElectricPowered(0, k_ElectricCarMaxBatteryAmount), i_VehicleType, i_Costumer, makeListOfWheels(wheel,5));
                    break;
                case eVehicleType.FuelCar:
                    wheel = new Wheel(i_WheelManufacturerName, 0, k_FuelCarMaxWheelAirPressure);
                    o_Vehicle = new Car(new InternalCombustionPowered(InternalCombustionPowered.eFuelType.Octan95,0, k_FuelCarMaxTankSize), i_VehicleType, i_Costumer, makeListOfWheels(wheel, 5));
                    break;
                case eVehicleType.Truck:
                    wheel = new Wheel(i_WheelManufacturerName, 0, k_TruckMaxWheelAirPressure);
                    o_Vehicle = new Truck(new InternalCombustionPowered(InternalCombustionPowered.eFuelType.Soler, 0, k_FuelTruckMaxTankSize), i_VehicleType, i_Costumer, makeListOfWheels(wheel, 14));
                    break;
                case eVehicleType.ElectricMotorcycle:
                    wheel = new Wheel(i_WheelManufacturerName, 0, k_ElectricMotorcycleMaxWheelAirPressure);
                    o_Vehicle = new Motorcycle(new ElectricPowered(0, k_ElectricMotorcycleMaxBatteryAmount), i_VehicleType, i_Costumer, makeListOfWheels(wheel, 2));
                    break;
                case eVehicleType.FuelMotorcycle:
                    wheel = new Wheel(i_WheelManufacturerName, 0, k_FuelMotorcycleMaxWheelAirPressure);
                    o_Vehicle = new Motorcycle(new InternalCombustionPowered(InternalCombustionPowered.eFuelType.Octan98, 0, k_FuelMotorcycleMaxTankSize), i_VehicleType, i_Costumer, makeListOfWheels(wheel, 2));
                    break;
                default:
                    result = false; 
                    break;
            }

            return result;
        }

        private List<Wheel> makeListOfWheels(Wheel i_Wheel, int i_NumberOfWheels)
        {
            List<Wheel> listOfWheel = new List<Wheel>();
            for (int j = 0; j < i_NumberOfWheels; j++)
            {
                listOfWheel.Add(new Wheel(i_Wheel));
            }

            return listOfWheel;
        }
    }
}
