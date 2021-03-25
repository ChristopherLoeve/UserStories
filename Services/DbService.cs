using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserStories.Models;
using Task = System.Threading.Tasks.Task;

namespace UserStories.Services
{
    public class DbService <T> where T : class
    {
        public async Task<List<T>> GetObjectsAsync()
        {
            using (var context = new UserStoriesDbContext())
            {
                return await context.Set<T>().AsNoTracking().ToListAsync();
            }
        }
        
        public async Task AddObjectAsync(T t)
        {
            using (var context = new UserStoriesDbContext())
            {
                context.Set<T>().Add(t);
                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveObjectAsync(T t)
        {
            using (var context = new UserStoriesDbContext())
            {
                context.Set<T>().Remove(t);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateObjectAsync(T t)
        {
            using (var context = new UserStoriesDbContext())
            {
                context.Set<T>().Update(t);
                await context.SaveChangesAsync();
            }
        }
    }
}
