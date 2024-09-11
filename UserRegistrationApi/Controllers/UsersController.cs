using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserRegistration.Models;
using UserRegistrationApi.Data;
using UserRegistrationApi.Models;

namespace UserRegistrationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            return Ok(user);
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var users = _context.Users.ToList();
            if (users == null || !users.Any())
            {
                return NotFound("No users found.");
            }
            return Ok(users);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User data is required.");
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateUserA(int id, [FromBody] User updatedUser)
        {
            var existingUser = _context.Users.FirstOrDefault(p => p.Id == id);
            if (existingUser == null)
            {
                return NotFound("User not found.");
            }

            existingUser.Age = updatedUser.Age;
            existingUser.Level = updatedUser.Level;
            existingUser.Height = updatedUser.Height;
            existingUser.Weight = updatedUser.Weight;
            existingUser.Gender = updatedUser.Gender;
            existingUser.MucTieu = updatedUser.MucTieu;
            existingUser.Fullname = updatedUser.Fullname;
            existingUser.Nickname = updatedUser.Nickname;
            existingUser.MobileNumber = updatedUser.MobileNumber;
            existingUser.Image = updatedUser.Image;


            _context.SaveChanges();

            return Ok(existingUser);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(p => p.Id == id);
            if (user == null)
            {
                return NotFound("user not found.");
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return NoContent();
        }





        [HttpPut("{id}/gender")]
        public async Task<IActionResult> UpdateGender(int id, [FromBody] string gender)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Gender = gender;

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Users.Any(e => e.Id == id))
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
        [HttpPut("{id}/MucTieu")]
        public async Task<IActionResult> UpdateGoal(int id, [FromBody] string muctieu)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.MucTieu = muctieu;

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Users.Any(e => e.Id == id))
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
        [HttpPut("{id}/Age")]
        public async Task<IActionResult> UpdateAge(int id, [FromBody] int Age)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Age = Age;

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Users.Any(e => e.Id == id))
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
        [HttpPut("{id}/Weight")]
        public async Task<IActionResult> UpdateWeight(int id, [FromBody] decimal Weight)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Weight = Weight;

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Users.Any(e => e.Id == id))
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
        [HttpPut("{id}/Height")]
        public async Task<IActionResult> UpdateHeight(int id, [FromBody] decimal Height)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Height = Height;

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Users.Any(e => e.Id == id))
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
        [HttpPut("{id}/Level")]
        public async Task<IActionResult> UpdateLevel(int id, [FromBody] string level)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Level = level;

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Users.Any(e => e.Id == id))
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
        [HttpPut("{id}/DetailUser")]
        public async Task<IActionResult> UpdateDetailUser(int id, [FromBody] UserUpdateDto updatedUser)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            // Cập nhật các thuộc tính của người dùng
            user.Fullname = updatedUser.Fullname;
            user.Nickname = updatedUser.Nickname;
            user.MobileNumber = updatedUser.MobileNumber;
            user.Image = updatedUser.Image;

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Users.Any(e => e.Id == id))
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

        // Đăng ký người dùng
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Kiểm tra người dùng đã tồn tại
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == user.Username);
            if (existingUser != null)
            {
                return Conflict("User already exists");
            }

            // Lưu người dùng mới
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(RegisterUser), new { id = user.Id }, user);
        }

        //login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var foundUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == loginModel.Username && u.Password == loginModel.Password);

            if (foundUser == null)
            {
                return Unauthorized("Invalid username or password");
            }

            // Tạo JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("NGUYENLEVIENHOCNGU@0766686630@0394440097");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, foundUser.Username),
            new Claim(ClaimTypes.NameIdentifier, foundUser.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // Trả về thông tin người dùng và token
            var userResponse = new
            {
                Id = foundUser.Id,
                Username = foundUser.Username,
                Email = foundUser.Email,
                Age = foundUser.Age,
                Fullname = foundUser.Fullname,
                Gender = foundUser.Gender,
                Height = foundUser.Height,
                Weight = foundUser.Weight,
                Image = foundUser.Image,
                Level = foundUser.Level,
                MobileNumber = foundUser.MobileNumber,
                MucTieu = foundUser.MucTieu,
                Nickname = foundUser.Nickname,
                Token = tokenString
            };

            return Ok(userResponse);
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            // Đăng xuất thường liên quan đến việc xóa token hoặc xóa thông tin xác thực từ client
            // Trong trường hợp này, bạn chỉ cần xóa token ở phía client, API không cần thực hiện thao tác gì thêm trên server

            // Ví dụ: Nếu bạn lưu token trên client (local storage, cookies), hãy đảm bảo xóa nó từ client khi gọi API này

            return Ok(new { message = "Logged out successfully" });
        }
    
}
}
