using DesktopDiplomProject.ServerASP.Features.Authentification.Permissions;
using DesktopDiplomProject.ServerASP.Features.PCCombine.Services;
using DiplomDataLibrary.Authentification.DTO;
using DiplomDataLibrary.PCBuild;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DesktopDiplomProject.ServerASP.Controllers.PCBuild
{
    [Route("api/[controller]")]
    [ApiController]
    public class PCPresetController : ControllerBase
    {
        private PCPresetService _service;
        private ILogger<PCPresetController> _logger;

        public PCPresetController(PCPresetService service, ILogger<PCPresetController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // GET: api/<PCPresetController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = await _service.GetItems();
                if (list == null) return new BadRequestResult();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
