using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YBOY.Core.Data
{
    public class Testimonials
    {
        [Key]
        public int Testimonial_id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Image_path { get; set; }
        public string Status { get; set; }
        public string Feedback_mess { get; set; }
        public int Web_id { get; set; }

        [ForeignKey("Web_id")]
        public virtual Website Website { get; set; }
    }
        
}
