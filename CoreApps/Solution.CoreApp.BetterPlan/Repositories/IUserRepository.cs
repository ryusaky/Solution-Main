using System;
using Solution.CoreApp.BetterPlan.Data.Models;

namespace Solution.CoreApp.BetterPlan.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        User GetGoals(int id);
        //void Create(User model);
        //void Update(int id, User model);
        //void Delete(int id);
    }
}

