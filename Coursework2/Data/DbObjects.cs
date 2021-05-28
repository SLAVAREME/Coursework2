using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coursework2.Data
{
    public class DbObjects
    {
        public static void updates(AppDBContent content, int idd, bool fg)
        {
            content.SaveChanges();
        }
    }
}
