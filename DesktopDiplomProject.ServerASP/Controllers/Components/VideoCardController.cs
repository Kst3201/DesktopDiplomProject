using DesktopDiplomProject.ServerASP.Features.Authentification.Permissions;
using DesktopDiplomProject.ServerASP.Features.ComponentManagement.Services.VideoCard;
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
    public class VideoCardController : ControllerBase
    {
        private IVideoCardService _service;
        private ILogger<VideoCardController> _logger;

        public VideoCardController(IVideoCardService service, ILogger<VideoCardController> logger)
        {
            _service = service;
            _logger = logger;
        }



        // GET: api/<VideoCardController>
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

        // GET api/<VideoCardController>/5
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

        // GET api/<VideoCardController>/5
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

        // GET api/<VideoCardController>/5
        [HttpGet("ByGPU/{name}")]
        [RequirePermission("PCComponents", PermissionAction.Read)]
        public async Task<IActionResult> GetByGPU(string name)
        {
            if (string.IsNullOrEmpty(name)) return BadRequest(name);
            try
            {
                var result = await _service.GetFirstItemByGPU(name);
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

        // POST api/<VideoCardController>
        [HttpPost]
        [RequirePermission("PCComponents", PermissionAction.Add)]
        public async Task<IActionResult> Post([FromBody] VideoCardDTO value)
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

        // PUT api/<VideoCardController>/5
        [HttpPut("{name}")]
        [RequirePermission("PCComponents", PermissionAction.Update)]
        public async Task<IActionResult> Put(string name, [FromBody] VideoCardDTO value)
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

        // DELETE api/<VideoCardController>/5
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
