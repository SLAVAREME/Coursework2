using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coursework2.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Coursework2.Data.Models
{
    public class CurrentAnswer
    {
        [Key]
        public int Id { get; set; }


        public int IdCurrentQuestion { get; set; }
        [ForeignKey("IdCurrentQuestion")]
        public CurrentQuestion CurrentQuestion { get; set; }


        public int IdUsers { get; set; }
        [ForeignKey("IdUsers")]
        public Users Users { get; set; }

        public int IdSession { get; set; }
        [ForeignKey("IdSession")]
        public GameSession GameSession { get; set; }

        public string Answer { get; set; }

        public int Credited { get; set; }
    }
}
