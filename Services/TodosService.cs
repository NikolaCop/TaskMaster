using System;
using System.Collections.Generic;
using TaskMaster.Models;
using TaskMaster.Repositories;

namespace TaskMaster.Services
{
    public class TodosService
    {
        private readonly TodosRepository _repo;

        public TodosService(TodosRepository repo)
        {
            _repo = repo;
        }
        //GET ALL ************************************
        public IEnumerable<Todo> Get()
        {
            return _repo.Get();
        }

        //GET ONE **********************************
        internal Todo GetById(string id)
        {
            Todo todos = _repo.Get(id);
            if (todos == null)
            {
                throw new Exception("invalid id");
            }
            return todos;
        }


        //CREATE******************************
        internal Todo Create(Todo newTodos)
        {
            return _repo.Create(newTodos);
        }

        //EDIT**********************************
        internal Todo Edit(Todo editTodos)
        {
            Todo original = GetById(editTodos.todoId);

            original.Name = editTodos.Name != null ? editTodos.Name : original.Name;


            return _repo.Edit(original);
        }

        //DELETE***********************************
        internal Todo Delete(string id)
        {
            Todo original = GetById(id);
            _repo.Delete(id);
            return original; ;
        }
    }
}