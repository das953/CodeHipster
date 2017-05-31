using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeHipser.Data.Migrations
{
    public partial class SeedSectionTypesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO SectionTypes (Name, ParentId) VALUES ('Theme', null)");
            migrationBuilder.Sql("INSERT INTO SectionTypes (Name, ParentId) VALUES ('Content', 1)");
            migrationBuilder.Sql("INSERT INTO SectionTypes (Name, ParentId) VALUES ('TextContent', 2)");
            migrationBuilder.Sql("INSERT INTO SectionTypes (Name, ParentId) VALUES ('VideoContent', 2)");
            migrationBuilder.Sql("INSERT INTO SectionTypes (Name, ParentId) VALUES ('Quiz', 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
