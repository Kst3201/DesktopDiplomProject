using DesktopDiplomProject.ServerASP.Features.PCCombine.Services.PCBuild;
using DiplomDataLibrary.PCBuild;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DesktopDiplomProject.ServerASP.Controllers.PCBuild
{
    [Route("api/[controller]")]
    [ApiController]
    public class PCBuildController : ControllerBase
    {
        private IPCBuildService _buildService;
        private IPCUpgradeService _upgradeService;
        private ILogger<PCBuildController> _logger;

        public PCBuildController(IPCBuildService buildService
            , IPCUpgradeService upgradeService, ILogger<PCBuildController> logger)
        {
            _buildService = buildService;
            _upgradeService = upgradeService;
            _logger = logger;
        }

        // GET: api/<PCBuildController>
        [HttpPost("build")]
        public async Task<IActionResult> Build([FromBody] PCBuildRequest dto)
        {
            try
            {
                var list = await _buildService.BuildComputers(dto);
                if (list == null) return new BadRequestResult();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/<PCBuildController>
        [HttpPost("upgrade")]
        public async Task<IActionResult> Upgrade([FromBody] PCUpgradeRequest dto)
        {
            try
            {
                var list = await _upgradeService.UpgradeComputer(dto);
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
