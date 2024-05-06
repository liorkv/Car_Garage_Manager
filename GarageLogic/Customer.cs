using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Customer
    {
        private string m_Name;
        private string m_PhoneNumber;

        public Customer(string i_Name, string i_PhoneNumber)
        {
            m_Name = i_Name;
            m_PhoneNumber = i_PhoneNumber;
        }

        public string GetName()
        {
            return m_Name;
        }

        public string GetPhoneNumber()
        {
            return m_PhoneNumber;
        }
        

    }
}
