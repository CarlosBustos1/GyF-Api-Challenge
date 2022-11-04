using GyF_Api_Challenge.Core.Models;
using GyF_Api_Challenge.Data.Interfaces;
using GyF_Api_Challenge.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyF_Api_Challenge.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GyFContext _gyFContext;
        public UnitOfWork(GyFContext gyFContext)
        {
            _gyFContext = gyFContext;
        }
        public IUpdatebleRepository<Cliente, int> _clientes;

        public IUpdatebleRepository<Cliente, int> Clientes
        {
            get
            {
                if (_clientes == null)
                {
                    _clientes = new UpdatableRepository<Cliente, int>(_gyFContext);
                }

                return _clientes;
            }
        }

        public void SaveChanges()
        {
            _gyFContext.SaveChanges();
        }
    }
}
