using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicShop.Models
{
    public partial class Instrument
    {
        public Instrument()
        {
            InstrumentRating = new HashSet<InstrumentRating>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public int ManufacturerId { get; set; }
        public int ColorId { get; set; }
        //[DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public virtual Colors Color { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual InstrumentType Type { get; set; }
        public virtual ICollection<InstrumentRating> InstrumentRating { get; set; }
    }
}
