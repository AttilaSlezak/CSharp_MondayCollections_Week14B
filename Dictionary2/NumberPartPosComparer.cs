using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary2
{
    class NumberPartPosComparer : IComparer<NumberPart>
    {
        public int Compare(NumberPart first, NumberPart second)
        {
            if (first.Position > second.Position)
                return 1;
            else
                return -1;
        }
    }
}
