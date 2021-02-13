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
        [HttpGet]
        [Route("GetFoodByTimeMeal")]
        public async Task<IActionResult> GetFoodByTimeMeal(string type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var food = await _service.GetFoodByTimeMeal(type);
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

        [HttpGet]
        [Route("GetAllFood")]
        public async Task<IActionResult> GetFood()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var food = await _service.GetAllFood();
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
                
                    return Ok($"{food.Name} cadastrado com sucesso!");
                
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPut]
        [Route("UpdateFood")]
        public async Task<IActionResult> Update([FromBody] FoodEntity food)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
               var update = await _service.UpdateFood(food);
                return Ok(food);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
