using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YBOY.Core.Data
{
    public class Website
    {
        [Key]
        public int Web_id { get; set; }
        public string Web_name { get; set; }
        public string Web_image_logo_path { get; set; }
        public string Web_image_background_path { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Card_id { get; set; }

        public ICollection<Testimonials> Testimonials { get; set; }
        public ICollection<About_Us> About_Us { get; set; }
        public ICollection<Contact_Us> Contact_Us { get; set; }

    }
}
