using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.Task.Api.Domain.Entities;

namespace Test.Task.Api.Repository.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<ETask>> GetTasks();
        Task<ETask> GetTaskById(int id);
        Task<ETask> InsTask(ETask request);
        Task<bool> UpdTask(ETask request);
        Task<bool> DelTask(int id);
    }
}
