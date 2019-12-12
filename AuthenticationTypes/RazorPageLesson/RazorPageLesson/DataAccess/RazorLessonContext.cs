using Microsoft.EntityFrameworkCore;
using RazorPageLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageLesson.DataAccess
{
    public class RazorLessonContext : DbContext
    {
        public RazorLessonContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(new Person
            {
                FullName = "Петя Толигенов",
                Age = 24
            },
            new Person
            {
                FullName = "Вася Пупкин",
                Age = 22
            });
        }
    }
}
