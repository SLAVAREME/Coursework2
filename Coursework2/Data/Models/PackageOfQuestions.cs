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
    public class PackageOfQuestions
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfCreation { get; set; }

        public string PackageEditor { get; set; }
    }
}
