using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PhoenixBusiness;

namespace PhoenixAPI;

public class AuthorizeService
{
    private readonly IAdminRepository _adminRepository;
    private readonly IGuestRepository _guestRepository;
    private readonly IConfiguration _configuration;

    public AuthorizeService(IAdminRepository adminRepository, IGuestRepository guestRepository, IConfiguration configuration)
    {
        _adminRepository = adminRepository;
        _guestRepository = guestRepository;
        _configuration = configuration;
    }

    private string CreateToken(RequestDTO dTO){
        List<Claim> claims = new List<Claim>(){
            new Claim(ClaimTypes.NameIdentifier, dTO.Username),
            new Claim(ClaimTypes.Role, dTO.Role)
        };

        var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:Token").Value
                )
        );

        var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credential
        );

        var serializeToken = new JwtSecurityTokenHandler().WriteToken(token);
        return serializeToken;
    }

    public string GetToken(RequestDTO requestDTO){
        if(requestDTO.Role == "Administrator"){
            var model = _adminRepository.Get(requestDTO.Username);
            bool isCorrectPassword = BCrypt.Net.BCrypt.Verify(requestDTO.Password, model.Password.Trim());
            if(isCorrectPassword)
                return CreateToken(requestDTO);
            throw new NullReferenceException("Username or Password incorrect");
        }
        else{
            var model = _guestRepository.Get(requestDTO.Username);
            bool validationPassword = BCrypt.Net.BCrypt.Verify(requestDTO.Password, model.Password);
            if(validationPassword) return CreateToken(requestDTO);
            throw new NullReferenceException("Username or Password incorrect");
        }
    }
}
