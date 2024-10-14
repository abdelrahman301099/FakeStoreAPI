
using FakeStore.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace FakeStore.APIs
{
    public class Program
    {
        public static async Task  Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<FakeStoreDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("mycon"))
                );
            

            var app = builder.Build();

            //Update-Database
            //FakeStoreDbContext dbContext = new FakeStoreDbContext();
            //await dbContext.Database.MigrateAsync();

            using  var scope = app.Services.CreateScope();//Group of Services with liftime Scoped
            var services = scope.ServiceProvider; // services itself
            var dbContext = services.GetRequiredService<FakeStoreDbContext>();//Ask CLR for creating object from context Explicity
            await  dbContext.Database.MigrateAsync();//Update-Database
            







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
