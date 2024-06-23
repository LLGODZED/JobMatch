using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jobmatch.Data.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phonenumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobSeeker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSeeker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Requirment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<float>(type: "real", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Job_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 2, "Bussines" },
                    { 3, "Education" }
                });

            migrationBuilder.InsertData(
                table: "Job",
                columns: new[] { "Id", "Address", "CategoryId", "Description", "Image", "Requirment", "Salary", "Title" },
                values: new object[,]
                {
                    { 1, "Pham Van Bach,Hanoi", 1, "Bridge SE", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRPXnpGRiAcFBeh8s06rHjnJq2tZ5BNy8RtOg&s", "N2, university diploma, cv", 2000f, "FPT" },
                    { 2, "Pham Van Dong,Hanoi", 1, "Front-end", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTuhRMWw3eTOcHg3rg9eVfhFLaQsZdJzpSrw&s", "HTML,PHP,JAVA,C#", 800f, "Nissan tech" },
                    { 3, "Cam Hoi,Hanoi", 3, "Teacher Match", "https://iweb.tatthanh.com.vn/pic/1115/setting/Logo-Landingpage.png", "university diploma", 300f, "THPT HOA BINH LATROBE" },
                    { 4, "Phan Chu Trinh,Hanoi", 2, "accountantt", "https://media.loveitopcdn.com/3807/thumb/logo-techcombank-dongphucsongphu.png", "university diploma", 500f, "Techcombank" },
                    { 5, "Nguyen Trai, Hanoi", 2, "Software Developer", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ1yQ8f0k8eIj3F_gwXGF8Z4eTQMQbFqOj8uQ&s", "Bachelor's degree, 2+ years experience, portfolio", 2500f, "ABC Corp" },
                    { 6, "Le Duan, Ho Chi Minh City", 3, "System Analyst", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTO9kt8wCj9eQKmT5BoFmnOrT8VNNc9YF_T5g&s", "Bachelor's degree, analytical skills, 3+ years experience", 3000f, "XYZ Ltd" },
                    { 7, "Hai Ba Trung, Hanoi", 1, "Project Manager", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT5zH7U8tPnQGpQa6IeI8txzQcYjeNzlxXL8A&s", "PMP certification, 5+ years experience, leadership skills", 3500f, "DEF Solutions" },
                    { 8, "Tran Hung Dao, Da Nang", 1, "QA Engineer", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR4oQ3hzj5RlTruVmK_f5WZ8d9lryOgtl3tPw&s", "Bachelor's degree, 3+ years experience in QA, attention to detail", 2800f, "GHI Tech" },
                    { 9, "Nguyen Van Linh, Ho Chi Minh City", 1, "UI/UX Designer", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTc3k2_vDc4CJyHYhrUzSgM9cM1a_xr85DutA&s", "Bachelor's degree, portfolio of design projects, proficiency in design software", 2700f, "JKL Innovations" },
                    { 10, "Tran Quy Kien,Hanoi", 1, "Full Stack", "https://vtc.gov.vn/site/img/anhvtc.jpg", "HTML,PHP,JAVA,C#, SQL, No SQL", 800f, "VTC" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Job_CategoryId",
                table: "Job",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employer");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "JobSeeker");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
