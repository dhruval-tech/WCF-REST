using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EBanking.Data;
using EBanking.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EBanking.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly MockBankingRepo _repository = new MockBankingRepo();
        // GET: api/<HomeController>
        [HttpGet]
        public ActionResult <IEnumerable<Users>> GetAllUsers()
        {
            var userItems = _repository.GetAllUsers();
            return Ok(userItems);
        }

        // GET api/<HomeController>/5
        [HttpGet("{id}")]
        public ActionResult <Users> GetUserById(int id)
        {
            var userItem = _repository.GetUserById(id);
            return Ok(userItem);
        }

        // POST api/<HomeController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<HomeController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<HomeController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
