using AngularApp1.Server.Model.DataAccess;
using AngularApp1.Server.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularApp1.Server.Controllers
{
  [ApiController]
  [Route("resources")]
  public class ResourcesController : ControllerBase
  {

    private readonly ILogger<WeatherForecastController> _logger;

    public ResourcesController(ILogger<WeatherForecastController> logger)
    {
      _logger = logger;
    }

    [HttpGet(Name = "all")]
    public async Task<IActionResult> ListAllResources()
    {
      using (var db = new DatabaseContext())
      {
        var result = await db.Resources.ToListAsync();
        return Ok(result);
      }
    }

    [HttpPost(Name = "add")]
    public async Task<IActionResult> AddNewResource(string name)
    {
      using (var db = new DatabaseContext())
      {
        Resource newItem = new() { Name = name, Status = ResourceStatus.Active };
        await db.Resources.AddAsync(newItem);
        await db.SaveChangesAsync();
        var result = await db.Resources.SingleAsync(r => r.Name == name);
        return Ok(result);
      }
    }

  }
}
