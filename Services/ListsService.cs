using System;
using System.Collections.Generic;
using TaskMaster.Models;
using TaskMaster.Repositories;

namespace TaskMaster.Services
{
    public class ListsService
    {
        private readonly ListsRepository _repo;

        public ListsService(ListsRepository repo)
        {
            _repo = repo;
        }
        //GET
        public IEnumerable<List> Get()
        {
            return _repo.Get();
        }

        //GET
        internal List GetById(string id)
        {
            List lists = _repo.Get(id);
            if (lists == null)
            {
                throw new Exception("invalid id");
            }
            return lists;
        }


        //CREATE/POST
        internal List Create(List newLists)
        {
            return _repo.Create(newLists);
        }

        //EDIT/PUT
        internal List Edit(List editLists)
        {
            List original = GetById(editLists.listId);

            original.Name = editLists.Name != null ? editLists.Name : original.Name;


            return _repo.Edit(original);
        }

        //DELORT
        internal List Delete(string id)
        {
            List original = GetById(id);
            _repo.Delete(id);
            return original; ;
        }
    }
}