using AutoMapper;
using GyF_Api.Challenge.Service;
using GyF_Api_Challenge.Core.Dtos;
using GyF_Api_Challenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GyF_Api_Challenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        private readonly ILogger<ClienteController> _logger;
        private readonly IMapper _mapper;

        public ClienteController(/*ILogger<ClienteController> logger, ClienteService clienteService, IMapper mapper*/)
        {
            //_logger = logger;
            //_clienteService = clienteService;
            //_mapper = mapper;
        }


        [HttpGet]
        [Route("ListAll")]
        public async Task<IActionResult> List()
        {
            try
            {
                var result = await _clienteService.ListAllAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(List));

                return Problem("un problema ha ocurrido, vuelva a intentarlo en unos momentos", statusCode: 500);
            }
        }

        [HttpGet]
        [Route("ListActives")]
        public async Task<IActionResult> ListActives()
        {
            try
            {
                var result = await _clienteService.ListAllActivesAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(ListActives));

                return Problem("un problema ha ocurrido, vuelva a intentarlo en unos momentos", statusCode: 500);
            }
        }

        [HttpPost]
        public IActionResult Create(CreateClienteModel model)
        {
            try
            {
                var dto = _mapper.Map<CreateClienteDto>(model);

                var result = _clienteService.Create(dto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(ListActives));

                return Problem("un problema ha ocurrido, vuelva a intentarlo en unos momentos", statusCode: 500);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> Update(UpdateClienteModel model)
        {
            try
            {
                var dto = _mapper.Map<UpdateClienteDto>(model);

                await _clienteService.UpdateAsync(dto);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(ListActives));

                return Problem("un problema ha ocurrido, vuelva a intentarlo en unos momentos", statusCode: 500);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try {
           
                await _clienteService.DeleteLogicaly(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(Delete));

                return Problem("un problema ha ocurrido, vuelva a intentarlo en unos momentos", statusCode: 500);
            }
        }
    }
}
