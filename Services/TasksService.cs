using System;
using System.Collections.Generic;
using TaskMaster.Models;
using TaskMaster.Repositories;

namespace TaskMaster.Services
{
    public class TasksService
    {
        private readonly TasksRepository _repo;

        public TasksService(TasksRepository repo)
        {
            _repo = repo;
        }
        //GET
        public IEnumerable<Task> Get()
        {
            return _repo.Get();
        }

        //GET
        internal Task GetById(string id)
        {
            Task tasks = _repo.Get(id);
            if (tasks == null)
            {
                throw new Exception("invalid id");
            }
            return tasks;
        }


        //CREATE/POST
        internal Task Create(Task newTasks)
        {
            return _repo.Create(newTasks);
        }

        //EDIT/PUT
        internal Task Edit(Task editTasks)
        {
            Task original = GetById(editTasks.taskId);

            original.Name = editTasks.Name != null ? editTasks.Name : original.Name;


            return _repo.Edit(original);
        }

        //DELORT
        internal Task Delete(string id)
        {
            Task original = GetById(id);
            _repo.Delete(id);
            return original; ;
        }
    }
}