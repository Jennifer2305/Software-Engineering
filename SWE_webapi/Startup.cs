using SWE_webapi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;



namespace SWE_webapi
{
	public static class Startup
	{
		public static WebApplication InitializeApp(string[] args)
        {
			var builder = WebApplication.CreateBuilder(args);
			ConfigureServices(builder);
			var app = builder.Build();
			Configure(app);
			return app;
		}

		private static void ConfigureServices(WebApplicationBuilder builder)
        {
			builder.Services.AddDbContext<LibraryContext>(opt => opt.UseInMemoryDatabase(builder.Configuration.GetConnectionString("MyDb")));
			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

		}


		private static void Configure(WebApplication app)
        {
			ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
			{
				builder.AddConsole();
				builder.AddDebug();
			});

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			var scope = app.Services.CreateScope();

			var context = scope.ServiceProvider.GetService<LibraryContext>();
			AddTestData(context);

			
		}

		public static void AddTestData(LibraryContext context)
		{
			var author = new Author
			{
				Name = "Geronimo Stilton",
			};
			var book = new Book
			{
				Title = "Fantasia",
				Author = author
			};

			context.Books.Add(book);
			context.SaveChanges();
		}
	}
}

