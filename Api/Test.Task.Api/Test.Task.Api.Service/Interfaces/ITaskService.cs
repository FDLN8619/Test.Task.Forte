using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Task.Api.Domain.Entities;

namespace Test.Task.Api.Service.Interfaces
{
    public interface ITaskService
    {
        Task<List<ETask>> GetTasks();
        Task<ETask> GetTaskById(int id);
        Task<ETask> InsTask(ETask request);
        Task<bool> UpdTask(ETask request);
        Task<bool> DelTask(int id);
    }
}
