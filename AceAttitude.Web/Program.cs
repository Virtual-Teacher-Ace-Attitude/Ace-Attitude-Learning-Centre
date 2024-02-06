using AceAttitude.Common.Helpers;
using AceAttitude.Common.Helpers.Contracts;
using AceAttitude.Data;
using AceAttitude.Data.Repositories;
using AceAttitude.Data.Repositories.Contracts;
using AceAttitude.Services;
using AceAttitude.Services.Contracts;
using AceAttitude.Services.Mapping;
using AceAttitude.Services.Mapping.Contracts;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AceAttitude.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                //Alexander's connection string:
                string connectionString = @"Server=DESKTOP-RBKNIJ9\SQLEXPRESS;Database=AceAttitude;Trusted_Connection=True;";

                //Alexei's connection string:
                //string connectionString = @"Server=DESKTOP-C2DTSUG\SQLEXPRESS;Database=AceAttitude;Trusted_Connection=True;";

                options.UseSqlServer(connectionString);
                options.EnableSensitiveDataLogging();
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Http Session
            builder.Services.AddSession(options =>
            {
                // With IdleTimeout you can change the number of seconds after which the session expires.
                // The seconds reset every time you access the session.
                // This only applies to the session, not the cookie.
                options.IdleTimeout = TimeSpan.FromSeconds(600);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddScoped<IAuthHelper, AuthHelper>();

            builder.Services.AddScoped<IModelMapper, ModelMapper>();

            builder.Services.AddScoped<IAuthService, AuthService>();

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<ICourseService, CourseService>();

            builder.Services.AddScoped<ILectureRepository, LectureRepository>();
            builder.Services.AddScoped<ILectureService, LectureService>();

            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<ICommentService, CommentService>();

            var app = builder.Build();

            app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseSession();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "AceAttitude API V1");
                options.RoutePrefix = "api/swagger";
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // Enables the views to use resources from wwwroot
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            app.MapControllers();

            app.Run();
        }
    }
}