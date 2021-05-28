using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Coursework2.Data.Models
{
    public class CurrentQuestion
    {
        [Key]
        public int Id { get; set; }


        public int IdSession { get; set; }
        [ForeignKey("IdSession")]
        public GameSession GameSession { get; set; }

        public int IdQuestion { get; set; }
        [ForeignKey("IdQuestion")]
        public Questions Questions { get; set; }

        public string Question { get; set; }

        public DateTime StartQuestion { get; set; }

        public DateTime EndQuestion { get; set; }
    }
}
