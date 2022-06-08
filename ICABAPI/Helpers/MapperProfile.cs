using System;
using System.Linq;
using AutoMapper;
using ICABAPI.DTOs;
using ICABAPI.DTOs.AdminDto;
using ICABAPI.DTOs.AuthModels;
//using ICABAPI.DTOs.cpl_studentdtos;
//using ICABAPI.DTOs.CPLDtos;
using ICABAPI.Models;
//using ICABAPI.Models.Cpl_Models;
//using ICABAPI.Models.Cpls_Student_Models;

namespace ICABAPI.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //   CreateMap<StudentRegDto , StudentReg>();
            //CreateMap<StudentReg, StudentRegDto>();
            //CreateMap<MainMenu , MainMenuDto>();
            //CreateMap<SubMenu , SubMenusDto>();
            CreateMap<Member, MemberForPincipleDto>();
            CreateMap<AppUser, RegisterDto>();
            CreateMap<FirmMas1, FirmMas1Dto>();
            CreateMap<FirmMas2, FirmMas2Dto>();
            CreateMap<ProPartner, ProPartnerDto>();
            CreateMap<FirmMas1Dto, FirmMas1>()
            .ForMember(dest => dest.FirmMas2s, opt =>
             opt.MapFrom(src => src.FirmMas2s.Select(s =>
            //  new FirmMas2() {BrType=s.BrType,FId = src.FId,FirmMas1Id=src.FId,DoStart=src.DoDeed,LocId =s.LocId
            new FirmMas2()
            {
                BrType = s.BrType,
                LocId = s.LocId,
                FId = src.FId,
                Address = s.Address
            }
             ))
          )
          .ForMember(d => d.ProPartners, o =>
          {
              o.MapFrom(s => s.ProPartners.Select(p => new ProPartner
              {
                  FId = s.FId,
                  MemId = p.MemId
              }));
          })
          ;
            //CreateMap<ExCourseDto, ExCourse>();
            //CreateMap<ExUniversityListRequest, ExUniversityList>();
            //CreateMap<ExUniversityList, ExUniversityListRequest>();
            //CreateMap<ExExamLevelDto, ExExamLevel>();
            //CreateMap<ExICABSubjectDto, ExICABSubject>();
            //CreateMap<ExUniversityDto, ExUniversity>();
            //CreateMap<ExDepartmentDto, ExDepartment>();


            //   .ForMember(dest => dest.EXICABSUBJECTS ,opt =>opt.MapFrom(src =>src.EXICABSUBJECTS.Select(s =>new ExICABSubject(){
            //       SUBJECTNAME = s.SUBJECTNAME,EXUNIVERSITYID=s.EXUNIVERSITYID,EXDEPARTMENTID=s.EXDEPARTMENTID,SUB_ID_OR_EXAMLEVELID =s.SUB_ID_OR_EXAMLEVELID,
            //       EXEXAMLEVEL =new ExExamLevel{
            //         //   EXEXAMLEVELID = s.EXEXAMLEVEL.EXICABSUBJECTID,
            //           LEVELNAME=s.EXEXAMLEVEL.LEVELNAME,
            //           EXICABSUBJECTID=s.EXEXAMLEVEL.EXICABSUBJECTID,
            //           SUB_ID_OR_EXAMLEVELID=s.EXEXAMLEVEL.SUB_ID_OR_EXAMLEVELID


            //       }
            //   }))



            //   );



            //CreateMap<ExCourse, ExCourseDto>();
            //   .ForMember(d=> d.EXICABSUBJECT,o =>o.MapFrom(v =>new ExCourse{
            //       EXICABSUBJECTID=v.EXICABSUBJECTID
            //   }));

            CreateMap<MainMenu, MainMenuDto>();
            CreateMap<SubMenu, SubMenusDto>();
            CreateMap<UserSubMenu, UserSubMenuDto>();
            //CreateMap<CPLSubject, CPLSubjectDto>();
            //CreateMap<CPLCourse,CPLCourseDto>();
            //CreateMap<CPLUniversity,CPLUniversityDto>();
            //CreateMap<CPLDepartment,CPLSubjectDto>();
            //CreateMap<CPLSubjectDto,CPLSubject>()
            //.ForMember(d =>d.CPLUniversity ,o =>o.MapFrom( v =>new CPLUniversity{
            //    UNIVERSITYNAME=v.CPLUniversity.UNIVERSITYNAME,STUD_ID=v.CPLUniversity.STUD_ID
            //}))
            //.ForMember(d =>d.CPLDEPARTMENT ,o =>o.MapFrom( v =>new CPLDepartment
            //{
            //    DEPARTMENTNAME=v.CPLDEPARTMENT.DEPARTMENTNAME
            //}
            //))

            //.ForMember(dest =>dest.CPLCourse, opt =>opt.MapFrom(src =>src.CPLCourse.Select(s => new CPLCourse(){
            //    COURSENAME =s.COURSENAME
            //}))

            //);



            // CreateMap<FirmMas1,FirmMas1Dto>()
            // .ForMember(d =>d.FirmMas2s , o =>o.MapFrom((s =>s.FirmMas2s.Select(x =>x.FirmMas1Id)
            // .ToList()
            // )));


        }

    }
}