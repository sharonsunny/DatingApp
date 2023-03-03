
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly DataContext _context;
        public BuggyController(DataContext context)
        {
            _context=context;
        }
        [Authorize]
        [HttpGet("auth")]
        public ActionResult<String> GetSecret(){
            return "Secret text";
        }

        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound(){
           var thing=_context.Users.Find(-1);
           if(thing==null)
           return NotFound();
           return thing;
        }
        [HttpGet("server-error")]
        public ActionResult<String> GetServerError(){
            // try{
            // var thing=_context.Users.Find(-1);
            // return thing.ToString();
            // }
            // catch(Exception ex)
            // {
            //     return StatusCode(500,"Computer says No!");
            // }
             var thing=_context.Users.Find(-1);
            return thing.ToString();
        }
        [HttpGet("bad-request")]
        public ActionResult<String> GetBadRequest(){
            return BadRequest("This was not a good request");
        }
    }
}