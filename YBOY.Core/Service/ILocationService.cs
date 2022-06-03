using System;
using System.Collections.Generic;
using System.Text;
using YBOY.Core.Data;

namespace YBOY.Core.Service
{
  public  interface ILocationService
    {
        public Location getLocationByUserId(Location location);

        public bool createLocation(Location location);

        public bool updateLocation(Location location);
    }
}
