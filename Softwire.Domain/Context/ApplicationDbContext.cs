using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Softwire.Domain.Entities;

namespace Softwire.Domain.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<QuoteRequest> QuoteRequests { get; set; }

        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<SupportRequest> SupportRequests { get; set; }
        

        public DbSet<Reference> References { get; set; }

       


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            try {
                return base.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex) {
                var error = GetEntityValidationErrors(ex);
                throw new System.Data.Entity.Validation.DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    error, ex
                    ); // Add the original exception as the innerException
            }
        }

        public override async System.Threading.Tasks.Task<int> SaveChangesAsync()
        {
            try {
                return await base.SaveChangesAsync();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex) {
                var error = GetEntityValidationErrors(ex);
                throw new System.Data.Entity.Validation.DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    error, ex
                    ); // Add the original exception as the innerException
            }
        }

        private string GetEntityValidationErrors(System.Data.Entity.Validation.DbEntityValidationException ex)
        {
            var sb = new System.Text.StringBuilder();

            foreach (var failure in ex.EntityValidationErrors) {
                sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                foreach (var error in failure.ValidationErrors) {
                    sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                    sb.AppendLine();
                }
            }

            return sb.ToString();
        }

       
    }
}