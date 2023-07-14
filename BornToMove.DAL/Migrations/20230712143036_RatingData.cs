using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.ComponentModel;

namespace BornToMove.DAL.Migrations
{
    public partial class RatingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData
            (
                table: "Ratings",
                columns: new[] { "Id","MoveId", "Rating" },
                values: new object[] {1,1,Convert.ToDouble(3)}
            );

            migrationBuilder.InsertData
            (
                table: "Ratings",
                columns: new[] { "Id", "MoveId", "Rating" },
                values: new object[] { 2, 2, Convert.ToDouble(3) }
            );

            migrationBuilder.InsertData
            (
                table: "Ratings",
                columns: new[] { "Id", "MoveId", "Rating" },
                values: new object[] { 3, 3, Convert.ToDouble(5)}
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
