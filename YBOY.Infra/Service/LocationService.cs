using System;
using System.Collections.Generic;
using System.Text;
using YBOY.Core.Data;
using YBOY.Core.Repository;
using YBOY.Core.Service;

namespace YBOY.Infra.Service
{
   public class LocationService : ILocationService
    {
        private readonly ILocationRepository locationRepository;

        public LocationService(ILocationRepository _locationRepository)
        {
            locationRepository = _locationRepository;
        }
        public Location getLocationByUserId(Location location)
        {
            return locationRepository.getLocationByUserId(location);
        }

        public bool createLocation(Location location)
        {
            return locationRepository.createLocation(location);
        }

        public bool updateLocation(Location location)
        {
            return locationRepository.updateLocation(location);
        }
    }
}
