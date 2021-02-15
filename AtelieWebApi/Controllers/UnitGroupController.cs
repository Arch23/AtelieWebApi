using Business.ApiModel;
using Business.Business.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtelieWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UnitGroupController : ControllerBase
    {
        private readonly IUnitGroupBusiness _unitGroupBusiness;
        private readonly ILogger<UnitGroupController> _logger;

        public UnitGroupController(
            ILogger<UnitGroupController> logger,
            IUnitGroupBusiness unitGroupBusiness
            )
        {
            _logger = logger;
            _unitGroupBusiness = unitGroupBusiness;
        }

        /// <summary>
        /// Gets all the unit groups
        /// </summary>
        /// <returns>The unit groups</returns>
        [HttpGet]
        public IActionResult GetUnitGroups() => Ok(_unitGroupBusiness.Get());

        /// <summary>
        /// Gets the unit group by Id
        /// </summary>
        /// <param name="model">The id of the unit group</param>
        /// <returns>The unit group</returns>
        [HttpGet("{id}")]
        public IActionResult GetUnitGroupById([FromRoute] long? id)
        {

            if (!id.HasValue || id.Value == 0)
            {
                return BadRequest();
            }

            var result = _unitGroupBusiness.Get(id.Value);

            return result != null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Create a new unit group
        /// </summary>
        /// <param name="model">The api model of the unit group</param>
        /// <returns>The Id of the new unit group</returns>
        [HttpPost]
        public IActionResult CreateUnitGroup([FromBody] UnitGroupApiModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            return Ok(_unitGroupBusiness.Insert(model));
        }

        /// <summary>
        /// Updates the unit group
        /// </summary>
        /// <param name="model">The api model of the unit group</param>
        /// <returns>True if the update was successful</returns>
        [HttpPut]
        public IActionResult UpdateUnitGroup([FromBody] UnitGroupApiModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            return Ok(_unitGroupBusiness.Update(model));
        }

        /// <summary>
        /// Deletes the unit group
        /// </summary>
        /// <param name="model">The id of the unit group</param>
        /// <returns>True if the delete was successful</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteUnitGroup([FromRoute] long? id)
        {
            if (!id.HasValue || id.Value == 0)
            {
                return BadRequest();
            }

            return Ok(_unitGroupBusiness.Delete(id.Value));
        }
    }
}
