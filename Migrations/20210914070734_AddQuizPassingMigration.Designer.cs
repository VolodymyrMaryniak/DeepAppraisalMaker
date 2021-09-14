﻿// <auto-generated />
using System;
using AspNetCoreVueStarter.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AspNetCoreVueStarter.Migrations
{
    [DbContext(typeof(DamDbContext))]
    [Migration("20210914070734_AddQuizPassingMigration")]
    partial class AddQuizPassingMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AspNetCoreVueStarter.Data.Models.AnswerOptionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnswerOptionText")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsCorrectAnswer")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("AnswerOption");
                });

            modelBuilder.Entity("AspNetCoreVueStarter.Data.Models.QuestionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("AspNetCoreVueStarter.Data.Models.QuizEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Quiz");
                });

            modelBuilder.Entity("AspNetCoreVueStarter.Data.Models.QuizPassingEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("PassingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.HasIndex("StudentId");

                    b.ToTable("QuizPassing");
                });

            modelBuilder.Entity("AspNetCoreVueStarter.Data.Models.StudentAnswerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ChosenAnswerId")
                        .HasColumnType("int");

                    b.Property<int?>("ChosenAnswerOptionId")
                        .HasColumnType("int");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int?>("QuizPassingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChosenAnswerOptionId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("QuizPassingId");

                    b.ToTable("StudentAnswer");
                });

            modelBuilder.Entity("AspNetCoreVueStarter.Data.Models.StudentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("AspNetCoreVueStarter.Data.Models.AnswerOptionEntity", b =>
                {
                    b.HasOne("AspNetCoreVueStarter.Data.Models.QuestionEntity", "Question")
                        .WithMany("AnswerOptions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("AspNetCoreVueStarter.Data.Models.QuestionEntity", b =>
                {
                    b.HasOne("AspNetCoreVueStarter.Data.Models.QuizEntity", "Quiz")
                        .WithMany("Questions")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("AspNetCoreVueStarter.Data.Models.QuizPassingEntity", b =>
                {
                    b.HasOne("AspNetCoreVueStarter.Data.Models.QuizEntity", "Quiz")
                        .WithMany()
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AspNetCoreVueStarter.Data.Models.StudentEntity", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("AspNetCoreVueStarter.Data.Models.StudentAnswerEntity", b =>
                {
                    b.HasOne("AspNetCoreVueStarter.Data.Models.AnswerOptionEntity", "ChosenAnswerOption")
                        .WithMany()
                        .HasForeignKey("ChosenAnswerOptionId");

                    b.HasOne("AspNetCoreVueStarter.Data.Models.QuestionEntity", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId");

                    b.HasOne("AspNetCoreVueStarter.Data.Models.QuizPassingEntity", "QuizPassing")
                        .WithMany("StudentAnswers")
                        .HasForeignKey("QuizPassingId");

                    b.Navigation("ChosenAnswerOption");

                    b.Navigation("Question");

                    b.Navigation("QuizPassing");
                });

            modelBuilder.Entity("AspNetCoreVueStarter.Data.Models.QuestionEntity", b =>
                {
                    b.Navigation("AnswerOptions");
                });

            modelBuilder.Entity("AspNetCoreVueStarter.Data.Models.QuizEntity", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("AspNetCoreVueStarter.Data.Models.QuizPassingEntity", b =>
                {
                    b.Navigation("StudentAnswers");
                });
#pragma warning restore 612, 618
        }
    }
}