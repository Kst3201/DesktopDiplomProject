using DesktopDiplomProject.ServerASP.Features.Authentification.Permissions;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.Drive;
using DiplomDataLibrary.Authentification.DTO;
using DiplomDataLibrary.PCComponents.DTO.Components;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DesktopDiplomProject.ServerASP.Controllers.Components
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DriveController : ControllerBase
    {
        private IDriveService _service;
        private ILogger<DriveController> _logger;

        public DriveController(IDriveService service, ILogger<DriveController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // GET: api/<DriveController>
        [HttpGet]
        [RequirePermission("PCComponents", PermissionAction.Read)]
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

        // GET api/<DriveController>/5
        [HttpGet("{name}")]
        [RequirePermission("PCComponents", PermissionAction.Read)]
        public async Task<IActionResult> Get(string name)
        {
            if (string.IsNullOrEmpty(name)) return BadRequest(name);
            try
            {
                var result = await _service.GetItem(name);
                return Ok(result);
            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound(name);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<DriveController>/5
        [HttpGet("ByFullname/{name}")]
        [RequirePermission("PCComponents", PermissionAction.Read)]
        public async Task<IActionResult> GetByFullname(string name)
        {
            if (string.IsNullOrEmpty(name)) return BadRequest(name);
            try
            {
                var result = await _service.GetItemByFullName(name);
                return Ok(result);
            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound(name);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<DriveController>
        [HttpPost]
        [RequirePermission("PCComponents", PermissionAction.Add)]
        public async Task<IActionResult> Post([FromBody] DriveDTO value)
        {
            try
            {
                var result = await _service.AddItem(value);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<DriveController>/5
        [HttpPut("{name}")]
        [RequirePermission("PCComponents", PermissionAction.Update)]
        public async Task<IActionResult> Put(string name, [FromBody] DriveDTO value)
        {
            try
            {
                var result = await _service.UpdateItem(name, value);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<DriveController>/5
        [HttpDelete("{named}")]
        [RequirePermission("PCComponents", PermissionAction.Delete)]
        public async Task<IActionResult> Delete(string name)
        {
            try
            {
                await _service.RemoveItem(name);
                return Ok();
            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound(name);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
