using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using SystemToDo.Data;
using SystemToDo.Repositorios.Interfaces;

namespace SystemToDo
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
            builder.Services.AddSwaggerGen();
            //var connectionStringMySql = builder.Configuration.GetConnectionString("DataBase");
            //builder.Services.AddDbContext<ApiDbContext>(x => x.UseMySql(connectionStringMySql, Microsoft.EntityFrameworkCore.MySqlServerVersion.Parse("8.0.38")));

            var connectionString = "Server=localhost;Port=3306;Database=SystemToDo;Uid=root;Pwd=root";
            var serverVersion = new MySqlServerVersion(new Version(8, 0,38));
            builder.Services.AddDbContext<ApiDbContext>(o => o.UseMySql(connectionString, serverVersion));
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
