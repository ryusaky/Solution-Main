using System;
using Microsoft.EntityFrameworkCore;
using Solution.CoreApp.BetterPlan.Data.Models;

namespace Solution.CoreApp.BetterPlan.Repositories
{
    public class GoalRepository : IGoalRepository
    {
        private ChallengeContext _context;
        public GoalRepository(ChallengeContext context)
        {
            _context = context;
        }
        public Goal GetGoal(int userId, int goalId)
        {
            return _context.Goals
                .Where(g => g.userid == userId && g.id == goalId)
                .Include(g=> g.FinancialEntity)
                .Include(g=>g.GoalCategory)
                .Include(g=>g.PortFolio)
                .First();
        }
    }
}

