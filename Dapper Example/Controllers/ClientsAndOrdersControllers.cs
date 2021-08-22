using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBaseConnector.CrudInterfaces;
using DataBaseConnector.DataBaseInterfaces;
using DataBaseClasses.Views;
namespace Dapper_Example.Controllers
{
    [Route("ClientsAndOrders")]
    public class ClientsAndOrdersController : Controller
    {
        private readonly ICrudOperationsShort<ClientsAndOrders> _repository;
        public ClientsAndOrdersController(IStoreDb store)
        {
            _repository = store.ClientsAndOrders;
        }
     
        [HttpGet("GetAllClientsWithTheirOrders")]
        public async Task<IActionResult> GetAllClientsWithTheirOrders()
        {
            var res = await _repository.GetAll();
            return View(res);
        }

        [HttpGet("GetFullById/{Id}")]
        public async Task<IActionResult> GetFullById(int id)
        {
            var res = await _repository.GetById(id);
            return View(res);
        }

    }
}
