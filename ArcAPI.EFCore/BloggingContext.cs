using System;
using ArcAPI.EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArcAPI.EFCore
{
    public partial class BloggingContext :DbContext
    {
        public BloggingContext()
        {
        }

        public BloggingContext(DbContextOptions<BloggingContext> options)
       : base(options)
        {
        }

        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<Post> Post { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>(entity =>
            {
                entity.HasKey(e => e.BlogId);
                entity.Property(e => e.Url).IsRequired();
            });//.HasKey();

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.BlogId);
            });

            modelBuilder.Entity<Blog>();//.HasKey();

        }

    }
}
