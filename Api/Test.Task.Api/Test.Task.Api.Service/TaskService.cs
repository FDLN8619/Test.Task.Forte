using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Task.Api.Domain.Entities;
using Test.Task.Api.Repository.Interfaces;
using Test.Task.Api.Service.Interfaces;

namespace Test.Task.Api.Service
{
    public class TaskService : ITaskService 
    {
        //Se inyecta Interfaz de repository
        private readonly ITaskRepository _repository;
        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        //** Se implemetan metodos de la interfaz repository

        public Task<bool> DelTask(int id)
        {
            return _repository.DelTask(id);
        }

        public Task<ETask> GetTaskById(int id)
        {
           return _repository.GetTaskById(id);
        }

        public Task<List<ETask>> GetTasks()
        {
            return _repository.GetTasks();
        }

        public async Task<ETask> InsTask(ETask request)
        {
            var response = new ETask();
            if (request.Tittle == null || request.Tittle == string.Empty)
                throw new Exception("El titulo es obligatorio!"); 
            else
               response = await _repository.InsTask(request);

            return response;
        }

        public Task<bool> UpdTask(ETask request)
        {
            return _repository.UpdTask(request);
        }
    }
}
