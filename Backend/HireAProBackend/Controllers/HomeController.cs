using Microsoft.AspNetCore.Mvc;
using HireAProBackend.Services;
using HireAProBackend.Models;
using HireAProBackend.Templates;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HireAProBackend.Controllers
{
    [Route("api-mongodb/")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly MongoDBService MongoDBService;
        public IConfiguration _configuracion;
        private readonly IEmailService _emailService;
        private readonly IHmacShaHash _hmacShaHash;
        private readonly IShaHash _shaHash;
        private readonly IGenTokenReset _genTokenReset;
       
        public HomeController(MongoDBService MongoDBService, IConfiguration configuracion, IEmailService emailService, IHmacShaHash hmacShaHash, IShaHash shaHash, IGenTokenReset genTokenReset)
        {
            this.MongoDBService = MongoDBService;
            _configuracion = configuracion;
            _emailService = emailService;
            _hmacShaHash = hmacShaHash;
            _shaHash = shaHash;
            _genTokenReset = genTokenReset;
           
        }


        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] Models.RegisterRequest registerRequest)
        {
            EmailDTO welEmail = new EmailDTO();
            EmailContent emailContent = new EmailContent();
            string email = registerRequest.Email;
            string username = registerRequest.Username;
            string type = registerRequest.Type;
            welEmail.To = email;
            welEmail.Subject = emailContent.WelcomeSubject;
            string body = emailContent.WelBody(username);
            welEmail.Body = body;

            string hashedPassword = _shaHash.ComputeSha256Hash(registerRequest.Password);

            int timeout = 100000;
            var cancellationTokenSource = new CancellationTokenSource();

            // instancia de la colección de usuarios para hacerle consultas proximamente
            var coleccionUsers = MongoDBService._database.GetCollection<Usuario>("usuarios");

            // buscará el email de las isntancias de usuarios (p.Email) usando como parámetro para comparar el email (email)
            // que viene como parámetro
            var filtro = Builders<Usuario>.Filter.Eq(p => p.Email, email);

            // cantidad de isntancias de ese correo
            var count = coleccionUsers.CountDocuments(filtro);

            if (count == 1){
                return Unauthorized("Correo ya en uso.");
            }
            else{
                // mongodb necesita objetos instanciados para añadirlos en la base de datos
                Usuario nuevoUser = new Usuario(username, email, hashedPassword, type);

                coleccionUsers.InsertOne(nuevoUser);

                return Ok("Usuario registrado");
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] Models.LoginRequest loginRequest)
        {
            string correo = loginRequest.Email;
            string password = _shaHash.ComputeSha256Hash(loginRequest.Password);

            // instancia de la colección de usuarios para hacerle consultas proximamente
            var coleccionUsers = MongoDBService._database.GetCollection<Usuario>("usuarios");

            // buscar primero por correo
            var buscarPorMail = Builders<Usuario>.Filter.Or(
                Builders<Usuario>.Filter.Eq(u => u.Email, correo),
                Builders<Usuario>.Filter.Eq(u => u.Username, correo)
            );

            // la siguiente lsita de objetos va a sacar campos que se especifiquen sabiendo un solo cmapo de ese documento.
            // por ejemplo, sabiendo solo el mail, se podra sacar el nombre y l aocnraseña, necesario para crear el JWT
            var projection = Builders<BsonDocument>.Projection.Include("Username").Include("Password").Include("Email");

            // se aplica toda la poryección y se dará como resultado el usuario en cuestión
            var user = await coleccionUsers.Find(buscarPorMail).FirstOrDefaultAsync();


            // cantidad de isntancias de ese correo
            var countMail = coleccionUsers.CountDocuments(buscarPorMail);
            
            if (countMail == 1)
            {
                //Obtiene los datos desde appsettings.json
                var jwt = _configuracion.GetSection("Jwt").Get<Jwt>();

                var claims = new[]
                {
                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("email", user.Username),
                        new Claim("password", user.Password)

                    };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.LoginKey));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var newToken = new JwtSecurityToken(
                        jwt.Issuer,
                        jwt.Audience,
                        claims,
                        expires: DateTime.Now.AddDays(10),
                        signingCredentials: signIn

                );

                /*
                if (usuario.Verified == false)
                {
                    return StatusCode(403, "Tu cuenta no ha sido verificada");
                }
                */

                return Ok("Bienvenido, " + user.Username + "\n" + new JwtSecurityTokenHandler().WriteToken(newToken));

            }
            else
            {
                return BadRequest("Usuario no encontrado");
            }

        }
    }
}
