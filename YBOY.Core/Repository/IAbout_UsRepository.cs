using System;
using System.Collections.Generic;
using System.Text;
using YBOY.Core.Data;

namespace YBOY.Core.Repository
{
    public interface IAbout_UsRepository

    {
        public List<About_Us> getAllAboutUs();

        public bool CreateAboutUs(About_Us about_Us);

        public bool UpdateAboutUs(About_Us about_Us);

        public string DeleteAboutUs(int id);

    }
}
