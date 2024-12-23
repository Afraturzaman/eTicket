using eTicket.Data.Base;
using eTicket.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Data.Services
{
    public class ActorService : EntityBaseRepository<Actor>,IActorService
    {
        //private readonly AppDbContext _context;
        public ActorService(AppDbContext context):base(context)
        {
            
        }
        //public async Task AddAsync(Actor actor)
        //{
        //    await _context.Actors.AddAsync(actor);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    var result = await _context.Actors.FirstOrDefaultAsync(x => x.Id == id);
        //    _context.Actors.Remove(result);
        //    await _context.SaveChangesAsync();
        
        //}

        //public async Task<IEnumerable<Actor>> GetAllAsync()
        //{
        //    var result =await _context.Actors.ToListAsync();
        //    return result;
        //}

        //public async Task<Actor> GetByIdAsync(int id)
        //{
        //    var result = await _context.Actors.FirstOrDefaultAsync(x => x.Id == id);
        //    return result;
        //}

        //public async Task<Actor> UpdateAsync(int id, Actor actor)
        //{
        //    _context.Update(actor);
        //    await _context.SaveChangesAsync();

        //    return actor;
        //}
    }
}
