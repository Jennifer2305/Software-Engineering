using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWE_webapi.Models;


namespace PrototypeApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly LibraryContext _context;

    public UsersController(LibraryContext context)
    {
        _context = context;
    }

    [HttpGet]
    //Gebruikt om te kijken of de in memory db werkt
    public List<Book> GetBooksTest()
    {
        return _context.Books.ToList();
    }

    [HttpGet(Name = "GetBooks")]
    public async Task<IActionResult> Get()
    {
        var users = await _context.Authors
            .Include(u => u.Books)
            .ToArrayAsync();

        var response = users.Select(u => new
        {
            Name = u.Name,
            posts = u.Books.Select(p => p.Title)
        });

        return Ok(response);
    }
}
