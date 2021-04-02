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
    [Route("api/accounts")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IBankingRepo _repository;

        public  HomeController(IBankingRepo repository)
        {
            _repository = repository;
        }
   
        [HttpGet]
        public ActionResult <IEnumerable<Accounts>> getAllAccounts()
        {
            var userItems = _repository.getAllAccounts();
            return Ok(userItems);
        }
         
        [HttpGet("{id}")]
        public ActionResult <Accounts> getAccount(int id)
        {
            var userItem = _repository.getAccount(id);
            return Ok(userItem);
        }

        [HttpPost]
        public ActionResult addAccount(Accounts accounts)
        {
            Accounts temp = new Accounts();
            temp.FirstName = accounts.FirstName;
            temp.LastName = accounts.LastName;
            temp.Address = accounts.Address;
            temp.Email = accounts.Email;
            temp.Balance = accounts.Balance;
            temp.Contact = accounts.Contact;
            _repository.addAccount(temp);
            return Ok();
        }

        [HttpDelete("{id}")]

        public ActionResult deleteAccount(int id)
        {
            var temp = _repository.deleteAccount(id);
            if (temp == false)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }


        }

        [HttpPut("{id}")]
        public ActionResult updateAccount(int id, Accounts accounts)
        {
            Accounts temp = _repository.getAccount(id);
            temp.FirstName = accounts.FirstName;
            temp.LastName = accounts.LastName;
            temp.Address = accounts.Address;
            temp.Email = accounts.Email;
            temp.Balance = accounts.Balance;
            temp.Contact = accounts.Contact;
            _repository.updateAccount(temp);

            return Ok();
        }


    }
}
