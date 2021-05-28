using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Coursework2.Data.Models;

namespace Coursework2.Data.Models
{
    public class GameSession
    {
        [Key]
        public int Id { get; set; }

        public DateTime Start { get; set; }
        
        public int IdLeading { get; set; }
        [ForeignKey("IdLeading")]
        public Leading Leading { get; set; }

        public string NameOfGame { get; set; }

        public int IdPackageQuestions { get; set; }
        [ForeignKey("IdPackageQuestions")]
        public PackageOfQuestions PackageOfQuestions { get; set; }
    }
}
