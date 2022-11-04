using AutoMapper;
using GyF_Api.Challenge.Service;
using GyF_Api_Challenge.Api.Models;
using GyF_Api_Challenge.Core.Dtos;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class ClienteSeguroController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        private readonly ILogger<ClienteController> _logger;
        private readonly IMapper _mapper;

        public ClienteSeguroController(ILogger<ClienteController> logger, ClienteService clienteService, IMapper mapper)
        {
            _logger = logger;
            _clienteService = clienteService;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("ListAll")]
        public async Task<IActionResult> List()
        {
            try
            {
                var result = await _clienteService.ListAllAsync();

                var resultModel = _mapper.Map<List<ClienteModel>>(result);

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
        public IActionResult Create(BaseClienteModel model)
        {
            try
            {
                var dto = _mapper.Map<BaseClienteDto>(model);

                var result = _clienteService.Create(dto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(ListActives));

                return Problem("un problema ha ocurrido, vuelva a intentarlo en unos momentos", statusCode: 500);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, BaseClienteModel model)
        {
            try
            {
                var dto = _mapper.Map<BaseClienteDto>(model);

                await _clienteService.UpdateAsync(id, dto);

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
            try
            {

                await _clienteService.DeleteLogicalyAsync(id);

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
