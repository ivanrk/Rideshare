﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rideshare.Data;

namespace Rideshare.Data.Migrations
{
    [DbContext(typeof(RideshareDbContext))]
    partial class RideshareDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
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

            modelBuilder.Entity("Rideshare.Data.Models.ApplicantTravel", b =>
                {
                    b.Property<string>("ApplicantId");

                    b.Property<int>("TravelId");

                    b.HasKey("ApplicantId", "TravelId");

                    b.HasIndex("TravelId");

                    b.ToTable("ApplicantTravel");
                });

            modelBuilder.Entity("Rideshare.Data.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AreDrinksAllowed");

                    b.Property<bool>("ArePetsAllowed");

                    b.Property<string>("Color")
                        .IsRequired();

                    b.Property<bool>("HasAirConditioner");

                    b.Property<bool>("HasRoomForLuggage");

                    b.Property<bool>("IsFoodAllowed");

                    b.Property<bool>("IsSmokingAllowed");

                    b.Property<string>("Make")
                        .IsRequired();

                    b.Property<string>("Model")
                        .IsRequired();

                    b.Property<string>("OwnerId");

                    b.Property<byte[]>("Photo");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Rideshare.Data.Models.Forum.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Rideshare.Data.Models.Forum.Reply", b =>
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

            modelBuilder.Entity("Rideshare.Data.Models.Forum.Subforum", b =>
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

            modelBuilder.Entity("Rideshare.Data.Models.Forum.Topic", b =>
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

            modelBuilder.Entity("Rideshare.Data.Models.Message", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<DateTime>("DateTime");

                    b.Property<bool>("IsRead");

                    b.Property<string>("RecipientId");

                    b.Property<string>("SenderId");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RecipientId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Rideshare.Data.Models.PassengerTravel", b =>
                {
                    b.Property<string>("PassengerId");

                    b.Property<int>("TravelId");

                    b.HasKey("PassengerId", "TravelId");

                    b.HasIndex("TravelId");

                    b.ToTable("PassengerTravel");
                });

            modelBuilder.Entity("Rideshare.Data.Models.Review", b =>
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

            modelBuilder.Entity("Rideshare.Data.Models.Travel", b =>
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

            modelBuilder.Entity("Rideshare.Data.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

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
                    b.HasOne("Rideshare.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Rideshare.Data.Models.User")
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

                    b.HasOne("Rideshare.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Rideshare.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rideshare.Data.Models.ApplicantTravel", b =>
                {
                    b.HasOne("Rideshare.Data.Models.User", "Applicant")
                        .WithMany("Applications")
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rideshare.Data.Models.Travel", "Travel")
                        .WithMany("Applicants")
                        .HasForeignKey("TravelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rideshare.Data.Models.Car", b =>
                {
                    b.HasOne("Rideshare.Data.Models.User", "Owner")
                        .WithMany("Cars")
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("Rideshare.Data.Models.Forum.Reply", b =>
                {
                    b.HasOne("Rideshare.Data.Models.User", "Author")
                        .WithMany("ForumReplies")
                        .HasForeignKey("AuthorId");

                    b.HasOne("Rideshare.Data.Models.Forum.Topic", "Topic")
                        .WithMany("Replies")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rideshare.Data.Models.Forum.Subforum", b =>
                {
                    b.HasOne("Rideshare.Data.Models.Forum.Category", "Category")
                        .WithMany("Subforums")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rideshare.Data.Models.Forum.Topic", b =>
                {
                    b.HasOne("Rideshare.Data.Models.User", "Author")
                        .WithMany("ForumTopics")
                        .HasForeignKey("AuthorId");

                    b.HasOne("Rideshare.Data.Models.Forum.Subforum", "Subforum")
                        .WithMany("Topics")
                        .HasForeignKey("SubforumId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rideshare.Data.Models.Message", b =>
                {
                    b.HasOne("Rideshare.Data.Models.User", "Recipient")
                        .WithMany("Messages")
                        .HasForeignKey("RecipientId");

                    b.HasOne("Rideshare.Data.Models.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId");
                });

            modelBuilder.Entity("Rideshare.Data.Models.PassengerTravel", b =>
                {
                    b.HasOne("Rideshare.Data.Models.User", "Passenger")
                        .WithMany("Travels")
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rideshare.Data.Models.Travel", "Travel")
                        .WithMany("Passengers")
                        .HasForeignKey("TravelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rideshare.Data.Models.Review", b =>
                {
                    b.HasOne("Rideshare.Data.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("Rideshare.Data.Models.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Rideshare.Data.Models.Travel", b =>
                {
                    b.HasOne("Rideshare.Data.Models.Car", "Car")
                        .WithMany("Travels")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rideshare.Data.Models.User", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId");
                });
#pragma warning restore 612, 618
        }
    }
}
