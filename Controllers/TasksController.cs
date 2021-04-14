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



        [HttpGet] //Get
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

        [HttpGet("{tasksId}")] //Get By ID
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

        [HttpPut("{tasksId}")] //EDIT
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


        [HttpPost] //Create
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

        [HttpDelete("{id}")] //Delort
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