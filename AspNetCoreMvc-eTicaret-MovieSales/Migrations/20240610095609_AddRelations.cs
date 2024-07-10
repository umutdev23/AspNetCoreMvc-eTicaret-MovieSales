using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCoreMvc_eTicaret_MovieSales.Migrations
{
    /// <inheritdoc />
    public partial class AddRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MovieSales_CustomerId",
                table: "MovieSales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSaleDetails_MovieId",
                table: "MovieSaleDetails",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSaleDetails_MovieSaleId",
                table: "MovieSaleDetails",
                column: "MovieSaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_GenreId",
                table: "Movies",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieSaleDetails_MovieSales_MovieSaleId",
                table: "MovieSaleDetails",
                column: "MovieSaleId",
                principalTable: "MovieSales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieSaleDetails_Movies_MovieId",
                table: "MovieSaleDetails",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieSales_Customers_CustomerId",
                table: "MovieSales",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_GenreId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieSaleDetails_MovieSales_MovieSaleId",
                table: "MovieSaleDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieSaleDetails_Movies_MovieId",
                table: "MovieSaleDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieSales_Customers_CustomerId",
                table: "MovieSales");

            migrationBuilder.DropIndex(
                name: "IX_MovieSales_CustomerId",
                table: "MovieSales");

            migrationBuilder.DropIndex(
                name: "IX_MovieSaleDetails_MovieId",
                table: "MovieSaleDetails");

            migrationBuilder.DropIndex(
                name: "IX_MovieSaleDetails_MovieSaleId",
                table: "MovieSaleDetails");

            migrationBuilder.DropIndex(
                name: "IX_Movies_GenreId",
                table: "Movies");
        }
    }
}
