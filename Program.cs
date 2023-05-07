
using AdminMNS.API.Abstractions;
using AdminMNS.API.Domain.Services;
using AdminMNS.API.Repository;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AdminMNS.API
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
			builder.Services.AddTransient<IDbConnection>(db => new SqlConnection(builder.Configuration.GetConnectionString("Default")));
			builder.Services.AddTransient<IUserService, UserService>();
			builder.Services.AddTransient<IUserRepository, UserRepository>();
			builder.Services.AddTransient<IGraduatingClassService, GraduatingClassService>();
			builder.Services.AddTransient<IGraduatingClassRepository, GraduatingClassRepository>();

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