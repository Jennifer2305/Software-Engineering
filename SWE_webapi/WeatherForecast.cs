namespace SWE_webapi;

public class WeatherForecast
{
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}

public class Books
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Author Author { get; set; }

}

public class Author
{
    public int Id { get; set; }
    public string Name { set; get; }
    public List<Books> Books { get; set; }


}
