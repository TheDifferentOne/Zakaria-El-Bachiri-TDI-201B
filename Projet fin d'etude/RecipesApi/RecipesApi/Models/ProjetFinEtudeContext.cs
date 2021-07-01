using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RecipesApi.Models
{
    public partial class ProjetFinEtudeContext : DbContext
    {
        public ProjetFinEtudeContext()
        {
        }

        public ProjetFinEtudeContext(DbContextOptions<ProjetFinEtudeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Direction> Directions { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<FoodPic> FoodPics { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=ProjetFinEtude;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__tmp_ms_x__AB6E6164B8E02E9B")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.UserType)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("userType");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.Property(e => e.Name)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Direction>(entity =>
            {
                entity.Property(e => e.Directions).HasColumnType("text");

                entity.Property(e => e.FoodName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.FoodNameNavigation)
                    .WithMany(p => p.Directions)
                    .HasForeignKey(d => d.FoodName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Directions_Food");
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("Food");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.CookingTime).HasColumnName("cookingTime");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.Servings).HasColumnName("servings");

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.Foods)
                    .HasForeignKey(d => d.Country)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Food_Countries");
            });

            modelBuilder.Entity<FoodPic>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FoodName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("foodName");

                entity.Property(e => e.Pic1)
                    .HasColumnType("image")
                    .HasColumnName("pic1");

                entity.Property(e => e.Pic2)
                    .HasColumnType("image")
                    .HasColumnName("pic2");

                entity.Property(e => e.Pic3)
                    .HasColumnType("image")
                    .HasColumnName("pic3");

                entity.Property(e => e.Pic4)
                    .HasColumnType("image")
                    .HasColumnName("pic4");

                entity.HasOne(d => d.FoodNameNavigation)
                    .WithMany(p => p.FoodPics)
                    .HasForeignKey(d => d.FoodName)
                    .HasConstraintName("FK__FoodPics__foodNa__5CA1C101");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.HasKey(e => e.IngrediantId);
                
                entity.Property(e => e.FoodName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("foodName");

                entity.Property(e => e.Name)
                    .HasColumnType("text")
                    .HasColumnName("name");

                entity.Property(e => e.Quantity)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("quantity");

                entity.HasOne(d => d.FoodNameNavigation)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.FoodName)
                    .HasConstraintName("FK_Recipes_Food");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
