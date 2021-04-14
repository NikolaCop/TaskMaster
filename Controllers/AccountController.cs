using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskMaster.Models;
using TaskMaster.Services;

namespace TaskMaster.Controllers
{
    [ApiController]
    [Route("[controller]")]
    // REVIEW[epic=Authentication] this tag enforces the user must be logged in
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly ProfilesService _ps;
        private readonly BoardsService _boardsServ;

        public AccountController(ProfilesService ps, BoardsService boardsServ)
        {
            _ps = ps;
            _boardsServ = boardsServ;
        }

        [HttpGet]
        // REVIEW[epic=Authentication] async calls must return a System.Threading.Tasks, this is equivalent to a promise in JS
        public async Task<ActionResult<Profile>> Get()
        {
            try
            {
                // REVIEW[epic=Authentication] how to get the user info from the request token
                // same as to req.userInfo
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_ps.GetOrCreateProfile(userInfo));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // [HttpGet("boards")]
        // public async Task<ActionResult<IEnumerable<PartyPartyMemberViewModel>>> GetBoardsAsync()
        // {
        //     try
        //     {
        //         Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        //         return Ok(_boardsServ.GetByAccountId(userInfo.Id));
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }
    }
}