﻿using Softwire.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softwire.Domain.Entities
{
   public class QuoteRequest
    {

        public QuoteRequest()
        {
            Date = UgandaDateTime.DateNow();
        }

        [Key]
        public int QuoteRequestId { get; set; }

        [Display(Name = "Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Organization")]
        [StringLength(100)]
        public string Organization { get; set; }

        [Display(Name = "Email")]
        [StringLength(50)]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        [StringLength(50)]
        public string Phone { get; set; }

        [Display(Name = "Product / Service")]
        [StringLength(100)]
        public string ProductOrService { get; set; }

        [Display(Name = "Description")]
        [StringLength(2000)]
        public string Description { get; set; }

        public DateTime Date { get; set; }

    }
}
