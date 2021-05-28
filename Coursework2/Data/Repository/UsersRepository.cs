using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coursework2.Data.Interfaces;
using Coursework2.Data.Models;

namespace Coursework2.Data.Repository
{
    public class UsersRepository : IUsers
    {
        private readonly AppDBContent AppDBContent;

        public UsersRepository(AppDBContent AppDBContent)
        {
            this.AppDBContent = AppDBContent;
        }

        public IEnumerable<Users> AllUsers => AppDBContent.Users;
    }
}
