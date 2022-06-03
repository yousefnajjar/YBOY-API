using System;
using System.Collections.Generic;
using System.Text;
using YBOY.Core.Data;

namespace YBOY.Core.Repository
{
    public interface IContact_UsRepository
    {
        public List<Contact_Us> getAllContact_Us();

        public bool CreateContact_Us(Contact_Us contact_Us);

        public bool UpdateContact_Us(Contact_Us contact_Us);

        public string DeleteContact_Us(int id);
    }
}
