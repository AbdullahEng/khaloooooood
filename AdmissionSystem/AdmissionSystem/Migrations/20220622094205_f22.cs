using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdmissionSystem.Migrations
{
    public partial class f22 : Migration
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
                    country_name = table.Column<string>(nullable: true)
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
                    Type_of_admission_eligibilty = table.Column<string>(nullable: true),
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
                    FK_facultyid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.id);
                    table.ForeignKey(
                        name: "FK_Department_Faculty_FK_facultyid",
                        column: x => x.FK_facultyid,
                        principalTable: "Faculty",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Persentage_count_for_each__country",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_statues_of_admission_eligibiltyid = table.Column<int>(nullable: true),
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
                        name: "FK_Persentage_count_for_each__country_Statues_of_admission_eligibilty_FK_statues_of_admission_eligibiltyid",
                        column: x => x.FK_statues_of_admission_eligibiltyid,
                        principalTable: "Statues_of_admission_eligibilty",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    high_school_certificate = table.Column<string>(nullable: true),
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
                    FK_statues_Of_Admission_Eligibiltyid = table.Column<int>(nullable: true),
                    Fk_departmentid = table.Column<int>(nullable: true),
                    Chair_count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Broken_Relationshib_Stat_Dep_Chair", x => x.id);
                    table.ForeignKey(
                        name: "FK_Broken_Relationshib_Stat_Dep_Chair_Statues_of_admission_eligibilty_FK_statues_Of_Admission_Eligibiltyid",
                        column: x => x.FK_statues_Of_Admission_Eligibiltyid,
                        principalTable: "Statues_of_admission_eligibilty",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Broken_Relationshib_Stat_Dep_Chair_Department_Fk_departmentid",
                        column: x => x.Fk_departmentid,
                        principalTable: "Department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Department_relation_Type",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_Departmentid = table.Column<int>(nullable: true),
                    FK_type_Of_High_School_Cirtificateid = table.Column<int>(nullable: true),
                    Minemum_of_Rate = table.Column<double>(nullable: false),
                    Rate_of_chaire_count = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department_relation_Type", x => x.id);
                    table.ForeignKey(
                        name: "FK_Department_relation_Type_Department_FK_Departmentid",
                        column: x => x.FK_Departmentid,
                        principalTable: "Department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Department_relation_Type_Type_of_high_school_Cirtificate_FK_type_Of_High_School_Cirtificateid",
                        column: x => x.FK_type_Of_High_School_Cirtificateid,
                        principalTable: "Type_of_high_school_Cirtificate",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accabtable_config",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_Statues_of_admission_eligibiltyid = table.Column<int>(nullable: true),
                    FK_studentId = table.Column<int>(nullable: false),
                    Accepted_Or_Not = table.Column<bool>(nullable: false),
                    Accepted_wish = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accabtable_config", x => x.id);
                    table.ForeignKey(
                        name: "FK_Accabtable_config_Statues_of_admission_eligibilty_FK_Statues_of_admission_eligibiltyid",
                        column: x => x.FK_Statues_of_admission_eligibiltyid,
                        principalTable: "Statues_of_admission_eligibilty",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                    old_rate = table.Column<int>(nullable: false),
                    new_rate = table.Column<int>(nullable: false),
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
                    The_Rate = table.Column<int>(nullable: false),
                    city_of_high_school_cirtificate = table.Column<string>(nullable: true),
                    date_of_high_school_cirtificate = table.Column<DateTime>(nullable: false),
                    Image_of_crtificat_URL = table.Column<string>(nullable: true),
                    check_recipt_image_URL = table.Column<string>(nullable: true),
                    LAnguge_of_the_addmintion = table.Column<string>(nullable: true),
                    Subscription_number = table.Column<string>(nullable: true),
                    course_number = table.Column<int>(nullable: false),
                    wish1id = table.Column<int>(nullable: true),
                    wish2id = table.Column<int>(nullable: true),
                    wish3id = table.Column<int>(nullable: true),
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
                        name: "FK_Admission_Eligibilty_Certificate_Department_relation_Type_wish1id",
                        column: x => x.wish1id,
                        principalTable: "Department_relation_Type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Admission_Eligibilty_Certificate_Department_relation_Type_wish2id",
                        column: x => x.wish2id,
                        principalTable: "Department_relation_Type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Admission_Eligibilty_Certificate_Department_relation_Type_wish3id",
                        column: x => x.wish3id,
                        principalTable: "Department_relation_Type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accabtable_config_FK_Statues_of_admission_eligibiltyid",
                table: "Accabtable_config",
                column: "FK_Statues_of_admission_eligibiltyid");

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
                name: "IX_Admission_Eligibilty_Certificate_wish1id",
                table: "Admission_Eligibilty_Certificate",
                column: "wish1id");

            migrationBuilder.CreateIndex(
                name: "IX_Admission_Eligibilty_Certificate_wish2id",
                table: "Admission_Eligibilty_Certificate",
                column: "wish2id");

            migrationBuilder.CreateIndex(
                name: "IX_Admission_Eligibilty_Certificate_wish3id",
                table: "Admission_Eligibilty_Certificate",
                column: "wish3id");

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
                name: "IX_Broken_Relationshib_Stat_Dep_Chair_FK_statues_Of_Admission_Eligibiltyid",
                table: "Broken_Relationshib_Stat_Dep_Chair",
                column: "FK_statues_Of_Admission_Eligibiltyid");

            migrationBuilder.CreateIndex(
                name: "IX_Broken_Relationshib_Stat_Dep_Chair_Fk_departmentid",
                table: "Broken_Relationshib_Stat_Dep_Chair",
                column: "Fk_departmentid");

            migrationBuilder.CreateIndex(
                name: "IX_Department_FK_facultyid",
                table: "Department",
                column: "FK_facultyid");

            migrationBuilder.CreateIndex(
                name: "IX_Department_relation_Type_FK_Departmentid",
                table: "Department_relation_Type",
                column: "FK_Departmentid");

            migrationBuilder.CreateIndex(
                name: "IX_Department_relation_Type_FK_type_Of_High_School_Cirtificateid",
                table: "Department_relation_Type",
                column: "FK_type_Of_High_School_Cirtificateid");

            migrationBuilder.CreateIndex(
                name: "IX_Persentage_count_for_each__country_FK_countryId",
                table: "Persentage_count_for_each__country",
                column: "FK_countryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persentage_count_for_each__country_FK_statues_of_admission_eligibiltyid",
                table: "Persentage_count_for_each__country",
                column: "FK_statues_of_admission_eligibiltyid");

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
