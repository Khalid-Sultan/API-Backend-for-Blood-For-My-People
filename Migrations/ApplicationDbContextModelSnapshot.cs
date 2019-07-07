﻿// <auto-generated />
using System;
using BloodDonation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BloodDonation.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Blood_Donation.Models.Message", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body");

                    b.Property<string>("Topic");

                    b.HasKey("id");

                    b.ToTable("messages");
                });

            modelBuilder.Entity("BloodDonation.Models.DonationHistory", b =>
                {
                    b.Property<int>("donationHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("amount");

                    b.Property<string>("date");

                    b.Property<int?>("donorId");

                    b.Property<int?>("recepientId");

                    b.HasKey("donationHistoryId");

                    b.HasIndex("donorId");

                    b.HasIndex("recepientId");

                    b.ToTable("donationHistories");
                });

            modelBuilder.Entity("BloodDonation.Models.Donor", b =>
                {
                    b.Property<int>("donorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("dateOfBirth");

                    b.Property<string>("fullName");

                    b.Property<string>("phoneNumber");

                    b.Property<int?>("userId");

                    b.HasKey("donorId");

                    b.HasIndex("userId")
                        .IsUnique()
                        .HasFilter("[userId] IS NOT NULL");

                    b.ToTable("donors");
                });

            modelBuilder.Entity("BloodDonation.Models.Item", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description");

                    b.Property<string>("full_name");

                    b.Property<string>("name");

                    b.Property<int>("stargazers_count");

                    b.Property<string>("user_login");

                    b.Property<string>("user_url");

                    b.HasKey("id");

                    b.ToTable("items");
                });

            modelBuilder.Entity("BloodDonation.Models.Recepient", b =>
                {
                    b.Property<int>("recepientId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("location");

                    b.Property<string>("name");

                    b.Property<string>("phoneNumber");

                    b.Property<int?>("userId");

                    b.HasKey("recepientId");

                    b.HasIndex("userId")
                        .IsUnique()
                        .HasFilter("[userId] IS NOT NULL");

                    b.ToTable("recepients");
                });

            modelBuilder.Entity("BloodDonation.Models.Report", b =>
                {
                    b.Property<int>("reportId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("bloodType");

                    b.Property<int?>("donationHistoryId");

                    b.HasKey("reportId");

                    b.HasIndex("donationHistoryId");

                    b.ToTable("reports");
                });

            modelBuilder.Entity("BloodDonation.Models.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email");

                    b.Property<string>("password");

                    b.Property<string>("role");

                    b.HasKey("userId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("BloodDonation.Models.DonationHistory", b =>
                {
                    b.HasOne("BloodDonation.Models.Donor", "donor")
                        .WithMany("DonationHistories")
                        .HasForeignKey("donorId");

                    b.HasOne("BloodDonation.Models.Recepient", "recepient")
                        .WithMany("DonationHistories")
                        .HasForeignKey("recepientId");
                });

            modelBuilder.Entity("BloodDonation.Models.Donor", b =>
                {
                    b.HasOne("BloodDonation.Models.User", "user")
                        .WithOne("donor")
                        .HasForeignKey("BloodDonation.Models.Donor", "userId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BloodDonation.Models.Recepient", b =>
                {
                    b.HasOne("BloodDonation.Models.User", "user")
                        .WithOne("recepient")
                        .HasForeignKey("BloodDonation.Models.Recepient", "userId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BloodDonation.Models.Report", b =>
                {
                    b.HasOne("BloodDonation.Models.DonationHistory", "donationHistory")
                        .WithMany()
                        .HasForeignKey("donationHistoryId");
                });
#pragma warning restore 612, 618
        }
    }
}
