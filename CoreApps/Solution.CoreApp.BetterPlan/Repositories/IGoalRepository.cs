using System;
using Solution.CoreApp.BetterPlan.Data.Models;

namespace Solution.CoreApp.BetterPlan.Repositories
{
    public interface IGoalRepository
    {
        Goal GetGoal(int userId, int goalId);
    }
}

