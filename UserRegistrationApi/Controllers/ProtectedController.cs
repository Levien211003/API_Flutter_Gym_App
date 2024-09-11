using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserRegistrationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProtectedController : ControllerBase
    {
        // Endpoint này yêu cầu người dùng phải được xác thực
        [HttpGet("securedata")]
        [Authorize]
        public async Task<IActionResult> GetSecureData()
        {
            // Đây là ví dụ đơn giản để trả về dữ liệu bảo mật
            var secureData = new
            {
                Message = "This is secured data",
                Date = DateTime.UtcNow
            };

            return Ok(secureData);
        }
    }
}
