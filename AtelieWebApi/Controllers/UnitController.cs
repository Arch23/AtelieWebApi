using Business.ApiModel;
using Business.Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AtelieWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UnitController : ControllerBase
    {
        private readonly IUnitBusiness _unitBusiness;
        private readonly ILogger<MaterialController> _logger;

        public UnitController(
            ILogger<MaterialController> logger,
            IUnitBusiness unitBusiness
            )
        {
            _logger = logger;
            _unitBusiness = unitBusiness;
        }

        /// <summary>
        /// Gets all the units
        /// </summary>
        /// <returns>The units</returns>
        [HttpGet]
        public IActionResult Get() => Ok(_unitBusiness.Get());

        /// <summary>
        /// Gets the unit by Id
        /// </summary>
        /// <param name="model">The id of the unit</param>
        /// <returns>The unit</returns>
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] long? id)
        {

            if (!id.HasValue || id.Value == 0)
            {
                return BadRequest();
            }

            var result = _unitBusiness.Get(id.Value);

            return result != null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Create a new unit
        /// </summary>
        /// <param name="model">The api model of the unit</param>
        /// <returns>The Id of the new unit</returns>
        [HttpPost]
        public IActionResult Create([FromBody] UnitApiModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            return Ok(_unitBusiness.Insert(model));
        }

        /// <summary>
        /// Updates the unit
        /// </summary>
        /// <param name="model">The api model of the unit</param>
        /// <returns>True if the update was successful</returns>
        [HttpPut]
        public IActionResult UpdateUnit([FromBody] UnitApiModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            return Ok(_unitBusiness.Update(model));
        }

        /// <summary>
        /// Deletes the unit
        /// </summary>
        /// <param name="model">The id of the unit</param>
        /// <returns>True if the delete was successful</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteUnit([FromRoute] long? id)
        {
            if (!id.HasValue || id.Value == 0)
            {
                return BadRequest();
            }

            return Ok(_unitBusiness.Delete(id.Value));
        }
    }
}
