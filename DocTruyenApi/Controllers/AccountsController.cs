using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DocTruyenApi.Models;
using DocTruyenApi.DTOs;
using AutoMapper;
using Microsoft.CodeAnalysis.Scripting;
using DocTruyenApi.Utils;


namespace DocTruyenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AccountsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            return await _context.Accounts.ToListAsync();
        }

        // GET: api/Accounts/5
        [HttpGet("login")]
        public async Task<ActionResult<AccountDTO>> GetAccount(string email, string password)
        {
            Account? account = await _context.Accounts.FirstOrDefaultAsync(a => a.Email == email);
            if (account == null)
            {
                return BadRequest("Email not existed");
            }
            if (BCrypt.Net.BCrypt.Verify(password, account.PasswordHash))
            {
                var accountDTO = _mapper.Map<AccountDTO>(account);
                return accountDTO;
            }
            return NotFound("Check your credentials");
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(int id, AccountDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var account = await _context.Accounts.FindAsync(id);
            if (id != dto.AccountId || account == null)
            {
                return BadRequest();
            }

            account.Email = dto.Email;
            account.PasswordHash = "";
            account.RoleId = dto.RoleId ?? 1;
            _context.Entry(account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("signup")]
        public async Task<ActionResult<Account>> PostAccount(AccountDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Account? existedAccount = _context.Accounts.FirstOrDefault(a => a.Email == dto.Email);
            if (existedAccount != null)
            {
                return BadRequest("Email already existed");
            }

            Account account = _mapper.Map<Account>(dto);
            account.PasswordHash = HashPassword(dto.Password);

            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();

            User user = new User()
            {
                AccountId = account.AccountId,
                UserName = UsernameGenerator.GenerateUsername(),
                Dob = DateTime.Now,
                Gender = true
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccount", new { id = account.AccountId }, account);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Helper method to hash passwords
        private string HashPassword(string password)
        {
            // Implement your hashing logic here, e.g., using a hashing library
            return BCrypt.Net.BCrypt.HashPassword(password);
        }


        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.AccountId == id);
        }
    }
}
