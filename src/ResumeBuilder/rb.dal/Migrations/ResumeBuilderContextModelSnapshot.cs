﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rb.dal.Data;

#nullable disable

namespace rb.dal.Migrations
{
    [DbContext(typeof(ResumeBuilderContext))]
    partial class ResumeBuilderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("rb.dal.Models.Certificate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("ExpirationDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("IssuedDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Certific__3214EC073BC0B2EA");

                    b.HasIndex("UserId");

                    b.ToTable("Certificates");
                });

            modelBuilder.Entity("rb.dal.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("FromDate")
                        .HasColumnType("date");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("ToDate")
                        .HasColumnType("date");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Educatio__3214EC07C80DB5BD");

                    b.HasIndex("UserId");

                    b.ToTable("Education");
                });

            modelBuilder.Entity("rb.dal.Models.EducationSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EducationId")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Educatio__3214EC070D9A000E");

                    b.HasIndex("EducationId");

                    b.HasIndex("SkillId");

                    b.ToTable("EducationSkills");
                });

            modelBuilder.Entity("rb.dal.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK__Language__3214EC070AA69293");

                    b.HasIndex(new[] { "Name" }, "UQ__Language__737584F6C72A3A75")
                        .IsUnique();

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("rb.dal.Models.Resume", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("TemplateId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Resume__3214EC07DBD78C75");

                    b.HasIndex("TemplateId");

                    b.HasIndex("UserId");

                    b.ToTable("Resume");
                });

            modelBuilder.Entity("rb.dal.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK__Skills__3214EC074DECEFC8");

                    b.HasIndex(new[] { "Name" }, "UQ__Skills__737584F684E625E1")
                        .IsUnique();

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("rb.dal.Models.Template", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id")
                        .HasName("PK__Template__3214EC07D599A14E");

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("rb.dal.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FullName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Location")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(false)
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK__Users__3214EC07F886BD66");

                    b.HasIndex(new[] { "Username" }, "UQ__Users__536C85E47D2C650D")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("rb.dal.Models.UserLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdvanceLevel")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__UserLang__3214EC07CD78D645");

                    b.HasIndex("LanguageId");

                    b.HasIndex("UserId");

                    b.ToTable("UserLanguages");
                });

            modelBuilder.Entity("rb.dal.Models.UserSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__UserSkil__3214EC07F32BA6AD");

                    b.HasIndex("SkillId");

                    b.HasIndex("UserId");

                    b.ToTable("UserSkills");
                });

            modelBuilder.Entity("rb.dal.Models.WorkExperience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("FromDate")
                        .HasColumnType("date");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("ToDate")
                        .HasColumnType("date");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__WorkExpe__3214EC07E056559E");

                    b.HasIndex("UserId");

                    b.ToTable("WorkExperiences");
                });

            modelBuilder.Entity("rb.dal.Models.Certificate", b =>
                {
                    b.HasOne("rb.dal.Models.User", "User")
                        .WithMany("Certificates")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__Certifica__UserI__3A81B327");

                    b.Navigation("User");
                });

            modelBuilder.Entity("rb.dal.Models.Education", b =>
                {
                    b.HasOne("rb.dal.Models.User", "User")
                        .WithMany("Educations")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__Education__UserI__46E78A0C");

                    b.Navigation("User");
                });

            modelBuilder.Entity("rb.dal.Models.EducationSkill", b =>
                {
                    b.HasOne("rb.dal.Models.Education", "Education")
                        .WithMany("EducationSkills")
                        .HasForeignKey("EducationId")
                        .IsRequired()
                        .HasConstraintName("FK__Education__Educa__49C3F6B7");

                    b.HasOne("rb.dal.Models.Skill", "Skill")
                        .WithMany("EducationSkills")
                        .HasForeignKey("SkillId")
                        .IsRequired()
                        .HasConstraintName("FK__Education__Skill__4AB81AF0");

                    b.Navigation("Education");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("rb.dal.Models.Resume", b =>
                {
                    b.HasOne("rb.dal.Models.Template", "Template")
                        .WithMany("Resumes")
                        .HasForeignKey("TemplateId")
                        .IsRequired()
                        .HasConstraintName("FK__Resume__Template__571DF1D5");

                    b.HasOne("rb.dal.Models.User", "User")
                        .WithMany("Resumes")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__Resume__UserId__5629CD9C");

                    b.Navigation("Template");

                    b.Navigation("User");
                });

            modelBuilder.Entity("rb.dal.Models.UserLanguage", b =>
                {
                    b.HasOne("rb.dal.Models.Language", "Language")
                        .WithMany("UserLanguages")
                        .HasForeignKey("LanguageId")
                        .IsRequired()
                        .HasConstraintName("FK__UserLangu__Langu__5165187F");

                    b.HasOne("rb.dal.Models.User", "User")
                        .WithMany("UserLanguages")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__UserLangu__UserI__5070F446");

                    b.Navigation("Language");

                    b.Navigation("User");
                });

            modelBuilder.Entity("rb.dal.Models.UserSkill", b =>
                {
                    b.HasOne("rb.dal.Models.Skill", "Skill")
                        .WithMany("UserSkills")
                        .HasForeignKey("SkillId")
                        .IsRequired()
                        .HasConstraintName("FK__UserSkill__Skill__412EB0B6");

                    b.HasOne("rb.dal.Models.User", "User")
                        .WithMany("UserSkills")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__UserSkill__UserI__403A8C7D");

                    b.Navigation("Skill");

                    b.Navigation("User");
                });

            modelBuilder.Entity("rb.dal.Models.WorkExperience", b =>
                {
                    b.HasOne("rb.dal.Models.User", "User")
                        .WithMany("WorkExperiences")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__WorkExper__UserI__440B1D61");

                    b.Navigation("User");
                });

            modelBuilder.Entity("rb.dal.Models.Education", b =>
                {
                    b.Navigation("EducationSkills");
                });

            modelBuilder.Entity("rb.dal.Models.Language", b =>
                {
                    b.Navigation("UserLanguages");
                });

            modelBuilder.Entity("rb.dal.Models.Skill", b =>
                {
                    b.Navigation("EducationSkills");

                    b.Navigation("UserSkills");
                });

            modelBuilder.Entity("rb.dal.Models.Template", b =>
                {
                    b.Navigation("Resumes");
                });

            modelBuilder.Entity("rb.dal.Models.User", b =>
                {
                    b.Navigation("Certificates");

                    b.Navigation("Educations");

                    b.Navigation("Resumes");

                    b.Navigation("UserLanguages");

                    b.Navigation("UserSkills");

                    b.Navigation("WorkExperiences");
                });
#pragma warning restore 612, 618
        }
    }
}