using CoreWebAPI.Context;
using CoreWebAPI.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreWebAPI.Controllers
{
    [Route("api/general")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly MyDbContext _db;
        public MasterController(MyDbContext db) { _db = db; }

        [HttpGet("main-menus")]
        public async Task<ActionResult<List<MainMenuDto>>> GetMainMenus()
        {
            var mainMenus = await _db.MainMenus.Select(s => new MainMenuDto
            {
                ID = s.ID,
                Title = s.Title,
                Url = s.Url,
                Icon = s.Icon,
                Priority = s.Priority
            }).ToListAsync();
            return Ok(mainMenus);
        }

        [HttpGet("main-menu/{id}")]
        public async Task<ActionResult<MainMenuDto>> GetMainMenuByID(int id)
        {
            var mainMenu = await _db.MainMenus.Where(m => m.ID == id).Select(s => new MainMenuDto
            {
                ID = s.ID,
                Title = s.Title,
                Url = s.Url,
                Icon = s.Icon,
                Priority = s.Priority
            }).ToListAsync();
            return Ok(mainMenu);
        }

    }
}
