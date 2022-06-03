using System;
using System.Collections.Generic;
using System.Text;
using YBOY.Core.Data;
using YBOY.Core.Repository;
using YBOY.Core.Service;
using YBOY.Infra.Repository;

namespace YBOY.Infra.Service
{
    public class About_UsService : IAbout_UsService
    {
        private readonly IAbout_UsRepository about_UsRepository;

        public About_UsService(IAbout_UsRepository _about_UsRepository)
        {
            about_UsRepository = _about_UsRepository;
        }



        public List<About_Us> getAllAboutUs()
        {
            return about_UsRepository.getAllAboutUs();
        }

        public bool CreateAboutUs(About_Us about_Us)
        {
            return about_UsRepository.CreateAboutUs(about_Us);  
        }

        public bool UpdateAboutUs(About_Us about_Us)
        {
            return about_UsRepository.UpdateAboutUs(about_Us);
        }

        public string DeleteAboutUs(int id)
        {
            return about_UsRepository.DeleteAboutUs(id);
        }
    }
}
