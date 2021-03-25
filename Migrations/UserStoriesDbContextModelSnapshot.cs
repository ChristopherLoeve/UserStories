﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserStories.Models;

namespace UserStories.Migrations
{
    [DbContext(typeof(UserStoriesDbContext))]
    partial class UserStoriesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UserStories.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cards");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Card");
                });

            modelBuilder.Entity("UserStories.Models.Programmer", b =>
                {
                    b.Property<int>("ProgrammerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessLevel")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("ProfilePictureName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("ProgrammerId");

                    b.ToTable("Programmers");
                });

            modelBuilder.Entity("UserStories.Models.Fix", b =>
                {
                    b.HasBaseType("UserStories.Models.Card");

                    b.Property<bool>("Fixed")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("Fix");
                });

            modelBuilder.Entity("UserStories.Models.Task", b =>
                {
                    b.HasBaseType("UserStories.Models.Card");

                    b.Property<bool>("TaskDone")
                        .HasColumnType("bit");

                    b.Property<int?>("UserStoryId")
                        .HasColumnType("int");

                    b.HasIndex("UserStoryId");

                    b.HasDiscriminator().HasValue("Task");
                });

            modelBuilder.Entity("UserStories.Models.UserStory", b =>
                {
                    b.HasBaseType("UserStories.Models.Card");

                    b.Property<int>("BusinessValue")
                        .HasColumnType("int");

                    b.Property<int>("Column")
                        .HasColumnType("int");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("StoryPoints")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("UserStory");
                });

            modelBuilder.Entity("UserStories.Models.Task", b =>
                {
                    b.HasOne("UserStories.Models.UserStory", null)
                        .WithMany("Tasks")
                        .HasForeignKey("UserStoryId");
                });

            modelBuilder.Entity("UserStories.Models.UserStory", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
