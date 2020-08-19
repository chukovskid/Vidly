using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute // ovaa klasa e Custom Validator
    {// Customer BirthDay [Min18YearsIfAMember]
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance; // ova VlidationContext mi go vrakja Modelot vo koj se naoga

            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                  return ValidationResult.Success;
            

            // za se ostanato mora da proveram dali ima vneseno BirthDay i ako ima dali e 18+

            if (customer.Birthdate == null)
            {
                return new ValidationResult("BirthDay is required");
            }

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;



            return age < 18 ? new ValidationResult("Sorry, you have to be +18") : ValidationResult.Success;

           


        }
    }
}