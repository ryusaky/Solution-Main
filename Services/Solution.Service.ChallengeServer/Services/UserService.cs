using System;
using Grpc.Core;
using Challenge;
using Solution.CoreApp.BetterPlan.Repositories;
using Google.Protobuf.WellKnownTypes;
using static Challenge.GoalModel.Types;
using System.Text.Json;

namespace Solution.Services.ChallengeServer.Services
{
    public class UserService : ChallengeUsers.ChallengeUsersBase
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IGoalRepository _goalRepository;
        public UserService(IUserRepository userRepository, IGoalRepository goalRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _goalRepository = goalRepository;
            _logger = logger;
        }

        #region Test Method Get All Element (Return Ten Elements)
        public override Task<GetUserListResponse> GetAllUsers(GetUserListRequest request, ServerCallContext context)
        {
            var result = _userRepository.GetAll().Select(e => new UserModel
            {
                Id = e.id,
                Firstname = e.firstname,
                Surname = e.surname,
                Advisorid = e.advisorid,
                Created = Timestamp.FromDateTimeOffset(e.created),
                Modified = Timestamp.FromDateTimeOffset(e.modified),
                Currencyid = e.currencyid,
                Advisor = new UserModel.Types.AdvisorModel
                {
                    Id = e.advisor.id,
                    Firstname = e.advisor.firstname,
                    Surname = e.advisor.surname
                }
            });
            var response = new GetUserListResponse();
            response.User.Add(result);
            return Task.FromResult(response);
        }
        #endregion

        #region Answer for Question Number One
        public override Task<QuestionOne> GetUserById(RequestId request, ServerCallContext context)
        {
            var myuser = _userRepository.GetById(request.Id);
            return Task.FromResult(new QuestionOne
            {
                Id = myuser.id,
                Userfullname = $"{myuser.surname} {myuser.firstname}",
                Advisorfullname = $"{myuser.advisor.surname} {myuser.advisor.firstname}",
                Created = Timestamp.FromDateTimeOffset(myuser.created)
            });
        }
        #endregion

        #region Answer for Question Number Four
        public override Task<UserQuestionFourth> GetAllGoalsByUserId(RequestId request, ServerCallContext context)
        {
            var myuser = _userRepository.GetGoals(request.Id);
            var response = new UserQuestionFourth
            {
                Id = myuser.id
            };
            response.Goal.AddRange(myuser.goals.Select(g => new GoalModel
            {
                //Id=g.id,
                Title = g.title,
                Years = g.years,
                Initialinvestment = g.initialinvestment,
                Monthlycontribution = g.monthlycontribution,
                Targetamount = g.targetamount,
                //Userid=g.userid,
                Financialentityid = g.financialentityid ?? 0,
                Financialentity = g.FinancialEntity != null ? new FinancialEntity
                {
                    Id = g.FinancialEntity.id,
                    Title = g.FinancialEntity.title
                } : null,
                //Modified = Timestamp.FromDateTimeOffset(g.modified),
                //Goalcategoryid = g.goalcategoryid,
                //Goalcategory = new GoalCategory
                //{
                //    Id = g.GoalCategory.id,
                //    Title = g.GoalCategory.title
                //},
                Created = Timestamp.FromDateTimeOffset(g.created),
                Portfolio = g.PortFolio != null ? new PortFolio
                {
                    Id = g.PortFolio.id,
                    Maxrangeyear = g.PortFolio.maxrangeyear,
                    Minrangeyear = g.PortFolio.minrangeyear,
                    Uuid = g.PortFolio.uuid,
                    Title = g.PortFolio.title,
                    Description = g.PortFolio.description,
                    Financialentityid = g.PortFolio.financialentityid,
                    Risklevelid = g.PortFolio.risklevelid,
                    Created = Timestamp.FromDateTimeOffset(g.PortFolio.created),
                    Modified = Timestamp.FromDateTimeOffset(g.PortFolio.modified),
                    Isdefault = g.PortFolio.isdefault,
                    Profitability = g.PortFolio.profitability?.ToString(),
                    Investmentstrategyid = g.PortFolio.investmentstrategyid,
                    Version = g.PortFolio.version,
                    Extraprofitabilitycurrencycode = g.PortFolio.extraprofitabilitycurrencycode ?? string.Empty,
                    Estimatedprofitability = g.PortFolio.estimatedprofitability,
                    Bpcomission = g.PortFolio.bpcomission,
                } : null
            }));
            return Task.FromResult(response);
        }
        #endregion

        public override Task<GoalQuestionFifth> GetDetailforGoal(RequestUserIdAndGoalId request, ServerCallContext context)
        {
            var goal = _goalRepository.GetGoal(request.Userid, request.Goalid);

            var response = new GoalQuestionFifth
            {
                Goal = new GoalModel
                {
                    //Id=g.id,
                    Title = goal.title,
                    Years = goal.years,
                    Initialinvestment = goal.initialinvestment,
                    Monthlycontribution = goal.monthlycontribution,
                    Targetamount = goal.targetamount,
                    //Userid=g.userid,
                    Financialentityid = goal.financialentityid ?? 0,
                    Financialentity = goal.FinancialEntity != null ? new FinancialEntity
                    {
                        Id = goal.FinancialEntity.id,
                        Title = goal.FinancialEntity.title
                    } : null,
                    //Modified = Timestamp.FromDateTimeOffset(g.modified),
                    //Goalcategoryid = g.goalcategoryid,
                    Goalcategory = new GoalCategory
                    {
                        Id = goal.GoalCategory.id,
                        Title = goal.GoalCategory.title
                    },
                    Created = Timestamp.FromDateTimeOffset(goal.created),
                    Portfolio = goal.PortFolio != null ? new PortFolio
                    {
                        Id = goal.PortFolio.id,
                        Maxrangeyear = goal.PortFolio.maxrangeyear,
                        Minrangeyear = goal.PortFolio.minrangeyear,
                        Uuid = goal.PortFolio.uuid,
                        Title = goal.PortFolio.title,
                        Description = goal.PortFolio.description,
                        Financialentityid = goal.PortFolio.financialentityid,
                        Risklevelid = goal.PortFolio.risklevelid,
                        Created = Timestamp.FromDateTimeOffset(goal.PortFolio.created),
                        Modified = Timestamp.FromDateTimeOffset(goal.PortFolio.modified),
                        Isdefault = goal.PortFolio.isdefault,
                        Profitability = goal.PortFolio.profitability?.ToString(),
                        Investmentstrategyid = goal.PortFolio.investmentstrategyid,
                        Version = goal.PortFolio.version,
                        Extraprofitabilitycurrencycode = goal.PortFolio.extraprofitabilitycurrencycode ?? string.Empty,
                        Estimatedprofitability = goal.PortFolio.estimatedprofitability,
                        Bpcomission = goal.PortFolio.bpcomission,
                    } : null
                }
            };

            return Task.FromResult(response);
        }
    }
}

