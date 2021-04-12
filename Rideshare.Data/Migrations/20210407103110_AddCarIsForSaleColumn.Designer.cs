﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rideshare.Data;

namespace Rideshare.Data.Migrations
{
    [DbContext(typeof(RideshareDbContext))]
    [Migration("20210407103110_AddCarIsForSaleColumn")]
    partial class AddCarIsForSaleColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Rideshare.Model.ApplicantTravel", b =>
                {
                    b.Property<string>("ApplicantId");

                    b.Property<int>("TravelId");

                    b.HasKey("ApplicantId", "TravelId");

                    b.HasIndex("TravelId");

                    b.ToTable("ApplicantTravel");
                });

            modelBuilder.Entity("Rideshare.Model.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdditionalInfo");

                    b.Property<bool>("AreDrinksAllowed");

                    b.Property<bool>("ArePetsAllowed");

                    b.Property<string>("Color")
                        .IsRequired();

                    b.Property<bool>("HasAirConditioner");

                    b.Property<bool>("HasRoomForLuggage");

                    b.Property<bool>("IsFoodAllowed");

                    b.Property<bool>("IsForSale");

                    b.Property<bool>("IsSmokingAllowed");

                    b.Property<string>("Make")
                        .IsRequired();

                    b.Property<string>("Model")
                        .IsRequired();

                    b.Property<string>("OwnerId");

                    b.Property<byte[]>("Photo");

                    b.Property<string>("Type");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Rideshare.Model.Forum.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Rideshare.Model.Forum.Reply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorId");

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<DateTime>("Published");

                    b.Property<int>("TopicId");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("TopicId");

                    b.ToTable("Replies");
                });

            modelBuilder.Entity("Rideshare.Model.Forum.Subforum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Subforums");
                });

            modelBuilder.Entity("Rideshare.Model.Forum.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorId");

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("Published");

                    b.Property<int>("SubforumId");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("SubforumId");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("Rideshare.Model.Message", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<DateTime>("DateTime");

                    b.Property<bool>("IsRead");

                    b.Property<bool>("IsSent");

                    b.Property<string>("RecipientId");

                    b.Property<string>("SenderId");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RecipientId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Rideshare.Model.PassengerTravel", b =>
                {
                    b.Property<string>("PassengerId");

                    b.Property<int>("TravelId");

                    b.HasKey("PassengerId", "TravelId");

                    b.HasIndex("TravelId");

                    b.ToTable("PassengerTravel");
                });

            modelBuilder.Entity("Rideshare.Model.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorId");

                    b.Property<string>("Comment");

                    b.Property<int>("Rating");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Rideshare.Model.Travel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdditionalInfo");

                    b.Property<int>("AvailableSeats");

                    b.Property<int>("CarId");

                    b.Property<string>("Destination")
                        .IsRequired();

                    b.Property<string>("DriverId");

                    b.Property<decimal>("Price");

                    b.Property<string>("StartingPoint")
                        .IsRequired();

                    b.Property<DateTime>("TravelTime");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("DriverId");

                    b.ToTable("Travels");
                });

            modelBuilder.Entity("Rideshare.Model.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<DateTime>("Birthdate");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<byte[]>("ProfilePicture");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Rideshare.Model.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Rideshare.Model.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rideshare.Model.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Rideshare.Model.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rideshare.Model.ApplicantTravel", b =>
                {
                    b.HasOne("Rideshare.Model.User", "Applicant")
                        .WithMany("Applications")
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rideshare.Model.Travel", "Travel")
                        .WithMany("Applicants")
                        .HasForeignKey("TravelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rideshare.Model.Car", b =>
                {
                    b.HasOne("Rideshare.Model.User", "Owner")
                        .WithMany("Cars")
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("Rideshare.Model.Forum.Reply", b =>
                {
                    b.HasOne("Rideshare.Model.User", "Author")
                        .WithMany("ForumReplies")
                        .HasForeignKey("AuthorId");

                    b.HasOne("Rideshare.Model.Forum.Topic", "Topic")
                        .WithMany("Replies")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rideshare.Model.Forum.Subforum", b =>
                {
                    b.HasOne("Rideshare.Model.Forum.Category", "Category")
                        .WithMany("Subforums")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rideshare.Model.Forum.Topic", b =>
                {
                    b.HasOne("Rideshare.Model.User", "Author")
                        .WithMany("ForumTopics")
                        .HasForeignKey("AuthorId");

                    b.HasOne("Rideshare.Model.Forum.Subforum", "Subforum")
                        .WithMany("Topics")
                        .HasForeignKey("SubforumId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rideshare.Model.Message", b =>
                {
                    b.HasOne("Rideshare.Model.User", "Recipient")
                        .WithMany("Messages")
                        .HasForeignKey("RecipientId");

                    b.HasOne("Rideshare.Model.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId");
                });

            modelBuilder.Entity("Rideshare.Model.PassengerTravel", b =>
                {
                    b.HasOne("Rideshare.Model.User", "Passenger")
                        .WithMany("Travels")
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rideshare.Model.Travel", "Travel")
                        .WithMany("Passengers")
                        .HasForeignKey("TravelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rideshare.Model.Review", b =>
                {
                    b.HasOne("Rideshare.Model.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("Rideshare.Model.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Rideshare.Model.Travel", b =>
                {
                    b.HasOne("Rideshare.Model.Car", "Car")
                        .WithMany("Travels")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rideshare.Model.User", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId");
                });
#pragma warning restore 612, 618
        }
    }
}
