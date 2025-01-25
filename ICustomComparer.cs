using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Adv_03
{
    internal interface ICustomComparer
    {
        bool Compare(int x , int y);
    }
    internal class AscComparer : ICustomComparer
    {
        public bool Compare(int x, int y) => x > y;
    }

    internal class DescComparer : ICustomComparer
    {
        public bool Compare(int x, int y) => x < y;
    }
}
