using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdmissionSystem.Migrations
{
    public partial class ff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    TheIDnumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    country_name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    Nick_Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone_Number = table.Column<int>(nullable: false),
                    The_ID_Number = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Birth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Faculty_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Statues_of_admission_eligibilty",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type_of_admission_eligibilty = table.Column<string>(maxLength: 15, nullable: false),
                    Begaining_date_of_the_process = table.Column<DateTime>(nullable: false),
                    semester_no = table.Column<int>(nullable: false),
                    semester_Date = table.Column<DateTime>(nullable: false),
                    Number_Student = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statues_of_admission_eligibilty", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Type_of_high_school_Cirtificate",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_of_high_school_Cirtificate", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    specialization_name = table.Column<string>(nullable: true),
                    FK_facultyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.id);
                    table.ForeignKey(
                        name: "FK_Department_Faculty_FK_facultyId",
                        column: x => x.FK_facultyId,
                        principalTable: "Faculty",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persentage_count_for_each__country",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_statues_of_admission_eligibiltyId = table.Column<int>(nullable: false),
                    FK_countryId = table.Column<int>(nullable: false),
                    Rate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persentage_count_for_each__country", x => x.id);
                    table.ForeignKey(
                        name: "FK_Persentage_count_for_each__country_Country_FK_countryId",
                        column: x => x.FK_countryId,
                        principalTable: "Country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persentage_count_for_each__country_Statues_of_admission_eligibilty_FK_statues_of_admission_eligibiltyId",
                        column: x => x.FK_statues_of_admission_eligibiltyId,
                        principalTable: "Statues_of_admission_eligibilty",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    high_school_certificate = table.Column<string>(nullable: true),
                    Fk_Cirtificate_cityId = table.Column<int>(nullable: false),
                    Cirtificate_cityid = table.Column<int>(nullable: true),
                    First_Name_AR = table.Column<string>(nullable: true),
                    Father_Name_AR = table.Column<string>(nullable: true),
                    Grandfather_Name_AR = table.Column<string>(nullable: true),
                    Mother_Name_AR = table.Column<string>(nullable: true),
                    First_Name_EN = table.Column<string>(nullable: true),
                    Father_Name_EN = table.Column<string>(nullable: true),
                    Grandfather_Name_EN = table.Column<string>(nullable: true),
                    Mother_Name_EN = table.Column<string>(nullable: true),
                    Nick_Name = table.Column<string>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    Birth = table.Column<DateTime>(nullable: false),
                    Marital_status = table.Column<string>(nullable: true),
                    Civil_Registriation_City = table.Column<string>(nullable: true),
                    Civil_Registrition_No = table.Column<int>(nullable: false),
                    Passport_No = table.Column<int>(nullable: false),
                    Identity_No = table.Column<int>(nullable: false),
                    Full_Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Current_Address = table.Column<string>(nullable: true),
                    Mobile_Phone = table.Column<int>(nullable: false),
                    Home_s_Phone = table.Column<int>(nullable: false),
                    Identity_front_image = table.Column<string>(nullable: true),
                    Identity_back_image = table.Column<string>(nullable: true),
                    Statues_Of_Admission_Eligibiltyid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Country_Cirtificate_cityid",
                        column: x => x.Cirtificate_cityid,
                        principalTable: "Country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Statues_of_admission_eligibilty_Statues_Of_Admission_Eligibiltyid",
                        column: x => x.Statues_Of_Admission_Eligibiltyid,
                        principalTable: "Statues_of_admission_eligibilty",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Broken_Relationshib_Stat_Dep_Chair",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_statues_Of_Admission_EligibiltyId = table.Column<int>(nullable: false),
                    Fk_departmentId = table.Column<int>(nullable: false),
                    Chair_count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Broken_Relationshib_Stat_Dep_Chair", x => x.id);
                    table.ForeignKey(
                        name: "FK_Broken_Relationshib_Stat_Dep_Chair_Statues_of_admission_eligibilty_FK_statues_Of_Admission_EligibiltyId",
                        column: x => x.FK_statues_Of_Admission_EligibiltyId,
                        principalTable: "Statues_of_admission_eligibilty",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Broken_Relationshib_Stat_Dep_Chair_Department_Fk_departmentId",
                        column: x => x.Fk_departmentId,
                        principalTable: "Department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Department_relation_Type",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_DepartmentId = table.Column<int>(nullable: false),
                    FK_type_Of_High_School_CirtificateId = table.Column<int>(nullable: false),
                    Minemum_of_Rate = table.Column<double>(nullable: false),
                    Rate_of_chaire_count = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department_relation_Type", x => x.id);
                    table.ForeignKey(
                        name: "FK_Department_relation_Type_Department_FK_DepartmentId",
                        column: x => x.FK_DepartmentId,
                        principalTable: "Department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Department_relation_Type_Type_of_high_school_Cirtificate_FK_type_Of_High_School_CirtificateId",
                        column: x => x.FK_type_Of_High_School_CirtificateId,
                        principalTable: "Type_of_high_school_Cirtificate",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accabtable_config",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_Statues_of_admission_eligibiltyId = table.Column<int>(nullable: false),
                    FK_studentId = table.Column<int>(nullable: false),
                    Accepted_Or_Not = table.Column<bool>(nullable: false),
                    Accepted_wish = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accabtable_config", x => x.id);
                    table.ForeignKey(
                        name: "FK_Accabtable_config_Statues_of_admission_eligibilty_FK_Statues_of_admission_eligibiltyId",
                        column: x => x.FK_Statues_of_admission_eligibiltyId,
                        principalTable: "Statues_of_admission_eligibilty",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accabtable_config_Student_FK_studentId",
                        column: x => x.FK_studentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Statues_Of_Student",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date_of_Acshiving = table.Column<DateTime>(nullable: false),
                    Checked_recipet = table.Column<bool>(nullable: false),
                    Checked_Identity = table.Column<bool>(nullable: false),
                    Checked_city_certificate = table.Column<bool>(nullable: false),
                    Checked_Rate = table.Column<bool>(nullable: false),
                    FK_Student_InfoId = table.Column<int>(nullable: false),
                    FK_Employee_Infoid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statues_Of_Student", x => x.id);
                    table.ForeignKey(
                        name: "FK_Statues_Of_Student_Employee_FK_Employee_Infoid",
                        column: x => x.FK_Employee_Infoid,
                        principalTable: "Employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Statues_Of_Student_Student_FK_Student_InfoId",
                        column: x => x.FK_Student_InfoId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tracking_Rate",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    old_rate = table.Column<float>(nullable: false),
                    new_rate = table.Column<float>(nullable: false),
                    old_country = table.Column<string>(nullable: true),
                    new_country = table.Column<string>(nullable: true),
                    old_typeofcertificate = table.Column<string>(nullable: true),
                    new_typeofcertificate = table.Column<string>(nullable: true),
                    Date_Of_Modification = table.Column<DateTime>(nullable: false),
                    FK_Student_InfoId = table.Column<int>(nullable: false),
                    FK_Employee_Infoid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracking_Rate", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tracking_Rate_Employee_FK_Employee_Infoid",
                        column: x => x.FK_Employee_Infoid,
                        principalTable: "Employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tracking_Rate_Student_FK_Student_InfoId",
                        column: x => x.FK_Student_InfoId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admission_Eligibilty_Certificate",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    The_Rate = table.Column<float>(nullable: false),
                    city_of_high_school_cirtificate = table.Column<string>(nullable: true),
                    date_of_high_school_cirtificate = table.Column<DateTime>(nullable: false),
                    Image_of_crtificat_URL = table.Column<string>(nullable: true),
                    check_recipt_image_URL = table.Column<string>(nullable: true),
                    LAnguge_of_the_addmintion = table.Column<string>(nullable: true),
                    Subscription_number = table.Column<string>(nullable: true),
                    course_number = table.Column<int>(nullable: false),
                    wish1ID = table.Column<int>(nullable: true),
                    wish2ID = table.Column<int>(nullable: true),
                    wish3ID = table.Column<int>(nullable: true),
                    FK_studentId = table.Column<int>(nullable: false),
                    FK_Type_of_high_school_Cirtificateid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admission_Eligibilty_Certificate", x => x.id);
                    table.ForeignKey(
                        name: "FK_Admission_Eligibilty_Certificate_Type_of_high_school_Cirtificate_FK_Type_of_high_school_Cirtificateid",
                        column: x => x.FK_Type_of_high_school_Cirtificateid,
                        principalTable: "Type_of_high_school_Cirtificate",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Admission_Eligibilty_Certificate_Student_FK_studentId",
                        column: x => x.FK_studentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admission_Eligibilty_Certificate_Department_relation_Type_wish1ID",
                        column: x => x.wish1ID,
                        principalTable: "Department_relation_Type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Admission_Eligibilty_Certificate_Department_relation_Type_wish2ID",
                        column: x => x.wish2ID,
                        principalTable: "Department_relation_Type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Admission_Eligibilty_Certificate_Department_relation_Type_wish3ID",
                        column: x => x.wish3ID,
                        principalTable: "Department_relation_Type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "id", "country_name" },
                values: new object[,]
                {
                    { 1, "سوريا" },
                    { 2, "الإمارات" },
                    { 3, "الكويت" },
                    { 4, "السعودية" }
                });

            migrationBuilder.InsertData(
                table: "Faculty",
                columns: new[] { "id", "Faculty_name" },
                values: new object[,]
                {
                    { 1, "كلية طبية" },
                    { 2, "كلية الهندسة المدنية والمعمارية" },
                    { 3, "كلية الهندسة" },
                    { 4, "كليةالأعمال والإدارة" },
                    { 5, "كليةالفنون والإعلام" },
                    { 6, "كليةالحقوق والعلوم الإنسانية" }
                });

            migrationBuilder.InsertData(
                table: "Type_of_high_school_Cirtificate",
                columns: new[] { "id", "type" },
                values: new object[,]
                {
                    { 1, "علمي" },
                    { 2, "أدبي" },
                    { 3, "تجارة" },
                    { 4, "مهني حاسوب" },
                    { 5, "مهني فنون" }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "id", "FK_facultyId", "specialization_name" },
                values: new object[,]
                {
                    { 1, 1, "الطب" },
                    { 2, 1, "طب الأسنان" },
                    { 3, 1, "الصيدلة" },
                    { 4, 2, "الهندسة المعمارية" },
                    { 5, 2, "الهندسة المدنية" },
                    { 6, 3, "هندسة تقانة المعلومات" },
                    { 7, 3, "هندسة الميكاترونيكس" },
                    { 8, 4, "إدارة" },
                    { 9, 4, "تمويل بنوك" },
                    { 10, 5, "التصميم الداخلي" },
                    { 11, 5, "التصميم الغرافيكي" },
                    { 12, 6, "الحقوق" }
                });

            migrationBuilder.InsertData(
                table: "Department_relation_Type",
                columns: new[] { "id", "FK_DepartmentId", "FK_type_Of_High_School_CirtificateId", "Minemum_of_Rate", "Rate_of_chaire_count" },
                values: new object[,]
                {
                    { 1, 1, 1, 83.0, 0.0 },
                    { 19, 11, 1, 56.0, 0.0 },
                    { 18, 10, 5, 63.0, 0.0 },
                    { 17, 10, 2, 56.0, 0.0 },
                    { 16, 10, 1, 56.0, 0.0 },
                    { 15, 9, 3, 63.0, 0.0 },
                    { 14, 9, 2, 56.0, 0.0 },
                    { 13, 9, 1, 56.0, 0.0 },
                    { 12, 8, 3, 63.0, 0.0 },
                    { 20, 11, 2, 56.0, 0.0 },
                    { 11, 8, 2, 56.0, 0.0 },
                    { 9, 7, 4, 83.0, 0.0 },
                    { 8, 7, 1, 68.0, 0.0 },
                    { 7, 6, 4, 83.0, 0.0 },
                    { 6, 6, 1, 68.0, 0.0 },
                    { 5, 5, 1, 68.0, 0.0 },
                    { 4, 4, 1, 68.0, 0.0 },
                    { 3, 3, 1, 78.0, 0.0 },
                    { 2, 2, 1, 78.0, 0.0 },
                    { 10, 8, 1, 56.0, 0.0 },
                    { 21, 11, 5, 63.0, 0.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accabtable_config_FK_Statues_of_admission_eligibiltyId",
                table: "Accabtable_config",
                column: "FK_Statues_of_admission_eligibiltyId");

            migrationBuilder.CreateIndex(
                name: "IX_Accabtable_config_FK_studentId",
                table: "Accabtable_config",
                column: "FK_studentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admission_Eligibilty_Certificate_FK_Type_of_high_school_Cirtificateid",
                table: "Admission_Eligibilty_Certificate",
                column: "FK_Type_of_high_school_Cirtificateid");

            migrationBuilder.CreateIndex(
                name: "IX_Admission_Eligibilty_Certificate_FK_studentId",
                table: "Admission_Eligibilty_Certificate",
                column: "FK_studentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admission_Eligibilty_Certificate_wish1ID",
                table: "Admission_Eligibilty_Certificate",
                column: "wish1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Admission_Eligibilty_Certificate_wish2ID",
                table: "Admission_Eligibilty_Certificate",
                column: "wish2ID");

            migrationBuilder.CreateIndex(
                name: "IX_Admission_Eligibilty_Certificate_wish3ID",
                table: "Admission_Eligibilty_Certificate",
                column: "wish3ID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Broken_Relationshib_Stat_Dep_Chair_FK_statues_Of_Admission_EligibiltyId",
                table: "Broken_Relationshib_Stat_Dep_Chair",
                column: "FK_statues_Of_Admission_EligibiltyId");

            migrationBuilder.CreateIndex(
                name: "IX_Broken_Relationshib_Stat_Dep_Chair_Fk_departmentId",
                table: "Broken_Relationshib_Stat_Dep_Chair",
                column: "Fk_departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_FK_facultyId",
                table: "Department",
                column: "FK_facultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_relation_Type_FK_DepartmentId",
                table: "Department_relation_Type",
                column: "FK_DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_relation_Type_FK_type_Of_High_School_CirtificateId",
                table: "Department_relation_Type",
                column: "FK_type_Of_High_School_CirtificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Persentage_count_for_each__country_FK_countryId",
                table: "Persentage_count_for_each__country",
                column: "FK_countryId");

            migrationBuilder.CreateIndex(
                name: "IX_Persentage_count_for_each__country_FK_statues_of_admission_eligibiltyId",
                table: "Persentage_count_for_each__country",
                column: "FK_statues_of_admission_eligibiltyId");

            migrationBuilder.CreateIndex(
                name: "IX_Statues_Of_Student_FK_Employee_Infoid",
                table: "Statues_Of_Student",
                column: "FK_Employee_Infoid");

            migrationBuilder.CreateIndex(
                name: "IX_Statues_Of_Student_FK_Student_InfoId",
                table: "Statues_Of_Student",
                column: "FK_Student_InfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_Cirtificate_cityid",
                table: "Student",
                column: "Cirtificate_cityid");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Statues_Of_Admission_Eligibiltyid",
                table: "Student",
                column: "Statues_Of_Admission_Eligibiltyid");

            migrationBuilder.CreateIndex(
                name: "IX_Tracking_Rate_FK_Employee_Infoid",
                table: "Tracking_Rate",
                column: "FK_Employee_Infoid");

            migrationBuilder.CreateIndex(
                name: "IX_Tracking_Rate_FK_Student_InfoId",
                table: "Tracking_Rate",
                column: "FK_Student_InfoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accabtable_config");

            migrationBuilder.DropTable(
                name: "Admission_Eligibilty_Certificate");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Broken_Relationshib_Stat_Dep_Chair");

            migrationBuilder.DropTable(
                name: "Persentage_count_for_each__country");

            migrationBuilder.DropTable(
                name: "Statues_Of_Student");

            migrationBuilder.DropTable(
                name: "Tracking_Rate");

            migrationBuilder.DropTable(
                name: "Department_relation_Type");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Type_of_high_school_Cirtificate");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Statues_of_admission_eligibilty");

            migrationBuilder.DropTable(
                name: "Faculty");
        }
    }
}
