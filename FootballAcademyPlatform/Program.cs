using FootballAcademyPlatform.Configuration;
using FootballAcademyPlatform.DAO;
using FootballAcademyPlatform.Services;

namespace FootballAcademyPlatform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddAutoMapper(typeof(MapperConfig));
            builder.Services.AddScoped<ICoachDAO,CoachDAOImpl>();
            builder.Services.AddScoped<ICoachService, CoachServiceImpl>();
            builder.Services.AddScoped<ITeamDAO, TeamDAOImpl>();
            builder.Services.AddScoped<ITeamService, TeamServiceImpl>();
            builder.Services.AddScoped<IPlayerDAO, PlayerDAOImpl>();
            builder.Services.AddScoped<IPlayerService, PlayerServiceImpl>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}