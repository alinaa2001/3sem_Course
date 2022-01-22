using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    static public class GUID //генератор гуидов
    {
        static int guid = 0;

        static public void setGUID(int value)
        {
            guid = value;
        }

        static public int getGUID()
        {
            guid++;
            return guid;
        }
    }
}
