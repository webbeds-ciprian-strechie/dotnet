using Microsoft.Extensions.DependencyInjection;
using CourseManagement.Domain.DataAccess;
using CourseManagement.Infrastructure.DataAccess;
using CourseManagement.Application.Services;

namespace CourseManagement.Api.ServiceExtensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IClassRoomService, ClassRoomService>();
            services.AddSingleton<ICourseService, CourseService>();
            services.AddSingleton<IDepartmentService, DepartmentService>();
            services.AddSingleton<IEnrollmentService, EnrollmentService>();
            services.AddSingleton<IOfficeAssignmentService, OfficeAssignmentService>();
            services.AddSingleton<IStudentService, StudentService>();
            services.AddSingleton<ITeacherService, TeacherService>();

            services.AddSingleton<IRequestLogger, RequestLogger>();

            return services;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IClassRoomRepository, ClassRoomRepository>();
            services.AddSingleton<ICourseRepository, CourseRepository>();
            services.AddSingleton<IDepartmentRepository, DepartmentRepository>();
            services.AddSingleton<IEnrollmentRepository, EnrollmentRepository>();
            services.AddSingleton<IOfficeAssignmentRepository, OfficeAssignmentRepository>();
            services.AddSingleton<IStudentRepository, StudentRepository>();
            services.AddSingleton<ITeacherRepository, TeacherRepository>();

            return services;
        }
    }
}
