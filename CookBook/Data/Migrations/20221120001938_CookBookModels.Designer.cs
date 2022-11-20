﻿// <auto-generated />
using System;
using CookBook.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CookBook.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221120001938_CookBookModels")]
    partial class CookBookModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("cook_book")
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CookBook.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer")
                        .HasColumnName("access_failed_count");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("email_confirmed");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("lockout_enabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("lockout_end");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_email");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_user_name");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("phone_number_confirmed");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text")
                        .HasColumnName("security_stamp");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("two_factor_enabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("user_name");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_users");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("asp_net_users", "cook_book");
                });

            modelBuilder.Entity("CookBook.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(false)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_categories");

                    b.ToTable("categories", "cook_book");
                });

            modelBuilder.Entity("CookBook.Models.Ingredient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(false)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_ingredients");

                    b.ToTable("ingredients", "cook_book");
                });

            modelBuilder.Entity("CookBook.Models.Recipe", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .IsUnicode(false)
                        .HasColumnType("character varying(512)")
                        .HasColumnName("description");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(128)
                        .IsUnicode(false)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("short_description");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(false)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_recipes");

                    b.ToTable("recipes", "cook_book");
                });

            modelBuilder.Entity("CookBook.Models.RecipeCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("category_id")
                        .HasColumnType("bigint")
                        .HasColumnName("category_id");

                    b.Property<long>("recipe_id")
                        .HasColumnType("bigint")
                        .HasColumnName("recipe_id");

                    b.HasKey("Id")
                        .HasName("pk_recipe_category");

                    b.HasIndex("category_id")
                        .HasDatabaseName("ix_recipe_category_category_id");

                    b.HasIndex("recipe_id")
                        .HasDatabaseName("ix_recipe_category_recipe_id");

                    b.ToTable("recipe_category", "cook_book");
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.DeviceFlowCodes", b =>
                {
                    b.Property<string>("UserCode")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("user_code");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("client_id");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_time");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("character varying(50000)")
                        .HasColumnName("data");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("description");

                    b.Property<string>("DeviceCode")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("device_code");

                    b.Property<DateTime?>("Expiration")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("expiration");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("session_id");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("subject_id");

                    b.HasKey("UserCode")
                        .HasName("pk_identity_device_flow_codes");

                    b.HasIndex("DeviceCode")
                        .IsUnique()
                        .HasDatabaseName("ix_identity_device_flow_codes_device_code");

                    b.HasIndex("Expiration")
                        .HasDatabaseName("ix_identity_device_flow_codes_expiration");

                    b.ToTable("identity_device_flow_codes", "cook_book");
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.Key", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("Algorithm")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("algorithm");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("data");

                    b.Property<bool>("DataProtected")
                        .HasColumnType("boolean")
                        .HasColumnName("data_protected");

                    b.Property<bool>("IsX509Certificate")
                        .HasColumnType("boolean")
                        .HasColumnName("is_x509certificate");

                    b.Property<string>("Use")
                        .HasColumnType("text")
                        .HasColumnName("use");

                    b.Property<int>("Version")
                        .HasColumnType("integer")
                        .HasColumnName("version");

                    b.HasKey("Id")
                        .HasName("pk_keys");

                    b.HasIndex("Use")
                        .HasDatabaseName("ix_keys_use");

                    b.ToTable("keys", "cook_book");
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.PersistedGrant", b =>
                {
                    b.Property<string>("Key")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("key");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("client_id");

                    b.Property<DateTime?>("ConsumedTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("consumed_time");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_time");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("character varying(50000)")
                        .HasColumnName("data");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("description");

                    b.Property<DateTime?>("Expiration")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("expiration");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("session_id");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("subject_id");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("type");

                    b.HasKey("Key")
                        .HasName("pk_identity_persisted_grants");

                    b.HasIndex("ConsumedTime")
                        .HasDatabaseName("ix_identity_persisted_grants_consumed_time");

                    b.HasIndex("Expiration")
                        .HasDatabaseName("ix_identity_persisted_grants_expiration");

                    b.HasIndex("SubjectId", "ClientId", "Type")
                        .HasDatabaseName("ix_identity_persisted_grants_subject_id_client_id_type");

                    b.HasIndex("SubjectId", "SessionId", "Type")
                        .HasDatabaseName("ix_identity_persisted_grants_subject_id_session_id_type");

                    b.ToTable("identity_persisted_grants", "cook_book");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_name");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_roles");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("asp_net_roles", "cook_book");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("claim_value");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("role_id");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_role_claims");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_asp_net_role_claims_role_id");

                    b.ToTable("asp_net_role_claims", "cook_book");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("claim_value");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_user_claims");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_asp_net_user_claims_user_id");

                    b.ToTable("asp_net_user_claims", "cook_book");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("login_provider");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("provider_key");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text")
                        .HasColumnName("provider_display_name");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("pk_asp_net_user_logins");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_asp_net_user_logins_user_id");

                    b.ToTable("asp_net_user_logins", "cook_book");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.Property<string>("RoleId")
                        .HasColumnType("text")
                        .HasColumnName("role_id");

                    b.HasKey("UserId", "RoleId")
                        .HasName("pk_asp_net_user_roles");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_asp_net_user_roles_role_id");

                    b.ToTable("asp_net_user_roles", "cook_book");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("login_provider");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("name");

                    b.Property<string>("Value")
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("UserId", "LoginProvider", "Name")
                        .HasName("pk_asp_net_user_tokens");

                    b.ToTable("asp_net_user_tokens", "cook_book");
                });

            modelBuilder.Entity("CookBook.Models.Recipe", b =>
                {
                    b.OwnsMany("CookBook.Models.RecipeIngredientAmount", "IngredientAmounts", b1 =>
                        {
                            b1.Property<long>("RecipeId")
                                .HasColumnType("bigint")
                                .HasColumnName("recipe_id");

                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasColumnName("id");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<long>("Id"));

                            b1.Property<string>("Amount")
                                .IsRequired()
                                .HasMaxLength(64)
                                .IsUnicode(false)
                                .HasColumnType("character varying(64)")
                                .HasColumnName("amount");

                            b1.Property<long>("IngredientId")
                                .HasColumnType("bigint")
                                .HasColumnName("ingredient_id");

                            b1.HasKey("RecipeId", "Id")
                                .HasName("pk_recipe_ingredient_amount");

                            b1.HasIndex("IngredientId")
                                .HasDatabaseName("ix_recipe_ingredient_amount_ingredient_id");

                            b1.ToTable("recipe_ingredient_amount", "cook_book");

                            b1.HasOne("CookBook.Models.Ingredient", "Ingredient")
                                .WithMany()
                                .HasForeignKey("IngredientId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired()
                                .HasConstraintName("fk_recipe_ingredient_amount_ingredients_ingredient_id");

                            b1.WithOwner()
                                .HasForeignKey("RecipeId")
                                .HasConstraintName("fk_recipe_ingredient_amount_recipes_recipe_id");

                            b1.Navigation("Ingredient");
                        });

                    b.Navigation("IngredientAmounts");
                });

            modelBuilder.Entity("CookBook.Models.RecipeCategory", b =>
                {
                    b.HasOne("CookBook.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_recipe_category_categories_category_id");

                    b.HasOne("CookBook.Models.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("recipe_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_recipe_category_recipes_recipe_id");

                    b.Navigation("Category");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_role_claims_asp_net_roles_role_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CookBook.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_claims_asp_net_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CookBook.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_logins_asp_net_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_roles_asp_net_roles_role_id");

                    b.HasOne("CookBook.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_roles_asp_net_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CookBook.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_tokens_asp_net_users_user_id");
                });
#pragma warning restore 612, 618
        }
    }
}
