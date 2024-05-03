using System;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
	{

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Database=Blog; User ID=postgres; Password=123; Pooling=true;");
          
        }

        public DbSet<About> Abouts { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Content> Contents { get; set; }
		public DbSet<Heading> Headings { get; set; }
		public DbSet<Writer> Writers { get; set; }

       


    }
}

