using API.Data;
using API.Repositorios;
using API.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;



namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "API",
                    Version = "v1"
                });
            });

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<SistemaTarefasDbContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectiaon"))
                );

            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.


            app.UseExceptionHandler("/Error");
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "API"); });



            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}