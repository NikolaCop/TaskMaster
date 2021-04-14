using System;
using System.Collections.Generic;
using TaskMaster.Models;
using TaskMaster.Services;
using Microsoft.AspNetCore.Mvc;

namespace TaskMaster.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly TodosService _service;


        public TodosController(TodosService service)
        {
            _service = service;
        }


        //GET ALL
        [HttpGet]
        public ActionResult<IEnumerable<Todo>> Get()
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
        [HttpGet("{todosId}")]
        public ActionResult<Todo> GetById(string todosId)
        {
            try
            {
                return Ok(_service.GetById(todosId));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        //EDIT
        [HttpPut("{todosId}")]
        public ActionResult<Todo> editTodos(string todoId, Todo editTodos)
        {
            try
            {
                editTodos.todoId = todoId;
                return Ok(_service.Edit(editTodos));

            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        //CREATE
        [HttpPost]
        public ActionResult<Todo> Create([FromBody] Todo newTodos)
        {
            try
            {
                return Ok(_service.Create(newTodos));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        //DELETE
        [HttpDelete("{id}")]
        public ActionResult<string> DeleteTodos(string id)
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