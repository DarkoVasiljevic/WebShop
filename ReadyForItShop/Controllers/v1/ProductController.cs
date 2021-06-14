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
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet("GetAllProducts")]
        public async Task<ActionResult> GetAllProducts()
        {
            IEnumerable<ProductResponse> result;

            try
            {
                result =  await _productService.GetAllProductsAsync();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(result);
        }

       

        // GET api/<ProductController>/5
        [HttpGet("GetProductById/{id}")]
        public async Task<ActionResult> GetProductById(int id)
        {
            ProductResponse result;

            try
            {
                result = await _productService.GetProductByIdAsync(id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(result);
        }

        // POST api/<ProductController>
        [HttpPost("InsertProduct")]
        public async Task<ActionResult> InsertProduct([FromBody] ProductRequest p)
        {
            ProductResponse result;

            try
            {
                result = await _productService.InsertProductAsync(p);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

            return StatusCode(StatusCodes.Status201Created, result);
        }

        // PUT api/<ProductController>/5
        [HttpPut("UpdateProduct/{id}")]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody] ProductRequest p)
        {
            ProductResponse result;

            try
            {
                result = await _productService.UpdateProductAsync(id, p);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

            return StatusCode(StatusCodes.Status200OK, result);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("DeleteProduct/{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            ProductResponse result;

            try
            {
                result = await _productService.DeleteProductAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
