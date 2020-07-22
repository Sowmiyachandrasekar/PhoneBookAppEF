using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PhoneBookApp.Interfaces;

namespace PhoneBookApp.Models
{
    public class Person : ISoftDeletable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 1)]
        public int ID { get; set; }
        
        [Required]
        [Display(Name = "First Name")]
        [StringLength(30, MinimumLength = 1,ErrorMessage = "First Name should be between 1 and 30 characters")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Last Name should be between 1 and 30 characters")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Phone")]
        [StringLength(13, MinimumLength = 10,ErrorMessage = "Phone Number cannot be longer than 13 characters.")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }



        //Address Table
        [Required]
        [Display(Name = "AddressLine One")]
        public string AddressOne { get; set; }

        [Display(Name = "AddressLine Two")]
        public string AddressTwo { get; set; }

        [Required]
        public int Pincode { get; set; }
        public bool IsActive { get; set; } = true;

        [Required]
        [Display(Name = "Country")]
        [ForeignKey("Country")]
        public int CountryId { get; set; }

        [Required]
        [Display(Name = "State")]
        [ForeignKey("State")]
        public int StateId { get; set; }

        [Required]
        [Display(Name = "City")]
        [ForeignKey("City")]
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual State State { get; set; }
        public virtual Country Country { get; set; }

    }
}