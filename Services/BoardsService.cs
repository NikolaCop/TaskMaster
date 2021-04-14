using System;
using System.Collections.Generic;
using TaskMaster.Models;
using TaskMaster.Repositories;

namespace TaskMaster.Services
{
    public class BoardsService
    {
        private readonly BoardsRepository _repo;

        public BoardsService(BoardsRepository repo)
        {
            _repo = repo;
        }
        //GET ALL***************
        public IEnumerable<Board> Get()
        {
            return _repo.Get();
        }

        //GET ONE*****************
        internal Board GetById(string id)
        {
            Board boards = _repo.Get(id);
            if (boards == null)
            {
                throw new Exception("invalid id");
            }
            return boards;
        }


        //CREATE******************
        internal Board Create(Board newBoards)
        {
            return _repo.Create(newBoards);
        }

        //EDIT**********************
        internal Board Edit(Board editBoards)
        {
            Board original = GetById(editBoards.boardId);

            original.Name = editBoards.Name != null ? editBoards.Name : original.Name;


            return _repo.Edit(original);
        }

        //DELETE**********************
        internal Board Delete(string id)
        {
            Board original = GetById(id);
            _repo.Delete(id);
            return original; ;
        }

        internal object GetByAccountId(string id)
        {
            throw new NotImplementedException();
        }
    }
}