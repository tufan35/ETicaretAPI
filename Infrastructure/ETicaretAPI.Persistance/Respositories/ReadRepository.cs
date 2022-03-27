using ETicaretAPI.Application.Respositories;
using ETicaretAPI.Persistance.Contexts;
using ETicatetAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistance.Respositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ETicaretDbContext _context;

        public ReadRepository(ETicaretDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll() => Table;


        public async Task<T> GetByIdAsync(string id)
        //=> await Table.FirstOrDefaultAsync(data  => data.Id == Guid.Parse(id));
        => await Table.FindAsync(Guid.Parse(id));

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        => await Table.FirstOrDefaultAsync(method);
            

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
       => Table.Where(method);
    }
}
