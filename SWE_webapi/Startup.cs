using SWE_webapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;


namespace SWE_webapi
{
	public static class Startup
	{
		/*var options = new DbContextOptionsBuilder<LibraryContext>()
        .UseInMemoryDatabase(databaseName: "InMemoryDB")
        .Options;*/
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
			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			//builder.Services.AddDbContext<LibraryContext>(opt => opt.UseInMemoryDatabase());
;


			//builder.Services.AddMvc(c => c.Conventions.Add();
		}


		private static void Configure(WebApplication app)
        {
			ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
			{
				builder.AddConsole();
				builder.AddDebug();
			});

			//loggerFactory.AddConsole(Configuration.GetSection("Logging"));


			//var context = app.Services.GetService<LibraryContext>();
			//AddTestData(context);

			//app.UseMvc();
			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			
		}

		/*private static void AddTestData(LibraryContext context)
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
		}*/
	}
}

