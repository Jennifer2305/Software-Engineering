using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWE_webapi.Models;

namespace PrototypeApi.Controllers
{
    /*[Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly LibraryContext _context;

        public UsersController(LibraryContext context)
        {
            _context = context;
        }

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
    }*/
}