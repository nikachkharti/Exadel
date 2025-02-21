using BookManagement.API.Extensions;
using BookManagement.API.Middleware;

namespace BookManagement.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.AddControllers();
            builder.AddEndpointsApiExplorer();
            builder.AddSwagger();
            builder.AddDatabase();

            var app = builder.Build();

            app.CreateDatabaseAutomatically();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
