using System;
using System.Collections.Generic;
using TaskMaster.Models;
using TaskMaster.Services;
using Microsoft.AspNetCore.Mvc;

namespace TaskMaster.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly TasksService _service;


        public TasksController(TasksService service)
        {
            _service = service;
        }


        //GET ALL
        [HttpGet]
        public ActionResult<IEnumerable<Task>> Get()
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
        [HttpGet("{tasksId}")]
        public ActionResult<Task> GetById(string tasksId)
        {
            try
            {
                return Ok(_service.GetById(tasksId));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        //EDIT
        [HttpPut("{tasksId}")]
        public ActionResult<Task> editTasks(string taskId, Task editTasks)
        {
            try
            {
                editTasks.taskId = taskId;
                return Ok(_service.Edit(editTasks));

            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        //CREATE
        [HttpPost]
        public ActionResult<Task> Create([FromBody] Task newTasks)
        {
            try
            {
                return Ok(_service.Create(newTasks));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        //DELETE
        [HttpDelete("{id}")]
        public ActionResult<string> DeleteTasks(string id)
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