using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class ValueOutOfRangeException: Exception
    {
        private float m_MinValue;
        private float m_MaxValue;

        public ValueOutOfRangeException(float i_CurrentValue, float i_MaxValue)
            : base(String.Format("The current battery/fuel value is {0}. You are trying to exceed the limit value which is {1}", i_CurrentValue, i_MaxValue))
        {
            m_MinValue = i_CurrentValue;
            m_MaxValue = i_MaxValue;
        }

        public float GetCurrentValue()
        { 
            return m_MinValue;
        }

        public void SetCurrentValue(float i_CurrentValue)
        {
            m_MinValue = i_CurrentValue;
        }

        public float GetMaxValue()
        {
            return m_MinValue;
        }

        public void SetMaxValue(float i_MaxValue)
        {
            m_MaxValue = i_MaxValue;
        }

    }
}
