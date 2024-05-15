using backend.Configuration;
using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
      private readonly MongoDbContext _context;

    public PaymentController(IOptions<MongoDBConfiguration> settings)
    {
        _context = new MongoDbContext(settings);
    }

  //  [HttpGet]
   // public async Task<ActionResult<IEnumerable<Stocks>>> Get()
    //{
     //   var articles = await _context.stocks.Find(_ => true).ToListAsync();
      //  return Ok(articles);
   // }
    [HttpGet]
public async Task<IActionResult> Get()
{
    try
    {
        var articles = await _context.paymentcard.Find(_ => true).ToListAsync();
        return Ok(articles);
    }
    catch (Exception ex)
    {
        return StatusCode(500, $"Internal server error: {ex.Message}");
    }
}


    [HttpGet("{id}")]
    public async Task<ActionResult<PaymentCard>> Get(int id)
    {
        var article = await _context.paymentcard.Find(a => a.PaymentDetailId == id).FirstOrDefaultAsync();

        if (article == null)
        {
            return NotFound();
        }

        return Ok(article);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PaymentCard article)
    {
        await _context.paymentcard.InsertOneAsync(article);
        return CreatedAtAction("Get", new { id = article.PaymentDetailId }, article);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] PaymentCard article)
    {
        var existingArticle = await _context.paymentcard.Find(a => a.PaymentDetailId == id).FirstOrDefaultAsync();

        if (existingArticle == null)
        {
            return NotFound();
        }

        article.PaymentDetailId = existingArticle.PaymentDetailId;
        await _context.paymentcard.ReplaceOneAsync(a => a.PaymentDetailId == id, article);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var article = await _context.paymentcard.Find(a => a.PaymentDetailId == id).FirstOrDefaultAsync();

        if (article == null)
        {
            return NotFound();
        }

        await _context.paymentcard.DeleteOneAsync(a => a.PaymentDetailId == id);
        return NoContent();
    }
}
