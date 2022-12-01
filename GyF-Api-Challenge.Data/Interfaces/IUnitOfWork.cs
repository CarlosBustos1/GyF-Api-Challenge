using GyF_Api_Challenge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyF_Api_Challenge.Data.Interfaces
{
    public interface IUnitOfWork
    {
        public IUpdatableRepository<Cliente,int> Clientes { get; }

        public void SaveChanges();
    }
}
