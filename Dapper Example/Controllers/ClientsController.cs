using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBaseConnector.CrudInterfaces;
using DataBaseConnector.DataBaseInterfaces;
using DataBaseClasses.Tables;

namespace Dapper_Example.Controllers
{
    [Route("Clients")]
    public class ClientsController : Controller
    {
        private readonly ICrudOperationsFull<Client> _repository;
        public ClientsController(IStoreDb store)
        {
            _repository = store.Clients;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("SignOn")]
        public IActionResult AddNew()
        {
            return View();
        }
        public async Task<IActionResult> AddNew([FromBody]Client client)
        {
            if (ModelState.IsValid)
            {
                var res = await _repository.Create(client);
                if (res)
                    return View();
            }
            
            return StatusCode(415, new {message ="Incorrect format" });
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] Client client)
        {
            var res = await _repository.Delete(client);
            if (res)
                return RedirectToAction("GetAll");
            return StatusCode(500);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var res = await _repository.GetAll();
            return View(res);
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _repository.GetById(id);
            return View(res);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Client client)
        {
            var res = await _repository.Update(client);
            if (res)
                return RedirectToAction("GetAll");
            return StatusCode(500);
        }
    }
}
