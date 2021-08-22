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
    [Route("Orders")]
    public class OrdersController : Controller
    {
        private readonly IStoreDb _repository;
        public OrdersController(IStoreDb store)
        {
            _repository = store;
        }
        [HttpGet("SignOn")]
        public async Task<IActionResult> AddNew()
        {
            ViewData["items"] = await _repository.Clients.GetAll();
            System.Diagnostics.Debug.WriteLine("Got clients in controller");
            //System.Diagnostics.Debug.WriteLine((ViewData["items"] as IEnumerable<Client>).Count());
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewOrder([FromBody] Order order)
        {
            var res = await _repository.Orders.Create(order);
            if (res)
                return RedirectToAction("GetAll");
            return StatusCode(500);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteClient([FromBody] Order order)
        {
            var res = await _repository.Orders.Delete(order);
            if (res)
                return RedirectToAction("GetAll");
            return StatusCode(500);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var res = await _repository.Orders.GetAll();
            return View(res);
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _repository.Orders.GetById(id);
            return View(res);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Order order)
        {
            var res = await _repository.Orders.Update(order);
            if (res)
                return RedirectToAction("GetAll");
            return StatusCode(500);
        }
    }
}
