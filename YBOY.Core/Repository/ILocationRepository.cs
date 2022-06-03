using System;
using System.Collections.Generic;
using System.Text;
using YBOY.Core.Data;

namespace YBOY.Core.Repository
{
   public interface ILocationRepository
    {


        public Location getLocationByUserId(Location location);

        public bool createLocation(Location location);

        public bool updateLocation(Location location);

    }
}
