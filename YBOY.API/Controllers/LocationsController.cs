using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YBOY.Core.Data;
using YBOY.Core.Service;

namespace YBOY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService locationService;

        public LocationsController(ILocationService _locationService)
        {
            locationService = _locationService;
        }

        [HttpPost]
        [Route("getLocationByUserId")]
        public Location getLocationByUserId(Location location)
        {
            return locationService.getLocationByUserId(location);
        }
        [HttpPost]
        [Route("createLocation")]
        public bool createLocation(Location location)
        {
            return locationService.createLocation(location);
        }
        [HttpPut]
        [Route("updateLocation")]
        public bool updateLocation(Location location)
        {
            return locationService.updateLocation(location);
        }
    }
}
