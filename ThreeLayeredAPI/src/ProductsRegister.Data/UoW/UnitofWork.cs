using ProductsRegister.Business.Interfaces;
using ProductsRegister.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsRegister.Data.UoW
{
    public class UnitofWork : IUnitofWork
    {
        private readonly MyDbContext _dbContext;

        public UnitofWork(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Commit()
        {
            return await _dbContext.SaveChangesAsync() > 0;
            // como é um bool, deve retornar uma condição booleana.
        }
    }
}
