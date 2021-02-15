using Business.ApiModel;
using Business.Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AtelieWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaterialController : ControllerBase
    {

        private readonly IMaterialBusiness _materialBusiness;
        private readonly ILogger<MaterialController> _logger;

        public MaterialController(
            ILogger<MaterialController> logger,
            IMaterialBusiness materialBusiness
            )
        {
            _logger = logger;
            _materialBusiness = materialBusiness;
        }

        /// <summary>
        /// Gets all the Materials
        /// </summary>
        /// <returns>The materials</returns>
        [HttpGet]
        public IActionResult Get() => Ok(_materialBusiness.Get());

        /// <summary>
        /// Gets the material by Id
        /// </summary>
        /// <param name="model">The id of the material</param>
        /// <returns>The material</returns>
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] long? id) { 

            if(!id.HasValue || id.Value == 0)
            {
                return BadRequest();
            }

            var result = _materialBusiness.Get(id.Value);

            return result != null ? Ok(result) : NotFound(); 
        }

        /// <summary>
        /// Create a new material
        /// </summary>
        /// <param name="model">The api model of the material</param>
        /// <returns>The Id of the new Material</returns>
        [HttpPost]
        public IActionResult Create([FromBody] MaterialApiModel model) { 
            if (model == null)
            {
                return BadRequest();
            }

            return Ok(_materialBusiness.Insert(model));
        }

        /// <summary>
        /// Updates the material
        /// </summary>
        /// <param name="model">The api model of the material</param>
        /// <returns>True if the update was successful</returns>
        [HttpPut]
        public IActionResult Update([FromBody] MaterialApiModel model) {
            if (model == null)
            {
                return BadRequest();
            }

            return Ok(_materialBusiness.Update(model));
        }

        /// <summary>
        /// Deletes the material
        /// </summary>
        /// <param name="model">The id of the material</param>
        /// <returns>True if the delete was successful</returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] long? id) {
            if (!id.HasValue || id.Value == 0)
            {
                return BadRequest();
            }

            return Ok(_materialBusiness.Delete(id.Value));
        }
    }
}
