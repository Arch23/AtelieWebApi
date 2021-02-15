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
    public class BrandController : ControllerBase
    {
        private readonly IBrandBusiness _brandBusiness;
        private readonly ILogger<BrandController> _logger;

        public BrandController(
            ILogger<BrandController> logger,
            IBrandBusiness brandBusiness
            )
        {
            _logger = logger;
            _brandBusiness = brandBusiness;
        }

        /// <summary>
        /// Gets all the brands
        /// </summary>
        /// <returns>The brands</returns>
        [HttpGet]
        public IActionResult Get() => Ok(_brandBusiness.Get());

        /// <summary>
        /// Gets the brand by Id
        /// </summary>
        /// <param name="model">The id of the brand</param>
        /// <returns>The brand</returns>
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] long? id)
        {

            if (!id.HasValue || id.Value == 0)
            {
                return BadRequest();
            }

            var result = _brandBusiness.Get(id.Value);

            return result != null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Create a new material
        /// </summary>
        /// <param name="model">The api model of the material</param>
        /// <returns>The Id of the new Material</returns>
        [HttpPost]
        public IActionResult Create([FromBody] BrandApiModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            return Ok(_brandBusiness.Insert(model));
        }

        /// <summary>
        /// Updates the material
        /// </summary>
        /// <param name="model">The api model of the material</param>
        /// <returns>True if the update was successful</returns>
        [HttpPut]
        public IActionResult Update([FromBody] BrandApiModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            return Ok(_brandBusiness.Update(model));
        }

        /// <summary>
        /// Deletes the material
        /// </summary>
        /// <param name="model">The id of the material</param>
        /// <returns>True if the delete was successful</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] long? id)
        {
            if (!id.HasValue || id.Value == 0)
            {
                return BadRequest();
            }

            return Ok(_brandBusiness.Delete(id.Value));
        }
    }
}
