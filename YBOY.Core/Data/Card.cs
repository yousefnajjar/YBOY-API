using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YBOY.Core.Data
{
    public class Card
    {
        [Key]
        public int Card_id { get; set; }

        public int Card_number { get; set; }
        public int  Ccv { get; set; }
        public DateTime ExpDate { get; set; }
        public float Balance { get; set; }

    }
}
