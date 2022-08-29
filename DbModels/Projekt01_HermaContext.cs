using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project_P4.DbModels
{
    public partial class Projekt01_HermaContext : DbContext
    {
        public Projekt01_HermaContext()
        {
        }

        public Projekt01_HermaContext(DbContextOptions<Projekt01_HermaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ExpGroup> ExpGroups { get; set; } = null!;
        public virtual DbSet<Expence> Expences { get; set; } = null!;
        public virtual DbSet<Income> Incomes { get; set; } = null!;
        public virtual DbSet<Member> Members { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Projekt01_Herma;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExpGroup>(entity =>
            {
                entity.HasKey(e => e.GroupId)
                    .HasName("PK__ExpGroup__149AF30A2E244628");

                entity.ToTable("ExpGroup");

                entity.HasIndex(e => e.GroupName, "UQ__ExpGroup__6EFCD434E207C59C")
                    .IsUnique();

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.GroupName).HasMaxLength(50);
            });

            modelBuilder.Entity<Expence>(entity =>
            {
                entity.ToTable("Expence");

                entity.Property(e => e.ExpenceId).HasColumnName("ExpenceID");

                entity.Property(e => e.ExpenceCost).HasColumnType("money");

                entity.Property(e => e.ExpenceDate).HasColumnType("date");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Expences)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ref2");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Expences)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ref3");
            });

            modelBuilder.Entity<Income>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Income");

                entity.Property(e => e.IncomeCost).HasColumnType("money");

                entity.Property(e => e.IncomeDate).HasColumnType("date");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.HasOne(d => d.Member)
                    .WithMany()
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ref1");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("Member");

                entity.HasIndex(e => e.MemberName, "UQ__Member__BE50FDEF485273A9")
                    .IsUnique();

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.MemberBudget).HasColumnType("money");

                entity.Property(e => e.MemberName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
