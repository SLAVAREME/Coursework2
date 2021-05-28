using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Coursework2.Data.Models;

namespace Coursework2.Data.Models
{
    public class Questions
    {
        [Key]
        public int Id { get; set; }

        public int IdPackage { get; set; }
        [ForeignKey("IdPackage")]
        public PackageOfQuestions PackageOfQuestions { get; set; }

        public string QuestionText { get; set; }

        public string Answer { get; set; }

        public string Comment { get; set; }

        public string Author { get; set; }
    }
}
