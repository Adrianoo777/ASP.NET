using System;
using System.Collections.Generic;

namespace MusicShop.Models
{
    public partial class InstrumentRating
    {
        public int Id { get; set; }
        public int Rate { get; set; }
        public int InstrumentId { get; set; }

        public virtual Instrument Instrument { get; set; }
    }
}
