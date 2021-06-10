using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using TaxiOperator.BLL.DAL;
using TaxiOperator.BLL.Manager;

namespace TaxiOperator.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class DataController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetCustomerList()
        {
            try
            {
                var lst = CustomerManager.GetList();
                if (lst.Count > 0)
                {
                    var retLst = JsonConvert.SerializeObject(CustomerManager.GetList(), Formatting.Indented,
                     new JsonSerializerSettings()
                     {
                         ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                     });
                    return Ok(retLst);
                }
                return Ok(null);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetById(int id)
        {
            try
            {
                return Ok(CustomerManager.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                CustomerManager.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public ActionResult SaveCustomer(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CustomerManager.Save(customer);
                    return Ok();
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
