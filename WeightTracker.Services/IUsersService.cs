using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WeightTracker.Data;
using WeightTracker.Models;

namespace WeightTracker.Services
{
    public interface IUsersService
    {
        IEnumerable<WeightsReportWeight> GetWeights(string name, string secretWord);
        Task<string> AddWeight(decimal weight, string name, string secretWord);
        bool CheckCredentials(string name, string secretWord);
        User GetUserBy(int id);
        User GetUserBy(string name);
        IEnumerable<Weight> Weights(Expression<Func<Weight, bool>> where);
        Task<int> RegisterNewUser(string name, string secretWord);
    }
}
