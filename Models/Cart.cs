using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int InstrumentId { get; set; }
        public int Quantity { get; set; }

        public virtual Instrument Instrument { get; set; }
    }
}
