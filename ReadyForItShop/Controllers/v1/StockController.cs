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
    public class StockController : ControllerBase
    {
        private readonly StockService _stockService;

        public StockController(StockService stockService)
        {
            _stockService = stockService;
        }

        // GET: api/<StockController>
        [HttpGet("GetAllStocks")]
        public async Task<ActionResult> GetAllStocks()
        {
            IEnumerable<StockResponse> result;

            try
            {
                result = await _stockService.GetAllStocksAsync();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(result);
        }

        // GET api/<StockController>/5
        [HttpGet("GetStockById/{id}")]
        public async Task<ActionResult> GetStockById(int id)
        {
            StockResponse result;

            try
            {
                result = await _stockService.GetStockByIdAsync(id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(result);
        }

        // POST api/<StockController>
        [HttpPost("InsertStock")]
        public async Task<ActionResult> InsertStock([FromBody] StockRequest p)
        {
            StockResponse result;

            try
            {
                result = await _stockService.InsertStockAsync(p);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

            return StatusCode(StatusCodes.Status201Created, result);
        }

        // PUT api/<StockController>/5
        [HttpPut("UpdateStock/{id}")]
        public async Task<ActionResult> UpdateStock(int id, [FromBody] StockRequest p)
        {
            StockResponse result;
            try
            {
                result = await _stockService.UpdateStockAsync(id, p);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

            return StatusCode(StatusCodes.Status200OK, result);
        }

        // DELETE api/<StockController>/5
        [HttpDelete("DeleteStock/{id}")]
        public async Task<ActionResult> DeleteStock(int id)
        {
            StockResponse result;

            try
            {
                result = await _stockService.DeleteStockAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
