using System;
using System.Collections.Generic;
using System.Text;
using YBOY.Core.Data;

namespace YBOY.Core.Service
{
    public interface IAbout_UsService
    {
        public List<About_Us> getAllAboutUs();

        public bool CreateAboutUs(About_Us about_Us);

        public bool UpdateAboutUs(About_Us about_Us);

        public string DeleteAboutUs(int id);
    }
}
