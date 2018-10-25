using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bookservice.WebAPI.DTO;
using Bookservice.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookservice.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        BookRepository _bookRepository;

        public BooksController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            return Ok(await _bookRepository.GetAllInclusive());
        }

        // GET: api/Books/Basic
        [HttpGet]
        [Route("Basic")]
        public async Task<IActionResult> GetBookBasic()
        {
            return Ok(await _bookRepository.ListBasic());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            return Ok(await _bookRepository.GetById(id));
        }

        [HttpGet]
        [Route("ImageByName/{filename}")]
        public IActionResult ImageByFileName(string filename)
        {
            var image = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", filename);
            return PhysicalFile(image, "image/jpg");
        }

        [HttpGet]
        [Route("ImageById/{bookid}")]
        public async Task<IActionResult> ImageById(int bookid)
        {
            BookDetail book = await _bookRepository.GetDetailById(bookid);
            return ImageByFileName(book.FileName);
        }
    }
}