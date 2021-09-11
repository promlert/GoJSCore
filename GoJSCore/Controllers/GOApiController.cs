using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoJSCore.Models;
using GoJSCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GoJSCore.Controllers
{ 
    [ApiController]
    [Route("[controller]")]
    public class GOApiController : ControllerBase
    {

        private static readonly string[] Summaries = new[]
     {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly ILogger<GOApiController> _logger;
        private readonly IDapper _dapper;
        public GOApiController(IDapper dapper)
        {
            _dapper = dapper;
        }
        //public GOApiController(ILogger<GOApiController> logger)
        //{
        //    _logger = logger;
        //}

        [HttpPost(nameof(Create))]
        public async Task<int> Create([FromForm] PLCModel data)
        {
            //var dbparams = new DynamicParameters();
            //dbparams.Add("Id", data.Id, DbType.Int32);
            //var result = await Task.FromResult(_dapper.Insert<int>("[dbo].[SP_Add_Article]"
            //    , dbparams,
            //    commandType: CommandType.StoredProcedure));
            var result = await _dapper.Insert<PLCModel>(data);
            return result;
        }
        //[HttpGet(nameof(GetById))]
        [HttpGet("GetById/{Id}")]//GET api/terms/programs/name
        [ActionName(nameof(GetById))]
        public async Task<PLCModel> GetById(int Id)
        {
            var result = await Task.FromResult(_dapper.Get<PLCModel>(Id));
            return result;
        }
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
