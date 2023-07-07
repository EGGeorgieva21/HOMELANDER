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
            entity.HasKey(e => e.Id).HasName("PK__Certific__3214EC07894B6857");

            entity.HasOne(d => d.User).WithMany(p => p.Certificates).HasConstraintName("FK__Certifica__UserI__3A81B327");
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Educatio__3214EC070A6756C6");

            entity.HasOne(d => d.User).WithMany(p => p.Educations).HasConstraintName("FK__Education__UserI__46E78A0C");
        });

        modelBuilder.Entity<EducationSkill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Educatio__3214EC07354DC4C9");

            entity.HasOne(d => d.Education).WithMany(p => p.EducationSkills).HasConstraintName("FK__Education__Educa__49C3F6B7");

            entity.HasOne(d => d.Skill).WithMany(p => p.EducationSkills).HasConstraintName("FK__Education__Skill__4AB81AF0");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Language__3214EC07FC50C201");
        });

        modelBuilder.Entity<Resume>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Resume__3214EC07740AAC9A");

            entity.HasOne(d => d.Template).WithMany(p => p.Resumes).HasConstraintName("FK__Resume__Template__571DF1D5");

            entity.HasOne(d => d.User).WithMany(p => p.Resumes).HasConstraintName("FK__Resume__UserId__5629CD9C");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Skills__3214EC07991F9ABE");
        });

        modelBuilder.Entity<Template>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Template__3214EC0718A5A755");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07E5750C97");
        });

        modelBuilder.Entity<UserLanguage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserLang__3214EC07AB1066C6");

            entity.HasOne(d => d.Language).WithMany(p => p.UserLanguages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserLangu__Langu__5165187F");

            entity.HasOne(d => d.User).WithMany(p => p.UserLanguages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserLangu__UserI__5070F446");
        });

        modelBuilder.Entity<UserSkill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserSkil__3214EC07BEAE8095");

            entity.HasOne(d => d.Skill).WithMany(p => p.UserSkills).HasConstraintName("FK__UserSkill__Skill__412EB0B6");

            entity.HasOne(d => d.User).WithMany(p => p.UserSkills).HasConstraintName("FK__UserSkill__UserI__403A8C7D");
        });

        modelBuilder.Entity<WorkExperience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WorkExpe__3214EC073CC35591");

            entity.HasOne(d => d.User).WithMany(p => p.WorkExperiences).HasConstraintName("FK__WorkExper__UserI__440B1D61");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
