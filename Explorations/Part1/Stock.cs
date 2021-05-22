using System;
using System.Collections.Generic;
using System.Text;

namespace Explorations.Part1
{
    public class Stock : Asset
    {
        public Stock(string name) : base(name){}
        public int NumberOfShares;
    }
}
