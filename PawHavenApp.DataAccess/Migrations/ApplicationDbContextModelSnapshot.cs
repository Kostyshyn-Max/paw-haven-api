﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PawHavenApp.DataAccess.EF;

#nullable disable

namespace PawHavenApp.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PawHavenApp.DataAccess.Entities.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("OrganisationId")
                        .HasColumnType("integer")
                        .HasColumnName("organisation_id");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("OrganisationId");

                    b.HasIndex("UserId");

                    b.ToTable("chats");
                });

            modelBuilder.Entity("PawHavenApp.DataAccess.Entities.HealthStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("health_statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Здоровий"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Реабілітований"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Потребує лікування"
                        },
                        new
                        {
                            Id = 4,
                            Title = "Відновлюється"
                        },
                        new
                        {
                            Id = 5,
                            Title = "Критичний"
                        });
                });

            modelBuilder.Entity("PawHavenApp.DataAccess.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ChatId")
                        .HasColumnType("integer")
                        .HasColumnName("chat_id");

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("message_text");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uuid")
                        .HasColumnName("sender_id");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("SenderId");

                    b.ToTable("messages");
                });

            modelBuilder.Entity("PawHavenApp.DataAccess.Entities.Organisation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("DonationCredentials")
                        .HasColumnType("text")
                        .HasColumnName("donation_credentials");

                    b.Property<string>("Location")
                        .HasColumnType("text")
                        .HasColumnName("location");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("OrganisationCategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("organisation_category_id");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid")
                        .HasColumnName("owner_id");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.HasKey("Id");

                    b.HasIndex("OrganisationCategoryId");

                    b.HasIndex("OwnerId");

                    b.ToTable("organisations");
                });

            modelBuilder.Entity("PawHavenApp.DataAccess.Entities.OrganisationCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("organisation_categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Ветеринарна клініка"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Притулок"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Розплідник"
                        });
                });

            modelBuilder.Entity("PawHavenApp.DataAccess.Entities.PetCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer")
                        .HasColumnName("age");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Health")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("health");

                    b.Property<int>("HealthStatusId")
                        .HasColumnType("integer")
                        .HasColumnName("health_status_id");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("location");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid")
                        .HasColumnName("owner_id");

                    b.Property<int>("PetTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("pet_type_id");

                    b.Property<int>("Views")
                        .HasColumnType("integer")
                        .HasColumnName("views");

                    b.HasKey("Id");

                    b.HasIndex("HealthStatusId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("PetTypeId");

                    b.ToTable("pet_cards");
                });

            modelBuilder.Entity("PawHavenApp.DataAccess.Entities.PetPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PetCardId")
                        .HasColumnType("integer")
                        .HasColumnName("pet_card_id");

                    b.Property<string>("PetPhotoLink")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("pet_photo_link");

                    b.HasKey("Id");

                    b.HasIndex("PetCardId");

                    b.ToTable("pet_photos");
                });

            modelBuilder.Entity("PawHavenApp.DataAccess.Entities.PetStory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid")
                        .HasColumnName("author_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("Likes")
                        .HasColumnType("integer")
                        .HasColumnName("likes");

                    b.Property<string>("Link")
                        .HasColumnType("text")
                        .HasColumnName("photo_link");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("pet_stories");
                });

            modelBuilder.Entity("PawHavenApp.DataAccess.Entities.PetType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("pet_types");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Кіт"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Собака"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Рептилія"
                        },
                        new
                        {
                            Id = 4,
                            Title = "Інші"
                        });
                });

            modelBuilder.Entity("PawHavenApp.DataAccess.Entities.Testimonial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid")
                        .HasColumnName("author_id");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("message");

                    b.Property<int>("OrganisationId")
                        .HasColumnType("integer")
                        .HasColumnName("organisation_id");

                    b.Property<DateTime>("PostedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("posted_date");

                    b.Property<int>("Rate")
                        .HasColumnType("integer")
                        .HasColumnName("rate");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("OrganisationId");

                    b.ToTable("testimonials");
                });

            modelBuilder.Entity("PawHavenApp.DataAccess.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<bool>("IsOrganisationOwner")
                        .HasColumnType("boolean")
                        .HasColumnName("is_organisation_owner");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_salt");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text")
                        .HasColumnName("refresh_token");

                    b.Property<DateTime?>("RefreshTokenExpireDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("refresh_token_expire_date");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("registration_date");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer")
                        .HasColumnName("role_id");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("PawHavenApp.DataAccess.Entities.UserFavourite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PetCardId")
                        .HasColumnType("integer")
                        .HasColumnName("pet_card_id");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("PetCardId");

                    b.HasIndex("UserId");

                    b.ToTable("user_favourites");
                });

            modelBuilder.Entity("PawHavenApp.DataAccess.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("user_roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "User"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Organisation Owner"
                        });
                });

            modelBuilder.Entity("PawHavenApp.DataAccess.Entities.Chat", b =>
                {
                    b.HasOne("PawHavenApp.DataAccess.Entities.Organisation", "Organisation")
                        .WithMany()
                        .HasForeignKey("OrganisationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PawHavenApp.DataAccess.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organisation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PawHavenApp.DataAccess.Entities.Message", b =>
                {
                    b.HasOne("PawHavenApp.DataAccess.Entities.Chat", "Chat")
                        .WithMany()
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PawHavenApp.DataAccess.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PawHavenApp.DataAccess.Entities.Organisation", b =>
                {
                    b.HasOne("PawHavenApp.DataAccess.Entities.OrganisationCategory", "OrganisationCategory")
                        .WithMany()
                        .HasForeignKey("OrganisationCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PawHavenApp.DataAccess.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrganisationCategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PawHavenApp.DataAccess.Entities.PetCard", b =>
                {
                    b.HasOne("PawHavenApp.DataAccess.Entities.HealthStatus", "HealthStatus")
                        .WithMany()
                        .HasForeignKey("HealthStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PawHavenApp.DataAccess.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PawHavenApp.DataAccess.Entities.PetType", "PetType")
                        .WithMany()
                        .HasForeignKey("PetTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HealthStatus");

                    b.Navigation("PetType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PawHavenApp.DataAccess.Entities.PetPhoto", b =>
                {
                    b.HasOne("PawHavenApp.DataAccess.Entities.PetCard", "PetCard")
                        .WithMany()
                        .HasForeignKey("PetCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PetCard");
                });

            modelBuilder.Entity("PawHavenApp.DataAccess.Entities.PetStory", b =>
                {
                    b.HasOne("PawHavenApp.DataAccess.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PawHavenApp.DataAccess.Entities.Testimonial", b =>
                {
                    b.HasOne("PawHavenApp.DataAccess.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PawHavenApp.DataAccess.Entities.Organisation", "Organisation")
                        .WithMany()
                        .HasForeignKey("OrganisationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organisation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PawHavenApp.DataAccess.Entities.User", b =>
                {
                    b.HasOne("PawHavenApp.DataAccess.Entities.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("PawHavenApp.DataAccess.Entities.UserFavourite", b =>
                {
                    b.HasOne("PawHavenApp.DataAccess.Entities.PetCard", "PetCard")
                        .WithMany()
                        .HasForeignKey("PetCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PawHavenApp.DataAccess.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PetCard");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
