using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Task.Api.Domain.Entities;
using Test.Task.Api.Repository.Interfaces;

namespace Test.Task.Api.Repository
{
    public class TaskRepository : ITaskRepository
    {
        //** Se inyecta TasKContext
        private readonly TaskContext _context;
        public TaskRepository(TaskContext context) 
        { 
            _context = context;
        }
        //Borramos Tarea por EF
        public async Task<bool> DelTask(int id)
        {
            ETask? task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (task != null) 
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }            
            else
                return false;            


            return true;
        }
        //Obtenemos Tarea por Id por EF
        public async Task<ETask> GetTaskById(int id)
        {
            var result = await _context.Tasks                    
                    .FirstOrDefaultAsync(x => x.Id == id);
            return result ?? new ETask();
        }
        //Obtenemos Tareas por EF
        public async Task<List<ETask>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }
        //Insertamos  Tarea por EF
        public async Task<ETask> InsTask(ETask request)
        {
            try
            {
                EntityEntry<ETask> insTask = await _context.Tasks.AddAsync(request);
                await _context.SaveChangesAsync();
                return insTask.Entity;
            }
            catch(Exception ex)
            {
                return new ETask();
            }
            
        }
        //Actualizamos  Tarea por EF
        public async Task<bool> UpdTask(ETask request)
        {
            _context.Tasks.Update(request);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
