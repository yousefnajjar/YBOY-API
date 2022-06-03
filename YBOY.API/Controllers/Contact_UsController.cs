using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using YBOY.Core.Data;
using YBOY.Core.Service;

namespace YBOY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Contact_UsController : ControllerBase
    {
        private readonly IContact_UsService contact_UsService;

        public Contact_UsController(IContact_UsService _contact_UsService)
        {
            contact_UsService = _contact_UsService;
        }
        [HttpGet]
        [Route("getAllContact_Us")]
        public List<Contact_Us> getAllContact_Us()
        {
            return contact_UsService.getAllContact_Us();
        }
        [HttpPost]
        [Route("CreateContact_Us")]
        public bool CreateContact_Us(Contact_Us contact_Us)
        {
            return contact_UsService.CreateContact_Us(contact_Us);
        }
        [HttpPut]
        [Route("UpdateContact_Us")]
        public bool UpdateContact_Us(Contact_Us contact_Us)
        {
            return contact_UsService.UpdateContact_Us(contact_Us);
        }
        [HttpDelete]
        [Route("DeleteContact_Us/{id}")]
        public string DeleteContact_Us(int id)
        {
            return contact_UsService.DeleteContact_Us(id);
        }
    }
}
