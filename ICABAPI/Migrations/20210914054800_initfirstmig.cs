using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ICABAPI.Migrations
{
    public partial class initfirstmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ADMIN_DECODER",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "ADMINCPLEXCOURSE",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "BANKBRANCH",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "BARCHECK_1",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "BARCHECK_2",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "BARCHECK_3",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "BARCHECK_41",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "BARCHECK_42",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "BARCHECK_51",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "BARCHECK_52",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "BARCHECK_61",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "BARCHECK_62",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "BARCHECK_63",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "BARCODE_ALLOT",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "BARCODE_ALLOT_EXPELLED_ARCHIVE",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "BARCODE_EDIT",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "BARCODEALLOTARCHIEVE",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "BARSEQ",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "BOARD_UNIVERSITY",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "CHEQUEBANK",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "CLASS_ATTENDANCE",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "CLASS_ATTENDANCE_ARCH",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "COMPINFO",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "CONVERSION_COURSE_MARKS",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "COUNTRY",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "CPLCOURSE",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "CPLDEPARTMENT",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "CPLSTUDENTCOURSE",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "CPLUNIVERSITY",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "DECODELOG",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "DECODER",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "DECODERUSER",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "DEMOCLASS",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "DEPOBANK",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "EARLIER_PASSED_61",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "EARLIER_PASSED_62",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "EARLIER_PASSED_63",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "EXAM_CENTRE",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "EXAM_FEE",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "EXAM_REG",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "EXAM_REG_ARCH",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "EXAM_REG_PASSED",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "EXAM_REG_PASSED_ARCH",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "EXAM_SAVEFLAG",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "EXAM_TIME_SCH",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "EXAM_TIME_SCH_ADMIT",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "EXAM_TIME_SCH_CURR",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "EXEMPTED_SUB",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "EXEMPTED_SUB_ARCH",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "EXSTUDENTFILE",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "FIRM_MAS2",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "FLAG_FOR_DECODE",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "FORM_FILLUP_AND_EXAM_RUNNING_STATUS",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "FORMFILLUPTABLEMOODLE",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "GRADE_DETAILS",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "GRADE_SYS",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "GRADE_SYS_CHANGED",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "GROUP_SUBJECT",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "HelloWorld",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "INCOMEHEAD",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "LOCATION",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "MARKS_ALLOT",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "MARKS_ALLOT_EDIT",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "MARKS_ALLOT_EXPELLED_ARCHIVE",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "MEMBER",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "MEMBER_ARCHIVE",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "MEMBERARCHIVE",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "MENUMASTER",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "MOU_STATUS_62",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "MOU_STATUS_63",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "NewTestModels",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "ODDSESSION_MOU_EXMP_SUB",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "PASSED_BY_EXEMPTION",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "PRINCIPAL",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "PRO_PARTNER",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "RefreshToken",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "REG_SUBJECT",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "REG_SUBJECT_ARCH",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "RESULT_BLOCK",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "RESULT_BLOCK_ARCH",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "RESULT_LOCK",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "ROOMWISEROLL",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "SEATPLAN",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "SESSION_INFO",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "SIGNATURE",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "SOFTWAREUSER",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "STU_CANCEL",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "STU_INFO_WEB_ADMIT",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "STU_REG1",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "STU_REG1_ARCH",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "STU_REG1_MOD_EXAM",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "STU_REG2",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "STU_REG2_ARCH",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "STUDENT_EXPELLED",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "STUDENT_EXPELLED_ARCH",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "STUDENT_OF_ICMAB_ACCA",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "STUDENT_REG_CANCELATION",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "STUDENT_TYPE",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "Students",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "STUTYPE23EXEMPSUB",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "SUBJECT",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "TAB_LEVEL_1",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "TAB_LEVEL_2",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "TAB_LEVEL_3",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "TAB_LEVEL_41",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "TAB_LEVEL_42",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "TAB_LEVEL_51",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "TAB_LEVEL_52",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "TAB_LEVEL_61",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "TAB_LEVEL_62",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "TAB_LEVEL_63",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "TBWEB_TIME_SCH",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "TEMP_CLASS_ATTENDANCE",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "TEMP_EARLIER_PASSED_61",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "TEMP_EARLIER_PASSED_62",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "TEMP_EARLIER_PASSED_63",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "TEMP_EXAM_REG",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "TEMP_EXAM_REG_PASSED",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "TEMP_EXEMPTED_SUB",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "TEMP_REG_SUBJECT",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "UNIVERSITYLIST_CPL",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "USERSEC",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "USERSUBMENU",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "WEB_RESULT",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "YEARINFO",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "ADMINCPLEXICABSUBJECTLIST",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "CPLSTUDENTICABSUBJECT",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "CPLSUBJECT",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "SET_EXMP_MOU",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "FIRM_MAS1",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "APPUSER",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "SUBMENU",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "CPLSTUDENTEXAMLEVEL",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "MAINMENU",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "CPLSTUDENTREGISTRATION",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "ADMINCPLEXDEPARTMENT",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "ADMINCPLEXUNIVERSITY",
                schema: "ICAB");

            migrationBuilder.DropTable(
                name: "ADMINCPLEXEXAMLEVELS",
                schema: "ICAB");

            migrationBuilder.DropSequence(
                name: "EXAM_CHANGE_ID",
                schema: "ICAB");

            migrationBuilder.DropSequence(
                name: "SEQ_EXAM_REGNO",
                schema: "ICAB");

            migrationBuilder.DropSequence(
                name: "SQ_SAMPLECLASS",
                schema: "ICAB");

            migrationBuilder.DropSequence(
                name: "SQ_TblStudent",
                schema: "ICAB");

            migrationBuilder.DropSequence(
                name: "SQ_TblUnknown",
                schema: "ICAB");

            migrationBuilder.DropSequence(
                name: "STUDENT_SLNO",
                schema: "ICAB");

            migrationBuilder.DropSequence(
                name: "STUREG_CHANGE_ID",
                schema: "ICAB");

            migrationBuilder.DropSequence(
                name: "TRACK_ID",
                schema: "ICAB");
        }
    }
}
