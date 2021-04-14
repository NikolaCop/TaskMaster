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
        //GET ALL ************************************
        public IEnumerable<Task> Get()
        {
            return _repo.Get();
        }

        //GET ONE **********************************
        internal Task GetById(string id)
        {
            Task tasks = _repo.Get(id);
            if (tasks == null)
            {
                throw new Exception("invalid id");
            }
            return tasks;
        }


        //CREATE******************************
        internal Task Create(Task newTasks)
        {
            return _repo.Create(newTasks);
        }

        //EDIT**********************************
        internal Task Edit(Task editTasks)
        {
            Task original = GetById(editTasks.taskId);

            original.Name = editTasks.Name != null ? editTasks.Name : original.Name;


            return _repo.Edit(original);
        }

        //DELETE***********************************
        internal Task Delete(string id)
        {
            Task original = GetById(id);
            _repo.Delete(id);
            return original; ;
        }
    }
}