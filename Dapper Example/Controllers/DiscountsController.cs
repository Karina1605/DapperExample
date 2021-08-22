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
    [Route("Discounts")]
    public class DiscountsController : Controller
    {
        private readonly ICrudOperationsFull<Discount> _repository;
        public DiscountsController(IStoreDb store)
        {
            _repository = store.Discounts;
        }
        [HttpGet("SignOn")]
        public IActionResult AddNew()
        {
            return View();
        }
        public async Task<IActionResult> AddNew([FromBody] Discount discount)
        {
            var res = await _repository.Create(discount);
            if (res)
                return View();
            return StatusCode(500);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] Discount discount)
        {
            var res = await _repository.Delete(discount);
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
        public async Task<IActionResult> Update([FromBody] Discount discount)
        {
            var res = await _repository.Update(discount);
            if (res)
                return RedirectToAction("GetAll");
            return StatusCode(500);
        }
    }
}
