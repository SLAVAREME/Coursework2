using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Coursework2.Data.Models;
using Microsoft.EntityFrameworkCore;
using ServiceStack.DataAnnotations;

namespace Coursework2.Data.Models
{

    public class Leading
    {
        [Key]
        public int Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string username { get; set; }

        public string password { get; set; }

    }

    //protected override void OnModelCreating(ModelBuilder builder)
    //{
    //    base.OnModelCreating(builder);

    //    // Define composite key.
    //    builder.Entity<Leading>()
    //        .HasKey(lc => new { lc.Id});
    //}
}
