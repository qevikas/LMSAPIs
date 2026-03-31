using CoreWebAPI.Context;
using CoreWebAPI.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreWebAPI.Controllers
{
    [Route("api/general")]
    [ApiController]
    /// <summary>This controller has primary constructor.</summary>
    public class MasterController(MyDbContext _db) : ControllerBase
    {

        [HttpGet("main-menus")]
        public async Task<ActionResult<List<MainMenuDto>>> GetMainMenusAsync()
        {
            var mainMenus = await _db.MainMenus.Where(m => m.Active).Select(s => new MainMenuDto
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
        public async Task<ActionResult<MainMenuDto>> GetMainMenuByIDAsync(int id)
        {
            var mainMenu = await _db.MainMenus.AsNoTracking().Where(m => m.ID == id).Select(s => new MainMenuDto
            {
                ID = s.ID,
                Title = s.Title,
                Url = s.Url,
                Icon = s.Icon,
                Priority = s.Priority
            }).FirstOrDefaultAsync();
            return Ok(mainMenu);
        }

        [HttpGet("main-menus-by-IDs")]
        public async Task<ActionResult<List<MainMenuDto>>> GetMainMenusByIDsAsync([FromQuery] List<int> ids)
        {
            var mainMenus = await _db.MainMenus.AsNoTracking().Where(m => m.Active && ids.Contains(m.ID)).Select(s => new MainMenuDto
            {
                ID = s.ID,
                Title = s.Title,
                Url = s.Url,
                Icon = s.Icon,
                Priority = s.Priority
            }).ToListAsync();
            return Ok(mainMenus);
        }

        [HttpGet("sub-menus")]
        public async Task<ActionResult<List<SubMenuDto>>> GetSubMenusAsync()
        {
            var subMenus = await _db.SubMenus.AsNoTracking().Where(s => s.Active && s.MainMenu.Active).Select(s => new SubMenuDto
            {
                ID = s.ID,
                Title = s.Title,
                Url = s.Url,
                Icon = s.Icon,
                Priority = s.Priority,
                MainMenu = new MainMenuDto
                {
                    ID = s.MainMenu.ID,
                    Title = s.MainMenu.Title,
                    Url = s.MainMenu.Url,
                    Icon = s.MainMenu.Icon,
                    Priority = s.MainMenu.Priority
                }
            }).ToListAsync();
            return Ok(subMenus);
        }

        [HttpGet("sub-menu/{id}")]
        public async Task<ActionResult<SubMenuDto>> GetSubMenuByIDAsync(int id)
        {
            var subMenu = await _db.SubMenus.AsNoTracking().Where(s => s.Active && s.MainMenu.Active && s.ID == id).Select(s => new SubMenuDto
            {
                ID = s.ID,
                Title = s.Title,
                Url = s.Url,
                Icon = s.Icon,
                Priority = s.Priority,
                MainMenu = new MainMenuDto
                {
                    ID = s.MainMenu.ID,
                    Title = s.MainMenu.Title,
                    Url = s.MainMenu.Url,
                    Icon = s.MainMenu.Icon,
                    Priority = s.MainMenu.Priority
                }
            }).FirstOrDefaultAsync();
            return Ok(subMenu);
        }

    }
}
