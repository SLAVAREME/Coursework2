using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coursework2.Data.Models;

namespace Coursework2.Data.Interfaces
{
    public interface ILeading
    {
        IEnumerable<Leading> AllLeadings { get; }
    }
}
