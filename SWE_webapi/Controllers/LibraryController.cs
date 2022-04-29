﻿using System.Linq;
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

    [HttpGet("{id}")]
    //Gebruikt om te kijken of de in memory db werkt
    public Book GetBookById(int id)
    {
        return _context.Books.SingleOrDefault(e => e.Id == id);
        //return books.Select(books).Where(s=> s.Id == id);
    }

    [HttpPost("NewBook")]

    public IActionResult AddBook(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
        return Created("api/books/" + book.Id, book);

    }

    [HttpGet("AllBooks")]
    //Gebruikt om te kijken of de in memory db werkt
    public List<Book> GetBooks()
    {
        return _context.Books.ToList();
        //
        //return books.Select();
        //
    }

    [HttpGet("GetBooks")]
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
