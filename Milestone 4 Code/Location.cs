using System;
using System.Collections.Generic;
using System.Text;

namespace Explorable_Areas
{
    class Location
    {
        protected string name;
      //  protected string areasize;
        //protected int checkpointnumber;
        protected int explorableareanumber;

        public Location(string Name, int expareanumber)
        {
            name = Name;
            
            explorableareanumber = expareanumber;
        }
    }
}
