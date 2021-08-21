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
        private readonly ICrudOperationsFull<Order> _repository;
        public OrdersController(IStoreDb store)
        {
            _repository = store.Orders;
        }
        [HttpGet("SignOn")]
        public IActionResult AddNew()
        {
            return View();
        }
        public async Task<IActionResult> AddNew([FromBody] Order order)
        {
            var res = await _repository.Create(order);
            if (res)
                return View();
            return StatusCode(500);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteClient([FromBody] Order order)
        {
            var res = await _repository.Delete(order);
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
        public async Task<IActionResult> Update([FromBody] Order order)
        {
            var res = await _repository.Update(order);
            if (res)
                return RedirectToAction("GetAll");
            return StatusCode(500);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
