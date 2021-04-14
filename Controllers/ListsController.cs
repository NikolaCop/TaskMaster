using System;
using System.Collections.Generic;
using TaskMaster.Models;
using TaskMaster.Services;
using Microsoft.AspNetCore.Mvc;

namespace TaskMaster.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListsController : ControllerBase
    {
        private readonly ListsService _service;


        public ListsController(ListsService service)
        {
            _service = service;
        }



        [HttpGet] //Get
        public ActionResult<IEnumerable<List>> Get()
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

        [HttpGet("{listsId}")] //Get By ID
        public ActionResult<List> GetById(string listsId)
        {
            try
            {
                return Ok(_service.GetById(listsId));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{listsId}")] //EDIT
        public ActionResult<List> editLists(string listId, List editLists)
        {
            try
            {
                editLists.listId = listId;
                return Ok(_service.Edit(editLists));

            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }


        [HttpPost] //Create
        public ActionResult<List> Create([FromBody] List newLists)
        {
            try
            {
                return Ok(_service.Create(newLists));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")] //Delort
        public ActionResult<string> DeleteLists(string id)
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