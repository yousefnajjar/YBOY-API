using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YBOY.Core.DTO;

namespace YBOY.Core.Service
{
    public interface IMailService
    {
       Task SendContactUsEmail(ContactUsEmail contactUsEmail);
        Task SendAcceptedOrderMail(ReceivedMail receivedMail);
        Task Sendbill(billMail billMail);
    }
}
