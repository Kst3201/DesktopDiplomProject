using DesktopDiplomProject.ServerASP.Features.Authentification.Permissions;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.RAM;
using DiplomDataLibrary.Authentification.DTO;
using DiplomDataLibrary.PCComponents.DTO.Components;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DesktopDiplomProject.ServerASP.Controllers.Components
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RAMController : ControllerBase
    {
        private IRAMService _service;
        private ILogger<RAMController> _logger;

        public RAMController(IRAMService service, ILogger<RAMController> logger)
        {
            _service = service;
            _logger = logger;
        }



        // GET: api/<RAMController>
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

        // GET api/<RAMController>/5
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

        // GET api/<RAMController>/5
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

        // POST api/<RAMController>
        [HttpPost]
        [RequirePermission("PCComponents", PermissionAction.Add)]
        public async Task<IActionResult> Post([FromBody] RAMDTO value)
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

        // PUT api/<RAMController>/5
        [HttpPut("{name}")]
        [RequirePermission("PCComponents", PermissionAction.Update)]
        public async Task<IActionResult> Put(string name, [FromBody] RAMDTO value)
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

        // DELETE api/<RAMController>/5
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
