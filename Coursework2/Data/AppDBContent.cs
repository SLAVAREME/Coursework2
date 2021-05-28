using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coursework2.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;


namespace Coursework2.Data
{
    public class AppDBContent : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasKey(u => u.Id); 
            modelBuilder.Entity<Leading>().HasKey(u => u.Id);
            modelBuilder.Entity<GameSession>().HasKey(u => u.Id);
            modelBuilder.Entity<ClientSession>().HasKey(u => u.Id);
            modelBuilder.Entity<PackageOfQuestions>().HasKey(u => u.Id);
            modelBuilder.Entity<Questions>().HasKey(u => u.Id);
            modelBuilder.Entity<CurrentQuestion>().HasKey(u => u.Id);
            modelBuilder.Entity<CurrentAnswer>().HasKey(u => u.Id);


        }
        public AppDBContent(DbContextOptions<AppDBContent> options)
	        : base(options)
        {
	        Database.EnsureCreated();  
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Leading> Leading { get; set; }
        public DbSet<GameSession> GameSession { get; set; }
        public DbSet<ClientSession> ClientSession { get; set; }
        public DbSet<PackageOfQuestions> PackageOfQuestions { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<CurrentQuestion> CurrentQuestion { get; set; }
        public DbSet<CurrentAnswer> CurrentAnswer { get; set; }
    }
}
