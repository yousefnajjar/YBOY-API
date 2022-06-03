using System;
using System.Collections.Generic;
using System.Text;
using YBOY.Core.Data;
using YBOY.Core.Repository;
using YBOY.Core.Service;
using YBOY.Infra.Repository;

namespace YBOY.Infra.Service
{
    public class Contact_UsService : IContact_UsService
    {
        private readonly IContact_UsRepository contact_UsRepository;

        public Contact_UsService(IContact_UsRepository _contact_UsRepository)
        {
            contact_UsRepository = _contact_UsRepository;
        }
        
        public List<Contact_Us> getAllContact_Us()
        {
            return contact_UsRepository.getAllContact_Us();
        }
        public bool CreateContact_Us(Contact_Us contact_Us)
        {
            return contact_UsRepository.CreateContact_Us(contact_Us);
        }
        public bool UpdateContact_Us(Contact_Us contact_Us)
        {
            return contact_UsRepository.UpdateContact_Us(contact_Us);
        }
        public string DeleteContact_Us(int id)
        {
            return contact_UsRepository.DeleteContact_Us(id);
        }
    }
}
