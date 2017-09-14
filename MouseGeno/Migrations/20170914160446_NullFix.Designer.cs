﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MouseGeno.Data;
using System;

namespace MouseGeno.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170914160446_NullFix")]
    partial class NullFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
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
                        .ValueGeneratedOnAdd();

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
                        .ValueGeneratedOnAdd();

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

            modelBuilder.Entity("MouseGeno.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Initials")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

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

            modelBuilder.Entity("MouseGeno.Models.Cage", b =>
                {
                    b.Property<int>("CageID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Breeding");

                    b.Property<string>("CageNumber")
                        .IsRequired()
                        .HasMaxLength(8);

                    b.Property<string>("Cubicle")
                        .HasMaxLength(3);

                    b.HasKey("CageID");

                    b.ToTable("Cage");
                });

            modelBuilder.Entity("MouseGeno.Models.CageCondition", b =>
                {
                    b.Property<int>("CageConditionID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CageID");

                    b.Property<string>("Comments");

                    b.Property<int>("ConditionID");

                    b.Property<DateTime>("Date");

                    b.Property<string>("UserId");

                    b.HasKey("CageConditionID");

                    b.HasIndex("CageID");

                    b.HasIndex("ConditionID");

                    b.HasIndex("UserId");

                    b.ToTable("CageCondition");
                });

            modelBuilder.Entity("MouseGeno.Models.Condition", b =>
                {
                    b.Property<int>("ConditionID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Instructions")
                        .IsRequired()
                        .HasMaxLength(155);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("ConditionID");

                    b.ToTable("Condition");
                });

            modelBuilder.Entity("MouseGeno.Models.GeneExpression", b =>
                {
                    b.Property<int>("GeneExpressionID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(18);

                    b.Property<string>("ShortHand")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("GeneExpressionID");

                    b.ToTable("GeneExpression");
                });

            modelBuilder.Entity("MouseGeno.Models.HealthStatus", b =>
                {
                    b.Property<int>("HealthStatusID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(155);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("HealthStatusID");

                    b.ToTable("HealthStatus");
                });

            modelBuilder.Entity("MouseGeno.Models.Line", b =>
                {
                    b.Property<int>("LineID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(155);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(24);

                    b.HasKey("LineID");

                    b.ToTable("Line");
                });

            modelBuilder.Entity("MouseGeno.Models.Mouse", b =>
                {
                    b.Property<int>("MouseID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birth");

                    b.Property<int?>("DadID");

                    b.Property<DateTime?>("Death");

                    b.Property<string>("EarTag");

                    b.Property<int>("LineID");

                    b.Property<int?>("MomID");

                    b.Property<int?>("PK1ID");

                    b.Property<int?>("PK2ID");

                    b.Property<string>("Sex")
                        .IsRequired();

                    b.Property<bool?>("SynCre");

                    b.Property<string>("ToeClip");

                    b.HasKey("MouseID");

                    b.HasIndex("LineID");

                    b.HasIndex("PK1ID");

                    b.HasIndex("PK2ID");

                    b.ToTable("Mouse");
                });

            modelBuilder.Entity("MouseGeno.Models.MouseCage", b =>
                {
                    b.Property<int>("MouseCageID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CageID");

                    b.Property<DateTime?>("EndDate");

                    b.Property<int>("MouseID");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("MouseCageID");

                    b.HasIndex("CageID");

                    b.HasIndex("MouseID");

                    b.ToTable("MouseCage");
                });

            modelBuilder.Entity("MouseGeno.Models.MouseHealthStatus", b =>
                {
                    b.Property<int>("MouseHealthStatusID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndDate");

                    b.Property<int>("HealthStatusID");

                    b.Property<int>("MouseID");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("UserId");

                    b.HasKey("MouseHealthStatusID");

                    b.HasIndex("HealthStatusID");

                    b.HasIndex("MouseID");

                    b.HasIndex("UserId");

                    b.ToTable("MouseHealthStatus");
                });

            modelBuilder.Entity("MouseGeno.Models.MouseTask", b =>
                {
                    b.Property<int>("MouseTaskID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comments");

                    b.Property<string>("Data");

                    b.Property<DateTime>("Date");

                    b.Property<int>("MouseID");

                    b.Property<int>("TaskTypeID");

                    b.Property<string>("UserId");

                    b.HasKey("MouseTaskID");

                    b.HasIndex("MouseID");

                    b.HasIndex("TaskTypeID");

                    b.HasIndex("UserId");

                    b.ToTable("MouseTask");
                });

            modelBuilder.Entity("MouseGeno.Models.TaskType", b =>
                {
                    b.Property<int>("TaskTypeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Instructions")
                        .IsRequired()
                        .HasMaxLength(155);

                    b.Property<string>("MeasurementType")
                        .HasMaxLength(8);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("TaskTypeID");

                    b.ToTable("TaskType");
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
                    b.HasOne("MouseGeno.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MouseGeno.Models.ApplicationUser")
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

                    b.HasOne("MouseGeno.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MouseGeno.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MouseGeno.Models.CageCondition", b =>
                {
                    b.HasOne("MouseGeno.Models.Cage", "Cage")
                        .WithMany("CageConditions")
                        .HasForeignKey("CageID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MouseGeno.Models.Condition", "Condition")
                        .WithMany("CageConditions")
                        .HasForeignKey("ConditionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MouseGeno.Models.ApplicationUser", "User")
                        .WithMany("CageConditions")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MouseGeno.Models.Mouse", b =>
                {
                    b.HasOne("MouseGeno.Models.Line", "Line")
                        .WithMany("Mice")
                        .HasForeignKey("LineID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MouseGeno.Models.GeneExpression", "PK1")
                        .WithMany("PK1GenoTypes")
                        .HasForeignKey("PK1ID");

                    b.HasOne("MouseGeno.Models.GeneExpression", "PK2")
                        .WithMany("PK2GenoTypes")
                        .HasForeignKey("PK2ID");
                });

            modelBuilder.Entity("MouseGeno.Models.MouseCage", b =>
                {
                    b.HasOne("MouseGeno.Models.Cage", "Cage")
                        .WithMany("MouseCages")
                        .HasForeignKey("CageID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MouseGeno.Models.Mouse", "Mouse")
                        .WithMany("MouseCages")
                        .HasForeignKey("MouseID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MouseGeno.Models.MouseHealthStatus", b =>
                {
                    b.HasOne("MouseGeno.Models.HealthStatus", "HealthStatus")
                        .WithMany()
                        .HasForeignKey("HealthStatusID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MouseGeno.Models.Mouse", "Mouse")
                        .WithMany("MouseHealthStatuses")
                        .HasForeignKey("MouseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MouseGeno.Models.ApplicationUser", "User")
                        .WithMany("MouseHealthStatuses")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MouseGeno.Models.MouseTask", b =>
                {
                    b.HasOne("MouseGeno.Models.Mouse", "Mouse")
                        .WithMany("MouseTasks")
                        .HasForeignKey("MouseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MouseGeno.Models.TaskType", "TaskType")
                        .WithMany()
                        .HasForeignKey("TaskTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MouseGeno.Models.ApplicationUser", "User")
                        .WithMany("MouseTasks")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
