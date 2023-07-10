using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using rb.dal.Models;

namespace rb.dal.Data;

public partial class ResumeBuilderContext : DbContext
{
    public ResumeBuilderContext()
    {
    }

    public ResumeBuilderContext(DbContextOptions<ResumeBuilderContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Certificate> Certificates { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<EducationSkill> EducationSkills { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Resume> Resumes { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<Template> Templates { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserLanguage> UserLanguages { get; set; }

    public virtual DbSet<UserSkill> UserSkills { get; set; }

    public virtual DbSet<WorkExperience> WorkExperiences { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source = .\\SQLEXPRESS; initial catalog=ResumeBuilder; Encrypt=false; Trusted_Connection=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Certificate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Certific__3214EC073BC0B2EA");

            entity.HasOne(d => d.User).WithMany(p => p.Certificates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Certifica__UserI__3A81B327");
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Educatio__3214EC07C80DB5BD");

            entity.HasOne(d => d.User).WithMany(p => p.Educations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Education__UserI__46E78A0C");
        });

        modelBuilder.Entity<EducationSkill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Educatio__3214EC070D9A000E");

            entity.HasOne(d => d.Education).WithMany(p => p.EducationSkills)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Education__Educa__49C3F6B7");

            entity.HasOne(d => d.Skill).WithMany(p => p.EducationSkills)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Education__Skill__4AB81AF0");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Language__3214EC070AA69293");
        });

        modelBuilder.Entity<Resume>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Resume__3214EC07DBD78C75");

            entity.HasOne(d => d.Template).WithMany(p => p.Resumes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Resume__Template__571DF1D5");

            entity.HasOne(d => d.User).WithMany(p => p.Resumes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Resume__UserId__5629CD9C");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Skills__3214EC074DECEFC8");
        });

        modelBuilder.Entity<Template>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Template__3214EC07D599A14E");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07F886BD66");
        });

        modelBuilder.Entity<UserLanguage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserLang__3214EC07CD78D645");

            entity.HasOne(d => d.Language).WithMany(p => p.UserLanguages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserLangu__Langu__5165187F");

            entity.HasOne(d => d.User).WithMany(p => p.UserLanguages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserLangu__UserI__5070F446");
        });

        modelBuilder.Entity<UserSkill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserSkil__3214EC07F32BA6AD");

            entity.HasOne(d => d.Skill).WithMany(p => p.UserSkills)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserSkill__Skill__412EB0B6");

            entity.HasOne(d => d.User).WithMany(p => p.UserSkills)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserSkill__UserI__403A8C7D");
        });

        modelBuilder.Entity<WorkExperience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WorkExpe__3214EC07E056559E");

            entity.HasOne(d => d.User).WithMany(p => p.WorkExperiences)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkExper__UserI__440B1D61");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
