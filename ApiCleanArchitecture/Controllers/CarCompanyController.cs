using ApiCleanArchitecture.Application;
using ApiCleanArchitecture.Core.Entities;
using ApiCleanArchitecture.Logging;
using ApiCleanArchitecture.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace ApiCleanArchitecture.Controllers
{
    [Route("api/autos")]
    [ApiController]
    public class CarCompanyController : ControllerBase
    {
        private readonly ICarCompanyHandler _createHandler;
        private readonly ICarCompanyHandler _updateHandler;
        private readonly ICarCompanyHandler _deleteHandler;

        public CarCompanyController(ICarCompanyHandler createHandler, ICarCompanyHandler updateHandler, ICarCompanyHandler deleteHandler)
        {
            _createHandler = createHandler;
            _updateHandler = updateHandler;
            _deleteHandler = deleteHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CarCompany carCompany)
        {
            await _createHandler.HandleAsync(carCompany);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CarCompany carCompany)
        {
            carCompany.Id = id;
            await _updateHandler.HandleAsync(carCompany);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _deleteHandler.HandleAsync(new CarCompany { Id = id });
            return Ok();
        }
    }

}
