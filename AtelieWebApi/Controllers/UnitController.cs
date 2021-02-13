using Business.ApiModel;
using Business.Business.Interface;
using Business.BusinessAggregator.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AtelieWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UnitController : ControllerBase
    {
        private readonly IUnitBusinessAggregator _unitBusinessAggregator;
        private readonly ILogger<MaterialController> _logger;

        public UnitController(
            ILogger<MaterialController> logger,
            IUnitBusinessAggregator unitBusinessAggregator
            )
        {
            _logger = logger;
            _unitBusinessAggregator = unitBusinessAggregator;
        }

        /// <summary>
        /// Gets all the units
        /// </summary>
        /// <returns>The units</returns>
        [HttpGet]
        [Route("GetUnits")]
        public IActionResult GetUnits() => Ok(_unitBusinessAggregator.GetUnits());

        /// <summary>
        /// Gets the unit by Id
        /// </summary>
        /// <param name="model">The id of the unit</param>
        /// <returns>The unit</returns>
        [HttpGet]
        [Route("GetUnitById/{id}")]
        public IActionResult GetUnitById([FromRoute] long? id)
        {

            if (!id.HasValue || id.Value == 0)
            {
                return BadRequest();
            }

            var result = _unitBusinessAggregator.GetUnit(id.Value);

            return result != null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Create a new unit
        /// </summary>
        /// <param name="model">The api model of the unit</param>
        /// <returns>The Id of the new unit</returns>
        [HttpPost]
        [Route("CreateUnit")]
        public IActionResult CreateUnit([FromBody] UnitApiModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var result = _unitBusinessAggregator.InsertUnit(model);

            return result != 0 ? Ok(result) : BadRequest();
        }

        /// <summary>
        /// Updates the unit
        /// </summary>
        /// <param name="model">The api model of the unit</param>
        /// <returns>True if the update was successful</returns>
        [HttpPut]
        [Route("UpdateUnit")]
        public IActionResult UpdateUnit([FromBody] UnitApiModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var result = _unitBusinessAggregator.UpdateUnit(model);

            return result ? Ok(result) : BadRequest();
        }

        /// <summary>
        /// Deletes the unit
        /// </summary>
        /// <param name="model">The id of the unit</param>
        /// <returns>True if the delete was successful</returns>
        [HttpDelete]
        [Route("DeleteUnit/{id}")]
        public IActionResult DeleteUnit([FromRoute] long? id)
        {
            if (!id.HasValue || id.Value == 0)
            {
                return BadRequest();
            }

            var result = _unitBusinessAggregator.DeleteUnit(id.Value);

            return result ? Ok(result) : NotFound();
        }



        /// <summary>
        /// Gets all the unit groups
        /// </summary>
        /// <returns>The unit groups</returns>
        [HttpGet]
        [Route("GetUnitGroups")]
        public IActionResult GetUnitGroups() => Ok(_unitBusinessAggregator.GetUnitGroups());

        /// <summary>
        /// Gets the unit group by Id
        /// </summary>
        /// <param name="model">The id of the unit group</param>
        /// <returns>The unit group</returns>
        [HttpGet]
        [Route("GetUnitGroupById/{id}")]
        public IActionResult GetUnitGroupById([FromRoute] long? id)
        {

            if (!id.HasValue || id.Value == 0)
            {
                return BadRequest();
            }

            var result = _unitBusinessAggregator.GetUnitGroup(id.Value);

            return result != null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Create a new unit group
        /// </summary>
        /// <param name="model">The api model of the unit group</param>
        /// <returns>The Id of the new unit group</returns>
        [HttpPost]
        [Route("CreateUnitGroup")]
        public IActionResult CreateUnitGroup([FromBody] UnitGroupApiModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var result = _unitBusinessAggregator.InsertUnitGroup(model);

            return result != 0 ? Ok(result) : BadRequest();
        }

        /// <summary>
        /// Updates the unit group
        /// </summary>
        /// <param name="model">The api model of the unit group</param>
        /// <returns>True if the update was successful</returns>
        [HttpPut]
        [Route("UpdateUnitGroup")]
        public IActionResult UpdateUnitGroup([FromBody] UnitGroupApiModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var result = _unitBusinessAggregator.UpdateUnitGroup(model);

            return result ? Ok(result) : BadRequest();
        }

        /// <summary>
        /// Deletes the unit group
        /// </summary>
        /// <param name="model">The id of the unit group</param>
        /// <returns>True if the delete was successful</returns>
        [HttpDelete]
        [Route("DeleteUnitGroup/{id}")]
        public IActionResult DeleteUnitGroup([FromRoute] long? id)
        {
            if (!id.HasValue || id.Value == 0)
            {
                return BadRequest();
            }

            var result = _unitBusinessAggregator.DeleteUnitGroup(id.Value);

            return result ? Ok(result) : NotFound();
        }
    }
}
