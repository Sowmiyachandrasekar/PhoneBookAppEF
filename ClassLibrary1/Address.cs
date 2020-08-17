namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Address")]
    public partial class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        public string AddressOne { get; set; }

        public string AddressTwo { get; set; }

        public int Pincode { get; set; }

        public int CountryId { get; set; }

        public int StateId { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public virtual Country Country { get; set; }

        public virtual Person Person { get; set; }

        public virtual State State { get; set; }
    }
}
