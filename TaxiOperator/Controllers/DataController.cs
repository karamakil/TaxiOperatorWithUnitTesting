using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using TaxiOperator.BLL.Manager;

namespace TaxiOperator.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class DataController : ControllerBase
    {
        
        //[HttpGet("GetRandom")]
        [HttpGet]
        //[Authorize(Roles = "User")]
        public IActionResult GetRandom()
        {
            try
            {
                return Ok(CustomerManager.GetRandom());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("SetVip")]
        public IActionResult SetVip(int id)
        {
            try
            {
                CustomerManager.SetVip(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetCabDriverShifts")]
        public IActionResult GetCabDriverShifts()
        {
            try
            {
                return Ok(CabDriverManager.List());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}
