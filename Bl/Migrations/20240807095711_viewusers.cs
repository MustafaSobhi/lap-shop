using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bl.Migrations
{
    /// <inheritdoc />
    public partial class viewusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create view VwUsers
            as
            SELECT dbo.AspNetUsers.Email, dbo.AspNetUsers.FirstName, dbo.AspNetUsers.LastName, dbo.AspNetUsers.Id, dbo.AspNetUserRoles.UserId, dbo.AspNetUserRoles.RoleId, dbo.AspNetRoles.Name
            FROM     dbo.AspNetUserRoles INNER JOIN
                              dbo.AspNetUsers ON dbo.AspNetUserRoles.UserId = dbo.AspNetUsers.Id INNER JOIN
                              dbo.AspNetRoles ON dbo.AspNetUserRoles.RoleId = dbo.AspNetRoles.Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
