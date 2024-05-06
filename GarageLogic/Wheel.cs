using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;


        public Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            if (i_CurrentAirPressure <= i_MaxAirPressure)
            {
                m_CurrentAirPressure = i_CurrentAirPressure;
                m_MaxAirPressure = i_MaxAirPressure;
            }
            else
            {
                throw new ArgumentOutOfRangeException("current air pressure", String.Format("the air pressure must be between 0 to max pressure which is {0}.", i_MaxAirPressure));
            }
        }
        public Wheel(Wheel i_Wheel)
        {
            m_ManufacturerName = i_Wheel.m_ManufacturerName;
            m_CurrentAirPressure = i_Wheel.m_CurrentAirPressure;
            m_MaxAirPressure = i_Wheel.m_MaxAirPressure;
        }

        public void AddAirPressure(float i_AmountOfAirToAdd)
        {
            if (i_AmountOfAirToAdd + this.m_CurrentAirPressure <= m_MaxAirPressure)
            {
                this.m_CurrentAirPressure += i_AmountOfAirToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(this.m_CurrentAirPressure, this.m_MaxAirPressure);
            }
        }

        public void MakeAirPressureMax()
        {
            this.m_CurrentAirPressure = this.m_MaxAirPressure;
        }

        public override string ToString()
        {
            return $"\nmanufacturer name: {m_ManufacturerName}, current air pressure: {m_CurrentAirPressure}, max air pressure: {m_MaxAirPressure}";
        }
    }
}
