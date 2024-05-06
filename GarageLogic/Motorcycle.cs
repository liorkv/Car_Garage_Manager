using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GarageLogic.Car;

namespace GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private eMotorcycleLicenseType m_LicenseType;
        private int m_EngineVolume;

        public Motorcycle(VehiclePowerSystem i_PowerSystem, VehicleFactory.eVehicleType i_VehicleType, Customer i_Customer, List<Wheel> i_Wheels) : base(i_PowerSystem, i_VehicleType, i_Customer, i_Wheels)
        {

        }

        public override Dictionary<string, object> GetPropertiesDictionary()
        {
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();

            keyValuePairs.Add("LicenseType", Enum.GetValues(typeof(eMotorcycleLicenseType)));
            keyValuePairs.Add("EngineVolume", null);

            return keyValuePairs;
        }

        public override void AssignAndValidateProperties(Dictionary<string, string> i_PropertiesDict)
        {
            int userInput;
            bool isValidInput;

            foreach (KeyValuePair<string, string> property in i_PropertiesDict)
            {
                isValidInput = int.TryParse(property.Value, out userInput);
                userInput -= 1;

                if (isValidInput)
                {
                    if (property.Key == "LicenseType")
                    {
                        if (Enum.IsDefined(typeof(Motorcycle.eMotorcycleLicenseType), userInput) && Enum.TryParse(userInput.ToString(), out eMotorcycleLicenseType type))
                        {
                            m_LicenseType = type;
                        }
                        else
                        {
                            throw new ArgumentException("You chose invalid choice for license type");
                        }
                    }
                    else if (property.Key == "EngineVolume")
                    {
                        if (int.TryParse(property.Value, out int EngineVolume))
                        {
                            m_EngineVolume = EngineVolume;
                        }
                        else
                        {
                            throw new ArgumentException("you insert the wrong input type, this field gets integer only!");
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("you didnt type correctly one of the options above");
                }
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nLicense type: {m_LicenseType.ToString()}\nEngine volume: {m_EngineVolume}";
        }

        public enum eMotorcycleLicenseType
        {
            A1,
            A2,
            AA,
            B1
        }
    }
}
