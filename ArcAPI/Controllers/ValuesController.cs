using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArcAPI.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Omise;
using Omise.Models;

namespace ArcAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ICompanyService _companyService;
        public ValuesController(ICompanyService companyService)
        {
            _companyService = companyService; 
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var item = _companyService.GetCompanyName();
            return Ok(new string[] { item });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/v
        [HttpPost]
        public async void Post([FromBody] chargesItem model)
        {
            var omise = new Client(skey: "skey_test_5ebu0qaf9yptjdvcfy2");

            var charge = await omise.Charges.Create(new Omise.Models.CreateChargeRequest
            {
                Amount = model.Amount,
                Currency = "THB",
                Card = model.Token
            });


        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class chargesItem
    {
        public string Token { get; set; }
        public int Amount { get; set; }

    }
}
