using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coursework2.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Coursework2.Data.Models
{
    public class ClientSession
    {
        [Key]
        public int Id { get; set; }


        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public Users Users { get; set; }


        public int IdSession { get; set; }
        [ForeignKey("IdSession")]
        public GameSession GameSession { get; set; }
    }
}
