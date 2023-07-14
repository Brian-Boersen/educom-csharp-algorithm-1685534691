using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Data.Sql;

namespace BornToMove.DAL.Migrations
{
    public partial class MoveData : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData
            (
                table: "Moves",
                columns: new[] { "Id", "Name", "Description", "SweatRate" },
                values: new object[] { 1, "Push up", "Ga horizontaal liggen op teentoppen en handen. Laat het lijf langzaam zakken tot de neus de grond bijna raakt. Duw het lijf terug nu omhoog tot de ellebogen bijna gestrekt zijn. Vervolgens weer laten zakken. Doe dit 20 keer zonder tussenpauzes", 3 }
            );

            migrationBuilder.InsertData
            (
                table: "Moves",
                columns: new[] { "Id", "Name", "Description", "SweatRate" },
                values: new object[] {2, "Planking", "Ga horizontaal liggen op teentoppen en onderarmen. Houdt deze positie 1 minuut vast", 3 }
            );
            
            migrationBuilder.InsertData
            (
                table: "Moves",
                columns: new[] { "Id", "Name", "Description", "SweatRate" },
                values: new object[] { 3, "Squat", "Ga staan met gestrekte armen. Zak door de knieën tot de billen de grond bijna raken. Ga weer volledig gestrekt staan. Herhaal dit 20 keer zonder tussenpauzes", 5 }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
