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


        //GET ALL
        [HttpGet]
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

        //GET ONE BY ID
        [HttpGet("{listsId}")]
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

        //EDIT
        [HttpPut("{listsId}")]
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

        //CREATE
        [HttpPost]
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

        //DELETE
        [HttpDelete("{id}")]
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