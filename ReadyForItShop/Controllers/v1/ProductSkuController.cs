using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadyForItShop.Dtos;
using ReadyForItShop.Models;
using ReadyForItShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReadyForItShop.Controllers.v1
{
    [Route("api/v1/")]
    [ApiController]
    public class ProductSkuController : ControllerBase
    {
        private readonly ProductSkuService _productSkuService;

        public ProductSkuController(ProductSkuService productSkuService)
        {
            _productSkuService = productSkuService;
        }

        // GET: api/<ProductSkuController>
        [HttpGet("GetAllProductSkus")]
        public async Task<ActionResult> GetAllProductSkus()
        {
            IEnumerable<ProductSkuResponse> result;

            try
            {
                result = await _productSkuService.GetAllProductSkusAsync();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(result);
        }

        // GET: api/<ProductSkuController>
        [HttpGet("GetTotalProductSkus")]
        public async Task<ActionResult> GetTotalProductSkus()
        {
            IEnumerable<ProductSkuResponse> result;

            try
            {
                result = await _productSkuService.GetAllProductSkusAsync();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(result);
        }

        // GET api/<ProductSkuController>/5
        [HttpGet("GetProductSkuById/{id}")]
        public async Task<ActionResult> GetProductSkuById(int id)
        {
            ProductSkuResponse result;

            try
            {
                result = await _productSkuService.GetProductSkuByIdAsync(id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(result);
        }

        // POST api/<ProductSkuController>
        [HttpPost("InsertProductSku")]
        public async Task<ActionResult> InsertProductSku([FromBody] ProductSkuRequest p)
        {
            ProductSkuResponse result;

            try
            {
                result = await _productSkuService.InsertProductSkuAsync(p);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

            return StatusCode(StatusCodes.Status201Created, result);
        }

        // PUT api/<ProductSkuController>/5
        [HttpPut("UpdateProductSku/{id}")]
        public async Task<ActionResult> UpdateProductSku(int id, [FromBody] ProductSkuRequest p)
        {
            ProductSkuResponse result;

            try
            {
                result = await _productSkuService.UpdateProductSkuAsync(id, p);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

            return StatusCode(StatusCodes.Status200OK, result);
        }

        // DELETE api/<ProductSkuController>/5
        [HttpDelete("DeleteProductSku/{id}")]
        public async Task<ActionResult> DeleteProductSku(int id)
        {
            ProductSkuResponse result;

            try
            {
                result = await _productSkuService.DeleteProductSkuAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
