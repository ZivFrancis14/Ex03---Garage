using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException: Exception
    {
        private float m_MaxVakue;
        private float m_MinVakue;
    }
}
