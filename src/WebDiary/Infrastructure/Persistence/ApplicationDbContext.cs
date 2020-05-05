using System;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        //public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Post>()
            //    .HasOne(c => c.User)
            //    .WithMany(t => t.Posts)
            //    .IsRequired()
            //    .HasForeignKey(p => p.UserId);

            //modelBuilder.Entity<Comment>()
            //    .HasOne(c => c.User)
            //    .WithMany(t => t.Comments)
            //    .IsRequired()
            //    .HasForeignKey(p => p.UserId);
        }
    }
}