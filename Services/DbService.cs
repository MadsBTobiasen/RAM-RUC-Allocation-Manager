using RAM___RUC_Allocation_Manager;
using System;
using RAM___RUC_Allocation_Manager;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RAM___RUC_Allocation_Manager.Models;

namespace RAM___RUC_Allocation_Manager.Services
{
    public class DbService<T> where T : class
    {
        public async Task<IEnumerable<T>> GetObjectsAsync()
        {
            using (var context = new RUCDBContext())
            {
                return await context.Set<T>().AsNoTracking().ToListAsync();
            }
        }

        public async Task AddObjectAsync(T obj)
        {
            using (var context = new RUCDBContext())
            {
                context.Set<T>().Add(obj);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteObjectAsync(T obj)
        {
            using (var context = new RUCDBContext())
            {
                context.Set<T>().Remove(obj);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateObjectAsync(T obj)
        {
            using (var context = new RUCDBContext())
            {
                context.Set<T>().Update(obj);
                await context.SaveChangesAsync();
            }
        }

        public async Task<T> GetObjectByIdAsync(int id)
        {
            using (var context = new RUCDBContext())
            {
                return await context.Set<T>().FindAsync(id);
            }


        }
    }
}
