using JSONStorageAPI.Services.JSONFileService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JSONStorageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JSONFileController : ControllerBase
    {
        private readonly IJSONFileService _jsonFileService;
        public JSONFileController(IJSONFileService jsonFileService)
        {
            _jsonFileService = jsonFileService;
        }

        [HttpGet]
        public async Task<ActionResult<List<JSONFile>>> GetAllJSONFiles() 
        {
            var result = await _jsonFileService.GetAllJSONFiles();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JSONFile>> GetJSONFileById(int id)
        {
            var result = await _jsonFileService.GetJSONFileById(id);
            if (result is null)
                return NotFound("JSON file not found.");
            return Ok(result);
        }


        [HttpPost]
        //this should change, it probably doesn't need to return the list.
        public async Task<ActionResult<List<JSONFile>>> AddJSONFile([FromBody]JSONFile reqFile)
        {
            var result = await _jsonFileService.AddJSONFile(reqFile);
            return Ok(result);
        }


        [HttpPut]
        //this should change, it probably doesn't need to return the list.
        public async Task<ActionResult<List<JSONFile>>> UpdateJSONFile([FromBody] JSONFile reqFile)
        {
            var result = await _jsonFileService.UpdateJSONFile(reqFile);
            if (result is null)
                return NotFound("JSON file not found.");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<JSONFile>>> DeleteJSONFileById(int id)
        {
            var result = await _jsonFileService.DeleteJSONFileById(id);
            if (result is null)
                return NotFound("JSON file not found.");
            return Ok(result);
        }
    }
}
