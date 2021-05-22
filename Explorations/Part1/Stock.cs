using System;
using System.Collections.Generic;
using System.Text;

namespace Explorations.Part1
{
    class Stock : Asset
    {
        public int numOfShares;
        public string stockID;

        public override string getFullID()
        {
            string baseID =  base.getFullID();
            return $"{baseID}-{stockID}";
        }

    }
}
