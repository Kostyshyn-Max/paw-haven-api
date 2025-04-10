#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PawHavenApp.DataAccess.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;
    using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "health_statuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_health_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "organisation_categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organisation_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pet_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pet_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    password_salt = table.Column<string>(type: "text", nullable: false),
                    is_organisation_owner = table.Column<bool>(type: "boolean", nullable: false),
                    refresh_token = table.Column<string>(type: "text", nullable: false),
                    refresh_token_expire_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    registration_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_user_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "user_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "organisations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    owner_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    location = table.Column<string>(type: "text", nullable: true),
                    donation_credentials = table.Column<string>(type: "text", nullable: true),
                    organisation_category_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organisations", x => x.id);
                    table.ForeignKey(
                        name: "FK_organisations_organisation_categories_organisation_category~",
                        column: x => x.organisation_category_id,
                        principalTable: "organisation_categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_organisations_users_owner_id",
                        column: x => x.owner_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pet_cards",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    owner_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    age = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    location = table.Column<string>(type: "text", nullable: false),
                    health = table.Column<string>(type: "text", nullable: false),
                    health_status_id = table.Column<int>(type: "integer", nullable: false),
                    pet_type_id = table.Column<int>(type: "integer", nullable: false),
                    views = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pet_cards", x => x.id);
                    table.ForeignKey(
                        name: "FK_pet_cards_health_statuses_health_status_id",
                        column: x => x.health_status_id,
                        principalTable: "health_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pet_cards_pet_types_pet_type_id",
                        column: x => x.pet_type_id,
                        principalTable: "pet_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pet_cards_users_owner_id",
                        column: x => x.owner_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pet_stories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    likes = table.Column<int>(type: "integer", nullable: false),
                    photo_link = table.Column<string>(type: "text", nullable: true),
                    author_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pet_stories", x => x.id);
                    table.ForeignKey(
                        name: "FK_pet_stories_users_author_id",
                        column: x => x.author_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chats",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    organisation_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chats", x => x.id);
                    table.ForeignKey(
                        name: "FK_chats_organisations_organisation_id",
                        column: x => x.organisation_id,
                        principalTable: "organisations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chats_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "testimonials",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    message = table.Column<string>(type: "text", nullable: false),
                    author_id = table.Column<Guid>(type: "uuid", nullable: false),
                    organisation_id = table.Column<int>(type: "integer", nullable: false),
                    posted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    rate = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_testimonials", x => x.id);
                    table.ForeignKey(
                        name: "FK_testimonials_organisations_organisation_id",
                        column: x => x.organisation_id,
                        principalTable: "organisations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_testimonials_users_author_id",
                        column: x => x.author_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pet_photos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pet_photo_link = table.Column<string>(type: "text", nullable: false),
                    pet_card_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pet_photos", x => x.id);
                    table.ForeignKey(
                        name: "FK_pet_photos_pet_cards_pet_card_id",
                        column: x => x.pet_card_id,
                        principalTable: "pet_cards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_favourites",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    pet_card_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_favourites", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_favourites_pet_cards_pet_card_id",
                        column: x => x.pet_card_id,
                        principalTable: "pet_cards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_favourites_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    message_text = table.Column<string>(type: "text", nullable: false),
                    chat_id = table.Column<int>(type: "integer", nullable: false),
                    sender_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.id);
                    table.ForeignKey(
                        name: "FK_messages_chats_chat_id",
                        column: x => x.chat_id,
                        principalTable: "chats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_messages_users_sender_id",
                        column: x => x.sender_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "health_statuses",
                columns: new[] { "id", "title" },
                values: new object[,]
                {
                    { 1, "Здоровий" },
                    { 2, "Реабілітований" },
                    { 3, "Потребує лікування" },
                    { 4, "Відновлюється" },
                    { 5, "Критичний" }
                });

            migrationBuilder.InsertData(
                table: "organisation_categories",
                columns: new[] { "id", "title" },
                values: new object[,]
                {
                    { 1, "Ветеринарна клініка" },
                    { 2, "Притулок" },
                    { 3, "Розплідник" }
                });

            migrationBuilder.InsertData(
                table: "pet_types",
                columns: new[] { "id", "title" },
                values: new object[,]
                {
                    { 1, "Кіт" },
                    { 2, "Собака" },
                    { 3, "Рептилія" },
                    { 4, "Інші" }
                });

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" },
                    { 3, "Organisation Owner" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_chats_organisation_id",
                table: "chats",
                column: "organisation_id");

            migrationBuilder.CreateIndex(
                name: "IX_chats_user_id",
                table: "chats",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_messages_chat_id",
                table: "messages",
                column: "chat_id");

            migrationBuilder.CreateIndex(
                name: "IX_messages_sender_id",
                table: "messages",
                column: "sender_id");

            migrationBuilder.CreateIndex(
                name: "IX_organisations_organisation_category_id",
                table: "organisations",
                column: "organisation_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_organisations_owner_id",
                table: "organisations",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_pet_cards_health_status_id",
                table: "pet_cards",
                column: "health_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_pet_cards_owner_id",
                table: "pet_cards",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_pet_cards_pet_type_id",
                table: "pet_cards",
                column: "pet_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_pet_photos_pet_card_id",
                table: "pet_photos",
                column: "pet_card_id");

            migrationBuilder.CreateIndex(
                name: "IX_pet_stories_author_id",
                table: "pet_stories",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_testimonials_author_id",
                table: "testimonials",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_testimonials_organisation_id",
                table: "testimonials",
                column: "organisation_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_favourites_pet_card_id",
                table: "user_favourites",
                column: "pet_card_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_favourites_user_id",
                table: "user_favourites",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_role_id",
                table: "users",
                column: "role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "pet_photos");

            migrationBuilder.DropTable(
                name: "pet_stories");

            migrationBuilder.DropTable(
                name: "testimonials");

            migrationBuilder.DropTable(
                name: "user_favourites");

            migrationBuilder.DropTable(
                name: "chats");

            migrationBuilder.DropTable(
                name: "pet_cards");

            migrationBuilder.DropTable(
                name: "organisations");

            migrationBuilder.DropTable(
                name: "health_statuses");

            migrationBuilder.DropTable(
                name: "pet_types");

            migrationBuilder.DropTable(
                name: "organisation_categories");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "user_roles");
        }
    }
}
