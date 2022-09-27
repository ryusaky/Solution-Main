using System;
using Microsoft.EntityFrameworkCore;
using Solution.CoreApp.BetterPlan.Data.Models;

namespace Solution.CoreApp.BetterPlan.Repositories
{
    public class UserRepository : IUserRepository
    {
        private CallengueContext _context;
        public UserRepository(CallengueContext context)
        {
            _context = context;
        }

        IEnumerable<User> IUserRepository.GetAll()
        {
            return _context.Users.Include(e => e.advisor).OrderByDescending(x => x.created).Skip(10).Take(10);
        }

        User IUserRepository.GetById(int id)
        {
            return _context.Users.Where(e => e.id == id).Include(e => e.advisor).First();
        }

        User IUserRepository.GetGoals(int id)
        {
            return _context.Users
                .Where(e => e.id == id)
                //.Include(e => e.goals)
                //.ThenInclude(g => g.GoalCategory)
                .Include(e => e.goals)
                .ThenInclude(g => g.FinancialEntity)
                .Include(e => e.goals)
                .ThenInclude(g=>g.PortFolio)
                .First();
        }
    }
}

