using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadyForItShop.Dtos;
using ReadyForItShop.Models;
using ReadyForItShop.Repositories;
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
    public class StoreController : ControllerBase
    {
        private readonly StoreService _storeService;

        public StoreController(StoreService storeService)
        {
            _storeService = storeService;
        }

        // GET: api/<StoreController>
        [HttpGet("GetAllStores")]
        public async Task<ActionResult> GetAllStores()
        {
            IEnumerable<StoreResponse> result;

            try
            {
                result = await _storeService.GetAllStoresAsync();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(result);
        }

        // GET api/<StoreController>/5
        [HttpGet("GetStoreById/{id}")]
        public async Task<ActionResult> GetStoreById(int id)
        {
            StoreResponse result;

            try
            {
                result = await _storeService.GetStoreByIdAsync(id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(result);
        }

        

        // POST api/<StoreController>
        [HttpPost("InsertStore")]
        public async Task<ActionResult> InsertStore([FromBody] StoreRequest p)
        {
            StoreResponse result;

            try
            {
                result = await _storeService.InsertStoreAsync(p);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

            return StatusCode(StatusCodes.Status201Created, result);
        }

        // PUT api/<StoreController>/5
        [HttpPut("UpdateStore/{id}")]
        public async Task<ActionResult> UpdateStore(int id, [FromBody] StoreRequest p)
        {
            StoreResponse result;
            try
            {
                result = await _storeService.UpdateStoreAsync(id, p);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

            return StatusCode(StatusCodes.Status200OK, result);
        }

        // DELETE api/<StoreController>/5
        [HttpDelete("DeleteStore/{id}")]
        public async Task<ActionResult> DeleteStore(int id)
        {
            StoreResponse result;

            try
            {
                result = await _storeService.DeleteStoreAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

            return StatusCode(StatusCodes.Status200OK, result);
        }

        // GET api/<StoreController>/5
        [HttpGet("GetProductQuantityByStore/{id}")]
        public ActionResult GetProductQuantityByStore(int id)
        {
            object result;

            try
            {
                result = _storeService.GetProductQuantityByStore(id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(result);
        }
    }
}
