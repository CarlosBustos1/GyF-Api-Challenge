using AutoMapper;
using GyF_Api_Challenge.Core.Dtos;
using GyF_Api_Challenge.Core.Models;
using GyF_Api_Challenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GyF_Api.Challenge.Service
{
    public class ClienteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ClienteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ClienteDto>> ListAllAsync()
        {
            var result = await _unitOfWork.Clientes.GetAllAsync();
            var dto = _mapper.Map<List<ClienteDto>>(result);

            return dto;
        }

        public async Task<List<ClienteDto>> ListAllActivesAsync()
        {
            Expression<Func<Cliente, bool>> predicate = (x) => x.EstaActivo == true;
         
            var result = await _unitOfWork.Clientes.GetAllAsync(predicate);

            var dto = _mapper.Map<List<ClienteDto>>(result);

            return dto;
        }

        public int Create(BaseClienteDto dto)
        {
            var cliente = _mapper.Map<Cliente>(dto);


            _unitOfWork.Clientes.Persist(cliente);

            _unitOfWork.SaveChanges();

            return cliente.Id;
        }

        public async Task UpdateAsync(int id,BaseClienteDto dto)
        {
            var cliente = await _unitOfWork.Clientes.FindByIdAsync(id);

            if (cliente == null)
            {
                throw new Exception($"El cliente con Id {id} no existe");
            }

            cliente.Nombre = dto.Nombre;
            cliente.Telefono = dto.Telefono;
            cliente.Cuil = dto.Cuil;
            cliente.Genero = dto.Genero;
            cliente.FechaNacimiento = dto.FechaNacimiento;

            _unitOfWork.Clientes.Update(cliente);

            _unitOfWork.SaveChanges();


        }

        public async Task DeleteLogicalyAsync(int id)
        {
            var cliente = await _unitOfWork.Clientes.FindByIdAsync(id);

            if (cliente == null)
            {
                throw new Exception($"El cliente con Id {id} no existe");
            }

            cliente.EstaActivo = false;

            _unitOfWork.Clientes.Update(cliente);

            _unitOfWork.SaveChanges();

        }
    }
}
