using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coursework2.Data.Interfaces;
using Coursework2.Data.Models;

namespace Coursework2.Data.Repository
{
    public class LeadingRepository : ILeading
    {

        private readonly AppDBContent AppDBContent;

        public LeadingRepository(AppDBContent AppDBContent)
        {
            this.AppDBContent = AppDBContent;
        }

        public IEnumerable<Leading> AllLeadings => AppDBContent.Leading;
    }
}
