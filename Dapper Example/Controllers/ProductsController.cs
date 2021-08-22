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
    [Route("Products")]
    public class ProductsController :Controller
    {
        private readonly ICrudOperationsFull<Product> _repository;
        public ProductsController(IStoreDb store)
        {
            _repository = store.Products;
        }
        [HttpGet("SignOn")]
        public IActionResult AddNew()
        {
            return View();
        }
        public async Task<IActionResult> AddNew([FromBody] Product product)
        {
            var res = await _repository.Create(product);
            if (res)
                return View();
            return StatusCode(500);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] Product product)
        {
            var res = await _repository.Delete(product);
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
        public async Task<IActionResult> Update([FromBody] Product product)
        {
            var res = await _repository.Update(product);
            if (res)
                return RedirectToAction("GetAll");
            return StatusCode(500);
        }  
    }
}
