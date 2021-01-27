﻿// <auto-generated />
using System;
using CivicHub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CivicHub.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20201218172038_Migrena")]
    partial class Migrena
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("CivicHub.Entities.Issue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("CivicHub.Entities.IssueState", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CustomMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IssueId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IssueId");

                    b.ToTable("IssueStates");
                });

            modelBuilder.Entity("CivicHub.Entities.IssueStateComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IssueStateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("dateCreated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IssueStateId");

                    b.HasIndex("UserId");

                    b.ToTable("IssueStateComments");
                });

            modelBuilder.Entity("CivicHub.Entities.IssueStateCommentLike", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IssueStateCommentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasAlternateKey("UserId", "IssueStateCommentId");

                    b.HasIndex("IssueStateCommentId");

                    b.ToTable("IssueStateCommentLikes");
                });

            modelBuilder.Entity("CivicHub.Entities.IssueStateCommentPhoto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IssueStateCommentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("IssueStateCommentId");

                    b.ToTable("IssueStateCommentPhotos");
                });

            modelBuilder.Entity("CivicHub.Entities.IssueStatePhoto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IssueStateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("dateAdded")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IssueStateId");

                    b.ToTable("IssueStatePhotos");
                });

            modelBuilder.Entity("CivicHub.Entities.IssueStateReaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IssueStateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Vote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dateGiven")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasAlternateKey("UserId", "IssueStateId");

                    b.HasIndex("IssueStateId");

                    b.ToTable("IssueStateReactions");
                });

            modelBuilder.Entity("CivicHub.Entities.IssueStateSignature", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cnp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateSigned")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IssueStateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumarBuletin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerieBuletin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasAlternateKey("UserId", "IssueStateId");

                    b.HasIndex("IssueStateId");

                    b.ToTable("IssueSignatures");
                });

            modelBuilder.Entity("CivicHub.Entities.IssueStateVideo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IssueStateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("dateAdded")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IssueStateId");

                    b.ToTable("IssueStateVideos");
                });

            modelBuilder.Entity("CivicHub.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Avatar")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("DateRegistered")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasAlternateKey("Mail");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CivicHub.Entities.Issue", b =>
                {
                    b.HasOne("CivicHub.Entities.User", "User")
                        .WithMany("Issues")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CivicHub.Entities.IssueState", b =>
                {
                    b.HasOne("CivicHub.Entities.Issue", "Issue")
                        .WithMany("IssueStates")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Issue");
                });

            modelBuilder.Entity("CivicHub.Entities.IssueStateComment", b =>
                {
                    b.HasOne("CivicHub.Entities.IssueState", "IssueState")
                        .WithMany("IssueStateComments")
                        .HasForeignKey("IssueStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CivicHub.Entities.User", "User")
                        .WithMany("IssueStateComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("IssueState");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CivicHub.Entities.IssueStateCommentLike", b =>
                {
                    b.HasOne("CivicHub.Entities.IssueStateComment", "IssueStateComment")
                        .WithMany("IssueStateCommentLikes")
                        .HasForeignKey("IssueStateCommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CivicHub.Entities.User", "User")
                        .WithMany("IssueStateCommentLikes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("IssueStateComment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CivicHub.Entities.IssueStateCommentPhoto", b =>
                {
                    b.HasOne("CivicHub.Entities.IssueStateComment", "IssueStateComment")
                        .WithMany("IssueStateCommentPhotos")
                        .HasForeignKey("IssueStateCommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IssueStateComment");
                });

            modelBuilder.Entity("CivicHub.Entities.IssueStatePhoto", b =>
                {
                    b.HasOne("CivicHub.Entities.IssueState", "IssueState")
                        .WithMany("IssueStatePhotos")
                        .HasForeignKey("IssueStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IssueState");
                });

            modelBuilder.Entity("CivicHub.Entities.IssueStateReaction", b =>
                {
                    b.HasOne("CivicHub.Entities.IssueState", "IssueState")
                        .WithMany("IssueStateReactions")
                        .HasForeignKey("IssueStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CivicHub.Entities.User", "User")
                        .WithMany("IssueStateReactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("IssueState");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CivicHub.Entities.IssueStateSignature", b =>
                {
                    b.HasOne("CivicHub.Entities.IssueState", "IssueState")
                        .WithMany("IssueStateSignatures")
                        .HasForeignKey("IssueStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CivicHub.Entities.User", "User")
                        .WithMany("IssueStateSignatures")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("IssueState");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CivicHub.Entities.IssueStateVideo", b =>
                {
                    b.HasOne("CivicHub.Entities.IssueState", "IssueState")
                        .WithMany("IssueStateVideos")
                        .HasForeignKey("IssueStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IssueState");
                });

            modelBuilder.Entity("CivicHub.Entities.Issue", b =>
                {
                    b.Navigation("IssueStates");
                });

            modelBuilder.Entity("CivicHub.Entities.IssueState", b =>
                {
                    b.Navigation("IssueStateComments");

                    b.Navigation("IssueStatePhotos");

                    b.Navigation("IssueStateReactions");

                    b.Navigation("IssueStateSignatures");

                    b.Navigation("IssueStateVideos");
                });

            modelBuilder.Entity("CivicHub.Entities.IssueStateComment", b =>
                {
                    b.Navigation("IssueStateCommentLikes");

                    b.Navigation("IssueStateCommentPhotos");
                });

            modelBuilder.Entity("CivicHub.Entities.User", b =>
                {
                    b.Navigation("Issues");

                    b.Navigation("IssueStateCommentLikes");

                    b.Navigation("IssueStateComments");

                    b.Navigation("IssueStateReactions");

                    b.Navigation("IssueStateSignatures");
                });
#pragma warning restore 612, 618
        }
    }
}
