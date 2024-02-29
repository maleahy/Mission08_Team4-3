﻿using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace Mission08_Team4_3.Models
{
    public class TodosContext: DbContext
    {
        public TodosContext(DbContextOptions<TodosContext> options) : base(options)
        {
        }

        public DbSet<Todos> Tasks { get; set; }
        public DbSet<Categories> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>().HasData(

                new Categories { CategoryId = 1, Category = "Home" },
                new Categories { CategoryId = 2, Category = "School" },
                new Categories { CategoryId = 3, Category = "Work" },
                new Categories { CategoryId = 4, Category = "Church" }
                );
        }
    }
}