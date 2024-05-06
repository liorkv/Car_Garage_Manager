using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Car : Vehicle
    {
        private eCarColor m_Color;
        private eNumberOfDoors m_NumberOfDoors;

        public Car(VehiclePowerSystem i_PowerSystem, VehicleFactory.eVehicleType i_VehicleType, Customer i_Costumer, List<Wheel> i_Wheels) : base(i_PowerSystem, i_VehicleType, i_Costumer, i_Wheels)
        {

        }

        public override Dictionary<string, object> GetPropertiesDictionary()
        {
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();

            keyValuePairs.Add("Color", Enum.GetValues(typeof(eCarColor)));
            keyValuePairs.Add("NumberOfDoors", Enum.GetValues(typeof(eNumberOfDoors)));

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
                    if (property.Key == "Color" )
                    {
                        if (Enum.IsDefined(typeof(Car.eCarColor), userInput) && Enum.TryParse(userInput.ToString(), out eCarColor color))
                        {
                            m_Color = color;
                        }
                        else
                        {
                            throw new ArgumentException("You chose invalid choice for car color");
                        }
                    }
                    else if (property.Key == "NumberOfDoors" )
                    {
                        if (Enum.IsDefined(typeof(Car.eNumberOfDoors), userInput) && Enum.TryParse(userInput.ToString(), out eNumberOfDoors numberOfDoors))
                        {
                            m_NumberOfDoors = numberOfDoors;
                        }
                        else
                        {
                            throw new ArgumentException("You chose invalid choise for car number of doors");
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
            return $"{base.ToString()}\nColor: {m_Color.ToString()}\nNumber of doors: {m_NumberOfDoors.ToString()}";
        }

        public enum eCarColor
        {
            White = 0,
            Black,
            Yellow,
            Red
        }

        public enum eNumberOfDoors
        {
            Two,
            Three,
            Four,
            Five
        }
    }
}
