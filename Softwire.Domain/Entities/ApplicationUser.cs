﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Softwire.Domain.Models;

namespace Softwire.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            References = new List<Reference>();
          
        }

        [Display(Name = "User Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DisplayId { get; set; }
              
        [StringLength(4)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [StringLength(60)]
        [Display(Name = "Forename(s)")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Display(Name = "Surname")]
        public string LastName { get; set; }
        
        [NotMapped]
        [Display(Name = "Full Name")]
        public string FullName {
            get {
                return AsPerson().FullName;
            }
        }

        // Virtuals (related entities)
        public virtual ICollection<Reference> References { get; set; }

        public Person AsPerson()
        {
            return new Person {
                Title = Title,
                FirstName = FirstName,
                LastName = LastName,
            };
        }

        public string UserId()
        {
            return DisplayId.ToString();
        }

        public string DocFolder()
        {
            string docRoot = System.Configuration.ConfigurationManager.AppSettings["Settings.Site.DocFolder"];
            return string.Format(@"{0}\Users\{1}", docRoot, DisplayId);
        }

        public bool HasMaxReferees()
        {
            return (References.Where(x => !x.OptedOutDate.HasValue).Count() >= 2);
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

       
       
    }
}
