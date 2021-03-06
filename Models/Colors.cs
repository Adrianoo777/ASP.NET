﻿using System;
using System.Collections.Generic;

namespace MusicShop.Models
{
    public partial class Colors
    {
        public Colors()
        {
            Instrument = new HashSet<Instrument>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Instrument> Instrument { get; set; }
    }
}
