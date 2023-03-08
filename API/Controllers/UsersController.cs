using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : BaseApiController
    {
        // private readonly DataContext _context;
        // public UsersController(DataContext context)
        // {
        //     this._context = context;
        // }
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper ;
        public UsersController(IUserRepository userRepository,IMapper mapper)
        {
            this._mapper = mapper;
            this._userRepository = userRepository;
            
           
        }

        [HttpGet]
      //  [AllowAnonymous]
    //   public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        // public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        // {
        //     // var users = await _context.Users.ToListAsync();
        //     // return users;
        //     // return Ok(await _userRepository.GetUsersAsync());
        //     var users=await _userRepository.GetUsersAsync();
        //     var usersToReturn=_mapper.Map<IEnumerable<MemberDto>>(users);
        //     return Ok(usersToReturn);
        // }
         public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            // var users = await _context.Users.ToListAsync();
            // return users;
            // return Ok(await _userRepository.GetUsersAsync());
            return Ok(await _userRepository.GetMembersAsync());
         
        }
        
        // [HttpGet("{Id}")]
        // public async Task<ActionResult<AppUser>> GetUser(int id)
        // {
        //     return await _context.Users.FindAsync(id);
        // }

          
        [HttpGet("{username}")]
        // public async Task<ActionResult<AppUser>> GetUser(string username)
        // public async Task<ActionResult<MemberDto>> GetUser(string username)
        // {
        //    // return await _userRepository.GetUserByUsername(username);
        //    var user=await _userRepository.GetUserByUsername(username);
        //    var userToReturn=_mapper.Map<MemberDto>(user);
        //    return userToReturn;
        // }

           public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
           return await _userRepository.GetMemberAsync(username);
          
        }
    }
}