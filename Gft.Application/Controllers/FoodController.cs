using Gft.Domain.Entities;
using Gft.Domain.Interfaces.Repository;
using Gft.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace Gft.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _service;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogService _logService;
        public FoodController(IFoodService service, IUnitOfWork unitOfWork, ILogService logService)
        {
            _service = service;
            _unitOfWork = unitOfWork;
            _logService = logService;
        }

        [HttpGet]
        [Route("GetFoodByType")]
        public async Task<IActionResult> GetFoodByType(string type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var food = await _service.GetFoodByType(type);
                return Ok(food);
            }
            catch (Exception ex)
            {
                StackTrace stackTrace = new StackTrace();

                var errorLog = new LogEntity();
                errorLog.nomeMetodo = stackTrace.GetFrame(3).GetMethod().Name;
                errorLog.NomeController = $@"{ControllerContext.RouteData.Values["controller"]}";
                errorLog.errorMessage = ex.Message.ToString().Replace("'", " ");

                await _logService.InsertLog(errorLog);
                _unitOfWork.Commit();
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
                
            }
        }


        [HttpPost]
        [Route("InsertFood")]
        public async Task<IActionResult> InsertFood([FromBody] FoodEntity food)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var insertFood = await _service.InsertFood(food);
                
                    return Ok($"Usuario {food.Name} cadastrado com sucesso!");
                
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
