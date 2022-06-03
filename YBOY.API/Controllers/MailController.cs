using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YBOY.Core.DTO;
using YBOY.Core.Service;

namespace YBOY.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService mailService;
        public MailController(IMailService mailService)
        {
            this.mailService = mailService;
        }

        [HttpPost]
        [Route("SendContactUsMail")]
        public async Task<IActionResult> SendContactUsMail([FromBody] ContactUsEmail contactUsEmail)
        {

            try
            {
                await mailService.SendContactUsEmail(contactUsEmail);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }

            
         

        }

        [HttpPost]
        [Route("SendAcceptedOrderMail")]
        public async Task<IActionResult> SendAcceptedOrderMail(ReceivedMail receivedMail)
        {
            try
            {
                await mailService.SendAcceptedOrderMail(receivedMail);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }

           
          
        }

        [HttpPost]
        [Route("Sendbill")]
        public async Task<IActionResult> Sendbill(billMail billMail)
        {
            try
            {
                await mailService.Sendbill(billMail);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }

         
          
        }
    }
}
