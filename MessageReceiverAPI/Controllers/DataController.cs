using Microsoft.AspNetCore.Mvc;
using MessageReceiverAPI.Data;
using MessageReceiverAPI.Models;

namespace MessageReceiverAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DataController : ControllerBase
{
    private readonly AppDbContext _context;

    public DataController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Post(GenericData data)
    {
        _context.GenericData.Add(data);
        _context.SaveChanges();
        return Ok(data);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.GenericData.ToList());
    }
}
