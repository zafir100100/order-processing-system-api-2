using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
#nullable disable
namespace ICABAPI.Models
{
    public partial class ModelContext : IdentityDbContext<ApplicationUser>
    {
        public ModelContext() { }
        public ModelContext(DbContextOptions<ModelContext> options) : base(options) { }
        public virtual DbSet<CplSubmission> CplSubmissions
        {
            get;
            set;
        }
        public virtual DbSet<CplSubmissionAcademicDetail> CplSubmissionAcademicDetails
        {
            get;
            set;
        }
        public virtual DbSet<CplSubmissionFilesCommon> CplSubmissionFilesCommons
        {
            get;
            set;
        }
        public virtual DbSet<CplCourse> CplCourses
        {
            get;
            set;
        }
        public virtual DbSet<CplDepartment> CplDepartments
        {
            get;
            set;
        }
        public virtual DbSet<CplSubjectMapping> CplSubjectMappings
        {
            get;
            set;
        }
        public virtual DbSet<CplUniversity> CplUniversities
        {
            get;
            set;
        }
        public virtual DbSet<SendMoodleCsv> SendMoodleCsvs
        {
            get;
            set;
        }
        public virtual DbSet<MoodleCohort> MoodleCohorts
        {
            get;
            set;
        }
        public virtual DbSet<VwTabulation> VwTabulations
        {
            get;
            set;
        }
        public virtual DbSet<Bankbranch> Bankbranches
        {
            get;
            set;
        }
        public virtual DbSet<FormFillupAndExamRunningStatus> FormFillupAndExamRunningStatuses
        {
            get;
            set;
        }
        public virtual DbSet<ExamFee> ExamFees
        {
            get;
            set;
        }
        public virtual DbSet<TempEarlierPassed61> TempEarlierPassed61s
        {
            get;
            set;
        }
        public virtual DbSet<TempEarlierPassed62> TempEarlierPassed62s
        {
            get;
            set;
        }
        public virtual DbSet<TempEarlierPassed63> TempEarlierPassed63s
        {
            get;
            set;
        }
        public virtual DbSet<TempExamRegPassed> TempExamRegPasseds
        {
            get;
            set;
        }
        public virtual DbSet<TempExemptedSub> TempExemptedSubs
        {
            get;
            set;
        }
        public virtual DbSet<TempRegSubject> TempRegSubjects
        {
            get;
            set;
        }
        public virtual DbSet<TempClassAttendance> TempClassAttendances
        {
            get;
            set;
        }
        public virtual DbSet<EarlierPassed61> EarlierPassed61s
        {
            get;
            set;
        }
        public virtual DbSet<EarlierPassed62> EarlierPassed62s
        {
            get;
            set;
        }
        public virtual DbSet<EarlierPassed63> EarlierPassed63s
        {
            get;
            set;
        }
        public virtual DbSet<AppUser> APPUSER
        {
            get;
            set;
        }
        public virtual DbSet<NewTestModel> NewTestModels
        {
            get;
            set;
        }
        public virtual DbSet<Barcheck1> Barcheck1s
        {
            get;
            set;
        }
        public virtual DbSet<Barcheck2> Barcheck2s
        {
            get;
            set;
        }
        public virtual DbSet<Barcheck3> Barcheck3s
        {
            get;
            set;
        }
        public virtual DbSet<Barcheck41> Barcheck41s
        {
            get;
            set;
        }
        public virtual DbSet<Barcheck42> Barcheck42s
        {
            get;
            set;
        }
        public virtual DbSet<Barcheck51> Barcheck51s
        {
            get;
            set;
        }
        public virtual DbSet<Barcheck52> Barcheck52s
        {
            get;
            set;
        }
        public virtual DbSet<Barcheck61> Barcheck61s
        {
            get;
            set;
        }
        public virtual DbSet<Barcheck62> Barcheck62s
        {
            get;
            set;
        }
        public virtual DbSet<Barcheck63> Barcheck63s
        {
            get;
            set;
        }
        public virtual DbSet<BarcodeAllot> BarcodeAllots
        {
            get;
            set;
        }
        public virtual DbSet<BarcodeAllotExpelledArchive> BarcodeAllotExpelledArchives
        {
            get;
            set;
        }
        public virtual DbSet<BarcodeEdit> BarcodeEdits
        {
            get;
            set;
        }
        public virtual DbSet<Barseq> Barseqs
        {
            get;
            set;
        }
        public virtual DbSet<BoardUniversity> BoardUniversities
        {
            get;
            set;
        }
        public virtual DbSet<Chequebank> Chequebanks
        {
            get;
            set;
        }
        public virtual DbSet<ClassAttendance> ClassAttendances
        {
            get;
            set;
        }
        public virtual DbSet<ClassAttendanceArch> ClassAttendanceArches
        {
            get;
            set;
        }
        public virtual DbSet<Compinfo> Compinfos
        {
            get;
            set;
        }
        public virtual DbSet<ConversionCourseMark> ConversionCourseMarks
        {
            get;
            set;
        }
        public virtual DbSet<Country> Countries
        {
            get;
            set;
        }
        public virtual DbSet<Decodelog> Decodelogs
        {
            get;
            set;
        }
        public virtual DbSet<Decoder> Decoders
        {
            get;
            set;
        }
        public virtual DbSet<Democlass> Democlasses
        {
            get;
            set;
        }
        public virtual DbSet<Depobank> Depobanks
        {
            get;
            set;
        }
        public virtual DbSet<ExamCentre> ExamCentres
        {
            get;
            set;
        }
        public virtual DbSet<VenueBuilding> VenueBuildings
        {
            get;
            set;
        }
        public virtual DbSet<ExamReg> ExamRegs
        {
            get;
            set;
        }
        public virtual DbSet<ExamRegArch> ExamRegArches
        {
            get;
            set;
        }
        public virtual DbSet<ExamRegPassed> ExamRegPasseds
        {
            get;
            set;
        }
        public virtual DbSet<ExamRegPassedArch> ExamRegPassedArches
        {
            get;
            set;
        }
        public virtual DbSet<ExamSaveflag> ExamSaveflags
        {
            get;
            set;
        }
        public virtual DbSet<ExamTimeSch> ExamTimeSches
        {
            get;
            set;
        }
        public virtual DbSet<ExamTimeSchAdmit> ExamTimeSchAdmits
        {
            get;
            set;
        }
        public virtual DbSet<ExamTimeSchCurr> ExamTimeSchCurrs
        {
            get;
            set;
        }
        public virtual DbSet<ExemptedSub> ExemptedSubs
        {
            get;
            set;
        }
        public virtual DbSet<ExemptedSubArch> ExemptedSubArches
        {
            get;
            set;
        }
        public virtual DbSet<FirmMas1> FirmMas1s
        {
            get;
            set;
        }
        public virtual DbSet<FirmMas2> FirmMas2s
        {
            get;
            set;
        }
        public virtual DbSet<FlagForDecode> FlagForDecodes
        {
            get;
            set;
        }
        public virtual DbSet<GradeDetail> GradeDetails
        {
            get;
            set;
        }
        public virtual DbSet<GradeSy> GradeSys
        {
            get;
            set;
        }
        public virtual DbSet<GradeSysChanged> GradeSysChangeds
        {
            get;
            set;
        }
        public virtual DbSet<GroupSubject> GroupSubjects
        {
            get;
            set;
        }
        public virtual DbSet<HelloWorld> HelloWorlds
        {
            get;
            set;
        }
        public virtual DbSet<Incomehead> Incomeheads
        {
            get;
            set;
        }
        public virtual DbSet<Location> Locations
        {
            get;
            set;
        }
        public virtual DbSet<MainMi> MainMis
        {
            get;
            set;
        }
        public virtual DbSet<MarksAllot> MarksAllots
        {
            get;
            set;
        }
        public virtual DbSet<MarksAllotEdit> MarksAllotEdits
        {
            get;
            set;
        }
        public virtual DbSet<MarksAllotExpelledArchive> MarksAllotExpelledArchives
        {
            get;
            set;
        }
        public virtual DbSet<MarksEditArchive> MarksEditArchives
        {
            get;
            set;
        }
        public virtual DbSet<Member> Members
        {
            get;
            set;
        }
        public virtual DbSet<MemberArchive1> MemberArchives1
        {
            get;
            set;
        }
        public virtual DbSet<Memberarchive> Memberarchives
        {
            get;
            set;
        }
        public virtual DbSet<MouStatus62> MouStatus62s
        {
            get;
            set;
        }
        public virtual DbSet<MouStatus63> MouStatus63s
        {
            get;
            set;
        }
        public virtual DbSet<OddsessionMouExmpSub> OddsessionMouExmpSubs
        {
            get;
            set;
        }
        public virtual DbSet<PassedByExemption> PassedByExemptions
        {
            get;
            set;
        }
        public virtual DbSet<Prin> Prins
        {
            get;
            set;
        }
        public virtual DbSet<Principal> Principals
        {
            get;
            set;
        }
        public virtual DbSet<ProPartner> ProPartners
        {
            get;
            set;
        }
        public virtual DbSet<RegSubject> RegSubjects
        {
            get;
            set;
        }
        public virtual DbSet<RegSubjectArch> RegSubjectArches
        {
            get;
            set;
        }
        public virtual DbSet<ResultBlock> ResultBlocks
        {
            get;
            set;
        }
        public virtual DbSet<ResultBlockArch> ResultBlockArches
        {
            get;
            set;
        }
        public virtual DbSet<ResultLock> ResultLocks
        {
            get;
            set;
        }
        public virtual DbSet<Roomwiseroll> Roomwiserolls
        {
            get;
            set;
        }
        public virtual DbSet<Seatplan> Seatplans
        {
            get;
            set;
        }
        public virtual DbSet<SessionInfo> SessionInfos
        {
            get;
            set;
        }
        public virtual DbSet<SetExmpMou> SetExmpMous
        {
            get;
            set;
        }
        public virtual DbSet<Softwareuser> Softwareusers
        {
            get;
            set;
        }
        public virtual DbSet<StuInfoWebAdmit> StuInfoWebAdmits
        {
            get;
            set;
        }
        public virtual DbSet<StuReg1> StuReg1s
        {
            get;
            set;
        }
        public virtual DbSet<StuReg1Arch> StuReg1Arches
        {
            get;
            set;
        }
        public virtual DbSet<StuReg1ModExam> StuReg1ModExams
        {
            get;
            set;
        }
        public virtual DbSet<StuReg2> StuReg2s
        {
            get;
            set;
        }
        public virtual DbSet<StuReg2Arch> StuReg2Arches
        {
            get;
            set;
        }
        public virtual DbSet<StuCancel> StuCancels
        {
            get;
            set;
        }
        public virtual DbSet<Student> Students
        {
            get;
            set;
        }
        public virtual DbSet<StudentExpelled> StudentExpelleds
        {
            get;
            set;
        }
        public virtual DbSet<StudentExpelledArch> StudentExpelledArches
        {
            get;
            set;
        }
        public virtual DbSet<StudentOfIcmabAcca> StudentOfIcmabAccas
        {
            get;
            set;
        }
        public virtual DbSet<StudentRegCancelation> StudentRegCancelations
        {
            get;
            set;
        }
        public virtual DbSet<StudentType> StudentTypes
        {
            get;
            set;
        }
        public virtual DbSet<Stutype23exempsub> Stutype23exempsubs
        {
            get;
            set;
        }
        public virtual DbSet<Subject> Subjects
        {
            get;
            set;
        }
        public virtual DbSet<TabLevel1> TabLevel1s
        {
            get;
            set;
        }
        public virtual DbSet<TabLevel2> TabLevel2s
        {
            get;
            set;
        }
        public virtual DbSet<TabLevel3> TabLevel3s
        {
            get;
            set;
        }
        public virtual DbSet<TabLevel41> TabLevel41s
        {
            get;
            set;
        }
        public virtual DbSet<TabLevel42> TabLevel42s
        {
            get;
            set;
        }
        public virtual DbSet<TabLevel51> TabLevel51s
        {
            get;
            set;
        }
        public virtual DbSet<TabLevel52> TabLevel52s
        {
            get;
            set;
        }
        public virtual DbSet<TabLevel61> TabLevel61s
        {
            get;
            set;
        }
        public virtual DbSet<TabLevel62> TabLevel62s
        {
            get;
            set;
        }
        public virtual DbSet<TabLevel63> TabLevel63s
        {
            get;
            set;
        }
        public virtual DbSet<TbwebTimeSch> TbwebTimeSches
        {
            get;
            set;
        }
        public virtual DbSet<TempExamReg> TempExamRegs
        {
            get;
            set;
        }
        public virtual DbSet<TimeSch> TimeSches
        {
            get;
            set;
        }
        public virtual DbSet<Usersec> Usersecs
        {
            get;
            set;
        }
        public virtual DbSet<VwAbsent> VwAbsents
        {
            get;
            set;
        }
        public virtual DbSet<VwBarAlloted> VwBarAlloteds
        {
            get;
            set;
        }
        public virtual DbSet<VwExamReg> VwExamRegs
        {
            get;
            set;
        }
        public virtual DbSet<VwExempsub23> VwExempsub23s
        {
            get;
            set;
        }
        public virtual DbSet<VwExemptedSub> VwExemptedSubs
        {
            get;
            set;
        }
        public virtual DbSet<VwMarksfinal> VwMarksfinals
        {
            get;
            set;
        }
        public virtual DbSet<VwMouSuccessList> VwMouSuccessLists
        {
            get;
            set;
        }
        public virtual DbSet<VwPrincipal> VwPrincipals
        {
            get;
            set;
        }
        public virtual DbSet<VwRollAlloted> VwRollAlloteds
        {
            get;
            set;
        }
        public virtual DbSet<VwSearch> VwSearches
        {
            get;
            set;
        }
        public virtual DbSet<VwSessionPassCount> VwSessionPassCounts
        {
            get;
            set;
        }
        public virtual DbSet<VwSessionPassCountBack> VwSessionPassCountBacks
        {
            get;
            set;
        }
        public virtual DbSet<VwStuReg> VwStuRegs
        {
            get;
            set;
        }
        public virtual DbSet<VwUnsuccessList> VwUnsuccessLists
        {
            get;
            set;
        }
        public virtual DbSet<WebResult> WebResults
        {
            get;
            set;
        }
        public virtual DbSet<Yearinfo> Yearinfos
        {
            get;
            set;
        }
        public virtual DbSet<BarCodeAllot_Archieve> BarCodeAllot_Archieves
        {
            get;
            set;
        }
        public virtual DbSet<Signature> Signatures
        {
            get;
            set;
        }
        public virtual DbSet<MenuMaster> MenuMasters
        {
            get;
            set;
        }
        public virtual DbSet<MainMenu> MainMenus
        {
            get;
            set;
        }
        public virtual DbSet<SubMenu> SubMenus
        {
            get;
            set;
        }
        public virtual DbSet<StudentMainMenu> StudentMainMenus
        {
            get;
            set;
        }
        public virtual DbSet<UserSubMenu> UserSubMenus
        {
            get;
            set;
        }
        public virtual DbSet<DecoderUser> DecoderUsers
        {
            get;
            set;
        }
        public virtual DbSet<FormFillUptableForMoodle> FormFillUptableForMoodles
        {
            get;
            set;
        }
        public virtual DbSet<OnlinePaymentDetail> OnlinePaymentDetails
        {
            get;
            set;
        }
        public virtual DbSet<CplOnlinePaymentDetail> CplOnlinePaymentDetails
        {
            get;
            set;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("ICAB").HasAnnotation("Relational:Collation", "USING_NLS_COMP");
            modelBuilder.Entity<CplSubmission>(entity => {
                entity.HasKey(e => e.SubmissionId).HasName("CPL_SUBMISSION_PK");
                entity.ToTable("CPL_SUBMISSION");
                entity.Property(e => e.SubmissionId).HasColumnType("NUMBER(38)").HasColumnName("SUBMISSION_ID");
                entity.Property(e => e.ExamLevel).HasColumnType("NUMBER(38)").HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.Id).HasColumnType("NUMBER").ValueGeneratedOnAdd().HasColumnName("ID");
                entity.Property(e => e.IsCplApproved).HasColumnType("NUMBER(38)").HasColumnName("IS_CPL_APPROVED").HasDefaultValueSql("0");
                entity.Property(e => e.ObtainedCgpa).HasColumnType("FLOAT").HasColumnName("OBTAINED_CGPA");
                entity.Property(e => e.RegNo).HasColumnType("NUMBER(38)").HasColumnName("REG_NO");
                entity.Property(e => e.MonthId).HasColumnType("NUMBER(38)").HasColumnName("MONTH_ID");
                entity.Property(e => e.SessionYear).HasColumnType("NUMBER(38)").HasColumnName("SESSION_YEAR");
                entity.Property(e => e.SubmissionDate).HasColumnType("DATE").HasColumnName("SUBMISSION_DATE");
            });
            modelBuilder.Entity<CplSubmissionAcademicDetail>(entity => {
                entity.HasKey(e => new {
                    e.SubmissionId,
                    e.CplUniversityId,
                    e.CplDepartmentId,
                    e.CplCourseId,
                    e.CplIcabSubjectId
                }).HasName("CPL_SUBMISSION_ACADEMIC_DETAILS_PK");
                entity.ToTable("CPL_SUBMISSION_ACADEMIC_DETAILS");
                entity.Property(e => e.SubmissionId).HasColumnType("NUMBER(38)").HasColumnName("SUBMISSION_ID");
                entity.Property(e => e.CplUniversityId).HasColumnType("NUMBER(38)").HasColumnName("CPL_UNIVERSITY_ID");
                entity.Property(e => e.CplDepartmentId).HasColumnType("NUMBER(38)").HasColumnName("CPL_DEPARTMENT_ID");
                entity.Property(e => e.CplCourseId).HasColumnType("NUMBER(38)").HasColumnName("CPL_COURSE_ID");
                entity.Property(e => e.CplIcabSubjectId).HasColumnType("NUMBER(38)").HasColumnName("CPL_ICAB_SUBJECT_ID");
                entity.Property(e => e.Id).HasColumnType("NUMBER").ValueGeneratedOnAdd().HasColumnName("ID");
                entity.Property(e => e.ObtainedGpa).HasColumnType("FLOAT").HasColumnName("OBTAINED_GPA");
                entity.HasOne(d => d.Submission).WithMany(p => p.CplSubmissionAcademicDetails).HasForeignKey(d => d.SubmissionId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CPL_SUBMISSION_FOR_ACADEMIC_DETAILS");
                entity.HasOne(d => d.Cpl).WithMany(p => p.CplSubmissionAcademicDetails).HasForeignKey(d => new {
                    d.CplUniversityId,
                    d.CplDepartmentId,
                    d.CplCourseId,
                    d.CplIcabSubjectId
                }).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CPL_SUBJECT_MAPPING_FOR_ACADEMIC_DETAILS");
            });
            modelBuilder.Entity<CplSubmissionFilesCommon>(entity => {
                entity.HasKey(e => e.SubmissionId).HasName("CPL_SUBMISSION_FILES_COMMON_PK");
                entity.ToTable("CPL_SUBMISSION_FILES_COMMON");
                entity.Property(e => e.SubmissionId).HasColumnType("NUMBER(38)").HasColumnName("SUBMISSION_ID");
                entity.Property(e => e.FileAcademicTranscript).IsRequired().HasMaxLength(200).IsUnicode(false).HasColumnName("FILEPATH_ACADEMIC_TRANSCRIPT");
                entity.Property(e => e.FileIcabIdCard).HasMaxLength(200).IsUnicode(false).HasColumnName("FILEPATH_ICAB_ID_CARD");
                entity.Property(e => e.FileMembershipCertificate).HasMaxLength(200).IsUnicode(false).HasColumnName("FILEPATH_MEMBERSHIP_CERTIFICATE");
                entity.Property(e => e.FileCplPayslip).IsRequired().HasMaxLength(200).IsUnicode(false).HasColumnName("FILEPATH_CPL_PAYSLIP");
                entity.Property(e => e.PayslipNumber).IsRequired().HasMaxLength(200).IsUnicode(false).HasColumnName("PAYSLIP_NUMBER");
                entity.Property(e => e.PaymentMode).IsRequired().HasMaxLength(200).IsUnicode(false).HasColumnName("PAYMENT_MODE");
                entity.Property(e => e.Id).HasColumnType("NUMBER").ValueGeneratedOnAdd().HasColumnName("ID");
                entity.HasOne(d => d.Submission).WithOne(p => p.CplSubmissionFilesCommon).HasForeignKey<CplSubmissionFilesCommon>(d => d.SubmissionId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CPL_SUBMISSION_FOR_FILES_COMMON");
            });
            modelBuilder.Entity<CplCourse>(entity => {
                entity.HasKey(e => new {
                    e.UniversityId,
                    e.DepartmentId,
                    e.CourseId
                }).HasName("CPL_COURSE_PK");
                entity.ToTable("CPL_COURSE");
                entity.HasIndex(e => new {
                    e.UniversityId,
                    e.DepartmentId,
                    e.CourseName
                }, "CPL_COURSE_UN").IsUnique();
                entity.Property(e => e.UniversityId).HasColumnType("NUMBER(38)").HasColumnName("UNIVERSITY_ID");
                entity.Property(e => e.DepartmentId).HasColumnType("NUMBER(38)").HasColumnName("DEPARTMENT_ID");
                entity.Property(e => e.CourseId).HasColumnType("NUMBER(38)").HasColumnName("COURSE_ID");
                entity.Property(e => e.CourseName).IsRequired().HasMaxLength(100).IsUnicode(false).HasColumnName("COURSE_NAME");
                entity.Property(e => e.Id).HasColumnType("NUMBER").ValueGeneratedOnAdd().HasColumnName("ID");
                entity.HasOne(d => d.CplDepartment).WithMany(p => p.CplCourses).HasForeignKey(d => new {
                    d.UniversityId,
                    d.DepartmentId
                }).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CPL_DEPARTMENT");
            });
            modelBuilder.Entity<CplDepartment>(entity => {
                entity.HasKey(e => new {
                    e.UniversityId,
                    e.DepartmentId
                }).HasName("CPL_DEPARTMENT_PK");
                entity.ToTable("CPL_DEPARTMENT");
                entity.HasIndex(e => new {
                    e.UniversityId,
                    e.DepartmentName
                }, "CPL_DEPARTMENT_UN").IsUnique();
                entity.Property(e => e.UniversityId).HasColumnType("NUMBER").HasColumnName("UNIVERSITY_ID");
                entity.Property(e => e.DepartmentId).HasColumnType("NUMBER(38)").HasColumnName("DEPARTMENT_ID");
                entity.Property(e => e.DepartmentName).IsRequired().HasMaxLength(100).IsUnicode(false).HasColumnName("DEPARTMENT_NAME");
                entity.Property(e => e.Id).HasColumnType("NUMBER").ValueGeneratedOnAdd().HasColumnName("ID");
                entity.Property(e => e.Cgpa).HasColumnType("FLOAT").HasColumnName("CGPA");
                entity.HasOne(d => d.University).WithMany(p => p.CplDepartments).HasForeignKey(d => d.UniversityId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CPL_UNIVERSITY");
            });
            modelBuilder.Entity<CplSubjectMapping>(entity => {
                entity.HasKey(e => new {
                    e.UniversityId,
                    e.DepartmentId,
                    e.CourseId,
                    e.IcabSubjectId
                }).HasName("CPL_SUBJECT_MAPPING_PK");
                entity.ToTable("CPL_SUBJECT_MAPPING");
                entity.Property(e => e.UniversityId).HasColumnType("NUMBER(38)").HasColumnName("UNIVERSITY_ID");
                entity.Property(e => e.DepartmentId).HasColumnType("NUMBER(38)").HasColumnName("DEPARTMENT_ID");
                entity.Property(e => e.CourseId).HasColumnType("NUMBER(38)").HasColumnName("COURSE_ID");
                entity.Property(e => e.IcabSubjectId).HasColumnType("NUMBER(38)").HasColumnName("ICAB_SUBJECT_ID");
                entity.Property(e => e.Gpa).HasColumnType("FLOAT").HasColumnName("GPA");
                entity.Property(e => e.ExamLevel).HasColumnType("NUMBER(8,0)").HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.Id).HasColumnType("NUMBER").ValueGeneratedOnAdd().HasColumnName("ID");
                entity.HasOne(d => d.CplCourse).WithMany(p => p.CplSubjectMappings).HasForeignKey(d => new {
                    d.UniversityId,
                    d.DepartmentId,
                    d.CourseId
                }).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CPL_COURSE");
            });
            modelBuilder.Entity<CplUniversity>(entity => {
                entity.HasKey(e => e.UniversityId).HasName("CPL_UNIVERSITY_PK");
                entity.ToTable("CPL_UNIVERSITY");
                entity.HasIndex(e => e.UniversityName, "CPL_UNIVERSITY_UN").IsUnique();
                entity.Property(e => e.UniversityId).HasColumnType("NUMBER(38)").HasColumnName("UNIVERSITY_ID");
                entity.Property(e => e.Id).HasColumnType("NUMBER").ValueGeneratedOnAdd().HasColumnName("ID");
                entity.Property(e => e.UniversityName).IsRequired().HasMaxLength(100).IsUnicode(false).HasColumnName("UNIVERSITY_NAME");
            });
            modelBuilder.Entity<OnlinePaymentDetail>(entity => {
                entity.HasKey(e => e.Id);
                entity.ToTable("ONLINE_PAYMENT_DETAILS");
                entity.Property(e => e.Amount).HasColumnType("FLOAT").HasColumnName("AMOUNT");
                entity.Property(e => e.CardType).HasMaxLength(100).IsUnicode(false).HasColumnName("CARD_TYPE");
                entity.Property(e => e.ExamLevel).HasColumnType("NUMBER(38)").HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.Id).HasColumnType("NUMBER").ValueGeneratedOnAdd().HasColumnName("ID");
                entity.Property(e => e.MonthId).HasColumnType("NUMBER(38)").HasColumnName("MONTH_ID");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100).IsUnicode(false).HasColumnName("NAME");
                entity.Property(e => e.PaymentTime).HasColumnType("DATE").HasColumnName("PAYMENT_TIME");
                entity.Property(e => e.RegNo).HasColumnType("NUMBER(38)").HasColumnName("REG_NO");
                entity.Property(e => e.SessionKey).HasMaxLength(100).IsUnicode(false).HasColumnName("SESSION_KEY");
                entity.Property(e => e.SessionYear).HasColumnType("NUMBER(38)").HasColumnName("SESSION_YEAR");
                entity.Property(e => e.Status).HasMaxLength(100).IsUnicode(false).HasColumnName("STATUS");
                entity.Property(e => e.TransactionId).IsRequired().HasMaxLength(100).IsUnicode(false).HasColumnName("TRANSACTION_ID");
                entity.Property(e => e.Exfeepayslipamt).HasColumnType("FLOAT").HasColumnName("EXFEEPAYSLIPAMT");
                entity.Property(e => e.Annfeepayslipamt).HasColumnType("FLOAT").HasColumnName("ANNFEEPAYSLIPAMT");
                entity.Property(e => e.RedirectUrl).HasMaxLength(100).IsUnicode(false).HasColumnName("REDIRECT_URL");
                entity.Property(e => e.PaymentError).HasMaxLength(200).IsUnicode(false).HasColumnName("PAYMENT_ERROR");
            });
            modelBuilder.Entity<CplOnlinePaymentDetail>(entity => {
                entity.HasKey(e => e.Id);
                entity.ToTable("CPL_ONLINE_PAYMENT_DETAILS");
                entity.Property(e => e.Amount).HasColumnType("FLOAT").HasColumnName("AMOUNT");
                entity.Property(e => e.CardType).HasMaxLength(100).IsUnicode(false).HasColumnName("CARD_TYPE");
                entity.Property(e => e.ExamLevel).HasColumnType("NUMBER(38)").HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.Id).HasColumnType("NUMBER").ValueGeneratedOnAdd().HasColumnName("ID");
                entity.Property(e => e.MonthId).HasColumnType("NUMBER(38)").HasColumnName("MONTH_ID");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100).IsUnicode(false).HasColumnName("NAME");
                entity.Property(e => e.PaymentTime).HasColumnType("DATE").HasColumnName("PAYMENT_TIME");
                entity.Property(e => e.RegNo).HasColumnType("NUMBER(38)").HasColumnName("REG_NO");
                entity.Property(e => e.SessionKey).HasMaxLength(100).IsUnicode(false).HasColumnName("SESSION_KEY");
                entity.Property(e => e.SessionYear).HasColumnType("NUMBER(38)").HasColumnName("SESSION_YEAR");
                entity.Property(e => e.Status).HasMaxLength(100).IsUnicode(false).HasColumnName("STATUS");
                entity.Property(e => e.TransactionId).IsRequired().HasMaxLength(100).IsUnicode(false).HasColumnName("TRANSACTION_ID");
                entity.Property(e => e.Exfeepayslipamt).HasColumnType("FLOAT").HasColumnName("EXFEEPAYSLIPAMT");
                entity.Property(e => e.Annfeepayslipamt).HasColumnType("FLOAT").HasColumnName("ANNFEEPAYSLIPAMT");
                entity.Property(e => e.RedirectUrl).HasMaxLength(100).IsUnicode(false).HasColumnName("REDIRECT_URL");
                entity.Property(e => e.PaymentError).HasMaxLength(200).IsUnicode(false).HasColumnName("PAYMENT_ERROR");
            });
            modelBuilder.Entity<SendMoodleCsv>(entity => {
                entity.HasKey(e => e.Id);
                entity.ToTable("SEND_MOODLE_CSV");
                entity.Property(e => e.Cohort1).IsRequired().HasMaxLength(50).IsUnicode(false).HasColumnName("COHORT1");
                entity.Property(e => e.DownloadDateTime).HasColumnType("DATE").HasColumnName("DOWNLOAD_DATE_TIME").HasDefaultValueSql("SYSDATE ");
                entity.Property(e => e.Id).HasColumnType("NUMBER").ValueGeneratedOnAdd().HasColumnName("ID");
                entity.Property(e => e.Monthid).HasPrecision(2).HasColumnName("MONTHID");
                entity.Property(e => e.Password).IsRequired().HasMaxLength(100).IsUnicode(false).HasColumnName("PASSWORD");
                entity.Property(e => e.RegNoFrom).HasPrecision(10).HasColumnName("REG_NO_FROM");
                entity.Property(e => e.RegNoTo).HasPrecision(10).HasColumnName("REG_NO_TO");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.Subid).HasPrecision(4).HasColumnName("SUBID");
                entity.Property(e => e.Username).HasMaxLength(100).IsUnicode(false).HasColumnName("USERNAME");
            });
            modelBuilder.Entity<MoodleCohort>(entity => {
                entity.HasKey(e => e.Id);
                entity.ToTable("MOODLE_COHORT");
                entity.Property(e => e.Id).HasColumnType("NUMBER").ValueGeneratedOnAdd().HasColumnName("ID");
                entity.Property(e => e.Username).HasMaxLength(100).IsUnicode(false).HasColumnName("USERNAME");
                entity.Property(e => e.Password).HasMaxLength(100).IsUnicode(false).HasColumnName("PASSWORD");
                entity.Property(e => e.Email).HasMaxLength(100).IsUnicode(false).HasColumnName("EMAIL");
                entity.Property(e => e.Name).HasMaxLength(100).IsUnicode(false).HasColumnName("NAME");
                entity.Property(e => e.ExamLevel).HasPrecision(4).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.City).HasMaxLength(50).IsUnicode(false).HasColumnName("CITY");
                entity.Property(e => e.Phone).HasMaxLength(100).IsUnicode(false).HasColumnName("PHONE");
                entity.Property(e => e.Cohort).HasMaxLength(50).IsUnicode(false).HasColumnName("COHORT");
                entity.Property(e => e.SubId).HasPrecision(4).HasColumnName("SUB_ID");
                entity.Property(e => e.MoodleUserId).HasMaxLength(100).IsUnicode(false).HasColumnName("MOODLE_USER_ID");
            });
            modelBuilder.Entity<VwTabulation>(entity => {
                entity.HasKey(e => new {
                    e.ExamLevel,
                    e.MonthId,
                    e.SessionYear,
                    e.RegNo,
                    e.SubId
                });
                entity.ToView("VW_TABULATION");
                entity.Property(e => e.BarCode).HasPrecision(15).HasColumnName("BAR_CODE");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.Grade).HasMaxLength(2).IsUnicode(false).HasColumnName("GRADE");
                entity.Property(e => e.Marks).HasColumnType("NUMBER(5,2)").HasColumnName("MARKS");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.SubId).HasPrecision(8).HasColumnName("SUB_ID");
            });
            modelBuilder.Entity<Bankbranch>(entity => {
                entity.HasKey(e => new {
                    e.Branchcode,
                    e.Chequebankcode
                });
                entity.ToTable("BANKBRANCH");
                entity.Property(e => e.Branchcode).HasColumnType("NUMBER").HasColumnName("BRANCHCODE");
                entity.Property(e => e.Branchname).IsRequired().HasMaxLength(100).IsUnicode(false).HasColumnName("BRANCHNAME");
                entity.Property(e => e.Chequebankcode).HasColumnType("NUMBER").HasColumnName("CHEQUEBANKCODE");
                entity.Property(e => e.Chequebankname).IsRequired().HasMaxLength(100).IsUnicode(false).HasColumnName("CHEQUEBANKNAME");
                entity.Property(e => e.Routing).IsRequired().HasMaxLength(50).IsUnicode(false).HasColumnName("ROUTING");
                entity.Property(e => e.Swiftcode).HasMaxLength(30).IsUnicode(false).HasColumnName("SWIFTCODE");
            });
            modelBuilder.Entity<FormFillupAndExamRunningStatus>(entity => {
                entity.HasKey(e => new {
                    e.ExamLevel,
                    e.MonthId,
                    e.SessionYear
                }).HasName("FORM_FILLUP_AND_EXAM_RUNNING_STATUS_PK");
                entity.ToTable("FORM_FILLUP_AND_EXAM_RUNNING_STATUS");
                entity.Property(e => e.ExamLevel).HasColumnType("NUMBER(38)").HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.MonthId).HasColumnType("NUMBER(38)").HasColumnName("MONTH_ID");
                entity.Property(e => e.SessionYear).HasColumnType("NUMBER(38)").HasColumnName("SESSION_YEAR");
                entity.Property(e => e.ExamRunningStatus).HasColumnType("NUMBER(38)").HasColumnName("EXAM_RUNNING_STATUS").HasDefaultValueSql("0 ");
                entity.Property(e => e.FormFillupStatus).HasColumnType("NUMBER(38)").HasColumnName("FORM_FILLUP_STATUS").HasDefaultValueSql("0 ");
            });
            modelBuilder.Entity<FormFillUptableForMoodle>(entity => {
                entity.HasKey(i => i.ID);
                entity.ToTable("FORMFILLUPTABLEMOODLE");
                entity.Property(e => e.ID).HasPrecision(10).HasColumnName("ID");
                entity.Property(e => e.APPEARINGFLAG).HasPrecision(10).HasColumnName("APPEARINGFLAG");
                entity.Property(e => e.BARCODE).HasPrecision(10).HasColumnName("BARCODE");
                entity.Property(e => e.EXAMLEVEL).HasPrecision(10).HasColumnName("EXAMLEVEL");
                entity.Property(e => e.EXAMROLL).HasPrecision(10).HasColumnName("EXAMROLL");
                entity.Property(e => e.FATHERSNAME).HasColumnName("FATHERSNAME");
                entity.Property(e => e.MONTHID).HasPrecision(10).HasColumnName("MONTHID");
                entity.Property(e => e.NAME).HasColumnName("NAME");
                entity.Property(e => e.REFNO).HasPrecision(10).HasColumnName("REFNO");
                entity.Property(e => e.REGNO).HasPrecision(10).HasColumnName("REGNO");
                entity.Property(e => e.SESSIONYEAR).HasPrecision(10).HasColumnName("SESSIONYEAR");
            });
            modelBuilder.Entity<EarlierPassed61>(entity => {
                entity.HasKey(c => c.RegNo);
                entity.ToTable("EARLIER_PASSED_61");
                entity.Property(e => e.Ep611).HasPrecision(4).HasColumnName("EP611");
                entity.Property(e => e.Ep612).HasPrecision(4).HasColumnName("EP612");
                entity.Property(e => e.Ep613).HasPrecision(4).HasColumnName("EP613");
                entity.Property(e => e.Ep614).HasPrecision(4).HasColumnName("EP614");
                entity.Property(e => e.Ep615).HasPrecision(4).HasColumnName("EP615");
                entity.Property(e => e.Ep616).HasPrecision(4).HasColumnName("EP616");
                entity.Property(e => e.Ep617).HasPrecision(4).HasColumnName("EP617");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.Ref).HasPrecision(8).HasColumnName("REF");
            });
            modelBuilder.Entity<EarlierPassed62>(entity => {
                entity.HasKey(c => c.RegNo);
                entity.ToTable("EARLIER_PASSED_62");
                entity.Property(e => e.Ep621).HasPrecision(4).HasColumnName("EP621");
                entity.Property(e => e.Ep622).HasPrecision(4).HasColumnName("EP622");
                entity.Property(e => e.Ep623).HasPrecision(4).HasColumnName("EP623");
                entity.Property(e => e.Ep624).HasPrecision(4).HasColumnName("EP624");
                entity.Property(e => e.Ep625).HasPrecision(4).HasColumnName("EP625");
                entity.Property(e => e.Ep626).HasPrecision(4).HasColumnName("EP626");
                entity.Property(e => e.Ep627).HasPrecision(4).HasColumnName("EP627");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.Ref).HasPrecision(8).HasColumnName("REF");
            });
            modelBuilder.Entity<EarlierPassed63>(entity => {
                entity.HasKey(c => c.RegNo);
                entity.ToTable("EARLIER_PASSED_63");
                entity.Property(e => e.Ep631).HasPrecision(4).HasColumnName("EP631");
                entity.Property(e => e.Ep632).HasPrecision(4).HasColumnName("EP632");
                entity.Property(e => e.Ep633).HasPrecision(4).HasColumnName("EP633");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.Ref).HasPrecision(8).HasColumnName("REF");
            });
            modelBuilder.Entity<ExamFee>(entity => {
                entity.HasKey(c => c.Id);
                entity.ToTable("EXAM_FEE");
                entity.Property(e => e.Id).HasColumnType("NUMBER").ValueGeneratedOnAdd().HasColumnName("ID");
                entity.Property(e => e.Amount).HasColumnType("NUMBER(10,2)").HasColumnName("AMOUNT");
                entity.Property(e => e.ExamLevel).HasColumnType("NUMBER").HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.MonthId).HasColumnType("NUMBER").HasColumnName("MONTH_ID");
                entity.Property(e => e.SessionYear).HasColumnType("NUMBER").HasColumnName("SESSION_YEAR");
                entity.Property(e => e.SubId).HasColumnType("NUMBER").HasColumnName("SUB_ID");
            });
            modelBuilder.Entity<TempEarlierPassed61>(entity => {
                entity.HasKey(c => c.RegNo);
                entity.ToTable("TEMP_EARLIER_PASSED_61");
                entity.Property(e => e.Ep611).HasPrecision(4).HasColumnName("EP611");
                entity.Property(e => e.Ep612).HasPrecision(4).HasColumnName("EP612");
                entity.Property(e => e.Ep613).HasPrecision(4).HasColumnName("EP613");
                entity.Property(e => e.Ep614).HasPrecision(4).HasColumnName("EP614");
                entity.Property(e => e.Ep615).HasPrecision(4).HasColumnName("EP615");
                entity.Property(e => e.Ep616).HasPrecision(4).HasColumnName("EP616");
                entity.Property(e => e.Ep617).HasPrecision(4).HasColumnName("EP617");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.Ref).HasPrecision(8).HasColumnName("REF");
            });
            modelBuilder.Entity<TempEarlierPassed62>(entity => {
                entity.HasKey(c => c.RegNo);
                entity.ToTable("TEMP_EARLIER_PASSED_62");
                entity.Property(e => e.Ep621).HasPrecision(4).HasColumnName("EP621");
                entity.Property(e => e.Ep622).HasPrecision(4).HasColumnName("EP622");
                entity.Property(e => e.Ep623).HasPrecision(4).HasColumnName("EP623");
                entity.Property(e => e.Ep624).HasPrecision(4).HasColumnName("EP624");
                entity.Property(e => e.Ep625).HasPrecision(4).HasColumnName("EP625");
                entity.Property(e => e.Ep626).HasPrecision(4).HasColumnName("EP626");
                entity.Property(e => e.Ep627).HasPrecision(4).HasColumnName("EP627");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.Ref).HasPrecision(8).HasColumnName("REF");
            });
            modelBuilder.Entity<TempEarlierPassed63>(entity => {
                entity.HasKey(c => c.RegNo);
                entity.ToTable("TEMP_EARLIER_PASSED_63");
                entity.Property(e => e.Ep631).HasPrecision(4).HasColumnName("EP631");
                entity.Property(e => e.Ep632).HasPrecision(4).HasColumnName("EP632");
                entity.Property(e => e.Ep633).HasPrecision(4).HasColumnName("EP633");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.Ref).HasPrecision(8).HasColumnName("REF");
            });
            modelBuilder.Entity<TempExamRegPassed>(entity => {
                entity.HasKey(c => new {
                    c.ExamSl,
                    c.RefNo
                });
                entity.ToTable("TEMP_EXAM_REG_PASSED");
                entity.Property(e => e.ExamNamePassed).HasMaxLength(70).IsUnicode(false).HasColumnName("EXAM_NAME_PASSED");
                entity.Property(e => e.ExamSl).HasPrecision(2).HasColumnName("EXAM_SL");
                entity.Property(e => e.ExamcenPassed).HasMaxLength(10).IsUnicode(false).HasColumnName("EXAMCEN_PASSED");
                entity.Property(e => e.RefNo).HasPrecision(8).HasColumnName("REF_NO");
                entity.Property(e => e.RollnoPassed).HasPrecision(8).HasColumnName("ROLLNO_PASSED");
                entity.Property(e => e.SessionPassed).HasMaxLength(20).IsUnicode(false).HasColumnName("SESSION_PASSED");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.StuRegNo).HasPrecision(8).HasColumnName("STU_REG_NO");
            });
            modelBuilder.Entity<TempExemptedSub>(entity => {
                entity.HasKey(c => new {
                    c.RegNo,
                    c.ExamLevel,
                    c.SubId,
                    c.Ref
                });
                entity.ToTable("TEMP_EXEMPTED_SUB");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.Ref).HasPrecision(8).HasColumnName("REF");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.SubId).HasPrecision(4).HasColumnName("SUB_ID");
            });
            modelBuilder.Entity<TempClassAttendance>(entity => {
                entity.HasKey(c => new {
                    c.RegNo,
                    c.ExamLevel,
                    c.SubId,
                    c.RefNo
                });
                entity.ToTable("TEMP_CLASS_ATTENDANCE");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.RefNo).HasPrecision(8).HasColumnName("REF_NO");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.SubId).HasPrecision(4).HasColumnName("SUB_ID");
            });
            modelBuilder.Entity<TempRegSubject>(entity => {
                entity.HasKey(c => new {
                    c.RefNo,
                    c.SubId
                });
                entity.ToTable("TEMP_REG_SUBJECT");
                entity.Property(e => e.EntryType).HasPrecision(1).HasColumnName("ENTRY_TYPE");
                entity.Property(e => e.RefNo).HasPrecision(8).HasColumnName("REF_NO");
                entity.Property(e => e.SubId).HasPrecision(4).HasColumnName("SUB_ID");
            });
            modelBuilder.Entity<TempExamReg>(entity => {
                entity.HasKey(c => new {
                    c.RegNo,
                    c.ExamLevel,
                    c.MonthId,
                    c.SessionYear,
                    c.ExamcenId
                });
                entity.ToTable("TEMP_EXAM_REG");
                entity.Property(e => e.Annfeepayslipamt).HasColumnType("NUMBER").HasColumnName("ANNFEEPAYSLIPAMT");
                entity.Property(e => e.Annfeepayslipbank).HasMaxLength(100).IsUnicode(false).HasColumnName("ANNFEEPAYSLIPBANK");
                entity.Property(e => e.Annfeepayslipbr).HasMaxLength(100).IsUnicode(false).HasColumnName("ANNFEEPAYSLIPBR");
                entity.Property(e => e.Annfeepayslipdate).HasColumnType("DATE").HasColumnName("ANNFEEPAYSLIPDATE");
                entity.Property(e => e.Annfeepayslipno).HasMaxLength(50).IsUnicode(false).HasColumnName("ANNFEEPAYSLIPNO");
                entity.Property(e => e.AttenAttached).HasMaxLength(1).IsUnicode(false).HasColumnName("ATTEN_ATTACHED");
                entity.Property(e => e.CcEnrno).HasMaxLength(20).IsUnicode(false).HasColumnName("CC_ENRNO");
                entity.Property(e => e.CcSession).HasMaxLength(4).IsUnicode(false).HasColumnName("CC_SESSION");
                entity.Property(e => e.CcYear).HasPrecision(4).HasColumnName("CC_YEAR");
                entity.Property(e => e.EntryType).HasPrecision(1).HasColumnName("ENTRY_TYPE");
                entity.Property(e => e.Entryuser).HasMaxLength(10).IsUnicode(false).HasColumnName("ENTRYUSER");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.ExamcenId).HasPrecision(2).HasColumnName("EXAMCEN_ID");
                entity.Property(e => e.Exfeepayslipamt).HasColumnType("NUMBER").HasColumnName("EXFEEPAYSLIPAMT");
                entity.Property(e => e.Exfeepayslipbank).HasMaxLength(100).IsUnicode(false).HasColumnName("EXFEEPAYSLIPBANK");
                entity.Property(e => e.Exfeepayslipbr).HasMaxLength(100).IsUnicode(false).HasColumnName("EXFEEPAYSLIPBR");
                entity.Property(e => e.Exfeepayslipdate).HasColumnType("DATE").HasColumnName("EXFEEPAYSLIPDATE");
                entity.Property(e => e.Exfeepayslipno).HasMaxLength(50).IsUnicode(false).HasColumnName("EXFEEPAYSLIPNO");
                entity.Property(e => e.Fapprove).HasColumnType("NUMBER").HasColumnName("FAPPROVE").HasDefaultValueSql("0");
                entity.Property(e => e.FillupDate).HasColumnType("DATE").HasColumnName("FILLUP_DATE");
                entity.Property(e => e.FitnessAttached).HasMaxLength(1).IsUnicode(false).HasColumnName("FITNESS_ATTACHED");
                entity.Property(e => e.FormNo).HasMaxLength(9).IsUnicode(false).HasColumnName("FORM_NO");
                entity.Property(e => e.Formsubmitstatus).HasColumnType("NUMBER").HasColumnName("FORMSUBMITSTATUS").HasDefaultValueSql("0");
                entity.Property(e => e.LastAppearedExamlevel).HasPrecision(8).HasColumnName("LAST_APPEARED_EXAMLEVEL");
                entity.Property(e => e.LastAppearedMonthid).HasPrecision(2).HasColumnName("LAST_APPEARED_MONTHID");
                entity.Property(e => e.LastAppearedRollno).HasPrecision(8).HasColumnName("LAST_APPEARED_ROLLNO");
                entity.Property(e => e.LastAppearedYear).HasPrecision(4).HasColumnName("LAST_APPEARED_YEAR");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.ReasonInvalid).HasMaxLength(200).IsUnicode(false).HasColumnName("REASON_INVALID");
                entity.Property(e => e.Ref).HasPrecision(8).HasColumnName("REF");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.StudType).HasPrecision(2).HasColumnName("STUD_TYPE");
                entity.Property(e => e.TrainingAttached).HasMaxLength(1).IsUnicode(false).HasColumnName("TRAINING_ATTACHED");
                entity.Property(e => e.TrainingEnd).HasColumnType("DATE").HasColumnName("TRAINING_END");
                entity.Property(e => e.TrainingSt).HasColumnType("DATE").HasColumnName("TRAINING_ST");
                entity.Property(e => e.Validity).HasPrecision(1).HasColumnName("VALIDITY");
                entity.Property(e => e.MaintbRef).HasPrecision(8).HasColumnName("MAINTB_REF");
                entity.Property(e => e.PaymentMode).HasMaxLength(100).IsUnicode(false).HasColumnName("PAYMENT_MODE");
                entity.Property(e => e.FilepathAttenAttached).HasMaxLength(200).IsUnicode(false).HasColumnName("FILEPATH_ATTEN_ATTACHED");
                entity.Property(e => e.FilepathTrainingAttached).HasMaxLength(200).IsUnicode(false).HasColumnName("FILEPATH_TRANING_ATTACHED");
                entity.Property(e => e.FilepathFitnessAttached).HasMaxLength(200).IsUnicode(false).HasColumnName("FILEPATH_FITNESS_ATTACHED");
                entity.Property(e => e.FilepathExfeeuploadPayslip).HasMaxLength(200).IsUnicode(false).HasColumnName("FILEPATH_EXFEEUPLOADPAYSLIP");
                entity.Property(e => e.FilepathAnnfeeuploadPayslip).HasMaxLength(200).IsUnicode(false).HasColumnName("FILEPATH_ANNFEEUPLOAD_PAYSLIP");
            });
            modelBuilder.Entity<BoardUniversity>(entity => {
                entity.HasKey(e => e.Id);
                entity.ToTable("BOARD_UNIVERSITY");
                entity.Property(e => e.BoardUniId).HasColumnType("NUMBER").HasColumnName("BOARD_UNI_ID");
                entity.Property(e => e.BoardUniName).HasMaxLength(100).IsUnicode(false).HasColumnName("BOARD_UNI_NAME");
                entity.Property(e => e.Id).HasColumnType("NUMBER").HasColumnName("ID");
            });
            modelBuilder.Entity<StudentMainMenu>(entity => {
                entity.HasKey(e => e.ID);
                entity.ToTable("STUDENT_MAINMENU");
                entity.Property(e => e.ID).HasColumnType("NUMBER").HasColumnName("ID");
                entity.Property(e => e.MENUNAME).HasMaxLength(100).IsUnicode(false).HasColumnName("MENUNAME");
                entity.Property(e => e.MENUURL).HasMaxLength(100).IsUnicode(false).HasColumnName("MENUURL");
                entity.Property(e => e.VISIBILITY).HasColumnType("NUMBER").HasColumnName("VISIBILITY");
            });
            modelBuilder.Entity<IdentityUserToken<string>>(entity => {
                entity.ToTable("UserTokens");
            });
            modelBuilder.Entity<UserSubMenu>().HasKey(Us => new {
                Us.ApplicationUserId,
                Us.SubMenuId
            });
            modelBuilder.Entity<UserSubMenu>().HasOne(Us => Us.ApplicationUser).WithMany(u => u.UserSubMenus).HasForeignKey(Us => Us.ApplicationUserId);
            modelBuilder.Entity<UserSubMenu>().HasOne(Us => Us.SubMenu).WithMany(u => u.UserSubMenus).HasForeignKey(Us => Us.SubMenuId);
            modelBuilder.Entity<UserSubMenu>().HasOne(Us => Us.MainMenu).WithMany(u => u.UserSubMenus).HasForeignKey(Us => Us.MainMenuId);
            modelBuilder.Entity<GroupSubject>(entity => {
                entity.HasKey(k => k.Id);
                entity.ToTable("GROUP_SUBJECT");
                entity.Property(e => e.Id).HasColumnType("NUMBER").HasColumnName("ID");
                entity.Property(e => e.GroupSubId).HasColumnType("NUMBER").HasColumnName("GROUP_SUB_ID");
                entity.Property(e => e.GroupSubName).HasMaxLength(100).IsUnicode(false).HasColumnName("GROUP_SUB_NAME");
            });
            modelBuilder.Entity<AdminDecoder>(entity => {
                entity.HasNoKey();
                entity.ToTable("ADMIN_DECODER");
                entity.Property(e => e.CreateDate).HasColumnType("DATE").HasColumnName("CREATE_DATE");
                entity.Property(e => e.Entryuser).HasMaxLength(100).IsUnicode(false).HasColumnName("ENTRYUSER");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.Fullname).HasMaxLength(100).IsUnicode(false).HasColumnName("FULLNAME");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.Password).HasMaxLength(100).IsUnicode(false).HasColumnName("PASSWORD");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.UserId).HasPrecision(4).HasColumnName("USER_ID");
                entity.Property(e => e.UserStatus).HasMaxLength(10).IsUnicode(false).HasColumnName("USER_STATUS");
                entity.Property(e => e.Username).HasMaxLength(100).IsUnicode(false).HasColumnName("USERNAME");
                entity.Property(e => e.Who).HasMaxLength(100).IsUnicode(false).HasColumnName("WHO");
            });
            modelBuilder.Entity<Appallsub>(entity => {
                entity.HasNoKey();
                entity.ToView("APPALLSUB");
            });
            modelBuilder.Entity<AppUser>(entity => {
                entity.ToTable("APPUSER");
                entity.Property(e => e.Id).HasPrecision(10).HasColumnName("Id");
                entity.Property(e => e.DateOfBirth).HasPrecision(7).HasColumnName("DateOfBirth");
                entity.Property(e => e.IsVerified).HasPrecision(1).HasColumnName("IsVerified");
                entity.Property(e => e.Otp).HasPrecision(10).HasColumnName("Otp");
                entity.Property(e => e.RegistrationNo).HasPrecision(10).HasColumnName("RegistrationNo");
            });
            modelBuilder.Entity<Barcheck1>(entity => {
                entity.HasNoKey();
                entity.ToTable("BARCHECK_1");
                entity.Property(e => e.Bar11).HasPrecision(15).HasColumnName("BAR11");
                entity.Property(e => e.Bar12).HasPrecision(15).HasColumnName("BAR12");
                entity.Property(e => e.Bar13).HasPrecision(15).HasColumnName("BAR13");
                entity.Property(e => e.Bar14).HasPrecision(15).HasColumnName("BAR14");
                entity.Property(e => e.Bar15).HasPrecision(15).HasColumnName("BAR15");
                entity.Property(e => e.Bar16).HasPrecision(15).HasColumnName("BAR16");
                entity.Property(e => e.Bar17).HasPrecision(15).HasColumnName("BAR17");
                entity.Property(e => e.Bar18).HasPrecision(15).HasColumnName("BAR18");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.Exm11).HasColumnType("NUMBER(5,2)").HasColumnName("EXM11");
                entity.Property(e => e.Exm12).HasColumnType("NUMBER(5,2)").HasColumnName("EXM12");
                entity.Property(e => e.Exm13).HasColumnType("NUMBER(5,2)").HasColumnName("EXM13");
                entity.Property(e => e.Exm14).HasColumnType("NUMBER(5,2)").HasColumnName("EXM14");
                entity.Property(e => e.Exm15).HasColumnType("NUMBER(5,2)").HasColumnName("EXM15");
                entity.Property(e => e.Exm16).HasColumnType("NUMBER(5,2)").HasColumnName("EXM16");
                entity.Property(e => e.Exm17).HasColumnType("NUMBER(5,2)").HasColumnName("EXM17");
                entity.Property(e => e.Exm18).HasColumnType("NUMBER(5,2)").HasColumnName("EXM18");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
            });
            modelBuilder.Entity<Barcheck2>(entity => {
                entity.HasNoKey();
                entity.ToTable("BARCHECK_2");
                entity.Property(e => e.Bar21).HasPrecision(15).HasColumnName("BAR21");
                entity.Property(e => e.Bar22).HasPrecision(15).HasColumnName("BAR22");
                entity.Property(e => e.Bar23).HasPrecision(15).HasColumnName("BAR23");
                entity.Property(e => e.Bar24).HasPrecision(15).HasColumnName("BAR24");
                entity.Property(e => e.Bar25).HasPrecision(15).HasColumnName("BAR25");
                entity.Property(e => e.Bar26).HasPrecision(15).HasColumnName("BAR26");
                entity.Property(e => e.Bar27).HasPrecision(15).HasColumnName("BAR27");
                entity.Property(e => e.Bar28).HasPrecision(15).HasColumnName("BAR28");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.Exm21).HasColumnType("NUMBER(5,2)").HasColumnName("EXM21");
                entity.Property(e => e.Exm22).HasColumnType("NUMBER(5,2)").HasColumnName("EXM22");
                entity.Property(e => e.Exm23).HasColumnType("NUMBER(5,2)").HasColumnName("EXM23");
                entity.Property(e => e.Exm24).HasColumnType("NUMBER(5,2)").HasColumnName("EXM24");
                entity.Property(e => e.Exm25).HasColumnType("NUMBER(5,2)").HasColumnName("EXM25");
                entity.Property(e => e.Exm26).HasColumnType("NUMBER(5,2)").HasColumnName("EXM26");
                entity.Property(e => e.Exm27).HasColumnType("NUMBER(5,2)").HasColumnName("EXM27");
                entity.Property(e => e.Exm28).HasColumnType("NUMBER(5,2)").HasColumnName("EXM28");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
            });
            modelBuilder.Entity<Barcheck3>(entity => {
                entity.HasNoKey();
                entity.ToTable("BARCHECK_3");
                entity.Property(e => e.Bar31).HasPrecision(15).HasColumnName("BAR31");
                entity.Property(e => e.Bar32).HasPrecision(15).HasColumnName("BAR32");
                entity.Property(e => e.Bar33).HasPrecision(15).HasColumnName("BAR33");
                entity.Property(e => e.Bar34).HasPrecision(15).HasColumnName("BAR34");
                entity.Property(e => e.Bar35).HasPrecision(15).HasColumnName("BAR35");
                entity.Property(e => e.Bar36).HasPrecision(15).HasColumnName("BAR36");
                entity.Property(e => e.Bar37).HasPrecision(15).HasColumnName("BAR37");
                entity.Property(e => e.Bar38).HasPrecision(15).HasColumnName("BAR38");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.Exm31).HasColumnType("NUMBER(5,2)").HasColumnName("EXM31");
                entity.Property(e => e.Exm32).HasColumnType("NUMBER(5,2)").HasColumnName("EXM32");
                entity.Property(e => e.Exm33).HasColumnType("NUMBER(5,2)").HasColumnName("EXM33");
                entity.Property(e => e.Exm34).HasColumnType("NUMBER(5,2)").HasColumnName("EXM34");
                entity.Property(e => e.Exm35).HasColumnType("NUMBER(5,2)").HasColumnName("EXM35");
                entity.Property(e => e.Exm36).HasColumnType("NUMBER(5,2)").HasColumnName("EXM36");
                entity.Property(e => e.Exm37).HasColumnType("NUMBER(5,2)").HasColumnName("EXM37");
                entity.Property(e => e.Exm38).HasColumnType("NUMBER(5,2)").HasColumnName("EXM38");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
            });
            modelBuilder.Entity<Barcheck41>(entity => {
                entity.HasNoKey();
                entity.ToTable("BARCHECK_41");
                entity.Property(e => e.Bar411).HasPrecision(15).HasColumnName("BAR411");
                entity.Property(e => e.Bar412).HasPrecision(15).HasColumnName("BAR412");
                entity.Property(e => e.Bar413).HasPrecision(15).HasColumnName("BAR413");
                entity.Property(e => e.Bar414).HasPrecision(15).HasColumnName("BAR414");
                entity.Property(e => e.Bar415).HasPrecision(15).HasColumnName("BAR415");
                entity.Property(e => e.Bar416).HasPrecision(15).HasColumnName("BAR416");
                entity.Property(e => e.Bar417).HasPrecision(15).HasColumnName("BAR417");
                entity.Property(e => e.Bar418).HasPrecision(15).HasColumnName("BAR418");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.Exm411).HasColumnType("NUMBER(5,2)").HasColumnName("EXM411");
                entity.Property(e => e.Exm412).HasColumnType("NUMBER(5,2)").HasColumnName("EXM412");
                entity.Property(e => e.Exm413).HasColumnType("NUMBER(5,2)").HasColumnName("EXM413");
                entity.Property(e => e.Exm414).HasColumnType("NUMBER(5,2)").HasColumnName("EXM414");
                entity.Property(e => e.Exm415).HasColumnType("NUMBER(5,2)").HasColumnName("EXM415");
                entity.Property(e => e.Exm416).HasColumnType("NUMBER(5,2)").HasColumnName("EXM416");
                entity.Property(e => e.Exm417).HasColumnType("NUMBER(5,2)").HasColumnName("EXM417");
                entity.Property(e => e.Exm418).HasColumnType("NUMBER(5,2)").HasColumnName("EXM418");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
            });
            modelBuilder.Entity<Barcheck42>(entity => {
                entity.HasNoKey();
                entity.ToTable("BARCHECK_42");
                entity.Property(e => e.Bar421).HasPrecision(15).HasColumnName("BAR421");
                entity.Property(e => e.Bar422).HasPrecision(15).HasColumnName("BAR422");
                entity.Property(e => e.Bar423).HasPrecision(15).HasColumnName("BAR423");
                entity.Property(e => e.Bar424).HasPrecision(15).HasColumnName("BAR424");
                entity.Property(e => e.Bar425).HasPrecision(15).HasColumnName("BAR425");
                entity.Property(e => e.Bar426).HasPrecision(15).HasColumnName("BAR426");
                entity.Property(e => e.Bar427).HasPrecision(15).HasColumnName("BAR427");
                entity.Property(e => e.Bar428).HasPrecision(15).HasColumnName("BAR428");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.Exm421).HasColumnType("NUMBER(5,2)").HasColumnName("EXM421");
                entity.Property(e => e.Exm422).HasColumnType("NUMBER(5,2)").HasColumnName("EXM422");
                entity.Property(e => e.Exm423).HasColumnType("NUMBER(5,2)").HasColumnName("EXM423");
                entity.Property(e => e.Exm424).HasColumnType("NUMBER(5,2)").HasColumnName("EXM424");
                entity.Property(e => e.Exm425).HasColumnType("NUMBER(5,2)").HasColumnName("EXM425");
                entity.Property(e => e.Exm426).HasColumnType("NUMBER(5,2)").HasColumnName("EXM426");
                entity.Property(e => e.Exm427).HasColumnType("NUMBER(5,2)").HasColumnName("EXM427");
                entity.Property(e => e.Exm428).HasColumnType("NUMBER(5,2)").HasColumnName("EXM428");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
            });
            modelBuilder.Entity<Barcheck51>(entity => {
                entity.HasNoKey();
                entity.ToTable("BARCHECK_51");
                entity.Property(e => e.Bar511).HasPrecision(15).HasColumnName("BAR511");
                entity.Property(e => e.Bar512).HasPrecision(15).HasColumnName("BAR512");
                entity.Property(e => e.Bar513).HasPrecision(15).HasColumnName("BAR513");
                entity.Property(e => e.Bar514).HasPrecision(15).HasColumnName("BAR514");
                entity.Property(e => e.Bar515).HasPrecision(15).HasColumnName("BAR515");
                entity.Property(e => e.Bar516).HasPrecision(15).HasColumnName("BAR516");
                entity.Property(e => e.Bar517).HasPrecision(15).HasColumnName("BAR517");
                entity.Property(e => e.Bar518).HasPrecision(15).HasColumnName("BAR518");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.Exm511).HasColumnType("NUMBER(5,2)").HasColumnName("EXM511");
                entity.Property(e => e.Exm512).HasColumnType("NUMBER(5,2)").HasColumnName("EXM512");
                entity.Property(e => e.Exm513).HasColumnType("NUMBER(5,2)").HasColumnName("EXM513");
                entity.Property(e => e.Exm514).HasColumnType("NUMBER(5,2)").HasColumnName("EXM514");
                entity.Property(e => e.Exm515).HasColumnType("NUMBER(5,2)").HasColumnName("EXM515");
                entity.Property(e => e.Exm516).HasColumnType("NUMBER(5,2)").HasColumnName("EXM516");
                entity.Property(e => e.Exm517).HasColumnType("NUMBER(5,2)").HasColumnName("EXM517");
                entity.Property(e => e.Exm518).HasColumnType("NUMBER(5,2)").HasColumnName("EXM518");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
            });
            modelBuilder.Entity<Barcheck52>(entity => {
                entity.HasNoKey();
                entity.ToTable("BARCHECK_52");
                entity.Property(e => e.Bar521).HasPrecision(15).HasColumnName("BAR521");
                entity.Property(e => e.Bar522).HasPrecision(15).HasColumnName("BAR522");
                entity.Property(e => e.Bar523).HasPrecision(15).HasColumnName("BAR523");
                entity.Property(e => e.Bar524).HasPrecision(15).HasColumnName("BAR524");
                entity.Property(e => e.Bar525).HasPrecision(15).HasColumnName("BAR525");
                entity.Property(e => e.Bar526).HasPrecision(15).HasColumnName("BAR526");
                entity.Property(e => e.Bar527).HasPrecision(15).HasColumnName("BAR527");
                entity.Property(e => e.Bar528).HasPrecision(15).HasColumnName("BAR528");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.Exm521).HasColumnType("NUMBER(5,2)").HasColumnName("EXM521");
                entity.Property(e => e.Exm522).HasColumnType("NUMBER(5,2)").HasColumnName("EXM522");
                entity.Property(e => e.Exm523).HasColumnType("NUMBER(5,2)").HasColumnName("EXM523");
                entity.Property(e => e.Exm524).HasColumnType("NUMBER(5,2)").HasColumnName("EXM524");
                entity.Property(e => e.Exm525).HasColumnType("NUMBER(5,2)").HasColumnName("EXM525");
                entity.Property(e => e.Exm526).HasColumnType("NUMBER(5,2)").HasColumnName("EXM526");
                entity.Property(e => e.Exm527).HasColumnType("NUMBER(5,2)").HasColumnName("EXM527");
                entity.Property(e => e.Exm528).HasColumnType("NUMBER(5,2)").HasColumnName("EXM528");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
            });
            modelBuilder.Entity<Barcheck61>(entity => {
                entity.HasKey(e => e.Id);
                entity.ToTable("BARCHECK_61");
                entity.Property(e => e.Bar611).HasPrecision(15).HasColumnName("BAR611");
                entity.Property(e => e.Bar612).HasPrecision(15).HasColumnName("BAR612");
                entity.Property(e => e.Bar613).HasPrecision(15).HasColumnName("BAR613");
                entity.Property(e => e.Bar614).HasPrecision(15).HasColumnName("BAR614");
                entity.Property(e => e.Bar615).HasPrecision(15).HasColumnName("BAR615");
                entity.Property(e => e.Bar616).HasPrecision(15).HasColumnName("BAR616");
                entity.Property(e => e.Bar617).HasPrecision(15).HasColumnName("BAR617");
                entity.Property(e => e.Bar618).HasPrecision(15).HasColumnName("BAR618");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.Exm611).HasColumnName("EXM611");
                entity.Property(e => e.Exm612).HasColumnName("EXM612");
                entity.Property(e => e.Exm613).HasColumnName("EXM613");
                entity.Property(e => e.Exm614).HasColumnName("EXM614");
                entity.Property(e => e.Exm615).HasColumnName("EXM615");
                entity.Property(e => e.Exm616).HasColumnName("EXM616");
                entity.Property(e => e.Exm617).HasColumnName("EXM617");
                entity.Property(e => e.Exm618).HasColumnName("EXM618");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
            });
            modelBuilder.Entity<Barcheck62>(entity => {
                entity.HasKey(e => e.Id);
                entity.ToTable("BARCHECK_62");
                entity.Property(e => e.Bar621).HasPrecision(8).HasColumnName("BAR621");
                entity.Property(e => e.Bar622).HasPrecision(8).HasColumnName("BAR622");
                entity.Property(e => e.Bar623).HasPrecision(8).HasColumnName("BAR623");
                entity.Property(e => e.Bar624).HasPrecision(8).HasColumnName("BAR624");
                entity.Property(e => e.Bar625).HasPrecision(8).HasColumnName("BAR625");
                entity.Property(e => e.Bar626).HasPrecision(8).HasColumnName("BAR626");
                entity.Property(e => e.Bar627).HasPrecision(8).HasColumnName("BAR627");
                entity.Property(e => e.Bar628).HasPrecision(8).HasColumnName("BAR628");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.Exm621).HasColumnName("EXM621");
                entity.Property(e => e.Exm622).HasColumnName("EXM622");
                entity.Property(e => e.Exm623).HasColumnName("EXM623");
                entity.Property(e => e.Exm624).HasColumnName("EXM624");
                entity.Property(e => e.Exm625).HasColumnName("EXM625");
                entity.Property(e => e.Exm626).HasColumnName("EXM626");
                entity.Property(e => e.Exm627).HasColumnName("EXM627");
                entity.Property(e => e.Exm628).HasColumnName("EXM628");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
            });
            modelBuilder.Entity<Barcheck63>(entity => {
                entity.HasKey(e => e.Id);
                entity.ToTable("BARCHECK_63");
                entity.Property(e => e.Bar631).HasPrecision(15).HasColumnName("BAR631");
                entity.Property(e => e.Bar632).HasPrecision(15).HasColumnName("BAR632");
                entity.Property(e => e.Bar633).HasPrecision(15).HasColumnName("BAR633");
                entity.Property(e => e.Bar634).HasPrecision(15).HasColumnName("BAR634");
                entity.Property(e => e.Bar635).HasPrecision(15).HasColumnName("BAR635");
                entity.Property(e => e.Bar636).HasPrecision(15).HasColumnName("BAR636");
                entity.Property(e => e.Bar637).HasPrecision(15).HasColumnName("BAR637");
                entity.Property(e => e.Bar638).HasPrecision(15).HasColumnName("BAR638");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.Exm631).HasColumnType("NVARCHAR2(2000)").HasColumnName("EXM631");
                entity.Property(e => e.Exm632).HasColumnType("NVARCHAR2(2000)").HasColumnName("EXM632");
                entity.Property(e => e.Exm633).HasColumnType("NVARCHAR2(2000)").HasColumnName("EXM633");
                entity.Property(e => e.Exm634).HasColumnType("NVARCHAR2(2000)").HasColumnName("EXM634");
                entity.Property(e => e.Exm635).HasColumnType("NVARCHAR2(2000)").HasColumnName("EXM635");
                entity.Property(e => e.Exm636).HasColumnType("NVARCHAR2(2000)").HasColumnName("EXM636");
                entity.Property(e => e.Exm637).HasColumnType("NVARCHAR2(2000)").HasColumnName("EXM637");
                entity.Property(e => e.Exm638).HasColumnType("NVARCHAR2(2000)").HasColumnName("EXM638");
                entity.Property(e => e.Erp633).HasColumnType("NVARCHAR2(2000)").HasColumnName("ERP633");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
            });
            modelBuilder.Entity<BarcodeAllot>(entity => {
                entity.HasKey(e => e.Id);
                entity.ToTable("BARCODE_ALLOT");
                entity.Property(e => e.BarCode).HasPrecision(15).HasColumnName("BAR_CODE");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.SubId).HasPrecision(8).HasColumnName("SUB_ID");
                entity.Property(e => e.UdSlno).HasPrecision(6).HasColumnName("UD_SLNO");
                entity.Property(e => e.UserId).HasMaxLength(20).IsUnicode(false).HasColumnName("USER_ID");
            });
            modelBuilder.Entity<BarcodeAllotExpelledArchive>(entity => {
                entity.HasNoKey();
                entity.ToTable("BARCODE_ALLOT_EXPELLED_ARCHIVE");
                entity.Property(e => e.BarCode).HasPrecision(15).HasColumnName("BAR_CODE");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.SubId).HasPrecision(8).HasColumnName("SUB_ID");
                entity.Property(e => e.UdSlno).HasPrecision(6).HasColumnName("UD_SLNO");
                entity.Property(e => e.UserId).HasMaxLength(20).IsUnicode(false).HasColumnName("USER_ID");
            });
            modelBuilder.Entity<BarcodeEdit>(entity => {
                entity.HasKey(e => e.Id);
                entity.ToTable("BARCODE_EDIT");
                entity.Property(e => e.BarCode).HasPrecision(15).HasColumnName("BAR_CODE");
                entity.Property(e => e.EditDelete).HasMaxLength(6).IsUnicode(false).HasColumnName("EDIT_DELETE");
                entity.Property(e => e.Editdate).HasColumnType("DATE").HasColumnName("EDITDATE");
                entity.Property(e => e.Editpart).HasPrecision(1).HasColumnName("EDITPART");
                entity.Property(e => e.Edittime).HasMaxLength(8).IsUnicode(false).HasColumnName("EDITTIME");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.PcInfo).HasMaxLength(100).IsUnicode(false).HasColumnName("PC_INFO");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.SubId).HasPrecision(8).HasColumnName("SUB_ID");
                entity.Property(e => e.UdSlno).HasPrecision(6).HasColumnName("UD_SLNO");
                entity.Property(e => e.UserId).HasMaxLength(10).IsUnicode(false).HasColumnName("USER_ID");
                entity.Property(e => e.Userid1).HasMaxLength(10).IsUnicode(false).HasColumnName("USERID");
            });
            modelBuilder.Entity<Barseq>(entity => {
                entity.HasKey(p => p.Id);
                entity.ToTable("BARSEQ");
                entity.Property(e => e.Barfrom).HasPrecision(10).HasColumnName("BARFROM");
                entity.Property(e => e.Barto).HasPrecision(10).HasColumnName("BARTO");
                entity.Property(e => e.ExamLevel).HasPrecision(10).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.MonthId).HasPrecision(10).HasColumnName("MONTH_ID");
                entity.Property(e => e.Scriptqty).HasPrecision(10).HasColumnName("SCRIPTQTY");
                entity.Property(e => e.SessionYear).HasPrecision(10).HasColumnName("SESSION_YEAR");
            });
            modelBuilder.Entity<Chequebank>(entity => {
                entity.HasKey(e => e.Cbcode);
                entity.ToTable("CHEQUEBANK");
                entity.Property(e => e.Cbcode).HasPrecision(4).HasColumnName("CBCODE");
                entity.Property(e => e.Cbname).HasMaxLength(100).IsUnicode(false).HasColumnName("CBNAME");
            });
            modelBuilder.Entity<ClassAttendance>(entity => {
                entity.HasKey(c => new {
                    c.RegNo,
                    c.ExamLevel,
                    c.SubId,
                    c.RefNo
                });
                entity.ToTable("CLASS_ATTENDANCE");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.RefNo).HasPrecision(8).HasColumnName("REF_NO");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.SubId).HasPrecision(4).HasColumnName("SUB_ID");
            });
            modelBuilder.Entity<ClassAttendanceArch>(entity => {
                entity.HasNoKey();
                entity.ToTable("CLASS_ATTENDANCE_ARCH");
                entity.Property(e => e.ChangeId).HasPrecision(8).HasColumnName("CHANGE_ID");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.RefNo).HasPrecision(8).HasColumnName("REF_NO");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.SubId).HasPrecision(4).HasColumnName("SUB_ID");
            });
            modelBuilder.Entity<Compinfo>(entity => {
                entity.HasNoKey();
                entity.ToTable("COMPINFO");
                entity.Property(e => e.Address).HasMaxLength(200).IsUnicode(false).HasColumnName("ADDRESS");
                entity.Property(e => e.Email).HasMaxLength(100).IsUnicode(false).HasColumnName("EMAIL");
                entity.Property(e => e.Fax).HasMaxLength(50).IsUnicode(false).HasColumnName("FAX");
                entity.Property(e => e.Name).HasMaxLength(100).IsUnicode(false).HasColumnName("NAME");
                entity.Property(e => e.Phone).HasMaxLength(200).IsUnicode(false).HasColumnName("PHONE");
                entity.Property(e => e.Web).HasMaxLength(100).IsUnicode(false).HasColumnName("WEB");
            });
            modelBuilder.Entity<ConversionCourseMark>(entity => {
                entity.HasNoKey();
                entity.ToTable("CONVERSION_COURSE_MARKS");
                entity.Property(e => e.BatchNo).HasPrecision(10).HasColumnName("BATCH_NO");
                entity.Property(e => e.Classsession).HasMaxLength(25).IsUnicode(false).HasColumnName("CLASSSESSION");
                entity.Property(e => e.Entryuser).HasMaxLength(10).IsUnicode(false).HasColumnName("ENTRYUSER");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.ExamcenId).HasPrecision(2).HasColumnName("EXAMCEN_ID");
                entity.Property(e => e.MarksSlno).HasPrecision(3).HasColumnName("MARKS_SLNO");
                entity.Property(e => e.Reason).HasMaxLength(250).IsUnicode(false).HasColumnName("REASON");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.Rollno).HasPrecision(5).HasColumnName("ROLLNO");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.StudentSlno).HasColumnType("NUMBER(25)").HasColumnName("STUDENT_SLNO");
                entity.Property(e => e.SubId).HasPrecision(4).HasColumnName("SUB_ID");
            });
            modelBuilder.Entity<Country>(entity => {
                entity.HasNoKey();
                entity.ToTable("COUNTRY");
                entity.HasIndex(e => e.CountryId, "PK_COUNT_ID").IsUnique();
                entity.HasIndex(e => e.Name, "UNQ_COUNT_NAME").IsUnique();
                entity.Property(e => e.CountryId).HasPrecision(3).HasColumnName("COUNTRY_ID");
                entity.Property(e => e.Name).HasMaxLength(50).IsUnicode(false).HasColumnName("NAME");
            });
            modelBuilder.Entity<Decodelog>(entity => {
                entity.HasKey(k => new {
                    k.ExamLevel,
                    k.MonthId,
                    k.SessionYear,
                    k.Ddate,
                    k.Dtime
                });
                entity.ToTable("DECODELOG");
                entity.Property(e => e.Ddate).HasColumnType("DATE").HasColumnName("DDATE");
                entity.Property(e => e.Decoder).HasMaxLength(10).IsUnicode(false).HasColumnName("DECODER");
                entity.Property(e => e.Decoder2nd).HasMaxLength(50).IsUnicode(false).HasColumnName("DECODER_2ND");
                entity.Property(e => e.Dtime).HasMaxLength(8).IsUnicode(false).HasColumnName("DTIME");
                entity.Property(e => e.ExamLevel).HasPrecision(2).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.UserId).HasMaxLength(10).IsUnicode(false).HasColumnName("USER_ID");
            });
            modelBuilder.Entity<Decoder>(entity => {
                entity.HasNoKey();
                entity.ToTable("DECODER");
                entity.Property(e => e.Fullname).HasMaxLength(100).IsUnicode(false).HasColumnName("FULLNAME");
                entity.Property(e => e.Password).HasMaxLength(100).IsUnicode(false).HasColumnName("PASSWORD");
                entity.Property(e => e.Username).HasMaxLength(100).IsUnicode(false).HasColumnName("USERNAME");
                entity.Property(e => e.Who).HasMaxLength(10).IsUnicode(false).HasColumnName("WHO");
            });
            modelBuilder.Entity<Democlass>(entity => {
                entity.ToTable("DEMOCLASS");
                entity.Property(e => e.Id).HasPrecision(10);
            });
            modelBuilder.Entity<Depobank>(entity => {
                entity.HasNoKey();
                entity.ToTable("DEPOBANK");
                entity.HasIndex(e => e.DbId, "PK_DB_ID").IsUnique();
                entity.Property(e => e.DbCode).HasMaxLength(4).IsUnicode(false).HasColumnName("DB_CODE");
                entity.Property(e => e.DbId).HasPrecision(4).HasColumnName("DB_ID");
                entity.Property(e => e.DbName).HasMaxLength(50).IsUnicode(false).HasColumnName("DB_NAME");
                entity.Property(e => e.DbOrder).HasPrecision(2).HasColumnName("DB_ORDER");
                entity.Property(e => e.Depth).HasPrecision(1).HasColumnName("DEPTH");
                entity.Property(e => e.Lr).HasMaxLength(1).IsUnicode(false).HasColumnName("LR");
                entity.Property(e => e.Parent).HasPrecision(4).HasColumnName("PARENT");
                entity.Property(e => e.Topparent).HasPrecision(4).HasColumnName("TOPPARENT");
            });
            modelBuilder.Entity<ExamCentre>(entity => {
                entity.HasKey(e => e.CenId);
                entity.ToTable("EXAM_CENTRE");
                entity.HasIndex(e => e.CenId, "PK_CEN_ID").IsUnique();
                entity.Property(e => e.Address).HasMaxLength(200).IsUnicode(false).HasColumnName("ADDRESS");
                entity.Property(e => e.CenId).HasPrecision(10).HasColumnName("CEN_ID");
                entity.Property(e => e.Name).HasMaxLength(100).IsUnicode(false).HasColumnName("NAME");
                entity.Property(e => e.Buildings).HasMaxLength(1000).IsUnicode(false).HasColumnName("BUILDINGS");
            });
            modelBuilder.Entity<VenueBuilding>(entity => {
                entity.HasKey(e => e.ID);
                entity.ToTable("VENUE_BUILDING");
                entity.Property(e => e.Address).HasMaxLength(1000).IsUnicode(false).HasColumnName("ADDRESS");
                entity.Property(e => e.CenId).HasPrecision(10).HasColumnName("CEN_ID");
                entity.Property(e => e.Buildings).HasMaxLength(1000).IsUnicode(false).HasColumnName("BUILDINGS");
            });
            modelBuilder.Entity<ExamReg>(entity => {
                entity.HasKey(c => new {
                    c.RegNo,
                    c.ExamLevel,
                    c.MonthId,
                    c.SessionYear,
                    c.ExamcenId
                });
                entity.ToTable("EXAM_REG");
                entity.Property(e => e.AttenAttached).HasMaxLength(1).IsUnicode(false).HasColumnName("ATTEN_ATTACHED");
                entity.Property(e => e.EntryType).HasPrecision(1).HasColumnName("ENTRY_TYPE");
                entity.Property(e => e.Entryuser).HasMaxLength(10).IsUnicode(false).HasColumnName("ENTRYUSER");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL").IsRequired();
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.ExamcenId).HasPrecision(2).HasColumnName("EXAMCEN_ID").IsRequired();
                entity.Property(e => e.FillupDate).HasColumnType("DATE").HasColumnName("FILLUP_DATE");
                entity.Property(e => e.FitnessAttached).HasMaxLength(1).IsUnicode(false).HasColumnName("FITNESS_ATTACHED");
                entity.Property(e => e.FormNo).HasMaxLength(9).IsUnicode(false).HasColumnName("FORM_NO");
                entity.Property(e => e.LastAppearedExamlevel).HasPrecision(8).HasColumnName("LAST_APPEARED_EXAMLEVEL");
                entity.Property(e => e.LastAppearedMonthid).HasPrecision(2).HasColumnName("LAST_APPEARED_MONTHID");
                entity.Property(e => e.LastAppearedRollno).HasPrecision(8).HasColumnName("LAST_APPEARED_ROLLNO");
                entity.Property(e => e.LastAppearedYear).HasPrecision(4).HasColumnName("LAST_APPEARED_YEAR");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID").IsRequired();
                entity.Property(e => e.ReasonInvalid).HasMaxLength(200).IsUnicode(false).HasColumnName("REASON_INVALID");
                entity.Property(e => e.Ref).HasPrecision(8).HasColumnName("REF");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO").IsRequired();
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR").IsRequired();
                entity.Property(e => e.StudType).HasPrecision(2).HasColumnName("STUD_TYPE");
                entity.Property(e => e.TrainingAttached).HasMaxLength(1).IsUnicode(false).HasColumnName("TRAINING_ATTACHED");
                entity.Property(e => e.TrainingEnd).HasColumnType("DATE").HasColumnName("TRAINING_END");
                entity.Property(e => e.TrainingSt).HasColumnType("DATE").HasColumnName("TRAINING_ST");
                entity.Property(e => e.Validity).HasPrecision(1).HasColumnName("VALIDITY");
                entity.Property(e => e.CcEnrno).HasMaxLength(20).IsUnicode(false).HasColumnName("CC_ENRNO");
                entity.Property(e => e.CcSession).HasMaxLength(4).IsUnicode(false).HasColumnName("CC_SESSION");
                entity.Property(e => e.CcYear).HasPrecision(4).HasColumnName("CC_YEAR");
                entity.Property(e => e.Venue).HasMaxLength(200).IsUnicode(false).HasColumnName("VENUE");
                entity.Property(e => e.FilepathAttenAttached).HasMaxLength(200).IsUnicode(false).HasColumnName("FILEPATH_ATTEN_ATTACHED");
                entity.Property(e => e.FilepathTrainingAttached).HasMaxLength(200).IsUnicode(false).HasColumnName("FILEPATH_TRANING_ATTACHED");
                entity.Property(e => e.FilepathFitnessAttached).HasMaxLength(200).IsUnicode(false).HasColumnName("FILEPATH_FITNESS_ATTACHED");
                entity.Property(e => e.FilepathExfeeuploadPayslip).HasMaxLength(200).IsUnicode(false).HasColumnName("FILEPATH_EXFEEUPLOADPAYSLIP");
                entity.Property(e => e.FilepathAnnfeeuploadPayslip).HasMaxLength(200).IsUnicode(false).HasColumnName("FILEPATH_ANNFEEUPLOAD_PAYSLIP");
            });
            modelBuilder.Entity<ExamRegArch>(entity => {
                entity.HasNoKey();
                entity.ToTable("EXAM_REG_ARCH");
                entity.Property(e => e.AttenAttached).HasMaxLength(1).IsUnicode(false).HasColumnName("ATTEN_ATTACHED");
                entity.Property(e => e.ChangeDate).HasColumnType("DATE").HasColumnName("CHANGE_DATE");
                entity.Property(e => e.ChangeId).HasPrecision(8).HasColumnName("CHANGE_ID");
                entity.Property(e => e.ChangeTime).HasMaxLength(8).IsUnicode(false).HasColumnName("CHANGE_TIME");
                entity.Property(e => e.ChangeUser).HasMaxLength(100).IsUnicode(false).HasColumnName("CHANGE_USER");
                entity.Property(e => e.EditDelete).HasMaxLength(6).IsUnicode(false).HasColumnName("EDIT_DELETE");
                entity.Property(e => e.EntryType).HasPrecision(1).HasColumnName("ENTRY_TYPE");
                entity.Property(e => e.Entryuser).HasMaxLength(10).IsUnicode(false).HasColumnName("ENTRYUSER");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.ExamcenId).HasPrecision(2).HasColumnName("EXAMCEN_ID");
                entity.Property(e => e.FillupDate).HasColumnType("DATE").HasColumnName("FILLUP_DATE");
                entity.Property(e => e.FitnessAttached).HasMaxLength(1).IsUnicode(false).HasColumnName("FITNESS_ATTACHED");
                entity.Property(e => e.FormNo).HasMaxLength(9).IsUnicode(false).HasColumnName("FORM_NO");
                entity.Property(e => e.LastAppearedExamlevel).HasPrecision(8).HasColumnName("LAST_APPEARED_EXAMLEVEL");
                entity.Property(e => e.LastAppearedMonthid).HasPrecision(2).HasColumnName("LAST_APPEARED_MONTHID");
                entity.Property(e => e.LastAppearedRollno).HasPrecision(8).HasColumnName("LAST_APPEARED_ROLLNO");
                entity.Property(e => e.LastAppearedYear).HasPrecision(4).HasColumnName("LAST_APPEARED_YEAR");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.PcInfo).HasMaxLength(100).IsUnicode(false).HasColumnName("PC_INFO");
                entity.Property(e => e.ReasonInvalid).HasMaxLength(200).IsUnicode(false).HasColumnName("REASON_INVALID");
                entity.Property(e => e.Ref).HasPrecision(8).HasColumnName("REF");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.StudType).HasPrecision(2).HasColumnName("STUD_TYPE");
                entity.Property(e => e.TrainingAttached).HasMaxLength(1).IsUnicode(false).HasColumnName("TRAINING_ATTACHED");
                entity.Property(e => e.TrainingEnd).HasColumnType("DATE").HasColumnName("TRAINING_END");
                entity.Property(e => e.TrainingSt).HasColumnType("DATE").HasColumnName("TRAINING_ST");
                entity.Property(e => e.Validity).HasPrecision(1).HasColumnName("VALIDITY");
            });
            modelBuilder.Entity<ExamRegPassed>(entity => {
                entity.HasNoKey();
                entity.ToTable("EXAM_REG_PASSED");
                entity.Property(e => e.ExamNamePassed).HasMaxLength(70).IsUnicode(false).HasColumnName("EXAM_NAME_PASSED");
                entity.Property(e => e.ExamSl).HasPrecision(2).HasColumnName("EXAM_SL");
                entity.Property(e => e.ExamcenPassed).HasMaxLength(10).IsUnicode(false).HasColumnName("EXAMCEN_PASSED");
                entity.Property(e => e.RefNo).HasPrecision(8).HasColumnName("REF_NO");
                entity.Property(e => e.RollnoPassed).HasPrecision(8).HasColumnName("ROLLNO_PASSED");
                entity.Property(e => e.SessionPassed).HasMaxLength(20).IsUnicode(false).HasColumnName("SESSION_PASSED");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.StuRegNo).HasPrecision(8).HasColumnName("STU_REG_NO");
            });
            modelBuilder.Entity<ExamRegPassedArch>(entity => {
                entity.HasNoKey();
                entity.ToTable("EXAM_REG_PASSED_ARCH");
                entity.Property(e => e.ChangeId).HasPrecision(8).HasColumnName("CHANGE_ID");
                entity.Property(e => e.ExamNamePassed).HasMaxLength(70).IsUnicode(false).HasColumnName("EXAM_NAME_PASSED");
                entity.Property(e => e.ExamSl).HasPrecision(2).HasColumnName("EXAM_SL");
                entity.Property(e => e.ExamcenPassed).HasMaxLength(10).IsUnicode(false).HasColumnName("EXAMCEN_PASSED");
                entity.Property(e => e.RefNo).HasPrecision(8).HasColumnName("REF_NO");
                entity.Property(e => e.RollnoPassed).HasPrecision(8).HasColumnName("ROLLNO_PASSED");
                entity.Property(e => e.SessionPassed).HasMaxLength(20).IsUnicode(false).HasColumnName("SESSION_PASSED");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.StuRegNo).HasPrecision(8).HasColumnName("STU_REG_NO");
            });
            modelBuilder.Entity<ExamSaveflag>(entity => {
                entity.HasNoKey();
                entity.ToTable("EXAM_SAVEFLAG");
                entity.Property(e => e.Delaycounter).HasPrecision(3).HasColumnName("DELAYCOUNTER");
            });
            modelBuilder.Entity<ExamTimeSch>(entity => {
                entity.HasKey(c => new {
                    c.Id
                });
                entity.ToTable("EXAM_TIME_SCH");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.ExamDate).HasColumnType("DATE").HasColumnName("EXAM_DATE");
                entity.Property(e => e.ExamLevel).HasPrecision(2).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.ExamTime1).HasMaxLength(8).IsUnicode(false).HasColumnName("EXAM_TIME1");
                entity.Property(e => e.ExamTime2).HasMaxLength(8).IsUnicode(false).HasColumnName("EXAM_TIME2");
                entity.Property(e => e.ExamTime3).HasMaxLength(8).IsUnicode(false).HasColumnName("EXAM_TIME3");
                entity.Property(e => e.ExamTime4).HasMaxLength(8).IsUnicode(false).HasColumnName("EXAM_TIME4");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.OrderNo).HasPrecision(2).HasColumnName("ORDER_NO");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.SubId).HasPrecision(3).HasColumnName("SUB_ID");
                entity.Property(e => e.Slot).HasPrecision(3).HasColumnName("SLOT");
                entity.Property(e => e.RollFrom).HasPrecision(8).HasColumnName("ROLLFROM");
                entity.Property(e => e.RollTo).HasPrecision(8).HasColumnName("ROLLTO");
            });
            modelBuilder.Entity<ExamTimeSchAdmit>(entity => {
                entity.HasNoKey();
                entity.ToTable("EXAM_TIME_SCH_ADMIT");
                entity.Property(e => e.ExamDate).HasColumnType("DATE").HasColumnName("EXAM_DATE");
                entity.Property(e => e.ExamLevel).HasPrecision(2).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.ExamTime1).HasMaxLength(8).IsUnicode(false).HasColumnName("EXAM_TIME1");
                entity.Property(e => e.ExamTime2).HasMaxLength(8).IsUnicode(false).HasColumnName("EXAM_TIME2");
                entity.Property(e => e.ExamTime3).HasMaxLength(8).IsUnicode(false).HasColumnName("EXAM_TIME3");
                entity.Property(e => e.ExamTime4).HasMaxLength(8).IsUnicode(false).HasColumnName("EXAM_TIME4");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.OrderNo).HasPrecision(2).HasColumnName("ORDER_NO");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.SubId).HasPrecision(3).HasColumnName("SUB_ID");
            });
            modelBuilder.Entity<ExamTimeSchCurr>(entity => {
                entity.HasNoKey();
                entity.ToTable("EXAM_TIME_SCH_CURR");
                entity.Property(e => e.ExamDate).HasColumnType("DATE").HasColumnName("EXAM_DATE");
                entity.Property(e => e.ExamLevel).HasPrecision(2).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.ExamTime1).HasMaxLength(8).IsUnicode(false).HasColumnName("EXAM_TIME1");
                entity.Property(e => e.ExamTime2).HasMaxLength(8).IsUnicode(false).HasColumnName("EXAM_TIME2");
                entity.Property(e => e.ExamTime3).HasMaxLength(8).IsUnicode(false).HasColumnName("EXAM_TIME3");
                entity.Property(e => e.ExamTime4).HasMaxLength(8).IsUnicode(false).HasColumnName("EXAM_TIME4");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.OrderNo).HasPrecision(2).HasColumnName("ORDER_NO");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.SubId).HasPrecision(3).HasColumnName("SUB_ID");
            });
            modelBuilder.Entity<ExemptedSub>(entity => {
                entity.HasKey(c => new {
                    c.RegNo,
                    c.ExamLevel,
                    c.SubId,
                    c.Ref
                });
                entity.ToTable("EXEMPTED_SUB");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.Ref).HasPrecision(8).HasColumnName("REF");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.SubId).HasPrecision(4).HasColumnName("SUB_ID");
            });
            modelBuilder.Entity<ExemptedSubArch>(entity => {
                entity.HasNoKey();
                entity.ToTable("EXEMPTED_SUB_ARCH");
                entity.Property(e => e.ChangeId).HasPrecision(8).HasColumnName("CHANGE_ID");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.Ref).HasPrecision(8).HasColumnName("REF");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.SubId).HasPrecision(4).HasColumnName("SUB_ID");
            });
            modelBuilder.Entity<FirmMas1>(entity => {
                entity.HasMany(e => e.FirmMas2s).WithOne(e => e.FirmMas1);
                entity.ToTable("FIRM_MAS1");
                entity.Property(e => e.FirmMas1Id).HasPrecision(10).HasColumnName("FIRMMAS1ID"); ;
                entity.Property(e => e.DoDeed).HasColumnType("DATE").HasColumnName("DO_DEED");
                entity.Property(e => e.Entryuser).HasMaxLength(10).IsUnicode(false).HasColumnName("ENTRYUSER");
                entity.Property(e => e.FId).HasPrecision(6).HasColumnName("F_ID");
                entity.Property(e => e.FName).HasMaxLength(100).IsUnicode(false).HasColumnName("F_NAME");
                entity.Property(e => e.FType).HasPrecision(1).HasColumnName("F_TYPE");
                entity.Property(e => e.NumPartner).HasPrecision(2).HasColumnName("NUM_PARTNER");
            });
            modelBuilder.Entity<FirmMas2>(entity => {
                entity.ToTable("FIRM_MAS2");
                entity.HasIndex(e => e.FirmMas1Id, "IX_FIRM_MAS2_FirmMas1Id");
                entity.Property(e => e.Id).HasPrecision(10);
                entity.Property(e => e.Address).HasMaxLength(200).IsUnicode(false).HasColumnName("ADDRESS");
                entity.Property(e => e.BrType).HasPrecision(1).HasColumnName("BR_TYPE");
                entity.Property(e => e.Cell).HasMaxLength(50).IsUnicode(false).HasColumnName("CELL");
                entity.Property(e => e.ContPer).HasMaxLength(40).IsUnicode(false).HasColumnName("CONT_PER");
                entity.Property(e => e.DoStart).HasColumnType("DATE").HasColumnName("DO_START");
                entity.Property(e => e.Email).HasMaxLength(100).IsUnicode(false).HasColumnName("EMAIL");
                entity.Property(e => e.FId).HasPrecision(6).HasColumnName("F_ID").HasDefaultValueSql("(0 ) ");
                entity.Property(e => e.Fax).HasMaxLength(50).IsUnicode(false).HasColumnName("FAX");
                entity.Property(e => e.FirmMas1Id).HasPrecision(10).HasColumnName("FIRMMAS1ID"); ;
                entity.Property(e => e.LocId).HasPrecision(2).HasColumnName("LOC_ID");
                entity.Property(e => e.Ph).HasMaxLength(50).IsUnicode(false).HasColumnName("PH");
                entity.Property(e => e.Website).HasMaxLength(50).IsUnicode(false).HasColumnName("WEBSITE");
                entity.HasOne(d => d.FirmMas1).WithMany(p => p.FirmMas2s).HasForeignKey(d => d.FirmMas1Id);
            });
            modelBuilder.Entity<FlagForDecode>(entity => {
                entity.HasNoKey();
                entity.ToTable("FLAG_FOR_DECODE");
                entity.Property(e => e.ExamLevel).HasPrecision(2).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.Flag).HasColumnType("NUMBER").HasColumnName("FLAG");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
            });
            modelBuilder.Entity<GradeDetail>(entity => {
                entity.HasKey(c => new {
                    c.RefNo,
                    c.GradeSl
                });
                entity.ToTable("GRADE_DETAILS");
                entity.Property(e => e.EndingMarks).HasPrecision(3).HasColumnName("ENDING_MARKS");
                entity.Property(e => e.GradeSl).HasColumnType("NUMBER").HasColumnName("GRADE_SL");
                entity.Property(e => e.LetterGrade).HasMaxLength(2).IsUnicode(false).HasColumnName("LETTER_GRADE");
                entity.Property(e => e.RefNo).HasPrecision(2).HasColumnName("REF_NO");
                entity.Property(e => e.StartingMarks).HasPrecision(2).HasColumnName("STARTING_MARKS");
            });
            modelBuilder.Entity<GradeSy>(entity => {
                entity.HasKey(c => new {
                    c.ExamLevel,
                    c.MonthId,
                    c.SessionYear,
                    c.SubId
                });
                entity.ToTable("GRADE_SYS");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.RefNo).HasPrecision(2).HasColumnName("REF_NO");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.SubId).HasPrecision(4).HasColumnName("SUB_ID");
            });
            modelBuilder.Entity<GradeSysChanged>(entity => {
                entity.HasKey(c => new {
                    c.MonthId,
                    c.SessionYear,
                    c.SubId,
                    c.ExamLevel,
                    c.RefNo
                });
                entity.ToTable("GRADE_SYS_CHANGED");
                entity.Property(e => e.ChangeDate).HasColumnType("DATE").HasColumnName("CHANGE_DATE");
                entity.Property(e => e.ChangeReason).HasMaxLength(500).IsUnicode(false).HasColumnName("CHANGE_REASON");
                entity.Property(e => e.ChangeUser).HasMaxLength(10).IsUnicode(false).HasColumnName("CHANGE_USER");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.RefNo).HasPrecision(2).HasColumnName("REF_NO");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.SubId).HasPrecision(4).HasColumnName("SUB_ID");
                entity.Property(e => e.Time).HasMaxLength(10).IsUnicode(false).HasColumnName("TIME");
                entity.Property(e => e.TrackId).HasPrecision(7).HasColumnName("TRACK_ID");
            });
            modelBuilder.Entity<HelloWorld>(entity => {
                entity.ToTable("HelloWorld");
                entity.Property(e => e.Id).HasPrecision(10);
            });
            modelBuilder.Entity<Incomehead>(entity => {
                entity.HasNoKey();
                entity.ToTable("INCOMEHEAD");
                entity.HasIndex(e => e.InheadId, "PK_INHEAD_ID").IsUnique();
                entity.Property(e => e.Depth).HasPrecision(1).HasColumnName("DEPTH");
                entity.Property(e => e.InheadCode).HasMaxLength(4).IsUnicode(false).HasColumnName("INHEAD_CODE");
                entity.Property(e => e.InheadId).HasPrecision(4).HasColumnName("INHEAD_ID");
                entity.Property(e => e.InheadidOrder).HasPrecision(2).HasColumnName("INHEADID_ORDER");
                entity.Property(e => e.Lr).HasMaxLength(1).IsUnicode(false).HasColumnName("LR");
                entity.Property(e => e.Name).HasMaxLength(50).IsUnicode(false).HasColumnName("NAME");
                entity.Property(e => e.Parent).HasPrecision(4).HasColumnName("PARENT");
                entity.Property(e => e.Topparent).HasPrecision(4).HasColumnName("TOPPARENT");
            });
            modelBuilder.Entity<Location>(entity => {
                entity.HasKey(e => e.LocId);
                entity.ToTable("LOCATION");
                entity.HasIndex(e => e.LocId, "PK_LOC_LID").IsUnique();
                entity.Property(e => e.LName).HasMaxLength(30).IsUnicode(false).HasColumnName("L_NAME");
                entity.Property(e => e.LocId).HasPrecision(8).HasColumnName("LOC_ID");
            });
            modelBuilder.Entity<MainMi>(entity => {
                entity.HasNoKey();
                entity.ToView("MAIN_MIS");
            });
            modelBuilder.Entity<MarksAllot>(entity => {
                entity.HasKey(c => new {
                    c.MonthId,
                    c.SessionYear,
                    c.SubId,
                    c.Examiner,
                    c.BarCode
                });
                entity.ToTable("MARKS_ALLOT");
                entity.Property(e => e.BarCode).HasPrecision(15).HasColumnName("BAR_CODE");
                entity.Property(e => e.Entryuser).HasMaxLength(10).IsUnicode(false).HasColumnName("ENTRYUSER");
                entity.Property(e => e.Examiner).HasPrecision(5).HasColumnName("EXAMINER");
                entity.Property(e => e.Grace).HasColumnType("NUMBER(5,2)").HasColumnName("GRACE");
                entity.Property(e => e.Grade).HasMaxLength(2).IsUnicode(false).HasColumnName("GRADE");
                entity.Property(e => e.Marks).HasColumnType("NUMBER(5,2)").HasColumnName("MARKS");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.Outmarks).HasColumnType("NUMBER(5,2)").HasColumnName("OUTMARKS");
                entity.Property(e => e.Scriptsl).HasPrecision(5).HasColumnName("SCRIPTSL");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.SubId).HasPrecision(8).HasColumnName("SUB_ID");
            });
            modelBuilder.Entity<MarksAllotEdit>(entity => {
                entity.HasKey(e => e.TrackId);
                entity.ToTable("MARKS_ALLOT_EDIT");
                entity.Property(e => e.BarCode).HasPrecision(15).HasColumnName("BAR_CODE");
                entity.Property(e => e.ChangeDate).HasColumnType("DATE").HasColumnName("CHANGE_DATE");
                entity.Property(e => e.ChangeMood).HasPrecision(1).HasColumnName("CHANGE_MOOD");
                entity.Property(e => e.ChangeTime).HasMaxLength(8).IsUnicode(false).HasColumnName("CHANGE_TIME");
                entity.Property(e => e.ChangeUser).HasMaxLength(100).IsUnicode(false).HasColumnName("CHANGE_USER");
                entity.Property(e => e.EditDelete).HasMaxLength(6).IsUnicode(false).HasColumnName("EDIT_DELETE");
                entity.Property(e => e.Entryuser).HasMaxLength(10).IsUnicode(false).HasColumnName("ENTRYUSER");
                entity.Property(e => e.Examiner).HasPrecision(5).HasColumnName("EXAMINER");
                entity.Property(e => e.Grace).HasColumnType("NUMBER(5,2)").HasColumnName("GRACE");
                entity.Property(e => e.Grade).HasMaxLength(2).IsUnicode(false).HasColumnName("GRADE");
                entity.Property(e => e.Marks).HasColumnType("NUMBER(5,2)").HasColumnName("MARKS");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.Outmarks).HasColumnType("NUMBER(5,2)").HasColumnName("OUTMARKS");
                entity.Property(e => e.PcInfo).HasMaxLength(100).IsUnicode(false).HasColumnName("PC_INFO");
                entity.Property(e => e.Scriptsl).HasPrecision(5).HasColumnName("SCRIPTSL");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.SubId).HasPrecision(8).HasColumnName("SUB_ID");
                entity.Property(e => e.TrackId).HasPrecision(7).HasColumnName("TRACK_ID");
            });
            modelBuilder.Entity<MarksAllotExpelledArchive>(entity => {
                entity.HasNoKey();
                entity.ToTable("MARKS_ALLOT_EXPELLED_ARCHIVE");
                entity.Property(e => e.BarCode).HasPrecision(15).HasColumnName("BAR_CODE");
                entity.Property(e => e.Entryuser).HasMaxLength(10).IsUnicode(false).HasColumnName("ENTRYUSER");
                entity.Property(e => e.Examiner).HasPrecision(5).HasColumnName("EXAMINER");
                entity.Property(e => e.Grace).HasColumnType("NUMBER(5,2)").HasColumnName("GRACE");
                entity.Property(e => e.Grade).HasMaxLength(2).IsUnicode(false).HasColumnName("GRADE");
                entity.Property(e => e.Marks).HasColumnType("NUMBER(5,2)").HasColumnName("MARKS");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.Outmarks).HasColumnType("NUMBER(5,2)").HasColumnName("OUTMARKS");
                entity.Property(e => e.Scriptsl).HasPrecision(5).HasColumnName("SCRIPTSL");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.SubId).HasPrecision(8).HasColumnName("SUB_ID");
            });
            modelBuilder.Entity<MarksEditArchive>(entity => {
                entity.HasNoKey();
                entity.ToView("MARKS_EDIT_ARCHIVE");
                entity.Property(e => e.BarCode).HasPrecision(15).HasColumnName("BAR_CODE");
                entity.Property(e => e.ChangeDate).HasColumnType("DATE").HasColumnName("CHANGE_DATE");
                entity.Property(e => e.ChangeUser).HasMaxLength(100).IsUnicode(false).HasColumnName("CHANGE_USER");
                entity.Property(e => e.Entryuser).HasMaxLength(10).IsUnicode(false).HasColumnName("ENTRYUSER");
                entity.Property(e => e.Marks).HasColumnType("NUMBER(5,2)").HasColumnName("MARKS");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.PcInfo).HasMaxLength(100).IsUnicode(false).HasColumnName("PC_INFO");
                entity.Property(e => e.Prevmarks).HasColumnType("NUMBER(5,2)").HasColumnName("PREVMARKS");
                entity.Property(e => e.Scriptsl).HasPrecision(5).HasColumnName("SCRIPTSL");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.SubId).HasPrecision(8).HasColumnName("SUB_ID");
                entity.Property(e => e.TrackId).HasPrecision(7).HasColumnName("TRACK_ID");
            });
            modelBuilder.Entity<Member>(entity => {
                entity.HasKey(e => e.Id);
                entity.ToTable("MEMBER");
                entity.Property(e => e.Id).HasPrecision(10);
                entity.Property(e => e.Cell).HasMaxLength(50).IsUnicode(false).HasColumnName("CELL");
                entity.Property(e => e.Email).HasMaxLength(100).IsUnicode(false).HasColumnName("EMAIL");
                entity.Property(e => e.Enrno).HasPrecision(5).HasColumnName("ENRNO").HasDefaultValueSql("0 ");
                entity.Property(e => e.MemId).HasPrecision(8).HasColumnName("MEM_ID");
                entity.Property(e => e.Name).HasMaxLength(50).IsUnicode(false).HasColumnName("NAME");
                entity.Property(e => e.Prof).IsRequired().HasPrecision(1).HasColumnName("PROF").HasDefaultValueSql("0 ");
            });
            modelBuilder.Entity<MemberArchive1>(entity => {
                entity.HasNoKey();
                entity.ToTable("MEMBER_ARCHIVE");
                entity.Property(e => e.Academic).HasMaxLength(50).IsUnicode(false).HasColumnName("ACADEMIC");
                entity.Property(e => e.Adminyear).HasPrecision(4).HasColumnName("ADMINYEAR");
                entity.Property(e => e.BAdd).HasMaxLength(150).IsUnicode(false).HasColumnName("B_ADD");
                entity.Property(e => e.BloodGr).HasMaxLength(2).IsUnicode(false).HasColumnName("BLOOD_GR");
                entity.Property(e => e.Cell).HasMaxLength(50).IsUnicode(false).HasColumnName("CELL");
                entity.Property(e => e.ChangeDate).HasColumnType("DATE").HasColumnName("CHANGE_DATE");
                entity.Property(e => e.ChildrenNo).HasPrecision(2).HasColumnName("CHILDREN_NO");
                entity.Property(e => e.CountName).HasMaxLength(50).IsUnicode(false).HasColumnName("COUNT_NAME");
                entity.Property(e => e.DateEnr).HasColumnType("DATE").HasColumnName("DATE_ENR");
                entity.Property(e => e.EditDelete).HasMaxLength(6).IsUnicode(false).HasColumnName("EDIT_DELETE");
                entity.Property(e => e.Email).HasMaxLength(100).IsUnicode(false).HasColumnName("EMAIL");
                entity.Property(e => e.Enrno).HasPrecision(5).HasColumnName("ENRNO");
                entity.Property(e => e.FName).HasMaxLength(50).IsUnicode(false).HasColumnName("F_NAME");
                entity.Property(e => e.Fax).HasMaxLength(30).IsUnicode(false).HasColumnName("FAX");
                entity.Property(e => e.MName).HasMaxLength(50).IsUnicode(false).HasColumnName("M_NAME");
                entity.Property(e => e.MemId).HasPrecision(8).HasColumnName("MEM_ID");
                entity.Property(e => e.NId).HasMaxLength(15).IsUnicode(false).HasColumnName("N_ID");
                entity.Property(e => e.Name).HasMaxLength(50).IsUnicode(false).HasColumnName("NAME");
                entity.Property(e => e.P).HasPrecision(1);
                entity.Property(e => e.PassNo).HasMaxLength(10).IsUnicode(false).HasColumnName("PASS_NO");
                entity.Property(e => e.Ph).HasMaxLength(50).IsUnicode(false).HasColumnName("PH");
                entity.Property(e => e.PreAdd).HasMaxLength(200).IsUnicode(false).HasColumnName("PRE_ADD");
                entity.Property(e => e.Prof).HasPrecision(1).HasColumnName("PROF");
                entity.Property(e => e.Res).HasMaxLength(30).IsUnicode(false).HasColumnName("RES");
                entity.Property(e => e.StuReg).HasPrecision(8).HasColumnName("STU_REG");
                entity.Property(e => e.Time).HasMaxLength(10).IsUnicode(false).HasColumnName("TIME");
                entity.Property(e => e.TrackId).HasPrecision(10).HasColumnName("TRACK_ID");
                entity.Property(e => e.UserId).HasPrecision(3).HasColumnName("USER_ID");
                entity.Property(e => e.Web).HasMaxLength(30).IsUnicode(false).HasColumnName("WEB");
            });
            modelBuilder.Entity<Memberarchive>(entity => {
                entity.HasNoKey();
                entity.ToTable("MEMBERARCHIVE");
                entity.Property(e => e.Academic).HasMaxLength(50).IsUnicode(false).HasColumnName("ACADEMIC");
                entity.Property(e => e.Adminyear).HasPrecision(4).HasColumnName("ADMINYEAR");
                entity.Property(e => e.BAdd).HasMaxLength(150).IsUnicode(false).HasColumnName("B_ADD");
                entity.Property(e => e.BloodGr).HasMaxLength(2).IsUnicode(false).HasColumnName("BLOOD_GR");
                entity.Property(e => e.Cell).HasMaxLength(50).IsUnicode(false).HasColumnName("CELL");
                entity.Property(e => e.ChangeDate).HasColumnType("DATE").HasColumnName("CHANGE_DATE");
                entity.Property(e => e.ChildrenNo).HasPrecision(2).HasColumnName("CHILDREN_NO");
                entity.Property(e => e.CountName).HasMaxLength(50).IsUnicode(false).HasColumnName("COUNT_NAME");
                entity.Property(e => e.DateEnr).HasColumnType("DATE").HasColumnName("DATE_ENR");
                entity.Property(e => e.EditDelete).HasMaxLength(6).IsUnicode(false).HasColumnName("EDIT_DELETE");
                entity.Property(e => e.Email).HasMaxLength(100).IsUnicode(false).HasColumnName("EMAIL");
                entity.Property(e => e.Enrno).HasPrecision(5).HasColumnName("ENRNO");
                entity.Property(e => e.Entryuser).HasMaxLength(7).IsUnicode(false).HasColumnName("ENTRYUSER");
                entity.Property(e => e.FName).HasMaxLength(50).IsUnicode(false).HasColumnName("F_NAME");
                entity.Property(e => e.Fax).HasMaxLength(30).IsUnicode(false).HasColumnName("FAX");
                entity.Property(e => e.MName).HasMaxLength(50).IsUnicode(false).HasColumnName("M_NAME");
                entity.Property(e => e.MemId).HasPrecision(8).HasColumnName("MEM_ID");
                entity.Property(e => e.NId).HasMaxLength(15).IsUnicode(false).HasColumnName("N_ID");
                entity.Property(e => e.Name).HasMaxLength(50).IsUnicode(false).HasColumnName("NAME");
                entity.Property(e => e.P).HasPrecision(1);
                entity.Property(e => e.PassNo).HasMaxLength(10).IsUnicode(false).HasColumnName("PASS_NO");
                entity.Property(e => e.Ph).HasMaxLength(50).IsUnicode(false).HasColumnName("PH");
                entity.Property(e => e.PreAdd).HasMaxLength(200).IsUnicode(false).HasColumnName("PRE_ADD");
                entity.Property(e => e.Prof).HasPrecision(1).HasColumnName("PROF");
                entity.Property(e => e.Res).HasMaxLength(30).IsUnicode(false).HasColumnName("RES");
                entity.Property(e => e.StuReg).HasPrecision(8).HasColumnName("STU_REG");
                entity.Property(e => e.Time).HasMaxLength(10).IsUnicode(false).HasColumnName("TIME");
                entity.Property(e => e.TrackId).HasPrecision(7).HasColumnName("TRACK_ID");
                entity.Property(e => e.UserId).HasPrecision(3).HasColumnName("USER_ID");
                entity.Property(e => e.Web).HasMaxLength(30).IsUnicode(false).HasColumnName("WEB");
            });
            modelBuilder.Entity<MouStatus62>(entity => {
                entity.HasNoKey();
                entity.ToTable("MOU_STATUS_62");
                entity.Property(e => e.Appeared).HasPrecision(1).HasColumnName("APPEARED");
                entity.Property(e => e.Bar621).HasPrecision(15).HasColumnName("BAR621");
                entity.Property(e => e.Bar622).HasPrecision(15).HasColumnName("BAR622");
                entity.Property(e => e.Bar623).HasPrecision(15).HasColumnName("BAR623");
                entity.Property(e => e.Bar624).HasPrecision(15).HasColumnName("BAR624");
                entity.Property(e => e.Bar625).HasPrecision(15).HasColumnName("BAR625");
                entity.Property(e => e.Bar626).HasPrecision(15).HasColumnName("BAR626");
                entity.Property(e => e.Bar627).HasPrecision(15).HasColumnName("BAR627");
                entity.Property(e => e.Bar628).HasPrecision(15).HasColumnName("BAR628");
                entity.Property(e => e.Completed).HasPrecision(1).HasColumnName("COMPLETED");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.Exempted).HasPrecision(1).HasColumnName("EXEMPTED");
                entity.Property(e => e.FName).HasMaxLength(70).IsUnicode(false).HasColumnName("F_NAME");
                entity.Property(e => e.G621).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G622).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G623).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G624).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G625).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G626).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G627).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G628).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.Name).HasMaxLength(150).IsUnicode(false).HasColumnName("NAME");
                entity.Property(e => e.Passcount).HasPrecision(2).HasColumnName("PASSCOUNT");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.Sl621).HasPrecision(10).HasColumnName("SL621");
                entity.Property(e => e.Sl622).HasPrecision(10).HasColumnName("SL622");
                entity.Property(e => e.Sl623).HasPrecision(10).HasColumnName("SL623");
                entity.Property(e => e.Sl624).HasPrecision(10).HasColumnName("SL624");
                entity.Property(e => e.Sl625).HasPrecision(10).HasColumnName("SL625");
                entity.Property(e => e.Sl626).HasPrecision(10).HasColumnName("SL626");
                entity.Property(e => e.Sl627).HasPrecision(10).HasColumnName("SL627");
                entity.Property(e => e.Sl628).HasPrecision(10).HasColumnName("SL628");
                entity.Property(e => e.Sub621).HasColumnType("NUMBER(5,2)").HasColumnName("SUB621");
                entity.Property(e => e.Sub622).HasColumnType("NUMBER(5,2)").HasColumnName("SUB622");
                entity.Property(e => e.Sub623).HasColumnType("NUMBER(5,2)").HasColumnName("SUB623");
                entity.Property(e => e.Sub624).HasColumnType("NUMBER(5,2)").HasColumnName("SUB624");
                entity.Property(e => e.Sub625).HasColumnType("NUMBER(5,2)").HasColumnName("SUB625");
                entity.Property(e => e.Sub626).HasColumnType("NUMBER(5,2)").HasColumnName("SUB626");
                entity.Property(e => e.Sub627).HasColumnType("NUMBER(5,2)").HasColumnName("SUB627");
                entity.Property(e => e.Sub628).HasColumnType("NUMBER(5,2)").HasColumnName("SUB628");
            });
            modelBuilder.Entity<MouStatus63>(entity => {
                entity.HasNoKey();
                entity.ToTable("MOU_STATUS_63");
                entity.Property(e => e.Appeared).HasPrecision(1).HasColumnName("APPEARED");
                entity.Property(e => e.Bar631).HasPrecision(15).HasColumnName("BAR631");
                entity.Property(e => e.Bar632).HasPrecision(15).HasColumnName("BAR632");
                entity.Property(e => e.Bar633).HasPrecision(15).HasColumnName("BAR633");
                entity.Property(e => e.Bar634).HasPrecision(15).HasColumnName("BAR634");
                entity.Property(e => e.Bar635).HasPrecision(15).HasColumnName("BAR635");
                entity.Property(e => e.Bar636).HasPrecision(15).HasColumnName("BAR636");
                entity.Property(e => e.Bar637).HasPrecision(15).HasColumnName("BAR637");
                entity.Property(e => e.Bar638).HasPrecision(15).HasColumnName("BAR638");
                entity.Property(e => e.Completed).HasPrecision(1).HasColumnName("COMPLETED");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.Exempted).HasPrecision(1).HasColumnName("EXEMPTED");
                entity.Property(e => e.FName).HasMaxLength(70).IsUnicode(false).HasColumnName("F_NAME");
                entity.Property(e => e.G631).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G632).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G633).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G634).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G635).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G636).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G637).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G638).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.Name).HasMaxLength(150).IsUnicode(false).HasColumnName("NAME");
                entity.Property(e => e.Passcount).HasPrecision(2).HasColumnName("PASSCOUNT");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.Sl631).HasPrecision(10).HasColumnName("SL631");
                entity.Property(e => e.Sl632).HasPrecision(10).HasColumnName("SL632");
                entity.Property(e => e.Sl633).HasPrecision(10).HasColumnName("SL633");
                entity.Property(e => e.Sl634).HasPrecision(10).HasColumnName("SL634");
                entity.Property(e => e.Sl635).HasPrecision(10).HasColumnName("SL635");
                entity.Property(e => e.Sl636).HasPrecision(10).HasColumnName("SL636");
                entity.Property(e => e.Sl637).HasPrecision(10).HasColumnName("SL637");
                entity.Property(e => e.Sl638).HasPrecision(10).HasColumnName("SL638");
                entity.Property(e => e.Sub631).HasColumnType("NUMBER(5,2)").HasColumnName("SUB631");
                entity.Property(e => e.Sub632).HasColumnType("NUMBER(5,2)").HasColumnName("SUB632");
                entity.Property(e => e.Sub633).HasColumnType("NUMBER(5,2)").HasColumnName("SUB633");
                entity.Property(e => e.Sub634).HasColumnType("NUMBER(5,2)").HasColumnName("SUB634");
                entity.Property(e => e.Sub635).HasColumnType("NUMBER(5,2)").HasColumnName("SUB635");
                entity.Property(e => e.Sub636).HasColumnType("NUMBER(5,2)").HasColumnName("SUB636");
                entity.Property(e => e.Sub637).HasColumnType("NUMBER(5,2)").HasColumnName("SUB637");
                entity.Property(e => e.Sub638).HasColumnType("NUMBER(5,2)").HasColumnName("SUB638");
            });
            modelBuilder.Entity<OddsessionMouExmpSub>(entity => {
                entity.HasNoKey();
                entity.ToTable("ODDSESSION_MOU_EXMP_SUB");
                entity.Property(e => e.Calendermonth).HasMaxLength(10).IsUnicode(false).HasColumnName("CALENDERMONTH");
                entity.Property(e => e.Calendermonthid).HasPrecision(2).HasColumnName("CALENDERMONTHID");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.ExamSession).HasPrecision(2).HasColumnName("EXAM_SESSION");
                entity.Property(e => e.ExamYear).HasPrecision(4).HasColumnName("EXAM_YEAR");
                entity.Property(e => e.ExmptSubid).HasPrecision(8).HasColumnName("EXMPT_SUBID");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.Status).HasPrecision(1).HasColumnName("STATUS");
                entity.Property(e => e.StudType).HasPrecision(2).HasColumnName("STUD_TYPE");
                entity.Property(e => e.SubId).HasPrecision(4).HasColumnName("SUB_ID");
                entity.Property(e => e.SubName).HasMaxLength(50).IsUnicode(false).HasColumnName("SUB_NAME");
            });
            modelBuilder.Entity<PassedByExemption>(entity => {
                entity.HasNoKey();
                entity.ToTable("PASSED_BY_EXEMPTION");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.ExamSession).HasPrecision(2).HasColumnName("EXAM_SESSION");
                entity.Property(e => e.ExamYear).HasPrecision(4).HasColumnName("EXAM_YEAR");
                entity.Property(e => e.ExmptSubid).HasPrecision(8).HasColumnName("EXMPT_SUBID");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.StudType).HasPrecision(2).HasColumnName("STUD_TYPE");
            });
            modelBuilder.Entity<Prin>(entity => {
                entity.HasNoKey();
                entity.ToView("PRIN");
                entity.Property(e => e.DateEnr).HasColumnType("DATE").HasColumnName("DATE_ENR");
                entity.Property(e => e.Enrno).HasPrecision(5).HasColumnName("ENRNO");
                entity.Property(e => e.FId).HasPrecision(6).HasColumnName("F_ID");
                entity.Property(e => e.MemId).HasPrecision(8).HasColumnName("MEM_ID");
                entity.Property(e => e.Month).HasMaxLength(2).IsUnicode(false).HasColumnName("MONTH");
                entity.Property(e => e.P).HasPrecision(1);
                entity.Property(e => e.Year).HasMaxLength(4).IsUnicode(false).HasColumnName("YEAR");
            });
            modelBuilder.Entity<Principal>(entity => {
                entity.HasKey(e => e.Id);
                entity.ToTable("PRINCIPAL");
                entity.Property(e => e.Id).HasPrecision(10);
                entity.Property(e => e.EnrNo).HasPrecision(8).HasColumnName("ENR_NO");
                entity.Property(e => e.FId).HasPrecision(6).HasColumnName("F_ID").HasDefaultValueSql("0 ");
                entity.Property(e => e.MemId).HasPrecision(8).HasColumnName("MEM_ID");
                entity.Property(e => e.PreStatus).HasMaxLength(20).IsUnicode(false).HasColumnName("PRE_STATUS");
                entity.Property(e => e.PrinId).HasPrecision(5).HasColumnName("PRIN_ID");
                entity.Property(e => e.DECEASEDDATE).HasColumnType("DATE").HasColumnName("DECEASEDDATE");
            });
            modelBuilder.Entity<ProPartner>(entity => {
                entity.HasKey(e => e.Id);
                entity.ToTable("PRO_PARTNER");
                entity.Property(e => e.FId).HasPrecision(6).HasColumnName("F_ID");
                entity.Property(e => e.MemId).HasPrecision(8).HasColumnName("MEM_ID");
                entity.Property(e => e.Id).HasPrecision(10).HasColumnName("ID");
            });
            modelBuilder.Entity<RegSubject>(entity => {
                entity.HasKey(c => new {
                    c.RefNo,
                    c.SubId
                });
                entity.ToTable("REG_SUBJECT");
                entity.Property(e => e.EntryType).HasPrecision(1).HasColumnName("ENTRY_TYPE");
                entity.Property(e => e.RefNo).HasPrecision(8).HasColumnName("REF_NO");
                entity.Property(e => e.SubId).HasPrecision(4).HasColumnName("SUB_ID");
            });
            modelBuilder.Entity<RegSubjectArch>(entity => {
                entity.HasNoKey();
                entity.ToTable("REG_SUBJECT_ARCH");
                entity.Property(e => e.ChangeId).HasPrecision(8).HasColumnName("CHANGE_ID");
                entity.Property(e => e.EntryType).HasPrecision(1).HasColumnName("ENTRY_TYPE");
                entity.Property(e => e.RefNo).HasPrecision(8).HasColumnName("REF_NO");
                entity.Property(e => e.SubId).HasPrecision(4).HasColumnName("SUB_ID");
            });
            modelBuilder.Entity<ResultBlock>(entity => {
                entity.HasKey(e => e.Id);
                entity.ToTable("RESULT_BLOCK");
                entity.Property(e => e.BlockDate).HasColumnType("DATE").HasColumnName("BLOCK_DATE");
                entity.Property(e => e.Entryuser).HasMaxLength(10).IsUnicode(false).HasColumnName("ENTRYUSER");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.Reason).HasMaxLength(200).IsUnicode(false).HasColumnName("REASON");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.Rollno).HasPrecision(5).HasColumnName("ROLLNO");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.Status).HasMaxLength(10).IsUnicode(false).HasColumnName("STATUS");
            });
            modelBuilder.Entity<ResultBlockArch>(entity => {
                entity.HasKey(e => e.RegNo);
                entity.ToTable("RESULT_BLOCK_ARCH");
                entity.Property(e => e.BackDate).HasColumnType("DATE").HasColumnName("BACK_DATE");
                entity.Property(e => e.BackReason).HasMaxLength(200).IsUnicode(false).HasColumnName("BACK_REASON");
                entity.Property(e => e.BlockDate).HasColumnType("DATE").HasColumnName("BLOCK_DATE");
                entity.Property(e => e.ChangeDate).HasColumnType("DATE").HasColumnName("CHANGE_DATE");
                entity.Property(e => e.ChangeTime).HasMaxLength(8).IsUnicode(false).HasColumnName("CHANGE_TIME");
                entity.Property(e => e.Entryuser).HasMaxLength(10).IsUnicode(false).HasColumnName("ENTRYUSER");
                entity.Property(e => e.Entryuserb).HasMaxLength(10).IsUnicode(false).HasColumnName("ENTRYUSERB");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.Reason).HasMaxLength(200).IsUnicode(false).HasColumnName("REASON");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.Rollno).HasPrecision(5).HasColumnName("ROLLNO");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
            });
            modelBuilder.Entity<ResultLock>(entity => {
                entity.HasKey(c => new {
                    c.ExamLevel,
                    c.MonthId,
                    c.SessionYear
                });
                entity.ToTable("RESULT_LOCK");
                entity.Property(e => e.Entryuser).HasMaxLength(10).IsUnicode(false).HasColumnName("ENTRYUSER");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.RLock).HasPrecision(1).HasColumnName("R_LOCK");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
            });
            modelBuilder.Entity<Roomwiseroll>(entity => {
                entity.HasNoKey();
                entity.ToTable("ROOMWISEROLL");
                entity.Property(e => e.Rollno).HasPrecision(4).HasColumnName("ROLLNO");
                entity.Property(e => e.Roomno).HasPrecision(4).HasColumnName("ROOMNO");
            });
            modelBuilder.Entity<Seatplan>(entity => {
                entity.HasKey(c => new {
                    c.ExamLevel,
                    c.MonthId,
                    c.SessionYear,
                    c.CenId,
                    c.SubId,
                    c.ExamDate,
                    c.Rollfrom,
                    c.Rollto
                });
                entity.ToTable("SEATPLAN");
                entity.Property(e => e.Building).HasMaxLength(120).IsUnicode(false).HasColumnName("BUILDING");
                entity.Property(e => e.CenId).HasPrecision(1).HasColumnName("CEN_ID");
                entity.Property(e => e.ExamDate).HasColumnType("DATE").HasColumnName("EXAM_DATE");
                entity.Property(e => e.ExamLevel).HasPrecision(2).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.Floor).HasMaxLength(115).IsUnicode(false).HasColumnName("FLOOR");
                entity.Property(e => e.MonthId).HasPrecision(1).HasColumnName("MONTH_ID");
                entity.Property(e => e.NoOfSeat).HasPrecision(3).HasColumnName("NO_OF_SEAT");
                entity.Property(e => e.Rollfrom).HasPrecision(4).HasColumnName("ROLLFROM");
                entity.Property(e => e.Rollto).HasPrecision(4).HasColumnName("ROLLTO");
                entity.Property(e => e.RoomNo).HasMaxLength(15).IsUnicode(false).HasColumnName("ROOM_NO");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.SubId).HasPrecision(4).HasColumnName("SUB_ID");
                entity.Property(e => e.Venue).HasMaxLength(150).IsUnicode(false).HasColumnName("VENUE");
            });
            modelBuilder.Entity<SessionInfo>(entity => {
                entity.HasKey(e => e.SessionId);
                entity.ToTable("SESSION_INFO");
                entity.Property(e => e.SessionId).HasPrecision(2).HasColumnName("SESSION_ID");
                entity.Property(e => e.SessionName).HasMaxLength(30).IsUnicode(false).HasColumnName("SESSION_NAME");
                entity.Property(e => e.SessionDetailsName).HasMaxLength(50).IsUnicode(false).HasColumnName("SESSION_DETAILS_NAME");
            });
            modelBuilder.Entity<SetExmpMou>(entity => {
                entity.HasKey(e => e.Id);
                entity.ToTable("SET_EXMP_MOU");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.ExamSession).HasPrecision(2).HasColumnName("EXAM_SESSION");
                entity.Property(e => e.ExamYear).HasPrecision(4).HasColumnName("EXAM_YEAR");
                entity.Property(e => e.ExmptSubid).HasPrecision(8).HasColumnName("EXMPT_SUBID");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.StudType).HasPrecision(2).HasColumnName("STUD_TYPE");
            });
            modelBuilder.Entity<Softwareuser>(entity => {
                entity.HasNoKey();
                entity.ToTable("SOFTWAREUSER");
                entity.Property(e => e.Cbogroup).HasMaxLength(100).IsUnicode(false).HasColumnName("CBOGROUP");
                entity.Property(e => e.Change).HasMaxLength(3).IsUnicode(false).HasColumnName("CHANGE");
                entity.Property(e => e.Fullname).HasMaxLength(100).IsUnicode(false).HasColumnName("FULLNAME");
                entity.Property(e => e.Password).HasMaxLength(100).IsUnicode(false).HasColumnName("PASSWORD");
                entity.Property(e => e.UserStatus).HasMaxLength(10).IsUnicode(false).HasColumnName("USER_STATUS");
                entity.Property(e => e.Username).HasMaxLength(100).IsUnicode(false).HasColumnName("USERNAME");
            });
            modelBuilder.Entity<StuInfoWebAdmit>(entity => {
                entity.HasNoKey();
                entity.ToTable("STU_INFO_WEB_ADMIT");
                entity.Property(e => e.CenAddr).HasMaxLength(200).IsUnicode(false).HasColumnName("CEN_ADDR");
                entity.Property(e => e.CenName).HasMaxLength(30).IsUnicode(false).HasColumnName("CEN_NAME");
                entity.Property(e => e.Dob).HasColumnType("DATE").HasColumnName("DOB");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.Examlevel1).HasMaxLength(100).IsUnicode(false).HasColumnName("EXAMLEVEL");
                entity.Property(e => e.FName).HasMaxLength(100).IsUnicode(false).HasColumnName("F_NAME");
                entity.Property(e => e.Imagepath).HasMaxLength(200).IsUnicode(false).HasColumnName("IMAGEPATH");
                entity.Property(e => e.MName).HasMaxLength(100).IsUnicode(false).HasColumnName("M_NAME");
                entity.Property(e => e.MonthId).HasPrecision(8).HasColumnName("MONTH_ID");
                entity.Property(e => e.Msg).HasPrecision(1).HasColumnName("MSG");
                entity.Property(e => e.Name).HasMaxLength(150).IsUnicode(false).HasColumnName("NAME");
                entity.Property(e => e.PreAdd).HasMaxLength(300).IsUnicode(false).HasColumnName("PRE_ADD");
                entity.Property(e => e.Ref).HasPrecision(8).HasColumnName("REF");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.SessionYear).HasPrecision(8).HasColumnName("SESSION_YEAR");
            });
            modelBuilder.Entity<StuReg1>(entity => {
                entity.HasKey(e => e.RegNo);
                entity.ToTable("STU_REG1");
                entity.Property(e => e.BloodGr).HasMaxLength(2).IsUnicode(false).HasColumnName("BLOOD_GR");
                entity.Property(e => e.Cell).HasMaxLength(50).IsUnicode(false).HasColumnName("CELL");
                entity.Property(e => e.Dob).HasColumnType("DATE").HasColumnName("DOB");
                entity.Property(e => e.Email).HasMaxLength(50).IsUnicode(false).HasColumnName("EMAIL");
                entity.Property(e => e.Entryuser).HasMaxLength(10).IsUnicode(false).HasColumnName("ENTRYUSER");
                entity.Property(e => e.FId).HasPrecision(6).HasColumnName("F_ID");
                entity.Property(e => e.FName).HasMaxLength(70).IsUnicode(false).HasColumnName("F_NAME");
                entity.Property(e => e.Fax).HasMaxLength(30).IsUnicode(false).HasColumnName("FAX");
                entity.Property(e => e.Gender).HasMaxLength(1).IsUnicode(false).HasColumnName("GENDER");
                entity.Property(e => e.Imagepath).HasMaxLength(200).IsUnicode(false).HasColumnName("IMAGEPATH");
                entity.Property(e => e.MName).HasMaxLength(70).IsUnicode(false).HasColumnName("M_NAME");
                entity.Property(e => e.Name).HasMaxLength(150).IsUnicode(false).HasColumnName("NAME");
                entity.Property(e => e.NationalId).HasMaxLength(15).IsUnicode(false).HasColumnName("NATIONAL_ID");
                entity.Property(e => e.Nationality).HasMaxLength(15).IsUnicode(false).HasColumnName("NATIONALITY");
                entity.Property(e => e.PerAdd).HasMaxLength(300).IsUnicode(false).HasColumnName("PER_ADD");
                entity.Property(e => e.PeriodFrom).HasColumnType("DATE").HasColumnName("PERIOD_FROM");
                entity.Property(e => e.PeriodTo).HasColumnType("DATE").HasColumnName("PERIOD_TO");
                entity.Property(e => e.Ph).HasMaxLength(50).IsUnicode(false).HasColumnName("PH");
                entity.Property(e => e.PreAdd).HasMaxLength(300).IsUnicode(false).HasColumnName("PRE_ADD");
                entity.Property(e => e.PrinEnrNo).HasPrecision(8).HasColumnName("PRIN_ENR_NO");
                entity.Property(e => e.RegDate).HasColumnType("DATE").HasColumnName("REG_DATE");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.RegYear).HasPrecision(4).HasColumnName("REG_YEAR");
                entity.Property(e => e.Religion).HasMaxLength(10).IsUnicode(false).HasColumnName("RELIGION");
                entity.Property(e => e.StudType).HasPrecision(2).HasColumnName("STUD_TYPE");
                entity.Property(e => e.Imageapprovalpending).HasPrecision(1).HasColumnName("IMAGEAPPROVALPENDING");
                entity.Property(e => e.UserDobChangeLimit).HasPrecision(10, 0).HasColumnName("USERDOBCHANGELIMIT");
                entity.Property(e => e.Salutation).HasMaxLength(20).IsUnicode(false).HasColumnName("SALUTATION");
                entity.Property(e => e.AltMobNo).HasMaxLength(20).IsUnicode(false).HasColumnName("ALT_MOB_NO");
                entity.Property(e => e.FirmName).HasMaxLength(100).IsUnicode(false).HasColumnName("FIRM_NAME");
                entity.Property(e => e.PrinName).HasMaxLength(50).IsUnicode(false).HasColumnName("PRIN_NAME");
                entity.Property(e => e.PrinID).HasColumnType("NUMBER").HasColumnName("PRIN_ID").HasDefaultValueSql("0");
                entity.Property(e => e.ArticleSname).HasMaxLength(8).IsUnicode(false).HasColumnName("ARTICLE_SNAME");
                entity.Property(e => e.GenStuType).HasColumnType("NUMBER").HasColumnName("GENSTU_TYPE").HasDefaultValueSql("0");
                entity.Property(e => e.RequestedImagepath).HasMaxLength(200).IsUnicode(false).HasColumnName("REQUESTED_IMAGEPATH");
            });
            modelBuilder.Entity<StuReg1Arch>(entity => {
                entity.HasKey(e => new {
                    e.RegNo,
                    e.ChangeId
                });
                entity.ToTable("STU_REG1_ARCH");
                entity.Property(e => e.BloodGr).HasMaxLength(2).IsUnicode(false).HasColumnName("BLOOD_GR");
                entity.Property(e => e.Cell).HasMaxLength(50).IsUnicode(false).HasColumnName("CELL");
                entity.Property(e => e.ChangeDate).HasColumnType("DATE").HasColumnName("CHANGE_DATE");
                entity.Property(e => e.ChangeId).HasPrecision(8).HasColumnName("CHANGE_ID");
                entity.Property(e => e.ChangeTime).HasMaxLength(8).IsUnicode(false).HasColumnName("CHANGE_TIME");
                entity.Property(e => e.ChangeUser).HasMaxLength(10).IsUnicode(false).HasColumnName("CHANGE_USER");
                entity.Property(e => e.Dob).HasColumnType("DATE").HasColumnName("DOB");
                entity.Property(e => e.EditDelete).HasMaxLength(6).IsUnicode(false).HasColumnName("EDIT_DELETE");
                entity.Property(e => e.Email).HasMaxLength(50).IsUnicode(false).HasColumnName("EMAIL");
                entity.Property(e => e.Entryuser).HasMaxLength(10).IsUnicode(false).HasColumnName("ENTRYUSER");
                entity.Property(e => e.FId).HasPrecision(6).HasColumnName("F_ID");
                entity.Property(e => e.FName).HasMaxLength(70).IsUnicode(false).HasColumnName("F_NAME");
                entity.Property(e => e.Fax).HasMaxLength(30).IsUnicode(false).HasColumnName("FAX");
                entity.Property(e => e.Gender).HasMaxLength(1).IsUnicode(false).HasColumnName("GENDER");
                entity.Property(e => e.Imagepath).HasMaxLength(200).IsUnicode(false).HasColumnName("IMAGEPATH");
                entity.Property(e => e.MName).HasMaxLength(70).IsUnicode(false).HasColumnName("M_NAME");
                entity.Property(e => e.Name).HasMaxLength(150).IsUnicode(false).HasColumnName("NAME");
                entity.Property(e => e.NationalId).HasMaxLength(15).IsUnicode(false).HasColumnName("NATIONAL_ID");
                entity.Property(e => e.Nationality).HasMaxLength(15).IsUnicode(false).HasColumnName("NATIONALITY");
                entity.Property(e => e.PerAdd).HasMaxLength(300).IsUnicode(false).HasColumnName("PER_ADD");
                entity.Property(e => e.PeriodFrom).HasColumnType("DATE").HasColumnName("PERIOD_FROM");
                entity.Property(e => e.PeriodTo).HasColumnType("DATE").HasColumnName("PERIOD_TO");
                entity.Property(e => e.Ph).HasMaxLength(50).IsUnicode(false).HasColumnName("PH");
                entity.Property(e => e.PreAdd).HasMaxLength(300).IsUnicode(false).HasColumnName("PRE_ADD");
                entity.Property(e => e.PrinEnrNo).HasPrecision(8).HasColumnName("PRIN_ENR_NO");
                entity.Property(e => e.RegDate).HasColumnType("DATE").HasColumnName("REG_DATE");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.RegYear).HasPrecision(4).HasColumnName("REG_YEAR");
                entity.Property(e => e.Religion).HasMaxLength(10).IsUnicode(false).HasColumnName("RELIGION");
                entity.Property(e => e.StudType).HasPrecision(2).HasColumnName("STUD_TYPE");
                entity.Property(e => e.Defaultimage).HasColumnType("BLOB").HasColumnName("DEFAULTIMAGE");
            });
            modelBuilder.Entity<StuReg1ModExam>(entity => {
                entity.HasNoKey();
                entity.ToTable("STU_REG1_MOD_EXAM");
                entity.Property(e => e.BloodGr).HasMaxLength(2).IsUnicode(false).HasColumnName("BLOOD_GR");
                entity.Property(e => e.Cell).HasMaxLength(50).IsUnicode(false).HasColumnName("CELL");
                entity.Property(e => e.Dob).HasColumnType("DATE").HasColumnName("DOB");
                entity.Property(e => e.Email).HasMaxLength(50).IsUnicode(false).HasColumnName("EMAIL");
                entity.Property(e => e.Entryuser).HasMaxLength(10).IsUnicode(false).HasColumnName("ENTRYUSER");
                entity.Property(e => e.FId).HasPrecision(6).HasColumnName("F_ID");
                entity.Property(e => e.FName).HasMaxLength(70).IsUnicode(false).HasColumnName("F_NAME");
                entity.Property(e => e.Fax).HasMaxLength(30).IsUnicode(false).HasColumnName("FAX");
                entity.Property(e => e.Gender).HasMaxLength(1).IsUnicode(false).HasColumnName("GENDER");
                entity.Property(e => e.Imagepath).HasMaxLength(200).IsUnicode(false).HasColumnName("IMAGEPATH");
                entity.Property(e => e.MName).HasMaxLength(70).IsUnicode(false).HasColumnName("M_NAME");
                entity.Property(e => e.MonthId).HasPrecision(1).HasColumnName("MONTH_ID");
                entity.Property(e => e.Name).HasMaxLength(100).IsUnicode(false).HasColumnName("NAME");
                entity.Property(e => e.NationalId).HasMaxLength(15).IsUnicode(false).HasColumnName("NATIONAL_ID");
                entity.Property(e => e.Nationality).HasMaxLength(15).IsUnicode(false).HasColumnName("NATIONALITY");
                entity.Property(e => e.PerAdd).HasMaxLength(300).IsUnicode(false).HasColumnName("PER_ADD");
                entity.Property(e => e.PeriodFrom).HasColumnType("DATE").HasColumnName("PERIOD_FROM");
                entity.Property(e => e.PeriodTo).HasColumnType("DATE").HasColumnName("PERIOD_TO");
                entity.Property(e => e.Ph).HasMaxLength(50).IsUnicode(false).HasColumnName("PH");
                entity.Property(e => e.PreAdd).HasMaxLength(300).IsUnicode(false).HasColumnName("PRE_ADD");
                entity.Property(e => e.PrinEnrNo).HasPrecision(8).HasColumnName("PRIN_ENR_NO");
                entity.Property(e => e.RegDate).HasColumnType("DATE").HasColumnName("REG_DATE");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.RegYear).HasPrecision(4).HasColumnName("REG_YEAR");
                entity.Property(e => e.Religion).HasMaxLength(10).IsUnicode(false).HasColumnName("RELIGION");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.StudType).HasPrecision(2).HasColumnName("STUD_TYPE");
            });
            modelBuilder.Entity<StuReg2>(entity => {
                entity.HasKey(e => new {
                    e.RegNo,
                    e.ExamName
                });
                entity.ToTable("STU_REG2");
                entity.Property(e => e.AcademicLevel).HasMaxLength(50).IsUnicode(false).HasColumnName("ACADEMIC_LEVEL");
                entity.Property(e => e.BoardUni).HasMaxLength(150).IsUnicode(false).HasColumnName("BOARD_UNI");
                entity.Property(e => e.ExamName).HasMaxLength(20).IsUnicode(false).HasColumnName("EXAM_NAME");
                entity.Property(e => e.Group).HasMaxLength(50).IsUnicode(false).HasColumnName("GROUP");
                entity.Property(e => e.PassYear).HasPrecision(4).HasColumnName("PASS_YEAR");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.ResultDiv).HasPrecision(1).HasColumnName("RESULT_DIV");
                entity.Property(e => e.ResultGpa).HasColumnType("NUMBER(3,2)").HasColumnName("RESULT_GPA");
                entity.Property(e => e.ResultOutOfGpa).HasColumnType("NUMBER(3,2)").HasColumnName("RESULT_OUT_OF_GPA");
                entity.Property(e => e.ResultProf).HasMaxLength(50).IsUnicode(false).HasColumnName("RESULT_PROF");
                entity.Property(e => e.CertificationLevel).HasMaxLength(50).IsUnicode(false).HasColumnName("CERTIFICATION_LEVEL");
                entity.Property(e => e.Institute).HasMaxLength(50).IsUnicode(false).HasColumnName("INSTITUTE");
            });
            modelBuilder.Entity<StuReg2Arch>(entity => {
                entity.HasKey(e => new {
                    e.RegNo,
                    e.ExamName,
                    e.ChangeId
                });
                entity.ToTable("STU_REG2_ARCH");
                entity.Property(e => e.AcademicLevel).HasMaxLength(50).IsUnicode(false).HasColumnName("ACADEMIC_LEVEL");
                entity.Property(e => e.BoardUni).HasMaxLength(50).IsUnicode(false).HasColumnName("BOARD_UNI");
                entity.Property(e => e.ChangeId).HasPrecision(8).HasColumnName("CHANGE_ID");
                entity.Property(e => e.ExamName).HasMaxLength(20).IsUnicode(false).HasColumnName("EXAM_NAME");
                entity.Property(e => e.Group).HasMaxLength(50).IsUnicode(false).HasColumnName("GROUP");
                entity.Property(e => e.PassYear).HasPrecision(4).HasColumnName("PASS_YEAR");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.ResultDiv).HasPrecision(1).HasColumnName("RESULT_DIV");
                entity.Property(e => e.ResultGpa).HasColumnType("NUMBER(3,2)").HasColumnName("RESULT_GPA");
                entity.Property(e => e.ResultOutOfGpa).HasColumnType("NUMBER(3,2)").HasColumnName("RESULT_OUT_OF_GPA");
                entity.Property(e => e.ResultProf).HasMaxLength(10).IsUnicode(false).HasColumnName("RESULT_PROF");
            });
            modelBuilder.Entity<StuCancel>(entity => {
                entity.HasKey(e => e.Id);
                entity.ToTable("STU_CANCEL");
                entity.Property(e => e.Id).HasPrecision(9).HasColumnType("NUMBER").ValueGeneratedOnAdd().HasColumnName("ID");
                entity.Property(e => e.CancellationDate).HasColumnType("DATE").HasColumnName("CANCELLATION_DATE").HasDefaultValueSql("SYSDATE");
                entity.Property(e => e.WithdrawnDate).HasColumnType("DATE").HasColumnName("WITHDRAWN_DATE");
                entity.Property(e => e.CwFlag).HasPrecision(2).HasColumnName("CW_FLAG").HasDefaultValueSql("0 ");
                entity.Property(e => e.CwReason).HasMaxLength(200).IsUnicode(false).HasColumnName("CW_REASON");
                entity.Property(e => e.ExamLevel).HasPrecision(2).HasColumnName("EXAM_LEVEL");
                //entity.Property(e => e.ExamRollno).HasColumnType("NUMBER").HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.Periodfrom).HasColumnType("DATE").HasColumnName("PERIODFROM").HasDefaultValueSql("SYSDATE");
                entity.Property(e => e.Periodto).HasColumnType("DATE").HasColumnName("PERIODTO").HasDefaultValueSql("SYSDATE");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
            });
            modelBuilder.Entity<Student>(entity => {
                entity.Property(e => e.Id).HasPrecision(10);
            });
            modelBuilder.Entity<StudentExpelled>(entity => {
                entity.HasKey(e => e.RegNo);
                entity.ToTable("STUDENT_EXPELLED");
                entity.Property(e => e.Entryuser).HasMaxLength(10).IsUnicode(false).HasColumnName("ENTRYUSER");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                //entity.Property(e => e.ExamYear).HasPrecision(4).HasColumnName("EXAM_YEAR");
                //entity.Property(e => e.ExamcenId).HasPrecision(2).HasColumnName("EXAMCEN_ID");
                //entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.Reason).HasMaxLength(200).IsUnicode(false).HasColumnName("REASON");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                //entity.Property(e => e.Rollno).HasPrecision(10).HasColumnName("ROLLNO");
                entity.Property(e => e.SessionFrom).HasPrecision(4).HasColumnName("SESSION_FROM");
                entity.Property(e => e.SessionTo).HasPrecision(4).HasColumnName("SESSION_TO");
                entity.Property(e => e.Status).HasMaxLength(20).IsUnicode(false).HasColumnName("STATUS");
                entity.Property(e => e.YearFrom).HasPrecision(4).IsUnicode(false).HasColumnName("YEAR_FROM");
                entity.Property(e => e.YearTo).HasPrecision(4).IsUnicode(false).HasColumnName("YEAR_TO");
                entity.Property(e => e.ExpulsionDate).HasColumnName("EXPULSION_DATE");
                entity.Property(e => e.WithdrawnDate).HasColumnName("WITHDRAWN_DATE");
            });
            modelBuilder.Entity<StudentExpelledArch>(entity => {
                entity.HasNoKey();
                entity.ToTable("STUDENT_EXPELLED_ARCH");
                entity.Property(e => e.ChangeDate).HasColumnType("DATE").HasColumnName("CHANGE_DATE");
                entity.Property(e => e.ChangeTime).HasMaxLength(8).IsUnicode(false).HasColumnName("CHANGE_TIME");
                entity.Property(e => e.EditDelete).HasMaxLength(6).IsUnicode(false).HasColumnName("EDIT_DELETE");
                entity.Property(e => e.Entryuser).HasMaxLength(10).IsUnicode(false).HasColumnName("ENTRYUSER");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.ExamYear).HasPrecision(4).HasColumnName("EXAM_YEAR");
                entity.Property(e => e.ExamcenId).HasPrecision(2).HasColumnName("EXAMCEN_ID");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.Reason).HasMaxLength(200).IsUnicode(false).HasColumnName("REASON");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.Rollno).HasPrecision(10).HasColumnName("ROLLNO");
                entity.Property(e => e.SessionFrom).HasPrecision(4).HasColumnName("SESSION_FROM");
                entity.Property(e => e.SessionTo).HasPrecision(4).HasColumnName("SESSION_TO");
                entity.Property(e => e.Status).HasMaxLength(20).IsUnicode(false).HasColumnName("STATUS");
                entity.Property(e => e.YearFrom).HasMaxLength(4).IsUnicode(false).HasColumnName("YEAR_FROM");
                entity.Property(e => e.YearTo).HasMaxLength(4).IsUnicode(false).HasColumnName("YEAR_TO");
            });
            modelBuilder.Entity<StudentOfIcmabAcca>(entity => {
                entity.HasKey(e => new {
                    e.ExamLevel,
                    e.ExamSession,
                    e.ExamYear,
                    e.SubId,
                    e.RegNo,
                    e.StudType
                });
                entity.ToTable("STUDENT_OF_ICMAB_ACCA");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.ExamSession).HasPrecision(2).HasColumnName("EXAM_SESSION");
                entity.Property(e => e.ExamYear).HasPrecision(4).HasColumnName("EXAM_YEAR");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.StudType).HasPrecision(2).HasColumnName("STUD_TYPE");
                entity.Property(e => e.SubId).HasPrecision(8).HasColumnName("SUB_ID");
            });
            modelBuilder.Entity<StudentRegCancelation>(entity => {
                entity.ToTable("STUDENT_REG_CANCELATION");
                entity.Property(e => e.Id).HasPrecision(10);
                entity.Property(e => e.CanDate).HasColumnType("DATE").HasColumnName("CAN_DATE");
                entity.Property(e => e.Entryuser).HasMaxLength(10).IsUnicode(false).HasColumnName("ENTRYUSER");
                entity.Property(e => e.Firmname).HasMaxLength(200).IsUnicode(false).HasColumnName("FIRMNAME");
                entity.Property(e => e.Fname).HasMaxLength(200).IsUnicode(false).HasColumnName("FNAME");
                entity.Property(e => e.Name).HasMaxLength(200).IsUnicode(false).HasColumnName("NAME");
                entity.Property(e => e.PrinName).HasMaxLength(200).IsUnicode(false).HasColumnName("PRIN_NAME");
                entity.Property(e => e.Reason).HasMaxLength(200).IsUnicode(false).HasColumnName("REASON");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.Status).HasMaxLength(15).IsUnicode(false).HasColumnName("STATUS");
            });
            modelBuilder.Entity<StudentType>(entity => {
                entity.ToTable("STUDENT_TYPE");
                entity.Property(e => e.Id).HasPrecision(10);
                entity.Property(e => e.StudId).HasPrecision(2).HasColumnName("STUD_ID");
                entity.Property(e => e.StudType).HasMaxLength(150).IsUnicode(false).HasColumnName("STUD_TYPE");
            });
            modelBuilder.Entity<Stutype23exempsub>(entity => {
                entity.HasNoKey();
                entity.ToTable("STUTYPE23EXEMPSUB");
                entity.Property(e => e.AttenAttached).HasMaxLength(1).IsUnicode(false).HasColumnName("ATTEN_ATTACHED");
                entity.Property(e => e.EntryType).HasPrecision(1).HasColumnName("ENTRY_TYPE");
                entity.Property(e => e.Entryuser).HasMaxLength(10).IsUnicode(false).HasColumnName("ENTRYUSER");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.ExamcenId).HasPrecision(2).HasColumnName("EXAMCEN_ID");
                entity.Property(e => e.FName).HasMaxLength(70).IsUnicode(false).HasColumnName("F_NAME");
                entity.Property(e => e.FillupDate).HasColumnType("DATE").HasColumnName("FILLUP_DATE");
                entity.Property(e => e.FitnessAttached).HasMaxLength(1).IsUnicode(false).HasColumnName("FITNESS_ATTACHED");
                entity.Property(e => e.FormNo).HasMaxLength(9).IsUnicode(false).HasColumnName("FORM_NO");
                entity.Property(e => e.LastAppearedExamlevel).HasPrecision(8).HasColumnName("LAST_APPEARED_EXAMLEVEL");
                entity.Property(e => e.LastAppearedMonthid).HasPrecision(2).HasColumnName("LAST_APPEARED_MONTHID");
                entity.Property(e => e.LastAppearedRollno).HasPrecision(8).HasColumnName("LAST_APPEARED_ROLLNO");
                entity.Property(e => e.LastAppearedYear).HasPrecision(4).HasColumnName("LAST_APPEARED_YEAR");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.Name).HasMaxLength(150).IsUnicode(false).HasColumnName("NAME");
                entity.Property(e => e.ReasonInvalid).HasMaxLength(200).IsUnicode(false).HasColumnName("REASON_INVALID");
                entity.Property(e => e.Ref).HasPrecision(8).HasColumnName("REF");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.StudType).HasPrecision(2).HasColumnName("STUD_TYPE");
                entity.Property(e => e.TrainingAttached).HasMaxLength(1).IsUnicode(false).HasColumnName("TRAINING_ATTACHED");
                entity.Property(e => e.TrainingEnd).HasColumnType("DATE").HasColumnName("TRAINING_END");
                entity.Property(e => e.TrainingSt).HasColumnType("DATE").HasColumnName("TRAINING_ST");
                entity.Property(e => e.Validity).HasPrecision(1).HasColumnName("VALIDITY");
            });
            modelBuilder.Entity<Subject>(entity => {
                entity.HasKey(e => e.SubId);
                entity.ToTable("SUBJECT");
                entity.HasIndex(e => e.SubId, "PK_SUB_ID").IsUnique();
                entity.Property(e => e.Depth).HasPrecision(1).HasColumnName("DEPTH");
                entity.Property(e => e.Entryuser).HasMaxLength(15).IsUnicode(false).HasColumnName("ENTRYUSER");
                entity.Property(e => e.Lr).HasMaxLength(1).IsUnicode(false).HasColumnName("LR");
                entity.Property(e => e.Parent).HasPrecision(4).HasColumnName("PARENT");
                entity.Property(e => e.SubCode).HasMaxLength(4).IsUnicode(false).HasColumnName("SUB_CODE");
                entity.Property(e => e.SubId).HasPrecision(4).HasColumnName("SUB_ID");
                entity.Property(e => e.SubName).HasMaxLength(50).IsUnicode(false).HasColumnName("SUB_NAME");
                entity.Property(e => e.SubOrder).HasPrecision(2).HasColumnName("SUB_ORDER");
                entity.Property(e => e.Topparent).HasPrecision(4).HasColumnName("TOPPARENT");
                entity.Property(e => e.UdsubCode).HasPrecision(4).HasColumnName("UDSUB_CODE");
                entity.Property(e => e.Outofmarks).HasPrecision(3).HasColumnName("OUTOFMARKS").HasDefaultValueSql("0 ");
            });
            modelBuilder.Entity<TabLevel1>(entity => {
                entity.HasNoKey();
                entity.ToTable("TAB_LEVEL_1");
                entity.Property(e => e.Appeared).HasPrecision(1).HasColumnName("APPEARED");
                entity.Property(e => e.Bar11).HasPrecision(15).HasColumnName("BAR11");
                entity.Property(e => e.Bar12).HasPrecision(15).HasColumnName("BAR12");
                entity.Property(e => e.Bar13).HasPrecision(15).HasColumnName("BAR13");
                entity.Property(e => e.Bar14).HasPrecision(15).HasColumnName("BAR14");
                entity.Property(e => e.Bar15).HasPrecision(15).HasColumnName("BAR15");
                entity.Property(e => e.Bar16).HasPrecision(15).HasColumnName("BAR16");
                entity.Property(e => e.Bar17).HasPrecision(15).HasColumnName("BAR17");
                entity.Property(e => e.Bar18).HasPrecision(15).HasColumnName("BAR18");
                entity.Property(e => e.Completed).HasPrecision(1).HasColumnName("COMPLETED");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.Exempted).HasPrecision(1).HasColumnName("EXEMPTED");
                entity.Property(e => e.G11).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G12).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G13).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G14).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G15).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G16).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G17).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G18).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.Passcount).HasPrecision(2).HasColumnName("PASSCOUNT");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.Sl11).HasPrecision(10).HasColumnName("SL11");
                entity.Property(e => e.Sl12).HasPrecision(10).HasColumnName("SL12");
                entity.Property(e => e.Sl13).HasPrecision(10).HasColumnName("SL13");
                entity.Property(e => e.Sl14).HasPrecision(10).HasColumnName("SL14");
                entity.Property(e => e.Sl15).HasPrecision(10).HasColumnName("SL15");
                entity.Property(e => e.Sl16).HasPrecision(10).HasColumnName("SL16");
                entity.Property(e => e.Sl17).HasPrecision(10).HasColumnName("SL17");
                entity.Property(e => e.Sl18).HasPrecision(10).HasColumnName("SL18");
                entity.Property(e => e.Sub11).HasColumnType("NUMBER(5,2)").HasColumnName("SUB11");
                entity.Property(e => e.Sub12).HasColumnType("NUMBER(5,2)").HasColumnName("SUB12");
                entity.Property(e => e.Sub13).HasColumnType("NUMBER(5,2)").HasColumnName("SUB13");
                entity.Property(e => e.Sub14).HasColumnType("NUMBER(5,2)").HasColumnName("SUB14");
                entity.Property(e => e.Sub15).HasColumnType("NUMBER(5,2)").HasColumnName("SUB15");
                entity.Property(e => e.Sub16).HasColumnType("NUMBER(5,2)").HasColumnName("SUB16");
                entity.Property(e => e.Sub17).HasColumnType("NUMBER(5,2)").HasColumnName("SUB17");
                entity.Property(e => e.Sub18).HasColumnType("NUMBER(5,2)").HasColumnName("SUB18");
            });
            modelBuilder.Entity<TabLevel2>(entity => {
                entity.HasNoKey();
                entity.ToTable("TAB_LEVEL_2");
                entity.Property(e => e.Appeared).HasPrecision(1).HasColumnName("APPEARED");
                entity.Property(e => e.Bar21).HasPrecision(15).HasColumnName("BAR21");
                entity.Property(e => e.Bar22).HasPrecision(15).HasColumnName("BAR22");
                entity.Property(e => e.Bar23).HasPrecision(15).HasColumnName("BAR23");
                entity.Property(e => e.Bar24).HasPrecision(15).HasColumnName("BAR24");
                entity.Property(e => e.Bar25).HasPrecision(15).HasColumnName("BAR25");
                entity.Property(e => e.Bar26).HasPrecision(15).HasColumnName("BAR26");
                entity.Property(e => e.Bar27).HasPrecision(15).HasColumnName("BAR27");
                entity.Property(e => e.Bar28).HasPrecision(15).HasColumnName("BAR28");
                entity.Property(e => e.Completed).HasPrecision(1).HasColumnName("COMPLETED");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.Exempted).HasPrecision(1).HasColumnName("EXEMPTED");
                entity.Property(e => e.G21).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G22).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G23).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G24).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G25).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G26).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G27).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G28).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.Passcount).HasPrecision(2).HasColumnName("PASSCOUNT");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.Sl21).HasPrecision(10).HasColumnName("SL21");
                entity.Property(e => e.Sl22).HasPrecision(10).HasColumnName("SL22");
                entity.Property(e => e.Sl23).HasPrecision(10).HasColumnName("SL23");
                entity.Property(e => e.Sl24).HasPrecision(10).HasColumnName("SL24");
                entity.Property(e => e.Sl25).HasPrecision(10).HasColumnName("SL25");
                entity.Property(e => e.Sl26).HasPrecision(10).HasColumnName("SL26");
                entity.Property(e => e.Sl27).HasPrecision(10).HasColumnName("SL27");
                entity.Property(e => e.Sl28).HasPrecision(10).HasColumnName("SL28");
                entity.Property(e => e.Sub21).HasColumnType("NUMBER(5,2)").HasColumnName("SUB21");
                entity.Property(e => e.Sub22).HasColumnType("NUMBER(5,2)").HasColumnName("SUB22");
                entity.Property(e => e.Sub23).HasColumnType("NUMBER(5,2)").HasColumnName("SUB23");
                entity.Property(e => e.Sub24).HasColumnType("NUMBER(5,2)").HasColumnName("SUB24");
                entity.Property(e => e.Sub25).HasColumnType("NUMBER(5,2)").HasColumnName("SUB25");
                entity.Property(e => e.Sub26).HasColumnType("NUMBER(5,2)").HasColumnName("SUB26");
                entity.Property(e => e.Sub27).HasColumnType("NUMBER(5,2)").HasColumnName("SUB27");
                entity.Property(e => e.Sub28).HasColumnType("NUMBER(5,2)").HasColumnName("SUB28");
            });
            modelBuilder.Entity<TabLevel3>(entity => {
                entity.HasNoKey();
                entity.ToTable("TAB_LEVEL_3");
                entity.Property(e => e.Appeared).HasPrecision(1).HasColumnName("APPEARED");
                entity.Property(e => e.Bar31).HasPrecision(15).HasColumnName("BAR31");
                entity.Property(e => e.Bar32).HasPrecision(15).HasColumnName("BAR32");
                entity.Property(e => e.Bar33).HasPrecision(15).HasColumnName("BAR33");
                entity.Property(e => e.Bar34).HasPrecision(15).HasColumnName("BAR34");
                entity.Property(e => e.Bar35).HasPrecision(15).HasColumnName("BAR35");
                entity.Property(e => e.Bar36).HasPrecision(15).HasColumnName("BAR36");
                entity.Property(e => e.Bar37).HasPrecision(15).HasColumnName("BAR37");
                entity.Property(e => e.Bar38).HasPrecision(15).HasColumnName("BAR38");
                entity.Property(e => e.Completed).HasPrecision(1).HasColumnName("COMPLETED");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.Exempted).HasPrecision(1).HasColumnName("EXEMPTED");
                entity.Property(e => e.G31).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G32).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G33).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G34).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G35).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G36).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G37).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G38).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.Passcount).HasPrecision(2).HasColumnName("PASSCOUNT");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.Sl31).HasPrecision(10).HasColumnName("SL31");
                entity.Property(e => e.Sl32).HasPrecision(10).HasColumnName("SL32");
                entity.Property(e => e.Sl33).HasPrecision(10).HasColumnName("SL33");
                entity.Property(e => e.Sl34).HasPrecision(10).HasColumnName("SL34");
                entity.Property(e => e.Sl35).HasPrecision(10).HasColumnName("SL35");
                entity.Property(e => e.Sl36).HasPrecision(10).HasColumnName("SL36");
                entity.Property(e => e.Sl37).HasPrecision(10).HasColumnName("SL37");
                entity.Property(e => e.Sl38).HasPrecision(10).HasColumnName("SL38");
                entity.Property(e => e.Sub31).HasColumnType("NUMBER(5,2)").HasColumnName("SUB31");
                entity.Property(e => e.Sub32).HasColumnType("NUMBER(5,2)").HasColumnName("SUB32");
                entity.Property(e => e.Sub33).HasColumnType("NUMBER(5,2)").HasColumnName("SUB33");
                entity.Property(e => e.Sub34).HasColumnType("NUMBER(5,2)").HasColumnName("SUB34");
                entity.Property(e => e.Sub35).HasColumnType("NUMBER(5,2)").HasColumnName("SUB35");
                entity.Property(e => e.Sub36).HasColumnType("NUMBER(5,2)").HasColumnName("SUB36");
                entity.Property(e => e.Sub37).HasColumnType("NUMBER(5,2)").HasColumnName("SUB37");
                entity.Property(e => e.Sub38).HasColumnType("NUMBER(5,2)").HasColumnName("SUB38");
            });
            modelBuilder.Entity<TabLevel41>(entity => {
                entity.HasNoKey();
                entity.ToTable("TAB_LEVEL_41");
                entity.Property(e => e.Appeared).HasPrecision(1).HasColumnName("APPEARED");
                entity.Property(e => e.Bar411).HasPrecision(15).HasColumnName("BAR411");
                entity.Property(e => e.Bar412).HasPrecision(15).HasColumnName("BAR412");
                entity.Property(e => e.Bar413).HasPrecision(15).HasColumnName("BAR413");
                entity.Property(e => e.Bar414).HasPrecision(15).HasColumnName("BAR414");
                entity.Property(e => e.Bar415).HasPrecision(15).HasColumnName("BAR415");
                entity.Property(e => e.Bar416).HasPrecision(15).HasColumnName("BAR416");
                entity.Property(e => e.Bar417).HasPrecision(15).HasColumnName("BAR417");
                entity.Property(e => e.Bar418).HasPrecision(15).HasColumnName("BAR418");
                entity.Property(e => e.Completed).HasPrecision(1).HasColumnName("COMPLETED");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.Exempted).HasPrecision(1).HasColumnName("EXEMPTED");
                entity.Property(e => e.G411).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G412).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G413).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G414).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G415).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G416).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G417).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G418).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.Passcount).HasPrecision(2).HasColumnName("PASSCOUNT");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.Sl411).HasPrecision(10).HasColumnName("SL411");
                entity.Property(e => e.Sl412).HasPrecision(10).HasColumnName("SL412");
                entity.Property(e => e.Sl413).HasPrecision(10).HasColumnName("SL413");
                entity.Property(e => e.Sl414).HasPrecision(10).HasColumnName("SL414");
                entity.Property(e => e.Sl415).HasPrecision(10).HasColumnName("SL415");
                entity.Property(e => e.Sl416).HasPrecision(10).HasColumnName("SL416");
                entity.Property(e => e.Sl417).HasPrecision(10).HasColumnName("SL417");
                entity.Property(e => e.Sl418).HasPrecision(10).HasColumnName("SL418");
                entity.Property(e => e.Sub411).HasColumnType("NUMBER(5,2)").HasColumnName("SUB411");
                entity.Property(e => e.Sub412).HasColumnType("NUMBER(5,2)").HasColumnName("SUB412");
                entity.Property(e => e.Sub413).HasColumnType("NUMBER(5,2)").HasColumnName("SUB413");
                entity.Property(e => e.Sub414).HasColumnType("NUMBER(5,2)").HasColumnName("SUB414");
                entity.Property(e => e.Sub415).HasColumnType("NUMBER(5,2)").HasColumnName("SUB415");
                entity.Property(e => e.Sub416).HasColumnType("NUMBER(5,2)").HasColumnName("SUB416");
                entity.Property(e => e.Sub417).HasColumnType("NUMBER(5,2)").HasColumnName("SUB417");
                entity.Property(e => e.Sub418).HasColumnType("NUMBER(5,2)").HasColumnName("SUB418");
            });
            modelBuilder.Entity<TabLevel42>(entity => {
                entity.HasNoKey();
                entity.ToTable("TAB_LEVEL_42");
                entity.Property(e => e.Appeared).HasPrecision(1).HasColumnName("APPEARED");
                entity.Property(e => e.Bar421).HasPrecision(15).HasColumnName("BAR421");
                entity.Property(e => e.Bar422).HasPrecision(15).HasColumnName("BAR422");
                entity.Property(e => e.Bar423).HasPrecision(15).HasColumnName("BAR423");
                entity.Property(e => e.Bar424).HasPrecision(15).HasColumnName("BAR424");
                entity.Property(e => e.Bar425).HasPrecision(15).HasColumnName("BAR425");
                entity.Property(e => e.Bar426).HasPrecision(15).HasColumnName("BAR426");
                entity.Property(e => e.Bar427).HasPrecision(15).HasColumnName("BAR427");
                entity.Property(e => e.Bar428).HasPrecision(15).HasColumnName("BAR428");
                entity.Property(e => e.Completed).HasPrecision(1).HasColumnName("COMPLETED");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.Exempted).HasPrecision(1).HasColumnName("EXEMPTED");
                entity.Property(e => e.G421).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G422).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G423).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G424).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G425).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G426).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G427).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G428).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.Passcount).HasPrecision(2).HasColumnName("PASSCOUNT");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.Sl421).HasPrecision(10).HasColumnName("SL421");
                entity.Property(e => e.Sl422).HasPrecision(10).HasColumnName("SL422");
                entity.Property(e => e.Sl423).HasPrecision(10).HasColumnName("SL423");
                entity.Property(e => e.Sl424).HasPrecision(10).HasColumnName("SL424");
                entity.Property(e => e.Sl425).HasPrecision(10).HasColumnName("SL425");
                entity.Property(e => e.Sl426).HasPrecision(10).HasColumnName("SL426");
                entity.Property(e => e.Sl427).HasPrecision(10).HasColumnName("SL427");
                entity.Property(e => e.Sl428).HasPrecision(10).HasColumnName("SL428");
                entity.Property(e => e.Sub421).HasColumnType("NUMBER(5,2)").HasColumnName("SUB421");
                entity.Property(e => e.Sub422).HasColumnType("NUMBER(5,2)").HasColumnName("SUB422");
                entity.Property(e => e.Sub423).HasColumnType("NUMBER(5,2)").HasColumnName("SUB423");
                entity.Property(e => e.Sub424).HasColumnType("NUMBER(5,2)").HasColumnName("SUB424");
                entity.Property(e => e.Sub425).HasColumnType("NUMBER(5,2)").HasColumnName("SUB425");
                entity.Property(e => e.Sub426).HasColumnType("NUMBER(5,2)").HasColumnName("SUB426");
                entity.Property(e => e.Sub427).HasColumnType("NUMBER(5,2)").HasColumnName("SUB427");
                entity.Property(e => e.Sub428).HasColumnType("NUMBER(5,2)").HasColumnName("SUB428");
            });
            modelBuilder.Entity<TabLevel51>(entity => {
                entity.HasNoKey();
                entity.ToTable("TAB_LEVEL_51");
                entity.Property(e => e.Appeared).HasPrecision(1).HasColumnName("APPEARED");
                entity.Property(e => e.Bar511).HasPrecision(15).HasColumnName("BAR511");
                entity.Property(e => e.Bar512).HasPrecision(15).HasColumnName("BAR512");
                entity.Property(e => e.Bar513).HasPrecision(15).HasColumnName("BAR513");
                entity.Property(e => e.Bar514).HasPrecision(15).HasColumnName("BAR514");
                entity.Property(e => e.Bar515).HasPrecision(15).HasColumnName("BAR515");
                entity.Property(e => e.Bar516).HasPrecision(15).HasColumnName("BAR516");
                entity.Property(e => e.Bar517).HasPrecision(15).HasColumnName("BAR517");
                entity.Property(e => e.Bar518).HasPrecision(15).HasColumnName("BAR518");
                entity.Property(e => e.Completed).HasPrecision(1).HasColumnName("COMPLETED");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.Exempted).HasPrecision(1).HasColumnName("EXEMPTED");
                entity.Property(e => e.G511).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G512).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G513).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G514).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G515).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G516).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G517).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G518).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.Passcount).HasPrecision(2).HasColumnName("PASSCOUNT");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.Sl511).HasPrecision(10).HasColumnName("SL511");
                entity.Property(e => e.Sl512).HasPrecision(10).HasColumnName("SL512");
                entity.Property(e => e.Sl513).HasPrecision(10).HasColumnName("SL513");
                entity.Property(e => e.Sl514).HasPrecision(10).HasColumnName("SL514");
                entity.Property(e => e.Sl515).HasPrecision(10).HasColumnName("SL515");
                entity.Property(e => e.Sl516).HasPrecision(10).HasColumnName("SL516");
                entity.Property(e => e.Sl517).HasPrecision(10).HasColumnName("SL517");
                entity.Property(e => e.Sl518).HasPrecision(10).HasColumnName("SL518");
                entity.Property(e => e.Sub511).HasColumnType("NUMBER(5,2)").HasColumnName("SUB511");
                entity.Property(e => e.Sub512).HasColumnType("NUMBER(5,2)").HasColumnName("SUB512");
                entity.Property(e => e.Sub513).HasColumnType("NUMBER(5,2)").HasColumnName("SUB513");
                entity.Property(e => e.Sub514).HasColumnType("NUMBER(5,2)").HasColumnName("SUB514");
                entity.Property(e => e.Sub515).HasColumnType("NUMBER(5,2)").HasColumnName("SUB515");
                entity.Property(e => e.Sub516).HasColumnType("NUMBER(5,2)").HasColumnName("SUB516");
                entity.Property(e => e.Sub517).HasColumnType("NUMBER(5,2)").HasColumnName("SUB517");
                entity.Property(e => e.Sub518).HasColumnType("NUMBER(5,2)").HasColumnName("SUB518");
            });
            modelBuilder.Entity<TabLevel52>(entity => {
                entity.HasNoKey();
                entity.ToTable("TAB_LEVEL_52");
                entity.Property(e => e.Appeared).HasPrecision(1).HasColumnName("APPEARED");
                entity.Property(e => e.Bar521).HasPrecision(15).HasColumnName("BAR521");
                entity.Property(e => e.Bar522).HasPrecision(15).HasColumnName("BAR522");
                entity.Property(e => e.Bar523).HasPrecision(15).HasColumnName("BAR523");
                entity.Property(e => e.Bar524).HasPrecision(15).HasColumnName("BAR524");
                entity.Property(e => e.Bar525).HasPrecision(15).HasColumnName("BAR525");
                entity.Property(e => e.Bar526).HasPrecision(15).HasColumnName("BAR526");
                entity.Property(e => e.Bar527).HasPrecision(15).HasColumnName("BAR527");
                entity.Property(e => e.Bar528).HasPrecision(15).HasColumnName("BAR528");
                entity.Property(e => e.Completed).HasPrecision(1).HasColumnName("COMPLETED");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.Exempted).HasPrecision(1).HasColumnName("EXEMPTED");
                entity.Property(e => e.G521).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G522).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G523).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G524).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G525).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G526).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G527).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G528).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.Passcount).HasPrecision(2).HasColumnName("PASSCOUNT");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.Sl521).HasPrecision(10).HasColumnName("SL521");
                entity.Property(e => e.Sl522).HasPrecision(10).HasColumnName("SL522");
                entity.Property(e => e.Sl523).HasPrecision(10).HasColumnName("SL523");
                entity.Property(e => e.Sl524).HasPrecision(10).HasColumnName("SL524");
                entity.Property(e => e.Sl525).HasPrecision(10).HasColumnName("SL525");
                entity.Property(e => e.Sl526).HasPrecision(10).HasColumnName("SL526");
                entity.Property(e => e.Sl527).HasPrecision(10).HasColumnName("SL527");
                entity.Property(e => e.Sl528).HasPrecision(10).HasColumnName("SL528");
                entity.Property(e => e.Sub521).HasColumnType("NUMBER(5,2)").HasColumnName("SUB521");
                entity.Property(e => e.Sub522).HasColumnType("NUMBER(5,2)").HasColumnName("SUB522");
                entity.Property(e => e.Sub523).HasColumnType("NUMBER(5,2)").HasColumnName("SUB523");
                entity.Property(e => e.Sub524).HasColumnType("NUMBER(5,2)").HasColumnName("SUB524");
                entity.Property(e => e.Sub525).HasColumnType("NUMBER(5,2)").HasColumnName("SUB525");
                entity.Property(e => e.Sub526).HasColumnType("NUMBER(5,2)").HasColumnName("SUB526");
                entity.Property(e => e.Sub527).HasColumnType("NUMBER(5,2)").HasColumnName("SUB527");
                entity.Property(e => e.Sub528).HasColumnType("NUMBER(5,2)").HasColumnName("SUB528");
            });
            modelBuilder.Entity<TabLevel61>(entity => {
                entity.HasNoKey();
                entity.ToTable("TAB_LEVEL_61");
                entity.Property(e => e.Appeared).HasPrecision(1).HasColumnName("APPEARED");
                entity.Property(e => e.Bar611).HasPrecision(15).HasColumnName("BAR611");
                entity.Property(e => e.Bar612).HasPrecision(15).HasColumnName("BAR612");
                entity.Property(e => e.Bar613).HasPrecision(15).HasColumnName("BAR613");
                entity.Property(e => e.Bar614).HasPrecision(15).HasColumnName("BAR614");
                entity.Property(e => e.Bar615).HasPrecision(15).HasColumnName("BAR615");
                entity.Property(e => e.Bar616).HasPrecision(15).HasColumnName("BAR616");
                entity.Property(e => e.Bar617).HasPrecision(15).HasColumnName("BAR617");
                entity.Property(e => e.Bar618).HasPrecision(15).HasColumnName("BAR618");
                entity.Property(e => e.Completed).HasPrecision(1).HasColumnName("COMPLETED");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.Exempted).HasPrecision(1).HasColumnName("EXEMPTED");
                entity.Property(e => e.G611).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G612).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G613).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G614).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G615).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G616).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G617).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G618).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.Passcount).HasPrecision(2).HasColumnName("PASSCOUNT");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.Sl611).HasPrecision(10).HasColumnName("SL611");
                entity.Property(e => e.Sl612).HasPrecision(10).HasColumnName("SL612");
                entity.Property(e => e.Sl613).HasPrecision(10).HasColumnName("SL613");
                entity.Property(e => e.Sl614).HasPrecision(10).HasColumnName("SL614");
                entity.Property(e => e.Sl615).HasPrecision(10).HasColumnName("SL615");
                entity.Property(e => e.Sl616).HasPrecision(10).HasColumnName("SL616");
                entity.Property(e => e.Sl617).HasPrecision(10).HasColumnName("SL617");
                entity.Property(e => e.Sl618).HasPrecision(10).HasColumnName("SL618");
                entity.Property(e => e.Sub611).HasColumnType("NUMBER(5,2)").HasColumnName("SUB611");
                entity.Property(e => e.Sub612).HasColumnType("NUMBER(5,2)").HasColumnName("SUB612");
                entity.Property(e => e.Sub613).HasColumnType("NUMBER(5,2)").HasColumnName("SUB613");
                entity.Property(e => e.Sub614).HasColumnType("NUMBER(5,2)").HasColumnName("SUB614");
                entity.Property(e => e.Sub615).HasColumnType("NUMBER(5,2)").HasColumnName("SUB615");
                entity.Property(e => e.Sub616).HasColumnType("NUMBER(5,2)").HasColumnName("SUB616");
                entity.Property(e => e.Sub617).HasColumnType("NUMBER(5,2)").HasColumnName("SUB617");
                entity.Property(e => e.Sub618).HasColumnType("NUMBER(5,2)").HasColumnName("SUB618");
            });
            modelBuilder.Entity<TabLevel62>(entity => {
                entity.HasNoKey();
                entity.ToTable("TAB_LEVEL_62");
                entity.Property(e => e.Appeared).HasPrecision(1).HasColumnName("APPEARED");
                entity.Property(e => e.Bar621).HasPrecision(15).HasColumnName("BAR621");
                entity.Property(e => e.Bar622).HasPrecision(15).HasColumnName("BAR622");
                entity.Property(e => e.Bar623).HasPrecision(15).HasColumnName("BAR623");
                entity.Property(e => e.Bar624).HasPrecision(15).HasColumnName("BAR624");
                entity.Property(e => e.Bar625).HasPrecision(15).HasColumnName("BAR625");
                entity.Property(e => e.Bar626).HasPrecision(15).HasColumnName("BAR626");
                entity.Property(e => e.Bar627).HasPrecision(15).HasColumnName("BAR627");
                entity.Property(e => e.Bar628).HasPrecision(15).HasColumnName("BAR628");
                entity.Property(e => e.Completed).HasPrecision(1).HasColumnName("COMPLETED");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.Exempted).HasPrecision(1).HasColumnName("EXEMPTED");
                entity.Property(e => e.G621).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G622).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G623).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G624).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G625).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G626).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G627).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G628).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.Passcount).HasPrecision(2).HasColumnName("PASSCOUNT");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.Sl621).HasPrecision(10).HasColumnName("SL621");
                entity.Property(e => e.Sl622).HasPrecision(10).HasColumnName("SL622");
                entity.Property(e => e.Sl623).HasPrecision(10).HasColumnName("SL623");
                entity.Property(e => e.Sl624).HasPrecision(10).HasColumnName("SL624");
                entity.Property(e => e.Sl625).HasPrecision(10).HasColumnName("SL625");
                entity.Property(e => e.Sl626).HasPrecision(10).HasColumnName("SL626");
                entity.Property(e => e.Sl627).HasPrecision(10).HasColumnName("SL627");
                entity.Property(e => e.Sl628).HasPrecision(10).HasColumnName("SL628");
                entity.Property(e => e.Sub621).HasColumnType("NUMBER(5,2)").HasColumnName("SUB621");
                entity.Property(e => e.Sub622).HasColumnType("NUMBER(5,2)").HasColumnName("SUB622");
                entity.Property(e => e.Sub623).HasColumnType("NUMBER(5,2)").HasColumnName("SUB623");
                entity.Property(e => e.Sub624).HasColumnType("NUMBER(5,2)").HasColumnName("SUB624");
                entity.Property(e => e.Sub625).HasColumnType("NUMBER(5,2)").HasColumnName("SUB625");
                entity.Property(e => e.Sub626).HasColumnType("NUMBER(5,2)").HasColumnName("SUB626");
                entity.Property(e => e.Sub627).HasColumnType("NUMBER(5,2)").HasColumnName("SUB627");
                entity.Property(e => e.Sub628).HasColumnType("NUMBER(5,2)").HasColumnName("SUB628");
            });
            modelBuilder.Entity<TabLevel63>(entity => {
                entity.HasNoKey();
                entity.ToTable("TAB_LEVEL_63");
                entity.Property(e => e.Appeared).HasPrecision(1).HasColumnName("APPEARED");
                entity.Property(e => e.Bar631).HasPrecision(15).HasColumnName("BAR631");
                entity.Property(e => e.Bar632).HasPrecision(15).HasColumnName("BAR632");
                entity.Property(e => e.Bar633).HasPrecision(15).HasColumnName("BAR633");
                entity.Property(e => e.Bar634).HasPrecision(15).HasColumnName("BAR634");
                entity.Property(e => e.Bar635).HasPrecision(15).HasColumnName("BAR635");
                entity.Property(e => e.Bar636).HasPrecision(15).HasColumnName("BAR636");
                entity.Property(e => e.Bar637).HasPrecision(15).HasColumnName("BAR637");
                entity.Property(e => e.Bar638).HasPrecision(15).HasColumnName("BAR638");
                entity.Property(e => e.Completed).HasPrecision(1).HasColumnName("COMPLETED");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.Exempted).HasPrecision(1).HasColumnName("EXEMPTED");
                entity.Property(e => e.G631).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G632).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G633).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G634).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G635).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G636).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G637).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.G638).HasMaxLength(2).IsUnicode(false);
                entity.Property(e => e.Passcount).HasPrecision(2).HasColumnName("PASSCOUNT");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.Sl631).HasPrecision(10).HasColumnName("SL631");
                entity.Property(e => e.Sl632).HasPrecision(10).HasColumnName("SL632");
                entity.Property(e => e.Sl633).HasPrecision(10).HasColumnName("SL633");
                entity.Property(e => e.Sl634).HasPrecision(10).HasColumnName("SL634");
                entity.Property(e => e.Sl635).HasPrecision(10).HasColumnName("SL635");
                entity.Property(e => e.Sl636).HasPrecision(10).HasColumnName("SL636");
                entity.Property(e => e.Sl637).HasPrecision(10).HasColumnName("SL637");
                entity.Property(e => e.Sl638).HasPrecision(10).HasColumnName("SL638");
                entity.Property(e => e.Sub631).HasColumnType("NUMBER(5,2)").HasColumnName("SUB631");
                entity.Property(e => e.Sub632).HasColumnType("NUMBER(5,2)").HasColumnName("SUB632");
                entity.Property(e => e.Sub633).HasColumnType("NUMBER(5,2)").HasColumnName("SUB633");
                entity.Property(e => e.Sub634).HasColumnType("NUMBER(5,2)").HasColumnName("SUB634");
                entity.Property(e => e.Sub635).HasColumnType("NUMBER(5,2)").HasColumnName("SUB635");
                entity.Property(e => e.Sub636).HasColumnType("NUMBER(5,2)").HasColumnName("SUB636");
                entity.Property(e => e.Sub637).HasColumnType("NUMBER(5,2)").HasColumnName("SUB637");
                entity.Property(e => e.Sub638).HasColumnType("NUMBER(5,2)").HasColumnName("SUB638");
            });
            modelBuilder.Entity<TbwebTimeSch>(entity => {
                entity.HasNoKey();
                entity.ToTable("TBWEB_TIME_SCH");
                entity.Property(e => e.ExamDate).HasColumnType("DATE").HasColumnName("EXAM_DATE");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.ExamTime1).HasMaxLength(8).IsUnicode(false).HasColumnName("EXAM_TIME1");
                entity.Property(e => e.ExamTime2).HasMaxLength(8).IsUnicode(false).HasColumnName("EXAM_TIME2");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.Ref).HasPrecision(8).HasColumnName("REF");
                entity.Property(e => e.RefNo).HasPrecision(8).HasColumnName("REF_NO");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.SubId).HasPrecision(4).HasColumnName("SUB_ID");
                entity.Property(e => e.SubName).HasMaxLength(50).IsUnicode(false).HasColumnName("SUB_NAME");
            });
            modelBuilder.Entity<TimeSch>(entity => {
                entity.HasNoKey();
                entity.ToView("TIME_SCH");
                entity.Property(e => e.ExamDate).HasColumnType("DATE").HasColumnName("EXAM_DATE");
                entity.Property(e => e.ExamLevel).HasPrecision(2).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.ExamTime1).HasMaxLength(8).IsUnicode(false).HasColumnName("EXAM_TIME1");
                entity.Property(e => e.ExamTime2).HasMaxLength(8).IsUnicode(false).HasColumnName("EXAM_TIME2");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.RefNo).HasPrecision(8).HasColumnName("REF_NO");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.SubId).HasPrecision(4).HasColumnName("SUB_ID");
                entity.Property(e => e.SubName).HasMaxLength(50).IsUnicode(false).HasColumnName("SUB_NAME");
            });
            modelBuilder.Entity<Usersec>(entity => {
                entity.HasNoKey();
                entity.ToTable("USERSEC");
                entity.Property(e => e.Mainmenu).HasMaxLength(60).IsUnicode(false).HasColumnName("MAINMENU");
                entity.Property(e => e.Menuname).HasMaxLength(40).IsUnicode(false).HasColumnName("MENUNAME");
                entity.Property(e => e.Userid).HasMaxLength(20).IsUnicode(false).HasColumnName("USERID");
            });
            modelBuilder.Entity<VwAbsent>(entity => {
                entity.HasNoKey();
                entity.ToView("VW_ABSENT");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.SubId).HasPrecision(4).HasColumnName("SUB_ID");
            });
            modelBuilder.Entity<VwBarAlloted>(entity => {
                entity.HasNoKey();
                entity.ToView("VW_BAR_ALLOTED");
                entity.Property(e => e.BarCode).HasPrecision(15).HasColumnName("BAR_CODE");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.SubId).HasPrecision(4).HasColumnName("SUB_ID");
                entity.Property(e => e.UdSlno).HasPrecision(6).HasColumnName("UD_SLNO");
            });
            modelBuilder.Entity<VwExamReg>(entity => {
                entity.HasNoKey();
                entity.ToView("VW_EXAM_REG");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.ExamcenId).HasPrecision(2).HasColumnName("EXAMCEN_ID");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.SubId).HasPrecision(4).HasColumnName("SUB_ID");
            });
            modelBuilder.Entity<VwExempsub23>(entity => {
                entity.HasNoKey();
                entity.ToView("VW_EXEMPSUB23");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.ExemptedSubname).HasMaxLength(50).IsUnicode(false).HasColumnName("EXEMPTED_SUBNAME");
                entity.Property(e => e.Ref).HasPrecision(8).HasColumnName("REF");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.SubId).HasPrecision(4).HasColumnName("SUB_ID");
            });
            modelBuilder.Entity<VwExemptedSub>(entity => {
                entity.HasNoKey();
                entity.ToView("VW_EXEMPTED_SUB");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.ExemptedSubname).HasMaxLength(50).IsUnicode(false).HasColumnName("EXEMPTED_SUBNAME");
                entity.Property(e => e.Ref).HasPrecision(8).HasColumnName("REF");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.SubId).HasPrecision(4).HasColumnName("SUB_ID");
            });
            modelBuilder.Entity<VwMarksfinal>(entity => {
                entity.HasKey(e => new {
                    e.ExamLevel,
                    e.MonthId,
                    e.SessionYear,
                    e.SubId,
                    e.RegNo
                });
                entity.ToView("VW_MARKSFINAL");
                entity.Property(e => e.BarCode).HasPrecision(15).HasColumnName("BAR_CODE");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.Examiner).HasPrecision(5).HasColumnName("EXAMINER");
                entity.Property(e => e.Grade).HasMaxLength(2).IsUnicode(false).HasColumnName("GRADE");
                entity.Property(e => e.Marks).HasColumnType("NUMBER(5,2)").HasColumnName("MARKS");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.Outmarks).HasColumnType("NUMBER(5,2)").HasColumnName("OUTMARKS");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.Scriptsl).HasPrecision(5).HasColumnName("SCRIPTSL");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.SubId).HasPrecision(8).HasColumnName("SUB_ID");
            });
            modelBuilder.Entity<VwMouSuccessList>(entity => {
                entity.HasNoKey();
                entity.ToView("VW_MOU_SUCCESS_LIST");
            });
            modelBuilder.Entity<VwPrincipal>(entity => {
                entity.HasNoKey();
                entity.ToView("VW_PRINCIPAL");
                entity.Property(e => e.DateEnr).HasColumnType("DATE").HasColumnName("DATE_ENR");
                entity.Property(e => e.FId).HasPrecision(6).HasColumnName("F_ID");
                entity.Property(e => e.MemId).HasPrecision(8).HasColumnName("MEM_ID");
                entity.Property(e => e.Name).HasMaxLength(50).IsUnicode(false).HasColumnName("NAME");
            });
            modelBuilder.Entity<VwRollAlloted>(entity => {
                entity.HasNoKey();
                entity.ToView("VW_ROLL_ALLOTED");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.FName).HasMaxLength(70).IsUnicode(false).HasColumnName("F_NAME");
                entity.Property(e => e.FormNo).HasMaxLength(9).IsUnicode(false).HasColumnName("FORM_NO");
                entity.Property(e => e.MName).HasMaxLength(70).IsUnicode(false).HasColumnName("M_NAME");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.Name).HasMaxLength(150).IsUnicode(false).HasColumnName("NAME");
                entity.Property(e => e.Ref).HasPrecision(8).HasColumnName("REF");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.StudType).HasPrecision(2).HasColumnName("STUD_TYPE");
            });
            modelBuilder.Entity<VwSearch>(entity => {
                entity.HasNoKey();
                entity.ToView("VW_SEARCH");
                entity.Property(e => e.BarCode).HasPrecision(15).HasColumnName("BAR_CODE");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.FName).HasMaxLength(70).IsUnicode(false).HasColumnName("F_NAME");
                entity.Property(e => e.MName).HasMaxLength(70).IsUnicode(false).HasColumnName("M_NAME");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.Name).HasMaxLength(150).IsUnicode(false).HasColumnName("NAME");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.SubId).HasPrecision(8).HasColumnName("SUB_ID");
            });
            modelBuilder.Entity<VwSessionPassCount>(entity => {
                entity.HasKey(e => new {
                    e.ExamLevel,
                    e.MonthId,
                    e.SessionYear,
                    e.RegNo
                });
                entity.ToView("VW_SESSION_PASS_COUNT");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.NoFailSub).HasColumnType("NUMBER").HasColumnName("NO_FAIL_SUB");
                entity.Property(e => e.NoPassSub).HasColumnType("NUMBER").HasColumnName("NO_PASS_SUB");
                entity.Property(e => e.NoSubApp).HasColumnType("NUMBER").HasColumnName("NO_SUB_APP");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
            });
            modelBuilder.Entity<VwSessionPassCountBack>(entity => {
                entity.HasNoKey();
                entity.ToView("VW_SESSION_PASS_COUNT_BACK");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.NoFailSub).HasColumnType("NUMBER").HasColumnName("NO_FAIL_SUB");
                entity.Property(e => e.NoPassSub).HasColumnType("NUMBER").HasColumnName("NO_PASS_SUB");
                entity.Property(e => e.NoSubApp).HasColumnType("NUMBER").HasColumnName("NO_SUB_APP");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
            });
            modelBuilder.Entity<VwStuReg>(entity => {
                entity.HasNoKey();
                entity.ToView("VW_STU_REG");
                entity.Property(e => e.BoardUni).HasMaxLength(50).IsUnicode(false).HasColumnName("BOARD_UNI");
                entity.Property(e => e.Cell).HasMaxLength(50).IsUnicode(false).HasColumnName("CELL");
                entity.Property(e => e.Dob).HasColumnType("DATE").HasColumnName("DOB");
                entity.Property(e => e.Email).HasMaxLength(50).IsUnicode(false).HasColumnName("EMAIL");
                entity.Property(e => e.ExamName).HasMaxLength(20).IsUnicode(false).HasColumnName("EXAM_NAME");
                entity.Property(e => e.FId).HasPrecision(6).HasColumnName("F_ID");
                entity.Property(e => e.FName).HasMaxLength(70).IsUnicode(false).HasColumnName("F_NAME");
                entity.Property(e => e.Fax).HasMaxLength(30).IsUnicode(false).HasColumnName("FAX");
                entity.Property(e => e.Gender).HasMaxLength(1).IsUnicode(false).HasColumnName("GENDER");
                entity.Property(e => e.Imagepath).HasMaxLength(200).IsUnicode(false).HasColumnName("IMAGEPATH");
                entity.Property(e => e.MName).HasMaxLength(70).IsUnicode(false).HasColumnName("M_NAME");
                entity.Property(e => e.Name).HasMaxLength(150).IsUnicode(false).HasColumnName("NAME");
                entity.Property(e => e.NationalId).HasMaxLength(15).IsUnicode(false).HasColumnName("NATIONAL_ID");
                entity.Property(e => e.Nationality).HasMaxLength(15).IsUnicode(false).HasColumnName("NATIONALITY");
                entity.Property(e => e.PassYear).HasPrecision(4).HasColumnName("PASS_YEAR");
                entity.Property(e => e.PerAdd).HasMaxLength(300).IsUnicode(false).HasColumnName("PER_ADD");
                entity.Property(e => e.PeriodFrom).HasColumnType("DATE").HasColumnName("PERIOD_FROM");
                entity.Property(e => e.PeriodTo).HasColumnType("DATE").HasColumnName("PERIOD_TO");
                entity.Property(e => e.Ph).HasMaxLength(50).IsUnicode(false).HasColumnName("PH");
                entity.Property(e => e.PreAdd).HasMaxLength(300).IsUnicode(false).HasColumnName("PRE_ADD");
                entity.Property(e => e.PrinEnrNo).HasPrecision(8).HasColumnName("PRIN_ENR_NO");
                entity.Property(e => e.RegDate).HasColumnType("DATE").HasColumnName("REG_DATE");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.RegYear).HasPrecision(4).HasColumnName("REG_YEAR");
                entity.Property(e => e.Religion).HasMaxLength(10).IsUnicode(false).HasColumnName("RELIGION");
                entity.Property(e => e.ResultDiv).HasPrecision(1).HasColumnName("RESULT_DIV");
                entity.Property(e => e.ResultGpa).HasColumnType("NUMBER(3,2)").HasColumnName("RESULT_GPA");
                entity.Property(e => e.ResultProf).HasMaxLength(10).IsUnicode(false).HasColumnName("RESULT_PROF");
            });
            modelBuilder.Entity<VwUnsuccessList>(entity => {
                entity.HasNoKey();
                entity.ToView("VW_UNSUCCESS_LIST");
                entity.Property(e => e.BarCode).HasPrecision(15).HasColumnName("BAR_CODE");
                entity.Property(e => e.ExamLevel).HasPrecision(8).HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.ExamRollno).HasPrecision(8).HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.Examiner).HasPrecision(5).HasColumnName("EXAMINER");
                entity.Property(e => e.Grade).HasMaxLength(2).IsUnicode(false).HasColumnName("GRADE");
                entity.Property(e => e.Marks).HasColumnType("NUMBER(5,2)").HasColumnName("MARKS");
                entity.Property(e => e.MonthId).HasPrecision(2).HasColumnName("MONTH_ID");
                entity.Property(e => e.Outmarks).HasColumnType("NUMBER(5,2)").HasColumnName("OUTMARKS");
                entity.Property(e => e.RegNo).HasPrecision(8).HasColumnName("REG_NO");
                entity.Property(e => e.Scriptsl).HasPrecision(5).HasColumnName("SCRIPTSL");
                entity.Property(e => e.SessionYear).HasPrecision(4).HasColumnName("SESSION_YEAR");
                entity.Property(e => e.SubId).HasPrecision(8).HasColumnName("SUB_ID");
            });
            modelBuilder.Entity<WebResult>(entity => {
                entity.HasNoKey();
                entity.ToTable("WEB_RESULT");
                entity.Property(e => e.Completed).HasColumnType("NUMBER").HasColumnName("COMPLETED");
                entity.Property(e => e.ExamLevel).HasColumnType("NUMBER").HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.ExamLevelName).HasMaxLength(50).IsUnicode(false).HasColumnName("EXAM_LEVEL_NAME");
                entity.Property(e => e.ExamRollno).HasColumnType("NUMBER").HasColumnName("EXAM_ROLLNO");
                entity.Property(e => e.ExamSession).HasColumnType("NUMBER").HasColumnName("EXAM_SESSION");
                entity.Property(e => e.ExamSessionName).HasMaxLength(20).IsUnicode(false).HasColumnName("EXAM_SESSION_NAME");
                entity.Property(e => e.ExamYear).HasColumnType("NUMBER").HasColumnName("EXAM_YEAR");
                entity.Property(e => e.FName).HasMaxLength(150).IsUnicode(false).HasColumnName("F_NAME");
                entity.Property(e => e.Fname1).HasMaxLength(150).IsUnicode(false).HasColumnName("FNAME");
                entity.Property(e => e.MName).HasMaxLength(150).IsUnicode(false).HasColumnName("M_NAME");
                entity.Property(e => e.Name).HasMaxLength(150).IsUnicode(false).HasColumnName("NAME");
                entity.Property(e => e.PassStatus).HasColumnType("NUMBER").HasColumnName("PASS_STATUS");
                entity.Property(e => e.RegNo).HasColumnType("NUMBER").HasColumnName("REG_NO");
                entity.Property(e => e.Sub1Grd).HasMaxLength(2).IsUnicode(false).HasColumnName("SUB1_GRD");
                entity.Property(e => e.Sub2Grd).HasMaxLength(2).IsUnicode(false).HasColumnName("SUB2_GRD");
                entity.Property(e => e.Sub3Grd).HasMaxLength(2).IsUnicode(false).HasColumnName("SUB3_GRD");
                entity.Property(e => e.Sub4Grd).HasMaxLength(2).IsUnicode(false).HasColumnName("SUB4_GRD");
                entity.Property(e => e.Sub5Grd).HasMaxLength(2).IsUnicode(false).HasColumnName("SUB5_GRD");
                entity.Property(e => e.Sub6Grd).HasMaxLength(2).IsUnicode(false).HasColumnName("SUB6_GRD");
                entity.Property(e => e.Sub7Grd).HasMaxLength(2).IsUnicode(false).HasColumnName("SUB7_GRD");
                entity.Property(e => e.Sub8Grd).HasMaxLength(2).IsUnicode(false).HasColumnName("SUB8_GRD");
            });
            modelBuilder.Entity<Yearinfo>(entity => {
                entity.HasKey(e => e.Yearcode).HasName("YEARINFO_PK");
                entity.ToTable("YEARINFO");
                entity.Property(e => e.Yearcode).HasPrecision(2).HasColumnName("YEARCODE");
                entity.Property(e => e.Description).HasMaxLength(30).IsUnicode(false).HasColumnName("DESCRIPTION");
                entity.Property(e => e.Enddate).HasColumnType("DATE").HasColumnName("ENDDATE");
                entity.Property(e => e.Openingfield).HasMaxLength(20).IsUnicode(false).HasColumnName("OPENINGFIELD");
                entity.Property(e => e.Startdate).HasColumnType("DATE").HasColumnName("STARTDATE");
            });
            modelBuilder.Entity<Signature>(entity => {
                entity.HasKey(j => j.Id);
                entity.ToTable("SIGNATURE");
                entity.Property(e => e.Id).HasColumnType("NUMBER").HasColumnName("ID");
                entity.Property(e => e.Controller).HasMaxLength(50).IsUnicode(false).HasColumnName("CONTROLLER");
                entity.Property(e => e.FilepathControllerSign).HasMaxLength(200).IsUnicode(false).HasColumnName("FILEPATH_CONTROLLER_SIGN");
                entity.Property(e => e.ExamLevel).HasColumnType("NUMBER").HasColumnName("EXAM_LEVEL");
                entity.Property(e => e.MonthId).HasColumnType("NUMBER").HasColumnName("MONTH_ID");
                entity.Property(e => e.SecretaryCeo).HasMaxLength(50).IsUnicode(false).HasColumnName("SECRETARY_CEO");
                entity.Property(e => e.FilepathSecretaryCeoSign).HasMaxLength(200).IsUnicode(false).HasColumnName("FILEPATH_SECRETARY_CEO_SIGN");
                entity.Property(e => e.SessionYear).HasColumnType("NUMBER").HasColumnName("SESSION_YEAR");
            });
            modelBuilder.HasSequence("EXAM_CHANGE_ID");
            modelBuilder.HasSequence("SEQ_EXAM_REGNO");
            modelBuilder.HasSequence("SQ_SAMPLECLASS");
            modelBuilder.HasSequence("SQ_TblStudent");
            modelBuilder.HasSequence("SQ_TblUnknown");
            modelBuilder.HasSequence("STUDENT_SLNO");
            modelBuilder.HasSequence("STUREG_CHANGE_ID");
            modelBuilder.HasSequence("TRACK_ID");
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}