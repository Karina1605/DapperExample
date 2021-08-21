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
    [Route("ProductsInOrders")]
    public class ProductsInOrdersController : Controller
    {
        private readonly ICrudOperationsFull<ProductInOrder> _repository;
        public ProductsInOrdersController(IStoreDb store)
        {
            _repository = store.ProductsInOrders;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("SignOn")]
        public IActionResult AddNew()
        {
            return View();
        }
        public async Task<IActionResult> AddNew([FromBody] ProductInOrder productInOrder)
        {
            var res = await _repository.Create(productInOrder);
            if (res)
                return View();
            return StatusCode(500);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] ProductInOrder productInOrder)
        {
            var res = await _repository.Delete(productInOrder);
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
        public async Task<IActionResult> UpdateClient([FromBody] ProductInOrder productInOrder)
        {
            var res = await _repository.Update(productInOrder);
            if (res)
                return RedirectToAction("GetAll");
            return StatusCode(500);
        }
    }
}
