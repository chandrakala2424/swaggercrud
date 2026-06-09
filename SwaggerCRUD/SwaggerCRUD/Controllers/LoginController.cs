using System.Linq;
using System.Web.Http;
using SwaggerCRUD.Helpers;
using SwaggerCRUD.Models;

namespace SwaggerCRUD.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        AppDbContext db = new AppDbContext();

        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login(Login model)
        {
            var user = db.Users.FirstOrDefault(x =>
                x.Username == model.Username &&
                x.Password == model.Password);

            if (user == null)
                return Unauthorized();

            string token =
                JwtHelper.GenerateToken(user.Username);

            return Ok(new
            {
                message = "Login Success",
                token = token
            });
        }
    }
}