using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Commerce.Identity.Api.Migrations
{
    /// <inheritdoc />
    public partial class AdminUserRoleDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5c28b074-7e58-44cc-b227-d7ed1d527cce", "832ef1f6-9396-43e9-9256-ff5f4ee4fac1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5c28b074-7e58-44cc-b227-d7ed1d527cce", "832ef1f6-9396-43e9-9256-ff5f4ee4fac1" });
        }
    }
}
