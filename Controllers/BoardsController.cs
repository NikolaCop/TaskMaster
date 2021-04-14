using System;
using System.Collections.Generic;
using TaskMaster.Models;
using TaskMaster.Services;
using Microsoft.AspNetCore.Mvc;

namespace TaskMaster.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoardsController : ControllerBase
    {
        private readonly BoardsService _service;


        public BoardsController(BoardsService service)
        {
            _service = service;
        }


        //GET ALL
        [HttpGet]
        public ActionResult<IEnumerable<Board>> Get()
        {
            try
            {
                return Ok(_service.Get());
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        //GET ONE BY ID
        [HttpGet("{boardsId}")]
        public ActionResult<Board> GetById(string boardsId)
        {
            try
            {
                return Ok(_service.GetById(boardsId));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        //EDIT
        [HttpPut("{boardsId}")]
        public ActionResult<Board> editBoards(string boardId, Board editBoards)
        {
            try
            {
                editBoards.boardId = boardId;
                return Ok(_service.Edit(editBoards));

            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        //CREATE
        [HttpPost]
        public ActionResult<Board> Create([FromBody] Board newBoards)
        {
            try
            {
                return Ok(_service.Create(newBoards));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        //DELETE
        [HttpDelete("{id}")]
        public ActionResult<string> DeleteBoards(string id)
        {
            try
            {
                return Ok(_service.Delete(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}