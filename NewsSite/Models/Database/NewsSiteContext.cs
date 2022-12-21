using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace NewsSite.Models.Database
{
    public partial class NewsSiteContext : DbContext
    {
        public NewsSiteContext()
        {
        }

        public NewsSiteContext(DbContextOptions<NewsSiteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<News> News { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=NewsSite;Integrated Security=SSPI");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_PRC_CI_AS");

            modelBuilder.Entity<News>(entity =>
            {
                entity.ToTable("news");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Kind)
                    .HasMaxLength(50)
                    .HasColumnName("kind");

                entity.Property(e => e.NewsContent)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .HasColumnName("news_content");

                entity.Property(e => e.Photo)
                    .HasMaxLength(200)
                    .HasColumnName("photo");

                entity.Property(e => e.Source)
                    .HasMaxLength(50)
                    .HasColumnName("source");

                entity.Property(e => e.Time)
                    .HasColumnType("date")
                    .HasColumnName("time");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("title");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
